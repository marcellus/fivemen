using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;
using FT.Commons.Tools;

namespace HiPiaoTerminal.Maintain
{
    public partial class ManagerSystemConfigPanel : HiPiaoTerminal.UserControlEx.MaintainParentPanel
    {
        public ManagerSystemConfigPanel()
        {
            InitializeComponent();
        }

        private void ManagerAutoClosePanel_Load(object sender, EventArgs e)
        {
            try
            {
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                this.txtInterfaceUrl.Text = config.HiPiaoInterfaceUrl;
                string[] ips = config.CinemaServerIp.Split('.');
                if (ips.Length == 4)
                {
                    this.txtIp1.Text = ips[0];
                    this.txtIp2.Text = ips[1];
                    this.txtIp3.Text = ips[2];
                    this.txtIp4.Text = ips[3];


                }
                this.checkShow.Checked = config.AllowShowMouse;
                this.checkHide.Checked = !config.AllowShowMouse;

                this.txtPort.Text = config.CinemaServerPort.ToString();

            }
            catch
            {
            }
        }

        private void btnCancelSave_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMaintain();
        }

        private void btnKeepSave_Click(object sender, EventArgs e)
        {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
           // config.HiPiaoInterfaceUrl = this.txtInterfaceUrl.Text.Trim();
            config.CinemaServerIp = this.GetIp();
            config.CinemaServerPort = Convert.ToInt32(this.txtPort.Text);
            config.AllowShowMouse = this.checkShow.Checked;
            FT.Commons.Cache.StaticCacheManager.SaveConfig<SystemConfig>(config);
            this.lbReturnMsg.Text = "修改成功！";
           // GlobalTools.ReturnMaintain();
        }

        private string GetIp()
        {
            return string.Format("{0}.{1}.{2}.{3}", this.txtIp1.Text, this.txtIp2.Text, this.txtIp3.Text, this.txtIp4.Text);
        }

        private void checkHide_Click(object sender, EventArgs e)
        {
            this.checkShow.Checked = !this.checkHide.Checked;
        }

        private void checkShow_Click(object sender, EventArgs e)
        {
            this.checkHide.Checked = !this.checkShow.Checked;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if(WindowExHelper.CanConnectionTo(this.GetIp()))
            {
                this.lbReturnMsg.Text = "网络连接成功！";
            }
                else{
                    this.lbReturnMsg.Text = "网络连接失败！";
                }
        }
    }
}
