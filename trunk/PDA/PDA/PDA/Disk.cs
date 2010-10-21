using System;

using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PDA
{
    public class Disk
    {
        #region 私有字段

        private int count;
        private int totalCount;
        private string id;
        private string parentId;
        private string storer;
        private SKU sku;
        private string skuId;
        private string billNo;
        private string billRowNo;
        private bool isScaned;
        private string loc;
        private DateTime createDateTime;
        private int lockCount;
        private string lockBillNo;
        private string subDiskId;
        private int partCount;
        private string lot;
        private static SKU EmptySKU = new SKU();
        private bool needMove;
        private string newLoc;
        private string receiptkey;
        private int outOption;
        //add by levin
        private int qtyallocated;
        private int qtyleft;
        #endregion

        #region 公共属性
        [ColumnName("LEFT_QTY", Action = Types.ActionType.ASN | Types.ActionType.PutAway | Types.ActionType.Pick | Types.ActionType.Part)]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        [ColumnName("TOTAL_QTY")]
        public int TotalCount
        {
            get { return totalCount; }
            set { totalCount = value; }
        }
        [ColumnName("DISK_ID", Action = Types.ActionType.ASN | Types.ActionType.Part | Types.ActionType.Common)]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [ColumnName("PARENT_DISK_ID")]
        public string ParentId
        {
            get { return parentId == null ? string.Empty : parentId; }
            set { parentId = value; }
        }
        [ColumnName("STORERKEY", Action = Types.ActionType.ASN)]
        public string Storer
        {
            get { return storer == null ? string.Empty : storer; }
            set { storer = value; }
        }

        internal SKU Sku
        {
            get
            {
                if (sku == null) return EmptySKU;
                return sku;
            }
            set
            {
                sku = value;
                this.BillRowNo = value == null ? string.Empty : this.sku.BillRowNo;
            }
        }
        [ColumnName("BillNo", Action = Types.ActionType.ASN)]
        public string BillNo
        {
            get { return billNo == null ? string.Empty : billNo; }
            set { billNo = value; }
        }
        [ColumnName("BillRowNo", Action = Types.ActionType.ASN | Types.ActionType.PutAway | Types.ActionType.Pick)]
        public string BillRowNo
        {
            get { return billRowNo == null ? string.Empty : billRowNo; }
            set { billRowNo = value; }
        }
        [ColumnName("SKU", Action = Types.ActionType.ASN | Types.ActionType.PutAway | Types.ActionType.Pick | Types.ActionType.Common)]
        public string SkuId
        {
            get { return skuId == null ? string.Empty : skuId; }
            set { skuId = value; }
        }
        [ColumnName("MANUFACTURE_DATE", Action = Types.ActionType.ASN | Types.ActionType.Common)]
        public DateTime CreateDateTime
        {
            get { return createDateTime; }
            set { createDateTime = value; }
        }
        [ColumnName("IsScaned", Action = Types.ActionType.ASN | Types.ActionType.PutAway | Types.ActionType.Pick | Types.ActionType.Part
            | Types.ActionType.Return | Types.ActionType.Common | Types.ActionType.MoveLoc)]
        public bool IsScaned
        {
            get { return isScaned; }
            set { isScaned = value; }
        }
        [ColumnName("LOC", Action = Types.ActionType.PutAway | Types.ActionType.Part | Types.ActionType.ASN)]
        public string Loc
        {
            get { return loc == null ? string.Empty : loc; }
            set { loc = value; }
        }
        [ColumnName("LOCK_QTY", Action = Types.ActionType.Pick | Types.ActionType.Part)]
        public int LockCount
        {
            get { return lockCount; }
            set { lockCount = value; }
        }
        [ColumnName("LOCK_BS_KEY", Action = Types.ActionType.Pick | Types.ActionType.Part)]
        public string LockBillNo
        {
            get { return lockBillNo; }
            set { lockBillNo = value; }
        }
        [ColumnName("SubDiskId", Action = Types.ActionType.Part)]
        public string SubDiskId
        {
            get { return subDiskId == null ? string.Empty : subDiskId; }
            set { subDiskId = value; }
        }
        [ColumnName("PartCount", Action = Types.ActionType.Part)]
        public int PartCount
        {
            get { return partCount; }
            set { partCount = value; }
        }
        [ColumnName("LOT", Action = Types.ActionType.PutAway | Types.ActionType.Part)]
        public string Lot
        {
            get { return lot == null ? string.Empty : lot; }
            set { lot = value; }
        }
        public int ScanCount
        {
            get
            {
                return this.lockCount > 0 ? lockCount : this.count;
            }
        }
        [ColumnName("NEW_LOC", Action = Types.ActionType.MoveLoc)]
        public string NewLoc
        {
            get { return newLoc; }
            set { newLoc = value; }
        }
        [ColumnName("RECEIPTKEY")]
        public string Receiptkey
        {
            get { return receiptkey; }
            set { receiptkey = value; }
        }
        [ColumnName("OUT_OPTION")]
        public int OutOption
        {
            get { return outOption; }
            set { outOption = value; }
        }
        [ColumnName("QTYALLOCATED")]
        public int QtyAllocated
        {
            get { return qtyallocated; }
            set { qtyallocated = value; }        
        }
        [ColumnName("QTY", Action = Types.ActionType.Pick)]
        public int QtyLeft
        {
            get { return qtyleft; }
            set { qtyleft = value; }
        }
        public bool IsFullDisk
        {
            get
            {
                if (this.outOption == 2) { return true; }
                else { return false; }
            }

        }
        #endregion

        #region 公共方法
        public Disk()
        {
        }
        public Disk(string DiskId)
        {
            this.id = DiskId;
            this.Sku = new SKU();
        }
        public Disk(SKU sku, DataRow dr)
        {
            this.sku = sku;
            if (!dr.Table.Columns.Contains(this.GetColName4Pro("Id")))
            {
                throw new Exception("料盘号为空，初始化数据失败！");
            }
            Pro2Col.DataRow2Obj(this, dr);
        }
        public Types.ScanInfo UnPutAway()
        {
            Types.ScanInfo si;
            si = this.sku.Scan(-this.count, this.loc);
            if (si != Types.ScanInfo.Successful) { return si; }
            this.isScaned = false;
            this.loc = string.Empty;
            this.lot = string.Empty;
            this.sku = null;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo PutAway(string locNo)
        {
            Types.ScanInfo si;
            si = this.sku.Scan(this.count, locNo);
            if (si != Types.ScanInfo.Successful) { return si; }
            this.isScaned = true;
            this.loc = locNo;
            this.lot = this.sku.Lot;
            return Types.ScanInfo.Successful;
        }

        /// <summary>
        /// 2010-10-5增加
        /// </summary>
        /// <returns></returns>
        public Types.ScanInfo UnMoveLot()
        {
            Types.ScanInfo si;
            si = this.sku.Scan(-this.count);
            if (si != Types.ScanInfo.Successful) { return si; }
            this.isScaned = false;
            //this.loc = string.Empty;
            this.lot = string.Empty;
            this.sku = null;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo MoveLot(string lot)
        {
            Types.ScanInfo si;
            si = this.sku.Scan(this.count);
            if (si != Types.ScanInfo.Successful) { return si; }
            this.isScaned = true;
            this.lot = lot;
            //this.lot = this.sku.Lot;
            return Types.ScanInfo.Successful;
        }



        public Types.ScanInfo UnAsn()
        {
            Types.ScanInfo si;
            si = Scan(true, false);
            if (si != Types.ScanInfo.Successful) { return si; }
            this.sku = null;
            this.billNo = string.Empty;
            this.skuId = string.Empty;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo Asn(DateTime createDateTime)
        {
            Types.ScanInfo si;
            si = Scan(false, false);
            if (si != Types.ScanInfo.Successful) { return si; }
            this.billNo = this.sku.BillNo;
            this.skuId = this.sku.Id;
            this.createDateTime = createDateTime;
            return Types.ScanInfo.Successful;
        }

        public Types.ScanInfo unPick()
        {
            Types.ScanInfo si;
            if (this.IsFullDisk)
            {
                si = this.sku.ScanFullDisk(-this.ScanCount);
                if (si != Types.ScanInfo.Successful) { return si; }
            }
            si = Scan(true);
            if (si != Types.ScanInfo.Successful)
            {
                this.sku.ScanFullDisk(this.ScanCount);
                return si;
            }
            UnLock();
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo Pick()
        {
            Types.ScanInfo si;
            if (this.IsFullDisk)
            {    //del by levin
                //si = this.sku.ScanFullDisk(this.ScanCount);
                si = this.sku.ScanFullDisk(1);
                if (si != Types.ScanInfo.Successful) { return si; }
            }
            this.Lock();
            si = this.Scan(false);
            if (si != Types.ScanInfo.Successful)
            {
                this.sku.ScanFullDisk(-this.ScanCount);
                UnLock();
                return si;
            }
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo UnPart()
        {
            if (!this.isScaned) { return Types.ScanInfo.NotScan; }
            this.subDiskId = string.Empty;
            this.partCount = 0;
            this.isScaned = false;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo Part(string subDiskId, int partCount)
        {
            if (this.isScaned) { return Types.ScanInfo.RepeatScan; }
            if (this.count > 0 && this.lockCount != partCount) { return Types.ScanInfo.PartCountError; }
            this.partCount = partCount;
            this.subDiskId = subDiskId;
            this.isScaned = true;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo UnReturn()
        {
            if (!this.isScaned) { return Types.ScanInfo.NotScan; }
            this.isScaned = false;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo Return()
        {
            if (this.isScaned) { return Types.ScanInfo.RepeatScan; }
            this.isScaned = true;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo UnCommanScan()
        {
            if (!this.isScaned) { return Types.ScanInfo.NotScan; }
            this.isScaned = false;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo CommanScan()
        {
            if (this.isScaned) { return Types.ScanInfo.RepeatScan; }
            this.isScaned = true;
            this.createDateTime = DateTime.Now;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo MoveBegin()
        {
            if (this.needMove) { return Types.ScanInfo.RepeatScan; }
            this.needMove = true;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo UnMoveBegion()
        {
            if (!this.needMove) { return Types.ScanInfo.NotScan; }
            this.needMove = false;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo Move(string newLoc)
        {
            if (this.isScaned) { return Types.ScanInfo.RepeatScan; }
            if (!this.needMove) { return Types.ScanInfo.NotInBill; }
            this.isScaned = true;
            this.newLoc = newLoc;
            return Types.ScanInfo.Successful;
        }
        public Types.ScanInfo UnMove()
        {
            if (!this.isScaned) { return Types.ScanInfo.NotScan; }
            this.isScaned = false;
            this.newLoc = string.Empty;
            return Types.ScanInfo.Successful;
        }
        public string GetColName4Pro(string propertyName)
        {
            return Pro2Col.GetColName4Pro(this.GetType(), propertyName);
        }
        #endregion
        #region 私有方法

        private Types.ScanInfo Scan(bool isUndo)
        {
            return Scan(isUndo, false);
        }
        private Types.ScanInfo Scan(bool isUndo, bool notCheckCount)
        {
            Types.ScanInfo si;
            si = this.sku.Scan(isUndo ? -this.ScanCount : this.ScanCount, notCheckCount);
            if (si != Types.ScanInfo.Successful) { return si; }
            if (isUndo) { isScaned = false; }
            else { isScaned = true; }
            return Types.ScanInfo.Successful;
        }

        private void Lock()
        {
            //del by levin
            //int skuNeedCount = this.sku.GetNeedCount();
            //add by levin
            int skuNeedCount = 0;
            if (this.QtyAllocated < this.QtyLeft && this.OutOption == 1)
            {
                skuNeedCount = this.QtyAllocated;
            }

            if (skuNeedCount > 0 && this.count > skuNeedCount)
            {
                this.lockCount = skuNeedCount;
                this.lockBillNo = this.sku.BillNo;
            }
        }
        private void UnLock()
        {
            this.lockCount = 0;
            this.lockBillNo = string.Empty;
        }
        #endregion

    }
}
