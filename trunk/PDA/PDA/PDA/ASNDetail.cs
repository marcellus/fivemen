using System;

using System.Collections.Generic;
using System.Text;
using PDA.DataInit;
using System.Data;

namespace PDA
{
    class ASNDetail
    {
        #region 私有属性
        private string pnno;
        private string tno;
        private int hold;
        private string xxjh;
        private string cuno;
        private string scanner;
        private DateTime scantime;
        private int status;
        private string receiveno;
        #endregion

        #region 公共属性
        public string Pnno
        {
            get
            {
                return pnno;
            }
            set
            {
                pnno = value;
            }
        }

        public string Tno
        {
            get
            {
                return tno;
            }
            set
            {
                tno = value;
            }
        }

        public int Hold
        {
            get
            {
                return hold;
            }
            set
            {
                hold = value;
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

        public string Cuno
        {
            get
            {
                return cuno;
            }
            set
            {
                cuno = value;
            }
        }

        public string Scanner
        {
            get
            {
                return scanner;
            }
            set
            {
                scanner = value;
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

        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public string Receiveno
        {
            get
            {
                return receiveno;
            }
            set
            {
                receiveno = value;
            }
        }
        #endregion

        public string SaveAsnDetail(string RollBack,string scanType,ASNMain asnmain,ASNDetail asndetail)
        {
            
            if (RollBack == string.Empty)
            {
                try
                {
                    string sqlForExist = "select * from receivedetail where cuno='" + asndetail.cuno + "'";
                    DataTable dtExist = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sqlForExist);
                    if (dtExist.Rows.Count > 0)
                    {
                        return "此产品已存在，请不要重复扫描！";
                    }
                    else
                    {
                        if (scanType == "SN")
                        {
                            string[] sql = new string[2];
                            string sqlForSelectMain = string.Format(@"select * from receiverecord where pnno='{0}'", this.pnno);
                            DataTable dtMain = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sqlForSelectMain);
                            string sqlInsertDetail = string.Format(@"insert into receivedetail (pnno,tno,hold,xxjh,cuno,scanner,scantime,status) values ('{0}','{1}','{2}',
'{3}','{4}','{5}',{6})", asndetail.pnno, asndetail.tno, asndetail.hold, asndetail.xxjh, asndetail.cuno, asndetail.scanner, asndetail.scantime,
                       asndetail.status);
                            sql[1] = sqlInsertDetail;
                            if (dtMain.Rows.Count == 0)
                            {
                                string sqlInsertMain = string.Format(@"insert into receiverecord (receiveno,factory,factoryid,storage,storageid,carno,receivetype,qufen,pnno,
tno,hold,sl,scaner,scantime,status) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}',{14})",
                    asnmain.Receiveno, asnmain.Factory, asnmain.Factoryid, asnmain.Storage, asnmain.Storageid, asnmain.Carno, asnmain.Receivetype,
                    asnmain.Qufen, asnmain.Pnno, asnmain.Tno, asnmain.Hold, asnmain.Sl, asnmain.Scanner, asnmain.Scantime, asnmain.Status);
                                sql[0] = sqlInsertMain;
                            }
                            else
                            {
                                string sqlUpdateMain = string.Format(@"update receiverecord set sl=sl+{0} where pnno='{1}'", asnmain.Sl, asnmain.Pnno);
                                sql[0] = sqlUpdateMain;
                            }
                            SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql);
                        }
                        else
                        {
                            string sqlInsertDetail = string.Format(@"insert into receivedetail (pnno,tno,hold,xxjh,cuno,scanner,scantime,status) values ('{0}','{1}','{2}',
'{3}','{4}','{5}',{6})", asndetail.pnno, asndetail.tno, asndetail.hold, asndetail.xxjh, asndetail.cuno, asndetail.scanner, asndetail.scantime,
                       asndetail.status);
                            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sqlInsertDetail);
                        }
                       
                    }
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                string sqlForSelect = string.Empty;
                string sqlForDelete = string.Empty;
                if (scanType == "SN")
                {
                    sqlForSelect = string.Format(@"select * from receivedetail where cuno='{0}'", asndetail.cuno);
                    DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sqlForSelect);
                    if (dt.Rows.Count == 0)
                    {
                        return "产品尚未扫描，不能撤销！";
                    }
                    else
                    {
                        if (scanType == "SN")
                        {
                            string[] sql = new string[2];
                            sqlForDelete = string.Format("delete from receivedetail where cuno='{0}'", asndetail.cuno);
                            string sqlForUpdateMain = string.Format(@"update receiverecord set sl=sl-{0} where pnno='{1}'", asnmain.Sl, asnmain.Pnno);
                            sql[0] = sqlForDelete;
                            sql[1] = sqlForUpdateMain;
                            SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql);
                            //sdo.ExecuteNonQuery(sqlForDelete);
                        }
                        else
                        {
                            sqlForDelete = string.Format("delete from receivedetail where cuno='{0}'", asndetail.cuno);
                            SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sqlForDelete);
                        }
                        return "产品撤销扫描成功！";
                    }
                }
                else
                {
                    sqlForSelect = string.Format(@"select * from receivedetail where tno='{0}'");
                    DataTable dt = SqliteDbFactory.GetSqliteDbOperator().SelectFromSql(sqlForSelect);
                    if (dt.Rows.Count == 0)
                    {
                        return "托盘尚未扫描，不能撤销！";
                    }
                    else
                    {
                        sqlForDelete = string.Format("delete from receivedetail where tno='{0}'", asndetail.cuno);
                        SqliteDbFactory.GetSqliteDbOperator().ExecuteNonQuery(sqlForDelete);
                        return "托盘撤销扫描成功！";
                    }
                }
            }

        }
    }
}
