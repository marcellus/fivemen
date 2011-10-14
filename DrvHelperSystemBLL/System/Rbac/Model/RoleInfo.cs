using System;
using System.Collections.Generic;

using System.Text;

using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Rbac.Model
{
    [SimpleTable("table_role_info")]
    public class RoleInfo
    {

        public RoleInfo()
        {
        }

        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_role_info")]
        public int Id;


        [SimpleColumn(Column = "c_role_name")]
        public String RoleName;

        [SimpleColumn(Column = "c_description")]
        public String depId;

        [SimpleColumn(Column = "c_description")]
        public String Description;
    }
}
