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

        // 翻转字节顺序 (32-bit) 
        public static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        /// <summary>
        /// 转换Big或Little Edian字节顺序
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static byte[] getConvertEdian(byte[] data)
        {
            int len = data.Length;
            byte[] result = new byte[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = data[len - i - 1];
            }
            return result;
        }

        public static int GetDataPackageLen(byte[] data)
        {
           
            return BitConverter.ToInt32(getConvertEdian(data), 0);
           // Convert.ToInt32(16 + contentByte.Length)
        }


        public static byte[] PackSend(string busCode, string content)
        {
            int len=0;
            byte[] contentByte = System.Text.ASCIIEncoding.ASCII.GetBytes(content);
            byte[] buffer=new byte[1024];
            byte[] identifier = new byte[1] { 0x30};
          // BitConverter.
            byte[] dataLength = getConvertEdian(BitConverter.GetBytes(16 + contentByte.Length));
            //byte[] dataLength = BitConverter.GetBytes(16+contentByte.Length) ;
            byte[] softVersion = new byte[2] { 0x30,0x31};
           // byte[] dataLength = new byte[1] { (byte)(16 + contentByte.Length )};
            byte[] pri = new byte[2] {0x30,0x35 };
            byte[] ruleCode = new byte[4] {0x33,0x30,0x30,0x31 };
            /*（对应规则文件中的data标签的name属性值，前两个字节为业务交易类型代号，在一次传输过程中唯一；后两个字节：
             * 请求报文为“01”，返回结果报文为“02”，业务级状态码报文为“03”）*/
            byte[] isCompress = new byte[1] { 0x30 };//（0代表未压缩、1代表压缩）
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
            CRCTool2.ConCRC(ref buffer, len);
            //ushort crcresult = CrcTools2.GetCRC16(buffer,len);
           // byte[] crc = new byte[] { Convert.ToByte(Convert.ToString(3701, 16)) };
            //byte[] crc=CrcTools.CRC16(buffer, len+1);
           // Array.Copy(crc, 0, buffer, len, crc.Length);
          //  len += crc.Length;

            byte[] result=new byte[len+2];
            Array.Copy(buffer, 0, result, 0, result.Length);
            return result;
        }
    }
}
