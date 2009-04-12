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
    /// ͳ�Ʊ���Ĳ��
    /// </summary>
    [Plugin(ChangeLogPath = "StudentCounterPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "��У-ͳ�Ʊ�����", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class StudentCounterPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("ͳ�Ʊ���(&R)");
            ToolStripMenuItem tmp = this.BuildSubMenu("ѧԱ����", typeof(SimpleStudentCounter));
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSubMenu("ѧԱͳ��", typeof(StudentCounter));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("ѧ������ͳ��", typeof(StudentFeeCounter));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("��������ͳ��", typeof(CarFeeCounter));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("�ϸ���ͳ��", typeof(CoachCounter));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("���Ա���", typeof(BaoMinReport));
            top.DropDownItems.Add(tmp);
        }

        public override void EmmitToolBar()
        {

        }
    }
}
