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
            tmp.Click += new EventHandler(F7_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��������ʻ֤�����");
            tmp.Click += new EventHandler(F6_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��������ʻ��ѵ��¼");
            tmp.Click += new EventHandler(F2_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��������ʻ����������֤��");
            tmp.Click += new EventHandler(F3_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��������ʻԱ��ѵѧԱ�ǼǱ�");
            tmp.Click += new EventHandler(F4_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("�״�-��Ŀ�����Գɼ���");
            tmp.Click += new EventHandler(F5_Click);
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            
            tmp = this.BuildTopMenu("��Ŀһ�ɼ�¼��");
            tmp.Click += new EventHandler(subject1_Click);
            top.DropDownItems.Add(tmp);

            StudentSystemConfig config = StaticCacheManager.GetConfig<StudentSystemConfig>();
            if (config.SubjectIs4)
            {
                tmp = this.BuildTopMenu("��Ŀ����׮���ɼ�¼��");
                tmp.Click += new EventHandler(subject20_Click);
                top.DropDownItems.Add(tmp);

                tmp = this.BuildTopMenu("��Ŀ�������أ��ɼ�¼��");
                tmp.Click += new EventHandler(subject21_Click);
                top.DropDownItems.Add(tmp);
            }
            else
            {
                tmp = this.BuildTopMenu("��Ŀ���ɼ�¼��");
                tmp.Click += new EventHandler(subject2_Click);
                top.DropDownItems.Add(tmp);
            }
            tmp = this.BuildTopMenu("��Ŀ���ɼ�¼��");
            tmp.Click += new EventHandler(subject3_Click);
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("��ѧ", typeof(QuitForm));
            top.DropDownItems.Add(tmp);
            

        }
        void F7_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F7);
            form.ShowInTaskbar = false;
            form.Text = "ֱ�Ӵ��������ʻ֤�����";
            form.ShowDialog();
        }
        void F6_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F6);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��������ʻ֤�����";
            form.ShowDialog();
        }
        void F5_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F5);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��Ŀ�����Գɼ���";
            form.ShowDialog();
        }
        void F4_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F4);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��������ʻԱ��ѵѧԱ�ǼǱ�";
            form.ShowDialog();
        }
        void F3_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F3);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��������ʻ����������֤��";
            form.ShowDialog();
        }

        void F2_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F2);
            form.ShowInTaskbar = false;
            form.Text = "�״�-��������ʻ��ѵ��¼";
            form.ShowDialog();
        }

        void subject1_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀһ");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        void subject20_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀ����׮��");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        void subject21_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀ�������أ�");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        void subject2_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀ��");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }
        void subject3_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("��Ŀ��");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        public override void EmmitToolBar()
        {
            //this.AddTopTool(DS.Plugins.Student.Resource.Student, "ѧԱ����", typeof(StudentSearch));
        }
    }
}
