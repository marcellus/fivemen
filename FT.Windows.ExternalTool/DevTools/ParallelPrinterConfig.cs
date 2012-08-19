using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Tools;

namespace FT.Windows.ExternalTool.DevTools
{
    [Serializable]
    public class ParallelPrinterConfig
    {
        public List<string> Commands = new List<string>();
        public int Pages=5;
        public int Seconds = 3;
        public string LPT = "lpt1";

        
    }
}
