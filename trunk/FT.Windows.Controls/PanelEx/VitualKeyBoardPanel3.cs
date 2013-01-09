using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Controls.PanelEx
{
    public partial class VitualKeyBoardPanel3 : UserControl
    {
        public VitualKeyBoardPanel3()
        {
            InitializeComponent();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void VitualKeyBoardPanel3_Load(object sender, EventArgs e)
        {
            Label btn;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                btn = this.Controls[i] as Label;
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

        private void SendKey(string key)
        {
            if (this.inputTextBox != null && this.inputTextBox.Text.Length < this.inputTextBox.MaxLength)
            {
                //this.inputTextBox.Focus();
                this.inputTextBox.Text += key;
                this.inputTextBox.SelectionStart = this.inputTextBox.Text.Length;
            }
        }


        void btn_Click(object sender, EventArgs e)
        {
            Label btn = sender as Label;
            if (btn != null)
            {
                this.SendKey(btn.Tag.ToString().ToLower());
            }
        }

        private void btnFmSpace_Click(object sender, EventArgs e)
        {
            if (this.inputTextBox != null && this.inputTextBox.Text.Length < this.inputTextBox.MaxLength)
            {
                this.inputTextBox.Text += " ";

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

        private void btnFnSure_Click(object sender, EventArgs e)
        {
            if (this.showWithForm)
            {
                this.FindForm().Hide();
                this.inputTextBox.Focus();
            }
            else
            {
                this.Hide();
                this.inputTextBox.Focus();
            }
        }

        private void btnFnClear_Click(object sender, EventArgs e)
        {
            if (this.inputTextBox != null)
            {
                this.inputTextBox.Text = string.Empty;

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
    }
}
