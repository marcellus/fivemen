using System;

using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace PDA
{
    class MoveLot : IMySerializable
    {
        #region 私有变量
        private DataTable skuDataSource;
        private DataTable diskDataSource;
        private Dictionary<string, SKU> skus;
        private Dictionary<string, Disk> disks;
        private Disk currentDisk;
        private int scanedDiskCount;
        /// <summary>
        /// 出于性能考虑，此字段不能直接使用，请使用属性。
        /// </summary>
        private ArrayList finishBillsId;
        #endregion

        #region 公共属性
        public static DataSet DataSource;
        public static string TempFileUrl
        {
            get
            {
                return DB.RootPath + @"BackUp\MoveLot";
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
                if (skus == null)
                {
                    skus = new Dictionary<string, SKU>();
                }
                return skus;
            }
            set { skus = value; }
        }

        public Dictionary<string, Disk> Dsiks
        {
            get
            {
                if (disks == null)
                {
                    disks = new Dictionary<string, Disk>();
                }
                return disks;
            }
            set { disks = value; }
        }

        public ArrayList FinishBillsId
        {
            get
            {
                if (finishBillsId == null) { finishBillsId = new ArrayList(); }
                return finishBillsId;
            }
        }

        public Disk CurrentDisk
        {
            get
            { return currentDisk; }
            set { this.currentDisk = value; }
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
        #endregion
        #region 公共方法
        public MoveLot(DataSet ds)
        {
            if (ds == null || ds.Tables.Count < 2)
            {
                throw new Exception("移储数据出错，数据为空！");
            }
            MoveLot.DataSource = ds;
            skus = new Dictionary<string, SKU>();
            disks = new Dictionary<string, Disk>();
            SetDataSource(ds);
            CreateSKUObjects();
            CreateDiskObjects();
            AddFinishBillToList();
        }

        public Types.ScanInfo DiskScan(string diskId, bool isUndo)
        {
            if (string.IsNullOrEmpty(diskId)) { return Types.ScanInfo.ScanError; }
            if (!this.disks.ContainsKey(diskId)) { return Types.ScanInfo.NotInBill; }
            this.currentDisk = this.disks[diskId];
            if (isUndo) { return UnDoScan(); }
            if (CurrentDisk.IsScaned) { return Types.ScanInfo.RepeatScan; }

            SKU s = GetCurrentSKU(this.currentDisk.SkuId);
            if (s == null) { return Types.ScanInfo.NotInBill; }
            else
            {
                this.currentDisk.Sku = s;
                //this.currentDisk.Lot = s.Lot;
            }
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo LotScan(string lotNo)
        {
            if (string.IsNullOrEmpty(lotNo)) { return Types.ScanInfo.ScanError; }
            if (this.currentDisk.Sku.NewLot.Trim().ToUpper() != lotNo.Trim().ToUpper()) { return Types.ScanInfo.NotExpectedLot; }
            Types.ScanInfo sInfo = CurrentDisk.MoveLot(lotNo);
            if (sInfo == Types.ScanInfo.Successful) 
            {
                scanedDiskCount++;
                CheckIsFinish(); 
            }
            else { this.currentDisk.Sku = null; }
            return sInfo;
        }


        public DataTable UpdateDiskDataTable()
        {
            Disk d = new Disk();
            foreach (DataRow dr in this.diskDataSource.Rows)
            {
                d = this.disks[dr[d.GetColName4Pro("Id")].ToString()];
                Pro2Col.Obj2DataRow(d, dr, Types.ActionType.PutAway);
            }
            return diskDataSource;
        }
        public DataTable UpdateSKUDataTable()
        {
            SKU s = new SKU();
            foreach (DataRow dr in skuDataSource.Rows)
            {
                s = skus[s.GetKey(dr)];
                Pro2Col.Obj2DataRow(s, dr, Types.ActionType.PutAway);
            }
            return skuDataSource;
        }
        public void UpdateDataSource()
        {
            UpdateSKUDataTable();
            UpdateDiskDataTable();
        }
        public DataSet GetDataSource()
        {
            return PutAway.DataSource;
        }

        #endregion

        #region 私有方法
        private void SetDataSource(DataSet ds)
        {
            this.skuDataSource = ds.Tables["MoveLotBill"];
            this.diskDataSource = ds.Tables["MoveLotDisk"];
        }
        private void CreateSKUObjects()
        {
            if (this.skuDataSource.Rows.Count == 0)
            {
                throw new Exception("移储数据出错，数据为空！");
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
            }
        }
        private void CreateDiskObjects()
        {
            if (this.diskDataSource.Rows.Count == 0)
            {
                throw new Exception("移储数据出错，料盘数据为空！");
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
            if (CurrentDisk == null || !CurrentDisk.IsScaned) { return Types.ScanInfo.NotScan; }
            Types.ScanInfo si = CurrentDisk.UnMoveLot();

            if (si != Types.ScanInfo.Successful) { return si; }
            this.FinishBillsId.Remove(currentDisk.Sku.BillNo);
            scanedDiskCount--;
            return Types.ScanInfo.Successful;
        }
        private void CheckIsFinish()
        {
            foreach (SKU s in skus.Values)
            {
                if (string.Compare(CurrentDisk.BillNo, s.BillNo, true) == 0 && !s.ScanFinish) { return; }
            }

            this.FinishBillsId.Add(currentDisk.Sku.BillNo);
            onScanFinish(this, new EventArgs());
        }
        private SKU GetCurrentSKU(string skuId)
        {
            SKU last = null;
            foreach (SKU s in skus.Values)
            {
                if (s.Id == skuId && s.BillNo== currentDisk.BillNo)// && s.Lot == currentDisk.Lot
                {
                    if (!s.ScanFinish) return s;
                    last = s;
                }
            }
            return last;
        }
        private void AddFinishBillToList()
        {
            if (this.skuDataSource.Rows.Count == 0)
            {
                throw new Exception("移储数据出错，物料数据为空！");
            }
            SKU s = new SKU();
            DataRow[] drs = this.skuDataSource.Select(s.GetColName4Pro("ScanFinish") + "=1");
            if (drs.Length == 0) { return; }
            foreach (DataRow dr in drs)
            {
                if (!this.FinishBillsId.Contains(dr[s.GetColName4Pro("BillNo")]))
                {
                    this.FinishBillsId.Add(dr[s.GetColName4Pro("BillNo")]);
                }
            }
            drs = this.skuDataSource.Select(s.GetColName4Pro("ScanFinish") + "=0");
            if (drs.Length == 0) { return; }
            foreach (DataRow dr in drs)
            {
                if (this.FinishBillsId.Contains(dr[s.GetColName4Pro("BillNo")]))
                {
                    this.FinishBillsId.Remove(dr[s.GetColName4Pro("BillNo")]);
                }
            }
        }
        #endregion
    }
}
