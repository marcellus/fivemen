using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using FT.Device.HotPrinter;
using FT.Device.CashCode;
using FT.Device.EncryptKeyboard;
using FT.Device.IDCard;
using FT.Device.InvoicePrinter;
using FT.Device.Rfid;
using FT.Device.VisaCardReader;

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text;


namespace TerminalMonitorServices
{
    /// <summary>
    /// TerminalStatusService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class TerminalStatusService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 获取机器代码
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetMachineMac()
        {
            return FT.Commons.Tools.HardwareManager.GetMac();
        }


        /// <summary>
        /// 获取机器代码
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetMachineCode()
        {
            return FT.Commons.Tools.HardwareManager.GetMachineCode();
        }

        /// <summary>
        /// 获取打印机状态
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetHotPrinterStatus()
        {
            StringBuilder sb = new StringBuilder();
            string result = string.Empty;
            int port = GetPort("InvoicePort");
            int ret = -1;
            ret = FT.Device.HotPrinter.HotPrinterImporter.OpenDevice(port, sb);
            if (ret != 0)
            {
                result = OpenDeviceFail;
            }
            else
            {
                FT.Device.HotPrinter.HotPrinterImporter.GetDeviceStatus(sb);
                result = sb.ToString();
                FT.Device.HotPrinter.HotPrinterImporter.CloseDevice(sb);
            }
            return result;
        }

        private int GetPort(string appConfig)
        {
            int port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings[appConfig]);
            return port;
        }

        private static string OpenDeviceFail = "打开设备失败,正在使用中！";

        /// <summary>
        /// 获取发票打印机状态
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetInvoicePrinterStatus()
        {
            StringBuilder sb = new StringBuilder();
            string result = string.Empty;
            int port = GetPort("InvoicePort");
            int ret = -1;
            ret=FT.Device.InvoicePrinter.InvoicePrinterImporter.OpenDevice(port,sb);
            if (ret != 0)
            {
                result = OpenDeviceFail;
            }
            else
            {
                FT.Device.InvoicePrinter.InvoicePrinterImporter.GetDeviceStatus( sb);
                result = sb.ToString();
                FT.Device.InvoicePrinter.InvoicePrinterImporter.CloseDevice(sb);
            }
           return result;
        }
    }
}
