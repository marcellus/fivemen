using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.NoUser;
using FT.Commons.Cache;
using FT.Windows.Forms.SimpleLog;
using FT.Commons.Tools;
using System.IO;
using System.Text.RegularExpressions;
using log4net;
using System.Xml;
using FT.Windows.ExternalTool;
using FT.Windows.Forms.Domain;

namespace PhotoZipUpTools
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            this.Hide();
        }
        private ProgramRegConfig regconfig;
        private void Form1_Load(object sender, EventArgs e)
        {
            regconfig = StaticCacheManager.GetConfig<ProgramRegConfig>();
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
            if(config.AutoUpload)
            {
                timer1.Interval = config.MonitorTimes;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
            }
           
            this.CreateLog("系统初启动");
        }
        private const string OptUserConst = "驾驶人图片上传工具";

        public void CreateLog(string detail)
        {
            CustomLog log = new CustomLog();
            log.OptDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OptDetail = detail;
            log.OptUser = OptUserConst;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            
                

                timer1.Start();
            
        }

        public void SetHintText(String str)
        {
            this.notifyIcon1.Text = "驾驶人图片监控软件-" + str;
        }

        private void 查看日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ShowLogs();
        }

        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ClearLogs();
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ChangePwd();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.About();
        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NoUserHelper.Unlock())
            {
                Form form = new SystemConfigForm();
                form.ShowDialog();
            }
        }

        private bool CheckNeedProcess(SystemConfig config)
        {
            bool result=false;
             if (FileHelper.CheckDirExists(config.MonitorPath))
            {
                DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);
                if (dir.GetFiles().Length > 0)
                {
                    result=true;
                }
             }
            return result;
        }

        private string ZipFiles(SystemConfig config)
        {
            string filename=Path.Combine(config.BakPath,
           regconfig.Company
                        + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".rar");
            FileHelper.ZipDir(config.MonitorPath,filename , "htcompany");
                    
            return filename;
        }

        private void 图片转换测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
            this.notifyIcon1.Text = "1、正在开始查找照片，请稍候...";
            System.Threading.Thread.Sleep(1000);
            if(this.CheckNeedProcess(config))
            {
                this.notifyIcon1.Text = "2、正在准备打包照片，请稍候...";
                string filename = this.ZipFiles(config);
                this.notifyIcon1.Text = "3、正在准备上传到FTP，请稍候...";

                try
                {
                    FTPHelper ftp = new FTPHelper(config.FtpUrl, config.FtpName, config.FtpPassword);
                    //ftp.Connect(config.FtpUrl, config.FtpName, config.FtpPassword);
                    int perc = 0;
                    //int tmp1 = filename.LastIndexOf("/");
                   // int tmp2 = filename.LastIndexOf("\\");
                    if(config.FtpFolder.Trim().Length>0)
                    {
                        ftp.ChangeDir(config.FtpFolder);
                    }
                    string name=filename.Substring(filename.LastIndexOf("\\")+1);
                    ftp.OpenUpload(filename,name);
                    while(ftp.DoUpload()>0)
                    {
                        perc = (int)((ftp.BytesTotal * 100) / ftp.FileSize);
                       this.notifyIcon1.Text=String.Format("\r上传: {0}/{1} {2}%",
                          ftp.BytesTotal, ftp.FileSize, perc);
                    }
                    
                    this.notifyIcon1.Text = "4、上传到FTP成功！";
                    FileHelper.CutFolder2Another(config.MonitorPath, Path.Combine(config.BakPath, System.DateTime.Now.ToString("yyyyMMddHHmmss")));
                    this.notifyIcon1.Text = "5、删除并备份文件，顺利完成本次上传！";
                }
                catch(Exception ex)
                {
                    this.notifyIcon1.Text = "4、上传到FTP被中断，错误信息请看日志！";
                    this.CreateLog(ex.ToString());
                }

               
            }
            else{

                this.notifyIcon1.Text = "5、没有需要上传的照片！";
            }
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.Quit();
        }
    }
}