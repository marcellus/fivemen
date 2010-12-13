using System;
using System.Data;
using System.Configuration;
using System.Web;
using log4net;
namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    ///DriverInterface 的摘要说明
    /// </summary>
    public class DriverInterface
    {
        protected static ILog log = log4net.LogManager.GetLogger("DriverInterface");
        public DriverInterface()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        #region 模拟获取用户的接口
        public static BusAllInfo GetFromUser(string idcardtype, string idcard, string dabh)
        {
            BusAllInfo info = new BusAllInfo();
            info.Dabh = "200120234";
            info.Lsh = "44040120101022";
            info.IdCardType = "身份证明号码";
            info.IdCard = "350128198403122135";
            info.Nation = "中国";
            info.CarType = "C1";
            info.Birthday = "1984-03-12";
            info.Sex = "男";
            info.Xm = "模拟用户1";
            info.CheckDate = "2010-10-02";
            return info;
        }

        public static bool WriteBusAllInfo(BusAllInfo info)
        {
            return true;
        }
        #endregion

        #region Tmri新接口
        public static TmriResponse WriteDrvBaseTmriRequest(DrvBaseTmriRequest request)
        {
            log.Debug("预约写入接口的xtlb：" + request.GetXtlb());
            log.Debug("预约写入接口的jkxlh：" + request.GetJkxlh());
            log.Debug("预约写入接口的jkid：" + request.GetJkid());
            log.Debug("预约写入接口的文本为：" + request.ToXml());
            TmriJaxRpcOutAccessService service = new TmriJaxRpcOutAccessService();
            service.Url = System.Configuration.ConfigurationManager.AppSettings["DefaultDrvSeriveUrl"];
            log.Debug("服务的URL："+service.Url);
            string responseText = "";
            responseText = service.writeObject(request.GetXtlb(), request.GetJkxlh(), request.GetJkid(), request.ToXml());
            log.Debug("调用写入接口返回的文本为：" + responseText);
            TmriResponse response = new TmriResponse();
            response.ParseFromXml(responseText);
            return response;

        }
        #endregion

        private DrvService GetOldService()
        {
            DrvService srv = new DrvService();
            srv.Url = System.Configuration.ConfigurationManager.AppSettings["DefaultDrvSeriveUrlOld"];
            return srv;
        }
    }
}
