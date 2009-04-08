using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.Cache;

namespace FT.Commons.WebCatcher
{
    public partial class CatcherForm : Form
    {
        public CatcherForm()
        {
            InitializeComponent();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            CatcherConfigForm form = new CatcherConfigForm();
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtConsole.Text = string.Empty;
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            CatcherConfig config=StaticCacheManager.GetConfig<CatcherConfig>();
            object obj=ReflectHelper.CreateInstance(config.CatcherClassName);
            ICatcher catcher = obj as ICatcher;
            catcher.Parse();
        }
    }
}