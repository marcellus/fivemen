using System;

using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

namespace PDA
{
    class Pick : IMySerializable
    {
        #region 私有变量
        private DataTable skuDataSource;
        private DataTable diskDataSource;
        private Dictionary<string, SKU> skus;
        private Dictionary<string, Disk> disks;
        private Disk currentDisk;
        private ArrayList billsIs;
        private int scanedDiskCount;
        #endregion

        #region 公共属性
        public static DataSet DataSource;
        public static string TempFileUrl
        {
            get
            {
                return DB.RootPath + @"BackUp\Pick";
            }
        }

        public DataTable SkuDataSource
        {
            get { return skuDataSource; }
            set { skuDataSource = value; }
        }

        public DataTable DiskDataSource
        {
            get
            {
                return diskDataSource;
            }
            set { diskDataSource = value; }
        }


        public Dictionary<string, SKU> Skus
        {
            get
            {
                return skus;
            }
        }

        public Dictionary<string, Disk> Dsiks
        {
            get
            {
                return disks;
            }
        }

        public Disk CurrentDisk
        {
            set
            {
                currentDisk = value;
            }
            get
            {
                return currentDisk;
            }
        }

        public ArrayList BillsIs
        {
            get
            {
                if (billsIs == null) { billsIs = new ArrayList(); }
                return billsIs;
            }
        }
        public int ScanedDiskCount
        {
            get { return scanedDiskCount; }
            set { scanedDiskCount = value; }
        }


        #endregion
        #region 事件
        public delegate void ScanFinish(object sender, EventArgs e);
        public event ScanFinish onScanFinish;
        public delegate void NeedPick(object sender, EventArgs e);
        public event NeedPick onPick;
        #endregion

        #region 公共方法
        public Pick(DataSet ds)
        {
            if (ds == null || ds.Tables.Count < 2)
            {
                throw new Exception("拣货数据出错，数据为空！");
            }
            Pick.DataSource = ds;
            skus = new Dictionary<string, SKU>();
            disks = new Dictionary<string, Disk>();
            SetDataSource(ds);
            CreateSKUObjects();
            CreateDiskObjects();
        }

        //public Types.ScanInfo DiskScan(string diskId, bool isUndo)
        //{
        //    if (string.IsNullOrEmpty(diskId)) { return Types.ScanInfo.ScanError; }
        //    if (!this.disks.ContainsKey(diskId)) { return Types.ScanInfo.NotInBill; }
        //    this.currentDisk = this.disks[diskId];
        //    if (isUndo) { return UnDoScan(); }
        //    if (CurrentDisk.IsScaned) { return Types.ScanInfo.RepeatScan; }

        //    SKU s = GetCurrentSKU(this.currentDisk);
        //    if (s == null) { return Types.ScanInfo.NotInBill; }
        //    else { this.currentDisk.Sku = s; }
        //    return Types.ScanInfo.Successful;
        //}
        //public Types.ScanInfo LocScan(string locNo)
        //{
        //    if (string.IsNullOrEmpty(locNo)) { return Types.ScanInfo.ScanError; }
        //    if (locNo != currentDisk.Loc) { return Types.ScanInfo.NotInLoc; }
        //    Types.ScanInfo sInfo = currentDisk.Pick();
        //    if (sInfo == Types.ScanInfo.Successful)
        //    {
        //        CheckIsPick();
        //        CheckIsFinish();
        //    }
        //    else { this.currentDisk.Sku = null; }
        //    return sInfo;
        //}

        public Types.ScanInfo DiskScan(string diskId, string locNo, bool isUndo)
        {
            if (string.IsNullOrEmpty(diskId) || string.IsNullOrEmpty(locNo)) { return Types.ScanInfo.ScanError; }
            if (!this.disks.ContainsKey(diskId)) { return Types.ScanInfo.NotInBill; }
            this.currentDisk = this.disks[diskId];
            if (isUndo) { return UnDoScan(); }

            if (CurrentDisk.IsScaned) { return Types.ScanInfo.RepeatScan; }
            if (locNo != currentDisk.Loc) { return Types.ScanInfo.NotInLoc; }

            SKU s = GetCurrentSKU(this.currentDisk);
            if (s == null) { return Types.ScanInfo.NotInBill; }
            else { this.currentDisk.Sku = s; }

            Types.ScanInfo sInfo = currentDisk.Pick();
            if (sInfo == Types.ScanInfo.Successful)
            {
                scanedDiskCount++;
                CheckIsPick();
                CheckIsFinish();
            }
            else { this.currentDisk.Sku = null; }
            return sInfo;

            //if (string.IsNullOrEmpty(diskId) || string.IsNullOrEmpty(locNo)) { return Types.ScanInfo.ScanError; }
            //if (!this.disks.ContainsKey(diskId)) { return Types.ScanInfo.NotInBill; }
            //this.currentDisk = this.disks[diskId];
            //if (isUndo) { return UnDoScan(); }

            //if (CurrentDisk.IsScaned) { return Types.ScanInfo.RepeatScan; }
            //if (locNo != currentDisk.Loc) { return Types.ScanInfo.NotInLoc; }

            //SKU s = GetCurrentSKU(this.currentDisk);
            //if (s == null) { return Types.ScanInfo.NotInBill; }
            //else { this.currentDisk.Sku = s; }

            //Types.ScanInfo sInfo = currentDisk.Pick();
            //if (sInfo == Types.ScanInfo.Successful)
            //{
            //    CheckIsPick();
            //    CheckIsFinish();
            //}
            //else { this.currentDisk.Sku = null; }
            //return sInfo;

        }
        public Types.ScanInfo LocScan(string locNo)
        {
            if (string.IsNullOrEmpty(locNo)) { return Types.ScanInfo.ScanError; }
            return Types.ScanInfo.Successful;
        }

        public DataTable UpdateSKUDataTable()
        {
            SKU s = new SKU();
            foreach (DataRow dr in skuDataSource.Rows)
            {
                s = skus[s.GetKey(dr)];
                Pro2Col.Obj2DataRow(s, dr, Types.ActionType.Pick);
            }
            return skuDataSource;
        }


        public DataTable UpdateDiskDataTable()
        {
            Disk d = new Disk();
            foreach (DataRow dr in diskDataSource.Rows)
            {
                d = disks[dr[d.GetColName4Pro("Id")].ToString()];
                Pro2Col.Obj2DataRow(d, dr, Types.ActionType.Pick);
            }
            return diskDataSource;
        }
        public void UpdateDataSource()
        {
            UpdateSKUDataTable();
            UpdateDiskDataTable();
        }
        public DataSet GetDataSource()
        {
            return Pick.DataSource;
        }
        #endregion

        #region 私有方法
        private void SetDataSource(DataSet ds)
        {
            this.skuDataSource = ds.Tables[0];
            this.diskDataSource = ds.Tables[1];
        }
        private void CreateSKUObjects()
        {
            if (this.skuDataSource.Rows.Count == 0)
            {
                throw new Exception("拣货数据出错，物料数据为空！");
            }
            SKU s = new SKU();
            foreach (DataRow dr in this.skuDataSource.Rows)
            {
                string key = s.GetKey(dr);
                if (skus.ContainsKey(key))
                {
                    throw new Exception("创建物料列表出错，存在重复的物料记录！");
                }
                skus.Add(key, new SKU(dr));
                AddBillId(dr[s.GetColName4Pro("BillNo")].ToString());
            }
        }
        private void CreateDiskObjects()
        {
            if (this.diskDataSource.Rows.Count == 0)
            {
                throw new Exception("拣货数据出错，料盘数据为空！");
            }
            SKU s = new SKU();
            Disk d = new Disk();
            foreach (DataRow dr in this.diskDataSource.Rows)
            {
                if (disks.ContainsKey(dr[d.GetColName4Pro("Id")].ToString()))
                {
                    throw new Exception("创建料盘列表出错，存在重复的料盘记录！");
                }

                string key = SKU.GetKey(dr[d.GetColName4Pro("BillRowNo")].ToString(), dr[d.GetColName4Pro("BillNo")].ToString());

                //如果料盘对应的物料不在ASN中，则不添加该料盘。
                //恢复保存时,物料和料盘已存在对应关系
                if (skus.ContainsKey(key)) { s = skus[key]; }
                else
                {
                    //没有则不关联
                    s = null;
                }
                disks.Add(dr[d.GetColName4Pro("Id")].ToString(), new Disk(s, dr));

            }
        }
        private Types.ScanInfo UnDoScan()
        {
            //if (CurrentDisk == null || !CurrentDisk.IsScaned) { return Types.ScanInfo.NotScan; }
            //return CurrentDisk.unPick();
            if (CurrentDisk == null || !CurrentDisk.IsScaned) { return Types.ScanInfo.NotScan; }
            Types.ScanInfo si = CurrentDisk.unPick();
            if (si != Types.ScanInfo.Successful) { return si; }
            scanedDiskCount--;
            return Types.ScanInfo.Successful;

        }
        private void CheckIsFinish()
        {
            foreach (SKU s in skus.Values)
            {
                if (string.Compare(CurrentDisk.BillNo, s.BillNo, true) == 0 && !s.ScanFinish) { return; }
            }
            onScanFinish(this, new EventArgs());
        }
        private void CheckIsPick()
        {
            if (CurrentDisk.LockCount > 0)
            {
                onPick(this, new EventArgs());
            }
        }
        private SKU GetCurrentSKU(Disk d)
        {
            SKU last = null;
            foreach (SKU s in skus.Values)
            {
                //if (s.Id == d.SkuId && s.PickLoc == d.Loc&& s.CompanyId == d.Storer && s.BillNo == d.BillNo)// && s.Lot == d.Lot 
                if (s.Id == d.SkuId && s.PickLoc == d.Loc &&  s.BillNo == d.BillNo)
                {
                    if (!s.ScanFinish) return s;
                    last = s;
                }
            }
            return last;
        }

        private void AddBillId(string billId)
        {
            if (BillsIs.Contains(billId)) { return; }
            BillsIs.Add(billId);
        }
        #endregion
    }
}
