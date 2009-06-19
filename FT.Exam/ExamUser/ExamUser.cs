using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Exam
{
    [SimpleTable("table_exam_user")]
    [Alias("������Ϣ")]
    public class ExamUser
    {
        [SimplePK]
        [Alias("���")]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }

        }

        /// <summary>
        /// ���֤������
        /// </summary>
        [SimpleColumn(Column = "c_idcard")]
        [Alias("���֤������")]
        public string IdCard;

        public string ���֤������
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        [SimpleColumn(Column = "c_name")]
        [Alias("����")]
        public string Name;

        public string ����
        {
            get { return Name; }
            set { Name = value; }
        }

        /// <summary>
        /// �����ܴ���
        /// </summary>
        [SimpleColumn(Column = "i_all_count")]
        [Alias("�����ܴ���")]
        public int AllCount;

        public int �����ܴ���
        {
            get { return AllCount; }
            set { AllCount = value; }
        }


        /// <summary>
        /// �ϸ����
        /// </summary>
        [SimpleColumn(Column = "i_pass_count")]
        [Alias("�ϸ����")]
        public int PassCount;

        public int �ϸ����
        {
            get { return PassCount; }
            set { PassCount = value; }
        }

        /// <summary>
        /// ���ϸ����
        /// </summary>
        [SimpleColumn(Column = "i_not_pass_count")]
        [Alias("���ϸ����")]
        public int NotPassCount;

        public int ���ϸ����
        {
            get { return NotPassCount; }
            set { NotPassCount = value; }
        }



    }
}
