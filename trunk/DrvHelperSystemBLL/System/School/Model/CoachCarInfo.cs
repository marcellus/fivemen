using System;
using System.Collections.Generic;

using System.Text;
using DrvHelperSystemBLL.System.Model;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.School.Model
{

    [SimpleTable("table_coachcar_info")]
    [Alias("教练车表")]
    public class CoachCarInfo
    {

        public CoachCarInfo()
        {
        }


        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_coachcar_info")]
        public int Id;


        [SimpleColumn(Column = "c_hmhp")]
        [Alias("号码号牌")]
        public String Hmhp;

        [SimpleColumn(Column = "c_clpp")]
        [Alias("车辆品牌")]
        public String Clpp;


        [SimpleColumn(Column = "i_school_id")]
        [Alias("驾校部门ID")]
        public int SchoolId;


        [SimpleColumn(Column = "i_coach_id")]
        [Alias("教练员ID")]
        public int CoachId;








    }
}
