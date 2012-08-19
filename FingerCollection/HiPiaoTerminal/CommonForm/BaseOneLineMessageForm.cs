using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace HiPiaoTerminal.CommonForm
{
    public partial class BaseOneLineMessageForm : Form
    {
        public BaseOneLineMessageForm()
        {
            InitializeComponent();
        }

        private void BaseOneLineMessageForm_Paint(object sender, PaintEventArgs e)
        {
            //WinFormHelper.PaintRound(sender);
            WinFormHelper.PainYellowBorder(sender, e);
           
             
        }
    }
}
