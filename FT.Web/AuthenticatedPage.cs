using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace FT.Web
{
    //一些系统常用的常数
    public class Constants
    {
        public struct Operation
        {
            public static readonly string HQProvinceCode = "001";
            public static readonly int KeySize = 24;
            public static readonly byte[] UnicodeOrderPrefix = new byte[2] { 0xFF, 0xFE };
            public static readonly byte[] UnicodeReversePrefix = new byte[2] { 0xFE, 0xFF };
        }
    }

    /// <summary>
    /// AuthenticatedPage 的摘要说明

    /// </summary>
    public class AuthenticatedPage:System.Web.UI.Page
    {
        private OperatorTick op;

        protected void SetOperatorInfo(string operatorinfo)
        {
            Session["OperatorInfo"] = operatorinfo;
        }
        protected void ClearOperatorInfo()
        {
            Session["OperatorInfo"] = null;
        }
        public OperatorTick Operator
        {
            get
            {
                if (Session["OperatorInfo"] == null)
                {
                    this.RedirectDefault();
                    return null;
                }

                else
                {
                    this.op = OperatorTick.GetFromString(Session["OperatorInfo"].ToString());
                }
                
                return this.op;
            }
        }
        protected virtual void InitThisPage()
        {

        }
        protected void RedirectNotRight()
        {
            Page.Response.Redirect(Page.ResolveUrl(System.Configuration.ConfigurationManager.AppSettings["NotRightPage"]), true);

        }
        protected void RedirectDefault()
        {
            string  url=System.Configuration.ConfigurationManager.AppSettings["NeedLoginPage"];
            Page.Response.Redirect(Page.ResolveUrl(url), true);
        }
        protected override void OnLoad(EventArgs e)
        {
            if (Session["OperatorInfo"] == null)
            {
               // Page.RegisterClientScriptBlock("redirect", "<script>window.document.location.href='../index.aspx';</script>");
                Page.Response.Redirect(Page.ResolveUrl(System.Configuration.ConfigurationManager.AppSettings["NeedLoginPage"]), true);
            }
            
            base.OnLoad(e);
        }  
        
    }

    public  class OperatorTick
    {
        private int operatorId;
        private string name;
        private int deptId;
        private string right;
        private string pwd;
        private string desp1;

        /// <summary>
        /// 工号
        /// </summary>
        public string Desp1
        {
            get { return desp1; }
            set { desp1 = value; }
        }
        private string desp2;

        /// <summary>
        /// 管理部门代码
        /// </summary>
        public string Desp2
        {
            get { return desp2; }
            set { desp2 = value; }
        }
        private string desp3;

        /// <summary>
        /// 部门代码
        /// </summary>
        public string Desp3
        {
            get { return desp3; }
            set { desp3 = value; }
        }

        private string desp4;

        /// <summary>
        /// 部门全名
        /// </summary>
        public string Desp4
        {
            get { return desp4; }
            set { desp4 = value; }
        }
        private string desp5;

        public string Desp5
        {
            get { return desp5; }
            set { desp5 = value; }
        }
        private string desp6;

        /// <summary>
        /// 角色名
        /// </summary>
        public string Desp6
        {
            get { return desp6; }
            set { desp6 = value; }
        }

        private string desp7;

        /// <summary>
        /// 默认管理科目
        /// </summary>
        public string Desp7
        {
            get { return desp7; }
            set { desp7 = value; }
        }

        private string desp8;

        /// <summary>
        /// 备用
        /// </summary>
        public string Desp8
        {
            get { return desp8; }
            set { desp8 = value; }
        }

        public string Pwd
        {
            get
            {
                return this.pwd;
            }
        }
      
        /// <summary>
        /// 默认加密字符串

        /// </summary>
        public const string MySecret = "cqguotong";


        public string OperatorName
        {
            get
            {
                return name;
            }
        }

        public int DeptId
        {
            get
            {
                return deptId;
            }
        }
        public int OperatorID
        {
            get
            {
                return this.operatorId;
            }
        }
        public string Right
        {
            get
            {
                return right;
            }
        }
        public OperatorTick(int id,string pname,int dept,string pright,string pwd)
        {
            this.operatorId = id;
            this.right = pright;
            this.name = pname;

            this.deptId = dept;
            this.pwd = pwd;
 
        }

        /// <summary>
        /// 产生操作员登录信息串。各信息字段间以"\n"分隔
        /// </summary>
        /// <returns>操作员信息串</returns>
        public  string GenerateOpInfo()
        {
            if ((this.operatorId == 0) || (this.right == null))
            {
                throw new ArgumentException("Invalid Argument");
            }

            string OpInfo = this.operatorId.ToString() + "\n" + this.name + "\n" + this.deptId + "\n" + this.right+"\n"+this.pwd
                 + "\n" + this.desp1
                 + "\n" + this.desp2
                 + "\n" + this.desp3
                  + "\n" + this.desp4
                 + "\n" + this.desp5
                   + "\n" + this.desp6
                 + "\n" + this.desp7
                 + "\n" + this.desp8;

            return OpInfo;
        }
        /// <summary>
        /// 生成操作员登录信息串，由WriteLoginTicket方法调用
        /// </summary>
        /// <param name="opInfoTicket">操作员信息</param>
        /// <param name="secret">加密密钥</param>
        /// <returns>返回加密后操作员信息串</returns>

        public static string GenerateOpTicket(OperatorTick op)
        {
            string result=GenerateOpTicket(op, OperatorTick.MySecret);
            
            return result;
        }

        public static  string GenerateOpTicket(OperatorTick op,string secret)
        {
            if ((secret == null) || (secret.Length == 0))
                throw new ArgumentNullException("Invalid Argument");

            try
            {
                string OpInfoStr = op.GenerateOpInfo();
                byte[] Key = TicketTool.GetKey(secret);
                byte[] OpInfoByte = Encoding.Unicode.GetBytes(OpInfoStr);

                MemoryStream MSTicket = new MemoryStream();

                MSTicket.Write(TicketTool.ConvertLength(OpInfoByte.Length), 0, 2);
                MSTicket.Write(OpInfoByte, 0, OpInfoByte.Length);

                MSTicket.Write(TicketTool.ConvertLength(Key.Length), 0, 2);
                MSTicket.Write(Key, 0, Key.Length);

                byte[] OpTicketCryptByte = TicketTool.Crypt(MSTicket.ToArray(), Key);

                string OpTicketCryptStr = Encoding.ASCII.GetString(TicketTool.Base64Encode(OpTicketCryptByte));

                return OpTicketCryptStr;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static OperatorTick GetFromString(string opinfo)
        {
           return  GetFromString(opinfo, OperatorTick.MySecret);
        }
        public static OperatorTick GetFromString(string opinfo, string secret)
        {
            try
            {
                byte[] Key = TicketTool.GetKey(secret);
                byte[] OpLoginTicketCry = TicketTool.Base64Decode(Encoding.ASCII.GetBytes(opinfo));
                byte[] OpLoginTicketDec = TicketTool.Decrypt(OpLoginTicketCry, Key);
                byte[] OpLoginInfoByte;

                if (OpLoginTicketDec.Length < 2)
                    throw new System.Exception("Invalid ticket");

                int OpNextLen = TicketTool.GetPart(OpLoginTicketDec, 0, out OpLoginInfoByte);

                byte[] TickKey;

                if (OpLoginTicketDec.Length < OpNextLen + 2)
                    throw new System.Exception("Invalid ticket");

                OpNextLen = TicketTool.GetPart(OpLoginTicketDec, OpNextLen, out TickKey);
                if (!TicketTool.CompareByteArrays(Key, TickKey))
                    throw new System.Exception("Invalid ticket");

                string OpLoginInfo = Encoding.Unicode.GetString(OpLoginInfoByte);

                string[] arra = OpLoginInfo.Split('\n');
                if (arra.Length ==13)
                {
                    OperatorTick op=new OperatorTick(Convert.ToInt32(arra[0]), arra[1], Convert.ToInt32(arra[2]), arra[3],arra[4]);
                    op.Desp1 = arra[5];
                    op.Desp2 = arra[6];
                    op.Desp3 = arra[7];
                    op.Desp4 = arra[8];
                    op.Desp5 = arra[9];
                    op.Desp6 = arra[10];
                    op.Desp7 = arra[11];
                    op.Desp8 = arra[12];
                    return op;
                }
                else
                {
                    throw new Exception("转换OperatorTick参数个数不对！");
                }
            }
            catch
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Ticket操作工具类。实现加密、解密算法和HASH算法
    /// </summary>
    public class TicketTool
    {
        //使用TripleDES加密
        public static byte[] Crypt(byte[] source, byte[] key)
        {
            if ((source.Length == 0) || (source == null) || (key == null) || (key.Length == 0))
            {
                throw new ArgumentException("Invalid Argument");
            }

            TripleDESCryptoServiceProvider dsp = new TripleDESCryptoServiceProvider();
            dsp.Mode = CipherMode.ECB;

            ICryptoTransform des = dsp.CreateEncryptor(key, null);

            try
            {
                return des.TransformFinalBlock(source, 0, source.Length);
            }
            catch (Exception e1)
            {
                throw e1;
            }

        }

        //使用TripledDES解密
        public static byte[] Decrypt(byte[] source, byte[] key)
        {
            if ((source.Length == 0) || (source == null) || (key == null) || (key.Length == 0))
            {
                throw new ArgumentNullException("Invalid Argument");
            }

            TripleDESCryptoServiceProvider dsp = new TripleDESCryptoServiceProvider();
            dsp.Mode = CipherMode.ECB;

            ICryptoTransform des = dsp.CreateDecryptor(key, null);
            try
            {
                byte[] ret = new byte[source.Length + 8];

                int num;
                num = des.TransformBlock(source, 0, source.Length, ret, 0);

                ret = des.TransformFinalBlock(source, 0, source.Length);
                ret = des.TransformFinalBlock(source, 0, source.Length);
                num = ret.Length;

                byte[] RealByte = new byte[num];
                Array.Copy(ret, RealByte, num);
                ret = RealByte;
                return ret;
            }
            catch (Exception e1)
            {
                throw e1;
            }

        }

        //使用md5计算散列
        public static byte[] Hash(byte[] source)
        {
            if ((source == null) || (source.Length == 0))
                throw new ArgumentException("source is not valid");

            MD5 m = MD5.Create();
            return m.ComputeHash(source);
        }


        //从secret生成加密的key
        public static byte[] GetKey(string secret)
        {
            if ((secret == null) || (secret.Length == 0))
                throw new ArgumentException("Secret is not valid");

            byte[] temp;

            ASCIIEncoding ae = new ASCIIEncoding();
            temp = Hash(ae.GetBytes(secret));

            byte[] ret = new byte[Constants.Operation.KeySize];

            int i;

            if (temp.Length < Constants.Operation.KeySize)
            {
                System.Array.Copy(temp, 0, ret, 0, temp.Length);
                for (i = temp.Length; i < Constants.Operation.KeySize; i++)
                {
                    ret[i] = 0;
                }
            }
            else
                System.Array.Copy(temp, 0, ret, 0, Constants.Operation.KeySize);

            return ret;
        }

        //改进后的base64编码:能够通过http传递

        public static string Encode(byte[] source)
        {
            byte[] dest;

            dest = Base64Encode(source);

            string ret;
            ret = new ASCIIEncoding().GetString(dest);
            //			ret = ret.Replace("+","~");
            //			ret = ret.Replace("/","@");
            //			ret = ret.Replace("=","$");
            //ret = HttpUtility.UrlEncode(ret);
            return ret;

        }

        //改进的base64的解码

        public static byte[] Decode(string source)
        {

            string dest;
            //			dest = source.Replace("~","+");
            //			dest = dest.Replace("@","/");
            //			dest = dest.Replace("$","=");
            dest = source;//HttpUtility.UrlDecode(source);
            byte[] ret;
            ret = Base64Decode(new ASCIIEncoding().GetBytes(dest));

            return ret;
        }

        //原始base64编码
        public static byte[] Base64Encode(byte[] source)
        {
            if ((source == null) || (source.Length == 0))
                throw new ArgumentException("source is not valid");

            ToBase64Transform tb64 = new ToBase64Transform();
            MemoryStream stm = new MemoryStream();
            int pos = 0;
            byte[] buff;

            while (pos + 3 < source.Length)
            {
                buff = tb64.TransformFinalBlock(source, pos, 3);
                stm.Write(buff, 0, buff.Length);
                pos += 3;
            }

            buff = tb64.TransformFinalBlock(source, pos, source.Length - pos);
            stm.Write(buff, 0, buff.Length);

            return stm.ToArray();

        }

        //原始base64解码
        public static byte[] Base64Decode(byte[] source)
        {
            if ((source == null) || (source.Length == 0))
                throw new ArgumentException("source is not valid");

            FromBase64Transform fb64 = new FromBase64Transform();
            MemoryStream stm = new MemoryStream();
            int pos = 0;
            byte[] buff;

            while (pos + 4 < source.Length)
            {
                buff = fb64.TransformFinalBlock(source, pos, 4);
                stm.Write(buff, 0, buff.Length);
                pos += 4;
            }

            buff = fb64.TransformFinalBlock(source, pos, source.Length - pos);
            stm.Write(buff, 0, buff.Length);
            return stm.ToArray();

        }

        //比较两个byte数组是否相同
        public static bool CompareByteArrays(byte[] source, byte[] dest)
        {
            if ((source == null) || (dest == null))
                throw new ArgumentException("source or dest is not valid");

            bool ret = true;

            if (source.Length != dest.Length)
                return false;
            else
                if (source.Length == 0)
                    return true;

            for (int i = 0; i < source.Length; i++)
                if (source[i] != dest[i])
                {
                    ret = false;
                    break;
                }
            return ret;

        }

        //根据规则还原字段长度
        public static int GetLength(byte[] length)
        {

            if ((length == null) || (length.Length == 0))
                throw new ArgumentException("Invalid Lenght");

            return System.Convert.ToInt16(length[0]) * 256 + System.Convert.ToInt16(length[1]);
        }

        //根据规则计算字段长度，并将长度填写到byte数组中返回

        public static byte[] ConvertLength(int length)
        {
            byte[] ret = new byte[2];

            ret[0] = (byte)(length / 256);
            ret[1] = (byte)(length % 256);

            return ret;
        }

        //取出下一个字段的长度，返回下一个字段的内容
        public static int GetPart(byte[] source, int posStart, out byte[] dest)
        {
            if (source == null || source.Length == 0)
            {
                throw new ArgumentException("Invalid TicketRequest.");
            }

            int length; //lenght是字节数组的前两位，而且高位在前，低位在后


            try
            {

                byte[] ll = new Byte[2];
                ll[0] = source[posStart];
                ll[1] = source[posStart + 1];
                length = GetLength(ll);

                if (source.Length < posStart + 2 + length)
                    throw new Exception("Invalid ticket");

                dest = new byte[length];
                System.Array.Copy(source, posStart + 2, dest, 0, length);
                return posStart + 2 + length;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
