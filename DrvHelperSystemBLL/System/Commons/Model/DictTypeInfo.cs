using System;
using System.Collections.Generic;

using System.Text;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Commons.Model
{
    [SimpleTable("table_dicttype_info")]
    [Alias("字典类别表")]
    public class DictTypeInfo
    {
        public DictTypeInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_dicttype_info")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_typename")]
        [Alias("类别名")]
        public String TypeName;

        public String 类别名
        {
            get { return TypeName; }
            set { TypeName = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("类别描述")]
        public String Description;

        public String 类别描述
        {
            get { return Description; }
            set { Description = value; }
        }
    }
}
