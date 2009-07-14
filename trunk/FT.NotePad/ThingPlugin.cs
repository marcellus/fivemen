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

namespace FT.NotePad
{
    [Plugin(ChangeLogPath = "ThingPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "记事本插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ThingPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            //throw new Exception("The method or operation is not implemented.");
            //ToolStripMenuItem top = this.AddToMenu("记事本(&N)");
           // ToolStripMenuItem tmp = 
            //this.BuildSubMenu("记事本管理", typeof(ThingEditor));
            //top.DropDownItems.Add(tmp);
            //this.AddSeparatorToMenu(top);


        }


        public override void EmmitToolBar()
        {
            this.AddTopTool(FT.NotePad.Resource.png_0009, "我的记事本", typeof(ThingEditor));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
