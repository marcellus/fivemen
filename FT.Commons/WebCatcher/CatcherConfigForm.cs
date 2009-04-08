using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Commons.WebCatcher
{
    public partial class CatcherConfigForm : Form
    {
        ConfigLoader<CatcherConfig> loader = null;
        public CatcherConfigForm()
        {
            InitializeComponent();
            loader = new ConfigLoader<CatcherConfig>(this);
            FormHelper.InitHabitToForm(this);
            this.cbParaType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtUrl.Text.Length == 0)
            {
                MessageBoxHelper.Show("������д�����Url��");
                return;
            }
            if (this.txtCatcherClassName.Text.Length == 0)
            {
                MessageBoxHelper.Show("������д������࣡");
                return;
            }
            loader.SaveConfig();
            MessageBoxHelper.Show("����ɹ���");
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            string result = FileDialogHelper.OpenDir(this.txtDownDir.Text.Trim());
            if (result.Length > 0)
            {
                this.txtDownDir.Text = result;
            }
        }
    }
}