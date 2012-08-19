using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class NumButton : Label
    {
        public NumButton()
        {
           
           
           // this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Width = 140;
            this.Height = 85;
            this.AutoSize = false;
            this.Image = Properties.Resources.NumKey_Not_Active;
            this.Font = new Font("方正兰亭黑简体", 36f);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = Color.White;
            this.MouseEnter += new EventHandler(NumButton_MouseEnter);
            this.MouseLeave += new EventHandler(NumButton_MouseLeave);
            InitializeComponent();

        }

        void NumButton_MouseEnter(object sender, EventArgs e)
        {
            this.IsActive = true;
        }

        void NumButton_MouseLeave(object sender, EventArgs e)
        {
            this.IsActive = false;
        }

        private bool isActive = false;

        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;

                if (value)
                {
                    this.Image = Properties.Resources.NumKey_Active;
                }
                else
                {
                    this.Image = Properties.Resources.NumKey_Not_Active;
                }
            }
        }
    }
}
