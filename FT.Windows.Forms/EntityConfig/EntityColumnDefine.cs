using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FT.Windows.Forms
{
    [SimpleTable("table_entity_column_define")]
    [Alias("实体的列定义")]
    public class EntityColumnDefine
    {
        [SimplePK]
        [Alias("编号")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column="c_property_name")]
        [Alias("属性名称")]
        public string PropertyName;

        public string 属性名称
        {
            get { return PropertyName; }
            set { PropertyName = value; }
        }

        [SimpleColumn(Column = "c_header_name")]
        [Alias("列头名称")]
        public string HeaderName;

        public string 列头名称
        {
            get { return HeaderName; }
            set { HeaderName = value; }
        }

        [SimpleColumn(Column = "i_header_width")]
        [Alias("列头宽度")]
        public int HeaderWidth;

        public int 列头宽度
        {
            get { return HeaderWidth; }
            set { HeaderWidth = value; }
        }

        [SimpleColumn(Column = "bool_isprinted")]
        [Alias("是否打印")]
        public bool IsPrinted;

        public bool 是否打印
        {
            get { return IsPrinted; }
            set { IsPrinted = value; }
        }

        [SimpleColumn(Column = "i_printed_width")]
        [Alias("打印宽度")]
        public int PrintedWidth;

        public int 打印宽度
        {
            get { return PrintedWidth; }
            set { PrintedWidth = value; }
        }

        [SimpleColumn(Column = "bool_isexported")]
        [Alias("是否导出")]
        public bool IsExportExcel;

        public bool 是否导出
        {
            get { return IsExportExcel; }
            set { IsExportExcel = value; }
        }

        [SimpleColumn(Column = "i_export_width")]
        [Alias("导出宽度")]
        public int ExportWidth;

        public int 导出宽度
        {
            get { return ExportWidth; }
            set { ExportWidth = value; }
        }

        [SimpleColumn(Column = "bool_showindetail")]
        [Alias("是否显示")]
        public bool ShowInDetail = false;

        public bool 是否显示
        {
            get { return ShowInDetail; }
            set { ShowInDetail = value; }
        }
        [SimpleColumn(Column = "i_detail_width")]
        [Alias("列表宽度")]
        public int DetailWidth;

        public int 列表宽度
        {
            get { return DetailWidth; }
            set { DetailWidth = value; }
        }

        [SimpleColumn(Column = "c_class_cn_name")]
        [Alias("关联实体名称")]
        public string ClassCnName;

        public string 关联实体名称
        {
            get { return ClassCnName; }
            set { ClassCnName = value; }
        }

        [SimpleColumn(Column = "c_class_full_name")]
        [Alias("关联类全称")]
        public string ClassFullName;

        public string 关联类全称
        {
            get { return ClassFullName; }
            set { ClassFullName = value; }
        }

        [SimpleColumn(Column = "i_order_num")]
        [Alias("排列顺序")]
        public int OrderNum;

        public int 排列顺序
        {
            get { return OrderNum; }
            set { OrderNum = value; }
        }
    }
}
