using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class LabelButtonWithActive : Label
    {
        public LabelButtonWithActive()
        {
            this.Image = Properties.Resources.Account_btn_Not_Active;
            this.AutoSize = false;
            this.Width = 268;
            this.Height = 95;
            this.Font = new Font("方正兰亭黑简体", 36f);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ForeColor = Color.White;
            InitializeComponent();
           
        }

        private bool isActived=false;

        public bool IsActived
        {
            get
            {
                return isActived;
            }
            set
            {
                isActived = value;
                if (value)
                {
                    this.Image = Properties.Resources.Account_btn_Active;
                }
                else
                {
                    this.Image = Properties.Resources.Account_btn_Not_Active;
                }
            }
        }
    }
}

