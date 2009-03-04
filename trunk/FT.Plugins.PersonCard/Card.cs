using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace FT.Plugins.PersonCard
{
    [SimpleTable("table_cards")]
    public class Card
    {
        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }
        [SimpleColumn(Column = "c_name", Alias = "姓名")]
        public String Name;

        /// <summary>
        /// 供datagridview显示使用
        /// </summary>
        public String 姓名
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_nickname", Alias = "昵称")]
        public String NickName;

        public String 昵称
        {
            get { return NickName; }
            set { NickName = value; }
        }

        [SimpleColumn(Column = "c_sex", Alias = "性别")]
        public String Sex;

        [SimpleColumn(Column = "c_birthday", Alias = "出生年月")]
        public String Birthday;

        [SimpleColumn(Column = "c_phone", Alias = "固话")]
        public String Phone;

        [SimpleColumn(Column = "c_mobile",Alias="手机")]
        public String Mobile;

        [SimpleColumn(Column = "c_description", Alias = "备注")]
        public String Description;

        [SimpleColumn(Column = "c_interest", Alias = "兴趣爱好")]
        public String Interest;

        [SimpleColumn(Column = "c_url", Alias = "个人主页")]
        public String Url;
        [SimpleColumn(Column = "c_email", Alias = "联系邮箱")]
        public String Email;
        [SimpleColumn(Column = "c_classical", Alias = "分组名称")]
        public String Classical;
    }
}
