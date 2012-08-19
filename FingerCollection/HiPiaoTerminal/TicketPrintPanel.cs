using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.UserControlEx;
using HiPiaoTerminal.PrinterTicket;

namespace HiPiaoTerminal
{
    public partial class TicketPrintPanel : UserControl
    {
        public TicketPrintPanel()
        {
            InitializeComponent();
        }

        private void TicketPrintPanel_Load(object sender, EventArgs e)
        {
            GlobalTools.RegistUpdateUnOperationTime(null);
            this.txtMobile.Focus();
        }

        private void picReturn_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        private void picReturnHome_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMain();
        }

        //private bool allowPrint = false;

        private void txtMobile_onSubTextChanged()
        {
            string mobile = this.txtMobile.Text.Trim();
            string validCode = this.txtValidCode.Text.Trim();
           /* if (mobile.Length == 11 && validCode.Length == 0)
            {
                this.txtValidCode.Focus();
                return;
            }*/
            if (mobile.Length == 11 && validCode.Length > 0)
            {
                this.btnPrint.IsActived = true;
            }
            else
            {
                this.btnPrint.IsActived = false;
            }
            //string validCode=
        }

        private UserInputPanel GetActiveInput()
        {
            if (this.txtMobile.Focused)
            {
                return this.txtMobile;
            }
            else if(txtValidCode.Focused)
            {
                return this.txtValidCode;

            }
            return null;
        }

        private void numButton1_Click(object sender, EventArgs e)
        {
            UserInputPanel txt = this.GetActiveInput();
            if (txt != null)
            {
                Label lb=sender as Label;
                txt.Text += lb.Text;
                if (txt == this.txtMobile && txt.Text.Length >= 11)
                {
                    //this.txtMobile.Focused = false;
                    this.txtValidCode.Focus();
                    this.txtMobile.UnFocus();
                }
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserInputPanel txt = this.GetActiveInput();
            if (txt != null)
            {
                if(txt.Text.Length>0)
                txt.Text = txt.Text.Substring(0,txt.Text.Length - 1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UserInputPanel txt = this.GetActiveInput();
            if (txt != null)
            {

                txt.Text = string.Empty;
            }
        }

        private void txtValidCode_onSubTextChanged()
        {
            string mobile = this.txtMobile.Text.Trim();
            string validCode = this.txtValidCode.Text.Trim();
            if (mobile.Length == 11 && validCode.Length > 0)
            {
                this.btnPrint.IsActived = true;
            }
            else
            {
                this.btnPrint.IsActived = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(this.btnPrint.IsActived)
                GlobalTools.Pop(new WaitValidPanel(this.txtMobile.Text,this.txtValidCode.Text));
        }
    }
}
