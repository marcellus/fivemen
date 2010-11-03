using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace WebService2
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        #region old

        [WebMethod]
        public DataSet GetDataSet(string sql, string useName, string passWord)
        {
            return new DB().GetDataSet(sql);
        }
        [WebMethod]
        public int ExecSql(string sql, string useName, string passWord)
        {
            return new DB().ExecSql(sql);
        }
        [WebMethod]
        public int ExecSqls(string[] sqls, string useName, string passWord)
        {
            return new DB().ExecSql(sqls);
        }
        [WebMethod]
        public DataSet getAsnDetail(string asn)
        {
            return new DB().getASNDetail(asn);
        }

        [WebMethod]
        public bool SaveAsn(DataTable dt, string userid)
        {
            return new DB().SaveAsn(dt, userid);
        }
        [WebMethod]
        public bool SavePutAway(DataTable dtDisk, DataTable dtLoc, string al, string userid, DataTable dtSku)
        {
            return new DB().SavePutAway(dtDisk, dtLoc, al, userid, dtSku);
        }

        [WebMethod]
        public DataSet GetPutAway(string putAwayBillNo)
        {
            return new DB().GetPutAwayData(putAwayBillNo);
        }

        [WebMethod]
        public DataSet GetPickData(string PickKey, string loc)
        {
            return new DB().GetPickData(PickKey, loc);
        }

        [WebMethod]
        public bool SavePickData(DataTable dtPick, DataTable dtDisk, string userid)
        {
            return new DB().SavePickData(dtPick, dtDisk, userid);
        }

        [WebMethod]
        public DataSet GetPartDisk()
        {
            return new DB().GetPartDiskData();
        }

        [WebMethod]
        public bool SavePartDisk(DataTable dt, string userid)
        {
            return new DB().SavePartDiskData(dt, userid);
        }

        [WebMethod]
        public DataSet GetFeedBackData(string id)
        {
            return new DB().GetFeedBackData(id);
        }

        [WebMethod]
        public bool SaveFeedBackData(DataTable dt)
        {
            return new DB().SaveFeedBackData(dt);
        }

        [WebMethod]
        public string GetAndUpdateDiskForOpen(string id, string userid)
        {
            return new DB().GetAndUpdateDiskForOpen(id, userid);
        }

        [WebMethod]
        public string GetAndSaveDiskForBegin(string id, string userid,string scantype)
        {
            return new DB().GetAndSaveDiskForBegin(id, userid, scantype);
        }

        [WebMethod]
        public string GetAndSaveDiskForEnd(string id, string userid, string scantype)
        {
            return new DB().GetAndSaveDiskForEnd(id, userid, scantype);
        }

        [WebMethod]
        public DataSet GetCompany()
        {
            return new DB().GetCompany();
        }

        [WebMethod]
        public DataSet GetDiskList(string diskid, string sku, DateTime dt, string asn)
        {
            return new DB().GetDiskList(diskid, sku, dt, asn);
        }

        [WebMethod]
        public string IsInDataBase(string id)
        {
            return new DB().isInDataBase(id);
        }

        [WebMethod]
        public DataTable GetPickDisk(string pickid, string loc)
        {
            return new DB().GetPickDiskData(pickid, loc);
        }
        [WebMethod]
        public DataSet GetMoveLocData(string loc)
        {
            return new DB().GetMoveLocData(loc);
        }
        [WebMethod]
        public bool SaveMoveLoc(DataTable dt,string userid)
        {
            return new DB().SaveMoveLoc(dt, userid);
        }

        [WebMethod]
        public DataSet GetMoveLotData(string billid, string lot)
        {
            return new DB().GetMoveLotData(billid, lot);
        }

        [WebMethod]
        public bool SaveMoveLotData(DataTable dt,string userid)
        {
            return new DB().SaveMoveLotData(dt, userid);
        }
        #endregion


        [WebMethod]
        public DataSet GetUserRight(string user, string pwd)
        {
            return new DB().GetUserRightList(user, pwd);
        }
        [WebMethod]
        public DataSet GetFactoryAndStorage()
        {
            return new DB().GetFactoryAndStorage();
        }
        [WebMethod]
        public DataSet GetLoc()
        {
            return new DB().GetLoc();
        }
        [WebMethod]
        public DataSet GetUserAndFunction()
        {
            return new DB().GetUserAndFunction();
        }
        [WebMethod]
        public string UpdateServerByPda(DataSet ds)
        {
            return new DB().UpdateServerByPda(ds);
        }
    }

}
