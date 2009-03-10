using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.PrinterEx;
using FT.DAL.Orm;

namespace FT.DAL.Entity
{
    /// <summary>
    /// ������Ա��
    /// </summary>
    public abstract class Person
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

        [SimpleColumn(Column = "c_birthday")]
        [Alias("��������")]
        public String Birthday;

        public String ��������
        {
            get { return Birthday; }
            set { Birthday = value; }
        }

        [SimpleColumn(Column = "c_phone")]
        [Alias("�̻�")]
        public String Phone;

        public String �̻�
        {
            get { return Phone; }
            set { Phone = value; }
        }

        [SimpleColumn(Column = "c_mobile")]
        [Alias("�ֻ�")]
        public String Mobile;

        public String �ֻ�
        {
            get { return Mobile; }
            set { Mobile = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("���֤������")]
        public String IdCard;

        public String ���֤������
        {
            get { return IdCard; }
            set { IdCard = value; }
        }

        [SimpleColumn(Column = "c_address")]
        [Alias("סַ")]
        public String Address;

        public String סַ
        {
            get { return Address; }
            set { Address = value; }
        }

        [SimpleColumn(Column = "c_dept")]
        [Alias("��������")]
        public String Dept;

        public String ��������
        {
            get { return Dept; }
            set { Dept = value; }
        }

        [SimpleColumn(Column = "c_employdate")]
        [Alias("��ְʱ��")]
        public String EmployDate;

        public String ��ְʱ��
        {
            get { return EmployDate; }
            set { EmployDate = value; }
        }

        [SimpleColumn(Column = "c_state")]
        [Alias("״̬")]
        public String State;

        public String ״̬
        {
            get { return State; }
            set { State = value; }
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
