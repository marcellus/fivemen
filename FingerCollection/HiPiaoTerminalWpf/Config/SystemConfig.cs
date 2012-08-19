using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiPiaoTerminalWpf.Config
{
    [Serializable]
    public class SystemConfig
    {
        public string ServicePhone = "400-601-5566";
        public string InternalUrl = "www.hipiao.com";

        public string TastUrl = "http://www.hipiao.com";

        public bool AutoCloseComputer = true;
        public int AutoCloseComputerHour = 1;
        public int AutoCloseComputerMinitues = 0;

        public bool AutoOpenComputer = true;
        public int AutoOpenComputerHour = 8;
        public int AutoOpenComputerMinitues = 0;

        public string CinemaServerIp = "192.168.0.1";
        public string HiPiaoInterfaceUrl = "http://jk.hipiao.com/xxx";

        public string ManagePwd = "qqqqqq";

        public int UnOperationTime = 20;

        public int UpdateMovieTime = 12000;


        public bool AllowShowMouse = false;

    }
}
