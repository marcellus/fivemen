using System;
using System.Collections.Generic;
using System.Text;

namespace XServerMonitor
{
    [Serializable]
    public class MonitorConfig
    {
        public string MonitorPath=string.Empty;
        public int TimerSecond=2000;
        public int MonitorLine = 2000;
        public int LogDays = 5;
    }
}
