using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin
{
    [SimpleTable("table_area")]
    [Alias("������Ϣ��")]
    public class Area
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_code")]
        [Alias("��������")]
        public string Code;

        public string ��������
        {
            get { return Code; }
            set { Code = value; }
        }

        [SimpleColumn(Column = "c_text")]
        [Alias("��������")]
        public string Text;

        public string ��������
        {
            get { return Text; }
            set { Text = value; }
        }

        [SimpleColumn(Column = "c_province_code")]
        [Alias("����ʡ��")]
        public string ProvinceCode;

        public string ����ʡ��
        {
            get { return ProvinceCode; }
            set { ProvinceCode = value; }
        }

        [SimpleColumn(Column = "c_father_code")]
        [Alias("������")]
        public string FatherCode;

        public string ������
        {
            get { return FatherCode; }
            set { FatherCode = value; }
        }

    }
}
