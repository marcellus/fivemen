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

namespace FT.Plugins.PersonCard
{
    [Plugin(ChangeLogPath = "PersonCardPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "个人名片夹插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class PersonCardPlugin:FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            //throw new Exception("The method or operation is not implemented.");
            ToolStripMenuItem top= this.AddToMenu("我的名片夹(&C)");
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
            this.IsEmmitSeparator = true;
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(FT.Plugins.PersonCard.Properties.Resource.Address_Book, "名片管理", typeof(FT.Plugins.PersonCard.PersonCardManager));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
