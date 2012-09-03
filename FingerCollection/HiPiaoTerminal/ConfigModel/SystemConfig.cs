using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoTerminal.ConfigModel
{
    [Serializable]
    public class SystemConfig
    {
        public string ServicePhone="400-601-5566";
        public string InternalUrl="www.hipiao.com";

        public string TastUrl = "http://www.hipiao.com";

        public bool AutoCloseComputer=true;
        public int AutoCloseComputerHour = 1;
        public int AutoCloseComputerMinitues = 0;

        public bool AutoOpenComputer = true;
        public int AutoOpenComputerHour = 8;
        public int AutoOpenComputerMinitues = 0;

        public string CinemaServerIp="192.168.0.1";
        public string HiPiaoInterfaceUrl = "http://jk.hipiao.com/xxx";

        public string ManagePwd="qqqqqq";

        public int UnOperationTime = 20;

        public int UpdateMovieTime = 12000;


        public bool AllowShowMouse = false;


        public bool UseMaskPanel = true;

        public bool UseHardwareKeyboard = false;


        public bool UseVirtualKeyboard = false;

        public bool UseRfid = false;

        public string Province = "广东省";

        public string City = "广州市";

        public string CityId = "7100d410-7b1d-102a-84c8-00188b381bbb";

        public string Cinema = "";
        public string CinemaId = "";

    }
}
