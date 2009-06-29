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

namespace PhotoMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(NoUserHelper.Unlock())
            {
                Form form=new SystemMonitorConfig();
                form.ShowDialog();
            }
        }

        public const string OptUserConst = "图片导入工具";

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemConfig config=StaticCacheManager.GetConfig<SystemConfig>();
            timer1.Interval = config.MonitorTimes;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            this.CreateLog("系统初启动");
        }

        public void CreateLog(string detail)
        {
            CustomLog log = new CustomLog();
            log.OptDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OptDetail = detail;
            log.OptUser = OptUserConst;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
        }

        public void ImportPhto(SystemConfig config)
        {
            string tmp = "找到监控目录，进行照片导入！";
            this.CreateLog(tmp);
            this.SetHintText(tmp);
             DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);
            string school=dir.GetDirectories()[0].Name;
            string impdate=System.DateTime.Now.ToString("yyyyMMddHHmmss");
             FileInfo[] files=dir.GetDirectories()[0].GetFiles();
            FileInfo file=null;
            string bakdir=config.BakPath + "/"
                             + school + "/" + impdate
                             + "/";
            FileHelper.CheckDirExistsAndCreate(bakdir);
             for (int i = 0; i < files.Length;i++ )
             {
                 file = files[i];
                 if (file.Extension.ToUpper() == ".JPG" || file.Extension.ToUpper() == ".JPEG")
                 {
                     try
                     {
                         
                         File.Copy(file.FullName,bakdir + file.Name, true);
                         file.Delete();
                     }
                     catch (System.Exception ex)
                     {
                        
                     }
                     
                 }
             }
        }

        public void SetHintText(String str)
        {
            this.notifyIcon1.Text = "驾驶人图片监控软件-" + str;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
            if(FileHelper.CheckDirExists(config.MonitorPath))
            {
                DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);

                if (dir.GetDirectories().Length>0&&dir.GetDirectories()[0].GetFiles().Length > 0)
                {
                    if (config.HintImport)
                    {
                        if (MessageBoxHelper.Confirm("发现监控目录，是否进行照片导入？"))
                        {
                            this.ImportPhto(config);
                        }
                    }
                    else
                    {
                        this.ImportPhto(config);
                    }
                }
                
            }
            else
            {

            }

            timer1.Start();
        } 
    }
}