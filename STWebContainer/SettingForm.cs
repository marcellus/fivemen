using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;
using System.Diagnostics;

namespace STWebContainer
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void btnShutDown_Click(object sender, EventArgs e)
        {
            try
            {
                //启动本地程序并执行命令
                Process.Start("Shutdown.exe", " -s -t 0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            try
            {
                //启动本地程序并执行命令
                Process.Start("shutdown.exe", " -r -t 0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            STWebContainerSetting set = StaticCacheManager.GetConfig<STWebContainerSetting>();
            set.Url=this.txtUrl.Text;
            StaticCacheManager.SaveConfig(set);
            set.Hour = this.dateTimePicker1.Value.Hour;
            set.Minute = this.dateTimePicker1.Value.Minute;
            set.IsTimer = this.cbIsTimer.Checked;
            set.IsShowToolBar=this.cbShowToolBar.Checked ;
            MessageBox.Show("保存成功！");
            this.Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            STWebContainerSetting set = StaticCacheManager.GetConfig<STWebContainerSetting>();
            this.txtUrl.Text = set.Url;
            DateTime now=System.DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, set.Hour, set.Minute, 0);
            this.dateTimePicker1.Value=dt;
            this.cbIsTimer.Checked = set.IsTimer;
            this.cbShowToolBar.Checked = set.IsShowToolBar;
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            Form frm = new ChangePwdForm();
            frm.ShowDialog();

        }
    }
}
