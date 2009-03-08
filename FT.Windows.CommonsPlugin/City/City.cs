using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin
{
    [SimpleTable("table_city")]
    [Alias("������Ϣ��")]
    public class City
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_code")]
        [Alias("�д���")]
        public string Code;

        public string �д���
        {
            get { return Code; }
            set { Code = value; }
        }

        [SimpleColumn(Column = "c_text")]
        [Alias("������")]
        public string Text;

        public string ������
        {
            get { return Text; }
            set { Text = value; }
        }
        [SimpleColumn(Column = "c_father_code")]
        [Alias("����ʡ��")]
        public string FatherCode;

        public string ����ʡ��
        {
            get { return FatherCode; }
            set { FatherCode = value; }
        }

    }
}
