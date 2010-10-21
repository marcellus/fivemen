using System;

using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace PDA
{
    public class ASN : IMySerializable
    {
        #region 私有变量
        private DataTable skuDataSource;
        private DataTable diskDataSource;
        private Dictionary<string, SKU> skus;
        private Dictionary<string, Disk> disks;
        private string currentDiskId;
        private Disk currentDisk;
        private SKU currentSKU;
        private ArrayList billsIs;
        #endregion

        #region 公共属性
        public static DataSet DataSource;
        public static string TempFileUrl
        {
            get
            {
                return DB.RootPath + @"BackUp\Asn";
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
            set { skus = value; }
        }

        public Dictionary<string, Disk> Dsiks
        {
            get
            {
                return disks;
            }
            set { disks = value; }
        }

        public string CurrentDiskId
        {
            get { return currentDiskId; }
            set { currentDiskId = value; }
        }

        public Disk CurrentDisk
        {
            get
            {
                if (currentDisk == null || currentDisk.Id != currentDiskId)
                {
                    if (!disks.ContainsKey(currentDiskId)) { currentDisk = null; }
                    else { currentDisk = this.disks[currentDiskId]; }
                }
                return currentDisk;
            }
        }

        public SKU CurrentSKU
        {
            get
            {
                return currentSKU;
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
        #endregion
        #region 事件
        public delegate void ScanFinish(object sender, EventArgs e);
        public event ScanFinish onScanFinish;
        #endregion

        #region 公共方法
        public ASN(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception("ASN数据出错，数据为空！");
            }
            ASN.DataSource = ds;
            skus = new Dictionary<string, SKU>();
            disks = new Dictionary<string, Disk>();
            SetDataSource(ds);
            CreateSKUObjects();
            CreateDiskObjects();
        }

        public Types.ScanInfo DiskScan(string diskId, bool isUndo)
        {
            if (string.IsNullOrEmpty(diskId)) { return Types.ScanInfo.ScanError; }
            this.currentDiskId = diskId;

            if (isUndo) { return UnDoScan(); }
            return CheckDiskIsScaned();
        }
        public Types.ScanInfo DiskScan(string diskId, bool isUndo, int PackCount, string skuID, DateTime createDatetime)
        {
            if (string.IsNullOrEmpty(diskId)) { return Types.ScanInfo.ScanError; }
            this.currentDiskId = diskId;

            if (isUndo) { return UnDoScan(); }
            //return CheckDiskIsScaned();
            Types.ScanInfo info = CheckDiskIsScaned();
            if (info == Types.ScanInfo.Successful)
            {
                SKU s = GetCurrentSKU(skuID);
                AddCurrentDisk(s,PackCount);
                Types.ScanInfo sInfo = CurrentDisk.Asn(createDatetime);
                if (sInfo == Types.ScanInfo.Successful) { CheckIsFinish(); }
                else { this.CurrentDisk.Sku = null; }
                return sInfo;
            }
            else
            {
                return info;
            }
        }

        public Types.ScanInfo DiskScan(string diskId, bool isUndo, int PackCount, string skuID, DateTime createDatetime,string loc)
        {
            if (string.IsNullOrEmpty(diskId)) { return Types.ScanInfo.ScanError; }
            this.currentDiskId = diskId;

            if (isUndo) { return UnDoScan(); }
            //return CheckDiskIsScaned();
            Types.ScanInfo info = CheckDiskIsScaned();
            if (info == Types.ScanInfo.Successful)
            {
                SKU s = GetCurrentSKU(skuID);
                AddCurrentDisk(s, PackCount,loc);
                Types.ScanInfo sInfo = CurrentDisk.Asn(createDatetime);
                if (sInfo == Types.ScanInfo.Successful) { CheckIsFinish(); }
                else { this.CurrentDisk.Sku = null; }
                return sInfo;
            }
            else
            {
                return info;
            }
        }
        public Types.ScanInfo SKUScan(string skuID, DateTime createDatetime)
        {
            if (string.IsNullOrEmpty(skuID)) { return Types.ScanInfo.ScanError; }
            SKU s = GetCurrentSKU(skuID);
            if (s == null) { return Types.ScanInfo.NotInBill; }
            this.currentSKU = s;
            return Types.ScanInfo.Successful;
            //AddCurrentDisk(s);
            //Types.ScanInfo sInfo = CurrentDisk.Asn(createDatetime);
            //if (sInfo == Types.ScanInfo.Successful) { CheckIsFinish(); }
            //else { this.CurrentDisk.Sku = null; }
            //return sInfo;
        }
        public DataTable UpdateSKUDataTable()
        {
            SKU s = new SKU();
            foreach (DataRow dr in skuDataSource.Rows)
            {
                s = skus[s.GetKey(dr)];
                Pro2Col.Obj2DataRow(s, dr, Types.ActionType.ASN);
            }
            return skuDataSource;
        }


        public DataTable UpdateDiskDataTable()
        {
            diskDataSource.Rows.Clear();
            foreach (Disk d in disks.Values)
            {
                if (!d.IsScaned) continue;
                DataRow dr = diskDataSource.NewRow();
                Pro2Col.Obj2DataRow(d, dr, Types.ActionType.ASN);
                diskDataSource.Rows.Add(dr);
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
            return ASN.DataSource;
        }
        #endregion

        #region 私有方法
        private void SetDataSource(DataSet ds)
        {
            this.skuDataSource = ds.Tables[0];
            if (ds.Tables.Count > 1)
            {
                this.diskDataSource = ds.Tables[1];
            }
            else
            {
                CreateDiskDataTable();
                ds.Tables.Add(this.diskDataSource);
            }
        }
        private void CreateSKUObjects()
        {
            if (this.skuDataSource.Rows.Count == 0)
            {
                throw new Exception("ASN数据出错，数据为空！");
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
                return;
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
                if (skus.ContainsKey(key))
                {
                    s = skus[key];
                    disks.Add(dr[d.GetColName4Pro("Id")].ToString(), new Disk(s, dr));
                }
            }
        }
        private Types.ScanInfo UnDoScan()
        {
            if (CurrentDisk == null || !CurrentDisk.IsScaned) { return Types.ScanInfo.NotScan; }
            Types.ScanInfo si = CurrentDisk.UnAsn();
            if (si != Types.ScanInfo.Successful) { return si; }
            this.disks.Remove(currentDiskId);
            this.currentDisk = null;
            return Types.ScanInfo.Successful;
        }
        private Types.ScanInfo CheckDiskIsScaned()
        {
            if (CurrentDisk != null && CurrentDisk.IsScaned) { return Types.ScanInfo.RepeatScan; }
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
        private SKU GetCurrentSKU(string skuId)
        {
            SKU last = null;
            foreach (SKU s in skus.Values)
            {
                if (s.Id == skuId)
                {
                    if (!s.ScanFinish) return s;
                    last = s;
                }
            }
            return last;
        }
        private Disk CreateDiskFromSKU(SKU s)
        {
            Disk d = new Disk();
            d.Sku = s;
            d.Id = currentDiskId;
            d.Count = s.PackCount;
            d.TotalCount = s.PackCount;
            d.BillNo = s.BillNo;
            d.Storer = s.CompanyId;
            return d;
        }
        private Disk CreateDiskFromSKU(SKU s,int PackCount)
        {
            Disk d = new Disk();
            d.Sku = s;
            d.Id = currentDiskId;
            d.Count = PackCount;
            d.TotalCount = s.PackCount;
            d.BillNo = s.BillNo;
            d.Storer = s.CompanyId;
            return d;
        }

        private Disk CreateDiskFromSKU(SKU s, int PackCount,string loc)
        {
            Disk d = new Disk();
            d.Sku = s;
            d.Id = currentDiskId;
            d.Count = PackCount;
            d.TotalCount = s.PackCount;
            d.BillNo = s.BillNo;
            d.Storer = s.CompanyId;
            d.Loc = loc;
            return d;
        }

        private void AddCurrentDisk(SKU s)
        {
            Disk d = CreateDiskFromSKU(s);
            disks.Add(d.Id, d);
            this.currentDiskId = d.Id;
        }
        private void AddCurrentDisk(SKU s,int PackCount)
        {
            Disk d = CreateDiskFromSKU(s,PackCount);
            disks.Add(d.Id, d);
            this.currentDiskId = d.Id;
        }

        private void AddCurrentDisk(SKU s, int PackCount,string loc)
        {
            Disk d = CreateDiskFromSKU(s, PackCount, loc);
            disks.Add(d.Id, d);
            this.currentDiskId = d.Id;
        }
        private void CreateDiskDataTable()
        {
            diskDataSource = new DataTable();
            Disk d = new Disk();
            Pro2Col.AddColumns4Obj(d, diskDataSource, Types.ActionType.ASN);
        }
        private void AddBillId(string billId)
        {
            if (BillsIs.Contains(billId)) { return; }
            BillsIs.Add(billId);
        }
        #endregion
    }
}
