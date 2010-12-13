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
	/// ����ת��
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
		/// �������в���ĳһ�ַ���
		/// </summary>
		/// <param name="arr">�����ҵ�����</param>
		/// <param name="str">����ҵ��ַ���</param>
		/// <returns>����true��ʾ�鵽�������ʾδ�鵽</returns>
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
		/// ���ַ������ӵ��ַ���������
		/// </summary>
		/// <param name="arr">Ŀ���ַ���������</param>
		/// <param name="str">�����ӵ�Ŀ���ַ����������е��ַ���</param>
		public static void StringArray_AppendItem ( ref String[] arr , String str ) 
		{
			arr = StringArray_AppendItem ( arr , str ) ;
		}

		/// <summary>
		/// ���ַ������ӵ��ַ���������
		/// </summary>
		/// <param name="arr">�ַ���������</param>
		/// <param name="str">�����ӵ��ַ����������е��ַ���</param>
		/// <returns>���ؼ����ַ���������飬ԭ�ַ��������鲻��</returns>
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
		/// ������ת��Ϊ�ַ���
		/// </summary>
		/// <param name="var">��ת���Ķ���</param>
		/// <returns>�ַ���</returns>
		public static String VarToStr( object var ) 
		{
			String rt = System.Convert.ToString( var ) ;

			if ( rt == null )
				rt = "" ;

			return rt ;
		}

		/// <summary>
		/// �ж��ַ������Ƿ�Ϊ����
		/// </summary>
		/// <param name="str">���жϵ��ַ���</param>
		/// <returns>����true��ʾ�����֣�����false��ʾ��������</returns>
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
		/// ���ַ���ת��Ϊ������
		/// </summary>
		/// <param name="str">��ת�����ַ���</param>
		/// <returns>������</returns>
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
		/// ʮ���ƶ���ת���ɶ������ַ���
		/// </summary>
		/// <param name="var">��ת���Ķ���</param>
		/// <param name="num">��ת���ɵĶ���������λ��</param>
		/// <returns>�������ַ���</returns>
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
		/// ���������ַ���ת����ʮ������
		/// </summary>
		/// <param name="str">��ת���Ķ������ַ���</param>
		/// <returns>ʮ������</returns>
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
			Encoding enc_des = System.Text.Encoding.GetEncoding(936);				//GB18030���������ģ�
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

		
		//ת��IP��ַ
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
		
		//�����������
		public static string getRandPasswd()
		{
			Random random=new Random();
			string PasswordReturn = random.Next(100000,999999).ToString();
			return(PasswordReturn);
		}
		
		//��int������ת��Ϊ4�ֽ�byte����
		public static byte[] convIntTo(int ii)
		{
			byte[] aOut=new byte[4];
			aOut[0]=(byte)((ii >> 24) & 0xff);
			aOut[1]=(byte)((ii >> 16) & 0xff);
			aOut[2]=(byte)((ii >> 8)  & 0xff);
			aOut[3]=(byte)(ii & 0xff);
			return aOut;
		}

		//��uint������ת��Ϊ4�ֽ�byte����
		public static byte[] convIntTo(uint ii)
		{
			byte[] aOut=new byte[4];
			aOut[0]=(byte)((ii >> 24) & 0xff);
			aOut[1]=(byte)((ii >> 16) & 0xff);
			aOut[2]=(byte)((ii >> 8)  & 0xff);
			aOut[3]=(byte)(ii & 0xff);
			return aOut;
		}

		//��short������ת��Ϊ2�ֽ�byte����
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

		// ��4�ֽ�byte����ת��Ϊint������
		public static int convToInt(byte[] aa) 
		{
			if (aa.Length !=4) return 0;
			int iRet = bytetoint(aa[3])+(bytetoint(aa[2])<<8)+(bytetoint(aa[1])<<16)+(bytetoint(aa[0])<<24);
			return iRet;
		}

		// ��2�ֽ�byte����ת��Ϊshort������
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

		/* �û�����վ���¼ 
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
				case 0:sAccessFlag = "ͨ��";break;
				case 1:sAccessFlag = "IP���";break;
				case 2:sAccessFlag = "URL���";break;
				case 3:sAccessFlag = "�ؼ������";break;
				case 4:sAccessFlag = "�˿����";break;
			}
			return sAccessFlag;
		}

		/* ��TextBoxȡ��ֵ�����򷵻�0 
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
		// datagrid �����е���, ���ؾܾ����͵ľ��庬��
		public static string accessFlagToStr(string accessFlag)
		{
			string  sAccessFlag="";
			try
			{
				int iFlag = int.Parse(accessFlag);
				switch(iFlag)
				{
					case 1:sAccessFlag = "IP���";break;
					case 2:sAccessFlag = "URL���";break;
					case 3:sAccessFlag = "�ؼ������";break;
					case 4:sAccessFlag = "�˿����";break;
					default :sAccessFlag ="����"; break;
				}
			}
			catch
			{
				return "����";
			}
			return sAccessFlag;
		}

		//���ط������͵ľ��庬��
		public static string accessTypeToStr(string accessType)
		{
			string sAccessType = "";
			try
			{
				int iFlag = int.Parse(accessType);
				switch(iFlag)
				{
					case 0:sAccessType = "����";break;
					case 1:sAccessType = "PUSH";break;
					case 2:sAccessType = "�滻";break;
					default :sAccessType ="����"; break;
				}
			}
			catch
			{
				return "����";
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
