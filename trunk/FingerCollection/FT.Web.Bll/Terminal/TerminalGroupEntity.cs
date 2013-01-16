using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Terminal
{
    /// <summary>
    /// 终端分组对象
    /// </summary>
    [SimpleTable("yuantuo_terminal_group")]
    public class TerminalGroupEntity
    {
        [SimplePK]
        public int Id;

        [SimpleColumn(Column = "name")]
        [Alias("分组名称")]
        public string Name;

        [SimpleColumn(Column = "des")]
        [Alias("分组描述")]
        public string Description;

        [SimpleColumn(Column = "adurl")]
        [Alias("分组广告地址")]
        public string AdUrl;

        [SimpleColumn(Column = "adcontent")]
        [Alias("分组促销信息内容")]
        public string AdContent;
        
    }
}
