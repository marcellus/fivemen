using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Forms.Monitor
{
    public class SimpleTimeMonitor:BaseMonitor
    {
        protected override void DoTask()
        {
            string hint = "当前时间：" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.SetHintText(hint);
            this.CreateLog(hint);
            //throw new NotImplementedException();
        }
        public SimpleTimeMonitor(NotifyIcon icon, int interval, string monitor):base( icon, interval, monitor)
        {
           
        }
    }
}
