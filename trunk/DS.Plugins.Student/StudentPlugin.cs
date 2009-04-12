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
    /// 学员管理的插件
    /// </summary>
    [Plugin(ChangeLogPath = "StudentPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "学员管理插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class StudentPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("学员管理(&S)");
            ToolStripMenuItem tmp = this.BuildSubMenu("添加学员", typeof(StudentBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("学员管理", typeof(StudentSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            //top.DropDownItems.Add(this.
            tmp = this.BuildSubMenu("学员缴费", typeof(StudentFeeBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("缴费管理", typeof(StudentFeeSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("添加考试记录", typeof(StudentExamBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("考试记录管理", typeof(StudentExamSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("二维条码测试", typeof(TestPdf417Code));
            top.DropDownItems.Add(tmp);

        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(DS.Plugins.Student.Resource.Student, "学员管理", typeof(StudentSearch));
        }
    }
}
