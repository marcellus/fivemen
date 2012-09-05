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
    public partial class MessageForm : Form
    {
        public MessageForm(string hint)
        {
            InitializeComponent();
            this.lbMsg1.Text = hint;
            this.lbMsg1.Location = new Point(this.lbMsg1.Location.X, this.lbMsg1.Location.Y + 30);
            this.lbMsg2.Visible = false;
            this.lbMsg2.Text = string.Empty;
            WinFormHelper.CenterHor(this.picSure);
        }

        public MessageForm(string hint,string hint2)
        {
            InitializeComponent();
            this.lbMsg1.Text = hint;
            this.lbMsg2.Text = hint2;
        }

        private bool returnHome;

        public bool ReturnHome
        {
            get { return returnHome; }
            set { returnHome = value; }
        }


        private void MessageForm_Paint(object sender, PaintEventArgs e)
        {
            WinFormHelper.PaintRound(sender);
           // WinFormHelper.PainYellowBorder(sender, e);
            
            ControlPaint.DrawBorder(e.Graphics,
                                this.ClientRectangle,
                                Color.LightSeaGreen,//7f9db9
                                1,
                                ButtonBorderStyle.Solid,
                                Color.LightSeaGreen,
                                1,
                                ButtonBorderStyle.Solid,
                                Color.LightSeaGreen,
                                1,
                                ButtonBorderStyle.Solid,
                                Color.LightSeaGreen,
                                1,
                                ButtonBorderStyle.Solid);
            /* * */

        }

        private void picSure_Click(object sender, EventArgs e)
        {
            if (returnHome)
            {
                GlobalTools.ReturnMain();
            }
            else
            {

            }
            this.Close();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
