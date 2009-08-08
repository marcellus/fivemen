using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Collections;

namespace DS.Plugins.Student
{
    public partial class QuitForm : BaseSkinForm
    {
        public QuitForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idcard = this.txtIdCard.Text.Trim();
            if (idcard.Length == 15)
            {
                idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
                this.txtIdCard.Text = idcard;
            }
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<StudentInfo>(" where c_idcard='" +
                FT.DAL.DALSecurityTool.TransferInsertField(idcard) + "' order by date_baoming desc");
            if (lists != null && lists.Count > 0)
            {
                StudentInfo info = lists[0] as StudentInfo;
                if(MessageBoxHelper.Confirm("ȷ��Ϊ���֤����Ϊ"+idcard+"\n����"+info.Name+"\n"
                    +"״̬Ϊ"+info.State+"ѧԱ��ѧ��"))
                {
                    StudentHelper.Quit(info);
                }
                

            }
            else
            {
                FT.Commons.Tools.MessageBoxHelper.Show("û���ҵ����֤������Ϊ" + idcard + "��ѧԱ��");
            }
        }
    }
}