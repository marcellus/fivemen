/*
 * 字符串处理工具
 * */

using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Common
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class StringUtil
	{

		#region 构造和析构
		private StringUtil()
		{
			
		}
		#endregion

		///<summary>将字符串中的HTML字符替换成转义字符<summary>
		///<param name="strHTML">HTML字符串</param>
		///<returns>string 替换后的字符串</returns>
		public static string htmlspecialchars(string strHTML)
		{
			//检查参数
			if (null == strHTML || 0 == strHTML.Length)
			{
				return "";
			}
			StringBuilder oSb = new StringBuilder(strHTML);
			oSb.Replace("&","&amp;");
			oSb.Replace("<","&lt;");
			oSb.Replace(">","&gt;");
			oSb.Replace("\x09","&#09;");
			oSb.Replace(" ","&nbsp;");
			return oSb.ToString();
		}

		///<summary>将字符串中的单引号替换成两个单引号<summary>
		///<param name="str">字符串</param>
		///<returns>string 替换后的字符串</returns>
		public static string SQLEncode(string str)
		{
			//检查参数
			if (null == str || 0 == str.Length)
			{
				return "";
			}
			StringBuilder oSb = new StringBuilder(str);
			oSb.Replace("'","''");
			return oSb.ToString();
		}

		///<summary>将字符串中的换行替换成HTML标记<summary>
		///<param name="str">字符串</param>
		///<returns>string 替换后的字符串</returns>
		public static string nl2br(string str)
		{
			//检查参数
			if (null == str || 0 == str.Length)
			{
				return "";
			}
			StringBuilder oSb = new StringBuilder(str);
			oSb.Replace("\n","<br />");
			return oSb.ToString();
		}

		public static string Bytes2String(MemoryStream objMem, string strEncoding)
		{
			Debug.Assert(null != objMem);
			Encoding objCode = Encoding.GetEncoding(strEncoding);
			byte[] arrData = Encoding.Convert(objCode, Encoding.UTF8, objMem.GetBuffer(), 0, (int)objMem.Length);
			UTF8Encoding objUtf8 = new UTF8Encoding();
			return objUtf8.GetString(arrData);
		}

		/// <summary>
		/// 查找字符串中特定的开始和结束的字符串
		/// </summary>
		/// <param name="strInput"></param>
		/// <param name="strStart"></param>
		/// <param name="strEnd"></param>
		/// <returns></returns>
		public static string SearchInString(string strInput, string strStart, string strEnd)
		{
			int nLoc1 = strInput.IndexOf(strStart);
			if (-1 == nLoc1)
			{
				return null;
			}
			int nLoc2 = strInput.IndexOf(strEnd, nLoc1 + strStart.Length);
			if (-1 == nLoc2)
			{
				return null;
			}
			return strInput.Substring(nLoc1 + strStart.Length, nLoc2 - nLoc1 - strStart.Length);
		}

		public static string SearchInString(string strInput, int nStartIndex, string strStart, string strEnd)
		{
			Debug.Assert(nStartIndex>=0 && nStartIndex < strInput.Length);
			int nLoc1 = strInput.IndexOf(strStart, nStartIndex);
			if (-1 == nLoc1)
			{
				return null;
			}
			int nLoc2 = strInput.IndexOf(strEnd, nLoc1 + strStart.Length);
			if (-1 == nLoc2)
			{
				return null;
			}
			return strInput.Substring(nLoc1 + strStart.Length, nLoc2 - nLoc1 - strStart.Length);
		}

		/// <summary>
		/// 分割字符串
		/// </summary>
		/// <param name="strInput">输入字符串</param>
		/// <param name="strSpliter">分隔字符串</param>
		/// <returns>字符串数组</returns>
		public static string[] Split(string strInput, string strSpliter)
		{
			System.Collections.ArrayList objArrList = new System.Collections.ArrayList();
			int nLoc = 0;
			do
			{
				nLoc = strInput.IndexOf(strSpliter, nLoc);
				if (-1 == nLoc)
				{
					break;
				}
				objArrList.Add(nLoc);
				nLoc += strSpliter.Length;
			} while(true);
			if (0 == objArrList.Count)
			{
				string[] arr = new string[1];
				arr[0] = strInput;
				return arr;
			}
			//下面构造数据
			string[] arrResult = new string[objArrList.Count + 1];
			int nIndex = 0;
			int nTemp = 0;
			int nStart = 0;
			do
			{
				nTemp = (int)objArrList[nIndex];
				arrResult[nIndex] = strInput.Substring(nStart, nTemp - nStart);
				nIndex++;
				nStart = nTemp + strSpliter.Length;
			} while(nIndex<objArrList.Count);
			arrResult[nIndex] = strInput.Substring(nStart);
			//完成
			return arrResult;
		}

		public static int ToInt32(string strInput)
		{
			try
			{
				return int.Parse(strInput);
			}
			catch(Exception)
			{
				System.Diagnostics.Debug.WriteLine(strInput + "转化成int失败");
				return 0;
			}
		}

		public static double ToDouble(string strInput)
		{
			try
			{
				return double.Parse(strInput);
			}
			catch(Exception)
			{
				System.Diagnostics.Debug.WriteLine(strInput + "转化成double失败");
				return 0.0D;
			}
		}

		public static decimal ToDecimal(string strInput)
		{
			try
			{
				return decimal.Parse(strInput);
			}
			catch(Exception)
			{
				System.Diagnostics.Debug.WriteLine(strInput + "转化成decimal失败");
				return 0.0M;
			}
		}

		public static bool ToBool(string strInput)
		{
			try
			{
				return bool.Parse(strInput.ToLower());
			}
			catch(Exception)
			{
				System.Diagnostics.Debug.WriteLine(strInput + "转化成bool失败");
				return false;
			}
		}

		public static DateTime ToDateTime(string strInput)
		{
			try
			{
				return DateTime.Parse(strInput);
			}
			catch(Exception)
			{
				System.Diagnostics.Debug.WriteLine("[" + strInput + "]转化成DateTime失败");
				//return DateTime.MinValue;
				return new DateTime(1753, 1, 1, 23, 0, 0);  //SQL可以接受的最小时间
			}
		}

		/// <summary>
		/// 十六进制字符串转化成整型
		/// </summary>
		/// <param name="strHex">16进制字符串</param>
		/// <returns>整数值，转换错误返回-1</returns>
		public static int Hex2Int(string strHex)
		{
			int i;
			int nCurValue;
			int nResult = 0;
			int nPow = 1;
			for (i=strHex.Length - 1; i>=0; i--)
			{
				if (strHex[i]>='0' && strHex[i]<='9')
				{
					nCurValue = (int)strHex[i] - (int)'0';
				}
				else if (strHex[i]>='a' && strHex[i]<='f')
				{
					nCurValue = (int)strHex[i] - (int)'a' + 10;
				}
				else if (strHex[i]>='A' && strHex[i]<='F')
				{
					nCurValue = (int)strHex[i] - (int)'A' + 10;
				}
				else
				{
					return -1;
				}
				nResult += nPow * nCurValue;
				nPow *= 16;
			}
			return nResult;
		}

		public static string CompressHtml(string Html)
		{
			string temp = Html;
			string strReg = @"<body[^<>]*?>[^\x00]*?</body>";
			Regex r = new Regex(strReg, RegexOptions.IgnoreCase | RegexOptions.Multiline);
			Match m = r.Match(temp);
			if (!m.Success)
			{
				return null;
			}
			//下面删除属性
			strReg = @"<(?<tagname>[A-Za-z0-9/]+?)\s+?[^<>]*?>";
			r = new Regex(strReg, RegexOptions.Multiline);
			StringBuilder objSb = new StringBuilder();
			temp = m.Value;
			int nIndex = 0;
			for (m = r.Match(temp); m.Success; m = m.NextMatch())
			{
				if (m.Index > nIndex)
				{
					objSb.Append(temp, nIndex, m.Index - nIndex);
				}
				nIndex = m.Index + m.Value.Length;
				objSb.Append('<');
				objSb.Append(m.Groups["tagname"].Value);
				objSb.Append('>');
			}
			objSb.Append(temp, nIndex, temp.Length - nIndex);
			return objSb.ToString();
		}

		public static string ConvertUnicode(string Input)
		{
			Debug.Assert(null != Input);
			StringBuilder objSb = new StringBuilder();
			int i = 0;
			int nLen = Input.Length;
			char cTemp;
			int nValue;
			while (i < nLen)
			{
				cTemp = Input[i];
				if (cTemp == '\\' && Input[i + 1] == 'u')
				{
					nValue = Hex2Int(Input.Substring(i+2, 4));
					objSb.Append(Convert.ToChar(nValue));
					i += 6;
				}
				else
				{
					objSb.Append(cTemp);
					++i;
				}
			}
			return objSb.ToString();
		}

		#region Url Encode
		public static string UrlEncoding(string Input, Encoding obj, bool IsConvertAll)
		{
			Encoding objUnicode = Encoding.Unicode;
			//Encoding objGb2312 = Encoding.GetEncoding("GB2312");
			byte[] arr = Encoding.Unicode.GetBytes(Input);
			arr = Encoding.Convert(objUnicode, obj, arr);
			//下面逐个转换
			StringBuilder objSb = new StringBuilder();
			int nLen = arr.Length;
			for (int i=0; i<nLen; i++)
			{
				if (arr[i]>127 && !IsConvertAll)
				{
					objSb.Append(Uri.HexEscape((char)arr[i]));
				}
				else
				{
					objSb.Append((char)arr[i]);
				}
			}
			return objSb.ToString();
		}

		public static string UrlEncoding(string Input, string strEncoding, bool IsConvertAll)
		{
			Encoding obj = Encoding.GetEncoding(strEncoding);
			return UrlEncoding(Input, obj, IsConvertAll);
		}

		public static string UrlEncoding(string Input, int CodePage, bool IsConvertAll)
		{
			Encoding obj = Encoding.GetEncoding(CodePage);
			return UrlEncoding(Input, obj, IsConvertAll);
		}

		public static string Gb2312UrlEncoding(string Input)
		{
			Encoding objGb2312 = Encoding.GetEncoding("GB2312");
			return UrlEncoding(Input, objGb2312, false);
		}
		#endregion
	}
}
