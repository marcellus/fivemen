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

namespace DS.Plugins.Student
{
    /// <summary>
    /// ѧԱ����Ĳ��
    /// </summary>
    [Plugin(ChangeLogPath = "SystemConfigPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "ϵͳ���ò��", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class SystemConfigPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("ϵͳ����(&G)");
            ToolStripMenuItem tmp = this.BuildSubMenu("ȫ�ִ�ӡ����...", typeof(FT.Windows.Forms.CustomPrinterSetting));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ѧԱ��ӡ����", typeof(PrintSettingForm));
            top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {

        }
    }
}
