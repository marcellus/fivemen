using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace FT.Device.HotPrinter
{
    public class HotPrinterImporter
    {

        #region dll导入
        /// <returns>1正确0错误</returns>
        [DllImport("ReceiptPrinter.dll")]
        public static extern int OpenDevice(int port,StringBuilder msg);

        [DllImport("ReceiptPrinter.dll")]
        public static extern int CloseDevice(StringBuilder msg);

        [DllImport("ReceiptPrinter.dll")]
        public static extern int GetDeviceStatus(StringBuilder msg);

        [DllImport("ReceiptPrinter.dll")]
        public static extern int SetRowDistance(int port, StringBuilder msg);

        [DllImport("ReceiptPrinter.dll")]
        public static extern int SetLeftDistance(int port, StringBuilder msg);

        [DllImport("ReceiptPrinter.dll")]
        public static extern int PrintLine(String data, StringBuilder msg);


        [DllImport("ReceiptPrinter.dll")]
        public static extern int CutPaper(StringBuilder msg);

        [DllImport("ReceiptPrinter.dll")]
        public static extern int PrintBitmapNV(int index,int size,int space,StringBuilder msg);

        [DllImport("ReceiptPrinter.dll")]
        public static extern int SetTextStyle(String style, StringBuilder msg);
        //SetRowDistance SetLeftDistance  PrintBitmapNV  SetTextStyle

        
        #endregion

    }
}
