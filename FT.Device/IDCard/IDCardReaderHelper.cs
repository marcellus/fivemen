using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;

namespace FT.Device.IDCard
{
    /// <summary>
    /// �����������İ�����
    /// </summary>
    public class IDCardReaderHelper:FT.Commons.Tools.BaseHelper
    {
        private IDCardReader reader;
        private Timer timer;
        private De_ReadICCardComplete completeDelegate;

        private bool isOpen;

        public bool IsOpen
        {
            get { return isOpen; }
        }

        private IDCardConfig config;

        public IDCardReaderHelper()
        {
            config = StaticCacheManager.GetConfig<IDCardConfig>();
            reader = new IDCardReader();
            timer = new Timer();
            timer.Interval = config.MiniSecond;
            timer.Tick += new EventHandler(timer_Tick);
        }

        public void StopWatching()
        {
            if (isOpen)
            {
                timer.Stop();
                isOpen = false;
            }
        }

        public void StartWatching()
        {
            if (!isOpen)
            {
                timer.Start();
                isOpen = true;
            }
        }

        public IDCardReaderHelper(De_ReadICCardComplete completeDelegate)
        {
            config=StaticCacheManager.GetConfig<IDCardConfig>();
            reader = new IDCardReader();
            timer = new Timer();
            timer.Interval = config.MiniSecond;
            timer.Tick += new EventHandler(timer_Tick);
            reader.ReadICCardComplete += completeDelegate;
            this.completeDelegate = completeDelegate;
            timer.Start();
        }
        public IDCardReaderHelper(De_ReadICCardComplete completeDelegate, int minisecond)
        {
            reader = new IDCardReader();
            timer = new Timer();
            timer.Interval = minisecond;
            timer.Tick += new EventHandler(timer_Tick);
            reader.ReadICCardComplete += completeDelegate;
            this.completeDelegate = completeDelegate;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            log.Debug("��ʼ��ʱ����");
            int result = reader.ReadICCard();
            if (result != 0)
            {
                
            }
            if (result == 0 && completeDelegate != null)
            {
                completeDelegate(reader.UserIdCard.Clone());
                //System.Threading.Thread.Sleep(80);
            }
            else if(result == 0 && completeDelegate == null)
            {
                log.Debug("�������֤���룬׼���������֤���롣����");
                
                SendKeys.SendWait(reader.UserIdCard.IDC);
                if (config.AddReturn)
                {
                    SendKeys.SendWait("{ENTER}");
                }
            }
            
            if (result == -1)
            {
                log.Debug("û���ҵ����ʵĶ�������ֹͣ������");
                return;
            }
            timer.Start();
        }
    }
}
