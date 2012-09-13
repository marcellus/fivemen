using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.Controls.PanelEx
{
    public partial class VitualKeyBoardPanel2 : UserControl
    {
        public VitualKeyBoardPanel2()
        {
            InitializeComponent();
            this.TabStop = false;
            //this.Enabled = false;
            Button btn;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                btn = this.Controls[i] as Button;
                if (btn != null)
                {
                    btn.Enabled = true;
                    btn.TabStop = false;
                }
                if (btn != null && !btn.Name.StartsWith("btnFn"))
                {

                    btn.Click += new EventHandler(btn_Click);
                }
            }
        }

        private void VitualKeyBoardPanel2_Load(object sender, EventArgs e)
        {
            
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                this.SendKey(btn.Tag.ToString().ToLower());
            }
        }

        private TextBox inputTextBox;

        public TextBox InputTextBox
        {
            get { return inputTextBox; }
            set { inputTextBox = value; }
        }

        private void SendKey(string key)
        {
            if (this.inputTextBox != null && this.inputTextBox.Text.Length < this.inputTextBox.MaxLength)
            {
                //this.inputTextBox.Focus();
                this.inputTextBox.Text += key;
                this.inputTextBox.SelectionStart = this.inputTextBox.Text.Length;
            }
        }

        private void btnFnBackspace_Click(object sender, EventArgs e)
        {
            if (this.inputTextBox != null)
            {
                string str = this.inputTextBox.Text.ToString();
                if (str.Length >= 1)
                {
                    this.inputTextBox.Text = this.inputTextBox.Text.Substring(0, this.inputTextBox.Text.Length - 1);
                }
            }
        }

        private void btnFnSure_Click(object sender, EventArgs e)
        {
            if (this.showWithForm)
            {
                this.FindForm().Hide();
            }
            else
            {
                this.Hide();
            }
        }

        private bool showWithForm = false;

        /// <summary>
        /// 是否以窗体方式出现
        /// </summary>
        public bool ShowWithForm
        {
            get { return showWithForm; }
            set { showWithForm = value; }
        }


        private void btnFnClear_Click(object sender, EventArgs e)
        {
            if (this.inputTextBox != null)
            {
                this.inputTextBox.Text=string.Empty;
               
            }
        }

        private void btnFnSpace_Click(object sender, EventArgs e)
        {
            if (this.inputTextBox != null && this.inputTextBox.Text.Length < this.inputTextBox.MaxLength)
            {
                this.inputTextBox.Text +=" ";

            }
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            //MessageBoxHelper.Show("单击了按钮一");
        }

        private void VitualKeyBoardPanel2_Paint(object sender, PaintEventArgs e)
        {
#if DEBUG
            Console.WriteLine("键盘重绘");
#endif
          //  Color color = Color.FromArgb(241,241,241);
           // WinFormHelper.PaintRound(sender, color, 1, e);
        }
    }
}
