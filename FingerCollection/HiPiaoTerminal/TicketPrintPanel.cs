using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.UserControlEx;
using HiPiaoTerminal.PrinterTicket;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal
{
    public partial class TicketPrintPanel : UserControl
    {
        public TicketPrintPanel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            if (config.IsDingXin)
            {
                this.picReturnHome.Image = Properties.Resources.DingXin_GetTicket_Back1;
                this.pictureHint.Image = Properties.Resources.DingXin_GetTicket_Back2;
                this.lbMobileHint.Text = "序列号";
                this.txtMobile.Hint = "购票序列号";
            }
        }

        private void TicketPrintPanel_Load(object sender, EventArgs e)
        {
            GlobalTools.RegistUpdateUnOperationTime(null);
            this.txtMobile.Focus();
           // this.txtValidCode.UnFocus();
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
            if (mobile.Length > 0 || validCode.Length > 0)
            {
                this.btnClearAll.Visible = true;
            }
            else
            {
                this.btnClearAll.Visible = false;
            }
            if (mobile.Length == 11 && validCode.Length == 0)
            {
                this.txtValidCode.Focus();
                return;
            }
            if (mobile.Length == 11 && validCode.Length == 6)
            {
                //this.btnPrint2.IsActived = true;
                this.allowPrint = true;
                this.btnPrint.Image = Properties.Resources.Print_Ticket_Num_GetTicket_Active;
            }
            else
            {
                //this.btnPrint2.IsActived = false;
                this.allowPrint = false;
                this.btnPrint.Image = Properties.Resources.Print_Ticket_Num_GetTicket_Not_Active;
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
                if (txt.Text.Length == txt.MaxInputLength)
                {
                    return;
                }
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

        private bool allowPrint;
        private void txtValidCode_onSubTextChanged()
        {
            string mobile = this.txtMobile.Text.Trim();
            string validCode = this.txtValidCode.Text.Trim();
            if (mobile.Length > 0 || validCode.Length > 0)
            {
                this.btnClearAll.Visible = true;
            }
            else
            {
                this.btnClearAll.Visible = false;
            }
            if (mobile.Length == 11 && validCode.Length ==6)
            {
                //this.btnPrint2.IsActived = true;
                this.allowPrint = true;
                this.btnPrint.Image = Properties.Resources.Print_Ticket_Num_GetTicket_Active;
            }
            else
            {
                //this.btnPrint2.IsActived = false;
                this.allowPrint = false;
                this.btnPrint.Image = Properties.Resources.Print_Ticket_Num_GetTicket_Not_Active;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //Cursor.Current = Cursors.Default;
                // Cursor.Show();
                this.btnPrint_Click(null, null);
                //this.Close();
                //return false;
            }
            return false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if(this.btnPrint2.IsActived)
                
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            if (allowPrint)
            {
                GlobalTools.Pop(new WaitValidPanel(this.txtMobile.Text, this.txtValidCode.Text));

                
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            this.txtMobile.Text=this.txtValidCode.Text = string.Empty;
            this.txtMobile.Focus();
            this.allowPrint = false;
            this.btnPrint.Image = Properties.Resources.Print_Ticket_Num_GetTicket_Not_Active;
        }
    }
}
