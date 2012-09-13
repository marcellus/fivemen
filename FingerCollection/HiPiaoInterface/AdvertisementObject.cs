using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HiPiaoInterface
{
    /// <summary>
    /// 广告信息
    /// </summary>
    [Serializable]
    public class AdvertisementObject
    {
        /*
1、位置：屏保 —— 名称：屏保轮刷广告 

2、位置：首页 —— 名称：首页轮刷广告

3、位置：取票完成页 —— 名称：取票完成页广告

4、位置：购票完成页 —— 名称：购票完成页广告

5、位置：注册完成页 —— 名称：注册完成页广告
    */
        //<advertisement advName="" advPic="" advPicLink="" advWeizhiOne="" advWeizhiTwo="" />
        private string advName;

        public string AdvName
        {
            get { return advName; }
            set { advName = value; }
        }
        [NonSerialized]
        private Image advPic;

        
        public Image AdvPic
        {
            get { return advPic; }
            set { advPic = value; }
        }

        public string AdImagePath;

        private string advPicLink;

        public string AdvPicLink
        {
            get { return advPicLink; }
            set { advPicLink = value; }
        }

        private string advWeizhiOne;

        public string AdvWeizhiOne
        {
            get { return advWeizhiOne; }
            set { advWeizhiOne = value; }
        }

        private string advWeizhiTwo;

        public string AdvWeizhiTwo
        {
            get { return advWeizhiTwo; }
            set { advWeizhiTwo = value; }
        }

    }
}
