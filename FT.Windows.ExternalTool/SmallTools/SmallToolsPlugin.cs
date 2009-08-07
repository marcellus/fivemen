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
    [Plugin(ChangeLogPath = "SmallToolsPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "����С���߲��", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class SmallToolsPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {
        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("����С����(&T)");
            ToolStripMenuItem tmp = this.BuildSubMenu("�ֻ������ز�ѯ", typeof(MobileSearchForm));

            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("���֤�����ز�ѯ", typeof(IdCardSearchForm));
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSubMenu("IP�����ز�ѯ", typeof(IpSearchForm));
            top.DropDownItems.Add(tmp);


            tmp = this.BuildSubMenu("�ʱ�����ز�ѯ", typeof(PostCodeSearchForm));
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSubMenu("2009�Ļ𳵲�ѯ", typeof(TrainSearchControl));
            top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {

        }
    }
}
