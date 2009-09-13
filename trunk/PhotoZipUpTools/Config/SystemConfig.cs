using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoZipUpTools
{
    [Serializable]
    public class SystemConfig
    {
        public bool SuccessBak = true;

        public string MonitorPath;

        public int MonitorTimes = 500;

        public bool AutoStart = false;

        public bool AutoUpload = false;

        public string BakPath;

        public string FtpUrl;

        public string FtpName;

        public string FtpPassword;
    }
}
