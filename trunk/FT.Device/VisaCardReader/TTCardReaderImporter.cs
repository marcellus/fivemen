using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace FT.Device.VisaCardReader
{
    public class TTCardReaderImporter
    {
        #region dll导入
        /// <returns>1正确0错误</returns>
        [DllImport("TTCardReaderV2.dll")]
        public static extern int OpenDevice(int port, StringBuilder msg);

        [DllImport("TTCardReaderV2.dll")]
        public static extern int CloseDevice( StringBuilder msg);


        [DllImport("TTCardReaderV2.dll")]
        public static extern int EjectCard(StringBuilder msg);


        [DllImport("TTCardReaderV2.dll")]
        public static extern int EnableEntry(StringBuilder msg);

        [DllImport("TTCardReaderV2.dll")]
        public static extern int DisableEntry(StringBuilder msg);

        [DllImport("TTCardReaderV2.dll")]
        public static extern int ReadTracks(StringBuilder track1, StringBuilder track2, StringBuilder track3, StringBuilder msg);

        [DllImport("TTCardReaderV2.dll")]
        public static extern int CaptureCard(StringBuilder msg);

        [DllImport("TTCardReaderV2.dll")]
        public static extern int GetDeviceStatus(StringBuilder msg);
        #endregion
    }
}
