using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ConsoleApplication1
{
    public class TestMd5
    {
        public
 String ConvertStringToMD51(string
 ClearText)
        {
            //byte[] ByteData = Encoding.BigEndianUnicode.GetBytes(ClearText);

            byte
         [] ByteData = Encoding.ASCII.GetBytes(ClearText);
            //if (BitConverter.IsLittleEndian)   

            //  Array.Reverse(ByteData);    


            MD5 md5 = MD5.Create();
            byte
         [] HashData = md5.ComputeHash(ByteData);
            StringBuilder oSb = new
          StringBuilder();
            for
          (int
          x = 0; x < HashData.Length; x++)
            {
                oSb.Append(HashData[x].ToString("X2"
            ));
            }
            //byte[] hash = Encoding.ASCII.GetBytes(oSb.ToString());

            //txtFname.Text = oSb.ToString();

            SByte[] FinalHash = ConvertToSbyte(HashData);
            return
          encBytes(FinalHash);
        }

        public
        SByte[] ConvertToSbyte(Byte[] arr)
        {
            SByte[] Hash = new
          SByte[arr.Length];
            int
          i = 0;
            foreach
          (Byte b in
          arr)
            {
                Hash[i] = unchecked
            ((SByte)b);
                i++;
            }
            return
          Hash;
        }

        public
         String encBytes(SByte[] barr)
        {
            StringBuilder licKey = new
          StringBuilder();
            for
          (int
          i = 0; i <= 15; i++)
            {
                SByte i1 = barr[i];
                int
             j = 0;
                j |= i1 & 0xFF;
                j %= 32;
                if
             (i > 0 && i % 4 == 0)
                {
                    licKey.Append("-"
               );
                }
                //  licKey = licKey.Append(Convert.ToChar(validChars.Substring(j, 1)));

            }
            // String licKey = Base64Utils.base64Encode(hash);

            return
          licKey.ToString();
        }
    }
}
