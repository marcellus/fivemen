using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Rbac.Model
{
    [SimpleTable("table_right_info")]
    [Alias("菜单表")]
    public class RightInfo
    {
        public RightInfo()
        {
        }

        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_right_info")]
        public int Id;

        [SimpleColumn(Column = "c_text")]
        [Alias("权限文本")]
        public String Text;

        [SimpleColumn(Column = "c_des")]
        [Alias("权限描述")]
        public String Description;

    }
}
