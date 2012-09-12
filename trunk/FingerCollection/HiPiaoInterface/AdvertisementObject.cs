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
