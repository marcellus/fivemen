using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace FT.Plugins.PersonCard
{
    [SimpleTable("table_cards")]
    public class Card
    {
        [SimplePK]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
        }
        [SimpleColumn(Column = "c_name", Alias = "����")]
        public String Name;

        /// <summary>
        /// ��datagridview��ʾʹ��
        /// </summary>
        public String ����
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_nickname", Alias = "�ǳ�")]
        public String NickName;

        public String �ǳ�
        {
            get { return NickName; }
            set { NickName = value; }
        }

        [SimpleColumn(Column = "c_sex", Alias = "�Ա�")]
        public String Sex;

        [SimpleColumn(Column = "c_birthday", Alias = "��������")]
        public String Birthday;

        [SimpleColumn(Column = "c_phone", Alias = "�̻�")]
        public String Phone;

        [SimpleColumn(Column = "c_mobile",Alias="�ֻ�")]
        public String Mobile;

        [SimpleColumn(Column = "c_description", Alias = "��ע")]
        public String Description;

        [SimpleColumn(Column = "c_interest", Alias = "��Ȥ����")]
        public String Interest;

        [SimpleColumn(Column = "c_url", Alias = "������ҳ")]
        public String Url;
        [SimpleColumn(Column = "c_email", Alias = "��ϵ����")]
        public String Email;
        [SimpleColumn(Column = "c_classical", Alias = "��������")]
        public String Classical;
    }
}
