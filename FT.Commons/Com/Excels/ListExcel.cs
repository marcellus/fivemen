/********************************************************************************
* File:Listcs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Web;

using Microsoft.Office.Interop.Excel;

namespace FT.Commons.Com.Excels
{
    public class ListExcel : SimpleExcel
    {
        private System.Data.DataTable dt;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListExcel"/> class.
        /// </summary>
        /// <param name="begin">The begin.</param>
        /// <param name="end">The end.</param>
        /// <param name="filename">The filename.</param>
        /// deadshot123 modify at 2007-4-10 13:55
        public ListExcel(string filename,System.Data.DataTable dt)
            : base(filename)
        {
            this.Title = "默认程序导出标题";
            this.HeaderHeight = 40;
            this.ColLength = dt.Columns.Count;
            this.dt = dt;
            this.Bottom = "Create at {0} by FmSystem.";

        }
        
        /// <summary>
        /// Draws the data row.
        /// </summary>
        /// <param name="rowindex">The rowindex.</param>
        /// <param name="dr">The dr.</param>
        /// deadshot123 modify at 2007-4-10 13:55
        private void DrawDataRow(int rowindex, DataRow dr)
        {
            //System.Diagnostics.Debug.WriteLine("rowindex:" + rowindex.ToString());
            //if (rowindex == 1000)
            //{
            //    System.Diagnostics.Debug.WriteLine("10000");
            //}
            for (int i = 1; i <= this.ColLength; i++)
            {
                Range rang = this.GetRange(rowindex, i);
                string temp = dr[i - 1].ToString();
                if (temp.StartsWith("=") || temp.StartsWith("0"))
                {
                    temp = "'" + temp;
                }
                else
                {
                    temp = "'" + temp;
                }
                
                this.SetRangeText(rang, temp);
            }
        }

        /// <summary>
        /// 画Excel的内容
        /// </summary>
        /// deadshot123 modify at 2007-4-10 13:55
        protected override void DrawContent()
        {
            System.Data.DataTable dt = this.dt;
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.CurrentRowIndex++;
                    this.DrawDataRow(this.CurrentRowIndex, dr);
                }
            }
            //base.DrawContent();
        }
        /// <summary>
        /// 画excel的底部
        /// </summary>
        /// deadshot123 modify at 2007-4-10 13:55
        protected override void DrawFooter()
        {
            //设置整个excel体的格式
            Range body = this.GetRange(3, 1, this.CurrentRowIndex, this.ColLength);
            this.SetFont(body, BodyFont);
            this.SetRangAlign(body, ExcelAlign.Center);
            this.SetRangBorderDefault(body);
            this.CurrentRowIndex++;
            base.DrawFooter();
        }

        /// <summary>
        /// 画Excel的头部
        /// </summary>
        /// deadshot123 modify at 2007-4-10 13:55
        protected override void DrawHeader()
        {
            base.DrawHeader();
            //Range rang = this.GetRange(3, 1, 3, 5);
            //this.MergeCells(rang);
            //this.SetRangBorderDefault(rang);
            //this.SetFont(rang, SimpleSecondTitle);
            //this.SetRangAlign(rang, ExcelAlign.Left);

            for (int i = 1; i <= this.ColLength; i++)
            {
                Range rangTemp = this.GetRange(2, i);
                this.SetRangeText(rangTemp, this.dt.Columns[i - 1].ColumnName);

                this.SetColumnWidth(i, 12);

            }

            //默认头格式
            Range rangHeader = this.GetRange(2, 1, 2, this.ColLength);
            this.SetFont(rangHeader, ThirdTitle);
            this.SetRangBorderDefault(rangHeader);
            this.SetRangAlign(rangHeader, ExcelAlign.Center);
            this.SetRangBackColor(rangHeader, 40);
            this.CurrentRowIndex = 2;
             

        }
    }
}
