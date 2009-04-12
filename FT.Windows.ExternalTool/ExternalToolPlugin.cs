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
         Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "�������߲��", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ExternalToolPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            //throw new Exception("The method or operation is not implemented.");
            ToolStripMenuItem top = this.AddToMenu("��������(&D)");
            ToolStripMenuItem tmp = this.BuildSubMenu("���в��...", typeof(FT.Windows.Forms.PluginManageForm));

            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("���ò��...", typeof(FT.Windows.Forms.PluginConfigForm));

            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("�����������", typeof(FT.Commons.Bar.BarReaderConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("�����ȡ����", typeof(FT.Commons.Bar.CodeReader));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("���ܽ���", typeof(SecurityForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����ʱ�鿴��", typeof(RuntimeView));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����ʹ�����", typeof(ProgramRegConfigForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("ģ�����", typeof(FT.Windows.Forms.EntitySearch));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ģ���ж������", typeof(FT.Windows.Forms.EntityConfigSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("֩������", typeof(FT.Commons.WebCatcher.CatcherConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("֩�����̨", typeof(FT.Commons.WebCatcher.CatcherForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("֩���������", typeof(FT.Commons.WebCatcher.RegexTest));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("TCP�ͻ�������", typeof(FT.Commons.TcpIp.ClientConfigForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("TCPģ��ͻ���", typeof(FT.Commons.TcpIp.TcpClientMockForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("TCP������������", typeof(FT.Commons.TcpIp.TcpServerConfigForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("��ͼ����", typeof(FT.Windows.ExternalTool.CaptureImageTest));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("KeyChar����", typeof(FT.Windows.Forms.CommonForm.KeyCharMonitorForm));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("�ļ�ѹ����ѹ", typeof(ZipTestForm));
            top.DropDownItems.Add(tmp);
            //tmp = this.BuildSubMenu("TCP����̨", typeof(FT.Commons.TcpIp.TcpWatcherForm));
            //top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {
          
        }
    }
}
