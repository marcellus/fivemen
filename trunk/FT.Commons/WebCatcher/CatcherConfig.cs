using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FT.Commons.WebCatcher
{
    /// <summary>
    /// 捕获配置
    /// </summary>
    [Serializable]
    public class CatcherConfig
    {
        public string CookieFormat;

        public string DownDir="c:\\";

        public string LoginUrl;

        public string Url;

        public string Begin;

        public string End;

        /// <summary>
        /// 无，日期，整数
        /// </summary>
        public string ParaType;

        public string UID;

        public string Pwd;

        public bool LoginWithCookie = true;

        public string CatcherClassName;

       
    }
}
