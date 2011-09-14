using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace FT.Device.PortSupport
{
    public class PortImporter
    {
        #region dll导入
        /// <returns>1正确0错误</returns>
        [DllImport("SerialPortV2.dll")]
        public static extern int OpenPort(IntPtr pPortOwner,int port, StringBuilder msg);

        [DllImport("SerialPortV2.dll")]
        public static extern int ClosePort(StringBuilder msg);

        [DllImport("SerialPortV2.dll")]
        public static extern void WriteToPort1(StringBuilder msg);

        [DllImport("SerialPortV2.dll")]
        public static extern void WriteToPort2( StringBuilder msg,int n);

        [DllImport("SerialPortV2.dll")]
        public static extern void WriteToPort3(StringBuilder msg,int n);

        [DllImport("SerialPortV2.dll")]
        public static extern void WriteToPort4(StringBuilder msg);


        [DllImport("SerialPortV2.dll")]
        public static extern void WriteToPort5(StringBuilder msg, int n);

        [DllImport("SerialPortV2.dll")]
        public static extern void TurnOn(int n);

        [DllImport("SerialPortV2.dll")]
        public static extern void TurnOff(int n);

        #endregion
    }
}
