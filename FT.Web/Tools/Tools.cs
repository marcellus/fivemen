
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Collections;

using System.Web.Mail;

namespace FT.Web.Tools
{
	public class Tools
	{	
		static char[] hexDigits = {   '0', '1', '2', '3', '4', '5', '6', '7',
									  '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};
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

		/* 检查SQL语句的合法性，防止不安全的SQL被执行 */
		public static bool ValidSQL(string sql)
		{
			if(sql==null || sql.Length < 10) return(false);

			string sSql = sql.ToUpper();
			if(sSql.IndexOf("SELECT")<0 && sSql.IndexOf("INSERT")<0 && sSql.IndexOf("UPDATE")<0 && sSql.IndexOf("DELETE")<0)
			{
				WriteLog("SQL FORMATE ERROR", "INVALID SQL: \n" + sql, System.Diagnostics.EventLogEntryType.Error);
				return(false);
			}

			if(sSql.IndexOf("--")>=0) 
			{
				WriteLog("SQL FORMATE ERROR", "INVALID SQL: \n" + sql, System.Diagnostics.EventLogEntryType.Error);
				return(false);
			}
			return(true);
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


		public static byte[] GetMD5Value(byte[] source )
		{
			if((source==null)||(source.Length ==0))
				throw new ArgumentException("source is not valid");

			ASCIIEncoding ae = new ASCIIEncoding(); 
			MD5 m = MD5.Create ();
			return m.ComputeHash (source); 
		}

		public static string GetMD5Code(string source )
		{
			if((source==null)||(source.Length ==0)) return(null);				

			byte[] bsrc = Encoding.ASCII.GetBytes(source);
			byte[] benc = GetMD5Value( bsrc );
			return(ToHexString(benc));
		}

		public static byte[] GetSHA1Value(byte[] source )
		{
			if((source==null)||(source.Length ==0))
				throw new ArgumentException("source is not valid");

			ASCIIEncoding ae = new ASCIIEncoding(); 
			SHA1 s = SHA1.Create ();
			return s.ComputeHash (source); 
		}

		public static string GetSHA1Code(string source )
		{
			if((source==null)||(source.Length ==0)) return(null);				

			byte[] bsrc = Encoding.ASCII.GetBytes(source);
			byte[] benc = GetSHA1Value( bsrc );
			return(ToHexString(benc));
		}

		public static string GetBase64Value(string source)
		{
			try
			{
				byte[] by = Encoding.Default.GetBytes(source.ToCharArray()); 
				source = Convert.ToBase64String(by); 
			}
			catch(Exception)
			{
				return ("");
			}
			return source;
		}

		/// <summary>
		/// 描述：返回base64加密后字符串的源串
		/// </summary>
		/// <param name="source">加密后的数据</param>
		/// <returns>加密前的数据</returns>
		public static string  FromBase64Value(string source)
		{
			try
			{
				byte[] by = Convert.FromBase64String(source); 
				source = Encoding.Default.GetString(by);
			}
			catch(Exception)
			{
				return ("");
			}
			return source;
		}

		public static string GetUrlEncode(string source)
		{
			string Encode = System.Web.HttpUtility.UrlEncode(source,System.Text.Encoding.GetEncoding("utf-8"));
			return Encode;
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

		public static byte[] convIntTo(int ii)
		{
			byte[] aOut=new byte[4];
			aOut[0]=(byte)((ii >> 24) & 0xff);
			aOut[1]=(byte)((ii >> 16) & 0xff);
			aOut[2]=(byte)((ii >> 8)  & 0xff);
			aOut[3]=(byte)(ii & 0xff);
			return aOut;
		}

		public string convert(string s)
		{
			return(s);
			/*
			System.Text.Encoding enc_src = System.Text.Encoding.GetEncoding(28591); //(28591)
			Encoding enc_des = System.Text.Encoding.GetEncoding(936); 
			byte[] src = enc_src.GetBytes(s);   
			return ( enc_des.GetString( src ) );   
			*/
		}

		public string deconvert(string s)
		{
			return(s);
			/*
			System.Text.Encoding enc_src = System.Text.Encoding.GetEncoding(936); 
			Encoding enc_des = System.Text.Encoding.GetEncoding(28591); 
			byte[] src = enc_src.GetBytes(s);   
			return ( enc_des.GetString( src ) );   
			*/
		}

		//生成随机密码
		public static string getRandPasswd()
		{
			Random random=new Random();
			string PasswordReturn = random.Next(100000,999999).ToString();
			return(PasswordReturn);
		}

		public static uint  convertToIIP(string ip)
		{
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
				IP=System.BitConverter.ToUInt32(IPByte,0);//??????
			}
			catch(System.Exception e1)
			{
				Tools.WriteLog("ICS UserPortal", e1.ToString(), System.Diagnostics.EventLogEntryType.Error);
				return 0;
			}
			return IP;
		}

		public static string convertToSIP(int IP)
		{
			string ip="";
			try
			{
				/*
				byte[] ipbyte=System.BitConverter.GetBytes(IP);
				byte[] convbyte=new byte[4];
				convbyte[0] =ipbyte[3];
				convbyte[1] =ipbyte[2];
				convbyte[2] =ipbyte[1];
				convbyte[3] =ipbyte[0];
				uint  ipp=System.BitConverter.ToUInt32(convbyte,0);
				*/
				System.Net.IPAddress myip=new IPAddress((long)IP);
				ip=myip.ToString();
			}
			catch(System.Exception e1)
			{
				Tools.WriteLog("ICS UserPortal", e1.ToString(), System.Diagnostics.EventLogEntryType.Error);
			}
			return ip;

		}

		public static string convertToSIP(uint IP)
		{
			string ip="";
			try
			{
				byte[] ipbyte=System.BitConverter.GetBytes(IP);
				byte[] convbyte=new byte[4];
				convbyte[0] =ipbyte[3];
				convbyte[1] =ipbyte[2];
				convbyte[2] =ipbyte[1];
				convbyte[3] =ipbyte[0];
				uint  ipp=System.BitConverter.ToUInt32(convbyte,0);
				System.Net.IPAddress myip=new IPAddress((long)ipp);
				ip=myip.ToString();
			}
			catch(System.Exception e1)
			{
				Tools.WriteLog("ICS UserPortal", e1.ToString(), System.Diagnostics.EventLogEntryType.Error);
			}
			return ip;

		}

		public static string ToShortDate(DateTime mydate)
		{
			string mytime=mydate.ToShortDateString();
			return mytime;
		}

		public static void selectDropList(System.Web.UI.WebControls.DropDownList ddlList, string code)
		{
			if(code==null || ddlList==null) return;
			System.Web.UI.WebControls.ListItem crItem = null;
			crItem = ddlList.Items.FindByValue(code);
			if(crItem != null) 
			{
				ddlList.SelectedValue = code;
			}
			else 
			{
				ddlList.SelectedIndex = 0;
			}
			return;
		}

		public static void selectRadioButtonList(System.Web.UI.WebControls.RadioButtonList rblList, string code)
		{
			if(code==null || rblList==null) return;
			System.Web.UI.WebControls.ListItem crItem = null;
			crItem = rblList.Items.FindByValue(code);
			if(crItem != null) 
			{
				rblList.SelectedValue = code;
			}
			else 
			{
				rblList.SelectedIndex = 0;
			}
			return;
		}

		public static int getStrLength(string str)
		{
			if(str==null || str.Length==0) return(0);
			byte[] bstr = Encoding.ASCII.GetBytes(str);
			return(bstr.Length);
		}

		public static string substring(string str, int len)
		{
			if(str==null || str.Length==0 || len<1) return null;
			
			byte[] bstr = Encoding.ASCII.GetBytes(str);
			if(bstr.Length <= len) return (str);

			byte[] b1 = new byte[len];
			Array.Copy(bstr, 0, b1, 0, len);
	
			string s = Encoding.ASCII.GetString(b1);
			return(s);
		}

		// 根据域名解析出IP地址列表
		public static IPAddress[] ResolveIpByHostName(string hostname) 
		{
			if(hostname==null || hostname.Length<3) return null;
			try
			{
				IPHostEntry hostInfo = Dns.Resolve( hostname );
				IPAddress[] address = hostInfo.AddressList;			
				return(address);
			}
			catch (Exception e)
			{
				WriteLog("ICS AdminPortal", e.ToString(), System.Diagnostics.EventLogEntryType.Error);
				return null;
			}			
		}

		//获得本机IP  
		public static uint GetLocalIP()
		{
			try
			{
				uint   IP = 0 ;
				string hostname=System.Net.Dns.GetHostName();
				string ip= GetIP(hostname);
				IP= convertToIIP(ip);
				return IP;
			}
			catch (Exception e)
			{
				WriteLog("ICS AdminPortal", e.ToString(), System.Diagnostics.EventLogEntryType.Error);
				return 0;
			}	
			
		}

		//获取客户端IP
		public static uint GetClientIP(System.Web.HttpRequest request)
		{
			try
			{
				uint   IP = 0 ;
				string ip  =request.UserHostAddress;
				/*String[] arr1 = request.ServerVariables.AllKeys;
				for (int loop1 = 0; loop1 < arr1.Length; loop1++) 
				{
					String[] arr2=request.ServerVariables.GetValues(arr1[loop1]);
					arr2 = request.ServerVariables.GetValues("REMOTE_ADDR");
					arr2 = request.ServerVariables.GetValues("REMOTE_USER");
					s = arr2[1];
				}*/
				IP= convertToIIP(ip);
				return IP;
			}
			catch (Exception e)
			{
				WriteLog("ICS AdminPortal", e.ToString(), System.Diagnostics.EventLogEntryType.Error);
				return 0;
			}	

		}

		//比较两个string串(格式：以','间隔)，输出objList 相对srcList增加的同格式string串
		public static string CompareList(string srcList,string objList)
		{
			string[] OldList = srcList.Split(',');
			string[] NewList = objList.Split(',');
			string  outList = "";
			for(int i=0;i<NewList.Length;i++)
			{
				string index = NewList[i];
				bool  flag=true;
				for(int j=0;j<OldList.Length;j++)
				{
					if(OldList[j].Equals(index))
					{
						flag=false;
						break;
					}
				}
				if(flag)
				{
					outList+=index;
					outList+=",";
				}
			}
			return outList;
		}

		public static DateTime GetNowDateTime()
		{
			DateTime nowDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
			return nowDate;
		}

		//使用DES算法加密
		public static byte[] Crypt(byte[] source, byte[] key)
		{
			if (source==null || source.Length ==0 || key==null || key.Length==0)
			{
				throw new ArgumentException("Invalid Argument");
			}

			DESCryptoServiceProvider dsp =new DESCryptoServiceProvider();
			dsp.Mode = CipherMode.ECB;
		
			ICryptoTransform des = dsp.CreateEncryptor(key, null);

			try
			{
				return des.TransformFinalBlock(source,0,source.Length);
			}
			catch(Exception e1)
			{
				throw e1;
			}		

		}

		//使用DES算法解密
		public static byte[] Decrypt(byte[] source,byte[] key)
		{
			if (source==null || source.Length ==0 || key==null || key.Length==0)
			{
				throw new ArgumentNullException("Invalid Argument");
			}

			DESCryptoServiceProvider dsp =new DESCryptoServiceProvider();
			dsp.Mode = CipherMode.ECB;

			ICryptoTransform des = dsp.CreateDecryptor(key,null);
			try
			{
				byte [] ret = new byte[source.Length+8];
				
				int num;
				num =  des.TransformBlock(source,0, source.Length,ret,0);				

				ret = des.TransformFinalBlock(source,0,source.Length);
				ret = des.TransformFinalBlock(source,0,source.Length);
				num = ret.Length;
				
				byte [] RealByte = new byte[num];
				Array.Copy(ret,RealByte,num);
				ret = RealByte;
				return ret;
			}
			catch(Exception e1)
			{
				throw e1;
			}	
		}

		public static bool SendMail(string sMsg,string sEmailAddress)
		{
			MailMessage msgMail = new MailMessage();
			msgMail.From="openet@www.openet.com.cn";
			msgMail.To=sEmailAddress;
			msgMail.Subject = "Openet ICS邮件通知";
			msgMail.BodyFormat =MailFormat.Text;
			msgMail.Body = sMsg;

			bool b = false;
			try
			{
				SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["ICS.Core.MailServer"];
				SmtpMail.Send(msgMail);
				b = true;
			}
			catch (Exception ex)
			{
				Tools.WriteLog("ICS AdminPortal",ex.Message+ex.StackTrace,System.Diagnostics.EventLogEntryType.Error);
			}
			return b;
		}

		public static string SendHttpRequest(string url)
		{
			if(url==null || url.Length<5) return("Erorr Request!");

			try
			{
				HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(url);

				HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
			
				System.IO.Stream RepStream = HttpWResp.GetResponseStream();
				byte[] RepReadTemp = new byte[1024];
				int BytesRead = RepStream.Read(RepReadTemp, 0, 1024);
			
				System.Text.Encoding enc = System.Text.Encoding.GetEncoding(936);	
				string retmsg = enc.GetString(RepReadTemp);
			
				RepStream.Close();
				HttpWResp.Close();

				return(retmsg);
			} 
			catch (Exception e)
			{
				Tools.WriteLog("UserPortal", e.ToString(), System.Diagnostics.EventLogEntryType.Error);
				return(e.ToString());
			}			
		}

		public static int  StrToInt(string s)
		{
			int i=0;
			if(s=="")
				return 0;
			try
			{
				i=int.Parse(s);
			}
			catch
			{
				return 0;
			}
			return i;
		}

		public static DateTime getLocalTime(int iTime)
		{
			long lTime = (long)iTime * 10000000 + 621355968000000000;
			DateTime dt = new DateTime(lTime).ToLocalTime();
			return(dt);
		}

		//生成随机数函数中从Vchar数组中随机抽取
		public static string RndNum(int VcodeNum) 
		{
			//string Vchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z" ;
			string Vchar = "0,1,2,3,4,5,6,7,8,9" ;             //验证码为数字
   
			string[] VcArray = Vchar.Split(',') ;
			string  VNum = "" ;//由于字符串很短，就不用StringBuilder了
			int temp = -1 ;//记录上次随机数值，尽量避免生产几个一样的随机数

			//采用一个简单的算法以保证生成随机数的不同
			Random rand =new Random();
			for ( int i = 1 ; i < VcodeNum+1 ; i++ ) 
			{    
				if ( temp != -1) 
				{
					rand =new Random(i*temp*unchecked((int)DateTime.Now.Ticks));
				}    
				int t=rand.Next(10);
				if (temp != -1 && temp == t) 
				{
					return RndNum( VcodeNum );
				}
				temp = t  ;
				VNum += VcArray[t];

			}
			return VNum ;
		}

		// 输入参数：经Base64编码后的字符串，编码前格式：username=123&policyid=456&ip=789
		public static Hashtable ParseParam(string sParam)
		{
			Hashtable hash = new Hashtable();
			if(sParam==null || sParam.Length<3) return(hash);

			string sPlaint = FromBase64Value(sParam);
			if(sPlaint==null || sPlaint.Length<3) return(hash);

			string[] sPair = sPlaint.Split('&');
			for(int i=0;i<sPair.Length;i++)
			{
				if(sPair[i]==null || sPair[i].Length < 3) continue;
				string[] sTmp = sPair[i].Split('=');
				if(sTmp==null || sTmp.Length!=2) continue;
				string sKey = sTmp[0].TrimStart(' ').Trim();;
				string sVal = sTmp[1].TrimStart(' ').Trim();;
				hash[sKey]  = sVal;
			}
			return(hash);
		}

	}
}
