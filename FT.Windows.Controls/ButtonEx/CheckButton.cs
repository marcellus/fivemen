using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Controls.Properties;

namespace FT.Windows.Controls.ButtonEx
{
    public class CheckButton:Button
    {
        public CheckButton()
        {
            this.Text = string.Empty;
            this.BackgroundImage = Resources.Check_Off;
            this.Click += new EventHandler(CheckButton_Click);
            this.Size = new System.Drawing.Size(38, 38);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private bool check = false;
        
        public bool Checked
        {
            get
            {
                return this.check;
            }
            set
            {
                this.check = value;
                if (value)
                {
                    this.BackgroundImage = Resources.Check_On;
                }
                else
                {
                    this.BackgroundImage = Resources.Check_Off;
                }
            }
        }

        void CheckButton_Click(object sender, EventArgs e)
        {
            if (!this.check)
            {
                this.check = true;
                this.BackgroundImage = Resources.Check_On;
            }
            else
            {
                this.check = false;
                this.BackgroundImage = Resources.Check_Off;
            }
        }


    }
}
