using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Domain;
using FT.Commons.Tools;
using FT.Commons.Security;
using FT.Commons.Cache;

namespace FT.Windows.Forms
{
    public partial class SimpleRegister : DevExpress.XtraEditors.XtraForm
    {
        
        ConfigLoader<ProgramRegConfig> loader = null;
        public SimpleRegister()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
            loader = new ConfigLoader<ProgramRegConfig>(this);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ISecurity md5 = new MD5Security();
            ISecurity sec= FT.Commons.Security.SecurityFactory.GetSecurity();
            if (this.txtCompany.Text.Trim().Length == 0)
            {
                MessageBoxHelper.Show("����������Ȩ�û���");
                return;
            }
            if (this.txtKeyCode.Text.Trim().Length > 0)
            {
                if (this.txtKeyCode.Text.Trim() != md5.Encrypt(sec.Encrypt(this.txtMachineCode.Text + this.txtCompany.Text.Trim() + this.txtMachineCode.Text)))
                {
                    this.txtKeyCode.Focus();
                    MessageBoxHelper.Show("ע����������������룡");
                    return;
                }
            }
            else
            {
                MessageBoxHelper.Show("û��ע���룬��ʹ�����ð棡");
                this.DialogResult = DialogResult.OK;
            }
            ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
            config.RegDate = System.DateTime.Now;
            
            loader.SaveConfig();
            MessageBoxHelper.Show("����ɹ���");
            this.DialogResult = DialogResult.OK;
        }

        private void SimpleRegister_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {

            }
            this.txtMachineCode.Text = FT.Commons.Tools.HardwareManager.GetMachineCode();
        }

        private void SimpleRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.Cancel && this.DialogResult != DialogResult.OK)
                e.Cancel = true;
        }

       
    }
}