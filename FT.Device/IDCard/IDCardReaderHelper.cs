using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;

namespace FT.Device.IDCard
{
    /// <summary>
    /// 操作读卡器的帮助类
    /// </summary>
    public class IDCardReaderHelper:FT.Commons.Tools.BaseHelper
    {
        private IDCardReader reader;
        private Timer timer;
        public IDCardReaderHelper(De_ReadICCardComplete completeDelegate)
        {
            IDCardConfig config=StaticCacheManager.GetConfig<IDCardConfig>();
            reader = new IDCardReader();
            timer = new Timer();
            timer.Interval = config.MiniSecond;
            timer.Tick += new EventHandler(timer_Tick);
            reader.ReadICCardComplete += completeDelegate;
            timer.Start();
        }
        public IDCardReaderHelper(De_ReadICCardComplete completeDelegate, int minisecond)
        {
            reader = new IDCardReader();
            timer = new Timer();
            timer.Interval = minisecond;
            timer.Tick += new EventHandler(timer_Tick);
            reader.ReadICCardComplete += completeDelegate;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            log.Debug("开始定时器！");
            int result = reader.ReadICCard();
            if (result != 0)
            {
                
            }
            if (result == -1)
            {
                log.Debug("没有找到合适的读卡器，停止读卡！");
                return;
            }
            timer.Start();
        }
    }
}
