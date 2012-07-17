using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.WindowsService.SystemInfo;
using System.IO;

namespace SecurityInitSystemTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKtIESelector_Click(object sender, EventArgs e)
        {
            this.txtKtIEPath.Text = FileDialogHelper.OpenDir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbIEVersions.Text = "6.00.2900.2180";
        }

        private  void SetText(TextBox txt, string str)
        {
            if (txt.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(SetLogText);
                this.Invoke(d, new object[] { txt,str });
            }
            else
            {
                txt.Text = str;
            }
        }

        private void SetLogText(TextBox txt, string str)
        {
            txt.Text = str;
        }

        private  void AppendText(TextBox txt, string str)
        {
            if (txt.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(AppendLogText);
                this.Invoke(d, new object[] { txt, str });
            }
            else
            {
                txt.Text = str;
            }
        }

        private void AppendLogText(TextBox txt, string str)
        {
           // txt.Text += str;
            txt.AppendText(str);
            txt.ScrollToCaret();
            txt.Focus();
            txt.Select(txt.TextLength,0);
            txt.ScrollToCaret();
            
        }

        private void AppendLogText(RichTextBox txt, string str)
        {
            // txt.Text += str;
            txt.AppendText(str);
            txt.ScrollToCaret();
            txt.Focus();
            txt.Select(txt.TextLength, 0);
            txt.ScrollToCaret();

        }

        private void btnKtIEInit_Click(object sender, EventArgs e)
        {
            string system="IE";
            string systemVersion=this.cbIEVersions.Text;
            string dirPath=this.txtKtIEPath.Text.Trim();
            this.FileCounter = 0;
            //this.Invoke(
            this.txtKtIEInitLog.Text = string.Empty;
            ComputerInitHelper.InitFolderMd5(system, systemVersion, dirPath, dirPath, new InitFileMd5Delegate(InitIEFileMd5));
            this.txtKtIEInitLog.Text += "\r\n\r\n处理完毕！共"+FileCounter.ToString()+"文件！";
        }
        private int FileCounter = 0;

        private void InitIEFileMd5(string system, string systemVersion, string dirPath, FileInfo file)
        {
            MonitorFileInfo result = new MonitorFileInfo(system, systemVersion, dirPath, file);
            FileCounter++;
            //this.txtKtIEInitLog.Text += "\r\n处理完文件"+result.ToString();
            this.AppendLogText(this.txtKtIEInitLog, "\r\n序号:"+FileCounter.ToString()+"处理完文件" + result.ToString());

        }

        private void InitWzhFileMd5(string system, string systemVersion, string dirPath, FileInfo file)
        {
            MonitorFileInfo result = new MonitorFileInfo(system, systemVersion, dirPath, file);
            FileCounter++;
            //this.txtKtIEInitLog.Text += "\r\n处理完文件"+result.ToString();
            this.AppendLogText(this.txtWzhInitLog, "\r\n序号:" + FileCounter.ToString() + "处理完文件" + result.ToString());

        }

        private void btnWzhFolderSelector_Click(object sender, EventArgs e)
        {
            this.txtWzhPath.Text = FileDialogHelper.OpenDir();
        }

        private void btnWzhInit_Click(object sender, EventArgs e)
        {
            string system = "WZH-APP";
            string systemVersion = this.cbWzhVersions.Text;
            string dirPath = this.txtWzhPath.Text.Trim();
            this.FileCounter = 0;
            //this.Invoke(
            this.txtKtIEInitLog.Text = string.Empty;
            ComputerInitHelper.InitFolderMd5(system, systemVersion, dirPath, dirPath, new InitFileMd5Delegate(InitWzhFileMd5));
            this.txtWzhInitLog.Text += "\r\n\r\n处理完毕！共" + FileCounter.ToString() + "文件！";
        }

        private void btnInitProcess_Click(object sender, EventArgs e)
        {

        }

        private int ProcessCounter = 0;

        private int ServiceCounter = 0;

        private void btnInitService_Click(object sender, EventArgs e)
        {
            string system = this.lbSystem.Text;
            string systemVersion = this.lbSystemVersion.Text.Trim();
            this.ServiceCounter = 0;
            //this.Invoke(
            this.txtSystemInitLog.Text = string.Empty;
            ComputerInitHelper.InitSystemServices(system, systemVersion, new InitServicesDelegate(InitServices));
            this.txtSystemInitLog.Text += "\r\n\r\n处理完毕！共" + ServiceCounter.ToString() + "服务！";
        }

        private void InitServices(string system, string systemVersion, System.ServiceProcess.ServiceController control)
        {
            MonitorServiceInfo result = new MonitorServiceInfo(system, systemVersion, control);
            ServiceCounter++;
            //this.txtKtIEInitLog.Text += "\r\n处理完文件"+result.ToString();
            this.AppendLogText(this.txtSystemInitLog, "\r\n序号:" + ServiceCounter.ToString() + "处理完服务" + result.ToString());

        }

        private void btnInitNetwork_Click(object sender, EventArgs e)
        {

        }

        private void btnInitHardware_Click(object sender, EventArgs e)
        {

        }

        private void btnInitOperationSystem_Click(object sender, EventArgs e)
        {

        }

        private void InitComputerInfo(ComputerInfo computerInfo)
        {
           
            //this.txtKtIEInitLog.Text += "\r\n处理完文件"+result.ToString();
            this.lbSystem.Text = computerInfo.System;
            this.lbSystemVersion.Text = computerInfo.SystemVersion;
            this.AppendLogText(this.txtSystemInitLog, "\r\n初始化系统\r\n:" + computerInfo.ToString());

        }

        private void btnInitSystemInfo_Click(object sender, EventArgs e)
        {
            this.txtSystemInitLog.Text = string.Empty;
            ComputerInitHelper.InitComputerInfo(new InitComputerInfoDelegate(InitComputerInfo));
            this.txtSystemInitLog.Text += "\r\n\r\n处理完毕！";
        }

       
    }
}
