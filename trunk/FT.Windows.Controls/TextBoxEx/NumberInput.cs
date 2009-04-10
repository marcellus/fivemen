using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FT.Windows.Controls.TextBoxEx
{
    public partial class NumberInput : TextBox
    {
        public NumberInput()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(OldCarInput_KeyPress);
            //this.TextChanged += new EventHandler(OldCarInput_TextChanged);
        }

        void OldCarInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar>=48&&e.KeyChar<=57)||e.KeyChar==46)
            {
                
            }
            else if (e.KeyChar == 8)
            {
            }
            else
            {
                e.Handled = true;
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        void OldCarInput_TextChanged(object sender, EventArgs e)
        {
            string str = this.Text.Trim().ToUpper();
            if (str.Length > 0)
            {
                string last = str.Substring(str.Length - 1);
                if (str.Length > 1 && Regex.Match(last, "[A-Z]").Success)
                {
                    this.Text = str.Substring(0, str.Length - 1) + " " + last;
                }
                else
                {
                    this.Text = str;
                }
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码

            // 调用基类 OnPaint
            base.OnPaint(pe);
        }
    }
}
