using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Controls.TabControlEx;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using FT.Commons.Cache;
using FT.Windows.Forms.Domain;
using System.IO;

namespace FT.Windows.Forms
{
    public partial class BaseMainForm : DevExpress.XtraEditors.XtraForm
    {
        public BaseMainForm()
        {
            InitializeComponent();
            PluginManager.LoadAllPluginToMainForm(this);
            this.simpleTabControl1.Font = new Font("宋体",11f);
        }
    

        
        /// <summary>
        /// 供注入的插件页面使用
        /// </summary>
        /// <returns></returns>
        public SimpleTabControl GetSimpleTabControl()
        {
            return this.simpleTabControl1;
        }

        /// <summary>
        /// 获取ToolStrip进行操作
        /// </summary>
        /// <returns></returns>
        public ToolStrip GetToolStrip()
        {
            return this.toolStrip1;
        }

        /// <summary>
        /// 获取StatusStrip进行操作
        /// </summary>
        /// <returns></returns>
        public StatusStrip GetStatusStrip()
        {
            return this.statusStrip1;
        }

        /// <summary>
        /// 控件的注入的方式
        /// </summary>
        /// <returns>获取菜单项进行注入</returns>
        public MenuStrip GetMenuStrip()
        {
            return this.menuStrip1;
        }

        private void BaseMainForm_Load(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            if (!this.DesignMode)
            {
                
                if (AppicationHelper.ProductState == ProgramState.Trial)
                {
                    this.Text += "-试用版";
                }
                else if (AppicationHelper.ProductState == ProgramState.Registed)
                {
                    this.Text += "-正式版";
                }

                else 
                {
                    this.Text += "-Beta版";
                }
            }
        }

        public void LoadPluginDebug(string filename)
        {
            //PluginManager.EmmitFromFile(this,filename);
        }

        private void BaseMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxHelper.Confirm("确定退出本系统吗？"))
            {
                ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
                if (config.LastDate > System.DateTime.Now)
                {
                    MessageBoxHelper.Show("对不起，当前时间被篡改！");
                    e.Cancel = true;
                }
                else
                {
                    config.LastDate = System.DateTime.Now;
                    config.UseCount++;
                    StaticCacheManager.SaveConfig<ProgramRegConfig>(config);
                    FileHelper.WriteLastLog(Application.ProductName);
                    DbAutoBakConfig dbconfig = StaticCacheManager.GetConfig<DbAutoBakConfig>();
                    if (dbconfig.AutoBak)
                    {
                        dbconfig.BakDb();
                    }
                }
            }
            else
            {

                e.Cancel = true;
            }
        }


    }
}