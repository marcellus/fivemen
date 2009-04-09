using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using FT.Commons.WebCatcher;
using FT.DAL;
using System.Windows.Forms;
using System.IO;

namespace FT.Windows.CommonsPlugin
{
    [Plugin(ChangeLogPath = "SystemToolsPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
      Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "外部工具插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class SystemToolsPlugin : AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("外部工具(&S)");
            //top.
            ToolStripMenuItem tmp
             = this.BuildSystemToolMenu("我的电脑", "explorer.exe",FT.Windows.CommonsPlugin.Resource.My_Computer.ToBitmap());
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSystemToolMenu("控制面板", "control.exe", FT.Windows.CommonsPlugin.Resource.Settings1.ToBitmap());
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSystemToolMenu("计算器", "calc.exe", FT.Windows.CommonsPlugin.Resource.calc.ToBitmap());
            
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSystemToolMenu("记事本", "notepad.exe", FT.Windows.CommonsPlugin.Resource.Text_Document.ToBitmap());

            top.DropDownItems.Add(tmp);

            tmp = this.BuildSystemToolMenu("画图工具", "mspaint.exe", FT.Windows.CommonsPlugin.Resource.painter.ToBitmap());
           
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSystemToolMenu("注册表", "regedit.exe", FT.Windows.CommonsPlugin.Resource.regedit.ToBitmap());
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSystemToolMenu("命令行", "cmd.exe");
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSystemToolMenu("时间日期", "timedate.cpl",FT.Windows.CommonsPlugin.Resource.clock);
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = false;
        }
        
       
        public override void EmmitToolBar()
        {
            //this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Config, "基础数据管理", typeof(DictSearch));
            //this.AddTopTool(FT.Windows.CommonsPlugin.Resource.Notepad, "记事本").Click += new EventHandler(notepad_Click);
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
