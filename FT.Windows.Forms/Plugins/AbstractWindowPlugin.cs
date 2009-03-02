using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Drawing;
using System.Diagnostics;

namespace FT.Windows.Forms.Plugins
{
    ///TODO:菜单快捷键
    /// <summary>
    /// 提供一些通用插件的功能
    /// </summary>
    public abstract class AbstractWindowPlugin:IPlugin
    {
        private BaseMainForm form;

        private bool isEmmitSeparator = false;

        /// <summary>
        /// 是否执行注入工具栏
        /// </summary>
        public bool IsEmmitSeparator
        {
            get { return isEmmitSeparator; }
            set { isEmmitSeparator = value; }
        }
        /// <summary>
        /// 启动一个系统的工具，或者命令
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
                MessageBoxHelper.Show("错误提示："+ex.Message);
            }
        }

        
        
        
        #region IPlugin 成员

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
        /// 点击弹出一个窗体类型
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
        /// 判断是否是单独的一个插件，如果是插入分隔符到工具栏
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
        /// 为菜单添加下拉的分隔符
        /// </summary>
        /// <param name="menu"></param>
        protected void AddSeparatorToMenu(ToolStripMenuItem menu)
        {
            menu.DropDownItems.Add(new System.Windows.Forms.ToolStripSeparator());
        }

        /// <summary>
        /// 注入菜单
        /// </summary>
        public abstract void EmmitMenu();
        /// <summary>
        /// 注入工具栏
        /// </summary>
        public abstract void EmmitToolBar();

        /// <summary>
        /// 增加一个工具栏到菜单, 不带有事件
        /// </summary>
        /// <param name="image"></param>
        /// <param name="text"></param>
        protected ToolStripButton AddTopTool(Image image, string text)
        {
            System.Windows.Forms.ToolStripButton tool = new System.Windows.Forms.ToolStripButton();
            tool.Text = tool.ToolTipText = text;
            tool.Image = image;
            this.form.GetToolStrip().Items.Add(tool);
            return tool;
        }

        /// <summary>
        /// 增加一个工具栏到菜单, 带有事件
        /// </summary>
        /// <param name="image"></param>
        /// <param name="text"></param>
        protected ToolStripButton AddTopTool(Image image, string text,Type paneltype)
        {
            System.Windows.Forms.ToolStripButton tool=AddTopTool(image, text);
            tool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tool.Tag = paneltype.FullName;
            tool.Click += new EventHandler(item_Click);
            return tool;
        }

        /// <summary>
        /// 为插件菜单添加顶级菜单
        /// </summary>
        /// <param name="text"> 菜单文本</param>
        /// <returns>并返回菜单的内容</returns>
        protected ToolStripMenuItem AddToMenu(string text)
        {
            ToolStripMenuItem item = BuildTopMenu(text);
            item.ShortcutKeyDisplayString = "T";
            MenuStrip menus = form.GetMenuStrip();
            menus.Items.Add(item);
            
            return item;
        }
        /// <summary>
        /// 创建一个没事件的菜单项
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
        /// 创建一个带有点击添加控件到菜单的事件的菜单项
        /// </summary>
        /// <param name="text"></param>
        /// <param name="paneltype"></param>
        /// <returns></returns>
        protected ToolStripMenuItem BuildSubMenu(string text, Type paneltype)
        {
            //Console.WriteLine("创建菜单项："+text+";paneltype："+paneltype);
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = text;
            item.Tag = paneltype.FullName;
            item.Click += new EventHandler(item_Click);
            return item;
        }

        void item_Click(object sender, EventArgs e)
        {
            // MessageBoxHelper.Show("点击菜单!");
            //Console.WriteLine("点击菜单!");
            ToolStripItem item = sender as ToolStripItem;
            if (item != null)
            {
                //Console.WriteLine("form 为："+form);
                object paneltmp = ReflectHelper.CreateInstance(item.Tag.ToString());
                if (paneltmp.GetType().BaseType == typeof(Form))
                {
                    Form form = paneltmp as Form;
                    form.ShowInTaskbar = false;
                    //form.MdiParent = this.form;
                    //form.IsMdiChild = true;
                    form.ShowDialog();
                }
                else
                {
                    this.form.GetSimpleTabControl().TabPages.Add(item.Text + "    ");
                    //TabPage tb = new TabPage();
                    //this.form.GetSimpleTabControl().TabPages.Add(tb);
                    TabPage tb = this.form.GetSimpleTabControl().TabPages[this.form.GetSimpleTabControl().TabPages.Count - 1];

                    //object paneltmp = ReflectHelper.CreateInstance(typeof(FT.Lottery.LotteryParse));
                    Control panel = (Control)paneltmp;
                    panel.Dock = DockStyle.Fill;
                    tb.Controls.Add(panel);
                }
            }
        }

        public void Init()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IAppUnit 成员

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
