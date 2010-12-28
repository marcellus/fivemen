using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Windows.Forms;
using FT.Windows.Forms.SimpleLog;

namespace FT.Windows.Forms.Monitor
{
    public abstract class BaseMonitor
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        protected string monitorname;

        public BaseMonitor(NotifyIcon icon, int interval,string monitor)
        {
            notifyIcon1 = icon;
            monitorname = monitor;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = interval;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        protected void CreateLog(string detail)
        {
            CustomLog log = new CustomLog();
            log.OptDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OptDetail = detail;
            log.OptUser = monitorname;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
        }




        protected void SetHintText(String str)
        {
            this.notifyIcon1.Text = "监控软件-" + str;
        }


        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.DoTask();
           timer1.Start();


        }

        protected abstract void DoTask();

        
    }
}
