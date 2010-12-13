//----------------------------------------------------------------------------------------------------
//Name:	DATA_CONVERT
//Function:	Data type convertion
//Author:	
// Date:	
//----------------------------------------------------------------------------------------------------

using System;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Security;
using System.Net.Sockets;
using System.Web.Security;
using System.Data;
using System.Security.Cryptography;


namespace FT.Web.Tools
{
	/// <summary>
	/// 数据转换
	/// </summary>
	public class DATA_CONVERT
	{
		public DATA_CONVERT()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		static int[] _DayOfMonth={31,29,31,30,31,30,31,31,30,31,30,31};

		public static int[] DayOfMonth
		{
			get { return _DayOfMonth; }			
		}
		

		/// <summary>
		/// 在数组中查找某一字符串
		/// </summary>
		/// <param name="arr">被查找的数组</param>
		/// <param name="str">需查找的字符串</param>
		/// <returns>返回true表示查到；否则表示未查到</returns>
		public static bool StringArray_FindStr ( String[] arr , String str ) 
		{
			bool rt = false ;

			for ( int i = 0 ; i < arr.Length ; i ++ ) 
			{
				if ( arr[i] == str ) 
				{
					rt = true ;
					break ;
				}
						
			}
			return rt ;
		}

		/// <summary>
		/// 将字符串增加到字符串数组中
		/// </summary>
		/// <param name="arr">目的字符串型数组</param>
		/// <param name="str">需增加到目的字符串型数组中的字符串</param>
		public static void StringArray_AppendItem ( ref String[] arr , String str ) 
		{
			arr = StringArray_AppendItem ( arr , str ) ;
		}

		/// <summary>
		/// 将字符串增加到字符串数组中
		/// </summary>
		/// <param name="arr">字符串型数组</param>
		/// <param name="str">需增加到字符串型数组中的字符串</param>
		/// <returns>返回加入字符串后的数组，原字符串型数组不变</returns>
		public static String [] StringArray_AppendItem ( String[] arr , String str ) 
		{
			String [] l_arr = new String [arr.Length + 1] ;

			for ( int i = 0 ; i < arr.Length ; i ++ ) 
			{
				l_arr[i] = arr[i] ;
			}

			l_arr[arr.Length] = str ;

			return l_arr ;
		}

		/// <summary>
		/// 将对象转化为字符串
		/// </summary>
		/// <param name="var">需转化的对象</param>
		/// <returns>字符串</returns>
		public static String VarToStr( object var ) 
		{
			String rt = System.Convert.ToString( var ) ;

			if ( rt == null )
				rt = "" ;

			return rt ;
		}

		/// <summary>
		/// 判断字符串中是否为数字
		/// </summary>
		/// <param name="str">需判断的字符串</param>
		/// <returns>返回true表示是数字；返回false表示不是数字</returns>
		public static bool IsNumeric ( String str ) 
		{
			bool bRt = false ;
			try
			{
				System.Int32.Parse(str) ;
				bRt= true ;
			}
			catch ( Exception  )
			{
			
			}

			return bRt;
		}

		/// <summary>
		/// 将字符串转换为整型数
		/// </summary>
		/// <param name="str">需转换的字符串</param>
		/// <returns>整型数</returns>
		public static int StrToInt ( String str ) 
		{
			int iRt = 0 ;
			try
			{
				iRt = System.Int32.Parse(str) ;
			}
			catch ( Exception  )
			{
			
			}

			return iRt ;
		}

		/// <summary>
		/// 十进制对象转换成二进制字符串
		/// </summary>
		/// <param name="var">需转换的对象</param>
		/// <param name="num">需转换成的二进制数的位数</param>
		/// <returns>二进制字符串</returns>
		public static string BinaryToStr( object var, int num)
		{
			int iFlg = System.Convert.ToInt32( var);

			String strTmp = "" ;

			for ( int i = 0 ; i < num ; i ++ ) 
			{
				if ( ( iFlg & 1  ) != 0 )
				{
					//strTmp += "1" ;
					strTmp = "1"+strTmp;
				}
				else
				{
					//strTmp += "0" ;
					strTmp = "0"+strTmp;
				}

				iFlg = ( iFlg >> 1 ) ;
			}

			return strTmp;
		}

		/// <summary>
		/// 将二进制字符串转换成十进制数
		/// </summary>
		/// <param name="str">需转换的二进制字符串</param>
		/// <returns>十进制数</returns>
		public static int StrToBinary(string str)
		{
			int iFlg = 0;
			int iBit1 = 1 ;

			for(int i = str.Length - 1 ; i >= 0; i--)
			{
				if (str.Substring(i ,1) == "1")
					iFlg = iFlg | iBit1 ;
				else
					iFlg = iFlg & ( ~iBit1) ;

				iBit1 = iBit1 << 1 ;
			}

			return iFlg;
		}

		public static string convert(string s)
		{
			return(s);
			/*
			System.Text.Encoding enc_src = System.Text.Encoding.GetEncoding(28591); //ISO 8859-1 Western
			Encoding enc_des = System.Text.Encoding.GetEncoding(936);				//GB18030（简体中文）
			byte[] src = enc_src.GetBytes(s);			
			return (enc_des.GetString(src));			
			*/
		}
		
		
		public static string deconvert(string s)
		{
			return(s);
			/*
			System.Text.Encoding enc_src = System.Text.Encoding.GetEncoding(936); 
			Encoding enc_des = System.Text.Encoding.GetEncoding(28591); 
			byte[] src = enc_src.GetBytes(s);			
			return (enc_des.GetString(src));			
			*/
		}

		public static string CryptPasswd(string src)
		{
			if(src==null || src.Length<1) return null;
			src = src + System.Configuration.ConfigurationSettings.AppSettings["ICS.Core.OpSecret"];
			byte[] b = Encoding.ASCII.GetBytes(src);
			byte[] des = GetMD5Value(b);
			return(ToHexString(des));
		}

		public static string ToHexString(byte[] bytes) 
		{
			char[] chars = new char[bytes.Length * 2];
			for (int i = 0; i < bytes.Length; i++) 
			{
				int b = bytes[i];
				chars[i * 2] = hexDigits[b >> 4];
				chars[i * 2 + 1] = hexDigits[b & 0xF];
			}
			return new string(chars);
		}

		
		public static byte[] GetMD5Value(byte[] source )
		{
			if((source==null)||(source.Length ==0))
				throw new ArgumentException("source is not valid");

			ASCIIEncoding ae = new ASCIIEncoding(); 
			MD5 m = MD5.Create ();
			return m.ComputeHash (source); 
		}

		static char[] hexDigits = {   '0', '1', '2', '3', '4', '5', '6', '7',
									  '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};

		
		//转换IP地址
		public static string ToDotIp(string sip)
		{
			if(sip==null || sip.Length<1) return("");
			long uiip = 0;
			try
			{
				uiip = long.Parse(sip);
			}
			catch( Exception )
			{
				uiip = 0;
			}

			byte[] ipbyte=System.BitConverter.GetBytes(uiip);
			byte[] convbyte=new byte[4];
			convbyte[0] =ipbyte[3];
			convbyte[1] =ipbyte[2];
			convbyte[2] =ipbyte[1];
			convbyte[3] =ipbyte[0];
			uint  ipp=System.BitConverter.ToUInt32(convbyte,0);
			System.Net.IPAddress myip=new IPAddress((long)ipp);			
			return (myip.ToString());

		}
		public static uint  ReToNumIP(string ip)
		{
			if(ip==null || ip.Length<1) return(0);

			uint IP=0;
			byte[] addbyte=new byte[128];
			try
			{
				System.Net.IPAddress ipaddr=System.Net.IPAddress.Parse(ip);
				addbyte=ipaddr.GetAddressBytes();
				byte[] IPByte=new byte[4];
				IPByte[0]=addbyte[3];
				IPByte[1]=addbyte[2];
				IPByte[2]=addbyte[1];
				IPByte[3]=addbyte[0];
				IP=System.BitConverter.ToUInt32(IPByte, 0);
			}
			catch(System.Exception e1)
			{
				Tools.WriteLog("ICS AdminPortal", e1.ToString(), System.Diagnostics.EventLogEntryType.Error);
				return 0;
			}
			return (IP);
		}
		
		//生成随机密码
		public static string getRandPasswd()
		{
			Random random=new Random();
			string PasswordReturn = random.Next(100000,999999).ToString();
			return(PasswordReturn);
		}
		
		//把int型数据转换为4字节byte数组
		public static byte[] convIntTo(int ii)
		{
			byte[] aOut=new byte[4];
			aOut[0]=(byte)((ii >> 24) & 0xff);
			aOut[1]=(byte)((ii >> 16) & 0xff);
			aOut[2]=(byte)((ii >> 8)  & 0xff);
			aOut[3]=(byte)(ii & 0xff);
			return aOut;
		}

		//把uint型数据转换为4字节byte数组
		public static byte[] convIntTo(uint ii)
		{
			byte[] aOut=new byte[4];
			aOut[0]=(byte)((ii >> 24) & 0xff);
			aOut[1]=(byte)((ii >> 16) & 0xff);
			aOut[2]=(byte)((ii >> 8)  & 0xff);
			aOut[3]=(byte)(ii & 0xff);
			return aOut;
		}

		//把short型数据转换为2字节byte数组
		public static byte[] convShortTo(short ii)
		{
			byte[] aOut=new byte[2];
			aOut[0]=(byte)((ii >> 8)  & 0xff);
			aOut[1]=(byte)(ii & 0xff);
			return aOut;
		}

		public static int bytetoint(byte b)
		{ 
			return (b+256) % 256;
		}

		// 将4字节byte数组转换为int型数据
		public static int convToInt(byte[] aa) 
		{
			if (aa.Length !=4) return 0;
			int iRet = bytetoint(aa[3])+(bytetoint(aa[2])<<8)+(bytetoint(aa[1])<<16)+(bytetoint(aa[0])<<24);
			return iRet;
		}

		// 将2字节byte数组转换为short型数据
		public static short convToShort(byte[] aa) 
		{
			if (aa.Length !=2) return 0;
			int iRet = bytetoint(aa[1]) + (bytetoint(aa[0])<<8);
			return (short)iRet;
		}

		public static void WriteLog (string source, string message, System.Diagnostics.EventLogEntryType type)
		{
			try
			{
				EventLog.WriteEntry ("SDP", source + "\n" + message, type);
			}
			catch (Exception)
			{

			}
		}

		public static void WriteLog (string source, Exception e, System.Diagnostics.EventLogEntryType type)
		{
			try
			{
				EventLog.WriteEntry ("SDP", source + "\n" + e.ToString(), type);
			}
			catch (Exception)
			{

			}
		}

		public static string GetIP(string hostname)
		{
			try
			{
				System.Net.IPHostEntry IP = System.Net.Dns.GetHostByName(hostname);
				IPAddress[] address = IP.AddressList;
				String namehost=IP.HostName;
				return address[0].ToString();
			}
			catch (Exception e)
			{
				WriteLog("ICS UserPortal", e.ToString(), System.Diagnostics.EventLogEntryType.Error);
				return "error";
			}
		}

		/* 用户访问站点记录 
		 * 
		 * Added by wenyx
		 * 
		 * 2003.11.11
		 * */
		public static string accessFlagToStr(int accessFlag)
		{
			string sAccessFlag = "";
			switch(accessFlag)
			{
				case 0:sAccessFlag = "通过";break;
				case 1:sAccessFlag = "IP阻截";break;
				case 2:sAccessFlag = "URL阻截";break;
				case 3:sAccessFlag = "关键字阻截";break;
				case 4:sAccessFlag = "端口阻截";break;
			}
			return sAccessFlag;
		}

		/* 从TextBox取数值，空则返回0 
		 * 
		 * Added by wenyx
		 * 
		 * 2003.11.15
		 * */
		public static int getValue(string str) 
		{
			if(str != null && str.Length > 0) 
			{
				int iRet = 0;
				try
				{
					iRet = Int32.Parse(str);
				}
				catch(Exception)
				{
					iRet = 0;
				}
				return(iRet);
			}
			else
			{
				return 0;
			}
		}
		public static byte getByteValue(string str) 
		{
			if(str != null && str.Length > 0) 
			{
				return System.Byte.Parse(str);
			}
			else
			{
				return 0;
			}
		}
		
		// added by Shengly  2003-12-2
		// datagrid 绑定列中调用, 返回拒绝类型的具体含义
		public static string accessFlagToStr(string accessFlag)
		{
			string  sAccessFlag="";
			try
			{
				int iFlag = int.Parse(accessFlag);
				switch(iFlag)
				{
					case 1:sAccessFlag = "IP阻截";break;
					case 2:sAccessFlag = "URL阻截";break;
					case 3:sAccessFlag = "关键字阻截";break;
					case 4:sAccessFlag = "端口阻截";break;
					default :sAccessFlag ="不详"; break;
				}
			}
			catch
			{
				return "不详";
			}
			return sAccessFlag;
		}

		//返回访问类型的具体含义
		public static string accessTypeToStr(string accessType)
		{
			string sAccessType = "";
			try
			{
				int iFlag = int.Parse(accessType);
				switch(iFlag)
				{
					case 0:sAccessType = "过滤";break;
					case 1:sAccessType = "PUSH";break;
					case 2:sAccessType = "替换";break;
					default :sAccessType ="不详"; break;
				}
			}
			catch
			{
				return "不详";
			}
			return (sAccessType);
		}

		public static string MD5Url(string url)
		{
			if((url==null)||(url.Length ==0))
				throw new ArgumentException("url is not valid");
			url = FormsAuthentication.HashPasswordForStoringInConfigFile(url,"MD5");		
			return url; 
		}

		public static string ConvertTime(string sTime)
		{
			if((sTime==null)||(sTime.Length ==0))
				throw new ArgumentException("Time is not valid");
			string time = sTime;
			time = time.Insert(4,"-");
			time = time.Insert(7,"-");
			time = time.Insert(10," ");
			time = time.Insert(13,":");
			time = time.Insert(16,":");
			return time;
		}
	}
}
