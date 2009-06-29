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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.About();
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.Quit();
        }

        private void �鿴��־ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ShowLogs();
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ChangePwd();
        }

        private void �����־ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.ClearLogs();
        }

        private void ϵͳ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(NoUserHelper.Unlock())
            {
                Form form=new SystemMonitorConfig();
                form.ShowDialog();
            }
        }

        public const string OptUserConst = "ͼƬ���빤��";

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemConfig config=StaticCacheManager.GetConfig<SystemConfig>();
            timer1.Interval = config.MonitorTimes;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            this.CreateLog("ϵͳ������");
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
            string tmp = "�ҵ����Ŀ¼��������Ƭ���룡";
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
            this.notifyIcon1.Text = "��ʻ��ͼƬ������-" + str;
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
                        if (MessageBoxHelper.Confirm("���ּ��Ŀ¼���Ƿ������Ƭ���룿"))
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