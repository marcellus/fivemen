using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Terminal
{
    [SimpleTable("yuantuo_terminals")]
    public class TerminalStatus:TerminalEntity
    {

        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string OnlineStatus=string.Empty;

        [Alias("上一轮检测时间")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public DateTime LastCheckTime;

      
        [Alias("热敏打印机状态")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string HotPrinterStatus;


       
        [Alias("发票打印机状态")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string InvoicePrinterStatus;


       
        [Alias("识币器状态")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string CashCodeStatus;


        
        [Alias("身份证阅读器状态")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string IdCardStatus;


        
        [Alias("摄像头状态")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string VedioStatus;


       
        [Alias("金属键盘状态")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string KeyboardStatus;

       
        [Alias("银联卡阅读器状态")]
        [SimpleColumn(AllowInsert=false,AllowSelect=false,AllowUpdate=false)]
        public string UnionPayCardReaderStatus;

       
        [Alias("Led设备状态")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string LedStatus;


        
        [Alias("Rfid阅读器状态")]
        [SimpleColumn(AllowInsert = false, AllowSelect = false, AllowUpdate = false)]
        public string RfidStatus;
    }
}
