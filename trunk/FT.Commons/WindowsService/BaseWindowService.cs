using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using log4net;

namespace FT.Commons.WindowsService
{
    public abstract  partial class BaseWindowService : ServiceBase
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.WindowsService");
        private System.Timers.Timer timer1;

        public BaseWindowService(int interval)
        {
            InitializeComponent();
            timer1 = new System.Timers.Timer(interval);
            timer1.Enabled = true;
            timer1.AutoReset = true;
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            //timer1.Start();
            
        }

        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer1.Enabled = false;
            log.Debug("开始执行DoTask");
            this.DoTask();
            log.Debug("结束执行DoTask");
            timer1.Enabled = true;
        }
        protected void Beep()
        {
            Console.Beep();
        }

        protected void Log(string logType,string logStr)
        {
            Console.WriteLine("日志类型{0}，内容{1}",logType,logStr);
            log.Debug(log);
        }
        protected void Sms(string logStr)
        {
        }

      
        
        /// <summary>
        /// 执行线程工作
        /// </summary>
        /// <returns>判断是否正常运作</returns>
        public abstract bool DoTask();
        /// <summary>
        /// 设计服务名，必须实现
        /// </summary>
        protected abstract void SetServiceName();

        protected void SetServiceName(string name)
        {
            this.ServiceName = name + "服务";
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            log.Debug("服务OnStart了"+timer1);
            timer1.Enabled = true;
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            log.Debug("服务OnStop");
            timer1.Enabled = false;
        }
    }
}
