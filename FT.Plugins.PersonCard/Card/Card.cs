using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace FT.Plugins.PersonCard
{
    [SimpleTable("table_cards")]
    [Alias("��Ƭ��")]
    public class Card
    {
        [SimplePK]
        [Alias("���")]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
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

        [SimpleColumn(Column = "c_nickname")]
        [Alias("�ǳ�")]
        public String NickName;

        public String �ǳ�
        {
            get { return NickName; }
            set { NickName = value; }
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

        [SimpleColumn(Column = "c_description")]
        [Alias("��ע")]
        public String Description;

        [SimpleColumn(Column = "c_interest")]
        [Alias("��Ȥ����")]
        public String Interest;

        [SimpleColumn(Column = "c_url")]
        [Alias("������ҳ")]
        public String Url;
        [SimpleColumn(Column = "c_email")]
        [Alias("��ϵ����")]
        public String Email;

        public String ��ϵ����
        {
            get { return Email; }
        }

        [SimpleColumn(Column = "c_groupid")]
        public String GroupId;

        [SimpleColumn(Column = "c_group")]
        [Alias("��������")]
        public String Group;

        public String ��������
        {
            get { return Group; }
            set { Group = value; }
        }
    }
}
