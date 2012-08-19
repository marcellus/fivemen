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
    public partial class AutoCloseComputerSettingPanel : HiPiaoTerminal.UserControlEx.MaintainParentPanel
    {
        public AutoCloseComputerSettingPanel()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            config.AutoCloseComputer = this.cbAllowAutoCloseComputer.Checked;
            config.AutoCloseComputerHour = this.txtHour.Number;
            config.AutoCloseComputerMinitues = this.txtMinutes.Number;
            FT.Commons.Cache.StaticCacheManager.SaveConfig<SystemConfig>(config);
            GlobalTools.ReturnMaintain();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMaintain();
        }

        private void AutoCloseComputerSettingPanel_Load(object sender, EventArgs e)
        {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            this.cbAllowAutoCloseComputer.Checked=config.AutoCloseComputer;
            this.txtHour.Number=config.AutoCloseComputerHour;
            this.txtMinutes.Number = config.AutoCloseComputerMinitues;
            string helpdoc = Application.StartupPath + "\\HelpDoc\\AutoCloseComputerSettingPanel.htm";
            this.webBrowser1.Navigate(helpdoc);
        }
    }
}
