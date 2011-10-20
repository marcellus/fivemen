using System;
using System.Collections.Generic;

using System.Text;
using FT.DAL.Orm;
using DrvHelperSystemBLL.System.Model;

namespace DrvHelperSystemBLL.System.School.Model
{
    [SimpleTable("table_school_info")]
    [Alias("驾校部门表")]
    public class SchoolInfo:BaseSubDepartment
    {
        public SchoolInfo()
        {
        }

        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_school_info")]
        public int Id;

       
    }
}
