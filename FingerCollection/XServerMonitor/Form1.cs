using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using FT.Commons.Win32;
using System.Threading;
using FT.Commons.Tools;
using log4net;
using FT.Commons.Cache;

namespace XServerMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread thread;
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");
        private void BeginMonitor()
        {
            int sec = Convert.ToInt32(this.txtTimerSecond.Text.Trim());
            int MonitorLineCount = Convert.ToInt32(this.txtMonitorLine.Text.Trim());
            int days = Convert.ToInt32(this.txtLogDays.Text.Trim());
            string monitorPath=this.txtMonitorPath.Text.Trim();

            while (true)
            {
                try
                {
                    DateTime begin = System.DateTime.Now;
                    string path = string.Empty;
                    string bakRestart = string.Empty;
                    string bakNormal = string.Empty;
                    string date = System.DateTime.Now.ToString("yyyyMMdd");
                    DirectoryInfo dir;
                    if (monitorPath.Length > 0)
                    {
                        dir = new DirectoryInfo(monitorPath);
                    }
                    else
                    {
                        dir = new DirectoryInfo(Application.StartupPath);
                    }
                    FileInfo[] files = dir.GetFiles();
                    FileInfo fileTemp = null;
                    string olddate = System.DateTime.Now.AddDays(-days).ToString("yyyyMMdd");
                    for (int i = 0; i < files.Length; i++)
                    {
                        fileTemp = files[i];
                        if (fileTemp.Name.StartsWith(olddate))
                        {
                            fileTemp.Delete();
                        }
                    }
                    if (this.txtMonitorPath.Text.Trim().Length > 0)
                    {
                        path = this.txtMonitorPath.Text.Trim() + "\\" + date + ".txt";
                        bakRestart = this.txtMonitorPath.Text.Trim() + "\\" + date + "-" + System.DateTime.Now.ToString("HHmmss") + "-restart.txt";
                        bakNormal = this.txtMonitorPath.Text.Trim() + "\\" + date + "-" + System.DateTime.Now.ToString("HHmmss") + "-normal.txt";
                    }
                    else
                    {
                        path = date + ".txt";
                        bakRestart = date + "-" + System.DateTime.Now.ToString("HHmmss") + "-restart.txt";
                        bakNormal = date + "-" + System.DateTime.Now.ToString("HHmmss") + "-normal.txt";
                    }

                    FileInfo file = new FileInfo(path);
                    if (file.Exists)
                    {
                        int counter = 0;
                        bool findError = false;
                        using (FileStream file_s =
                            //new FileStream(path, FileMode.Open);
                             File.Open(path, FileMode.Open, FileAccess.Read))
                        {
                            using (StreamReader sr = new StreamReader(file_s))
                            //using (StreamReader sr = new StreamReader(path))
                            {
                                String line;


                                // Read and display lines from the file until the end of 
                                // the file is reached.
                                while ((line = sr.ReadLine()) != null)
                                {
                                    counter++;
                                    WindowFormDelegate.SetMainThreadHint(lbHint, string.Format(HintFormatter, counter, date));
                                    WindowFormDelegate.SetMainThreadHint(lbLogContent, string.Format(HintContentFormatter, line));

                                    if (counter <= LineCounter)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (line.IndexOf(ErrorString) != -1)
                                        {

                                            findError = true;
                                            this.LineCounter = counter;
                                            break;
                                        }
                                    }

                                }
                                // while(sr.EndOfStream



                            }

                            if (findError)
                            {
                                FT.Commons.Tools.WindowServicesHelper.ForceStop(XServerName);
                                try
                                {
                                    file.CopyTo(bakRestart);
                                    file.Delete();
                                    this.LineCounter = 0;
                                }
                                catch (Exception ex)
                                {
                                    log.Info(bakRestart);
                                    log.Info(ex);
                                    //MessageBoxHelper.Show(ex.ToString());
                                }
                                System.Threading.Thread.Sleep(2000);
                                FT.Commons.Tools.WindowServicesHelper.ForceStart(XServerName);
                            }
                            else if (counter > MonitorLineCount)
                            {
                                try
                                {
                                    file.CopyTo(bakNormal);
                                    file.Delete();
                                    this.LineCounter = 0;
                                }
                                catch (Exception ex)
                                {
                                    log.Info(bakNormal);
                                    log.Info(ex);
                                    //MessageBoxHelper.Show(ex.ToString());
                                }
                            }
                        }
                    }

                    DateTime end = System.DateTime.Now;
                    TimeSpan ts = end.Subtract(begin);
                    WindowFormDelegate.SetMainThreadHint(lbUseTimes, ts.TotalMilliseconds.ToString());

                    System.Threading.Thread.Sleep(sec);
                }
                catch (Exception ex)
                {
                    log.Info("大循环异常："+ex);
                }
            }
        }

        private void btnStartMonitor_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir;
            if (this.txtMonitorPath.Text.Trim().Length > 0)
            {
                dir = new DirectoryInfo(this.txtMonitorPath.Text.Trim());
            }
            else
            {
                dir = new DirectoryInfo(Application.StartupPath);
            }
            if (!dir.Exists)
            {
                return;
            }
            if (thread == null)
            {
                thread = new Thread(new ThreadStart(this.BeginMonitor));
                thread.IsBackground = true;
            }
            thread.Start();

            /*
            this.timer1.Interval = Convert.ToInt32(this.txtTimerSecond.Text.Trim());
            this.timer1.Start();
             * * */
            this.btnStartMonitor.Enabled = false;
            this.btnStopMonitor.Enabled = true;
             
        }

        private void btnStopMonitor_Click(object sender, EventArgs e)
        {
            //this.timer1.Stop();
            thread.Abort();
            thread = null;
            this.btnStartMonitor.Enabled = true;
            this.btnStopMonitor.Enabled = false;
        }

        private int LineCounter = 0;

        private static string HintFormatter = "监控当前行：{0}，当前监控时间：{1}";
        private static string HintContentFormatter = "监控日志内容：{0}";

        private static string ErrorString = "Invalid Request for Service";
        private static string XServerName = "sXServer";

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
           
            
            this.timer1.Start();
        }

        private void btnFolderSelector_Click(object sender, EventArgs e)
        {
            this.txtMonitorPath.Text=FT.Commons.Tools.FileDialogHelper.OpenDir();
        }
        MonitorConfig config;

        private void Form1_Load(object sender, EventArgs e)
        {
           // loader = new ConfigLoader<MonitorConfig>(this);
           
           config= StaticCacheManager.GetConfig<MonitorConfig>();
           FormHelper.SetDataToForm(this, config);
           btnStartMonitor_Click(null,null);
            
        }
        ConfigLoader<MonitorConfig> loader;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

           // loader.SaveConfig();
        
            FormHelper.GetDataFromForm(this, config);
            StaticCacheManager.SaveConfig<MonitorConfig>(config);
        }
    }
}
