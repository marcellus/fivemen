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

        [SimpleColumn(Column = "i_dep_type")]
        [Alias("部门类别")]
        public int DepType;

        [SimpleColumn(Column = "c_menu_str")]
        [Alias("菜单字符串")]
        public String MenuStr;

        [SimpleColumn(Column = "c_right_str")]
        [Alias("权限字符串")]
        public String RightStr;


        [SimpleColumn(Column = "c_des1")]
        [Alias("说明1")]
        public String Des1;

        [SimpleColumn(Column = "c_des2")]
        [Alias("说明2")]
        public String Des2;

        [SimpleColumn(Column = "c_des3")]
        [Alias("说明3")]
        public String Des3;
    }
}
