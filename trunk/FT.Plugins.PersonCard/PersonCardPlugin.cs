using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using FT.Commons.WebCatcher;
using FT.DAL;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data;

namespace FT.Plugins.PersonCard
{
    [Plugin(ChangeLogPath = "PersonCardPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "名片夹插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class PersonCardPlugin:FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            //throw new Exception("The method or operation is not implemented.");
            ToolStripMenuItem top= this.AddToMenu("名片夹(&C)");
            ToolStripMenuItem tmp = this.BuildSubMenu("添加名片", typeof(FT.Plugins.PersonCard.PersonCardBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("名片管理", typeof(FT.Plugins.PersonCard.PersonCardManager));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            //top.DropDownItems.Add(this.
            tmp = this.BuildSubMenu("添加分组", typeof(FT.Plugins.PersonCard.GroupBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("分组管理", typeof(FT.Plugins.PersonCard.GroupSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("名片配置", typeof(FT.Plugins.PersonCard.Setting));
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = true;
            this.form.Load += new EventHandler(BirthdayHint);
            
            
        }

        

        public static void BirthdayHint(object sender, EventArgs e)
        {
            BaseMainForm form = sender as BaseMainForm;
            CarStartSetting setting = FT.Commons.Cache.StaticCacheManager.GetConfig<CarStartSetting>();
            if (setting.BirthDayHint)
            {
                DateTime before = System.DateTime.Now;
                DateTime end = System.DateTime.Now.AddDays(setting.Days);
                //c_birthday
                IDataAccess access = DataAccessFactory.GetDataAccess();
                string condition = access.BetweenDateString(
                    "c_birthday", before, end);
                DataTable dt = access.SelectDataTable("select * from table_cards where " + condition, "tmp");
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (MessageBoxHelper.Confirm("有" + dt.Rows.Count + "人将在最近" + setting.Days + "天内过生日，是否查看？"))
                    {
                        form.GetSimpleTabControl().TabPages.Add("将过生日人员    ");
                        //TabPage tb = new TabPage();
                        //this.form.GetSimpleTabControl().TabPages.Add(tb);
                        TabPage tb = form.GetSimpleTabControl().TabPages[form.GetSimpleTabControl().TabPages.Count - 1];

                        //object paneltmp = ReflectHelper.CreateInstance(typeof(FT.Lottery.LotteryParse));

                        PersonCardSearch panel = new PersonCardSearch();
                        panel.SetConditions(condition);
                        panel.Dock = DockStyle.Fill;
                        tb.Controls.Add(panel);
                        form.GetSimpleTabControl().SelectedIndex = 
                            form.GetSimpleTabControl().TabCount - 1;
                    }
                }
            }
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(FT.Plugins.PersonCard.Properties.Resource.Address_Book, "名片管理", typeof(FT.Plugins.PersonCard.PersonCardManager));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
