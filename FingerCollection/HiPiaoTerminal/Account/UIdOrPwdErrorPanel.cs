using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.UserControlEx;

namespace HiPiaoTerminal.Account
{
    public partial class UIdOrPwdErrorPanel : FirstNotifyUserPanel
    {
        public UIdOrPwdErrorPanel()
        {
            InitializeComponent();
        }


        private void UIdOrPwdErrorForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            GlobalTools.ReturnMain();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            GlobalTools.GoLoginPanel();
        }
    }
}
