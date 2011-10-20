using System;
using System.Collections.Generic;

using System.Text;
using FT.DAL.Orm;
using DrvHelperSystemBLL.System.Model;

namespace DrvHelperSystemBLL.System.Rbac.Model
{
    [SimpleTable("table_user_info")]
    [Alias("系统用户表")]
    public class UserInfo : BasePerson
    {


        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_user_info")]
        public int Id;

       

        [SimpleColumn(Column = "i_km")]
        [Alias("默认管理科目")]
        public int Km;
    }
}
