using System;

using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PDA
{

    class OpenDisk : Common
    {
        public static string TempFileUrl
        {
            get
            {
                return DB.RootPath + @"BackUp\Open";
            }
        }

        OpenDisk()
            : base()
        {
        }
        OpenDisk(DataSet ds)
            : base(ds)
        {
        }
    }
    class RoastBegin : Common
    {
        public static string TempFileUrl
        {
            get
            {
                return DB.RootPath + @"BackUp\RoastBegin";
            }
        }

        RoastBegin()
            : base()
        {
        }
        RoastBegin(DataSet ds)
            : base(ds)
        {
        }
    }
    class RoastEnd : Common
    {
        public static string TempFileUrl
        {
            get
            {
                return DB.RootPath + @"BackUp\RoastEnd";
            }
        }

        RoastEnd()
            : base()
        {
        }
        RoastEnd(DataSet ds)
            : base(ds)
        {
            
        }
    }
    abstract class Common
    {
        #region 私有字段
        private DataTable diskDataSource;
        private Dictionary<string, Disk> disks;
        private Dictionary<string, SKU> skus;
        private Disk currentDisk;
        private string currentDiskId;
        #endregion
        #region 公共属性
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

        public string CurrentDiskId
        {
            get { return currentDiskId; }
            set { currentDiskId = value; }
        }
        #endregion
        #region 公共方法
        protected Common()
        {
            DataSet ds = new DataSet();
            init(ds);
        }
        protected Common(DataSet ds)
        {
            if (ds == null)
            {
                ds = new DataSet();
            }
            init(ds);
        }
        public Types.ScanInfo DiskScan(string diskId, bool isUndo)
        {
            if (string.IsNullOrEmpty(diskId)) { return Types.ScanInfo.ScanError; }
            if (isUndo) { return UnDoScan(diskId); }
            if (!disks.ContainsKey(diskId)) { this.disks.Add(diskId, new Disk(diskId)); }
            this.currentDisk = disks[diskId];
            return this.currentDisk.CommanScan();
        }
        public bool AddDisk(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception("数据库中无此料盘数据！");
            }
            Disk d = new Disk();
            this.CreateDiskAndSKUObject(ds.Tables[0]);
            return true;
        }
        public DataTable UpdateDiskDataTable()
        {
            this.diskDataSource.Rows.Clear();
            foreach (Disk d in disks.Values)
            {
                if (!d.IsScaned) { continue; }
                DataRow dr = this.diskDataSource.NewRow();
                Pro2Col.Obj2DataRow(d, dr, Types.ActionType.Common);
                Pro2Col.Obj2DataRow(d.Sku, dr, Types.ActionType.Common);
                this.diskDataSource.Rows.Add(dr);
            }
            return diskDataSource;
        }
        public void UpdateDataSource()
        {
            UpdateDiskDataTable();
        }
        public DataSet GetDataSource()
        {
            return Common.DataSource;
        }
        #endregion
        #region 私有方法

        private void SetDataSource(DataSet ds)
        {
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                CreateDiskDataTable();
            }
            else { diskDataSource = ds.Tables[0]; }
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
                disks.Add(dr[d.GetColName4Pro("Id")].ToString(), new Disk(s, dr));
            }
        }

        private void CreateDiskDataTable()
        {
            SKU s = new SKU();
            Disk d = new Disk();
            this.diskDataSource = new DataTable();
            Pro2Col.AddColumns4Obj(d, diskDataSource, Types.ActionType.Common);
            Pro2Col.AddColumns4Obj(d, diskDataSource, Types.ActionType.Common);
            Common.DataSource.Tables.Add(this.diskDataSource);
        }

        private void init(DataSet ds)
        {

            Common.DataSource = ds;
            this.disks = new Dictionary<string, Disk>();
            this.skus = new Dictionary<string, SKU>();
            SetDataSource(ds);
            CreateDiskAndSKUObject();
        }
        private Types.ScanInfo UnDoScan(string diskId)
        {
            if (!disks.ContainsKey(diskId)) { return Types.ScanInfo.NotScan; }
            return disks[diskId].UnCommanScan();
        }
        #endregion
    }
}
