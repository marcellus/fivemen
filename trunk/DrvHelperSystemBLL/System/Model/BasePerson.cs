using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Model
{
    public abstract class BasePerson:BaseModel
    {
        public BasePerson()
        {
        }

        [SimpleColumn(Column = "c_mobile")]
        [Alias("联系电话")]
        public String Mobile;

        [SimpleColumn(Column = "c_phone")]
        [Alias("固定电话")]
        public String Phone;


        [SimpleColumn(Column = "c_address")]
        [Alias("联系地址")]
        public String Address;


        [SimpleColumn(Column = "c_login_name")]
        [Alias("登陆名")]
        public String UserLoginName;

        [SimpleColumn(Column = "c_full_name")]
        [Alias("用户全名")]
        public String FullName;

        [SimpleColumn(Column = "c_pwd", AllowUpdate = false)]
        [Alias("密码")]
        public String Password;

        [SimpleColumn(Column = "i_roleid")]
        [Alias("角色ID")]
        public int RoleId;


        [SimpleColumn(Column = "c_mac")]
        [Alias("MAC地址")]
        public string  Mac;


        [SimpleColumn(Column = "I_IS_MAC")]
        [Alias("是否执行MAC地址绑定")]
        public int  IsMac;


        

        [SimpleColumn(Column = "c_idcard")]
        [Alias("身份证明号码")]
        public String IdCard;

        [SimpleColumn(Column = "c_workid")]
        [Alias("工号")]
        public String WorkId;

        [SimpleColumn(Column = "c_beginip")]
        [Alias("IP起始地址")]
        public String BeginIp;

        [SimpleColumn(Column = "c_endip")]
        [Alias("IP结束地址")]
        public String EndIp;

        [SimpleColumn(Column = "i_state")]
        [Alias("状态")]
        public int State;
    }
}
