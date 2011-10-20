using System;
using System.Collections.Generic;

using System.Text;
using DrvHelperSystemBLL.System.Model;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Rbac.Model
{
    [SimpleTable("table_department_info")]
    [Alias("车管所部门表")]
    public class DepartmentInfo :BaseDepartment
    {
        public DepartmentInfo()
        {
        }
        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_department_info")]
        public int Id;

        

      
        [SimpleColumn(Column = "c_glbm_code")]
        [Alias("管理部门代码")]
        public String GlbmCode;

        [SimpleColumn(Column = "c_fzjg")]
        [Alias("发证机关")]
        public String Fzjg;

    }
}
