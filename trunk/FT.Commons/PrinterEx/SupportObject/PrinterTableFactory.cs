using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FT.Commons.PrinterEx.SupportObject
{
    /// <summary>
    /// 打印内容构造器
    /// </summary>
    public sealed class PrinterTableFactory
    {
        public const int Default_Row_Height = 22;

        public static PrinterTable Build(DataTable dt, int[] columnWidth)
        {
            return Build(dt, Default_Row_Height, columnWidth);
        }

        public static PrinterTable Build(DataTable dt, int rowHeight,int[] columnWidth)
        {
            int len = columnWidth.Length;
            PrinterTable table = new PrinterTable();
            PrinterRow row=new PrinterRow();
            row.Rectangle = new System.Drawing.Rectangle(0, 0, PrinterContent.PageMargin.Width, rowHeight);
            TextDraw text=null;
            int tmp = 0;
            for(int i=0;i<len;i++)
            {
                text = new ColumnHeaderDraw(dt.Columns[i].ColumnName);
                text.Border = BordersEdgeStyle.All;
                text.Rectangle=new System.Drawing.Rectangle(tmp,0,columnWidth[i],rowHeight);
                tmp += columnWidth[i];
                row.Add(text);
            }
            table.Header = row;
            //table.Add(row);
            row = null;
            tmp = 0;
            foreach (DataRow dr in dt.Rows)
            {
                row = new PrinterRow();
                row.Rectangle = new System.Drawing.Rectangle(0, 0, PrinterContent.PageMargin.Width, rowHeight);
                for (int i = 0; i < len; i++)
                {
                    text = new TextDraw(Convert.IsDBNull(dr[i])?string.Empty:dr[i].ToString());
                    text.Border = BordersEdgeStyle.All;
                    text.Rectangle = new System.Drawing.Rectangle(tmp, 0, columnWidth[i], rowHeight);
                    tmp += columnWidth[i];
                    row.Add(text);
                }
                tmp = 0;
                table.Add(row);
            }
            return table;
        }
    }
}
