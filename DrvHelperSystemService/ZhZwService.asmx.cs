using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using FT.DAL;

namespace DrvHelperSystemService
{
    /// <summary>
    /// ZhZwService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class ZhZwService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetLessonResult(string idcard)
        {
            string result = "未完成";
            DataTable dt = FT.WebServiceInterface.DrvQuery.ZhZwQueryHelper.GetDataTable(idcard);
            if(dt!=null&&dt.Rows.Count>0)
            {
                result = dt.Rows[0]["lesson_result"].ToString();
            }

            return result;
        }

        [WebMethod]
        public string GetTrainResult(string idcard)
        {
            string result = "未完成";
            DataTable dt = FT.WebServiceInterface.DrvQuery.ZhZwQueryHelper.GetDataTable(idcard);
            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["train_result"].ToString();
            }

            return result;
        }

    }
}
