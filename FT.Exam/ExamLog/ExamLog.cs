using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Exam
{
    [SimpleTable("table_exam_log")]
    [Alias("ģ�⿼�Լ�¼")]
    public class ExamLog
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
        /// ����ʱ��
        /// </summary>
        [SimpleColumn(Column = "c_exam_date")]
        [Alias("����ʱ��")]
        public string ExamDate;

        public string ����ʱ��
        {
            get { return ExamDate; }
            set { ExamDate = value; }
        }


        /// <summary>
        /// ���Գɼ�
        /// </summary>
        [SimpleColumn(Column = "i_score")]
        [Alias("���Գɼ�")]
        public int Score;

        public int ���Գɼ�
        {
            get { return Score; }
            set { Score = value; }
        }

        



    }
}
