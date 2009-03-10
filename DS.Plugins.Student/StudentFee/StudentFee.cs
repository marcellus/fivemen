using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace DS.Plugins.Student
{
    /// <summary>
    /// ѧԱ�ɷ���Ϣ
    /// </summary>
    [SimpleTable("table_student_fee")] 
    [Alias("ѧԱ�ɷ���Ϣ��")]
    public class StudentFee
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

        [SimpleColumn(Column = "c_idcard")]
        [Alias("���֤������")]
        public String IdCard;

        public String ���֤������
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        [SimpleColumn(Column = "date_fee")]
        [Alias("����ʱ��")]
        public string FeeDate;

        public string ����ʱ��
        {
            get { return FeeDate; }
            set { FeeDate = value; }
        }

        [SimpleColumn(Column = "i_fee")]
        [Alias("���ý��")]
        public string Fee;

        public string ���ý��
        {
            get { return Fee; }
            set { Fee = value; }
        }

        [SimpleColumn(Column = "c_feetype")]
        [Alias("�������")]
        public string FeeType;

        public string �������
        {
            get { return FeeType; }
            set { FeeType = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("��ע")]
        public String Description;

        public String ��ע
        {
            get { return Description; }
            set { Description = value; }
        }
    }
}
