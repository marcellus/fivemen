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
    [Plugin(ChangeLogPath = "StudentPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "ѧԱ������", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class StudentPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("ѧԱ����(&S)");
            ToolStripMenuItem tmp = this.BuildSubMenu("���ѧԱ", typeof(StudentBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ѧԱ����", typeof(StudentSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            //top.DropDownItems.Add(this.
            tmp = this.BuildSubMenu("ѧԱ�ɷ�", typeof(StudentFeeBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("�ɷѹ���", typeof(StudentFeeSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("��ӿ��Լ�¼", typeof(StudentExamBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("���Լ�¼����", typeof(StudentExamSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("��ά�������", typeof(TestPdf417Code));
            top.DropDownItems.Add(tmp);

        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(DS.Plugins.Student.Resource.Student, "ѧԱ����", typeof(StudentSearch));
        }
    }
}
