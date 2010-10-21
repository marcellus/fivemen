using System;

using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PDA
{
    public class LOC
    {
        private string locNo;
        private int count;
        [ColumnName("LOC", Action = Types.ActionType.Loc)]
        public string LocNo
        {
            get { return this.locNo; }
            set { this.locNo = value; }
        }
        [ColumnName("QTY", Action = Types.ActionType.Loc)]
        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public LOC()
        {
        }
        public LOC(string locNo, int count)
        {
            this.locNo = locNo;
            this.count = count;
        }

    }
    public class SKU
    {
        #region 私有字段
        private string id;
        private string desc;
        private int count;
        private int scanCount;
        private int packCount;
        private bool scanFinish;
        private string billNo;
        private string billRowNo;
        private string expectedLoc;
        private string lot;
        private string pickLoc;
        private string company;
        private string companyId;
        private string receiptkey;
        private string temLoc;
        private int canPickFullDiskCount;
        private int scanFullDiskCount;
        private string newLot;

        /// <summary>
        /// 此字段不能直接使用，考虑到性能问题，要访问需要使用属性
        /// </summary>
        private Dictionary<string, LOC> locs;
        #endregion

        #region 公共属性
        [ColumnName("SKU", Action = Types.ActionType.Loc | Types.ActionType.Common | Types.ActionType.Part)]
        public string Id
        {
            get { return id == null ? string.Empty : id; }
            set { id = value; }
        }
        [ColumnName("descr", Action = Types.ActionType.Common | Types.ActionType.Part)]
        public string Desc
        {
            get { return desc == null ? string.Empty : desc; }
            set { desc = value; }
        }
        [ColumnName("Count")]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        [ColumnName("ScanCount", Action = Types.ActionType.ASN | Types.ActionType.PutAway | Types.ActionType.Loc | Types.ActionType.Pick)]
        public int ScanCount
        {
            get { return scanCount; }
            set { scanCount = value; }
        }
        [ColumnName("ScanFinish", Action = Types.ActionType.ASN | Types.ActionType.PutAway | Types.ActionType.Pick)]
        public bool ScanFinish
        {
            get { return scanFinish; }
            set { scanFinish = value; }
        }
        [ColumnName("BillNo", Action = Types.ActionType.Loc)]
        public string BillNo
        {
            get { return billNo == null ? string.Empty : billNo; }
            set { billNo = value; }
        }
        [ColumnName("BillRowNo", Action = Types.ActionType.Loc)]
        public string BillRowNo
        {
            get { return billRowNo == null ? string.Empty : billRowNo; }
            set { billRowNo = value; }
        }
        [ColumnName("casecnt")]
        public int PackCount
        {
            get { return packCount; }
            set { packCount = value; }
        }
        [ColumnName("EXPECTED_LOC")]
        public string ExpectedLoc
        {
            get { return expectedLoc == null ? string.Empty : expectedLoc; }
            set { expectedLoc = value; }
        }
        [ColumnName("LOT", Action = Types.ActionType.Loc)]
        public string Lot
        {
            get { return lot == null ? string.Empty : lot; }
            set { lot = value; }
        }
        [ColumnName("LOC")]
        public string PickLoc
        {
            get { return pickLoc == null ? string.Empty : pickLoc; }
            set { pickLoc = value; }
        }
        [ColumnName("COMPANY", Action = Types.ActionType.Common | Types.ActionType.Part)]
        public string Company
        {
            get { return company == null ? string.Empty : company; }
            set { company = value; }
        }
        [ColumnName("STORERKEY", Action = Types.ActionType.Loc)]
        public string CompanyId
        {
            get { return companyId == null ? string.Empty : companyId; }
            set { companyId = value; }
        }

        public Dictionary<string, LOC> Locs
        {
            get
            {
                if (locs == null) { locs = new Dictionary<string, LOC>(); }
                return locs;
            }
            set { locs = value; }
        }
        [ColumnName("RECEIPTKEY")]
        public string Receiptkey
        {
            get { return receiptkey; }
            set { receiptkey = value; }
        }
        [ColumnName("temp_loc", Action = Types.ActionType.Loc)]
        public string TemLoc
        {
            get { return temLoc; }
            set { temLoc = value; }
        }
        [ColumnName("CanPickFullDiskCount")]
        public int CanPickFullDiskCount
        {
            get { return canPickFullDiskCount; }
            set { canPickFullDiskCount = value; }
        }
        [ColumnName("ScanFullDiskCount", Action = Types.ActionType.Pick)]
        public int ScanFullDiskCount
        {
            get { return scanFullDiskCount; }
            set { scanFullDiskCount = value; }
        }
        [ColumnName("NewLot")]
        public string NewLot
        {
            get { return newLot; }
            set { newLot = value; }
        }
        #endregion

        #region 公共方法
        public SKU()
        {
        }
        public SKU(DataRow dr)
        {
            if (!dr.Table.Columns.Contains(GetColName4Pro("Id")))
            {
                throw new Exception("物料P/N为空，初始化数据失败！");
            }
            Pro2Col.DataRow2Obj(this, dr);
            if (this.scanCount == this.count) { this.scanFinish = true; }
        }
        public bool AddLoc(DataRow dr)
        {
            LOC l = new LOC();
            if (!dr.Table.Columns.Contains(GetColName4Pro(l, "LocNo"))) { return false; }
            l.LocNo = dr[GetColName4Pro(l, "LocNo")].ToString();
            if (dr.Table.Columns.Contains(GetColName4Pro(l, "Count")))
            {
                l.Count = Convert.ToInt32(dr[GetColName4Pro(l, "Count")]);
            }
            this.Locs.Add(l.LocNo, l);
            return true;
        }
        public Types.ScanInfo Scan(int count)
        {
            Types.ScanInfo si = CheckScan(count);
            if (si != Types.ScanInfo.Successful) return si;
            this.scanCount += count;
            this.scanFinish = this.scanCount == this.count ? true : false;
            return Types.ScanInfo.Successful;
        }

        public Types.ScanInfo Scan(int count, bool notCheckCount)
        {
            Types.ScanInfo si;
            if (!notCheckCount)
            {
                si = CheckScan(count);
                if (si != Types.ScanInfo.Successful) return si;
            }
            this.scanCount += count;
            this.scanFinish = this.scanCount == this.count ? true : false;
            return Types.ScanInfo.Successful;
        }


        //public Types.ScanInfo ScanASN(int count)
        //{
        //    this.scanCount += count;
        //    this.scanFinish = this.scanCount == this.count ? true : false;
        //    return Types.ScanInfo.Successful;
        //}
        public int GetNeedCount()
        {
            return this.count - this.scanCount;
        }
        public Types.ScanInfo ScanFullDisk(int count)
        {
            if (count < 0 && this.scanFullDiskCount + count < 0)
            {
                return Types.ScanInfo.Underflow;
            }
            if (count > 0 && this.scanFullDiskCount + count > this.canPickFullDiskCount)
            {
                return Types.ScanInfo.OverflowFullDisk;
            }
            this.scanFullDiskCount += count;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo Scan(int count, string locNo)
        {
            Types.ScanInfo si = CheckScan(count);
            if (si != Types.ScanInfo.Successful) return si;
            if (this.expectedLoc.Trim().ToUpper() != locNo.Trim().ToUpper())
            {
                return Types.ScanInfo.NotExpectedLoc;
            }
            if (count < 0 && (!this.Locs.ContainsKey(locNo) || this.Locs[locNo].Count + count < 0))
            {
                return Types.ScanInfo.NotInLoc;
            }
            if (!this.Locs.ContainsKey(locNo))
            {
                this.Locs.Add(locNo, new LOC(locNo, 0));
            }
            this.scanCount += count;
            this.Locs[locNo].Count += count;
            this.scanFinish = this.scanCount == this.count ? true : false;
            return Types.ScanInfo.Successful;
        }
        public string GetColName4Pro(string propertyName)
        {
            return Pro2Col.GetColName4Pro(this.GetType(), propertyName);
        }
        public string GetColName4Pro(object o, string propertyName)
        {
            return Pro2Col.GetColName4Pro(o, propertyName);
        }

        public static string GetKey(string billRowNo, string billNo)
        {
            if (string.IsNullOrEmpty(billNo))
            {
                throw new Exception("单号为空");
            }
            return (billRowNo.ToUpper().GetHashCode() + billNo.ToUpper().GetHashCode()).GetHashCode().ToString();
        }
        public string GetKey(DataRow dr)
        {
            string billRowNo = dr[GetColName4Pro("BillRowNo")].ToString();
            string billNo = dr[GetColName4Pro("BillNo")].ToString();
            return SKU.GetKey(billRowNo, billNo);
        }
        #endregion

        #region 私有方法
        private Types.ScanInfo CheckScan(int count)
        {
            if (count < 0 && this.scanCount + count < 0)
            {
                return Types.ScanInfo.Underflow;
            }
            if (count > 0 && this.scanCount + count > this.count)
            {
                return Types.ScanInfo.Overflow;
            }
            return Types.ScanInfo.Successful;
        }
        #endregion
    }
}
