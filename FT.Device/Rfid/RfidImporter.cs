using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FT.Device.Rfid
{
    public class RfidImporter
    {
        #region 对USB接口的使用(PHILIPH卡)
        #region  D3接口函数定义
        [DllImport("dcrf32.dll")]
        public static extern int dc_init(Int16 port, long baud);  //初试化
        [DllImport("dcrf32.dll")]
        public static extern int dc_exit(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern int dc_reset(int icdev, uint sec);
        [DllImport("dcrf32.dll")]
        public static extern int dc_request(int icdev, char _Mode, ref uint TagType);
        ////[DllImport("dcrf32.dll")]
        ////public static extern int dc_card(int icdev, char _Mode, ref ulong Snr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card(int icdev, char _Mode, ref ulong Snr);

        [DllImport("dcrf32.dll")]
        public static extern short dc_card(int icdev, char _Mode, [MarshalAs(UnmanagedType.LPStr)] StringBuilder Snr);  //从卡中读数据(转换为16进制)

        [DllImport("dcrf32.dll")]
        public static extern int dc_halt(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern int dc_anticoll(int icdev, char _Bcnt, ref ulong IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern int dc_beep(int icdev, uint _Msec);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication(int icdev, int _Mode, int _SecNr);

        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_passaddr(int icdev, int _Mode, int _SecNr, [In] string sdata);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_passaddr_hex(int icdev, int _Mode, int _SecNr, [In] string sdata);

        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_pass(int icdev, int _Mode, int _SecNr, [In] string sdata);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_pass_hex(int icdev, int _Mode, int _SecNr, [In] string sdata);

        [DllImport("dcrf32.dll")]
        public static extern int dc_load_key(int icdev, int mode, int secnr, [In] byte[] nkey);  //密码装载到读写模块中
        [DllImport("dcrf32.dll")]
        public static extern int dc_load_key_hex(int icdev, int mode, int secnr, string nkey);  //密码装载到读写模块中

        [DllImport("dcrf32.dll")]
        //public static extern int dc_write(int icdev, int adr, [In] char[]  sdata);  //向卡中写入数据
        public static extern int dc_write(int icdev, int adr, [In] string sdata);  //向卡中写入数据
        [DllImport("dcrf32.dll")]
        public static extern int dc_write_hex(int icdev, int adr, [In] string sdata);  //向卡中写入数据(转换为16进制)

        [DllImport("dcrf32.dll")]
        public static extern int dc_read(int icdev, int adr, [Out] byte[] sdata);  //从卡中读数据
        [DllImport("dcrf32.dll")]
        public static extern short dc_read(int icdev, int adr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);  //从卡中读数据

        [DllImport("dcrf32.dll")]
        public static extern short dc_read_hex(int icdev, int adr, ref byte sdata);  //从卡中读数据(转换为16进制)
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_hex(int icdev, int adr, [MarshalAs(UnmanagedType.LPStr)] StringBuilder sdata);  //从卡中读数据(转换为16进制)

        [DllImport("dcrf32.dll")]
        public static extern void hex_a(ref string oldValue, ref string newValue, int len);  //十六进制字符转换成普通字符

        [DllImport("dcrf32.dll")]
        public static extern short dc_initval(int icdev, int _Bcnt, [In] uint IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readval(int icdev, int _Bcnt, ref  uint IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern short dc_increment(int icdev, int _Bcnt, [In] uint IcCardNo);
        [DllImport("dcrf32.dll")]
        public static extern short dc_decrement(int icdev, int _Bcnt, [In] uint IcCardNo);


        #endregion
        #endregion

        
    }
}
