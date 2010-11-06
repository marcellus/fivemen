using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using PDA.DataInit;

namespace PDA
{
    class CheckDetailRecord
    {
        #region 私有属性
        private string sn;
        private string xxjh;
        private string tph;
        private string kw;
        private string scaner;
        private DateTime scantime;
        #endregion

        #region 公共属性
        public string Sn
        {
            get
            {
                return sn;
            }
            set
            {
                sn = value;
            }
        }

        public string Xxjh
        {
            get
            {
                return xxjh;
            }
            set
            {
                xxjh = value;
            }
        }

        public string Tph
        {
            get
            {
                return tph;
            }
            set
            {
                tph = value;
            }
        }

        public string Kw
        {
            get
            {
                return kw;
            }
            set
            {
                kw = value;
            }
        }

        public string Scaner
        {
            get
            {
                return scaner;
            }
            set
            {
                scaner = value;
            }
        }

        public DateTime Scantime
        {
            get
            {
                return scantime;
            }
            set
            {
                scantime = value;
            }
        }
        #endregion

        public string SaveCheckData(CheckMain ck,CheckDetailRecord cdr,string ScanType,string RollBack)
        { 
            //string sqlInsert=string.Format(@"insert into ")
            try
            {
                if (RollBack == string.Empty)
                {
                    string selectForExist = string.Empty;
                    if (ScanType == "SN")
                    {
                        selectForExist = "select * from pandiandetail where sn='" + this.sn + "'";
                    }
                    else
                    {
                        selectForExist = "select * from pandiandetail where tph='" + this.tph + "'";
                    }
                    DataTable dtExist = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(selectForExist);
                    if (dtExist.Rows.Count > 0)
                    {
                        return "扫描纪录已存在，请不要重复扫描！";
                    }
                    else
                    {
                        if (ScanType == "SN")
                        {
                            string[] sql = new string[2];

                            string sqlInsertDetail = string.Format(@"insert into pandiandetail(sn,xxjh,tph,scaner,scantime,kuwei) values ('{0}','{1}','{2}','{3}',
'{4}','{5}')", cdr.Sn, cdr.Xxjh, cdr.Tph, cdr.Scaner, cdr.Scantime, cdr.Kw);
                            sql[0] = sqlInsertDetail;

                            string sqlForSelectMain = "select * from pandianrecord where pnno='" + ck.Pnno + "'";
                            DataTable dtMain = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sqlForSelectMain);
                            if (dtMain.Rows.Count == 0)
                            {
                                string sqlInsertMain = string.Format(@"insert into pandianrecord (kw,pnno,cpqufen,sl,status) values ('{0}','{1}','{2}',{3},{4})",
                                    ck.Kw, ck.Pnno, ck.Cpqufen, ck.Sl, ck.Status);
                                sql[1] = sqlInsertMain;
                            }
                            else
                            {
                                string sqlUpdateMain = string.Format(@"update pandianrecord set sl=sl+{0} where pnno='{1}'", ck.Sl, ck.Pnno);
                            }
                            SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql);
                        }
                        else
                        {
                            string sqlInsertDetail = string.Format(@"insert into pandiandetail(sn,xxjh,tph,scaner,scantime,kuwei) values ('{0}','{1}','{2}','{3}',
'{4}','{5}')", cdr.Sn, cdr.Xxjh, cdr.Tph, cdr.Scaner, cdr.Scantime, cdr.Kw);
                            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sqlInsertDetail);
                        }
                    }
                    return string.Empty;
                }
                else
                {
                    string[] sql = new string[2];
                    string selectForExist = string.Empty;
                    if (ScanType == "SN")
                    {
                        selectForExist = "select * from pandiandetail where sn='" + this.sn + "'";
                    }
                    else
                    {
                        selectForExist = "select * from pandiandetail where tph='" + this.tph + "'";
                    }
                    DataTable dtExist = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(selectForExist);
                    if (dtExist.Rows.Count == 0)
                    {
                        return "此纪录尚未扫描，不能撤销扫描！";
                    }
                    else
                    {
                        string sqlForDelete = string.Empty;
                        if (ScanType == "SN")
                        {
                            sqlForDelete = string.Format(@"delete from pandiandetail where sn='{0}'", cdr.Sn);
                            string sqlMainRollBack = string.Format(@"update pandianrecord set sl=sl-{0} where pnno='{1}'", ck.Sl, ck.Pnno);
                            sql[0] = sqlForDelete;
                            sql[1] = sqlMainRollBack;
                            SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql);
                        }
                        else
                        {
                            sqlForDelete = string.Format(@"delete from pandiandetail where tph='{0}'", cdr.Tph);
                            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sqlForDelete);
                        }
                        return "撤销扫描成功！";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
