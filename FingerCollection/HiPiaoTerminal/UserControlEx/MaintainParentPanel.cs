using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class MaintainParentPanel : HiPiaoTerminal.UserControlEx.MaintainFirstPanel
    {
        public MaintainParentPanel()
        {
            InitializeComponent();
        }

        private void btnReturnMaintain_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMaintain();
        }
    }
}
