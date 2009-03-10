using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;
using FT.Commons.Tools;

namespace FT.Windows.Forms
{
    public partial class CustomPrinterSetting : Form
    {
        ConfigLoader<GlobalPrintSetting> loader = null;
        public CustomPrinterSetting()
        {
            InitializeComponent();
            this.cbPrintModel.SelectedIndex = 0;
            loader = new ConfigLoader<GlobalPrintSetting>(this);
        }

        private void CustomPrinterSetting_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {
                loader.SaveConfig();
                MessageBoxHelper.Show("保存成功！");
            }
        }

        private void txtTop_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "上边距必须是整数！",false);
        }

        protected void ValidateNumber(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateNumber(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        private void txtLeft_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "左边距必须是整数！", false);
        }

        private void txtBottom_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "下边距必须是整数！", false);
        }

        private void txtRight_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "右边距必须是整数！", false);
        }

    }
}