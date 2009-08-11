using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoMonitor
{
    [Serializable]
    public class SystemConfig
    {
        public bool SuccessBak=true;

        public string MonitorPath;

        public int MonitorTimes=500;

        public bool AutoStart = false;

        public bool HintImport = true;

        public string BakPath;

        public string ServiceIp;

        public string ServiceReadSn;

        public string ServiceWriteSn;
    }
}
