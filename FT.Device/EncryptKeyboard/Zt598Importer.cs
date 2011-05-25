using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FT.Device.EncryptKeyboard
{
    public  class Zt598Importer
    {
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_OpenCom(int iPort, long lBaud);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_CloseCom();
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinInitialization(int iInitMode);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinReadVersion(StringBuilder cpVersion,StringBuilder cpSN,StringBuilder cpRechang);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_SetDesPara(int iPara, int iFCode);


        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinLoadMasterKey(int iKMode, int iKeyNo, string lpKey, StringBuilder cpExChk);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinLoadWorkKey(int iKMode, int iMKeyNo, int iKeyNo, string lpKey, StringBuilder cpExChk);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_ActivWorkPin(int iMKeyNo, int iWKeyNo);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinLoadCardNo(string lpCardNo);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_OpenKeyVoic( int iValue);

        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinStartAdd(int iPinLen, int iDispMode, int iPINMode, int iPromMode, int iTimeOut);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinReportPressed(StringBuilder cpKey, int iTimeOut);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinReadPin(int iKMode, StringBuilder cpPinBlock);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinCalMAC(int iKMode, int iMacMode, string lpValue, StringBuilder cpExValue);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinAdd(int iKMode, int iMode, string lpValue, StringBuilder cpExValue);

        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_PinUnAdd(int iKMode, int iMode, string lpValue, StringBuilder cpExValue);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_SetICType(int iIC, int iICType);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_ICOnPower(StringBuilder chOutData);
        [DllImport("ZT_EPP_API.dll")]
        public static extern  int ZT_EPP_ICControl(string lpValue, StringBuilder cpExValue);
    }
}
