using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Terminal
{
    [SimpleTable("table_terminal")]
    public class TerminalStatus:TerminalEntity
    {

        public string OnlineStatus=string.Empty;

        [Alias("上一轮检测时间")]
        public DateTime LastCheckTime;

      
        [Alias("热敏打印机状态")]
        public string HotPrinterStatus;


       
        [Alias("发票打印机状态")]
        public string InvoicePrinterStatus;


       
        [Alias("识币器状态")]
        public string CashCodeStatus;


        
        [Alias("身份证阅读器状态")]
        public string IdCardStatus;


        
        [Alias("摄像头状态")]
        public string VedioStatus;


       
        [Alias("金属键盘状态")]
        public string KeyboardStatus;

       
        [Alias("银联卡阅读器状态")]
        public string UnionPayCardReaderStatus;

       
        [Alias("Led设备状态")]
        public string LedStatus;


        
        [Alias("Rfid阅读器状态")]
        public string RfidStatus;
    }
}
