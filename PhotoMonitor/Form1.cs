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

        private DrvService service;

        private DrvService GetService(SystemConfig config)
        {

            if(service==null)
            {
                
                service = new DrvService();
                service.Url = config.ServiceIp;
            }
            return service;
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
            string nowzp = string.Empty;
            int success = 0;
            int error = 0;
           
            string idcardtype="A";
            string filename=string.Empty;
            string tmpimgdata = string.Empty;
           
            
             for (int i = 0; i < files.Length;i++ )
             {
                 file = files[i];
                 this.SetHintText("正在处理"+file.Name);
                 if (file.Extension.ToUpper() == ".JPG" || file.Extension.ToUpper() == ".JPEG")
                 {
                     filename = file.Name;
                     try
                     {
                         
                         if(! Regex.IsMatch(file.Name[0].ToString(),"[0-9]"))
                         {
                             idcardtype=file.Name[0].ToString();
                         }
                         tmpimgdata=this.GetService(config).getDrvimage(idcardtype, filename, config.ServiceReadSn);
                         if(tmpimgdata!=null&&tmpimgdata.Length>0)
                         {
                             this.CreateLog("已存在照片" + file.Name);
                             FileHelper.CheckDirExistsAndCreate(bakdir + "已存在照片/");
                             File.Copy(file.FullName, bakdir +"已存在照片/"+ file.Name, true);
                             file.Delete();
                             
                         }
                         else
                         {
                             this.GetService(config).write_drvimage(idcardtype, filename,
                                 ImageHelper.ImageToBase64Str(file.FullName),config.ServiceWriteSn);

                             File.Copy(file.FullName, bakdir +file.Name, true);
                             file.Delete();
                         }
                         success++;
                         
                     }
                     
                     catch (System.Exception ex)
                     {
                         error++;
                         FileHelper.CheckDirExistsAndCreate(bakdir + "处理失败的照片/");
                         this.CreateLog("处理失败的照片" + file.Name + "失败的原因" + ex.Message);
                         File.Copy(file.FullName, bakdir + "处理失败的照片/" + file.Name, true);
                         file.Delete();
                         
                     }
                     
                 }
                 else
                 {
                     error++;
                     this.CreateLog("非照片文件" + file.Name);
                     FileHelper.CheckDirExistsAndCreate(bakdir + "非照片文件/");
                     File.Copy(file.FullName, bakdir + "非照片文件/" + file.Name, true);
                     file.Delete();
                    
                 }
             }
             int all=error+success;
             this.SetHintText("处理完毕，共" + all.ToString() + "照片，成功" + success + "张，失败" + error + "张！");
            if(error>0)
            {
                if (MessageBoxHelper.Confirm("有"+error.ToString()+"张处理失败的照片，是否打开图片文件夹?"))
                System.Diagnostics.Process.Start("explorer.exe", bakdir.Replace("/","\\"));

            }

        }

        public void SetHintText(String str)
        {
            this.notifyIcon1.Text = "驾驶人图片监控软件-" + str;
        }

        /// <summary>
        /// 是否接口有效
        /// </summary>
        private bool InterfaceEnabled = true;

        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if(this.InterfaceEnabled)
            {
                SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
                if (FileHelper.CheckDirExists(config.MonitorPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);

                    if (dir.GetDirectories().Length > 0 && dir.GetDirectories()[0].GetFiles().Length > 0)
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
}