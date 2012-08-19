using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class MaintainFirstPanel : SameBackgroudParentPanel
    {
        public MaintainFirstPanel()
        {
            InitializeComponent();
        }

        private void btnReturnFirstUserHome_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        
    }
}
