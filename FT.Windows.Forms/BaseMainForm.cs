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

namespace FT.Windows.Forms
{
    public partial class BaseMainForm : Form
    {
        public BaseMainForm()
        {
            InitializeComponent();
        }
        private ProgramState state;
        public BaseMainForm(ProgramState state):this()
        {
            this.state = state;
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
                PluginManager.LoadAllPluginToMainForm(this);
                this.Text = Application.ProductName + Application.ProductVersion;
                if (this.state == ProgramState.Trial)
                {
                    this.Text += "-试用版";
                }
                else if (this.state == ProgramState.Registed)
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
    }
}