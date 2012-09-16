using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FT.Device.EncryptKeyboard
{
    public class KmyImporter
    {
        //9600
        [DllImport("KMY350X.dll")]
        public static extern int OpenPort(int iPort, int lBaud);
        [DllImport("KMY350X.dll")]
        public static extern int ClosePort();

        [DllImport("KMY350X.dll")]
        public static extern int ScoutKeyPress(ref byte keyCode);

        [DllImport("KMY350X.dll")]
        public static extern int DevReset(int type);
        [DllImport("KMY350X.dll")]
        public static extern int SetFunctionKeys(int type);

        //IType  关闭键盘：1  打开键盘：2  打开键盘且静音：3  系统键盘：4 
        [DllImport("KMY350X.dll")]
        public static extern int KeyboardControl(int type);
    }
}
