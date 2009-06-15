using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Cache;
using System.Collections;
using FT.Commons.Tools;

namespace FT.Windows.Forms
{
    public partial class PluginConfigForm : Form
    {
        public PluginConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
        }

        private void listViewNow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem item in this.listViewNow.SelectedItems)
                {
                    this.listViewNow.Items.Remove(item);
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PluginsFileConfig config=new PluginsFileConfig();
            config.PluginTypes.Clear();
            foreach (ListViewItem item in this.listViewNow.Items)
            {
                config.PluginTypes.Add(item.SubItems[1].Text);
            }
            StaticCacheManager.SaveConfig<PluginsFileConfig>(config);
            MessageBoxHelper.Show("保存成功,请退出重进！");
        }

        private void PluginConfigForm_Load(object sender, EventArgs e)
        {
            this.InitListViewByCache(this.listViewNow, FT.Windows.Forms.Plugins.PluginManager.UseCaches);
            this.InitListViewByCache(this.listViewAll, FT.Windows.Forms.Plugins.PluginManager.AllCaches);
        }

        private void InitListViewByCache(ListView listview,Hashtable caches)
        {
            listview.DoubleClick += new EventHandler(listview_DoubleClick);
            /*初始化使用的插件*/
            System.Collections.IDictionaryEnumerator enumerator = caches.GetEnumerator();
            //ListViewItem tmp = null;
            PluginAttribute att = null;
            while (enumerator.MoveNext())
            {
                att = enumerator.Value as PluginAttribute;
                if (att != null)
                {
                    ListViewItem tmp = new ListViewItem(new string[] { att.Name,enumerator.Key.ToString() });
                    tmp.Tag = att;
                    listview.Items.Add(tmp);
                }
            }
        }

        void listview_DoubleClick(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedIndices.Count > 0)
            {
                Form form = new PluginDetailForm(lv.SelectedItems[0].Tag as PluginAttribute);
                form.ShowInTaskbar = false;
                form.ShowDialog();
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        private void listViewAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                foreach (ListViewItem item in this.listViewAll.SelectedItems)
                {
                    this.listViewNow.Items.Add(((ListViewItem)item.Clone()));
                }
            }
        }
    }
}