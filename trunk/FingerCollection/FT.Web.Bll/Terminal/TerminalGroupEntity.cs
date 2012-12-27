using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Terminal
{
    /// <summary>
    /// 终端分组对象
    /// </summary>
    [SimpleTable("table_terminal_group")]
    public class TerminalGroupEntity
    {
        [SimplePK]
        public int Id;

        [SimpleColumn(Column = "c_name")]
        [Alias("分组名称")]
        public string Name;

        [SimpleColumn(Column = "c_description")]
        [Alias("分组描述")]
        public string Description;
    }
}
