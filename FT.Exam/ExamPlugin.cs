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
       Email = "cbw123_1984@163,com", MainVersion = "1.0", Name = "���������", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class ExamPlugin : AbstractWindowPlugin
    {


        public override void EmmitMenu()
        {
            ToolStripMenuItem top = this.AddToMenu("����������(&C)");
            ToolStripMenuItem tmp = this.BuildSubMenu("������", typeof(ExamTopicBrowser));
           
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("������", typeof(ExamTopicSearch));
            top.DropDownItems.Add(tmp);
            this.IsEmmitSeparator = false;
            this.AddSeparatorToMenu(top);

            tmp = this.BuildSubMenu("������", typeof(ExamUserBrowser));
            top.DropDownItems.Add(tmp);
            tmp = this.BuildSubMenu("��������", typeof(ExamUserSearch));
            top.DropDownItems.Add(tmp);

            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("���Լ�¼��ѯ", typeof(ExamLogSearch));
            top.DropDownItems.Add(tmp);
            this.AddSeparatorToMenu(top);
            tmp = this.BuildSubMenu("���Բ�������", typeof(ExamPolicySetting));
            top.DropDownItems.Add(tmp);
            /*
            tmp = this.BuildTopMenu("ģ�⿼��");
            tmp.Click += new EventHandler(tmp_Click);
            top.DropDownItems.Add(tmp);*/
        }

        void tmp_Click(object sender, EventArgs e)
        {
            ArrayList topics = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(ExamTopic));
            ExamWorkStation form = new ExamWorkStation(topics,null,false);
            form.ShowDialog();
        }

        public override void EmmitToolBar()
        {
            
        }
    }
}
