using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;

namespace Vehicle.Plugins
{
    public class VehicleHelper:BaseHelper
    {
        private VehicleHelper()
        {
        }



        #region 不可变动
        /// <summary>
        ///打印二维条码的第二个数组的编码
        /// </summary>
        /// <param name="str">字符串由身份证+准驾车型+地区编号</param>
        /// <returns>编码后的8位字符串</returns>
        public static string Encode(string str)
        {
            /* 
string ls_ret, ls_sum, ls_outstr, ls_str, ls_temp
integer i,ll_len
long   ll_asc, ll_sum

ll_len = len(arg_input)
ll_sum = 0
for i = 1 to ll_len
   ll_asc = asc(mid(arg_input, i, 1)) //取Ascii码
   ll_asc = ll_asc * 3 * 17 * i
   ll_asc = mod(ll_asc, 1000)  //取数字的后三位
   ls_str = string(ll_asc)
   if len(ls_str) = 1 then ls_str = '00' + ls_str
   if len(ls_str) = 2 then ls_str = '0' + ls_str
   if len(ls_str) > 3 then ls_str = mid(ls_str,len(ls_str) - 2,3)	
   ll_sum = ll_sum + ll_asc
   ls_outstr = ls_outstr + ls_str
next
ll_sum =ll_sum * 3 * 37
ls_sum = string(ll_sum)
if len(ls_sum) = 1 then ls_sum = ls_sum + '000'
if len(ls_sum) = 2 then ls_sum = ls_sum + '00'
if len(ls_sum) = 3 then ls_sum = ls_sum + '0'
if len(ls_sum) > 4 then ls_sum = mid(ls_sum,len(ls_sum) - 3 ,4)
ll_len = len(ls_outstr)
if ll_len > 28 then
    ls_outstr =mid(ls_outstr, 1, 28)
end if;
ll_len = round(len(ls_outstr) / 4,1) 
if mod(ll_len , 4) <> 0 then
    ll_len = ll_len + 1
end if
ls_temp = ls_sum
for i  = 1 to ll_len
	ls_str = mid(ls_outstr,(i - 1) *4 + 1 ,4)
     ll_asc = long(ls_str) + long(ls_sum)
	ll_asc = mod(ll_asc,10000)
	ls_temp = ls_temp + trim(string(ll_asc,'0000'))
next	

ls_outstr = ls_temp


if len(ls_outstr) < 32 then
   ll_len= 32 - len(ls_outstr)
   ls_str = ''
   for i = 1 to ll_len 
	
      ll_asc = ll_sum * i * 13 * len(ls_outstr)
      ll_asc = mod(ll_asc, 10000)
      ls_str = ls_str +string(ll_asc)
      if len(ls_str) > ll_len then
        ls_str = mid(ls_str, 1, ll_len)
        exit
      end if
	next
   ls_outstr = ls_outstr + ls_str
end if

if len(ls_outstr) > 32 then
	ls_outstr = mid(ls_outstr, 1, 32)
end if



return ls_outstr
             */
            Debug("二维条码加密字符为：" + str);
            string ls_ret = string.Empty, ls_sum = string.Empty, ls_outstr = string.Empty, ls_str = string.Empty, ls_temp = string.Empty;
            long ll_asc = 0, ll_len = 0, ll_sum = 0;
            ll_len = str.Length;
            //System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            //int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
            //byte[] bytes = asciiEncoding.GetBytes(str);
            for (int i = 1; i <= ll_len; i++)
            {
                ll_asc = (long)str[i - 1];//?取ascii码？
                ll_asc = ll_asc * 17 * 3 * i;
                ll_asc = ll_asc % 1000L;//取余数的两位
                ls_str = string.Format("{0:000}", ll_asc);
                ls_str = ls_str.Substring(ls_str.Length - 3);
                //ls_str = string.Format("{0:F2}", ll_asc);
                ll_sum = ll_sum + ll_asc;
                ls_outstr = ls_outstr + ls_str;
            }
            Debug("第一次循环后：" + ls_outstr);
            ll_sum = (ll_sum * 3 * 37L);
            ls_sum = string.Format("{0:0000}", ll_sum);
            ls_sum = ls_sum.Substring(ls_sum.Length - 4);
            ll_len = ls_outstr.Length;
            Debug("第一次循环后字符长度：" + ll_len);
            Debug("第一次循环后ls_sum：" + ls_sum);
            if (ll_len > 28)
                ls_outstr = ls_outstr.Substring(0, 28);
            ll_len = ls_outstr.Length / 4;
            //ll_len = ls_outstr.Length;
            //ll_len = (long)Math.Round(ls_outstr.Length / 4,1);//TODO?
            if (ls_outstr.Length % 4 != 0)
                ll_len = ll_len + 1;
            ls_temp = ls_sum;
            for (int i = 1; i <= ll_len; i++)
            {
                if (i != ll_len)
                    ls_str = ls_outstr.Substring((i - 1) * 4, 4);
                else
                {
                    ls_str = ls_outstr.Substring((i - 1) * 4);
                }
                ll_asc = long.Parse(ls_str) + long.Parse(ls_sum);
                ll_asc = ll_asc % 10000;
                ls_temp = ls_temp + string.Format("{0:0000}", ll_asc);
            }
            Debug("第二次循环后：" + ls_outstr);
            Debug("第二次循环后ll_sum"+ll_sum.ToString());
            ls_outstr = ls_temp;
            if (ls_outstr.Length < 32)
            {
                ll_len= 32 - ls_outstr.Length;
                ls_str = "";
                for (int i = 1; i <= ll_len; i++)
                {   
                    ll_asc = ll_sum * i * 13 * ls_outstr.Length;
                    ll_asc = ll_asc%10000L;
                    ls_str = ls_str +ll_asc.ToString();
                    if (ls_str.Length > ll_len)
                    {
                        ls_str = ls_str.Substring(0, (int)ll_len);
                        break;
                    }
                }
                Debug("少于32时循环后" + ls_str);
                ls_outstr = ls_outstr + ls_str;
            }
            
            if (ls_outstr.Length > 32 )
            {
                ls_outstr = ls_outstr.Substring(0, 32);
            }
            return ls_outstr;

        }
        

        private readonly static string QRSep = "|";

        public static void AppendString(StringBuilder sb, string app)
        {
            sb.Append(QRSep);
            sb.Append(app);
        }






        /// <summary>
        /// 根据身份证明名称和号码来转化需要编码的号码
        /// </summary>
        /// <param name="type">证明名称代码</param>
        /// <param name="idcard">证明号码</param>
        /// <returns></returns>
        public static string TransIdCard(string type, string idcard)
        {
            string result = idcard;
            if (type == "A" && idcard.Length == 15)
            {
                result = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
            }
            else if (type != string.Empty && type != "A")
            {
                result = type + idcard;
            }
            return result;
        }
        #endregion
    }
}
