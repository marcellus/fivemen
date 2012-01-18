using System;
using System.Collections.Generic;
using System.Text;

namespace STWebContainer
{
    [Serializable]
    public class STWebContainerSetting
    {

        public string Url="about:blank";
        public string Pwd="123456";
        public int Hour=17;

        public int Minute = 30;
        
        public bool IsTimer = false;
        public bool IsShowToolBar=true;

    }
}
