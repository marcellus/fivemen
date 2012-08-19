using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    /// <summary>
    /// 接口返回对象
    /// </summary>
    public class ReturnObject
    {
        public static int SUCESS = 0;
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        private int code;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
    }
}
