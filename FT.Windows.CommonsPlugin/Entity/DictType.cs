using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin.Entity
{
    [SimpleTable("table_dicttype")]
    public class DictType
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(Column = "c_name")]
        [Alias("��������")]
        public string Name;

        public string ��������
        {
            get { return Name; }
            set { Name = value; }
        }
    }
}
