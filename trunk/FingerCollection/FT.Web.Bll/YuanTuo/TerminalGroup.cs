using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.YuanTuo
{
    [SimpleTable("yuantuo_terminal_group")]
    [Alias("终端分组")]
    [Serializable]
    public class TerminalGroup
    {

        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "name")]
        [Alias("分组名称")]
        public String Name;

        public String 分组名称
        {
            get { return Name; }
            set { Name = value; }
        }

        [SimpleColumn(Column = "adcontent")]
        [Alias("分组促销信息内容")]
        public String AdContent;

        public String 分组促销信息内容
        {
            get { return AdContent; }
            set { AdContent = value; }
        }

        [SimpleColumn(Column = "des")]
        [Alias("分组备注")]
        public String Description;

        public String 分组备注
        {
            get { return Description; }
            set { Description = value; }
        }

        [SimpleColumn(Column = "adurl")]
        [Alias("分组广告地址")]
        public string AdUrl;

    }
}
