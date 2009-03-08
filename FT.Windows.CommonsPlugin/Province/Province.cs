using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin
{
    [SimpleTable("table_province")]
    [Alias("ʡ����Ϣ��")]
    public class Province
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_code")]
        [Alias("ʡ�ݴ���")]
        public string Code;

        public string ʡ�ݴ���
        {
            get { return Code; }
            set { Code = value; }
        }

        [SimpleColumn(Column = "c_text")]
        [Alias("ʡ������")]
        public string Text;

        public string ʡ������
        {
            get { return Text; }
            set { Text = value; }
        }
    }
}
