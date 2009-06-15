using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using FT.Commons.WebCatcher;
using FT.DAL;
using System.Windows.Forms;
using System.Collections;

namespace FT.Exam
{
    [Plugin(ChangeLogPath = "changlog.txt", Company = "Fight Together", Developer = "deadshot123",
       Email = "cbw123_1984@163,com", MainVersion = "1.0", Name = "考试题库插件", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ExamPlugin : AbstractWindowPlugin
    {


        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("考试题库管理(&C)");
            ToolStripMenuItem tmp = this.BuildSubMenu("添加题库", typeof(ExamTopicBrowser));
           
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("题库管理", typeof(ExamTopicSearch));
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = false;

            tmp = this.BuildTopMenu("模拟考试");
            tmp.Click += new EventHandler(tmp_Click);
            top.DropDownItems.Add(tmp);
        }

        void tmp_Click(object sender, EventArgs e)
        {
            ArrayList topics = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(ExamTopic));
            ExamWorkStation form = new ExamWorkStation(topics);
            form.ShowDialog();
        }

        public override void EmmitToolBar()
        {
            
        }
    }
}
