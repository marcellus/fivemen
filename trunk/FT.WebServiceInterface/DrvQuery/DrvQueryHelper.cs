using System;
using System.Data;
using System.Configuration;
using FT.DAL.Oracle;
using FT.DAL;
using log4net;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data.Common;
using System.Data.OracleClient;
using FT.WebServiceInterface.WebService;

namespace FT.WebServiceInterface.DrvQuery
{

    /// <summary>
    ///DrvQueryHelper 的摘要说明
    /// </summary>
    public class DrvQueryHelper
    {
        protected static ILog log = log4net.LogManager.GetLogger("DrvQueryHelper");
        public DrvQueryHelper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public static void TestSql(string connConfig,int id1,int id2,int id3)
        {
           // string queryStr = "select distinct '' \"jxmc\",b.jxmc \"jxdm\", 'A' \"idCardType\", a.sfzmhm \"idCard\",a.xm \"name\",b.zkcx \"zkcx\",a.lsh \"lsh\",to_char(b.yxqs,'yyyy-MM-dd') \"yxqs\",to_char(b.yxqz,'yyyy-MM-dd') \"yxqz\",b.jly \"jly\" from trff_app.drv_flow a left join trff_app.drv_examcard b on a.sfzmhm=b.sfzmhm where a.ywlx in ('A','B') and a.sfzmhm='440583199005011018'";

           /* 
           String sql = "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from fzkyy.st_drv_preasign a where kskm=1 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
                        sql += " union ";
                        sql += "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from fzkyy.st_drv_preasign a where kskm=2 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
                        sql += " union ";
                        sql += "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from fzkyy.st_drv_preasign a where kskm=3 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
                        String queryStr = string.Format(sql, new string[] { "4405", "440583199005011018" });
            * */

            string sql = "select distinct decode(xb,1,'男',2,'女') sex,lxdh phone,lxdh mobile,lxzsxxdz address,to_char(csrq,'yyyy-MM-dd') csrq  from fzkyy.st_person a where a.sfzmhm='{1}'";
            string queryStr = string.Format(sql, new string[] { "4405", "440583199005011018" });
             

            // IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            string tmp = System.Configuration.ConfigurationManager.AppSettings[connConfig];
            // log.Debug("DefaultConnString is:" + tmp);
            string connStr = FT.Commons.Security.SecurityFactory.GetSecurity().Decrypt(tmp);

            string sql2 = "update table_yuyue_info set c_check_result='" + FT.DAL.DALSecurityTool.TransferInsertField(connStr) + "' where id= "+id1.ToString();
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql2);
            DbConnection conn = new OracleConnection(connStr);
            DataTable dt = new DataTable("tmp");
            try
            {
                /*
                try
                {
                    conn.Open();
                    conn.Close();
                    string sql3 = "update table_yuyue_info set c_check_result='测试数据库打开链接成功！' where id="+id2.ToString();
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql3);
                }
                catch (System.Exception e)
                {
                    string sql7 = "update table_yuyue_info set c_check_result='" + e.ToString() + "' where id= "+id2.ToString();
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql7);
                }
                */

                DbDataAdapter oradp = new OracleDataAdapter();
                DbCommand command = conn.CreateCommand();
                command.CommandText = queryStr;
                //command.CommandText = sql.Replace("\r\n","");
                oradp.SelectCommand = command;
                oradp.Fill(dt);
                string sql5 = "update table_yuyue_info set c_check_result='查询完毕"+FT.DAL.DALSecurityTool.TransferInsertField(queryStr)+"记录数：" + dt.Rows.Count.ToString() + "' where id="+id3.ToString();
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql5);
            }
            catch (Exception e)
            {
                string sql8 = "update table_yuyue_info set c_check_result='" + e.ToString() + "' where id= " + id3.ToString();
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql8);
                //log.Error(e);
                // return null;
            }
        }
        public static void TestSql()
        {
            TestSql("DefaultConnString3", 1004, 1005, 1006);
            // TestSql("DefaultConnString4", 998, 999, 1000);
            TestSql("DefaultConnString4", 1007, 1008, 1009);
            string queryStr = "select distinct '' \"jxmc\",b.jxmc \"jxdm\", 'A' \"idCardType\", a.sfzmhm \"idCard\",'' \"name\",b.zkcx \"zkcx\",a.lsh \"lsh\",to_char(b.yxqs,'yyyy-MM-dd') \"yxqs\",to_char(b.yxqz,'yyyy-MM-dd') \"yxqz\",b.jly \"jly\" from fzkyy.st_drv_flow a left join fzkyy.st_drv_examcard b on a.sfzmhm=b.sfzmhm where a.ywlx in ('A','B') and a.sfzmhm='440583199005011018'";
           // string queryStr = "select 1 from dual";
/*
            String sql = "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from trff_app.drv_preasign a where kskm=1 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            sql += " union ";
            sql += "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from trff_app.drv_preasign a where kskm=2 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            sql += " union ";
            sql += "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from trff_app.drv_preasign a where kskm=3 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            String queryStr = string.Format(sql, new string[] { "4405", "440583199005011018" });
 * */

           // IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            string tmp = System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"];
           // log.Debug("DefaultConnString is:" + tmp);
            string connStr = FT.Commons.Security.SecurityFactory.GetSecurity().Decrypt(tmp);

            string sql2 = "update table_yuyue_info set c_check_result='" + FT.DAL.DALSecurityTool.TransferInsertField(connStr) + "' where id=993 ";
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql2);
            DbConnection conn=new OracleConnection(connStr);
            DataTable dt = new DataTable("tmp");
            try
            {
                /*
                try
                {
                    conn.Open();
                    conn.Close();
                    string sql3 = "update table_yuyue_info set c_check_result='测试数据库打开链接成功！' where id=994";
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql3);
                }
                catch (System.Exception e)
                {
                    string sql8 = "update table_yuyue_info set c_check_result='" + e.ToString() + "' where id=994 ";
                    FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql8);
                }
             */
                
                DbDataAdapter oradp = new OracleDataAdapter();
                DbCommand command = conn.CreateCommand();
                command.CommandText = queryStr;
                //command.CommandText = sql.Replace("\r\n","");
                oradp.SelectCommand = command;
                oradp.Fill(dt);
                string sql5 = "update table_yuyue_info set c_check_result='查询完毕" + FT.DAL.DALSecurityTool.TransferInsertField(queryStr) + "记录数：" + dt.Rows.Count.ToString() + "' where id=992 ";
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql5);
                //log.Error(e);
            }
            catch (Exception e)
            {
                string sql = "update table_yuyue_info set c_check_result='查询语句异常："+e.ToString()+"' where id=992 ";
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
                //log.Error(e);
               // return null;
            }
            
        }
        #region 供网上预约使用
        public static TempKscjInfo QueryKscj(String glbm, String sfzmhm)
        {
            TempKscjInfo info = null;
            String sql = "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from fzkyy.st_drv_preasign a where kskm=1 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            sql += " union ";
            sql += "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from fzkyy.st_drv_preasign a where kskm=2 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            sql += " union ";
            sql += "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from fzkyy.st_drv_preasign a where kskm=3 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            String queryStr = string.Format(sql, new string[] { glbm, sfzmhm });

            //IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt = GetInnerDbAccess().SelectDataTable(queryStr, "tmp");
            if (dt != null && dt.Rows.Count > 0)
            {
                info = new TempKscjInfo();
                info.km1 = Convert.ToInt32(dt.Rows[0][1]);
                info.km1yyrq = dt.Rows[0][2].ToString();
                if (dt.Rows.Count > 1)
                {
                    info.km2 = Convert.ToInt32(dt.Rows[1][1]);
                    info.km2yyrq = dt.Rows[1][2].ToString();
                }
                if (dt.Rows.Count > 2)
                {
                    info.km3 = Convert.ToInt32(dt.Rows[2][1]);
                    info.km3yyrq = dt.Rows[2][2].ToString();
                }

            }
            return info;
        }

        public static TempStudentInfo QueryStudent(String sfzmhm)
        {
            return QueryStudent(System.Configuration.ConfigurationManager.AppSettings["DrvHelperSystem_glbm"].ToString(), sfzmhm);
        }

        public static TempStudentInfo QueryStudent(String glbm, String sfzmhm)
        {
            TempStudentInfo info = null;
            //a.glbm like '{0}%' and
            String sql = "select distinct '' \"jxmc\",b.jxmc \"jxdm\", 'A' \"idCardType\", a.sfzmhm \"idCard\",a.xm \"name\",b.zkcx \"zkcx\",a.lsh \"lsh\",to_char(b.yxqs,'yyyy-MM-dd') \"yxqs\",to_char(b.yxqz,'yyyy-MM-dd') \"yxqz\",b.jly \"jly\" from fzkyy.st_drv_flow a left join fzkyy.st_drv_examcard b on a.sfzmhm=b.sfzmhm where  a.ywlx in ('A','B') and a.sfzmhm='{1}'";
            String queryStr = string.Format(sql, new string[] { glbm, sfzmhm });

            //IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            IDataAccess access=GetInnerDbAccess();
            DataTable dt = access.SelectDataTable(queryStr, "tmp");
            if (dt != null && dt.Rows.Count > 0)
            {
                log.Debug("查询到用户！");
                info = new TempStudentInfo();
                DataRow dr = dt.Rows[0];
                info.jxdm = dr[1] == null ? string.Empty : dr[1].ToString();
                info.idCardType = "A";
                info.idCard = sfzmhm;
                info.name = dr[4].ToString();
                info.zkcx = dr[5].ToString();
                info.lsh = dr[6].ToString();
                info.yxqs = dr[7] == null ? string.Empty : dr[7].ToString();
                info.yxqz = dr[8] == null ? string.Empty : dr[8].ToString();
                info.jly = dr[9] == null ? string.Empty : dr[9].ToString();
/*
                sql = "select distinct decode(xb,1,'男',2,'女') sex,lxdh phone,lxdh mobile,lxzsxxdz address,to_char(csrq,'yyyy-MM-dd') csrq  from fzkyy.st_person a where a.sfzmhm='{1}'";
                queryStr = string.Format(sql, new string[] { glbm, sfzmhm });
                DataTable dt2 = access.SelectDataTable(queryStr, "tmp");
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    dr = dt2.Rows[0];
                    info.sex=dr[0] == null ? string.Empty : dr[0].ToString();
                    info.phone = dr[1] == null ? string.Empty : dr[1].ToString();
                    info.mobile = dr[2] == null ? string.Empty : dr[2].ToString();
                    info.address = dr[3] == null ? string.Empty : dr[3].ToString();
                    info.birthday = dr[4] == null ? string.Empty : dr[4].ToString();
                }
 * */
            }
            return info;
        }
        #endregion

        #region 绑定字典等等

        public static void BindComboxBusType(ComboBox cb)
        {
            BindCombox(cb, 8);
        }
        public static void BindComboxSfzmmc(ComboBox cb)
        {
            BindCombox(cb, 19);
        }

        public static void BindDropDownListSfzmmc(DropDownList cb)
        {
            BindDropDownList(cb, 19);
        }

        public static void BindDropDownListZkcx(DropDownList cb)
        {
            BindDropDownList(cb, 1);
        }

        public static void BindDropDownListLy(DropDownList cb)
        {
            BindDropDownList(cb, 2);
        }

        public static void BindDropDownListLocalArea(DropDownList cb)
        {
            BindDropDownListByArea(cb, 50);
        }

        public static void BindDropDownListNational(DropDownList cb)
        {
            BindDropDownList(cb,31);
        }

        public static void BindDropDownListHospital(DropDownList cb)
        {
            BindDropDownListByArea(cb, 43);
        }

        public static void BindComboxHospital(ComboBox cb)
        {
            BindComboxByArea(cb, 43);
        }

        public static void BindComboxKsdd(ComboBox cb)
        {
            BindComboxByArea(cb, 41);
        }

        public static void BindComboxKscc(ComboBox cb)
        {
            BindComboxByArea(cb, 45);
        }


        public static void BindComboxByArea(ComboBox cb, int type)
        {
            DataTable dt1 = GetDictByArea(type);
            if (dt1 != null)
            {
                cb.DataSource = dt1;
                cb.DisplayMember = "dmmc1";
                cb.ValueMember = "dmz";
            }
        }

        public static void BindDropDownListByArea(DropDownList cb, int type)
        {
            DataTable dt1 = GetDictByAreaWeb(type);
            if (dt1 != null)
            {
                cb.DataSource = dt1;
                cb.DataTextField = "dmmc1";
                cb.DataValueField = "dmz";
                cb.DataBind();
            }
        }

        public static void BindCombox(ComboBox cb, int type)
        {
            DataTable dt1 = GetDict(type);
            if (dt1 != null)
            {
                cb.DataSource = dt1;
                cb.DisplayMember = "dmmc1";
                cb.ValueMember = "dmz";
            }
        }

        public static void BindDropDownList(DropDownList cb, int type)
        {
            DataTable dt1 = GetDictWeb(type);
            if (dt1 != null)
            {
                cb.DataSource = dt1;
                cb.DataTextField = "dmmc1";
                cb.DataValueField = "dmz";
                cb.DataBind();
            
            
            }
        }

        public static void BindDDLArea(DropDownList cb, string citycode)
        {
            DataTable dt1 = GetArea(citycode);
            if (dt1 != null)
            {
                cb.DataSource = dt1;
                cb.DataTextField = "dmmc1";
                cb.DataValueField = "dmz";
                cb.DataBind();
            }
        }

        private static IDataAccess GetInnerDbAccess()
        {
            

            string tmp = System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"];
            log.Debug("DefaultConnString2 is:" + tmp);
            string connStr = FT.Commons.Security.SecurityFactory.GetSecurity().Decrypt(tmp);

            IDataAccess access = new OracleDataHelper(connStr);
            return access;
        }


        private static DataTable GetArea(string citycode)
        {
            string sql = "select distinct dmz,dmz||'：'||dmmc1 as dmmc1 from trff_app.drv_code t where dmlb=33 and dmz<>'" + citycode + "' and  dmz like '" + citycode.Substring(0, 4) + "%'";
           // IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = GetInnerDbAccess().SelectDataTable(sql, "tmp");
            return dt1;
        }

        public static void BindDDLCity(DropDownList cb,string provicecode)
        {
            DataTable dt1 = GetCity(provicecode);
            if (dt1 != null)
            {
                cb.DataSource = dt1;
                cb.DataTextField = "dmmc1";
                cb.DataValueField = "dmz";
                cb.DataBind();
            }
        }

        private static DataTable GetCity(string provicecode)
        {
            string sql = "select distinct dmz,dmz||'：'||dmmc1 as dmmc1 from trff_app.drv_code t where dmlb=33 and dmz<>'" + provicecode + "' and dmz like '" + provicecode.Substring(0, 2) + "%00'";
          //  IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = GetInnerDbAccess().SelectDataTable(sql, "tmp");
            return dt1;
        }

       

        public static void BindDDLProvince(DropDownList cb)
        {
            DataTable dt1 = GetDictProvince();
            if (dt1 != null)
            {
                cb.DataSource = dt1;
                cb.DataTextField = "dmmc1";
                cb.DataValueField = "dmz";
                cb.DataBind();
            }
        }

        private static DataTable GetDictProvince()
        {

            string sql = "select distinct dmz,dmz||'：'||dmmc1 as dmmc1 from trff_app.drv_code t where dmlb=33 and dmz like '%0000'";
            //IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = GetInnerDbAccess().SelectDataTable(sql, "tmp");
            return dt1;
        }

        private static DataTable GetDictByAreaWeb(int type)
        {
            string glbm = System.Configuration.ConfigurationManager.AppSettings["glbm"];
            string ksccsql = "select distinct dmz ,dmz||'：'||dmmc1 as dmmc1 from trff_app.drv_code t where dmlb=" + type + " and dmz like '" + glbm + "%'";
           // IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = GetInnerDbAccess().SelectDataTable(ksccsql, "tmp");
            return dt1;
        }

        private static DataTable GetDictWeb(int type)
        {

            string ksccsql = "select distinct dmz,dmz||'：'||dmmc1 as dmmc1 from trff_app.drv_code t where dmlb=" + type;
           // IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = GetInnerDbAccess().SelectDataTable(ksccsql, "tmp");
            return dt1;
        }

        private static DataTable GetDictByArea(int type)
        {
            string glbm = System.Configuration.ConfigurationManager.AppSettings["glbm"];
            string ksccsql = "select distinct dmz,dmmc1 from trff_app.drv_code t where dmlb=" + type + " and dmz like '" + glbm + "%'";
           // IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = GetInnerDbAccess().SelectDataTable(ksccsql, "tmp");
            return dt1;
        }

        private static DataTable GetDict(int type)
        {
            
            string ksccsql = "select distinct dmz,dmmc1 from trff_app.drv_code t where dmlb=" + type ;
           // IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = GetInnerDbAccess().SelectDataTable(ksccsql, "tmp");
            return dt1;
        }
        #endregion 绑定字典等等


    }
}
