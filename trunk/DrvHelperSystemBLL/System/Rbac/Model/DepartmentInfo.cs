using System;
using System.Collections.Generic;

using System.Text;
using DrvHelperSystemBLL.System.Model;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Rbac.Model
{
    [SimpleTable("table_department_info")]
    [Alias("车管所部门表")]
    public class DepartmentInfo : BaseModel
    {
        public DepartmentInfo()
        {
        }
        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_department_info")]
        public int Id;

        [SimpleColumn(Column = "c_mobile")]
        [Alias("联系电话")]
        public String Mobile;

        [SimpleColumn(Column = "c_phone")]
        [Alias("固定电话")]
        public String Phone;


        [SimpleColumn(Column = "c_address")]
        [Alias("联系地址")]
        public String Address;

        [SimpleColumn(Column = "c_companycode")]
        [Alias("机构证书代码")]
        public String CompanyCode;

        [SimpleColumn(Column = "c_depfullname")]
        [Alias("部门全名")]
        public String DepFullName;

        [SimpleColumn(Column = "c_depnickname")]
        [Alias("部门简称")]
        public String DepNickName;

        [SimpleColumn(Column = "c_depcode")]
        [Alias("部门代码")]
        public String DepCode;

      
        [SimpleColumn(Column = "c_glbm_code")]
        [Alias("管理部门代码")]
        public String GlbmCode;

        [SimpleColumn(Column = "c_fzjg")]
        [Alias("发证机关")]
        public String Fzjg;

    }
}
