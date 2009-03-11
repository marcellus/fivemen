using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Controls.TextBoxEx
{
    public class DateTextBox : System.Windows.Forms.TextBox
    {
        private System.ComponentModel.Container components = null;
        private System.Text.StringBuilder str = new System.Text.StringBuilder("0000-00-00");

        public DateTextBox()
        {
           
            //InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(DateTextBox_KeyPress);
            this.Leave += new EventHandler(DateTextBox_Leave);
        }
        private void DateTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            int startPos = ((TextBox)sender).SelectionStart;
            if (Char.IsDigit(e.KeyChar))     //如果是数字  
            {
                if (startPos < 10)
                {
                    if (startPos == 0 && (e.KeyChar != '1' && e.KeyChar != '2'))
                    {
                        e.Handled = true;
                        return;
                    }
                    if ((startPos == 4 || startPos == 5) && (e.KeyChar != '0' && e.KeyChar != '1'))   //   月份的第一位不能为0、1以外的数字  
                    {
                        e.Handled = true;
                        return;
                    }
                    if (startPos == 6 && str[5] == '1' && e.KeyChar > '2')
                    {
                        e.Handled = true;
                        return;
                    }
                    if ((startPos == 7 || startPos == 8) && e.KeyChar > '3')
                    {
                        e.Handled = true;
                        return;
                    }
                    if (startPos == 9 && str[8] == '3' && e.KeyChar > '1')
                    {
                        e.Handled = true;
                        return;
                    }
                    if (startPos == 4 || startPos == 7)
                        startPos++;

                    str[startPos] = e.KeyChar;
                    startPos++;
                }
            }
            if (e.KeyChar == 8)
            {
                if (startPos == 5 || startPos == 8)
                {
                    str[startPos - 2] = '0';
                    startPos -= 2;
                    e.Handled = true;
                }
                else
                {
                    if (startPos > 0)
                    {
                        str[startPos - 1] = '0';
                        startPos--;
                    }
                }
            }
            ((TextBox)sender).Text = str.ToString();
            ((TextBox)sender).SelectionStart = startPos;
            e.Handled = true;
        }
        private void DateTextBox_Leave(object sender, EventArgs e)
        {
            string str = ((TextBox)sender).Text;
            if (str.Trim() == "" || str == "0000-00-00")
                return;
            try
            {
                Convert.ToDateTime(((TextBox)sender).Text);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("不正确的时间格式"); ((TextBox)sender).Select();
            }
        }
    }
}
