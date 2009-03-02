using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using System.IO;

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
            //FT.Windows.Forms.Plugins.PluginManager.LoadAllPlugin();
            this.Init();
        }
        /// <summary>
        /// 添加一个属性到ListView上
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="att"></param>
        private void AddAttToListView(ListView listview, PluginAttribute att)
        {
            ListViewItem tmp = new ListViewItem(new string[] { att.Name, att.MainVersion, att.Company, att.IsGlobalization.ToString(), "启用" });
            tmp.Tag = att;
            listview.Items.Add(tmp);
        }

        private void Init()
        {
            /*初始化使用的插件*/
            System.Collections.IDictionaryEnumerator enumerator = FT.Windows.Forms.Plugins.PluginManager.UseCaches.GetEnumerator();
            //ListViewItem tmp = null;
            PluginAttribute att=null;
            while (enumerator.MoveNext())
            {
                att = enumerator.Value as PluginAttribute;
                if (att != null)
                {
                    this.AddAttToListView(this.listView1, att);
                }
            }
            /*初始化现有使用的插件*/
            //初始化所有的系统插件
            
            //StaticCacheManager.SaveConfig<T>(config);
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

