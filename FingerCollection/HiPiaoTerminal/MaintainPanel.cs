using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace HiPiaoTerminal
{
    public partial class MaintainPanel : UserControl
    {
        public MaintainPanel()
        {
            InitializeComponent();
        }

       

        private void MaintainPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void btnApplicationExit_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Confirm("确定要退出并返回桌面吗？"))
            {
                Application.Exit();
            }
        }

        private void btnCloseComputer_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Confirm("确定要关机吗？"))
            {
                //FT.Commons.Win32.SystemDefine.c
                FT.Commons.Tools.WindowExHelper.CloseComputer();
            }
        }

        private void btnReturnMain_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void btnAutoCloseComputer_Click(object sender, EventArgs e)
        {
            GlobalTools.GoPanel(new Maintain.AutoCloseComputerSettingPanel());
        }
    }
}
