using System;
using System.Collections.Generic;
using System.Text;

namespace FingerMonitor.Config
{
    [Serializable]
    public class SystemConfig
    {
        public string MonitorPath;

        public int MonitorTimes = 500;

        public bool AutoStart = false;

        public string TnsName;
        public string OraUser;
        public string OraPwd;
    }
}
