using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Model
{
    public abstract class BaseDepartment
    {

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


        [SimpleColumn(Column = "c_connector")]
        [Alias("联系人")]
        public String Connector;

    }
}
