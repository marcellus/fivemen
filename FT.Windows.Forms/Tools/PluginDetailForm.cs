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
            FormHelper.SetDataToForm(this, att);
        }

        private void lbUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.lbUrl.Text.Trim());
        }

        private void lbEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start(this.lbEmail.Text.Trim());
        }

        private void lbChangeLogPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.att.ChangeLogPath;
            //this.att.
            string path = ReflectHelper.GetStartUpPath("changelog\\" + att.ChangeLogPath);
            try
            {
                //string test=att.GetType().Name;
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("¥ÌŒÛ–≈œ¢£∫"+ex.Message);
            }
        }

        
    }
}

