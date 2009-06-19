using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms.CommonForm
{
    [Serializable]
    public class CapturePhotoSet
    {
        public bool BgRgbEnable = true;

        public int SeCha = 30;

        public int BgRgbR = 0;
        public int BgRgbG = 0;
        public int BgRgbB = 0;

        public int CapWidth = 130;

        public int CapHeight = 170;

        public int DevWidth = 256;

        public int DevHeight = 192;

        public int Dpi = 300;
    }
}
