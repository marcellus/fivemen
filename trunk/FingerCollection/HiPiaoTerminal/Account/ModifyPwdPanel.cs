using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;
using FT.Commons.Tools;

namespace HiPiaoTerminal.Account
{
    public partial class ModifyPwdPanel : UserControl
    {
        public ModifyPwdPanel()
        {
            InitializeComponent();
        }
        private bool allowUpdate = false;
       
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (allowUpdate)
            {
                string oldPwd = this.txtOldPwd.Text.Trim();
                string pwd = this.txtNewPwd.Text.Trim();
                string repeatPwd = this.txtRepeatPwd.Text.Trim();

                bool result = true;

                if (GlobalTools.GetLoginUser().Pwd != oldPwd)
                {
                    this.lbOldPwdHint.Text = "密码输入有误！";
                    this.txtOldPwd.Text = string.Empty;
                    this.txtOldPwd.Focus();
                    this.picOldPwdHint.Image = Properties.Resources.Error;
                    result = false; ;
                }
                else
                {
                    this.lbOldPwdHint.Text = string.Empty;
                    this.picOldPwdHint.Image = Properties.Resources.Right;
                }

                if (!ValidatorHelper.ValidatePostCode(pwd, false))
                {
                    this.lbNewPwdHint.Text = "密码只允许6位数字";
                    this.picNewPwdHint.Visible = true;
                    this.picNewPwdHint.Image = Properties.Resources.Error;
                    this.txtNewPwd.Focus();
                    result = false;

                }
                else
                {
                    this.lbNewPwdHint.Text = string.Empty;
                    this.picNewPwdHint.Image = Properties.Resources.Right;
                }

                if (pwd != repeatPwd)
                {
                    this.lbRepeatPwdHint.Text = "两次输入的密码不一致，请重新输入";
                    this.picRepeatPwdHint.Visible = true;
                    this.picRepeatPwdHint.Image = Properties.Resources.Error;
                    this.txtNewPwd.Text = this.txtRepeatPwd.Text = string.Empty;
                    this.txtNewPwd.Focus();
                    result = false;

                }
                else
                {
                    this.lbRepeatPwdHint.Text = string.Empty;
                    this.picRepeatPwdHint.Image = Properties.Resources.Right;
                }

               
                if (result)
                {
                    if (HiPiaoOperatorFactory.GetHiPiaoOperator().UpdatePwd(GlobalTools.GetLoginUser(), pwd))
                    {
                        
                        GlobalTools.Pop("修改密码成功！");
                    }
                    else
                    {
                        GlobalTools.PopNetError();
                    }
                }
            }
        }

        private void txtOldPwd_onSubTextChanged()
        {
            string oldPwd = this.txtOldPwd.Text.Trim();
            string pwd = this.txtNewPwd.Text.Trim();
            string repeatPwd = this.txtRepeatPwd.Text.Trim();
            if (oldPwd.Length > 0 && pwd.Length > 0 && repeatPwd.Length > 0)
            {
                allowUpdate = true;
                this.btnSure.Image = Properties.Resources.Account_btn_Active;
            }
            else
            {
                allowUpdate = false;
                this.btnSure.Image = Properties.Resources.Account_btn_Not_Active;
            }
        }
    }
}
