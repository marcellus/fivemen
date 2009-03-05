using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.CommonsPlugin.Entity
{
    [SimpleTable("table_users")]
    public class User
    {
        [SimplePK]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
        }
        [SimpleColumn(Column = "c_name")]
        [Alias("��¼��")]
        public String Name;

        /// <summary>
        /// ��datagridview��ʾʹ��
        /// </summary>
        public String ��¼��
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_password")]
        public String Password;

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
    }
}
