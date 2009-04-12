using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Device.IDCard;

namespace FT.Windows.Forms
{
    public partial class PersonDetail : UserControl
    {
        public PersonDetail()
        {
            InitializeComponent();
            this.cbSex.SelectedIndex = 0;
            this.cbState.SelectedIndex = 0;
        }

        public void SetIDCard(IDCard card)
        {
            this.txtName.Text = card.Name;
            this.txtIdCard.Text = card.IDC;
            this.txtAddress.Text = card.ADDRESS;
            this.dateBirthday.Value = card.BIRTH;
            this.cbSex.Text = IDCardHelper.GetSexName(card.IDC);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ϊ�ؼ�����text������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="text"></param>
        protected void SetError(object sender, string text)
        {
            this.errorProvider1.SetError((Control)sender, text);
        }
        /// <summary>
        /// ���ĳ�ؼ��ϵĴ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        protected void ClearError(object sender)
        {
            SetError(sender, string.Empty);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                this.SetError(sender, "��������Ϊ�գ�");
                e.Cancel = true;
            }
            else
            {
                this.SetError(sender, "");
                e.Cancel = false;
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatorHelper.ValidatePhone(this.txtPhone.Text, true))
            {
                this.SetError(sender, "�绰�����ʽ����,��ʽ��12345678��010-12345678��");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtIdCard_Validating(object sender, CancelEventArgs e)
        {
            string idcard = this.txtIdCard.Text.Trim();
            if (idcard.Length > 0)
            {
                string str = IDCardHelper.Validate(idcard);
                if (str != string.Empty)
                {
                    this.SetError(sender, str);
                    e.Cancel = true;
                }
                else
                {
                    this.ClearError(sender);
                    e.Cancel = false;
                }

            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtMobile_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatorHelper.ValidateMobile(this.txtMobile.Text, true))
            {
                this.SetError(sender, "�ֻ������ʽ����");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtIdCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string id = this.txtIdCard.Text.Trim();
                if(id.Length!=0)
                {
                    try
                    {
                        this.dateBirthday.Value=IDCardHelper.GetBirthday(id);
                        this.cbSex.Text=IDCardHelper.GetSexName(id);
                    }
                    catch (Exception ex)
                    {
                        //this.SetError(sender, "�ֻ������ʽ����");
                        //MessageBoxHelper.Show("����:"+ex.Message);
                    }
                }
            }
        }
    }
}
