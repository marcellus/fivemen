using System;

using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PDA
{
    public class MoveLoc
    {
        #region 私有字段
        private Dictionary<string, Disk> disks;
        DataTable diskDataSource;
        Disk currentDisk;
        #endregion
        #region 公共属性
        public static DataSet DataSource;
        public Dictionary<string, Disk> Dsiks
        {
            get
            {
                return disks;
            }
        }

        public DataTable DiskDataSource
        {
            get { return diskDataSource; }
            set { diskDataSource = value; }
        }

        public Disk CurrentDisk
        {
            get { return currentDisk; }
            set { currentDisk = value; }
        }
        #endregion
        #region 公共方法
        public MoveLoc(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception("该库位无物料，请重新扫描！");
            }
            MoveLoc.DataSource = ds;
            disks = new Dictionary<string, Disk>();
            SetDataSource(ds);
            CreateDiskObjects();
        }
        public void UpdateDataSource()
        {
            UpdateDiskDataTable();
        }
        public Types.ScanInfo OldDiskScan(string diskId,bool isUnDo){
            if (string.IsNullOrEmpty(diskId)) { return Types.ScanInfo.ScanError; }
            if (!this.disks.ContainsKey(diskId)) { return Types.ScanInfo.NotInBill; }
            currentDisk = disks[diskId];
            if (isUnDo) { return currentDisk.UnMoveBegion(); }
            return currentDisk.MoveBegin();
        }
        public Types.ScanInfo NewDiskScan(string diskId, string loc,bool isUnDo)
        {
            if (string.IsNullOrEmpty(diskId) || string.IsNullOrEmpty(loc)) { return Types.ScanInfo.ScanError; }
            if (!this.disks.ContainsKey(diskId)) { return Types.ScanInfo.NotInBill; }
            currentDisk = disks[diskId];
            if (isUnDo) { return currentDisk.UnMove(); }
            return currentDisk.Move(loc);
        }
        #endregion
        #region 私有方法
        private void SetDataSource(DataSet ds)
        {
            this.diskDataSource = ds.Tables[0];
        }
        public DataTable UpdateDiskDataTable()
        {
            Disk d = new Disk();
            foreach (DataRow dr in diskDataSource.Rows)
            {
                d = disks[dr[d.GetColName4Pro("Id")].ToString()];
                Pro2Col.Obj2DataRow(d, dr, Types.ActionType.MoveLoc);
            }
            return diskDataSource;
        }
        private void CreateDiskObjects()
        {
            if (this.diskDataSource.Rows.Count == 0)
            {
                throw new Exception("移库数据出错，料盘数据为空！");
            }
            Disk d = new Disk();
            foreach (DataRow dr in this.diskDataSource.Rows)
            {
                if (disks.ContainsKey(dr[d.GetColName4Pro("Id")].ToString()))
                {
                    throw new Exception("创建料盘列表出错，存在重复的料盘记录！");
                }
                d = new Disk(null, dr);
                d.SkuId = dr[d.GetColName4Pro("SkuId")].ToString();
                disks.Add(dr[d.GetColName4Pro("Id")].ToString(), d);
            }
        }
        #endregion
    }
}
