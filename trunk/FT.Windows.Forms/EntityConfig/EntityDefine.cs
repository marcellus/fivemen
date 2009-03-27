using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FT.Windows.Forms
{
    [SimpleTable("table_entity_define")]
    [Alias("实体定义")]
    public class EntityDefine
    {
        [SimplePK]
        [Alias("编号")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_class_full_name")]
        [Alias("关联类全称")]
        public string ClassFullName;

        public string 关联类全称
        {
            get { return ClassFullName; }
            set { ClassFullName = value; }
        }

        [SimpleColumn(Column = "c_class_cn_name")]
        [Alias("实体中文名称")]
        public string ClassCnName;

        public string 实体中文名称
        {
            get { return ClassCnName; }
            set { ClassCnName = value; }
        }
    }
}
