using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoCutMonitor
{
    [Serializable]
    public class SystemConfig
    {
        public bool SuccessBak = true;

        public string MonitorPath;

        public int MonitorTimes = 500;

        public bool AutoStart = false;

        public string BakPath;

        public string CutPath;

        public int StartX;

        public int StartY;
        public int CutLength;
        public int CutWidth;

        public bool IsRar=true;

        public int KitWidth = 417;

        public int KitHeight = 566;

    }
}
