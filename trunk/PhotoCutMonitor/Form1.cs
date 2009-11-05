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

namespace PhotoCutMonitor
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

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
            timer1.Interval = config.MonitorTimes;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            this.CreateLog("系统初启动");
        }

        private const string OptUserConst = "图片裁剪工具";

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
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
                if (FileHelper.CheckDirExists(config.MonitorPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);
                    FileInfo[] files=dir.GetFiles();
                    if (files.Length > 0)
                    {
                        this.CutPhoto(files,config);
                    }

                }
                else
                {

                }

                timer1.Start();
            
        }

        private void CutPhoto(FileInfo[] files,SystemConfig config)
        {
            FileInfo file = null;
            int error = 0;
            string unzipdir = Path.Combine(config.BakPath, System.DateTime.Now.ToString("yyyyMMddHHmmss"));
            FileHelper.CheckDirExistsAndCreate(unzipdir);
            for (int i = 0; i < files.Length; i++)
            {
                file = files[i];
                if(file.Extension.ToUpper()==".RAR")
                {
                    
                    if (FileHelper.UnZipDir(file.FullName, unzipdir
                         , "htcompany")
                     )
                    {
                        DirectoryInfo tmpdir=new DirectoryInfo(unzipdir);
                        FileInfo[] tmpfiles=tmpdir.GetFiles();
                        FileInfo tmpfile=null;
                        Bitmap tmpsrc=null;
                        for (int j = 0; j < tmpfiles.Length;j++ )
                        {
                            tmpfile=tmpfiles[j];
                            tmpsrc = (Bitmap)Bitmap.FromFile(tmpfile.FullName);
                            Bitmap map2= ImageHelper.KiResizeImage(tmpsrc, config.KitWidth, config.KitHeight, 1);
                            Bitmap map = ImageHelper.KiCut(map2, config.StartX, config.StartY, config.CutWidth, config.CutLength);
                            map.Save(Path.Combine(config.CutPath, tmpfile.Name), System.Drawing.Imaging.ImageFormat.Jpeg);
                            tmpsrc.Dispose();
                            tmpsrc = null;
                            map2.Dispose();
                            map2 = null;
                            map.Dispose();
                            map = null;
                        }
                        //TODO:开始裁剪
                        File.Delete(file.FullName);
                    }
                    else
                    {
                        string dir=Path.Combine
                            (config.BakPath ,"非法的压缩文件");
                        error++;  
                       FileHelper.CheckDirExistsAndCreate(dir);
                        File.Copy(file.FullName, Path.Combine
                            (dir, file.Name),true);
                        File.Delete(file.FullName);
                    }
                    
                }
                else
                {
                    Bitmap tmpsrc = null;
                   
                        tmpsrc = (Bitmap)Bitmap.FromFile(file.FullName);
                        Bitmap map2 = ImageHelper.KiResizeImage(tmpsrc, config.KitWidth, config.KitHeight, 1);
                        Bitmap map = ImageHelper.KiCut(map2, config.StartX, config.StartY, config.CutWidth, config.CutLength);
                        map.Save(Path.Combine(config.CutPath, file.Name), System.Drawing.Imaging.ImageFormat.Jpeg);
                        tmpsrc.Dispose();
                        tmpsrc = null;
                        map2.Dispose();
                        map2 = null;
                        map.Dispose();
                        map = null;
                        File.Copy(file.FullName, Path.Combine(unzipdir, file.Name));
                    //TODO:开始裁剪
                    File.Delete(file.FullName);
                }
                
            }
            if (error > 0)
            {
                if (MessageBoxHelper.Confirm("有" + error.ToString() + "张处理失败压缩包，是否打开查看?"))
                    System.Diagnostics.Process.Start("explorer.exe", Path.Combine(config.BakPath, "非法的压缩文件").Replace("/", "\\"));

            }
                
           
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

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoUserHelper.Quit();
        }
    }
}