using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Rbac.Model
{
    [SimpleTable("table_menu_info")]
    [Alias("菜单表")]
    public class MenuInfo

    {
        public MenuInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_menu_info")]
        public int Id;

        [SimpleColumn(Column = "c_text")]
        [Alias("菜单文本")]
        public String Text;

        [SimpleColumn(Column = "c_url")]
        [Alias("菜单URL")]
        public String Url;

        [SimpleColumn(Column = "c_img")]
        [Alias("菜单图片")]
        public String Img;

        [SimpleColumn(Column = "i_order_num")]
        [Alias("菜单排序")]
        public int OrderNum;


        [SimpleColumn(Column = "i_is_parent")]
        [Alias("是否是顶级菜单")]
        public int IsParent;

        [SimpleColumn(Column = "i_parent_id")]
        [Alias("父菜单ID")]
        public int ParentId;

    }
}
