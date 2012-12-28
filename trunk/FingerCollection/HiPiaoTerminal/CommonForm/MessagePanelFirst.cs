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
    public partial class MessagePanelFirst : HiPiaoTerminal.UserControlEx.FirstNotifyUserPanel
    {
         public MessagePanelFirst(string hint)
        {
            InitializeComponent();
            this.lbMsg1.Text = hint;
            this.lbMsg1.Location = new Point(this.lbMsg1.Location.X, this.lbMsg1.Location.Y + 30);
            this.lbMsg2.Visible = false;
            this.lbMsg2.Text = string.Empty;
            WinFormHelper.CenterHor(this.picSure);
        }

         public MessagePanelFirst(string hint,int width,int height)
         {
             InitializeComponent();
             this.Width = width;
             this.Height = height;
             this.lbMsg1.Text = hint;
             this.lbMsg1.Location = new Point(this.lbMsg1.Location.X, this.lbMsg1.Location.Y + 30);
             this.lbMsg2.Visible = false;
             this.lbMsg2.Text = string.Empty;
             WinFormHelper.CenterHor(this.picSure);
         }


        public MessagePanelFirst(string hint,string hint2)
        {
            InitializeComponent();
            this.lbMsg1.Text = hint;
            this.lbMsg2.Text = hint2;
        }

        private void picSure_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void lbMsg2_Click(object sender, EventArgs e)
        {

        }

        private void MessagePanelFirst_Load(object sender, EventArgs e)
        {
            Control frm = this.Parent;
            if (frm != null)
            {
                frm.Size = new Size(this.Width,this.Height);
            }
        }
    }
}
