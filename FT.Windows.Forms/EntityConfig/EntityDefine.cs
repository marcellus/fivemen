using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FT.Windows.Forms
{
    [SimpleTable("table_entity_define")]
    [Alias("ʵ�嶨��")]
    public class EntityDefine
    {
        [SimplePK]
        [Alias("���")]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_class_full_name")]
        [Alias("������ȫ��")]
        public string ClassFullName;

        public string ������ȫ��
        {
            get { return ClassFullName; }
            set { ClassFullName = value; }
        }

        [SimpleColumn(Column = "c_class_cn_name")]
        [Alias("ʵ����������")]
        public string ClassCnName;

        public string ʵ����������
        {
            get { return ClassCnName; }
            set { ClassCnName = value; }
        }
    }
}
