using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class LabelButtonWithActive2 :Label
    {
        public LabelButtonWithActive2()
        {
            this.Image = Properties.Resources.BuyTick_ConfirmPay_NotActive;
            this.AutoSize = false;
            this.Width = 241;
            this.Height = 92;
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
                    this.Image = Properties.Resources.BuyTick_ConfirmPay_Active;
                }
                else
                {
                    this.Image = Properties.Resources.BuyTick_ConfirmPay_NotActive;
                }
            }
        }
    }
}
