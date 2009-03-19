using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Bar
{
    [Serializable]
    public class BarReaderConfig
    {
        public string Port="COM1";

        public int DataBit=8;

        public int StopBit=1;

        public int BaudRate=9600;

        public string Parity="ÎÞÐ£Ñé";

        public string Encoding="gb2312";

        public bool AddReturn=false;
    }
}
