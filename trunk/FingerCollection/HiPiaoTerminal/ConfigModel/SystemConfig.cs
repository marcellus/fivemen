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

        public string CinemaServerIp="192.168.0.1";//影院前置机IP地址
        public int CinemaServerPort = 2987;//影院前置机端口
        public string HiPiaoInterfaceUrl = "http://open.hipiao.com:8080/ws/hpcinema";

        public string ManagePwd="123456";

        public int UnOperationTime = 20;

        public string PrinterType = "并口";

        /// <summary>
        /// 定时更新电影信息时间
        /// </summary>
        public int UpdateMovieTime = 5;

        public bool AllowNumberKeyboard = false;//是否允许数字的时候也弹出键盘

        public bool IsDingXin = false;//是否鼎新取票


        public bool AllowShowMouse = true;


        public bool UseMaskPanel = true;

        public bool UseHardwareKeyboard = false;


        public bool UseVirtualKeyboard = false;

        public bool UseRfid = false;

        public string Province = "广东省";

        public string City = "广州市";

        public string CityId = "7100d410-7b1d-102a-84c8-00188b381bbb";

        public string Cinema = "默认影院";
        public string CinemaId = "";


        public int FullScreenSecond = 5;

        public bool AllowFullScreen = true;

        /// <summary>
        /// 广告替换的时间 毫秒
        /// </summary>
        public int AdSeconds = 2000;

        //全屏选座座位扩大距离
        public int FullScreenAddWidth = 0;

    }
}
