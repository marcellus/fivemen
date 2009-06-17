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
using FT.Commons.Cache;

namespace DS.Plugins.Student
{
    /// <summary>
    /// ѧԱ����Ĳ��
    /// </summary>
    [Plugin(ChangeLogPath = "NewStudentPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "�µ�ѧԱ������", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class NewStudentPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("��ʻ��Ԥ¼��(&S)");
            ToolStripMenuItem tmp = this.BuildSubMenu("��ʼ����", typeof(StudentBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("��Ƭ�ɼ�", typeof(DriverPicCapture));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ѧԱ�ɷ�", typeof(StudentFeeBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("ѧԱ�޸�", typeof(UpdateForm));
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSubMenu("ѧԱ�б�", typeof(StudentSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildTopMenu("ֱ�Ӵ��������ʻ֤�����");
            tmp.Click += new EventHandler(StudentHelper.F7_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��������ʻ֤�����");
            tmp.Click += new EventHandler(StudentHelper.F6_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��������ʻ��ѵ��¼");
            tmp.Click += new EventHandler(StudentHelper.F2_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��������ʻ����������֤��");
            tmp.Click += new EventHandler(StudentHelper.F3_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��������ʻԱ��ѵѧԱ�ǼǱ�");
            tmp.Click += new EventHandler(StudentHelper.F4_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��Ŀ�����Գɼ���");
            tmp.Click += new EventHandler(StudentHelper.F5_Click);
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            
            tmp = this.BuildTopMenu("��Ŀһ�ɼ�¼��");
            tmp.Click += new EventHandler(StudentHelper.subject1_Click);
            top.DropDownItems.Add(tmp);

            StudentSystemConfig config = StaticCacheManager.GetConfig<StudentSystemConfig>();
            if (config.SubjectIs4)
            {
                tmp = this.BuildTopMenu("��Ŀ����׮���ɼ�¼��");
                tmp.Click += new EventHandler(StudentHelper.subject20_Click);
                top.DropDownItems.Add(tmp);

                tmp = this.BuildTopMenu("��Ŀ�������أ��ɼ�¼��");
                tmp.Click += new EventHandler(StudentHelper.subject21_Click);
                top.DropDownItems.Add(tmp);
            }
            else
            {
                tmp = this.BuildTopMenu("��Ŀ���ɼ�¼��");
                tmp.Click += new EventHandler(StudentHelper.subject2_Click);
                top.DropDownItems.Add(tmp);
            }
            tmp = this.BuildTopMenu("��Ŀ���ɼ�¼��");
            tmp.Click += new EventHandler(StudentHelper.subject3_Click);
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("��ѧ", typeof(QuitForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("������ݽ���", typeof(InitButtonPanel));
            top.DropDownItems.Add(tmp);
            

        }
        

        public override void EmmitToolBar()
        {
            //this.AddTopTool(DS.Plugins.Student.Resource.Student, "ѧԱ����", typeof(StudentSearch));
        }
    }
}
