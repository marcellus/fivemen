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
            this.simpleTabControl1.Font = new Font("����",11f);
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
                
                if (AppicationHelper.ProductState == ProgramState.Trial)
                {
                    this.Text += "-���ð�";
                }
                else if (AppicationHelper.ProductState == ProgramState.Registed)
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

        private void BaseMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxHelper.Confirm("ȷ���˳���ϵͳ��"))
            {
                ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
                if (config.LastDate > System.DateTime.Now)
                {
                    MessageBoxHelper.Show("�Բ��𣬵�ǰʱ�䱻�۸ģ�");
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