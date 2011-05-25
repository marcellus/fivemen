using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace FT.Device.CashCode
{
    public class CashCodeImporter
    {
        #region 导入dll
        [DllImport("BillValidator.dll")]
        public static extern int OpenDevice(int port, StringBuilder msg);

        [DllImport("BillValidator.dll")]
        public static extern int CloseDevice(StringBuilder msg);

        [DllImport("BillValidator.dll")]
        public static extern int GetDeviceStatus(StringBuilder msg);


        [DllImport("BillValidator.dll")]
        public static extern int StartIdentify(String TraceNo, String UserNo, String EnabledDenominations, StringBuilder msg);

        [DllImport("BillValidator.dll")]
        public static extern int StartIdentifyV2(String TraceNo, String UserNo, String EnabledDenominations, StringBuilder msg);

        
        [DllImport("BillValidator.dll")]
        public static extern int StopIdentify(StringBuilder msg);
        [DllImport("BillValidator.dll")]
        public static extern int Identify(StringBuilder msg);

        [DllImport("BillValidator.dll")]
        public static extern int Reset(StringBuilder msg);

        [DllImport("BillValidator.dll")]
        public static extern int IdentifyV2(int maxMoney,StringBuilder msg);

        



        #endregion
    }
}
