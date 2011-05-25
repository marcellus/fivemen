using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace FT.Device.IDCardWithScan
{
    public class A8ScannerReaderImporter
    {
        /// <summary>
        /// 初始化端口
        /// </summary>
        /// <param name="deviceName">IVS-600DS</param>
        /// <returns>True：成功，False：失败</returns>
        [DllImport("a8_dblNew.dll")]
        public static extern int IO_HasScanner(string deviceName);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_GetScanModeA8(ref SC_MODEA8 mMode);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_SetScanModeA8(ref SC_MODEA8 mMode);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_ReadRFIDInfo(ref Id_Card pIdCard);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_GetCalibData(ref SC_CALIBDATA pCalibData);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_GetCardStatus(ref long lStatus);

        [DllImport("a8_dblNew.dll")]
        public static extern int BmpToJpeg(string srcFileName, string dstFileName);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_GetImgFromUnit(int lDpi, String pImgPath1, ref int lImgW1, ref int lImgH1,
            String pImgPath2, ref int lImgW2, ref int lImgH2);

        [DllImport("kernel32.dll")]
        public static extern void Sleep(long dwMilliseconds);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_Beep(long lTimes);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_EjectCard();

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_GetSensorStatus(ref long lStatus);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_GetChipID(ref long lChipID);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_GetVersion(string strVersion);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_SetCalibdata();

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_GetDeviceStatus(ref long lStatus);

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_ResetDevice();

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_ConfiscateCard();

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_StartSuckCard();

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_CancelSuckCard();

        [DllImport("a8_dblNew.dll")]
        public static extern int IO_CloseDevice();

        #region 结构体
        public struct SC_MODEA8
        {
            public int atuo_reverse;
            public int mode_u;
            public int mode_d;
            public int mode_u_r;
            public int mode_d_r;
        }
        public struct SC_CALIBDATA
        {
            public int bCalibStatus;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5152)]
            public byte[] R_Gain;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5152)]
            public byte[] G_Gain;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5152)]
            public byte[] B_Gain;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5152)]
            public byte[] IR_Gain;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2576)]
            public byte[] offset;
        }

        /// <summary>
        /// 身份证
        /// </summary>
        public struct Id_Card
        {
            /// <summary>
            /// 保留
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] id_Rev;

            /// <summary>
            /// 姓名
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] id_Name;

            /// <summary>
            /// 性别:1男，2女
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] id_Sex;

            /// <summary>
            /// 民族
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] id_National;

            /// <summary>
            /// 出生日期
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] id_Born;

            /// <summary>
            /// 家庭
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
            public byte[] id_Home;

            /// <summary>
            /// 身份证号
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
            public byte[] id_Code;

            /// <summary>
            /// 发证机关
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] id_RegOrg;

            /// <summary>
            /// 有效期限
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] id_ValidPeriod;

            /// <summary>
            /// 最新地址
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
            public byte[] id_NewAddr;

            /// <summary>
            /// 图像
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            public byte[] id_pImage;
        }

        #endregion       
    }
}
