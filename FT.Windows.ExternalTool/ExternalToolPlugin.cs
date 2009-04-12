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

namespace FT.Windows.ExternalTool
{
    [Plugin(ChangeLogPath = "ExternalTool-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
         Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "开发工具插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ExternalToolPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            //throw new Exception("The method or operation is not implemented.");
            ToolStripMenuItem top = this.AddToMenu("开发工具(&D)");
            ToolStripMenuItem tmp = this.BuildSubMenu("现有插件...", typeof(FT.Windows.Forms.PluginManageForm));

            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("配置插件...", typeof(FT.Windows.Forms.PluginConfigForm));

            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("监控条码配置", typeof(FT.Commons.Bar.BarReaderConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("条码读取测试", typeof(FT.Commons.Bar.CodeReader));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("加密解密", typeof(SecurityForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("运行时查看器", typeof(RuntimeView));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("程序使用情况", typeof(ProgramRegConfigForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("模板管理", typeof(FT.Windows.Forms.EntitySearch));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("模板列定义管理", typeof(FT.Windows.Forms.EntityConfigSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("蜘蛛配置", typeof(FT.Commons.WebCatcher.CatcherConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("蜘蛛控制台", typeof(FT.Commons.WebCatcher.CatcherForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("蜘蛛正则测试", typeof(FT.Commons.WebCatcher.RegexTest));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("TCP客户端配置", typeof(FT.Commons.TcpIp.ClientConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("TCP模拟客户端", typeof(FT.Commons.TcpIp.TcpClientMockForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("TCP服务器端配置", typeof(FT.Commons.TcpIp.TcpServerConfigForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("截图测试", typeof(FT.Windows.ExternalTool.CaptureImageTest));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("KeyChar监听", typeof(FT.Windows.Forms.CommonForm.KeyCharMonitorForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("文件压缩解压", typeof(ZipTestForm));
            top.DropDownItems.Add(tmp);
            //tmp = this.BuildSubMenu("TCP控制台", typeof(FT.Commons.TcpIp.TcpWatcherForm));
            //top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {
          
        }
    }
}
