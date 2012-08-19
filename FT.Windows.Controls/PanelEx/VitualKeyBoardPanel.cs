using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FT.Windows.Controls.PanelEx
{
    public partial class VitualKeyBoardPanel : UserControl
    {
        public VitualKeyBoardPanel()
        {
            InitializeComponent();
        }

        private TextBox inputTextBox;

        public TextBox InputTextBox
        {
            get { return inputTextBox; }
            set { inputTextBox = value; }
        }

        private void btnFnCap_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "大写")
            {
                btn.Text = "小写";
                this.ToUpper();
            }
            else
            {
                btn.Text = "大写";
                this.ToLower();
            }
        }

        private void ToUpper()
        {
            Button btn;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                btn = this.Controls[i] as Button;
                if (btn != null && btn.Name.StartsWith("btnChar"))
                {
                    btn.Text = btn.Text.ToUpper();
                }
            }
        }

        private void ToLower()
        {
            Button btn;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                btn = this.Controls[i] as Button;
                if (btn != null && btn.Name.StartsWith("btnChar"))
                {
                    btn.Text = btn.Text.ToLower();
                }
            }
        }

        public void ShowToTextBox(TextBox txt)
        {
            txt.Parent.Controls.Add(this);
            this.inputTextBox = txt;
            this.Location=new Point(txt.Location.X,txt.Location.Y+txt.Height);
            //this.to
            this.Show();
        }

        private void btnFnBackspace_Click(object sender, EventArgs e)
        {
            string str = this.inputTextBox.Text;
            if (str.Length >= 1)
            {
                this.inputTextBox.Text = this.inputTextBox.Text.Substring(0, this.inputTextBox.Text.Length - 1);
            }
            //this.SendKey("{BS}");
        }

        private void btnFnEnter_Click(object sender, EventArgs e)
        {
            //this.inputTextBox.Parent.Controls.Remove(this);
            this.Hide();
        }

        private void btnFnSpace_Click(object sender, EventArgs e)
        {
            this.SendKey(" ");
        }

        private string pref = string.Empty;

        private void SendKey(string key)
        {
            this.inputTextBox.Focus();
            this.inputTextBox.Text += key;
            this.inputTextBox.SelectionStart = this.inputTextBox.Text.Length ;
           // SendKeys.SendWait(pref + key);
            this.btnFnCtrl.BackColor = SystemColors.Control;
            this.btnFnAlt.BackColor = SystemColors.Control;
            this.pref = string.Empty;
        }

        private void btnFnCtrl_Click(object sender, EventArgs e)
        {
            this.pref += "^";
            this.btnFnCtrl.BackColor = System.Drawing.Color.Coral;
        }

        private void btnFnAlt_Click(object sender, EventArgs e)
        {
            this.pref += "%";
            this.btnFnAlt.BackColor = System.Drawing.Color.Coral;
        }

        private void btnFnClear_Click(object sender, EventArgs e)
        {
            if (this.inputTextBox != null)
            {
                this.inputTextBox.Text = string.Empty;
            }
        }

        private void VitualKeyBoardPanel_Load(object sender, EventArgs e)
        {
            Button btn;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                btn = this.Controls[i] as Button;
                if (btn != null && !btn.Name.StartsWith("btnFn"))
                {
                    btn.Click += new EventHandler(btn_Click);
                }
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                this.SendKey(btn.Text);
            }
        }

        private void btnCharL_Click(object sender, EventArgs e)
        {

        }
    }
}
