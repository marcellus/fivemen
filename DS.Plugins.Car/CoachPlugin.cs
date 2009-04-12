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

namespace DS.Plugins.Car
{
    /// <summary>
    /// ����������
    /// </summary>
    [Plugin(ChangeLogPath = "CoachPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "����Ա����", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class CoachPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("����Ա����(&C)");
            ToolStripMenuItem tmp = this.BuildSubMenu("��ӽ���Ա", typeof(CoachBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("����Ա����", typeof(CoachSearch));
            top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(DS.Plugins.Car.Resource.Coach, "��������", typeof(CoachSearch));
        }
    }
}
