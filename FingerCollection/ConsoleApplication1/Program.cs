using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Security;
using FT.Commons.WindowsService.SystemInfo;
using FT.Commons.Win32;
using System.Data.OracleClient;
using FT.DAL;
using FT.DAL.Oracle;
using System.Security.Cryptography;
using HiPiaoInterface;

namespace ConsoleApplication1
{
    class Program
    {
        public static sbyte[] ConvertToSbyte(byte[] arr)
        {
            sbyte[] Hash = new
          sbyte[arr.Length];
            int
          i = 0;
            foreach
          (byte b in
          arr)
            {
                Hash[i] = unchecked
            ((sbyte)b);
                i++;
            }
            return
          Hash;
        }
        public static string Encrypt(string source)
        {
            MD5 md5 = MD5.Create();//将源字符串转换成字节数组
            //byte[] soureBytes = System.Text.Encoding.UTF8.GetBytes(source);
            byte[] soureBytes = System.Text.Encoding.UTF8.GetBytes(source);
            //md5.co
            byte[] resultBytes = md5.ComputeHash(soureBytes);//将加密后的字节数组转换成字符串
            
            string result = null;
            
            for (int i = 0; i < resultBytes.Length; i++)
            { result = result + resultBytes[i].ToString("x2"); }
           // if (result.Length > 30)//如果超过30个字符，就截取前30个
           // { result = result.Substring(0, 30); }
            return result;

            
        }

        public static string md5One(string s)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] ss = md.ComputeHash(UnicodeEncoding.UTF8.GetBytes(s));
            return byteArrayToHexString(ss);
        }  


        private static string[] HexCode = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

        public static string byteToHexString(byte b)
        {
            int n = b;
            if (n < 0)
            {
                n = 256 + n;
            }
            int d1 = n / 16;
            int d2 = n % 16;
            return HexCode[d1] + HexCode[d2];
        }

        public static String byteArrayToHexString(byte[] b)
        {
            String result = "";
            for (int i = 0; i < b.Length; i++)
            {
                result = result + byteToHexString(b[i]);
            }
            return result;
        }  




        static void Main(string[] args)
        {
            for (int i = 0; i < 10;i++ )
                Console.WriteLine("随机产生6位随机码：" + HiPiaoInterface.RandomSmsHelper.GenerateNumberCode(6));
            //HiPiaoInterface.HipiaoTcpHelper.GetTicket();
            HiPiaoCache.GetDingXinTicket();
           // DingXinResponseObject.Parse("");
            Console.ReadLine();

            /*
拼装字符串=MEMBERID26c52c2e-69ae-102e-8c3d-001a4beef7e4fromclientHPMACHINEmobile13911139181normal2planIdb8695e80-065b-11e2-a9dc-001bb97ef1a4seatids4b45e880-f01f-11e0-98ca-001bb97ef1a4,4b711730-f01f-11e0-98ca-001bb97ef1a4
密码+卡号加密=f56174a3de82dd6016bd5dff2d770682
最终加密md5(r2+r1)=53d1205f9fddc1a3a1fc21f3880a4c84
             */
            string rr1 = "f56174a3de82dd6016bd5dff2d770682";
            string rr2   = "MEMBERID26c52c2e-69ae-102e-8c3d-001a4beef7e4fromclientHPMACHINEmobile13911139181normal2planIdb8695e80-065b-11e2-a9dc-001bb97ef1a4seatids4b45e880-f01f-11e0-98ca-001bb97ef1a4,4b711730-f01f-11e0-98ca-001bb97ef1a4";
           // string rr2   = "MEMBERID26c52c2e-69ae-102e-8c3d-001a4beef7e4fromclientHPMACHINEmobile13911139181normal2planidb8695e80-065b-11e2-a9dc-001bb97ef1a4seatids4b45e880-f01f-11e0-98ca-001bb97ef1a4,4b711730-f01f-11e0-98ca-001bb97ef1a4";
                          //MEMBERID26c52c2e-69ae-102e-8c3d-001a4beef7e4fromclientHPMACHINEmobile13911139181normal2planIdb8695e80-065b-11e2-a9dc-001bb97ef1a4seatids4b45e880-f01f-11e0-98ca-001bb97ef1a4,4b711730-f01f-11e0-98ca-001bb97ef1a4

            Console.WriteLine("最终加密结果rr1+rr2为:" + Encrypt(rr2+rr1));
            ISecurity md5 = new MD5Security();
            //1b8dc01720fc2b67ad19a3c526c7bca2
            Console.WriteLine("最终加密结果为:"+Encrypt("789001"));
            string menberid="26c52c2e-69ae-102e-8c3d-001a4beef7e4";
            string mobile="18618237773";
            string count="4";
            string planid="c81f8af0-fb63-11e1-a9dc-001bb97ef1a4@@6";
            string seatv="9be8e070-8acb-11e1-b245-001bb97ef1a4,9be81d20-8acb-11e1-b245-001bb97ef1a4,9be86b40-8acb-11e1-b245-001bb97ef1a4,9be9cad0-8acb-11e1-b245-001bb97ef1a4";
            string fromclient="ANDROID";
            string pwd="789001";
            string hipiaocard = "26c52c2e69";
             String r1 = "MEMBERID" + menberid+
                         "fromclient" + fromclient+
                        "mobile" + mobile +
                        "normal" + count +
                        "planId" + planid +
                        "seatids" + seatv
                       
                        ;
            //String r2 = md5.Encrypt(md5.Encrypt(md5.Encrypt(pwd)) +hipiaocard);
            //String r3 = md5.Encrypt(r1 + r2);
             Console.WriteLine("r1==" + r1);
            String r2 = Encrypt(Encrypt(Encrypt(pwd)) +hipiaocard);
            Console.WriteLine("r2=="+r2);
             String tmp=r1+r2;
             Console.WriteLine("tmp==" + tmp);
             //MD5Tester tester = new MD5Tester();
            // Console.WriteLine("临时加密结果为：" + MD5Tester.Encrypt(tmp,32));
             Console.WriteLine("临时加密结果为：" + md5One(tmp));
            String r3 = Encrypt(r1 + r2);
            Console.WriteLine("r3==" + r3);
            String r4 = "MEMBERID=" + menberid + "&mobile="
                    +mobile + "&normal="
                    + count + "&planId="
                    + planid + "&seatids=" + seatv
                    + "&fromclient" + fromclient;
            //String query = r4 + "&pass=" + r3;
            String query = r4 + "&pass=" + r3;
#if DEBUG
            Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "发送购票内容为：" + query);
#endif
            //9457ea0b240e8dfaa85622d371330f89
            //MEMBERID=&mobile=18618237773&normal=4&planId=&seatids=&fromclient&pass=

           // TestConnection2(10000);

            /* 
             * 3D3514F23F37E13A 丰大驾校
             * 4D64496ADCEF53E0 安泰驾校
             * 13EE4553EEF0DF7E 市驾培中心
             * A59B773F9C3AA159 惠东平安
             * C4FA4E8E43E6A92F 惠东怡辉
             * 70C1D30CC159B03B 博罗鸿信
             * A60793889949C6F6 光大驾校
             * 23762878906B059C 亮丽驾校
             * AD8045BF9592308E 博罗鸿信
             * 3D00BF143CC95448 环球驾校
             * F1844D78F2236926 宏达驾校
             * 50B4238104DABA1C 
             * E48EF54511ED7D4F 市驾培中心
             * 7D66505102C8DB25 隆辉驾校
             * 84A883D2309E661D 隆辉驾校
             * DCA698218706CA2B 博罗鸿信
             * C3F979CF15706C39 金峰驾校


          
        
            ComputerMonitorHelper helper = new ComputerMonitorHelper();
              helper.CheckIsOpenPort(3389);
              helper.CheckIsOpenPort("192.168.1.10",3389);
              //FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.ExDiskPluginMonitorService("CDEF", 1000);
              //FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.NetworkMonitorService( 1000);
             // FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.SystemServiceMonitorService(30000);
             // FT.Commons.WindowsService.BaseWindowService serv = new FT.Commons.WindowsService.ProcessMonitorService(30000);
            
            //  serv.DoTask();
              //ComputerInitHelper.InitFolderMd5("Windows Xp","Sp3","D:\\自助终端","D:\\自助终端");
             // ComputerInitHelper.InitSystemServices();
              //ComputerInitHelper.InitSystemNetworkCard();
              Console.ReadLine();
             */
            //ISecurity md5 = new MD5Security();
              ISecurity sec = FT.Commons.Security.SecurityFactory.GetSecurity();
              //string hardwarecode=FT.Commons.Tools.HardwareManager.GetMachineCode();
             // string hardwarecode = "C3F979CF15706C39";
              Console.WriteLine("请输入机器码并回车：");
              string hardwarecode = Console.ReadLine();

              //一友驾校
              //E7A7CA598DDDAFA6
             // string company = "金峰驾校";
              Console.WriteLine("请输入授权用户名称并回车：");
              string company = Console.ReadLine();
              Console.WriteLine("注册码生成结果为->" + md5.Encrypt(sec.Encrypt(hardwarecode + company + hardwarecode)));

            /*  string path = Environment.CurrentDirectory + "//success.wav";
              SystemDefine.PlaySound(path, 0, SystemDefine.SND_ASYNC | SystemDefine.SND_FILENAME);//播放音乐
              //FT.Commons.Tools.WindowsPrinterHelper.LoopPrinter();
              string printer = @"\\192.168.1.150\Brother DCP-7030 Printer";
           // Console.WriteLine("打印机状态为："+FT.Commons.Tools.WindowsPrinterHelper.GetPrinterStat(printer).ToString());

            string cmd = ""+(char)(27)+(char)(33)+(char)(10)+"模";
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(cmd);
            for (int i = 0; i < mybyte.Length; i++)
            {
                Console.WriteLine(i+"="+mybyte[i]);
            }
                Console.ReadLine();
             * */
              Console.ReadLine();
           
        }

        public static void TestConnection2(int num)
        {
            IDataAccess accessOracle = new OracleDataHelper("oradrv","aspnet", "stjj117");
            Console.WriteLine(System.DateTime.Now.ToLocalTime().ToString() + "开始执行");
            for (int i = 0; i < num; i++)
            {
                try
                {
                    string sql= "insert into table_test(name,sex) values('name" + i.ToString() + "','male')";
                    accessOracle.SelectDataTable("select 1 from dual","tmp");
                   // accessOracle.ExecuteSql(sql);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("执行到第几次打开关闭连接出现异常-》" + i.ToString());
                    Console.WriteLine(e.ToString());
                    break;

                }
            }
            Console.WriteLine(System.DateTime.Now.ToLocalTime().ToString() + "执行完毕");
            Console.ReadLine();
        }

        const int BITS_TO_A_BYTE = 8;
  const int BYTES_TO_A_WORD = 4;
  const int BITS_TO_A_WORD = 32; 
  private static long[] m_lOnBits = new long[30 + 1];
  private static long[] m_l2Power = new long[30 + 1];

  private static long LShift(long lValue, long iShiftBits)
  {
   long LShift = 0;
   if (iShiftBits == 0)
   {
    LShift = lValue;
    return LShift;
   }
   else
   {
    if( iShiftBits == 31)
    {
     if (Convert.ToBoolean(lValue & 1))
     {
      LShift = 0x80000000;
     }
     else
     {
      LShift = 0;
     }
     return LShift;
    }
    else
    {
     if( iShiftBits < 0 || iShiftBits > 31)
     {
      // Err.Raise 6;
     }
    }
   }

   if (Convert.ToBoolean((lValue & m_l2Power[31 - iShiftBits])))
   {
    LShift = ((lValue & m_lOnBits[31 - (iShiftBits + 1)]) * m_l2Power[iShiftBits]) | 0x80000000;
   }
   else
   {
    LShift = ((lValue & m_lOnBits[31 - iShiftBits]) * m_l2Power[iShiftBits]);
   }

   return LShift;
  }

  private static long RShift(long lValue, long iShiftBits)
  {
   long RShift = 0;
   if (iShiftBits == 0)
   {
    RShift = lValue;
    return RShift;
   }
   else
   {
    if( iShiftBits == 31)
    {
     if (Convert.ToBoolean(lValue & 0x80000000))
     {
      RShift = 1;
     }
     else
     {
      RShift = 0;
     }
     return RShift;
    }
    else
    {
     if( iShiftBits < 0 || iShiftBits > 31)
     {
      // Err.Raise 6;
     }
    }
   }

   RShift = (lValue & 0x7FFFFFFE) / m_l2Power[iShiftBits];

   if (Convert.ToBoolean((lValue & 0x80000000)))
   {
    RShift = (RShift | (0x40000000 / m_l2Power[iShiftBits - 1]));
   }

   return RShift;
  }

  private static long RotateLeft(long lValue, long iShiftBits)
  {
   long RotateLeft = 0;
   RotateLeft = LShift(lValue, iShiftBits) | RShift(lValue, (32 - iShiftBits));
   return RotateLeft;
  }

  private static long AddUnsigned(long lX, long lY)
  {
   long AddUnsigned = 0;
   long lX4 = 0;
   long lY4 = 0;
   long lX8 = 0;
   long lY8 = 0;
   long lResult = 0;

   lX8 = lX & 0x80000000;
   lY8 = lY & 0x80000000;
   lX4 = lX & 0x40000000;
   lY4 = lY & 0x40000000;

   lResult = (lX & 0x3FFFFFFF) + (lY & 0x3FFFFFFF);
   if (Convert.ToBoolean(lX4 & lY4))
   {
    lResult = lResult ^ 0x80000000 ^ lX8 ^ lY8;
   }
   else if( Convert.ToBoolean(lX4 | lY4))
   {
    if (Convert.ToBoolean(lResult & 0x40000000))
    {
     lResult = lResult ^ 0xC0000000 ^ lX8 ^ lY8;
    }
    else
    {
     lResult = lResult ^ 0x40000000 ^ lX8 ^ lY8;
    }
   }
   else
   {
    lResult = lResult ^ lX8 ^ lY8;
   }
   AddUnsigned = lResult;
   return AddUnsigned;
  }

  private static long md5_F(long x, long y, long z)
  {
   long md5_F = 0;
   md5_F = (x & y) | (( ~x) & z);
   return md5_F;
  }

  private static long md5_G(long x, long y, long z)
  {
   long md5_G = 0;
   md5_G = (x & z) | (y & ( ~z));
   return md5_G;
  }

  private static long md5_H(long x, long y, long z)
  {
   long md5_H = 0;
   md5_H = (x ^ y ^ z);
   return md5_H;
  }

  private static long md5_I(long x, long y, long z)
  {
   long md5_I = 0;
   md5_I = (y ^ (x | (~z)));
   return md5_I;
  }

  private static void md5_FF(ref long a, long b, long c, long d, long x, long s, long ac)
  {
   a = AddUnsigned(a, AddUnsigned(AddUnsigned(md5_F(b, c, d), x), ac));
   a = RotateLeft(a, s);
   a = AddUnsigned(a, b);
  }

  private static void md5_GG(ref long a, long b, long c, long d, long x, long s, long ac)
  {
   a = AddUnsigned(a, AddUnsigned(AddUnsigned(md5_G(b, c, d), x), ac));
   a = RotateLeft(a, s);
   a = AddUnsigned(a, b);
  }

  private static void md5_HH(ref long a, long b, long c, long d, long x, long s, long ac)
  {
   a = AddUnsigned(a, AddUnsigned(AddUnsigned(md5_H(b, c, d), x), ac));
   a = RotateLeft(a, s);
   a = AddUnsigned(a, b);
  }

  private static void md5_II(ref long a, long b, long c, long d, long x, long s, long ac)
  {
   a = AddUnsigned(a, AddUnsigned(AddUnsigned(md5_I(b, c, d), x), ac));
   a = RotateLeft(a, s);
   a = AddUnsigned(a, b);
  }

  private static long[] ConvertToWordArray(string sMessage)
  {
   long[] ConvertToWordArray = null;
   int lMessageLength = 0;
   int lNumberOfWords = 0;
   long[] lWordArray = null;
   int lBytePosition = 0;
   int lByteCount = 0;
   int lWordCount = 0;

   const int MODULUS_BITS = 512;
   const int CONGRUENT_BITS = 448;

   lMessageLength = sMessage.Length;
   lNumberOfWords = (((lMessageLength + ((MODULUS_BITS - CONGRUENT_BITS) / BITS_TO_A_BYTE)) / (MODULUS_BITS / BITS_TO_A_BYTE)) + 1) * (MODULUS_BITS / BITS_TO_A_WORD);
   lWordArray = new long[lNumberOfWords];

   lBytePosition = 0;
   lByteCount = 0;

   while(lByteCount < lMessageLength)
   {
    lWordCount = lByteCount / BYTES_TO_A_WORD;
    lBytePosition = (lByteCount % BYTES_TO_A_WORD) * BITS_TO_A_BYTE;
    lWordArray[lWordCount] = lWordArray[lWordCount] | LShift(Convert.ToByte(sMessage.Substring(lByteCount, 1).ToCharArray()[0]), lBytePosition);
    lByteCount = lByteCount + 1;
   }

   lWordCount = lByteCount / BYTES_TO_A_WORD;
   lBytePosition = (lByteCount % BYTES_TO_A_WORD) * BITS_TO_A_BYTE;
   lWordArray[lWordCount] = lWordArray[lWordCount] | LShift(0x80, lBytePosition);
   lWordArray[lNumberOfWords - 2] = LShift(lMessageLength, 3);
   lWordArray[lNumberOfWords - 1] = RShift(lMessageLength, 29);
   ConvertToWordArray = lWordArray;

   return ConvertToWordArray;
  }

  private static string WordToHex(long lValue)
  {
   string WordToHex = "";
   long lByte = 0;
   int lCount = 0;
   for(lCount = 0; lCount <= 3; lCount++)
   {
    lByte = RShift(lValue, lCount * BITS_TO_A_BYTE) & m_lOnBits[BITS_TO_A_BYTE - 1];
    WordToHex = WordToHex + (("0" + ToHex(lByte)).Substring(("0" + ToHex(lByte)).Length - 2));
   }
   return WordToHex;
  }

 private static string ToHex(long dec)
  {
   string strhex = "";
   while(dec > 0)
   {
    strhex = tohex(dec % 16) + strhex;
    dec = dec / 16;
   }
   return strhex;
  }
  
  private static string tohex(long hex)
  {
   string strhex = "";
   switch(hex)
   {
    case 10: strhex = "a"; break;
    case 11: strhex = "b"; break;
    case 12: strhex = "c"; break;
    case 13: strhex = "d"; break;
    case 14: strhex = "e"; break;
    case 15: strhex = "f"; break;
    default : strhex = hex.ToString(); break;
   }
   return strhex;
  }

  public static string Encrypt2(string source)
  {
      return Encrypt2(source, 32);
  }
  public static string Encrypt2(string sMessage, int stype)
  {
   string MD5 = "";
   
   for(int i=0; i<=30; i++)
   {
    m_lOnBits[i] = Convert.ToInt64(Math.Pow(2, i+1) -1);
    m_l2Power[i] = Convert.ToInt64(Math.Pow(2, i));
   }

   long[] x = null;
   int k = 0;
   long AA = 0;
   long BB = 0;
   long CC = 0;
   long DD = 0;
   long a = 0;
   long b = 0;
   long c = 0;
   long d = 0;

   const int S11 = 7;
   const int S12 = 12;
   const int S13 = 17;
   const int S14 = 22;
   const int S21 = 5;
   const int S22 = 9;
   const int S23 = 14;
   const int S24 = 20;
   const int S31 = 4;
   const int S32 = 11;
   const int S33 = 16;
   const int S34 = 23;
   const int S41 = 6;
   const int S42 = 10;
   const int S43 = 15;
   const int S44 = 21;

   x = ConvertToWordArray(sMessage);

   a = 0x67452301;
   b = 0xEFCDAB89;
   c = 0x98BADCFE;
   d = 0x10325476;

   for(k = 0; k < x.Length; k += 16)
   {
    AA = a;
    BB = b;
    CC = c;
    DD = d;

    md5_FF(ref a, b, c, d, x[k + 0], S11, 0xD76AA478);
    md5_FF(ref d, a, b, c, x[k + 1], S12, 0xE8C7B756);
    md5_FF(ref c, d, a, b, x[k + 2], S13, 0x242070DB);
    md5_FF(ref b, c, d, a, x[k + 3], S14, 0xC1BDCEEE);
    md5_FF(ref a, b, c, d, x[k + 4], S11, 0xF57C0FAF);
    md5_FF(ref d, a, b, c, x[k + 5], S12, 0x4787C62A);
    md5_FF(ref c, d, a, b, x[k + 6], S13, 0xA8304613);
    md5_FF(ref b, c, d, a, x[k + 7], S14, 0xFD469501);
    md5_FF(ref a, b, c, d, x[k + 8], S11, 0x698098D8);
    md5_FF(ref d, a, b, c, x[k + 9], S12, 0x8B44F7AF);
    md5_FF(ref c, d, a, b, x[k + 10], S13, 0xFFFF5BB1);
    md5_FF(ref b, c, d, a, x[k + 11], S14, 0x895CD7BE);
    md5_FF(ref a, b, c, d, x[k + 12], S11, 0x6B901122);
    md5_FF(ref d, a, b, c, x[k + 13], S12, 0xFD987193);
    md5_FF(ref c, d, a, b, x[k + 14], S13, 0xA679438E);
    md5_FF(ref b, c, d, a, x[k + 15], S14, 0x49B40821);
    md5_GG(ref a, b, c, d, x[k + 1], S21, 0xF61E2562);
    md5_GG(ref d, a, b, c, x[k + 6], S22, 0xC040B340);
    md5_GG(ref c, d, a, b, x[k + 11], S23, 0x265E5A51);
    md5_GG(ref b, c, d, a, x[k + 0], S24, 0xE9B6C7AA);
    md5_GG(ref a, b, c, d, x[k + 5], S21, 0xD62F105D);
    md5_GG(ref d, a, b, c, x[k + 10], S22, 0x2441453);
    md5_GG(ref c, d, a, b, x[k + 15], S23, 0xD8A1E681);
    md5_GG(ref b, c, d, a, x[k + 4], S24, 0xE7D3FBC8);
    md5_GG(ref a, b, c, d, x[k + 9], S21, 0x21E1CDE6);
    md5_GG(ref d, a, b, c, x[k + 14], S22, 0xC33707D6);
    md5_GG(ref c, d, a, b, x[k + 3], S23, 0xF4D50D87);
    md5_GG(ref b, c, d, a, x[k + 8], S24, 0x455A14ED);
    md5_GG(ref a, b, c, d, x[k + 13], S21, 0xA9E3E905);
    md5_GG(ref d, a, b, c, x[k + 2], S22, 0xFCEFA3F8);
    md5_GG(ref c, d, a, b, x[k + 7], S23, 0x676F02D9);
    md5_GG(ref b, c, d, a, x[k + 12], S24, 0x8D2A4C8A);
    md5_HH(ref a, b, c, d, x[k + 5], S31, 0xFFFA3942);
    md5_HH(ref d, a, b, c, x[k + 8], S32, 0x8771F681);
    md5_HH(ref c, d, a, b, x[k + 11], S33, 0x6D9D6122);
    md5_HH(ref b, c, d, a, x[k + 14], S34, 0xFDE5380C);
    md5_HH(ref a, b, c, d, x[k + 1], S31, 0xA4BEEA44);
    md5_HH(ref d, a, b, c, x[k + 4], S32, 0x4BDECFA9);
    md5_HH(ref c, d, a, b, x[k + 7], S33, 0xF6BB4B60);
    md5_HH(ref b, c, d, a, x[k + 10], S34, 0xBEBFBC70);
    md5_HH(ref a, b, c, d, x[k + 13], S31, 0x289B7EC6);
    md5_HH(ref d, a, b, c, x[k + 0], S32, 0xEAA127FA);
    md5_HH(ref c, d, a, b, x[k + 3], S33, 0xD4EF3085);
    md5_HH(ref b, c, d, a, x[k + 6], S34, 0x4881D05);
    md5_HH(ref a, b, c, d, x[k + 9], S31, 0xD9D4D039);
    md5_HH(ref d, a, b, c, x[k + 12], S32, 0xE6DB99E5);
    md5_HH(ref c, d, a, b, x[k + 15], S33, 0x1FA27CF8);
    md5_HH(ref b, c, d, a, x[k + 2], S34, 0xC4AC5665);
    md5_II(ref a, b, c, d, x[k + 0], S41, 0xF4292244);
    md5_II(ref d, a, b, c, x[k + 7], S42, 0x432AFF97);
    md5_II(ref c, d, a, b, x[k + 14], S43, 0xAB9423A7);
    md5_II(ref b, c, d, a, x[k + 5], S44, 0xFC93A039);
    md5_II(ref a, b, c, d, x[k + 12], S41, 0x655B59C3);
    md5_II(ref d, a, b, c, x[k + 3], S42, 0x8F0CCC92);
    md5_II(ref c, d, a, b, x[k + 10], S43, 0xFFEFF47D);
    md5_II(ref b, c, d, a, x[k + 1], S44, 0x85845DD1);
    md5_II(ref a, b, c, d, x[k + 8], S41, 0x6FA87E4F);
    md5_II(ref d, a, b, c, x[k + 15], S42, 0xFE2CE6E0);
    md5_II(ref c, d, a, b, x[k + 6], S43, 0xA3014314);
    md5_II(ref b, c, d, a, x[k + 13], S44, 0x4E0811A1);
    md5_II(ref a, b, c, d, x[k + 4], S41, 0xF7537E82);
    md5_II(ref d, a, b, c, x[k + 11], S42, 0xBD3AF235);
    md5_II(ref c, d, a, b, x[k + 2], S43, 0x2AD7D2BB);
    md5_II(ref b, c, d, a, x[k + 9], S44, 0xEB86D391);

    a = AddUnsigned(a, AA);
    b = AddUnsigned(b, BB);
    c = AddUnsigned(c, CC);
    d = AddUnsigned(d, DD);
   }

   if (stype == 32)
   {
    MD5 = ((((WordToHex(a)) + (WordToHex(b))) + (WordToHex(c))) + (WordToHex(d))).ToLower();
   }
   else
   {
    MD5 = ((WordToHex(b)) + (WordToHex(c))).ToLower();
   }
   return MD5;
    }






        public static void TestConnection(int num)
        {
            OracleConnection conn = new OracleConnection(@"Data Source=(

DESCRIPTION =

    (ADDRESS_LIST =

      (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))

    )

    (CONNECT_DATA =

      (SERVICE_NAME = oradrv)

    )

);user ID=aspnet;Password=stjj117
");
            Console.WriteLine(System.DateTime.Now.ToLocalTime().ToString() + "开始执行");
            for (int i = 0; i < num; i++)
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "insert into table_test(name,sex) values('name"+i.ToString()+"','male')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("执行到第几次打开关闭连接出现异常-》"+i.ToString());
                    Console.WriteLine(e.ToString());
                    break;

                }
            }
            Console.WriteLine(System.DateTime.Now.ToLocalTime().ToString() + "执行完毕");
                Console.ReadLine();
        }
    
    }
}
