using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class VitualKeyboardForm : Form
    {
        public VitualKeyboardForm()
        {
            InitializeComponent();
        }

        private void vitualKeyBoardPanel21_Load(object sender, EventArgs e)
        {
            this.vitualKeyBoardPanel21.ShowWithForm = true;
        }


        public TextBox InputTextBox
        {
            get
            {
                return this.vitualKeyBoardPanel21.InputTextBox;
            }
            set
            {
                this.vitualKeyBoardPanel21.InputTextBox=value;
            }
        }
    }
}
