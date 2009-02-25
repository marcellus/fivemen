using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Plugins;

namespace FT.Windows.Forms
{
    public partial class PluginManageForm : Form
    {
        public PluginManageForm()
        {
            InitializeComponent();
        }

        private void PluginManageForm_Load(object sender, EventArgs e)
        {
            FT.Windows.Forms.Plugins.PluginManager.LoadAllPlugin();
            this.Init();
        }

        private void Init()
        {
            System.Collections.IDictionaryEnumerator enumerator = FT.Windows.Forms.Plugins.PluginManager.Caches.GetEnumerator();
            ListViewItem tmp = null;
            PluginAttribute att=null;
            while (enumerator.MoveNext())
            {
                att = enumerator.Value as PluginAttribute;
                if (att != null)
                {
                    tmp = new ListViewItem(new string[] { att.Name, att.MainVersion, att.Company, att.IsGlobalization.ToString() ,"ÆôÓÃ"});
                    tmp.Tag = enumerator.Value;
                    this.listView1.Items.Add(tmp);
                }
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices.Count > 0)
            {
                Form form = new PluginDetailForm(this.listView1.SelectedItems[0].Tag as PluginAttribute);
                form.ShowDialog();
            }
        }
    }
}

