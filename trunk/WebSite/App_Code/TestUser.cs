using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FT.DAL.Orm;


    [SimpleTable("table_users")]
    [Alias("系统用户表")]
    public class TestUser
    {
        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }
        [SimpleColumn(Column = "c_name")]
        [Alias("登录名")]
        public String Name;

        /// <summary>
        /// 供datagridview显示使用
        /// </summary>
        public String 登录名
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_password")]
        public String Password;

        [SimpleColumn(Column = "c_valid")]
        [Alias("是否有效")]
        public String Valid;

        public String 是否有效
        {
            get { return Valid; }
            set { Valid = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("备注")]
        public String Description;

        public String 备注
        {
            get { return Description; }
            set { Description = value; }
        }
    }

