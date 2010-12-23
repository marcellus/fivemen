using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using log4net;
using FT.Windows.Forms.NoUser;
using FT.Commons.Cache;
using FT.Windows.Forms.SimpleLog;
using FT.Commons.Tools;
using FT.Windows.Forms.Monitor;

namespace WindowMonitor
{
    public partial class BaseMonitorForm : Form
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");
        //protected static ILog log = log4net.LogManager.GetLogger("tools");

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Debug(object obj)
        {
            if (log != null && log.IsDebugEnabled)
            {
                log.Debug(obj);
            }
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Info(object obj)
        {
            if (log != null && log.IsInfoEnabled)
            {
                log.Info(obj);
            }
        }

        public BaseMonitorForm()
        {
            InitializeComponent();
        }

        public void CreateLog(string detail)
        {
            CustomLog log = new CustomLog();
            log.OptDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OptDetail = detail;
            log.OptUser = "SystemMonitor";
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
        }

        protected override void OnActivated(EventArgs e)
        {
            this.Hide();
        }


        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.About();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.Quit();
        }

        private void 查看日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ShowLogs();
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ChangePwd();
        }

        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ClearLogs();
        }

        private void BaseMonitorForm_Load(object sender, EventArgs e)
        {
            SimpleTimeMonitor monitor = new SimpleTimeMonitor(notifyIcon1, 3000, "简单的时间监控器1");
            SimpleTimeMonitor monitor2 = new SimpleTimeMonitor(notifyIcon1, 3000, "简单的时间监控器2");
            this.Text = System.Configuration.ConfigurationManager.AppSettings["MonitorName"].ToString();
            this.notifyIcon1.Text = this.Text;
            this.CreateLog("系统初启动");
        }
    }
}
