using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    /// <summary>
    /// 取票获取的对象
    /// </summary>
    public class GetTicketPrintObject
    {

        /*
         票据唯一标识:68974
正副券标识:0
打印X坐标:3
打印Y坐标:42
字体大小:10
是否加粗:0
打印项内容:ӰƬ:Ӯ֦
         */
        
        public string Id;
        public string Id2;
        public int X;
        public int Y;
        public int FontWeight;
        public bool IsBold;
        public string Content;
    }
}
