using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal.Maintain
{
    public partial class ManagerAutoClosePanel : HiPiaoTerminal.UserControlEx.MaintainParentPanel
    {
        public ManagerAutoClosePanel()
        {
            InitializeComponent();
        }

        private void btnCancelSave_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMaintain();
        }

        private void btnKeepSave_Click(object sender, EventArgs e)
        {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            config.AutoCloseComputer = this.checkClose.Checked;
            config.AutoOpenComputer=this.checkOpen.Checked ;
            config.AutoCloseComputerHour=this.txtCloseHour.Number ;
            config.AutoCloseComputerMinitues=this.txtCloseMinute.Number ;
            config.AutoOpenComputerHour=this.txtOpenHour.Number ;
            config.AutoOpenComputerMinitues=this.txtOpenMinute.Number;
            FT.Commons.Cache.StaticCacheManager.SaveConfig<SystemConfig>(config);
            this.lbReturnMsg.Text = "修改成功！";
        }

        private void ManagerAutoClosePanel_Load(object sender, EventArgs e)
        {
            try
            {
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                this.checkClose.Checked = config.AutoCloseComputer;
                this.checkOpen.Checked = config.AutoOpenComputer;
                this.txtCloseHour.Number = config.AutoCloseComputerHour;
                this.txtCloseMinute.Number = config.AutoCloseComputerMinitues;
                this.txtOpenHour.Number = config.AutoOpenComputerHour;
                this.txtOpenMinute.Number = config.AutoOpenComputerMinitues;
            }
            catch
            {

            }
        }
    }
}
