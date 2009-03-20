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
    /// 统计报表的插件
    /// </summary>
    [Plugin(ChangeLogPath = "StudentCounterPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "驾校-统计报表插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class StudentCounterPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("统计报表(&R)");
            ToolStripMenuItem tmp = this.BuildSubMenu("学员汇总", typeof(SimpleStudentCounter));
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSubMenu("学员统计", typeof(SimpleStudentCounter));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("学生费用汇总", typeof(SimpleStudentCounter));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("车辆费用汇总", typeof(SimpleStudentCounter));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("合格率统计", typeof(SimpleStudentCounter));
            top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {

        }
    }
}
