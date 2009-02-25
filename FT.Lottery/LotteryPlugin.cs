using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using FT.Commons.WebCatcher;
using FT.DAL;
using System.Windows.Forms;

namespace FT.Lottery
{
    [Plugin(ChangeLogPath = "changlog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "cbw123_1984@163,com", MainVersion = "1.0", Name = "自助博彩工具", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class LotteryPlugin:IPlugin
    {
        private BaseMainForm form;
        #region IPlugin 成员

        public void Emmit(BaseMainForm form)
        {
            if (this.form == null)
            {
                this.form = form;
            }
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = "自助博彩";
           // item.DropDownItems.Add(this.BuildToolStripItem("联赛队伍管理",typeof()));
           // item.DropDownItems.Add(this.BuildToolStripItem("彩票分析",typeof()));
            
            MenuStrip menus=form.GetMenuStrip();
            menus.Items.Add(item);
        }

        private ToolStripItem BuildToolStripItem(string text,Type paneltype)
        {
            ToolStripItem item = new ToolStripMenuItem();
            item.Text = text;
            item.Tag = paneltype.FullName;
            item.Click += new EventHandler(item_Click);
            return item;
        }

        void item_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            if (item != null)
            {
                this.form.GetSimpleTabControl().TabPages.Add(item.Text);
                TabPage tb=this.form.GetSimpleTabControl().TabPages[this.form.GetSimpleTabControl().TabPages.Count];
                Panel panel=(Panel)ReflectHelper.CreateInstance(item.Tag.ToString());
                panel.Dock=DockStyle.Fill;
                tb.Controls.Add(panel);
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
