using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection ;
using System.IO;
using log4net;

namespace FT.Device.IDCard
{
    public class IDCardReader
    {
        private ILog log = log4net.LogManager.GetLogger("FT.Device.IDCard");
        //首先，声明通用接口
        [DllImport("sdtapi.dll")]
        public static extern int SDT_OpenPort(int iPortID);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_ClosePort(int iPortID);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_PowerManagerBegin(int iPortID, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_AddSAMUser(int iPortID, string pcUserName, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_SAMLogin(int iPortID, string pcUserName, string pcPasswd, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_SAMLogout(int iPortID, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_UserManagerOK(int iPortID, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_ChangeOwnPwd(int iPortID, string pcOldPasswd, string pcNewPasswd, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_ChangeOtherPwd(int iPortID, string pcUserName, string pcNewPasswd, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_DeleteSAMUser(int iPortID, string pcUserName, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_StartFindIDCard(int iPortID, ref int pucIIN, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_SelectIDCard(int iPortID, ref int pucSN, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_ReadBaseMsg(int iPortID, string pucCHMsg, ref int puiCHMsgLen, string pucPHMsg, ref int puiPHMsgLen, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_ReadBaseMsgToFile(int iPortID, string fileName1, ref int puiCHMsgLen, string fileName2, ref int puiPHMsgLen, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_WriteAppMsg(int iPortID, ref byte pucSendData, int uiSendLen, ref byte pucRecvData, ref int puiRecvLen, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_WriteAppMsgOK(int iPortID, ref byte pucData, int uiLen, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_CancelWriteAppMsg(int iPortID, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_ReadNewAppMsg(int iPortID, ref byte pucAppMsg, ref int puiAppMsgLen, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_ReadAllAppMsg(int iPortID, ref byte pucAppMsg, ref int puiAppMsgLen, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_UsableAppMsg(int iPortID, ref byte ucByte, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_GetUnlockMsg(int iPortID, ref byte strMsg, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_GetSAMID(int iPortID, ref byte StrSAMID, int iIfOpen);

        [DllImport("sdtapi.dll")]
        public static extern int SDT_SetMaxRFByte(int iPortID, byte ucByte, int iIfOpen);
        [DllImport("sdtapi.dll")]
        public static extern int SDT_ResetSAM(int iPortID, int iIfOpen);

        [DllImport("WltRS.dll")]
        public static extern int GetBmp(string file_name, int intf);

        public delegate void De_ReadICCardComplete(IDCard card);
        public event De_ReadICCardComplete ReadICCardComplete;
        private IDCard objEDZ = new IDCard();
        private int EdziIfOpen = 1;               //自动开关串口
        int EdziPortID;
        public IDCardReader()
        {

        }
        /// <summary>
        /// 读卡，返回各种原因
        /// </summary>
        /// <returns>
        /// -1:端口打开失败，请检测相应的端口或者重新连接读卡器
        /// 1:未放卡或者卡未放好
        /// 2:读卡失败
        /// 3:读卡数据失败
        /// 0:读卡成功
        /// </returns>
        public int ReadICCard()
        {
            bool bUsbPort = false;
            int intOpenPortRtn = 0;
            int rtnTemp = 0;
            int pucIIN = 0;
            int pucSN = 0;
            int puiCHMsgLen = 0;
            int puiPHMsgLen = 0;

            objEDZ = new IDCard();
            //检测usb口的机具连接，必须先检测usb
            for (int iPort = 1001; iPort <= 1016; iPort++)
            {
                intOpenPortRtn = SDT_OpenPort(iPort);
                if (intOpenPortRtn == 144)
                {
                    EdziPortID = iPort;
                    bUsbPort = true;
                    break;
                }
            }
            //检测串口的机具连接
            if (!bUsbPort)
            {
                for (int iPort = 1; iPort <= 2; iPort++)
                {
                    intOpenPortRtn = SDT_OpenPort(iPort);
                    if (intOpenPortRtn == 144)
                    {
                        EdziPortID = iPort;
                        bUsbPort = false;
                        break;
                    }
                }
            }
            if (intOpenPortRtn != 144)
            {

                log.Debug("端口打开失败，请检测相应的端口或者重新连接读卡器！");
                //MessageBox.Show("端口打开失败，请检测相应的端口或者重新连接读卡器！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            //在这里，如果您想下一次不用再耗费检查端口的检查的过程，您可以把 EdziPortID 保存下来，可以保存在注册表中，也可以保存在配置文件中，我就不多写了，但是，
            //您要考虑机具连接端口被用户改变的情况哦

            //下面找卡
            rtnTemp = SDT_StartFindIDCard(EdziPortID, ref pucIIN, EdziIfOpen);
            if (rtnTemp != 159)
            {
                rtnTemp = SDT_StartFindIDCard(EdziPortID, ref pucIIN, EdziIfOpen);  //再找卡
                if (rtnTemp != 159)
                {
                    rtnTemp = SDT_ClosePort(EdziPortID);
                    log.Debug("未放卡或者卡未放好，请重新放卡！");
                    //MessageBox.Show("", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
            }
            //选卡
            rtnTemp = SDT_SelectIDCard(EdziPortID, ref pucSN, EdziIfOpen);
            if (rtnTemp != 144)
            {
                rtnTemp = SDT_SelectIDCard(EdziPortID, ref pucSN, EdziIfOpen);  //再选卡
                if (rtnTemp != 144)
                {
                    rtnTemp = SDT_ClosePort(EdziPortID);
                    log.Debug("读卡失败！");
                   // MessageBox.Show("读卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 2;
                }
            }
            //注意，在这里，用户必须有应用程序当前目录的读写权限
            FileInfo objFile = new FileInfo("wz.txt");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            objFile = new FileInfo("zp.bmp");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            objFile = new FileInfo("zp.wlt");
            if (objFile.Exists)
            {
                objFile.Attributes = FileAttributes.Normal;
                objFile.Delete();
            }
            rtnTemp = SDT_ReadBaseMsgToFile(EdziPortID, "wz.txt", ref puiCHMsgLen, "zp.wlt", ref puiPHMsgLen, EdziIfOpen);
            if (rtnTemp != 144)
            {
                rtnTemp = SDT_ClosePort(EdziPortID);
                log.Debug("读卡数据失败！");
               // MessageBox.Show("读卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }
            //下面解析照片，注意，如果在C盘根目录下没有机具厂商的授权文件Termb.Lic，照片解析将会失败
            if (bUsbPort)
                rtnTemp = GetBmp("zp.wlt", 2);
            else
                rtnTemp = GetBmp("zp.wlt", 1);
            switch (rtnTemp)
            {
                case 0:
                    log.Debug("调用sdtapi.dll错误！");
                    //MessageBox.Show("调用sdtapi.dll错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 1:   //正常
                    break;
                case -1:
                    log.Debug("调用sdtapi.dll错误！");
                   // MessageBox.Show("相片解码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -2:
                    log.Debug("wlt文件后缀错误！");
                   // MessageBox.Show("wlt文件后缀错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -3:
                    log.Debug("wlt文件打开错误！");
                    //MessageBox.Show("wlt文件打开错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -4:
                    log.Debug("wlt文件格式错误！");
                   // MessageBox.Show("wlt文件格式错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -5:
                    log.Debug("软件未授权！");
                   // MessageBox.Show("软件未授权！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -6:
                    log.Debug("设备连接错误！");
                    //MessageBox.Show("设备连接错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            rtnTemp = SDT_ClosePort(EdziPortID);
            FileInfo f = new FileInfo("wz.txt");
            FileStream fs = f.OpenRead();
            byte[] bt = new byte[fs.Length];
            fs.Read(bt, 0, (int)fs.Length);
            fs.Close();

            string str = System.Text.UnicodeEncoding.Unicode.GetString(bt);

            objEDZ.Name = System.Text.UnicodeEncoding.Unicode.GetString(bt, 0, 30).Trim();
            objEDZ.Sex_Code = System.Text.UnicodeEncoding.Unicode.GetString(bt, 30, 2).Trim();
            objEDZ.NATION_Code = System.Text.UnicodeEncoding.Unicode.GetString(bt, 32, 4).Trim();
            string strBird = System.Text.UnicodeEncoding.Unicode.GetString(bt, 36, 16).Trim();
            objEDZ.BIRTH = Convert.ToDateTime(strBird.Substring(0, 4) + "年" + strBird.Substring(4, 2) + "月" + strBird.Substring(6) + "日");
            objEDZ.ADDRESS = System.Text.UnicodeEncoding.Unicode.GetString(bt, 52, 70).Trim();
            objEDZ.IDC = System.Text.UnicodeEncoding.Unicode.GetString(bt, 122, 36).Trim();
            objEDZ.REGORG = System.Text.UnicodeEncoding.Unicode.GetString(bt, 158, 30).Trim();
            string strTem = System.Text.UnicodeEncoding.Unicode.GetString(bt, 188, bt.GetLength(0) - 188).Trim();
            objEDZ.STARTDATE = Convert.ToDateTime(strTem.Substring(0, 4) + "年" + strTem.Substring(4, 2) + "月" + strTem.Substring(6, 2) + "日");
            strTem = strTem.Substring(8);
            if (strTem.Trim() != "长期")
            {
                objEDZ.ENDDATE = Convert.ToDateTime(strTem.Substring(0, 4) + "年" + strTem.Substring(4, 2) + "月" + strTem.Substring(6, 2) + "日");
            }
            else
            {
                objEDZ.ENDDATE = DateTime.MaxValue;
            }
            objFile = new FileInfo("zp.bmp");
            if (objFile.Exists)
            {
                Image img = Image.FromFile("zp.bmp");
                objEDZ.PIC_Image = (Image)img.Clone();
                System.IO.MemoryStream m = new MemoryStream();
                img.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                objEDZ.PIC_Byte = m.ToArray();
                img.Dispose();
                img = null;
            }
            ReadICCardComplete(objEDZ);
            return 0;
        }
    }
}
