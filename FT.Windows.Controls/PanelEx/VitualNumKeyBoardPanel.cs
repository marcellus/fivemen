using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Controls.PanelEx
{
    public partial class VitualNumKeyBoardPanel : UserControl
    {
        public VitualNumKeyBoardPanel()
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

        private TextBox inputTextBox;

        public TextBox InputTextBox
        {
            get { return inputTextBox; }
            set { inputTextBox = value; }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                this.SendKey(btn.Text.ToLower());
            }
        }

        private void btnFnBackspace_Click(object sender, EventArgs e)
        {
            if (this.inputTextBox != null)
            {
                string str = this.inputTextBox.Text;
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
                this.inputTextBox.Text = string.Empty;

            }
        }

        private void SendKey(string key)
        {
            if (this.inputTextBox != null&&this.inputTextBox.Text.Length<this.inputTextBox.MaxLength)
            {
                //this.inputTextBox.Focus();
                this.inputTextBox.Text += key;
                this.inputTextBox.SelectionStart = this.inputTextBox.Text.Length;
            }
        }

    }
}
