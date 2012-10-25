using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;

namespace HiPiaoInterface
{
    /// <summary>
    ///   哈票协议包组成函数
    ///   
    /// </summary>
    public class HiPiaoProtocol
    {
        public static void CopyTo(byte[] from, byte[] buffer, int startindex)
        {
            
        }
        public static byte[] PackSend(string busCode, string content)
        {
            int len=0;
            byte[] contentByte = System.Text.ASCIIEncoding.ASCII.GetBytes(content);
            byte[] buffer=new byte[1024];
            byte[] identifier = new byte[1] { (byte)0};
            byte[] dataLength = BitConverter.GetBytes(16+contentByte.Length) ;
            byte[] softVersion = new byte[2] { 0,1};
            byte[] pri = new byte[2] {0,8 };
            byte[] ruleCode = new byte[4] {3,0,0,3 };
            /*（对应规则文件中的data标签的name属性值，前两个字节为业务交易类型代号，在一次传输过程中唯一；后两个字节：
             * 请求报文为“01”，返回结果报文为“02”，业务级状态码报文为“03”）*/
            byte[] isCompress = new byte[1] { 0 };//（0代表未压缩、1代表压缩）
            Array.Copy(identifier, 0, buffer, len, identifier.Length);
            len += identifier.Length;

            Array.Copy(dataLength, 0, buffer, len, dataLength.Length);
            len += dataLength.Length;

            Array.Copy(softVersion, 0, buffer, len, softVersion.Length);
            len += softVersion.Length;

            Array.Copy(pri, 0, buffer, len, pri.Length);
            len += pri.Length;
            Array.Copy(ruleCode, 0, buffer, len, ruleCode.Length);
            len += ruleCode.Length;
            Array.Copy(isCompress, 0, buffer, len, isCompress.Length);
            len += isCompress.Length;

            
            Array.Copy(contentByte, 0, buffer, len, contentByte.Length);
            len += contentByte.Length;
            byte[] crc=CrcTools.CRC16(buffer, len+1);
            Array.Copy(crc, 0, buffer, len, crc.Length);
            len += crc.Length;

            byte[] result=new byte[len+1];
            Array.Copy(buffer, 0, result, 0, result.Length);
            return result;
        }
    }
}
