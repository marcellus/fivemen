using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin.Entity
{
    [SimpleTable("table_dict")]
    public class Dict
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_text")]
        [Alias("�����ı�")]
        public string Text;

        public string �����ı�
        {
            get { return Text; }
            set { Text = value; }
        }

        [SimpleColumn(Column = "c_value")]
        [Alias("���ݴ���")]
        public string Value;

        public string ���ݴ���
        {
            get { return Value; }
            set { Value = value; }
        }

        [SimpleColumn(Column = "c_valid")]
        [Alias("�Ƿ���Ч")]
        public String Valid;

        public String �Ƿ���Ч
        {
            get { return Valid; }
            set { Valid = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("��ע")]
        public String Description;

        public String ��ע
        {
            get { return Description; }
            set { Description = value; }
        }

        [SimpleColumn(Column = "c_grouptype")]
        [Alias("�������")]
        public string GroupType;

        public string �������
        {
            get { return GroupType; }
            set { GroupType = value; }
        }
    }
}
