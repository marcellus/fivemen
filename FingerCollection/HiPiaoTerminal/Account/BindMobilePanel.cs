using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;

namespace HiPiaoTerminal.Account
{
    public partial class BindMobilePanel : HiPiaoTerminal.UserControlEx.SecondNotifyUserPanel
    {
        public BindMobilePanel()
        {
            InitializeComponent();
            try
            {
                if (GlobalTools.GetLoginUser() != null)
                {
                    this.lbUserName.Text = "用户名：" + GlobalTools.GetLoginUser().Name;
                    this.pictureBox1.BackgroundImage = Properties.Resources.BindMobile_SendValidCode_NotActive;
                }
                
            }
            catch(Exception ex)
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form frm = this.FindForm();
            if (frm != null)
            {
                frm.FormClosing += new FormClosingEventHandler(frm_FormClosing);
                frm.Close();

            }
            // GlobalTools.ReturnMain();
        }

        void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // GlobalTools.ReturnMain();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            string mobile = this.txtMobile.Text.Trim();
            if (!FT.Commons.Tools.ValidatorHelper.ValidateMobile(mobile, false))
            {
                GlobalTools.Pop("手机号码输入有误！");
                return;
            }
            if (RandomSmsHelper.IsRight(this.txtCode.Text))
            {
                if (HiPiaoCache.BindMobile(GlobalTools.GetLoginUser(), this.txtMobile.Text))
                {
                    GlobalTools.GetLoginUser().IsBindMobile = true;
                    GlobalTools.GetLoginUser().Mobile = this.txtMobile.Text.Trim();
                    this.lbHint.Text = "绑定手机成功！";
                    //GlobalTools.Pop("绑定手机成功！");
                    GlobalTools.ChangePanel(this.FindForm(),new BindMobileSuccessPanel());
                    //this.FindForm().Close();
                   
                }
                else
                {
                    this.lbHint.Text = "绑定手机失败！！";
                    //GlobalTools.Pop("绑定手机失败！");
                }
            }
            else
            {
                this.lbHint.Text = "验证码输入错误！";
                //GlobalTools.Pop("验证码输入错误！");
            }
        }

        private DateTime pre;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          //  bool allowSend = true;
            /*
            if (pre != null)
            {
                double times = System.DateTime.Now.Subtract(pre).TotalSeconds;
                if (times > 30)
                {
                    allowSend = true;
                }
                else
                {
                    allowSend = false;
                }

            }
             * */
            if (allowSend&&this.txtMobile.Text.Length==11)
            {
                this.lbHint.Text = string.Empty;
                // string content = "您的" + user.Name + "账户于" + System.DateTime.Now.ToString("M月d日") + "以" + user.Mobile + "成功消费" + fee + "元，账户余额" + user.Balance + "元。如有疑问请致电400-601-5566【哈票网】";
                string content = string.Format("本次验证码：{0},如有疑问请致电400-601-5566", RandomSmsHelper.GenerateNumberCode(6));
                bool result = HiPiaoCache.SmsMobileContent(this.txtMobile.Text.Trim(), content);
                this.timer1.Start();
                allowSend = false;
                this.pictureBox1.BackgroundImage = Properties.Resources.BindMobile_SendValidCode_NotActive;
               // this.lbHint = "验证码已发送，请查收！";
                //pre = System.DateTime.Now;
            }
          
        }
        private bool allowSend = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            allowSend = true;
            this.pictureBox1.BackgroundImage = Properties.Resources.BindMobile_SendValidCode;
           
        }

        private void txtMobile_onSubTextChanged()
        {
            if (allowSend)
            {
                if (this.txtMobile.Text.Length == 11&&FT.Commons.Tools.ValidatorHelper.ValidateMobile(this.txtMobile.Text.Trim(),false))
                {
                    //this.allowSend = true;
                    this.pictureBox1.BackgroundImage = Properties.Resources.BindMobile_SendValidCode;
                }
                else
                {
                    //  this.allowSend = false;
                    this.pictureBox1.BackgroundImage = Properties.Resources.BindMobile_SendValidCode_NotActive;
                }
            }
        }
    }
}
