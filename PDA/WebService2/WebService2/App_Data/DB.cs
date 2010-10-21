using System;

using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data.OracleClient;
using System.Data;
using System.Data.Common;
using System.Collections;

namespace WebService2
{
    class DB
    {
        private string _connString;


        public string ConnString
        {
            get
            {
                if (string.IsNullOrEmpty(_connString))
                {
                    return GetDBConnString();
                }
                else
                {
                    return _connString;
                }
            }
            set
            {
                _connString = value;
            }
        }
        public static string GetDBConnString()
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Request.MapPath(@"/Config/Config.xml"));
            XmlNode xmlN = xmlDoc.DocumentElement.SelectSingleNode("DataSource/ConnString");
            if (xmlN == null)
            {
                return string.Empty;
            }
            else
            {
                return xmlN.InnerText;
            }


        }
        public DataSet GetDataSet(string sql)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    OracleCommand scc = new OracleCommand(sql, conn);
                    OracleDataAdapter scd = new OracleDataAdapter(scc);
                    DataSet ds = new DataSet();
                    scd.Fill(ds);
                    return ds;
                }
            }
            catch
            {
                return new DataSet();
            }
        }
        public int ExecSql(string sql)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    OracleCommand scc = new OracleCommand(sql, conn);
                    conn.Open();
                    return scc.ExecuteNonQuery();
                }
            }
            catch
            {
                return -1;
            }

        }
        public int ExecSql(string[] sqls)
        {
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                OracleTransaction st;
                conn.Open();
                st = conn.BeginTransaction();
                try
                {
                    foreach (string sql in sqls)
                    {
                        OracleCommand scc = new OracleCommand(sql, conn);
                        scc.Transaction = st;
                        scc.ExecuteNonQuery();
                    }
                    st.Commit();
                    return 0;

                }
                catch
                {
                    st.Rollback();
                    return -1;
                }
            }
        }

        public string isInDataBase(string id)
        {
            string sql = "select disk_id from lm_disk where disk_id='" + id + "'";
            DataSet ds = new DataSet();
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                conn.Open();
                OracleCommand oc1 = new OracleCommand(sql, conn);
                OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                oda1.Fill(ds, "disk");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return "TRUE";
                }
                else
                {
                    return "FALSE";
                }
            }
        }

        /// <summary>
        /// 获取ASN单的信息及详细物料、料盘信息
        /// </summary>
        /// <param name="asn"></param>
        /// <returns></returns>
        public DataSet getASNDetail(string asn)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    conn.Open();
                    //                    string sqlasn = @"select r.receiptkey as billNo,rd.RECEIPTLINENUMBER as BillRowNo,rd.sku,rd.storerkey,st.company,s.descr,rd.DATERECEIVED,rd.QTYEXPECTED,nvl(temptable.tempnum,0) as ScanCount,
                    //rd.QTYEXPECTED as Count,p.casecnt,0 as ScanFinish,s.DESCR as sku_name,' ' as LOC from
                    //wh10.RECEIPT r inner join wh10.RECEIPTDETAIL rd on r.RECEIPTKEY=rd.RECEIPTKEY 
                    //left join wh10.SKU s on rd.sku=s.sku and rd.storerkey = s.storerkey
                    //left join wh10.STORER st on r.storerkey=st.storerkey
                    //left join wh10.PACK p on s.packkey=p.packkey
                    //left join (select sku,RECEIPTKEY,sum(nvl(left_qty,0)) as tempnum from lm_disk group by sku,RECEIPTKEY) temptable on rd.sku=temptable.sku and rd.receiptkey = temptable.RECEIPTKEY
                    //where r.RECEIPTKEY='" + asn + "' and NVL(r.scan_status,0)<>1 and nvl(temptable.tempnum,0) < rd.qtyexpected";
                    string sqlasn = @"SELECT rc.receiptkey AS billno,
       rc.receiptkey || '&' || rdetail.sku AS BillRowNo,
       rdetail.sku,
       rc.storerkey,
       storer.company,
       sku.descr,
       rdetail.QTYEXPECTED AS count,
       NVL(diskdata.total_qty,0) AS ScanCount,
       (rdetail.QTYEXPECTED - NVL(diskdata.total_qty,0)) AS canscanqty,
       pack.casecnt,
       0 AS scanfinish,
       '' AS loc        
  FROM wh10.receipt rc,
       (SELECT SUM(QTYEXPECTED) AS QTYEXPECTED,sku,RECEIPTKEY 
          FROM wh10.receiptdetail
         GROUP BY RECEIPTKEY,sku) rdetail,
       (SELECT sku, RECEIPTKEY, sum(nvl(left_qty, 0)) as total_qty
          FROM lm_disk
         GROUP BY sku, RECEIPTKEY) diskdata,
       wh10.storer,wh10.sku,wh10.pack
  WHERE rc.receiptkey = rdetail.receiptkey
    AND rc.storerkey = storer.storerkey
    AND rdetail.sku = sku.sku
    AND rc.storerkey = sku.storerkey
    AND sku.packkey = pack.packkey(+)
    AND rdetail.sku = diskdata.sku(+)
    AND rdetail.receiptkey = diskdata.receiptkey(+)
    --AND rc.receiptkey = '1009210027'
    --AND rdetail.sku = '174-000413'
    AND rc.receiptkey = '" + asn + "' AND nvl(diskdata.total_qty,0) < nvl(rdetail.QTYEXPECTED,0)";
                    OracleCommand oc1 = new OracleCommand(sqlasn, conn);
                    OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                    DataSet ds = new DataSet();
                    oda1.Fill(ds, "ASN");
                    return ds;
                }
            }
            catch
            {
                return new DataSet();
            }
        }

        //        public bool SaveAsn(DataTable dt)
        //        {
        //             StringBuilder sqlinsert = new StringBuilder();
        //             sqlinsert.Append("begin ");
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    sqlinsert.AppendFormat(@"insert into LM_DISK (DISK_ID,STORER,STORER_DESC,SKU,TOTAL_QTY,LEFT_QTY,RECEIPTKEY,CREATED_BY,CREATED_DATE,
        //SKU_DESC) select '{0}',b.STORERKEY as STORER,c.COMPANY as STORER_DESC,'{1}',{2},{3},'{4}','{5}',sysdate,b.DESCR as SKU_DESC 
        //from SKU b left join STORER c on b.STORERKEY=c.STORERKEY where b.SKU='{1}';", dt.Rows[i]["DISK_ID"].ToString(),
        //                            dt.Rows[i]["SKU"].ToString(), dt.Rows[i]["LEFT_QTY"].ToString(), dt.Rows[i]["LEFT_QTY"].ToString(),
        //                            dt.Rows[i]["BillNo"].ToString(), "Admin");
        //                   // sqlinsert.AppendLine();
        //                }
        //            sqlinsert.Append(" end;");
        //                return ExecSql(sqlinsert.ToString())==1;
        //        }

        /// <summary>
        /// 保存ASN数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool SaveAsn(DataTable dt, string userid)
        {
            try
            {
                StringBuilder sqlinsert = new StringBuilder();
                //sqlinsert.Append("begin ");
                ArrayList al = new ArrayList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sqlinsert.AppendFormat(@"insert into LM_DISK (DISK_ID,STORER,STORER_DESC,SKU,TOTAL_QTY,LEFT_QTY,RECEIPTKEY,CREATED_BY,CREATED_DATE,
                   SKU_DESC,RECEIPT_DATE,UPDATED_BY,UPDATED_DATE,loc,LOTTABLE01,LOTTABLE02,LOTTABLE03,LOTTABLE04,LOTTABLE05,LOTTABLE06,LOTTABLE07,
                   LOTTABLE08,LOTTABLE09,LOTTABLE10) 
                   select '{0}',b.STORERKEY as STORER,c.COMPANY as STORER_DESC,'{1}',{2},{3},'{4}','{5}',sysdate,b.DESCR as SKU_DESC,sysdate,'{5}',
                           sysdate,'{7}',rd.LOTTABLE01,rd.LOTTABLE02,rd.LOTTABLE03,rd.LOTTABLE04,rd.LOTTABLE05,rd.LOTTABLE06,rd.LOTTABLE07,
                           rd.LOTTABLE08,rd.LOTTABLE09,rd.LOTTABLE10
                     from wh10.SKU b left 
                     join wh10.STORER c on b.STORERKEY=c.STORERKEY 
                     join (SELECT DISTINCT receiptkey,storerkey,sku,lottable01,lottable02,
                 lottable03,lottable04,lottable05,lottable06,
                 lottable07,lottable08,lottable09,lottable10
             FROM wh10.receiptdetail
            WHERE SKU = '{1}'
              AND STORERKEY = '{6}') rd on b.sku=rd.sku and rd.RECEIPTKEY='{4}' where b.SKU='{1}' and b.STORERKEY='{6}';"
                        , dt.Rows[i]["DISK_ID"].ToString(),
                            dt.Rows[i]["SKU"].ToString(), dt.Rows[i]["LEFT_QTY"].ToString(), dt.Rows[i]["LEFT_QTY"].ToString(),
                            dt.Rows[i]["BillNo"].ToString(), userid, dt.Rows[i]["STORERKEY"].ToString(), dt.Rows[i]["LOC"].ToString());
                    if (!al.Contains(dt.Rows[i]["BillNo"].ToString()))
                    {
                        al.Add(dt.Rows[i]["BillNo"].ToString());
                    }

                }
                //sqlinsert.Append(" end;");
                AddBeginEnd(sqlinsert);

                string idlist = string.Empty;
                if (al.Count > 0)
                {
                    foreach (object o in al)
                    {
                        idlist += "'" + o.ToString() + "',";
                    }
                    idlist = idlist.Substring(0, idlist.Length - 1);
                }

                string sqlupdateasn = string.Format(@"update wh10.RECEIPT set scan_status=1 
where RECEIPTKEY in
(select tempa.receiptkey 
   from 
   (select receiptkey ,sum(qtyreceived) as count
      from wh10.RECEIPTDETAIL
      where RECEIPTKEY in ({0})
      group by receiptkey) tempa
    join 
    (select RECEIPTKEY,sum(left_qty) as count 
      from lm_disk 
      where RECEIPTKEY in ({0})
      group by RECEIPTKEY
    ) tempb on tempa.count = tempb.count
 )", idlist);

                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    OracleCommand oc = new OracleCommand(sqlinsert.ToString(), conn);
                    OracleCommand oc2 = new OracleCommand(sqlupdateasn, conn);
                    conn.Open();

                    if (oc.ExecuteNonQuery() > 0)
                    {
                        oc2.ExecuteNonQuery();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取上架数据
        /// </summary>
        /// <param name="ptBill"></param>
        /// <returns></returns>
        public DataSet GetPutAwayData(string ptBill)
        {
            //            string sqlForBill = @"select lptd.receiptkey,lptd.sku,s.descr,lptd.lot,lptd.temp_loc,nvl(lptd.EXPECTED_PUTAWAY_QTY,0) as Count,lptd.EXPECTED_PUTAWAY_QTY,lptd.EXPECTED_LOC,st.company,lptd.TEMP_ID,lptd.RECEIPTKEY as billNo,
            //lptd.RECEIPTKEY || '&' || lptd.lot  || '&' || lptd.sku as billRowNo,0 as scanFinish,nvl(tld.ScanCount,0) as ScanCount,lptd.STORERKEY
            //from LM_PUTAWAY_TASK lpt inner join LM_PUTAWAY_TASK_DETAIL lptd on lpt.task_key=lptd.task_key
            //left join(SELECT ld.RECEIPTKEY,ld.LOT,ld.SKU,SUM(ld.LEFT_QTY) as ScanCount
            //from LM_DISK ld JOIN LM_DISK_INOUT ldio ON ld.DISK_ID = ldio.DISK_ID
            //where ldio.BS_KEY = '" + ptBill + @"' and ldio.ACTION_TYPE = 1
            //GROUP BY ld.RECEIPTKEY,ld.LOT,ld.SKU
            //) tld ON lptd.RECEIPTKEY = tld.RECEIPTKEY AND lptd.LOT = tld.LOT AND lptd.SKU = tld.SKU
            //left join wh10.SKU s on lptd.sku=s.sku and lptd.storerkey = s.storerkey
            //left join wh10.STORER st on lpt.storer=st.storerkey where lptd.receiptkey='" + ptBill + "' and lpt.STATUS<>1 and lptd.Status <> 1";

            string sqlForBill = string.Format(@"SELECT lptdata.receiptkey AS BillNo,lptdata.receiptkey,lptdata.storerkey,lptdata.sku,lptdata.descr,lptdata.lot,billRowNo,TEMP_ID,
       (lptdata.qty - NVL(diskdata.qty,0)) AS Count,lptdata.expected_loc,lptdata.temp_loc,lptdata.company,scanFinish,ScanCount
  FROM
      (SELECT lptd.receiptkey,
             lptd.storerkey,
             lptd.sku,
             lptd.temp_loc,
             sku.descr,
             lptd.lot,
             SUM(nvl(lptd.EXPECTED_PUTAWAY_QTY, 0)) AS qty,
             lptd.RECEIPTKEY || '&' || lptd.lot || '&' || lptd.sku as billRowNo,
             lptd.expected_loc,
             lptd.TEMP_ID,
             storer.company,
             0 as scanFinish,
             0 as ScanCount
        FROM lm_putaway_task lpt,lm_putaway_task_detail lptd,wh10.sku sku,wh10.storer storer
       WHERE lpt.task_key = lptd.task_key
         AND lptd.storerkey = sku.storerkey
         AND lptd.sku = sku.sku
         AND lptd.storerkey = storer.storerkey 
         AND lptd.receiptkey = '{0}'
       GROUP BY lptd.receiptkey,lptd.storerkey,lptd.sku,sku.descr,lptd.lot,lptd.expected_loc,storer.company,lptd.temp_loc,lptd.TEMP_ID) lptdata,
       (SELECT lot,receiptkey,sku,SUM(left_qty) AS qty
          FROM lm_disk
         WHERE receiptkey = '{0}'
         GROUP BY lot,receiptkey,sku) diskdata
  WHERE lptdata.lot = diskdata.lot(+)
    AND lptdata.receiptkey = diskdata.receiptkey(+)
    AND lptdata.sku = diskdata.sku(+)", ptBill);

            //            string sqlForDisk = @"select lptd.RECEIPTKEY as billNo,'' as billRowNo,ld.disk_id,ld.storer_desc,ld.sku,ld.sku_desc,ld.left_qty,ld.loc,0 as IsScaned,'' as lot,RECEIPTKEY from 
            //LM_DISK ld inner join 
            //(select distinct task_key,receiptkey, sku
            //from LM_PUTAWAY_TASK_DETAIL
            //where STATUS<>1) lptd on ld.receiptkey=lptd.receiptkey and ld.sku=lptd.sku
            //where lptd.receiptkey='" + ptBill + "' and ld.loc is null";

            string sqlForDisk = string.Format(@"SELECT lptd.RECEIPTKEY as billNo,
       '' as billRowNo,
       ld.disk_id,
       ld.storer,
       ld.storer_desc,
       ld.sku,
       ld.sku_desc,
       ld.left_qty,
       ld.loc,
       0 as IsScaned,
       --'' as lot,
       ltb.lot as lot,
       ld.RECEIPTKEY,
       lptd.temp_loc,
       ltb.lot as fromlot
  FROM LM_DISK ld,
       wh10.lotattribute ltb,
       (SELECT disk_id 
          FROM lm_disk_inout
         WHERE action_type = 1
           AND bs_key = '{0}') inout,
       (SELECT DISTINCT task_key, receiptkey, sku, temp_loc
          FROM LM_PUTAWAY_TASK_DETAIL
         WHERE STATUS <> 1) lptd       
  WHERE ld.disk_id = inout.disk_id(+)
    AND NVL(inout.disk_id,'$') = '$'
    AND ld.receiptkey = lptd.receiptkey
    AND ld.sku = lptd.sku
    AND ltb.storerkey = ld.storer
    AND ltb.lottable01 = ld.lottable01
    AND ltb.lottable02 = ld.lottable02
    AND ltb.lottable03 = ld.lottable03
    AND TO_CHAR(ltb.lottable04, 'YYYY-MM-DD') = '2001-01-01'
    AND ltb.lottable05 = ld.lottable05
    AND ltb.lottable06 = ld.lottable06
    AND ltb.lottable07 = ld.lottable07
    AND ltb.lottable08 = ld.lottable08
    AND ltb.lottable09 = ld.lottable09
    AND ltb.lottable10 = ld.lottable10
    AND  lptd.receiptkey = '{0}'", ptBill);


            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    conn.Open();
                    OracleCommand oc1 = new OracleCommand(sqlForBill, conn);
                    OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                    DataSet ds = new DataSet();
                    oda1.Fill(ds, "PutAwayBill");

                    OracleCommand oc2 = new OracleCommand(sqlForDisk, conn);
                    OracleDataAdapter oda2 = new OracleDataAdapter(oc2);
                    oda2.Fill(ds, "PutAwayDisk");
                    return ds;
                }
            }
            catch
            {
                return new DataSet();
            }
        }

        /// <summary>
        /// 保存更新上架信息
        /// </summary>
        /// <param name="dtDisk"></param>
        /// <param name="dtLoc"></param>
        /// <returns></returns>
        public bool SavePutAway(DataTable dtDisk, DataTable dtLoc, string strFinishBill, string userid, DataTable dtSku)
        {
            StringBuilder sqlinsertIO = new StringBuilder();
            StringBuilder sqlupdateLOTXLOCXID = new StringBuilder();
            StringBuilder sqlupdateLOTXLOCXIDNew = new StringBuilder();
            StringBuilder sqlupdateSKUXLOC = new StringBuilder();
            StringBuilder sqlupdateSKUXLOCNew = new StringBuilder();
            StringBuilder sqlupdateDisk = new StringBuilder();
            StringBuilder sqlUpdatePutAwayBill = new StringBuilder();
            StringBuilder sqlUpdateSKUStatus = new StringBuilder();
            StringBuilder sqlUpdateASNBill = new StringBuilder();
            ArrayList asns = new ArrayList();

            if (dtDisk.Rows.Count > 0)
            {
                //sqlinsertIO.Append("begin ");
                //sqlupdateDisk.Append("begin ");
                for (int i = 0; i < dtDisk.Rows.Count; i++)
                {
                    if (dtDisk.Rows[i]["IsScaned"].ToString() == "1")
                    {
                        sqlinsertIO.AppendFormat(@"insert into LM_DISK_INOUT(DISK_ID,BS_KEY,SKU,ACTION_TYPE,QTY,CREATED_BY,CREATED_DATE) 
select'{0}','{1}','{2}',1,{3},'{4}',sysdate from dual;", dtDisk.Rows[i]["DISK_ID"].ToString(), dtDisk.Rows[i]["billNo"].ToString(),
                            dtDisk.Rows[i]["SKU"].ToString(), dtDisk.Rows[i]["LEFT_QTY"].ToString(), userid);

                        sqlupdateDisk.AppendFormat(@"update LM_DISK set LOC='{0}',LOT = '{2}',UPDATED_BY='{3}',UPDATED_DATE=sysdate,lottable04 = TO_DATE('01-01-2001','mm-dd-yyyy') where DISK_ID='{1}';",
                            dtDisk.Rows[i]["LOC"].ToString(), dtDisk.Rows[i]["DISK_ID"].ToString(), dtDisk.Rows[i]["lot"], userid);
                        if (!asns.Contains(dtDisk.Rows[i]["RECEIPTKEY"].ToString()))
                        {
                            asns.Add(dtDisk.Rows[i]["RECEIPTKEY"].ToString());
                        }
                    }
                }
                //sqlinsertIO.Append(" end;");
                //sqlupdateDisk.Append(" end;");

                AddBeginEnd(sqlinsertIO);
                AddBeginEnd(sqlupdateDisk);
            }
            #region 取消功能
            //            if (dtLoc.Rows.Count > 0)
            //            {
            //                //sqlupdateLOTXLOCXID.Append("begin ");
            //                //sqlupdateLOTXLOCXIDNew.Append("begin ");
            //                //sqlupdateSKUXLOC.Append("begin ");
            //                //sqlupdateSKUXLOCNew.Append("begin ");
            //                for (int i = 0; i < dtLoc.Rows.Count; i++)
            //                {
            //                    sqlupdateLOTXLOCXID.AppendFormat(@"update wh10.LOTXLOCXID set QTY=QTY-{0},EDITWHO='{4}',EDITDATE=sysdate where  
            //LOC=(select TEMP_LOC from LM_PUTAWAY_TASK_DETAIL where TASK_KEY='{1}' and TASK_LINE_NUMBER='{2}') and 
            //ID=(select TEMP_ID from LM_PUTAWAY_TASK_DETAIL where TASK_KEY='{1}' and TASK_LINE_NUMBER='{2}') and LOT='{3}';",
            //    dtLoc.Rows[i]["QTY"].ToString(), dtLoc.Rows[i]["BillNo"].ToString(), dtLoc.Rows[i]["BillRowNo"].ToString(), dtLoc.Rows[i]["LOT"].ToString(), userid);

            //                    sqlupdateLOTXLOCXIDNew.AppendFormat(@"update wh10.LOTXLOCXID set QTY=QTY+{4},EDITWHO='{7}',EDITDATE=sysdate where LOT='{3}' and ID=' ' and LOC='{2}';if sql%rowcount = 0 then insert into wh10.LOTXLOCXID(LOC,ID,LOT,STORERKEY,SKU,QTY,QTYALLOCATED,ADDWHO,ADDDATE) select '{2}',' ','{3}','{5}','{6}',{4},{4},'{7}',sysdate from dual;end if;", dtLoc.Rows[i]["BillNo"].ToString(), dtLoc.Rows[i]["BillRowNo"].ToString(), dtLoc.Rows[i]["LOC"].ToString(), dtLoc.Rows[i]["LOT"].ToString(),
            //           dtLoc.Rows[i]["QTY"].ToString(), dtLoc.Rows[i]["STORERKEY"].ToString(), dtLoc.Rows[i]["SKU"].ToString(), userid);

            //                    sqlupdateSKUXLOC.AppendFormat(@"update wh10.SKUXLOC set QTY=QTY-{0},EDITWHO='{5}',EDITDATE=sysdate where STORERKEY='{1}' and SKU='{2}' and 
            //LOC=(select TEMP_LOC from LM_PUTAWAY_TASK_DETAIL where TASK_KEY='{3}' and TASK_LINE_NUMBER='{4}');", dtLoc.Rows[i]["QTY"].ToString(),
            //    dtLoc.Rows[i]["STORERKEY"].ToString(), dtLoc.Rows[i]["SKU"].ToString(), dtLoc.Rows[i]["BillNo"].ToString(), dtLoc.Rows[i]["BillRowNo"].ToString(), userid);

            //                    sqlupdateSKUXLOCNew.AppendFormat(@"update wh10.SKUXLOC set QTY=QTY+{3},EDITWHO='{4}',EDITDATE=sysdate where STORERKEY='{0}' and SKU='{1}' and LOC='{2}';if sql%rowcount = 0 then insert into wh10.SKUXLOC (STORERKEY,SKU,LOC,QTY,QTYALLOCATED,ADDDATE,ADDWHO,EDITDATE,EDITWHO) select '{0}','{1}','{2}',{3},{3},sysdate,'{4}',sysdate,'{4}' from dual;end if;", dtLoc.Rows[i]["STORERKEY"].ToString(), dtLoc.Rows[i]["SKU"].ToString(), dtLoc.Rows[i]["LOC"].ToString(), dtLoc.Rows[i]["QTY"].ToString(), userid);
            //                }
            //                //sqlupdateLOTXLOCXID.Append(" end;");
            //                //sqlupdateLOTXLOCXIDNew.Append(" end;");
            //                //sqlupdateSKUXLOC.Append(" end;");
            //                //sqlupdateSKUXLOCNew.Append(" end;");

            //                AddBeginEnd(sqlupdateLOTXLOCXID);
            //                AddBeginEnd(sqlupdateLOTXLOCXIDNew);
            //                AddBeginEnd(sqlupdateSKUXLOC);
            //                AddBeginEnd(sqlupdateSKUXLOCNew);
            //            }
            //if (dtSku.Rows.Count > 0)
            //{
            //    //sqlUpdateSKUStatus.Append("begin ");
            //    foreach (DataRow dr in dtSku.Rows)
            //    {
            //        if (dr["ScanFinish"].ToString() == "0")
            //        {
            //            continue;
            //        }
            //        sqlUpdateSKUStatus.AppendFormat(@"update LM_PUTAWAY_TASK_DETAIL set status = 1,UPDATED_BY='{2}',UPDATED_DATE=sysdate where TASK_KEY='{0}' and TASK_LINE_NUMBER = '{1}';", dr["BillNo"], dr["BillRowNo"], userid);
            //    }
            //    //sqlUpdateSKUStatus.Append(" end;");
            //    AddBeginEnd(sqlUpdateSKUStatus);
            //}

            //string[] strTemp = strFinishBill.Split(',');
            //if (strTemp.Length > 0 && strFinishBill.Length > 0)
            //{
            //    //sqlUpdatePutAwayBill.Append("begin ");
            //    foreach (string str in strTemp)
            //    {
            //        sqlUpdatePutAwayBill.AppendFormat(@"update LM_PUTAWAY_TASK set STATUS=1,UPDATED_BY='{1}',UPDATED_DATE=sysdate where TASK_KEY='{0}';", str, userid);
            //    }
            //    //sqlUpdatePutAwayBill.Append(" end;");
            //    AddBeginEnd(sqlUpdatePutAwayBill);
            //}
            #endregion
            if (asns.Count > 0)
            {
                StringBuilder asnIds = new StringBuilder();
                foreach (object asn in asns)
                {
                    asnIds.AppendFormat("'{0}',", asn);
                    asnIds.Length = asnIds.Length - 1;
                }
                sqlUpdateASNBill.AppendFormat(@"update wh10.RECEIPT set PUTAWAY_STATUS = 1 
where RECEIPTKEY in
(select tempa.receiptkey 
   from 
   (select receiptkey ,sum(EXPECTED_PUTAWAY_QTY) as count
      from LM_PUTAWAY_TASK_DETAIL
      where RECEIPTKEY in ({0})
      group by receiptkey) tempa
    join 
    (select RECEIPTKEY,sum(left_qty) as count 
      from lm_disk ld join LM_DISK_INOUT ldio on ld.DISK_ID = ldio.DISK_ID AND ldio.BS_KEY = ld.RECEIPTKEY and ldio.ACTION_TYPE = 1
      where RECEIPTKEY in ({0})
      group by RECEIPTKEY
    ) tempb on tempa.count = tempb.count
 )", asnIds.ToString());
            }
            string[] sqls = { sqlinsertIO.ToString(), sqlupdateLOTXLOCXID.ToString(), sqlupdateLOTXLOCXIDNew.ToString(), sqlupdateSKUXLOC.ToString(), sqlupdateSKUXLOCNew.ToString(), sqlupdateDisk.ToString(), sqlUpdateSKUStatus.ToString(), sqlUpdatePutAwayBill.ToString(), sqlUpdateASNBill.ToString() };
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                OracleTransaction st;
                conn.Open();
                st = conn.BeginTransaction();
                try
                {
                    foreach (string sql in sqls)
                    {
                        if (string.IsNullOrEmpty(sql)) { continue; }
                        OracleCommand scc = new OracleCommand(sql, conn);
                        scc.Transaction = st;
                        scc.ExecuteNonQuery();
                    }
                }
                catch
                {
                    st.Rollback();
                    return false;
                }

                if (dtDisk.Rows.Count == 0)
                {
                    st.Commit();
                    return true;
                }

                try
                {
                    for (int j = 0; j < dtDisk.Rows.Count; j++)
                    {
                        if (dtDisk.Rows[j]["IsScaned"].ToString() == "0") { continue; }
                        OracleCommand scc = new OracleCommand("WH10.INV_MOVEMENT_PROCESS", conn, st);
                        scc.CommandType = CommandType.StoredProcedure;
                        OracleParameterCollection pc = scc.Parameters;
                        pc.Add(new OracleParameter("FROMSTORERKEY", dtDisk.Rows[j]["STORER"].ToString()));
                        pc.Add(new OracleParameter("FROMSKU", dtDisk.Rows[j]["SKU"].ToString()));
                        pc.Add(new OracleParameter("FROMLOT", dtDisk.Rows[j]["fromlot"].ToString()));
                        pc.Add(new OracleParameter("FROMLOC", dtDisk.Rows[j]["temp_loc"].ToString()));
                        pc.Add(new OracleParameter("FROMID", " "));
                        pc.Add(new OracleParameter("QTY", Convert.ToInt32(dtDisk.Rows[j]["LEFT_QTY"])));
                        pc.Add(new OracleParameter("TOLOC", dtDisk.Rows[j]["LOC"].ToString()));
                        pc.Add(new OracleParameter("TOID", " "));
                        pc.Add(new OracleParameter("USERCODE", userid));
                        pc.Add(new OracleParameter("result_code", OracleType.Number));
                        pc["result_code"].Direction = ParameterDirection.Output;
                        scc.ExecuteNonQuery();
                        if (Convert.ToInt32(scc.Parameters["result_code"].Value) == 0)
                        {
                            st.Rollback();
                            return false;
                        }
                    }
                }
                catch
                {
                    st.Rollback();
                    return false;
                }
                st.Commit();
                return true;
            }
        }

        /// <summary>
        /// 获取移储数据
        /// </summary>
        /// <param name="moveLotID"></param>
        /// <param name="Lot"></param>
        /// <returns></returns>
        public DataSet GetMoveLotData(string moveLotID, string Lot)
        {
            DataSet ds = new DataSet();
            string sqlForSku = string.Format(@"SELECT billno,transferkey,storerkey,trdata.sku,OldLot,NewLot,
       (trdata.qty - NVL(diskinout.qty,0)) AS Count,company,0 AS scanFinish,0 AS ScanCount
  FROM (
        SELECT trdetail.transferkey AS billno,---
                trdetail.transferkey || '&' || trdetail.fromlot || '&' || trdetail.fromsku as billRowNo,
               trdetail.transferkey,
               trdetail.fromstorerkey AS storerkey,
               trdetail.fromsku AS sku,
               trdetail.fromlot AS OldLot,
               itrn.lot AS NewLot,
               SUM(trdetail.fromqty) AS qty,
               storer.company
          FROM wh10.transferdetail trdetail,wh10.itrn itrn,
               wh10.sku sku,wh10.storer storer
         WHERE trdetail.status = '9'
           AND (trdetail.transferkey || trdetail.transferlinenumber) = itrn.sourcekey
           AND itrn.sourcetype = 'ntrTransferDetailAdd'
           AND itrn.trantype = 'DP'
           AND trdetail.fromstorerkey = storer.storerkey
           AND trdetail.fromstorerkey = sku.storerkey
           AND trdetail.fromsku = sku.sku
           AND trdetail.transferkey = '{0}'
           AND trdetail.fromlot = '{1}'
         GROUP BY trdetail.transferkey,trdetail.fromstorerkey,trdetail.fromsku,trdetail.fromlot,itrn.lot,storer.company) trdata,
         (SELECT SUM(qty) AS qty,lot,sku
            FROM lm_disk_inout
           WHERE bs_key = '{0}'
             AND action_type = 5
           GROUP BY lot,sku) diskinout 
 WHERE trdata.old_lot = diskinout.lot(+)
   AND trdata.sku = diskinout.sku(+)
", moveLotID, Lot);
            string sqlForDisk = string.Format(@"SELECT '{0}' AS billno,'' AS billrowno,
       lmdisk.disk_id,lmdisk.storer,storer.company AS storer_desc,
       lmdisk.sku,lmdisk.sku_desc,
       lmdisk.left_qty,lmdisk.loc,
       lota.lot
  FROM lm_disk lmdisk,wh10.lotattribute lota,
       wh10.storer storer,
       wh10.sku sku,
       (SELECT lot,disk_id
          FROM lm_disk_inout
         WHERE bs_key = '{0}'
           AND action_type = 5
           AND lot = '{1}') diskinout
 WHERE lmdisk.storer = lota.storerkey
   AND lmdisk.sku = lota.sku
   AND lmdisk.lottable01 = lota.lottable01
   AND lmdisk.lottable02 = lota.lottable02
   AND lmdisk.lottable03 = lota.lottable03
   AND lmdisk.lottable04 = lota.lottable04
   AND lmdisk.lottable05 = lota.lottable05
   AND lmdisk.lottable06 = lota.lottable06
   AND lmdisk.lottable07 = lota.lottable07
   AND lmdisk.lottable08 = lota.lottable08
   AND lmdisk.lottable09 = lota.lottable09
   AND lmdisk.lottable10 = lota.lottable10
   AND lota.lot = diskinout.lot(+)
   AND NVL(diskinout.disk_id,'$') = '$'
   AND lmdisk.storer = storer.storerkey
   AND lmdisk.sku = sku.sku
   AND lmdisk.storer = sku.storerkey
   AND lota.lot = '{1}'
", moveLotID, Lot);

            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    conn.Open();
                    OracleCommand oc1 = new OracleCommand(sqlForSku, conn);
                    OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                    oda1.Fill(ds, "MoveLotBill");

                    OracleCommand oc2 = new OracleCommand(sqlForDisk, conn);
                    OracleDataAdapter oda2 = new OracleDataAdapter(oc2);
                    oda2.Fill(ds, "MoveLotDisk");
                    return ds;
                }
            }
            catch
            {
                return new DataSet();
            }
        }

        /// <summary>
        /// 更新料盘批次信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool SaveMoveLotData(DataTable dt, string userid)
        {
            StringBuilder sqlUpdate = new StringBuilder();
            StringBuilder sqlinsertIO = new StringBuilder();
            ArrayList al = new ArrayList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IsScaned"].ToString() == "1")
                    {
                        sqlUpdate.AppendFormat(@"UPDATE lm_disk
   SET lottable01 = (SELECT lottable01 FROM wh10.lotattribute WHERE lot = '{0}'),
       lottable02 = (SELECT lottable02 FROM wh10.lotattribute WHERE lot = '{0}'), 
       lottable03 = (SELECT lottable03 FROM wh10.lotattribute WHERE lot = '{0}'), 
       lottable04 = (SELECT lottable04 FROM wh10.lotattribute WHERE lot = '{0}'), 
       lottable05 = (SELECT lottable05 FROM wh10.lotattribute WHERE lot = '{0}'), 
       lottable06 = (SELECT lottable06 FROM wh10.lotattribute WHERE lot = '{0}'), 
       lottable07 = (SELECT lottable07 FROM wh10.lotattribute WHERE lot = '{0}'), 
       lottable08 = (SELECT lottable08 FROM wh10.lotattribute WHERE lot = '{0}'), 
       lottable09 = (SELECT lottable09 FROM wh10.lotattribute WHERE lot = '{0}'), 
       lottable10 = (SELECT lottable10 FROM wh10.lotattribute WHERE lot = '{0}')
 WHERE disk_id = '{1}'", dt.Rows[i]["lot"].ToString(), dt.Rows[i]["Disk_ID"].ToString());

                        sqlinsertIO.AppendFormat(@"insert into LM_DISK_INOUT(DISK_ID,BS_KEY,SKU,ACTION_TYPE,QTY,CREATED_BY,CREATED_DATE) 
select'{0}','{1}','{2}',1,{3},'{4}',sysdate from dual;", dt.Rows[i]["DISK_ID"].ToString(), dt.Rows[i]["billNo"].ToString(),
                            dt.Rows[i]["SKU"].ToString(), dt.Rows[i]["LEFT_QTY"].ToString(), userid);
                    }
                }
                AddBeginEnd(sqlUpdate);
                AddBeginEnd(sqlinsertIO);
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    OracleTransaction st;
                    conn.Open();
                    st = conn.BeginTransaction();
                    try
                    {
                        if (sqlUpdate.ToString().Length > 0)
                        {
                            OracleCommand oc = new OracleCommand(sqlUpdate.ToString(), conn);
                            oc.Transaction = st;
                            oc.ExecuteNonQuery();
                        }
                        if (sqlinsertIO.ToString().Length > 0)
                        {
                            OracleCommand oc1 = new OracleCommand(sqlinsertIO.ToString(), conn);
                            oc1.Transaction = st;
                            oc1.ExecuteNonQuery();
                        }
                        st.Commit();
                        return true;
                    }
                    catch
                    {
                        st.Rollback();
                        return false;
                    }
                    
                }
            }
            else
            {
                return false;
            }
        }
        

        /// <summary>
        /// 判断用户是否登陆成功并却返回可用模块代码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public DataSet GetUserRightList(string user, string pwd)
        {
            DataSet ds = new DataSet();
            string sql = "select * from P_USER where USER_Code='" + user + "' and PDA_PWD='" + pwd + "'";
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                conn.Open();
                OracleCommand oc1 = new OracleCommand(sql, conn);
                OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                oda1.Fill(ds, "user");
                if (ds.Tables["user"].Rows.Count > 0)
                {
                    string sqlforright = "select FUNCTION_CODE from P_PDA_PRIVILEGE pp join P_USER pu on pp.USER_CODE=pu.USER_CODE where pu.USER_Code='" + user + "'";
                    OracleCommand oc2 = new OracleCommand(sqlforright, conn);
                    OracleDataAdapter oda2 = new OracleDataAdapter(oc2);
                    oda2.Fill(ds, "right");
                }
                else
                {
                    return ds;
                }
            }
            return ds;
        }

        /// <summary>
        /// 获取拣货单信息及料盘信息
        /// </summary>
        /// <param name="PickKey"></param>
        /// <returns></returns>
        public DataSet GetPickData(string PickKey, string loc)
        {
            DataSet ds = new DataSet();

            string sqlForPick = string.Format(@"SELECT pick.externorderkey AS billno,
       pick.storerkey || '&' || pick.sku || '&' || pick.loc || '&' || pick.lot  as BillRowNo,
       pick.storerkey,
       pick.storerkey AS storer,
       pick.sku,
       pick.loc,
       pick.qty as Count,
       storer.company,
       sku.descr,
       NVL(scandisk.scanqty,0) as ScanCount,
       0 AS ScanFinish,
       (allscanfulldisk.allFullDiskCount - NVL(scanedfulldisk.ScanFullDiskCount,0)) AS CanPickFullDiskCount,
       NVL(scanedfulldisk.ScanFullDiskCount,0) AS  ScanFullDiskCount   
  FROM (SELECT orders.externorderkey,pick.storerkey,pick.sku,pick.loc,pick.lot,SUM(qty) AS qty
          FROM wh10.PICKDETAIL pick,wh10.orders orders
         WHERE pick.orderkey = orders.orderkey
           AND orders.externorderkey = '{0}'
           AND pick.loc = '{1}'
         GROUP BY orders.externorderkey,pick.storerkey,pick.sku,pick.loc,pick.lot) pick,
       (SELECT COUNT(inout.disk_id) ScanFullDiskCount,lmdisk.storer,lmdisk.sku,lmdisk.loc,orderlot.lot
          FROM lm_mn_ship_orders_lot orderlot,lm_mn_ship_orders ship,lm_disk_inout inout,lm_disk lmdisk,lm_mn_ship_orders_disk orderdisk
         WHERE orderlot.order_line_id = ship.order_line_id
           AND ship.order_no = inout.bs_key
           AND inout.action_type = 2
           AND inout.disk_id = lmdisk.disk_id
           AND ship.order_line_id = orderdisk.order_line_id
           AND inout.disk_id = orderdisk.disk_id
           AND orderdisk.out_option = 2
           AND ship.order_no = '{0}'
           AND lmdisk.loc = '{1}'
         GROUP BY lmdisk.storer,lmdisk.sku,lmdisk.loc,orderlot.lot) scanedfulldisk,
        (SELECT COUNT(orderdisk.disk_id),lmdisk.storer,lmdisk.sku,lmdisk.loc,orderlot.lot,orderlot.fulldisk_count AS allFullDiskCount
           FROM lm_mn_ship_orders ship,lm_mn_ship_orders_lot orderlot,lm_mn_ship_orders_disk orderdisk,lm_disk lmdisk
          WHERE ship.order_line_id = orderdisk.order_line_id
            AND ship.order_line_id = orderlot.order_line_id
            AND orderdisk.disk_id = lmdisk.disk_id
            AND orderdisk.out_option = 2
            AND ship.order_no = '{0}'
            AND lmdisk.loc = '{1}'
          GROUP BY lmdisk.storer,lmdisk.sku,lmdisk.loc,orderlot.lot,orderlot.fulldisk_count) allscanfulldisk,
        (SELECT inout.bs_key,ld.storer,ld.sku,ld.loc,lota.lot,
                SUM(CASE WHEN NVL(lock_qty,0) > 0 THEN lock_qty ELSE inout.qty END) AS scanqty
           FROM lm_disk ld,lm_disk_inout inout,wh10.orders orders,wh10.lotattribute lota
          WHERE ld.disk_id = inout.disk_id
            AND inout.action_type = 2
            AND inout.bs_key = orders.orderkey
            AND ld.storer = lota.storerkey
            AND ld.sku = lota.sku
            AND ld.lottable01 = lota.lottable01
            AND ld.lottable02 = lota.lottable02
            AND ld.lottable03 = lota.lottable03
            AND ld.lottable04 = lota.lottable04
            AND ld.lottable05 = lota.lottable05
            AND ld.lottable06 = lota.lottable06
            AND ld.lottable07 = lota.lottable07
            AND ld.lottable08 = lota.lottable08
            AND ld.lottable09 = lota.lottable09
            AND ld.lottable10 = lota.lottable10
            AND orders.externorderkey = '{0}'
            AND ld.loc = '{1}'
          GROUP BY inout.bs_key,ld.storer,ld.sku,ld.loc,lota.lot) scandisk,
         wh10.storer,wh10.sku
   WHERE pick.storerkey = storer.storerkey
     AND pick.storerkey = sku.storerkey
     AND pick.sku = sku.sku
     AND pick.storerkey = scandisk.storer(+)
     AND pick.sku = scandisk.sku(+)
     AND pick.lot = scandisk.lot(+)
     AND pick.loc = scandisk.loc(+)
     
     AND pick.storerkey = scanedfulldisk.storer(+)
     AND pick.sku = scanedfulldisk.sku(+)
     AND pick.lot = scanedfulldisk.lot(+)
     AND pick.loc = scanedfulldisk.loc(+)
     
     AND pick.storerkey = allscanfulldisk.storer(+)
     AND pick.sku = allscanfulldisk.sku(+)
     AND pick.lot = allscanfulldisk.lot(+)
     AND pick.loc = allscanfulldisk.loc(+)", PickKey, loc);

            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    conn.Open();
                    OracleCommand oc1 = new OracleCommand(sqlForPick, conn);
                    OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                    oda1.Fill(ds, "PickBill");
                    return ds;
                }
            }
            catch
            {
                return ds;
            }
        }

        /// <summary>
        /// 获取拣货时候当前库位中的料盘数据
        /// </summary>
        /// <param name="PickKey"></param>
        /// <param name="Loc"></param>
        /// <returns></returns>
        public DataTable GetPickDiskData(string PickKey, string Loc)
        {
            DataSet ds = new DataSet();
            string sqlForDisk = string.Format(@"SELECT ship.order_no as BillNo,
       '' as BillRowNo,
       ld.sku,
       pick.qty as Count,
       ld.disk_id,
       ld.storer as storerkey,
       ld.storer_desc as Company,
       ld.sku_desc as DESCR,
       ld.left_qty,
       ld.lot,
       ld.loc,
       ld.status,
       ld.lock_qty,
       0 as IsScaned,
       LOCK_BS_KEY,
       pick.OUT_OPTION,
       pick.QTY,
       pick.QTYALLOCATED,
       pick.OUT_OPTION 
  FROM LM_MN_SHIP_ORDERS_DISK pick, LM_DISK ld,LM_MN_SHIP_ORDERS ship,
       (SELECT inout.disk_id
          FROM lm_disk_inout inout,lm_disk lmdisk
         WHERE inout.disk_id = lmdisk.disk_id
           AND bs_key = '{0}'
           AND lmdisk.loc = '{1}'
           AND action_type = 2) scaneddisk
 WHERE pick.disk_id =ld.disk_id
   AND ld.LEFT_QTY > 0 and NVL(ld.LOCK_QTY,0) = 0
   AND pick.order_line_id = ship.order_line_id
   AND pick.disk_id = scaneddisk.disk_id(+)
   AND NVL(scaneddisk.disk_id,'$') = '$'
   And ld.loc = '{1}'
   AND ship.order_no = '{0}'", PickKey, Loc);

            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    conn.Open();
                    OracleCommand oc2 = new OracleCommand(sqlForDisk, conn);
                    OracleDataAdapter oda2 = new OracleDataAdapter(oc2);
                    oda2.Fill(ds, "PickDisk");
                    if (ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
            }
            catch
            {
                return new DataTable();
            }
        }


        /// <summary>
        /// 保存拣货信息及更新拣货单状态
        /// </summary>
        /// <param name="dtPick"></param>
        /// <param name="dtDisk"></param>
        /// <param name="finishedBill"></param>
        /// <returns></returns>
        public bool SavePickData(DataTable dtPick, DataTable dtDisk, string userid)
        {
            StringBuilder sqlInsertIO = new StringBuilder();
            StringBuilder sqlUpdateDisk = new StringBuilder();
            StringBuilder sqlUpdatePickBill = new StringBuilder();
            DataRow[] drs = dtDisk.Select("IsScaned = 1");
            ArrayList al = new ArrayList();

            if (drs.Length > 0)
            {
                //sqlInsertIO.Append("begin ");
                //sqlUpdateDisk.Append("begin ");
                foreach (DataRow dr in drs)
                {
                    if (!al.Contains(dr["billNo"].ToString()))
                    {
                        al.Add(dr["billNo"].ToString());
                    }
                    if (Convert.ToInt32(dr["LOCK_QTY"]) == 0)
                    {
                        sqlInsertIO.AppendFormat(@"insert into LM_DISK_INOUT(DISK_ID,BS_KEY,SKU,ACTION_TYPE,QTY,CREATED_BY,CREATED_DATE) 
select'{0}','{1}','{2}',2,{3},'{4}',sysdate from dual;", dr["DISK_ID"].ToString(), dr["billNo"].ToString(),
                        dr["SKU"].ToString(), dr["LEFT_QTY"].ToString(), userid);

                        sqlUpdateDisk.AppendFormat(@"update LM_DISK set LEFT_QTY=0 where DISK_ID='{0}';", dr["DISK_ID"].ToString());
                    }
                    else
                    {
                        sqlUpdateDisk.AppendFormat(@"update LM_DISK set STATUS=2,LOCK_QTY={0},LOCK_BS_KEY='{2}' where DISK_ID='{1}';", dr["LOCK_QTY"].ToString(), dr["DISK_ID"].ToString(), dr["billNo"].ToString());
                    }
                }
                //sqlInsertIO.Append(" end;");
                //sqlUpdateDisk.Append(" end;");

                AddBeginEnd(sqlInsertIO);
                AddBeginEnd(sqlUpdateDisk);
            }
            string idlist = string.Empty;
            if (al.Count > 0)
            {
                foreach (object o in al)
                {
                    idlist += "'" + o.ToString() + "',";
                }
                idlist = idlist.Substring(0, idlist.Length - 1);
            }

            string sqlforUpdateOrder = string.Format(@" 
 update wh10.orders
   set scan_status = 1
 where orderkey in
       (select orderkey
          from (select orderkey, sum(qty) as count
                  from wh10.PICKDETAIL p
                 where orderkey in ({0})
                                  group by orderkey) tempa
          join (select inout.bs_key, sum(inout.qty) as count
                 from lm_disk_inout inout                
                where bs_key in ({0})
                  and inout.action_type = 2
                group by bs_key) tempb on tempa.orderkey = tempb.bs_key
                                          and tempa.count = tempb.count)", idlist);

            string[] sqls = { sqlInsertIO.ToString(), sqlUpdateDisk.ToString(), sqlforUpdateOrder };
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                OracleTransaction st;
                conn.Open();
                st = conn.BeginTransaction();
                try
                {
                    foreach (string sql in sqls)
                    {
                        if (sql == string.Empty) { continue; }
                        OracleCommand scc = new OracleCommand(sql, conn);
                        scc.Transaction = st;
                        scc.ExecuteNonQuery();
                    }
                    st.Commit();
                    return true;

                }
                catch
                {
                    st.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 获得需分盘料盘数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetPartDiskData()
        {
            string sql = @"select ld.disk_id,ld.storer_desc as COMPANY,ld.SKU,ld.sku_desc as descr,ld.left_qty,ld.lot,ld.loc,ld.LOCK_QTY,'' as SubDiskId,0 as PartCount,0 AS IsScaned,LOCK_BS_KEY from lm_disk ld where ld.status=2
and ld.lock_qty>0";
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    conn.Open();
                    OracleCommand oc1 = new OracleCommand(sql, conn);
                    OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                    DataSet ds = new DataSet();
                    oda1.Fill(ds, "PartDisk");
                    return ds;
                }
            }
            catch
            {
                return new DataSet();
            }
        }

        /// <summary>
        /// 保存分盘数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool SavePartDiskData(DataTable dt, string userid)
        {
            StringBuilder sqlForParentDisk = new StringBuilder();
            StringBuilder sqlForSubDisk = new StringBuilder();
            StringBuilder sqlForIOParent = new StringBuilder();
            StringBuilder sqlForIOSub = new StringBuilder();
            ArrayList al = new ArrayList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!al.Contains(dt.Rows[i]["LOCK_BS_KEY"].ToString()))
                    {
                        al.Add(dt.Rows[i]["LOCK_BS_KEY"].ToString());
                    }
                    sqlForParentDisk.AppendFormat(@"update LM_DISK set STATUS=1,LOCK_QTY=0,LEFT_QTY=LEFT_QTY-{0},LOCK_BS_KEY='' where DISK_ID='{1}';",
                        dt.Rows[i]["PartCount"].ToString(), dt.Rows[i]["DISK_ID"].ToString());

                    sqlForSubDisk.AppendFormat(@"insert into LM_DISK (DISK_ID,PARENT_DISK_ID,STORER,STORER_DESC,SKU,SKU_DESC,TOTAL_QTY,LEFT_QTY,RECEIPTKEY,LOT,LOC,RECEIPT_DATE,MANUFACTURE_DATE,IQC_DATE,OPEN_DATE,ROAST_BEGIN_DATE,ROAST_END_DATE,STATUS,LOCK_QTY,CREATED_BY,CREATED_DATE,lottable01,lottable02,lottable03,lottable04,lottable05,lottable06,lottable07,lottable08,lottable09,lottable10) select '{0}' as DISK_ID,'{1}' as PARENT_DISK_ID,STORER,STORER_DESC,SKU,SKU_DESC,{2},0,RECEIPTKEY,LOT,LOC,RECEIPT_DATE,MANUFACTURE_DATE,IQC_DATE,OPEN_DATE,ROAST_BEGIN_DATE,ROAST_END_DATE,1,0,'{3}',sysdate as CREATED_DATE,lottable01,lottable02,lottable03,lottable04,lottable05,lottable06,lottable07,lottable08,lottable09,lottable10 from LM_DISK where DISK_ID='{1}';"
                        , dt.Rows[i]["SubDiskId"].ToString(), dt.Rows[i]["DISK_ID"].ToString(),
                                                                  dt.Rows[i]["PartCount"].ToString(), userid);

                    sqlForIOParent.AppendFormat(@"insert into LM_DISK_INOUT (DISK_ID,BS_KEY,SKU,ACTION_TYPE,QTY,CREATED_BY,CREATED_DATE) select '{0}' as DISK_ID,'{3}' as BS_KEY,SKU,4,{1},'{2}',sysdate from LM_DISK where DISK_ID='{0}';"
                        , dt.Rows[i]["DISK_ID"].ToString(), dt.Rows[i]["PartCount"].ToString(), userid, dt.Rows[i]["LOCK_BS_KEY"].ToString());

                    sqlForIOSub.AppendFormat(@"insert into LM_DISK_INOUT (DISK_ID,BS_KEY,SKU,ACTION_TYPE,QTY,CREATED_BY,CREATED_DATE) select '{0}' as DISK_ID,'{4}' as BS_KEY,SKU,2,{1},'{2}',sysdate from LM_DISK where DISK_ID='{3}';"
                        , dt.Rows[i]["SubDiskId"].ToString(), dt.Rows[i]["PartCount"].ToString(), userid, dt.Rows[i]["DISK_ID"].ToString(), dt.Rows[i]["LOCK_BS_KEY"].ToString());
                }

                AddBeginEnd(sqlForParentDisk);
                AddBeginEnd(sqlForSubDisk);
                AddBeginEnd(sqlForIOParent);
                AddBeginEnd(sqlForIOSub);
            }

            string idlist = string.Empty;
            if (al.Count > 0)
            {
                foreach (object o in al)
                {
                    idlist += "'" + o.ToString() + "',";
                }
                idlist = idlist.Substring(0, idlist.Length - 1);
            }

            string sqlforUpdateOrder = string.Format(@"update wh10.orders
   set scan_status = 1
 where orderkey in
       (select orderkey
          from (select orderkey, sum(qty) as count
                  from wh10.PICKDETAIL p
                 where orderkey in ({0})
                                  group by orderkey) tempa
          join (select inout.bs_key, sum(inout.qty) as count
                 from lm_disk_inout inout                
                where bs_key in ({0})
                  and inout.action_type = 2
                group by bs_key) tempb on tempa.orderkey = tempb.bs_key
                                          and tempa.count = tempb.count)", idlist);

            string[] sqls = { sqlForParentDisk.ToString(), sqlForSubDisk.ToString(), sqlForIOParent.ToString(), sqlForIOSub.ToString(), sqlforUpdateOrder };
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                OracleTransaction st;
                conn.Open();
                st = conn.BeginTransaction();
                try
                {
                    foreach (string sql in sqls)
                    {
                        OracleCommand scc = new OracleCommand(sql, conn);
                        scc.Transaction = st;
                        scc.ExecuteNonQuery();
                    }
                    st.Commit();
                    return true;
                }
                catch
                {
                    st.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取退料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet GetFeedBackData(string id)
        {
            string sql = @"select DISK_ID,RETURN_KEY as BillNo,QTY as left_qty,DESCR,LM_DISK_PRO_RETURN.SKU,0 as isScaned from LM_DISK_PRO_RETURN left join SKU on LM_DISK_PRO_RETURN.SKU=SKU.SKU where STATUS=1 and RETURN_KEY='" + id + "'";
            try
            {
                using (OracleConnection conn = new OracleConnection(ConnString))
                {
                    conn.Open();
                    OracleCommand oc1 = new OracleCommand(sql, conn);
                    OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                    DataSet ds = new DataSet();
                    oda1.Fill(ds, "FeedBackDisk");
                    return ds;
                }
            }
            catch
            {
                return new DataSet();
            }
        }

        /// <summary>
        /// 保存退料清点数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool SaveFeedBackData(DataTable dt)
        {
            StringBuilder sql = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IsScaned"].ToString() == "1")
                    {
                        sql.AppendFormat(@"update LM_DISK_PRO_RETURN set STATUS=2 where DISK_ID='{0}' and RETURN_KEY='{1}';",
                            dt.Rows[i]["DISK_ID"].ToString(), dt.Rows[i]["BillNo"].ToString());
                    }
                }

                AddBeginEnd(sql);
            }
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                OracleTransaction st;
                conn.Open();
                st = conn.BeginTransaction();
                try
                {
                    OracleCommand scc = new OracleCommand(sql.ToString(), conn);
                    scc.Transaction = st;
                    scc.ExecuteNonQuery();
                    st.Commit();
                    return true;
                }
                catch
                {
                    st.Rollback();
                    return false;
                }
            }
        }

        private static void AddBeginEnd(StringBuilder sql)
        {
            if (sql.ToString().Trim().Length > 0)
            {
                sql.Insert(0, "begin ");
                sql.Append(" end;");
            }
        }

        /// <summary>
        /// 获取开封料盘信息及更新料盘开封信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAndUpdateDiskForOpen(string id, string userid)
        {
            string sqlForSelect = @"select STORER_DESC,SKU,LEFT_QTY from LM_DISK where DISK_ID='" + id + "'";
            DataSet ds = new DataSet();
            using (OracleConnection conn = new OracleConnection(ConnString))
            {

                OracleCommand oc1 = new OracleCommand(sqlForSelect, conn);
                OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                oda1.Fill(ds, "Disk");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //string sqlForInsert = string.Format(@"insert into LM_DISK_OPEN (DISK_ID,OPEN_DATE,CREATED_BY,CREATED_DATE) values ('{0}',sysdate,'{1}',sysdate)", id, userid);
                    string sqlForInsert = string.Format(@"begin update LM_DISK_OPEN set OPEN_DATE=sysdate where DISK_ID='{0}';if sql%rowcount = 0 then insert into LM_DISK_OPEN (DISK_ID,OPEN_DATE,CREATED_BY,CREATED_DATE) values ('{0}',sysdate,'{1}',sysdate);end if; end;", id, userid);
                    string sqlForUpdate = string.Format(@"update LM_DISK set OPEN_DATE=sysdate where DISK_ID='{0}'", id);

                    OracleTransaction st;
                    conn.Open();
                    st = conn.BeginTransaction();
                    try
                    {
                        OracleCommand oc2 = new OracleCommand(sqlForInsert, conn);
                        oc2.Transaction = st;
                        oc2.ExecuteNonQuery();

                        OracleCommand oc3 = new OracleCommand(sqlForUpdate, conn);
                        oc3.Transaction = st;
                        oc3.ExecuteNonQuery();

                        st.Commit();
                        return "料盘：" + id + "\r\n物料：" + ds.Tables[0].Rows[0]["SKU"].ToString() + "\r\n供应商：" + ds.Tables[0].Rows[0]["STORER_DESC"].ToString() + "\r\n数量：" + ds.Tables[0].Rows[0]["LEFT_QTY"].ToString() + "\r\n料盘开封时间：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    catch
                    {
                        st.Rollback();
                        return "料盘开封信息更新失败！";
                    }
                }
                else
                {
                    return "料盘在数据库中不存在，或此料盘已作开封操作！";
                }
            }
        }

        /// <summary>
        /// 获取料盘信息更新料盘开始烘烤时间
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetAndSaveDiskForBegin(string id, string userid,string ScanType)
        {
            string sqlForSelectDisk = @"select STORER_DESC,SKU,LEFT_QTY from LM_DISK where DISK_ID='" + id + "'";
            DataSet ds = new DataSet();
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                OracleCommand oc1 = new OracleCommand(sqlForSelectDisk, conn);
                OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                oda1.Fill(ds, "Disk");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ScanType.ToUpper() == "BAKE")
                    {
                        string sqlForSelectOpenRecord = "select ROAST_BEGIN_DATE,ROAST_END_DATE from LM_DISK where DISK_ID='" + id + "' and (ROAST_BEGIN_DATE>ROAST_END_DATE or (ROAST_BEGIN_DATE is not null and ROAST_END_DATE is null))";
                        OracleCommand oc2 = new OracleCommand(sqlForSelectOpenRecord, conn);
                        OracleDataAdapter oda2 = new OracleDataAdapter(oc2);
                        oda2.Fill(ds, "Roast");
                        if (ds.Tables["Roast"].Rows.Count > 0)
                        {
                            return "上次烘烤未结束！\r\n上次烘烤开始时间：" + ds.Tables["Roast"].Rows[0]["ROAST_BEGIN_DATE"].ToString();
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("begin ");
                            //sb.AppendFormat(@"insert into LM_DISK_ROAST (DISK_ID,ROAST_BEGIN_DATE,CREATED_BY,CREATED_DATE) values ('{0}',sysdate,'{1}',sysdate);", id, userid);
                            sb.AppendFormat(@"begin update LM_DISK_ROAST set ROAST_BEGIN_DATE=sysdate where DISK_ID='{0}' and ACTION_TYPE=2;if sql%rowcount = 0 then insert into LM_DISK_ROAST (DISK_ID,ROAST_BEGIN_DATE,CREATED_BY,CREATED_DATE,ACTION_TYPE) values ('{0}',sysdate,'{1}',sysdate,2);end if; end;", id, userid);
                            sb.AppendFormat(@"update LM_DISK set ROAST_BEGIN_DATE=sysdate where DISK_ID='{0}';", id);
                            sb.Append(" end;");
                            conn.Open();
                            OracleTransaction st;
                            st = conn.BeginTransaction();
                            try
                            {
                                OracleCommand oc3 = new OracleCommand(sb.ToString(), conn);
                                oc3.Transaction = st;
                                oc3.ExecuteNonQuery();

                                st.Commit();
                                return "料盘：" + id + "\r\n物料：" + ds.Tables["Disk"].Rows[0]["SKU"].ToString() + "\r\n供应商：" + ds.Tables["Disk"].Rows[0]["STORER_DESC"].ToString() + "\r\n数量：" + ds.Tables["Disk"].Rows[0]["LEFT_QTY"].ToString() + "\r\n开始烘烤时间：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            catch
                            {
                                st.Rollback();
                                return "更新料盘开始烘烤时间失败！";
                            }
                        }
                    }
                    else
                    {
                        string sqlForSelectOpenRecord = "select DRY_BEGIN_DATE,DRY_END_DATE from LM_DISK where DISK_ID='" + id + "' and (DRY_BEGIN_DATE>DRY_END_DATE or (DRY_BEGIN_DATE is not null and DRY_END_DATE is null))";
                        OracleCommand oc2 = new OracleCommand(sqlForSelectOpenRecord, conn);
                        OracleDataAdapter oda2 = new OracleDataAdapter(oc2);
                        oda2.Fill(ds, "Dry");
                        if (ds.Tables["Dry"].Rows.Count > 0)
                        {
                            return "上次干燥未结束！\r\n上次干燥开始时间：" + ds.Tables["Dry"].Rows[0]["DRY_BEGIN_DATE"].ToString();
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("begin ");
                            //sb.AppendFormat(@"insert into LM_DISK_ROAST (DISK_ID,ROAST_BEGIN_DATE,CREATED_BY,CREATED_DATE) values ('{0}',sysdate,'{1}',sysdate);", id, userid);
                            sb.AppendFormat(@"begin update LM_DISK_ROAST set ROAST_BEGIN_DATE=sysdate where DISK_ID='{0}' and ACTION_TYPE=1;if sql%rowcount = 0 then insert into LM_DISK_ROAST (DISK_ID,ROAST_BEGIN_DATE,CREATED_BY,CREATED_DATE,ACTION_TYPE) values ('{0}',sysdate,'{1}',sysdate,1);end if; end;", id, userid);
                            sb.AppendFormat(@"update LM_DISK set DRY_BEGIN_DATE=sysdate where DISK_ID='{0}';", id);
                            sb.Append(" end;");
                            conn.Open();
                            OracleTransaction st;
                            st = conn.BeginTransaction();
                            try
                            {
                                OracleCommand oc3 = new OracleCommand(sb.ToString(), conn);
                                oc3.Transaction = st;
                                oc3.ExecuteNonQuery();

                                st.Commit();
                                return "料盘：" + id + "\r\n物料：" + ds.Tables["Disk"].Rows[0]["SKU"].ToString() + "\r\n供应商：" + ds.Tables["Disk"].Rows[0]["STORER_DESC"].ToString() + "\r\n数量：" + ds.Tables["Disk"].Rows[0]["LEFT_QTY"].ToString() + "\r\n开始干燥时间：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            catch
                            {
                                st.Rollback();
                                return "更新料盘开始干燥时间失败！";
                            }
                        }
                    }
                }
                else
                {
                    return "料盘在数据库中不存在！";
                }
            }
        }

        /// <summary>
        /// 获取料盘信息更新料盘结束烘烤时间
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetAndSaveDiskForEnd(string id, string userid,string ScanType)
        {
            string sqlForSelectDisk = @"select STORER_DESC,SKU,LEFT_QTY from LM_DISK where DISK_ID='" + id + "'";
            DataSet ds = new DataSet();
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                OracleCommand oc1 = new OracleCommand(sqlForSelectDisk, conn);
                OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                oda1.Fill(ds, "Disk");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ScanType.ToUpper() == "BAKE")
                    {
                        string sqlForSelectOpenRecord = "select ROAST_BEGIN_DATE from LM_DISK where DISK_ID='" + id + "' and (ROAST_BEGIN_DATE>ROAST_END_DATE or ROAST_END_DATE is null) and ROAST_BEGIN_DATE is not null";
                        OracleCommand oc2 = new OracleCommand(sqlForSelectOpenRecord, conn);
                        OracleDataAdapter oda2 = new OracleDataAdapter(oc2);
                        oda2.Fill(ds, "Roast");
                        if (ds.Tables["Roast"].Rows.Count == 0)
                        {
                            return "此料盘尚未开始烘烤,或烘烤已结束！";
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("begin ");
                            sb.AppendFormat(@"update LM_DISK_ROAST set ROAST_END_DATE=sysdate where DISK_ID='{0}' and ACTION_TYPE=2;", id);
                            sb.AppendFormat(@"update LM_DISK set ROAST_END_DATE=sysdate where DISK_ID='{0}';", id);
                            sb.Append(" end;");
                            conn.Open();
                            OracleTransaction st;
                            st = conn.BeginTransaction();
                            try
                            {
                                OracleCommand oc3 = new OracleCommand(sb.ToString(), conn);
                                oc3.Transaction = st;
                                oc3.ExecuteNonQuery();
                                st.Commit();
                                return "料盘：" + id + "\r\n物料：" + ds.Tables["Disk"].Rows[0]["SKU"].ToString() + "\r\n供应商：" + ds.Tables["Disk"].Rows[0]["STORER_DESC"].ToString() + "\r\n数量：" + ds.Tables["Disk"].Rows[0]["LEFT_QTY"].ToString() + "\r\n烘烤结束时间：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            catch
                            {
                                st.Rollback();
                                return "更新料盘结束烘烤时间失败！";
                            }
                        }
                    }
                    else
                    {
                        string sqlForSelectOpenRecord = "select DRY_BEGIN_DATE from LM_DISK where DISK_ID='" + id + "' and (DRY_BEGIN_DATE>DRY_END_DATE or DRY_END_DATE is null) and DRY_BEGIN_DATE is not null";
                        OracleCommand oc2 = new OracleCommand(sqlForSelectOpenRecord, conn);
                        OracleDataAdapter oda2 = new OracleDataAdapter(oc2);
                        oda2.Fill(ds, "Dry");
                        if (ds.Tables["Dry"].Rows.Count == 0)
                        {
                            return "此料盘尚未开始干燥,或干燥已结束！";
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("begin ");
                            sb.AppendFormat(@"update LM_DISK_ROAST set ROAST_END_DATE=sysdate where DISK_ID='{0}' and ACTION_TYPE=1;", id);
                            sb.AppendFormat(@"update LM_DISK set DRY_END_DATE=sysdate where DISK_ID='{0}';", id);
                            sb.Append(" end;");
                            conn.Open();
                            OracleTransaction st;
                            st = conn.BeginTransaction();
                            try
                            {
                                OracleCommand oc3 = new OracleCommand(sb.ToString(), conn);
                                oc3.Transaction = st;
                                oc3.ExecuteNonQuery();
                                st.Commit();
                                return "料盘：" + id + "\r\n物料：" + ds.Tables["Disk"].Rows[0]["SKU"].ToString() + "\r\n供应商：" + ds.Tables["Disk"].Rows[0]["STORER_DESC"].ToString() + "\r\n数量：" + ds.Tables["Disk"].Rows[0]["LEFT_QTY"].ToString() + "\r\n干燥结束时间：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            catch
                            {
                                st.Rollback();
                                return "更新料盘结束干燥时间失败！";
                            }
                        }
                    }
                }
                else
                {
                    return "料盘在数据库中不存在！";
                }
            }
        }

        public DataSet GetCompany()
        {
            string sql = "select * from STORER";
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                conn.Open();
                OracleCommand oc1 = new OracleCommand(sql, conn);
                OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                DataSet ds = new DataSet();
                oda1.Fill(ds, "Company");
                return ds;
            }
        }

        public DataSet GetDiskList(string diskid, string sku, DateTime timein, string asn)
        {
            string sql = "select DISK_ID,RECEIPTKEY,STORER_DESC,SKU,TOTAL_QTY,LEFT_QTY,LOT,LOC from lm_disk where 1=1";
            if (asn != string.Empty)
            {
                sql += " and RECEIPTKEY='" + asn + "'";
            }
            if (diskid != string.Empty)
            {
                sql += " and disk_id='" + diskid + "'";
            }
            if (sku != string.Empty)
            {
                sql += " and sku='" + sku + "'";
            }
            //sql += " and RECEIPT_DATE>=to_date('" + timein.ToString("yyyy-MM-dd") + "','yyyy-MM-dd')";
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                conn.Open();
                OracleCommand oc1 = new OracleCommand(sql, conn);
                OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                DataSet ds = new DataSet();
                oda1.Fill(ds, "DiskList");
                return ds;
            }
        }
        /// <summary>
        /// 获取库位对应的物料信息
        /// </summary>
        /// <param name="loc">库位号</param>
        /// <returns></returns>
        public DataSet GetMoveLocData(string loc)
        {
            string sql = "select DISK_ID,RECEIPTKEY,STORER_DESC as STORERKEY,STORER,SKU,TOTAL_QTY,LEFT_QTY,LOT,LOC,0 AS IsScaned,'' as NEW_LOc from lm_disk where LOC = '" + loc + "'";

            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                conn.Open();
                OracleCommand oc1 = new OracleCommand(sql, conn);
                OracleDataAdapter oda1 = new OracleDataAdapter(oc1);
                DataSet ds = new DataSet();
                oda1.Fill(ds, "DiskList");
                return ds;
            }
        }
        /// <summary>
        /// 移库：保存物料库位信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool SaveMoveLoc(DataTable dt,string userid)
        {
            StringBuilder sql = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IsScaned"].ToString() == "1")
                    {
                        sql.AppendFormat(@"update LM_DISK set LOC='{1}' where DISK_ID='{0}';",
                            dt.Rows[i]["DISK_ID"].ToString(), dt.Rows[i]["NEW_LOC"].ToString());
                    }
                }

                AddBeginEnd(sql);
                if (sql.ToString().Trim() == string.Empty) { return true; }
            }
            using (OracleConnection conn = new OracleConnection(ConnString))
            {
                OracleTransaction st;
                conn.Open();
                st = conn.BeginTransaction();

                try
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j]["IsScaned"].ToString() == "0") { continue; }
                        OracleCommand scc = new OracleCommand("WH10.INV_MOVEMENT_PROCESS", conn, st);
                        scc.CommandType = CommandType.StoredProcedure;
                        OracleParameterCollection pc = scc.Parameters;
                        pc.Add(new OracleParameter("FROMSTORERKEY", dt.Rows[j]["STORER"].ToString()));
                        pc.Add(new OracleParameter("FROMSKU", dt.Rows[j]["SKU"].ToString()));
                        pc.Add(new OracleParameter("FROMLOT", dt.Rows[j]["LOT"].ToString()));
                        pc.Add(new OracleParameter("FROMLOC", dt.Rows[j]["LOC"].ToString()));
                        pc.Add(new OracleParameter("FROMID", " "));
                        pc.Add(new OracleParameter("QTY", Convert.ToInt32(dt.Rows[j]["LEFT_QTY"])));
                        pc.Add(new OracleParameter("TOLOC", dt.Rows[j]["NEW_LOC"].ToString()));
                        pc.Add(new OracleParameter("TOID", " "));
                        pc.Add(new OracleParameter("USERCODE", userid));
                        pc.Add(new OracleParameter("result_code", OracleType.Number));
                        pc["result_code"].Direction = ParameterDirection.Output;
                        scc.ExecuteNonQuery();
                        if (Convert.ToInt32(scc.Parameters["result_code"].Value) == 0)
                        {
                            st.Rollback();
                            return false;
                        }
                    }
                }
                catch
                {
                    st.Rollback();
                    return false;
                }

                try
                {
                    OracleCommand scc = new OracleCommand(sql.ToString(), conn);
                    scc.Transaction = st;
                    scc.ExecuteNonQuery();
                    st.Commit();
                    return true;
                }
                catch
                {
                    st.Rollback();
                    return false;
                }
            }
        }
    }
}
