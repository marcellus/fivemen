using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class VitualNumKeyboardForm : Form
    {
        public VitualNumKeyboardForm()
        {
            InitializeComponent();
        }

        public TextBox InputTextBox
        {
            get
            {
                return this.vitualNumKeyBoardPanel1.InputTextBox;
            }
            set
            {
                this.vitualNumKeyBoardPanel1.InputTextBox = value;
            }
        }
    }
}
