using System;
using System.Data;
using System.Configuration;
using FT.DAL.Oracle;
using FT.DAL;
using log4net;
using System.Windows.Forms;

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
        #region 供网上预约使用
        public static TempKscjInfo QueryKscj(String glbm, String sfzmhm)
        {
            TempKscjInfo info = null;
            String sql = "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from drv_admin.drv_preasign a where kskm=1 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            sql += " union ";
            sql += "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from drv_admin.drv_preasign a where kskm=2 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            sql += " union ";
            sql += "(select kskm \"kskm\",zt \"zt\",to_char(ykrq,'yyyy-MM-dd') \"yyrq\" from (select kskm,nvl(zt,0) zt,nvl(ykrq,sysdate) ykrq from drv_admin.drv_preasign a where kskm=3 and glbm like '{0}%' and sfzmhm='{1}' order by ykrq desc) where rownum=1)";
            String queryStr = string.Format(sql, new string[] { glbm, sfzmhm });

            IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt = access.SelectDataTable(queryStr, "tmp");
            if (dt != null && dt.Rows.Count > 0)
            {
                info = new TempKscjInfo();
                info.km1 = Convert.ToInt32(dt.Rows[1][1]);
                info.km1yyrq = dt.Rows[1][2].ToString();
                if (dt.Rows.Count > 1)
                {
                    info.km2 = Convert.ToInt32(dt.Rows[1][1]);
                    info.km2yyrq = dt.Rows[1][2].ToString();
                }
                if (dt.Rows.Count > 2)
                {
                    info.km3 = Convert.ToInt32(dt.Rows[1][1]);
                    info.km3yyrq = dt.Rows[1][2].ToString();
                }

            }
            return info;
        }

        public static TempStudentInfo QueryStudent(String glbm, String sfzmhm)
        {
            TempStudentInfo info = null;
            String sql = "select distinct '' \"jxmc\",b.jxmc \"jxdm\", 'A' \"idCardType\", a.sfzmhm \"idCard\",a.xm \"name\",b.zkcx \"zkcx\",a.lsh \"lsh\",to_char(b.yxqs,'yyyy-MM-dd') \"yxqs\",to_char(b.yxqz,'yyyy-MM-dd') \"yxqz\",b.jly \"jly\" from drv_admin.drv_flow a left join drv_admin.drv_examcard b on a.sfzmhm=b.sfzmhm where a.glbm like '{0}%' and a.ywlx in ('A','B') and a.sfzmhm='{1}'";
            String queryStr = string.Format(sql, new string[] { glbm, sfzmhm });

            IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
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

        private static DataTable GetDictByArea(int type)
        {
            string glbm = System.Configuration.ConfigurationManager.AppSettings["glbm"];
            string ksccsql = "select distinct dmz,dmmc1 from drv_admin.drv_code t where dmlb=" + type + " and dmz like '" + glbm + "%'";
            IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = access.SelectDataTable(ksccsql, "tmp");
            return dt1;
        }

        private static DataTable GetDict(int type)
        {
            
            string ksccsql = "select distinct dmz,dmmc1 from drv_admin.drv_code t where dmlb=" + type ;
            IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
            DataTable dt1 = access.SelectDataTable(ksccsql, "tmp");
            return dt1;
        }
        #endregion 绑定字典等等
    }
}
