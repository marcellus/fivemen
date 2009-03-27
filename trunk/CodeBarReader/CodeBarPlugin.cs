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

namespace CodeBarReader
{
    [Plugin(ChangeLogPath = "ExternalTool-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "条码工具插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class CodeBarPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            //throw new Exception("The method or operation is not implemented.");
            ToolStripMenuItem top = this.AddToMenu("条码工具(&C)");
            ToolStripMenuItem tmp = this.BuildSubMenu("监控条码配置", typeof(FT.Commons.Bar.BarReaderConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("条码读取测试", typeof(FT.Commons.Bar.CodeReader));
            top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {

        }
    }
}
