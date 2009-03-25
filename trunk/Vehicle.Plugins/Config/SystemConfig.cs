using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Plugins
{
    [Serializable]
    public class SystemConfig
    {
        public string PhotoDir;

        public int CompressLength = 81920;

        public int CompressRate = 30;

        //368, 230
        public int ImageWidth = 368;

        public int ImageHeight = 230;

        public bool UseCardReader = true;

        public int CardReaderInterval = 500;

        public bool ReadHgz = true;
    }
}
