using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Student
{
    [SimpleTable("table_student_exam")]
    public class StudentExam
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }
        [SimpleColumn(Column = "c_name")]
        [Alias("����")]
        public String Name;

        /// <summary>
        /// ��datagridview��ʾʹ��
        /// </summary>
        public String ����
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_sex")]
        [Alias("�Ա�")]
        public String Sex;

        public String �Ա�
        {
            get { return Sex; }
            set { Sex = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("���֤��")]
        public String IdCard;

        public String ���֤��
        {
            get { return IdCard; }
            set { IdCard = value; }
        }
    }
}
