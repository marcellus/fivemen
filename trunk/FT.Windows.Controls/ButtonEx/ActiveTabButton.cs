using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Controls.ButtonEx
{
    public partial class ActiveTabButton : UserControl
    {
        public ActiveTabButton()
        {
            InitializeComponent();
            this.lbHintText.Font = btnFont;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            this.IsActive = false;
            //this.lbHintText.Click += new EventHandler(lbHintText_Click);
            this.Width = 222;
            this.Height = 70;

           
        }

       

        
        public string TabText
        {
            get
            {
                return this.lbHintText.Text;
            }
            set
            {
                this.lbHintText.Text = value;
            }
        }

        private static Font btnFont = new Font("方正兰亭黑简体", 24);
        private static Color notActiveColor = Color.FromArgb(255, 255, 255);
        private static Color activeColor = Color.FromArgb(89, 87, 87);

       // private static Color notActiveColor = Color.Red;
       // private static Color activeColor = Color.Red;

        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;

                if (value)
                {
                    this.BackgroundImage = Properties.Resources.Account_TabActive;
                    this.lbHintText.ForeColor = activeColor;
                }
                else
                {
                    this.BackgroundImage = Properties.Resources.Account_Tab_NotActive;
                    this.lbHintText.ForeColor = notActiveColor;
                }

            }
        }

        

        private void lbHintText_Click(object sender, EventArgs e)
        {
            Console.WriteLine("用户点击了"+this.TabText);
            this.OnClick(e);
        }


        
    }
}
