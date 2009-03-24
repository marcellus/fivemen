using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Drawing;
using System.Diagnostics;

namespace FT.Windows.Forms.Plugins
{
    ///TODO:�˵���ݼ�
    /// <summary>
    /// �ṩһЩͨ�ò���Ĺ���
    /// </summary>
    public abstract class AbstractWindowPlugin:IPlugin
    {
        protected BaseMainForm form;

        private bool isEmmitSeparator = false;

        /// <summary>
        /// �Ƿ�ִ��ע�빤����
        /// </summary>
        public bool IsEmmitSeparator
        {
            get { return isEmmitSeparator; }
            set { isEmmitSeparator = value; }
        }
        /// <summary>
        /// ����һ��ϵͳ�Ĺ��ߣ���������
        /// </summary>
        /// <param name="cmd"></param>
        protected void StartExtendTools(string cmd)
        {
            try
            {
                Process.Start(cmd);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.Show("������ʾ��"+ex.Message+" "+cmd);
            }
        }

        
        
        
        #region IPlugin ��Ա

        public void Emmit(BaseMainForm form)
        {
            if (this.form == null)
            {
                this.form = form;
            }
            this.EmmitMenu();

            this.EmmitSeparator();
            this.EmmitToolBar();
            //throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// �������һ����������
        /// </summary>
        /// <param name="type"></param>
        protected void ShowWindowDialog(Type type)
        {
            if (type.BaseType == typeof(Form))
            {
                Form form =  ReflectHelper.CreateInstance(type) as Form;
                form.ShowDialog();
            }
        }
        /// <summary>
        /// �ж��Ƿ��ǵ�����һ�����������ǲ���ָ�����������
        /// </summary>
        private void EmmitSeparator()
        {
            if (this.isEmmitSeparator)
            {
                int count = this.form.GetToolStrip().Items.Count;
                if (count != 0)
                {
                    this.form.GetToolStrip().Items.Add(new System.Windows.Forms.ToolStripSeparator());
                }
            }
        }
        /// <summary>
        /// Ϊ�˵���������ķָ���
        /// </summary>
        /// <param name="menu"></param>
        protected void AddSeparatorToMenu(ToolStripMenuItem menu)
        {
            menu.DropDownItems.Add(new System.Windows.Forms.ToolStripSeparator());
        }

        /// <summary>
        /// ע��˵�
        /// </summary>
        public abstract void EmmitMenu();
        /// <summary>
        /// ע�빤����
        /// </summary>
        public abstract void EmmitToolBar();

        /// <summary>
        /// ����һ�����������˵�, �������¼�
        /// </summary>
        /// <param name="image"></param>
        /// <param name="text"></param>
        protected ToolStripButton AddTopTool(Image image, string text)
        {
            System.Windows.Forms.ToolStripButton tool = new System.Windows.Forms.ToolStripButton();
            tool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tool.Text = tool.ToolTipText = text;
            tool.Image = image;
            tool.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.form.GetToolStrip().Items.Add(tool);
            return tool;
        }

        /// <summary>
        /// ����һ�����������˵�, �����¼�
        /// </summary>
        /// <param name="image"></param>
        /// <param name="text"></param>
        protected ToolStripButton AddTopTool(Image image, string text,Type paneltype)
        {
            System.Windows.Forms.ToolStripButton tool=AddTopTool(image, text);
            tool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tool.Tag = paneltype.FullName;
            tool.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            tool.Click += new EventHandler(item_Click);
            return tool;
        }

        /// <summary>
        /// Ϊ����˵���Ӷ����˵�
        /// </summary>
        /// <param name="text"> �˵��ı�</param>
        /// <returns>�����ز˵�������</returns>
        protected ToolStripMenuItem AddToMenu(string text)
        {
            ToolStripMenuItem item = BuildTopMenu(text);
            item.ShortcutKeyDisplayString = "T";
            MenuStrip menus = form.GetMenuStrip();
            menus.Items.Add(item);
            
            return item;
        }
        /// <summary>
        /// ����һ��û�¼��Ĳ˵���
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected ToolStripMenuItem BuildTopMenu(string text)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = text;
            return item;

           
        }

        /// <summary>
        /// ����һ��ϵͳ���ߵĲ˵���
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected ToolStripMenuItem BuildSystemToolMenu(string text,string cmd)
        {
            return BuildSystemToolMenu(text, cmd, null);

        }

        /// <summary>
        /// ����һ��ϵͳ���ߵĲ˵���
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected ToolStripMenuItem BuildSystemToolMenu(string text, string cmd,Image image)
        {
            ToolStripMenuItem systemtool = new ToolStripMenuItem();
            systemtool.Text = text;
            systemtool.Tag = cmd;
            if(image!=null)
                systemtool.Image = image;
            systemtool.Click += new EventHandler(systemtool_Click);
            
            return systemtool;


        }

        void systemtool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ctr = sender as ToolStripMenuItem;
            this.StartExtendTools(ctr.Tag.ToString());
            //throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// ����һ�����е����ӿؼ����˵����¼��Ĳ˵���
        /// </summary>
        /// <param name="text"></param>
        /// <param name="paneltype"></param>
        /// <returns></returns>
        protected ToolStripMenuItem BuildSubMenu(string text, Type paneltype)
        {
            //Console.WriteLine("�����˵��"+text+";paneltype��"+paneltype);
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = text;
            item.Tag = paneltype.FullName;
            item.Click += new EventHandler(item_Click);
            return item;
        }

        void item_Click(object sender, EventArgs e)
        {
            // MessageBoxHelper.Show("����˵�!");
            //Console.WriteLine("����˵�!");
            ToolStripItem item = sender as ToolStripItem;
            if (item != null)
            {
                //Console.WriteLine("form Ϊ��"+form);
                object paneltmp = ReflectHelper.CreateInstance(item.Tag.ToString());
                if ((typeof(Form)).IsAssignableFrom(paneltmp.GetType()))
                {
                    Form form = paneltmp as Form;
                    form.ShowInTaskbar = false;
                    form.StartPosition = FormStartPosition.CenterParent;
                    //form.MdiParent = this.form;
                    //form.IsMdiChild = true;
                    form.ShowDialog();
                }
                else
                {
                    int count=this.form.GetSimpleTabControl().TabPages.Count;
                    for(int i=0;i<count;i++)
                    {
                        if (this.form.GetSimpleTabControl().TabPages[i].Text.StartsWith(item.Text))
                        {
                            this.form.GetSimpleTabControl().SelectedIndex = i;
                            //tab.Select();
                           // tab.Focus();
                           return;
                        }
                    }
                    this.form.GetSimpleTabControl().TabPages.Add(item.Text + "    ");
                    //TabPage tb = new TabPage();
                    //this.form.GetSimpleTabControl().TabPages.Add(tb);
                    TabPage tb = this.form.GetSimpleTabControl().TabPages[this.form.GetSimpleTabControl().TabPages.Count - 1];

                    //object paneltmp = ReflectHelper.CreateInstance(typeof(FT.Lottery.LotteryParse));
                    Control panel = (Control)paneltmp;
                    panel.Dock = DockStyle.Fill;
                    tb.Controls.Add(panel);
                    this.form.GetSimpleTabControl().SelectedIndex = this.form.GetSimpleTabControl().TabCount - 1;
                }
            }
        }

        public void Init()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IAppUnit ��Ա

        public void BeginGlobalization(System.Globalization.CultureInfo cultureInfo)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void BeginCall()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
