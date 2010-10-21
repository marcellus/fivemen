using System;

using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PDA
{
    class ReturnDisk : IMySerializable
    {
        #region 私有字段
        private DataTable diskDataSource;
        private Dictionary<string, Disk> disks;
        private Dictionary<string, SKU> skus;
        private Disk currentDisk;
        #endregion
        #region 公共属性
        public static string TempFileUrl
        {
            get
            {
                return DB.RootPath+@"BackUp\Return";
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
        #endregion
        #region 公共方法
        public ReturnDisk(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0)
            {
                throw new Exception("获取退料数据出错，数据为空！");
            }
            ReturnDisk.DataSource = ds;
            this.disks = new Dictionary<string, Disk>();
            this.skus = new Dictionary<string, SKU>();
            SetDataSource(ds);
            CreateDiskAndSKUObject();
        }
        public Types.ScanInfo DiskScan(string diskId, bool isUndo)
        {
            if (string.IsNullOrEmpty(diskId)) { return Types.ScanInfo.ScanError; }
            if (!disks.ContainsKey(diskId)) { return Types.ScanInfo.NotInBill; }
            this.currentDisk = disks[diskId];
            if (isUndo) { return this.currentDisk.UnReturn(); }
            return currentDisk.Return();
        }

        public DataTable UpdateDiskDataTable()
        {
            Disk d = new Disk();
            foreach (DataRow dr in diskDataSource.Rows)
            {
                Pro2Col.Obj2DataRow(disks[dr[d.GetColName4Pro("Id")].ToString()], dr, Types.ActionType.Return);
            }
            return diskDataSource;
        }
        public void UpdateDataSource()
        {
            UpdateDiskDataTable();
        }
        public DataSet GetDataSource()
        {
            return ReturnDisk.DataSource;
        }
        #endregion
        #region 私有方法

        private void SetDataSource(DataSet ds)
        {
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception("获取退料数据出错，数据为空！");
            }
            else { diskDataSource = ds.Tables[0]; }
        }
        private void CreateDiskAndSKUObject()
        {
            SKU s = new SKU();
            Disk d = new Disk();
            foreach (DataRow dr in diskDataSource.Rows)
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
        #endregion
    }
}
