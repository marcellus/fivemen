using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;

namespace FT.Windows.Forms
{
    public partial class PluginDetailForm : Form
    {
        private PluginAttribute att;
        public PluginDetailForm()
        {
            InitializeComponent();
        }
        public PluginDetailForm(PluginAttribute att):this()
        {
            this.att = att;
        }

        private void PluginDetailForm_Load(object sender, EventArgs e)
        {
            FormHelper.LoadData(this, att);
        }
    }
}

