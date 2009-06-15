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
    /// 学员管理的插件
    /// </summary>
    [Plugin(ChangeLogPath = "NewStudentPlugin-ChangeLog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "deadshot123@qq.com", MainVersion = "1.0", Name = "新的学员管理插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class NewStudentPlugin : FT.Windows.Forms.Plugins.AbstractWindowPlugin
    {

        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("驾驶人预录入(&S)");
            ToolStripMenuItem tmp = this.BuildSubMenu("初始报名", typeof(StudentBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("照片采集", typeof(DriverPicCapture));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("学员缴费", typeof(StudentFeeBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("学员修改", typeof(UpdateForm));
            top.DropDownItems.Add(tmp);

            tmp = this.BuildSubMenu("学员列表", typeof(StudentSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            tmp = this.BuildTopMenu("直接打机动车驾驶证申请表");
            tmp.Click += new EventHandler(F7_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-机动车驾驶证申请表");
            tmp.Click += new EventHandler(F6_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-机动车驾驶培训记录");
            tmp.Click += new EventHandler(F2_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-机动车驾驶人身体条件证明");
            tmp.Click += new EventHandler(F3_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-机动车驾驶员培训学员登记表");
            tmp.Click += new EventHandler(F4_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-科目三考试成绩表");
            tmp.Click += new EventHandler(F5_Click);
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            
            tmp = this.BuildTopMenu("科目一成绩录入");
            tmp.Click += new EventHandler(subject1_Click);
            top.DropDownItems.Add(tmp);

            StudentSystemConfig config = StaticCacheManager.GetConfig<StudentSystemConfig>();
            if (config.SubjectIs4)
            {
                tmp = this.BuildTopMenu("科目二（桩）成绩录入");
                tmp.Click += new EventHandler(subject20_Click);
                top.DropDownItems.Add(tmp);

                tmp = this.BuildTopMenu("科目二（场地）成绩录入");
                tmp.Click += new EventHandler(subject21_Click);
                top.DropDownItems.Add(tmp);
            }
            else
            {
                tmp = this.BuildTopMenu("科目二成绩录入");
                tmp.Click += new EventHandler(subject2_Click);
                top.DropDownItems.Add(tmp);
            }
            tmp = this.BuildTopMenu("科目三成绩录入");
            tmp.Click += new EventHandler(subject3_Click);
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("退学", typeof(QuitForm));
            top.DropDownItems.Add(tmp);
            

        }
        void F7_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F7);
            form.ShowInTaskbar = false;
            form.Text = "直接打机动车驾驶证申请表";
            form.ShowDialog();
        }
        void F6_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F6);
            form.ShowInTaskbar = false;
            form.Text = "套打-机动车驾驶证申请表";
            form.ShowDialog();
        }
        void F5_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F5);
            form.ShowInTaskbar = false;
            form.Text = "套打-科目三考试成绩表";
            form.ShowDialog();
        }
        void F4_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F4);
            form.ShowInTaskbar = false;
            form.Text = "套打-机动车驾驶员培训学员登记表";
            form.ShowDialog();
        }
        void F3_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F3);
            form.ShowInTaskbar = false;
            form.Text = "套打-机动车驾驶人身体条件证明";
            form.ShowDialog();
        }

        void F2_Click(object sender, EventArgs e)
        {
            Form form = new OtherPrinterForm(Keys.F2);
            form.ShowInTaskbar = false;
            form.Text = "套打-机动车驾驶培训记录";
            form.ShowDialog();
        }

        void subject1_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("科目一");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        void subject20_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("科目二（桩）");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        void subject21_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("科目二（场地）");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        void subject2_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("科目二");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }
        void subject3_Click(object sender, EventArgs e)
        {
            Form form = new StudentExamBrowser("科目三");
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        public override void EmmitToolBar()
        {
            //this.AddTopTool(DS.Plugins.Student.Resource.Student, "学员管理", typeof(StudentSearch));
        }
    }
}
