using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class NumberInputControl : UserControl
    {
        public NumberInputControl()
        {
            InitializeComponent();
        }

        private int minNum = 0;

        public int MinNum
        {
            get { return minNum; }
            set { minNum = value; }
        }
        private int maxNum = 100;

        public int MaxNum
        {
            get { return maxNum; }
            set { maxNum = value; }
        }

        private int minNumPadLen = 1;

        public int MinNumPadLen
        {
            get { return minNumPadLen; }
            set { minNumPadLen = value; }
        }

        [DefaultValue(0)]
        public  int Number
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.txtNum.Text.Trim().TrimStart('0'));
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                try
                {
                    this.txtNum.Text = value.ToString().PadLeft(this.MinNumPadLen, '0');
                }
                catch
                {
                    this.txtNum.Text = "0".ToString().PadLeft(this.MinNumPadLen, '0');
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(this.txtNum.Text.Trim());
                i++;
                if (i > maxNum)
                {
                }
                else
                {
                    this.txtNum.Text = i.ToString().PadLeft(this.MinNumPadLen, '0');
                }
            }
            catch
            {
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(this.txtNum.Text.Trim());
                i--;
                if (i < minNum)
                {
                }
                else
                {
                    this.txtNum.Text = i.ToString().PadLeft(this.MinNumPadLen, '0');
                }
            }
            catch
            {
            }
        }

        

    }
}
