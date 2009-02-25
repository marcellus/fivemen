using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

namespace FT.Device.IDCard
{
    public class CV100UReader
    {
        #region dll导入
        /*
int CVR_InitComm(int Port)       						 初始化连接;
int CVR_Authenticate()									 卡认证;
int CVR_Read_Content(int Active)				    			 读卡操作。
int CVR_CloseComm()			      						 关闭连接;
int CVR_Ant(int mode)									 射频操作
	int	CVR_ReadBaseMsg (
		  unsigned char *pucCHMsg, unsigned int *puiCHMsgLen, 							  unsigned char *pucPHMsg, unsigned int *puiPHMsgLen, 
		  int nMode)                                          读卡操作(读入内存)
	int  GetPeopleName(char *strTmp, int strLen)	    			 	 得到姓名信息	
	int  GetPeopleSex(char *strTmp, int strLen)	    			 		 得到性别信息	
	int  GetPeopleNation(char *strTmp, int strLen)	    			 	 得到民族信息	
	int  GetPeopleBirthday(char *strTmp, int strLen)			 		 得到出生日期	
	int  GetPeopleAddress(char *strTmp, int strLen)			 		 得到地址信息	
	int  GetPeopleIDCode(char *strTmp, int strLen)			 		 得到身份证号信息
	int  GetDepartment(char *strTmp, int strLen)	    			 	 得到发证机关信息	
	int  GetStartDate(char *strTmp, int strLen)	    					得到有效开始日期	
	int  GetEndDate(char *strTmp, int strLen)	        				得到有效截止日期

         */
        #region 调用 CVR_Read_Content 或者 CVR_ReadBaseMsg 函数			成功后再分别调用以下函数
        /// <summary>
        ///得到姓名信息
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="namelen">字符串长度</param>
        /// <returns>1正确0错误</returns>
        [DllImport("termb.dll")]
        public static extern int GetPeopleName(StringBuilder name,int namelen);
        [DllImport("termb.dll")]
        public static extern int GetPeopleSex(StringBuilder sex, int sexlen);
        [DllImport("termb.dll")]
        public static extern int GetPeopleNation(StringBuilder nation, int nationlen);
        [DllImport("termb.dll")]
        public static extern int GetPeopleBirthday(StringBuilder birthday, int birlen);
        [DllImport("termb.dll")]
        public static extern int GetPeopleAddress(StringBuilder address, int addresslen);
        [DllImport("termb.dll")]
        public static extern int GetPeopleIDCode(StringBuilder idcode, int idcodelen);
        [DllImport("termb.dll")]
        public static extern int GetDepartment(StringBuilder dept, int deptlen);
        [DllImport("termb.dll")]
        public static extern int GetStartDate(StringBuilder start, int startlen);
        [DllImport("termb.dll")]
        public static extern int GetEndDate(StringBuilder end, int endlen);
        #endregion

        /// <summary>
        /// 读文字、照片信息到自定义内存缓冲
        /// </summary>
        /// <param name="baseData">身份文字信息内存缓冲指针 out</param>
        /// <param name="baseDataLen">身份文字信息长度默认 256 Byte</param>
        /// <param name="picData">身份照片信息内存缓冲指针 out</param>
        /// <param name="picDataLen">身份照片信息长度默认 1024 Byte</param>
        /// <param name="mode">
        /// 1、文字编码为默认UCS-2格式，照片未解压成bmp文件
        /// 2、文字编码已转换成GBK国标码格式，照片未解压成bmp文件
        /// 3、文字编码为默认UCS-2格式，照片已解压成zp.bmp文件
        /// 4、文字编码已转换成GBK国标码格式，照片已解压成zp.bmp文件
        /// </param>
        /// <returns>1正确0错误</returns>
        [DllImport("termb.dll", CharSet = CharSet.Auto)]
        public static extern int CVR_ReadBaseMsg(StringBuilder baseData,int baseDataLen,StringBuilder picData,int picDataLen,int mode);

        /// <summary>
        /// 本函数用于打开/关闭射频。阅读器在不读卡时，如果射频对其它的电子产品有干扰的话，
        /// 可以选择关闭射频，当需要读卡时，再打开射频。该函数只在当连接到串行接口的阅读器时，
        /// 调用有效。如不调用此函数时，射频一直处于打开状态。
        /// 注：当 CVR_InitComm函数调用成功后，该函数有效。
        /// </summary>
        /// <param name="mode">
        /// 1、打开射频
        /// 0、关闭射频
        /// </param>
        /// <returns>1正确0错误</returns>
        [DllImport("termb.dll")]
        public static extern int CVR_Ant(int mode);

        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="port">端口，1-4串口，1001-1004USB口</param>
        /// <returns>1正确0错误</returns>
        [DllImport("termb.dll")]
        public static extern int CVR_InitComm(int port);

        /// <summary>
        /// 关闭PC到阅读器的连接
        /// </summary>
        /// <returns>1正确0错误</returns>
        [DllImport("termb.dll")]
        public static extern int CVR_CloseComm();


        /// <summary>
        /// 卡认证.
        /// </summary>
        /// <returns>注意：若卡片放置后发生认证错误时，应移走卡片重新放置。
        /// 1、卡片正确放置时
        /// 0、未放卡或卡片放置不正确时
        /// </returns>
        [DllImport("termb.dll")]
        public static extern int CVR_Authenticate();

        /// <summary>
        ///读取身份证卡片内容
        /// </summary>
        /// <param name="active">
        /// 1、生成文字WZ.TXT、相片数据XP.WLT和相片ZP.BMP(解码)
        /// 2、生成文字WZ.TXT和相片数据XP.WLT
        /// 3、生成最新住址NEWADD.TXT（卡无最新地址则生成空文件）
        /// 4、生成WZ.TXT(解码)，相片ZP.BMP(解码)
        /// 5、芯片管理号IINSNDN.bin
        /// 6、以设备唯一标志号，生成文字WZ.TXT(解码)，相片XP.BMP(解码)（用于终端网络环境）
        /// </param>
        /// <returns>1正确0错误</returns>
        [DllImport("termb.dll")]
        public static extern int CVR_Read_Content(int active);
        #endregion

        public CV100UReader()
        {
        }

        public delegate void ReadICCardComplete(IDCard card);
        public event ReadICCardComplete AfterReadICCardComplete;

        public int Init()
        {
            int usePort = -1;
            //检测usb口的机具连接，必须先检测usb
            for (int port = 1001; port <= 1016; port++)
            {
                int result = CVR_InitComm(port);
                if (result == 1)
                {
                    usePort = port;
                    break;
                }
            }
            if (usePort == -1)
            {
                throw new Exception("初始化二代身份证读卡器出错！");
                return -1;
            }
            if (CVR_Authenticate() == 0)
            {
                throw new Exception("认证二代身份证读卡器出错！");
                return -1;
            }
            hasInit = true;
            return usePort;
        }

        public void Close()
        {
            if (CVR_CloseComm() == 0)
            {
                throw new Exception("关闭卡出错！");
            }
        }

        private bool hasInit = false;

        /// <summary>
        /// 读取身份证信息
        /// </summary>
        public void Read()
        {
            if (!this.hasInit)
            {
                this.Init();
            }
            IDCard card = new IDCard();
            if (CVR_Read_Content(1) == 0)
            {
                throw new Exception("未放卡或卡片放置不正确！");
            }

        }

        public void ReadFromFile(IDCard card)
        {
            FileInfo f = new FileInfo("wz.txt");
            FileStream fs = f.OpenRead();
            byte[] bt = new byte[fs.Length];
            fs.Read(bt, 0, (int)fs.Length);
            fs.Close();

            string str = System.Text.UnicodeEncoding.Unicode.GetString(bt);

            card.Name = System.Text.UnicodeEncoding.Unicode.GetString(bt, 0, 30).Trim();
            card.Sex_Code = System.Text.UnicodeEncoding.Unicode.GetString(bt, 30, 2).Trim();
            card.NATION_Code = System.Text.UnicodeEncoding.Unicode.GetString(bt, 32, 4).Trim();
            string strBird = System.Text.UnicodeEncoding.Unicode.GetString(bt, 36, 16).Trim();
            card.BIRTH = Convert.ToDateTime(strBird.Substring(0, 4) + "年" + strBird.Substring(4, 2) + "月" + strBird.Substring(6) + "日");
            card.ADDRESS = System.Text.UnicodeEncoding.Unicode.GetString(bt, 52, 70).Trim();
            card.IDC = System.Text.UnicodeEncoding.Unicode.GetString(bt, 122, 36).Trim();
            card.REGORG = System.Text.UnicodeEncoding.Unicode.GetString(bt, 158, 30).Trim();
            string strTem = System.Text.UnicodeEncoding.Unicode.GetString(bt, 188, bt.GetLength(0) - 188).Trim();
            card.STARTDATE = Convert.ToDateTime(strTem.Substring(0, 4) + "年" + strTem.Substring(4, 2) + "月" + strTem.Substring(6, 2) + "日");
            strTem = strTem.Substring(8);
            if (strTem.Trim() != "长期")
            {
                card.ENDDATE = Convert.ToDateTime(strTem.Substring(0, 4) + "年" + strTem.Substring(4, 2) + "月" + strTem.Substring(6, 2) + "日");
            }
            else
            {
                card.ENDDATE = DateTime.MaxValue;
            }
            FileInfo objFile = null;
            objFile = new FileInfo("zp.bmp");
            if (objFile.Exists)
            {
                Image img = Image.FromFile("zp.bmp");
                card.PIC_Image = (Image)img.Clone();
                System.IO.MemoryStream m = new MemoryStream();
                img.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                card.PIC_Byte = m.ToArray();
                img.Dispose();
                img = null;
            }
        }

    }
}
