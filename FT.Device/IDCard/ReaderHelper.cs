using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FT.Device.IDCard
{
    /// <summary>
    /// �����������İ�����
    /// </summary>
    public class ReaderHelper:FT.Commons.Tools.BaseHelper
    {
        private IDCardReader reader;
        private Timer timer;
        public ReaderHelper(De_ReadICCardComplete completeDelegate,int minisecond )
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
            log.Debug("��ʼ��ʱ����");
            int result = reader.ReadICCard();
            if (result != 0)
            {
                
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
