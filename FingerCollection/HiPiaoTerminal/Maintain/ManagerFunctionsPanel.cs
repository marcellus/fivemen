using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace HiPiaoTerminal.Maintain
{
    public partial class ManagerFunctionsPanel : HiPiaoTerminal.UserControlEx.MaintainFirstPanel
    {
        public ManagerFunctionsPanel()
        {
            InitializeComponent();
        }

        private void btnAutoCloseComputer_Click(object sender, EventArgs e)
        {
            GlobalTools.GoPanel(new ManagerAutoClosePanel());
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            GlobalTools.GoPanel(new ManagerSystemConfigPanel());
        }

        private void btnModifyManagePwd_Click(object sender, EventArgs e)
        {
            GlobalTools.GoPanel(new ManagerModifyPwdPanel());
        }

        private void btnReturnDesktop_Click(object sender, EventArgs e)
        {
            if (GlobalTools.Confirm("确定要退出并返回桌面吗？"))
            {
                Application.Exit();
            }
        }

        private void btnCloseComputer_Click(object sender, EventArgs e)
        {
            if (GlobalTools.Confirm("确定要关机吗？"))
            {
                //FT.Commons.Win32.SystemDefine.c
                FT.Commons.Tools.WindowExHelper.CloseComputer();
            }
        }

        private void btnMoreSetting_Click(object sender, EventArgs e)
        {
            GlobalTools.GoPanel(new ManagerMoreSettingPanel());
        }

        
    }
}
