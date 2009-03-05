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
        /// ��ע��Ĳ��ҳ��ʹ��
        /// </summary>
        /// <returns></returns>
        public SimpleTabControl GetSimpleTabControl()
        {
            return this.simpleTabControl1;
        }

        /// <summary>
        /// ��ȡToolStrip���в���
        /// </summary>
        /// <returns></returns>
        public ToolStrip GetToolStrip()
        {
            return this.toolStrip1;
        }

        /// <summary>
        /// ��ȡStatusStrip���в���
        /// </summary>
        /// <returns></returns>
        public StatusStrip GetStatusStrip()
        {
            return this.statusStrip1;
        }

        /// <summary>
        /// �ؼ���ע��ķ�ʽ
        /// </summary>
        /// <returns>��ȡ�˵������ע��</returns>
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
                    this.Text += "-���ð�";
                }
                else if (this.state == ProgramState.Registed)
                {
                    this.Text += "-��ʽ��";
                }

                else 
                {
                    this.Text += "-Beta��";
                }
            }
        }

        public void LoadPluginDebug(string filename)
        {
            //PluginManager.EmmitFromFile(this,filename);
        }
    }
}