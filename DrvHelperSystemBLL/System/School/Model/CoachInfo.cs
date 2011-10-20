using System;
using System.Collections.Generic;

using System.Text;
using DrvHelperSystemBLL.System.Model;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.School.Model
{

    [SimpleTable("table_coach_info")]
    [Alias("教练信息表")]
    public class CoachInfo
    {



        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_coach_info")]
        public int Id;

        [SimpleColumn(Column = "c_coach_no")]
        [Alias("教练证号")]
        public String CoachNo;



        [SimpleColumn(Column = "i_school_id")]
        [Alias("驾校部门ID")]
        public int SchoolId;



        [SimpleColumn(Column = "c_idcard")]
        [Alias("教练身份证号码")]
        public String IdCard;


        [SimpleColumn(Column = "c_mobile")]
        [Alias("教练联系电话")]
        public String Mobile;

        [SimpleColumn(Column = "c_name")]
        [Alias("教练姓名")]
        public String Name;


        [SimpleColumn(Column = "c_phone")]
        [Alias("固定电话")]
        public String Phone;


        [SimpleColumn(Column = "c_address")]
        [Alias("联系地址")]
        public String Address;
    }
}
