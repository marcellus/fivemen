using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace FT.Plugins.PersonCard
{
    [SimpleTable("table_cards")]
    [Alias("名片表")]
    public class Card
    {
        [SimplePK]
        [Alias("编号")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }
        [SimpleColumn(Column = "c_name")]
        [Alias("姓名")]
        public String Name;

        /// <summary>
        /// 供datagridview显示使用
        /// </summary>
        public String 姓名
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "c_nickname")]
        [Alias("昵称")]
        public String NickName;

        public String 昵称
        {
            get { return NickName; }
            set { NickName = value; }
        }

        [SimpleColumn(Column = "c_sex")]
        [Alias("性别")]
        public String Sex;

        public String 性别
        {
            get { return Sex; }
            set { Sex = value; }
        }

        [SimpleColumn(Column = "c_birthday")]
        [Alias("出生年月")]
        public String Birthday;

        public String 出生年月
        {
            get { return Birthday; }
            set { Birthday = value; }
        }

        [SimpleColumn(Column = "c_phone")]
        [Alias("固话")]
        public String Phone;

        public String 固话
        {
            get { return Phone; }
            set { Phone = value; }
        }

        [SimpleColumn(Column = "c_mobile")]
        [Alias("手机")]
        public String Mobile;

        public String 手机
        {
            get { return Mobile; }
            set { Mobile = value; }
        }

        [SimpleColumn(Column = "c_description")]
        [Alias("备注")]
        public String Description;

        [SimpleColumn(Column = "c_interest")]
        [Alias("兴趣爱好")]
        public String Interest;

        [SimpleColumn(Column = "c_url")]
        [Alias("个人主页")]
        public String Url;
        [SimpleColumn(Column = "c_email")]
        [Alias("联系邮箱")]
        public String Email;

        public String 联系邮箱
        {
            get { return Email; }
        }

        [SimpleColumn(Column = "c_groupid")]
        public String GroupId;

        [SimpleColumn(Column = "c_group")]
        [Alias("分组名称")]
        public String Group;

        public String 分组名称
        {
            get { return Group; }
            set { Group = value; }
        }
    }
}
