using System;

using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PDA
{
    class PartDisk : IMySerializable
    {
        #region 私有字段
        private DataTable diskDataSource;
        private Dictionary<string, Disk> disks;
        private Dictionary<string, SKU> skus;
        private List<string> subDiskIds;
        private Disk currentDisk;
        #endregion
        #region 公共属性
        public static string TempFileUrl
        {
            get
            {
                return DB.RootPath+@"BackUp\Part";
            }
        }
        public Dictionary<string, Disk> Disks
        {
            get { return disks; }
            set { disks = value; }
        }
        public DataTable DiskDataSource
        {
            get { return diskDataSource; }
            set { diskDataSource = value; }
        }
        public static DataSet DataSource;
        public Disk CurrentDisk
        {
            get { return currentDisk; }
            set { currentDisk = value; }
        }
        public List<string> SubDiskIds
        {
            get { return subDiskIds; }
            set { subDiskIds = value; }
        }
        #endregion
        #region 公共方法
        public PartDisk()
        {
            PartDisk.DataSource = new DataSet();
            Init(PartDisk.DataSource);
        }
        public PartDisk(DataSet ds)
        {
            if (ds == null)
            {
                throw new Exception("获取分盘数据出错，数据为空！");
            }
            PartDisk.DataSource = ds;
            Init(ds);
        }
        public bool AddDisk(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            this.CreateDiskAndSKUObject(ds.Tables[0]);
            return true;
        }
        public Types.ScanInfo ParentDiskScan(string parentDiskId, bool isUndo)
        {
            if (string.IsNullOrEmpty(parentDiskId)) { return Types.ScanInfo.ScanError; }
            if (isUndo) { return UnDoScan(parentDiskId); }
            if (!disks.ContainsKey(parentDiskId)) { this.disks.Add(parentDiskId, new Disk(parentDiskId)); }
            this.currentDisk = disks[parentDiskId];
            if (currentDisk.IsScaned) { return Types.ScanInfo.RepeatScan; }
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo SubDiskScan(string subDiskId, int partCount)
        {
            if (string.IsNullOrEmpty(subDiskId) || partCount == 0) { return Types.ScanInfo.ScanError; }
            if (subDiskIds.Contains(subDiskId)) { return Types.ScanInfo.PartSubReScan; }
            Types.ScanInfo si = currentDisk.Part(subDiskId, partCount);
            if (si != Types.ScanInfo.Successful) { return si; }
            subDiskIds.Add(subDiskId);
            return Types.ScanInfo.Successful;
        }

        public DataTable UpdateDiskDataTable()
        {
            diskDataSource.Rows.Clear();
            foreach (Disk d in disks.Values)
            {
                if (d.PartCount == 0) continue;
                DataRow dr = diskDataSource.NewRow();
                Pro2Col.Obj2DataRow(d, dr, Types.ActionType.Part);
                Pro2Col.Obj2DataRow(d.Sku,dr, Types.ActionType.Part);
                diskDataSource.Rows.Add(dr);
            }
            return diskDataSource;
        }
        public void UpdateDataSource()
        {
            UpdateDiskDataTable();
        }
        public DataSet GetDataSource()
        {
            return PartDisk.DataSource;
        }
        #endregion
        #region 私有方法

        private void Init(DataSet ds)
        {
            this.disks = new Dictionary<string, Disk>();
            this.skus = new Dictionary<string, SKU>();
            this.subDiskIds = new List<string>();
            SetDataSource(ds);
            CreateDiskAndSKUObject();
        }
        private void SetDataSource(DataSet ds)
        {
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                CreateDiskDataTable();
                PartDisk.DataSource.Tables.Add(diskDataSource);
            }
            AddTempData();
            diskDataSource = PartDisk.DataSource.Tables[0];
        }

        private static void AddTempData()
        {
            try
            {
                DataSet ds = PartDisk.DataSource;
                Disk d = new Disk();
                DataSet dsOld = MySerialization.DeSerialize(PartDisk.TempFileUrl);
                if (dsOld == null || dsOld.Tables.Count == 0 || dsOld.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                for (int i = 0; i < dsOld.Tables.Count; i++)
                {
                    if (ds.Tables.Count > i)
                    {
                        foreach (DataRow dr in ds.Tables[i].Rows)
                        {
                            if (dsOld.Tables[i].Select(d.GetColName4Pro("Id") + "="
                                + string.Format("'{0}'", dr[d.GetColName4Pro("Id")])).Length != 0) { continue; }
                            DataRow drOld = dsOld.Tables[i].NewRow();
                            dr.ItemArray.CopyTo(drOld.ItemArray, 0);
                            dsOld.Tables[i].Rows.Add(dr);
                        }
                    }
                }
                PartDisk.DataSource = dsOld;
            }
            catch
            {
            }
        }
        private void CreateDiskDataTable()
        {
            diskDataSource = new DataTable();
            SKU s = new SKU();
            LOC l = new LOC();
            Pro2Col.AddColumns4Obj(s, diskDataSource, Types.ActionType.Part);
            Pro2Col.AddColumns4Obj(l, diskDataSource, Types.ActionType.Part);
        }
        private void CreateDiskAndSKUObject()
        {
            if (this.diskDataSource.Rows.Count == 0) { return; }
            CreateDiskAndSKUObject(this.diskDataSource);
        }

        private void CreateDiskAndSKUObject(DataTable dt)
        {
            SKU s = new SKU();
            Disk d = new Disk();
            foreach (DataRow dr in dt.Rows)
            {
                if (disks.ContainsKey(dr[d.GetColName4Pro("Id")].ToString()))
                {
                    throw new Exception("创建料盘列表出错，存在重复的料盘记录！");
                }
                string key = dr[d.GetColName4Pro("SkuId")].ToString();
                if (skus.ContainsKey(key)) { s = skus[key]; }
                else
                {
                    s = new SKU(dr);
                    skus.Add(key, s);
                }
                d = new Disk(s, dr);
                disks.Add(dr[d.GetColName4Pro("Id")].ToString(), d);
                if (!string.IsNullOrEmpty(d.SubDiskId)) { subDiskIds.Add(d.SubDiskId); }
            }
        }
        private Types.ScanInfo UnDoScan(string diskId)
        {
            if (!disks.ContainsKey(diskId)) { return Types.ScanInfo.NotScan; }
            Types.ScanInfo si = disks[diskId].UnPart();
            if (si != Types.ScanInfo.Successful) { return si; }
            subDiskIds.Remove(diskId);
            return Types.ScanInfo.Successful;
        }
        #endregion
    }
}
