using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.Controls.ButtonEx
{
    public partial class ActiveWithArrowButton : UserControl
    {

       
        public ActiveWithArrowButton()
        {
            InitializeComponent();
            this.Width = 218;
            this.Height = 65;

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.lbHintText.Font = btnFont;
           
            this.IsActive = false;
            this.Click += new EventHandler(ActiveWithArrowButton_Click);
        }

        private static Font btnFont = new Font("微软雅黑", 17);
        private static Color notActiveColor = Color.FromArgb(77, 76, 76);
        private static Color activeColor = Color.FromArgb(255, 255, 255);

        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;

                if (value)
                {
                    this.BackgroundImage = Properties.Resources.btn_Back_Active;
                    this.lbHintText.ForeColor = activeColor;
                }
                else
                {
                    this.BackgroundImage = Properties.Resources.btn_Back_None_Active;
                    this.lbHintText.ForeColor = notActiveColor;
                }

            }
        }

        public  string ButtonText
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

        void ActiveWithArrowButton_Click(object sender, EventArgs e)
        {
            
        }

        private void lbHintText_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
