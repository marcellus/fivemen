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
            tmp.Click += new EventHandler(StudentHelper.F7_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-机动车驾驶证申请表");
            tmp.Click += new EventHandler(StudentHelper.F6_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-机动车驾驶培训记录");
            tmp.Click += new EventHandler(StudentHelper.F2_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-机动车驾驶人身体条件证明");
            tmp.Click += new EventHandler(StudentHelper.F3_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-机动车驾驶员培训学员登记表");
            tmp.Click += new EventHandler(StudentHelper.F4_Click);
            top.DropDownItems.Add(tmp);
            tmp = this.BuildTopMenu("套打-科目三考试成绩表");
            tmp.Click += new EventHandler(StudentHelper.F5_Click);
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);

            
            tmp = this.BuildTopMenu("科目一成绩录入");
            tmp.Click += new EventHandler(StudentHelper.subject1_Click);
            top.DropDownItems.Add(tmp);

            StudentSystemConfig config = StaticCacheManager.GetConfig<StudentSystemConfig>();
            if (config.SubjectIs4)
            {
                tmp = this.BuildTopMenu("科目二（桩）成绩录入");
                tmp.Click += new EventHandler(StudentHelper.subject20_Click);
                top.DropDownItems.Add(tmp);

                tmp = this.BuildTopMenu("科目二（场地）成绩录入");
                tmp.Click += new EventHandler(StudentHelper.subject21_Click);
                top.DropDownItems.Add(tmp);
            }
            else
            {
                tmp = this.BuildTopMenu("科目二成绩录入");
                tmp.Click += new EventHandler(StudentHelper.subject2_Click);
                top.DropDownItems.Add(tmp);
            }
            tmp = this.BuildTopMenu("科目三成绩录入");
            tmp.Click += new EventHandler(StudentHelper.subject3_Click);
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("退学", typeof(QuitForm));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("操作快捷界面", typeof(InitButtonPanel));
            top.DropDownItems.Add(tmp);
            

        }
        

        public override void EmmitToolBar()
        {
            //this.AddTopTool(DS.Plugins.Student.Resource.Student, "学员管理", typeof(StudentSearch));
        }
    }
}
