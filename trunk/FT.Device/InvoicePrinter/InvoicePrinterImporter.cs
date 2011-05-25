using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace FT.Device.InvoicePrinter
{
    public class InvoicePrinterImporter
    {
        #region dll导入
        /// <returns>1正确0错误</returns>
        [DllImport("InvoicePrinter.dll")]
        public static extern int OpenDevice(int port, StringBuilder msg);

        [DllImport("InvoicePrinter.dll")]
        public static extern int CloseDevice(StringBuilder msg);

        [DllImport("InvoicePrinter.dll")]
        public static extern int GetDeviceStatus(StringBuilder msg);

        [DllImport("InvoicePrinter.dll")]
        public static extern int SetRowDistance(int port, StringBuilder msg);

        [DllImport("InvoicePrinter.dll")]
        public static extern int PrintLine(String data, StringBuilder msg);

        [DllImport("InvoicePrinter.dll")]
        public static extern int CutPaper(int flag,StringBuilder msg);

        [DllImport("InvoicePrinter.dll")]
        public static extern int SetTextStyle(String style, StringBuilder msg);
        //SetRowDistance SetLeftDistance  PrintBitmapNV  SetTextStyle


        [DllImport("InvoicePrinter.dll")]
        public static extern int SetBlackOffset(int P,int L ,int Q, StringBuilder msg);


        [DllImport("InvoicePrinter.dll")]
        public static extern int BlackMarkIdentify(StringBuilder msg);

        [DllImport("InvoicePrinter.dll")]
        public static extern int MovePaper(int distance,StringBuilder msg);


        
        
        


        #endregion
    }
}
