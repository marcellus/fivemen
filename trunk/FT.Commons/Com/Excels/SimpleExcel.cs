
/********************************************************************************
* File:Simplecs
* Author:austin chen
* Date:2008-4-21
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Drawing;



namespace FT.Commons.Com.Excels
{
    public enum ExcelAlign
    {
        Right,
        Left,
        Center
    }
    public class SimpleExcel
    {
        public static System.Drawing.Font ThirdTitle = new System.Drawing.Font("宋体", 9, FontStyle.Bold);
        public static System.Drawing.Font SecondTitle = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
        public static System.Drawing.Font FirstTitle = new System.Drawing.Font("黑体", 20);
        public static System.Drawing.Font BodyFont = new System.Drawing.Font("宋体", 9);
        private const string bottom = "该报表由程序自动生成。";
        private string fileName;
        
        protected Application m_objExcel = null;
        protected Workbooks m_objBooks = null;
        protected _Workbook m_objBook = null;

        protected object m_objOpt = System.Reflection.Missing.Value;

        private int m_headheight = 20;
        private int m_bottomheight = 20;
        /// <summary>
        /// Gets or sets the height of the header.
        /// </summary>
        /// <value>The height of the header.</value>
        /// deadshot123 modify at 2007-4-10 13:44
        public int HeaderHeight
        {
            get
            {
                return this.m_headheight;
            }
            set
            {
                this.m_headheight = value;
            }
        }
        /// <summary>
        /// Gets or sets the height of the bottom.
        /// </summary>
        /// <value>The height of the bottom.</value>
        /// deadshot123 modify at 2007-4-10 13:44
        protected int BottomHeight
        {
            get
            {
                return this.m_bottomheight;
            }
            set
            {
                this.m_bottomheight = value;
            }
        }

        protected string m_bottom = bottom;
        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        /// <value>The bottom.</value>
        /// deadshot123 modify at 2007-4-10 13:44
        protected string Bottom
        {
            get
            {
                return this.m_bottom;
            }
            set
            {
                this.m_bottom = value;
            }
        }

        protected string m_title = string.Empty;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        /// deadshot123 modify at 2007-4-10 13:44
        public string Title
        {
            get
            {
                return this.m_title;
            }
            set
            {
                this.m_title = value;
            }
        }

        protected int m_colLength = 1;
        /// <summary>
        /// Gets or sets the length of the col.
        /// </summary>
        /// <value>The length of the col.</value>
        /// deadshot123 modify at 2007-4-10 13:44
        protected int ColLength
        {
            get
            {
                return this.m_colLength;
            }
            set
            {
                this.m_colLength = value;
            }
        }

        protected int m_currentRowIndex = 1;
        /// <summary>
        /// Gets or sets the index of the current row.
        /// </summary>
        /// <value>The index of the current row.</value>
        /// deadshot123 modify at 2007-4-10 13:44
        protected int CurrentRowIndex
        {
            get
            {
                return this.m_currentRowIndex;
            }
            set
            {
                this.m_currentRowIndex = value;
            }
        }

        /// <summary>
        /// excel操作抽象类
        /// </summary>
        /// <param name="filename">保存的文件名</param>
        public SimpleExcel(string filename)
        {
            this.fileName = filename;
        }

        /// <summary>
        /// 添加一个工作表
        /// </summary>
        /// <param name="name">工作表名字</param>
        protected void AddSheet(string name)
        {
            if (m_objBook != null)
            {
                // m_objBook.Sheets.Add(
                m_objBook.Sheets.Add(m_objOpt, m_objOpt, 1, m_objOpt);
                this.RenameSheet(m_objBook.Sheets.Count - 1, name);
            }
        }
        /// <summary>
        /// 根据名字获取一个工作表
        /// </summary>
        /// <param name="name">工作表名</param>
        protected Worksheet GetSheet(string name)
        {
            foreach (Worksheet sheet in m_objBook.Sheets)
            {
                if (sheet.Name == name)
                {
                    return sheet;
                }
            }
            return null;
        }
        /// <summary>
        /// 根据索引获取工作表
        /// </summary>
        /// <param name="index">工作表索引</param>
        protected Worksheet GetSheet(int index)
        {
            if (m_objBook != null && index < m_objBook.Sheets.Count)
            {
                return (Worksheet)m_objBook.Sheets.get_Item(index);
            }
            return null;
        }
        /// <summary>
        /// 根据索引为工作表重命名
        /// </summary>
        /// <param name="index">工作表索引</param>
        /// <param name="newname">新工作表名</param>
        protected void RenameSheet(int index, string newname)
        {
            Worksheet sheet = this.GetSheet(index);
            if (sheet != null)
            {
                this.RenameSheet(sheet, newname);
            }
        }
        /// <summary>
        /// 为工作表更改名字
        /// </summary>
        /// <param name="sheet">工作表</param>
        /// <param name="newname">新名字</param>
        protected void RenameSheet(Worksheet sheet, string newname)
        {
            if (sheet != null && !string.IsNullOrEmpty(newname))
                sheet.Name = newname;
        }

        /// <summary>
        /// 根据旧名字修改工作表名字
        /// </summary>
        /// <param name="oldname">旧名字</param>
        /// <param name="newname">新名字</param>
        protected void RenameSheet(string oldname, string newname)
        {
            Worksheet sheet = this.GetSheet(oldname);
            if (sheet != null)
            {
                this.RenameSheet(sheet, newname);
            }
        }
        /// <summary>
        /// 获取列对应的字符，比如27列是AA，28列是AB
        /// 53为BA
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        protected string ConvertCol2Char(int col)
        {
            if (col > 26)
            {
                int count = col / 26 + 64;
                int s = col % 26 + 64;
                return ((char)count).ToString() + ((char)s).ToString();
            }
            else
            {
                return ((char)(col + 64)).ToString();
            }
        }

        /// <summary>
        /// 排列单元格文本
        /// </summary>
        /// <param name="rang">单元格</param>
        /// <param name="al">排列方式</param>
        protected void SetRangAlign(Range rang, ExcelAlign al)
        {
            switch (al)
            {
                case ExcelAlign.Center:
                    rang.HorizontalAlignment = Constants.xlCenter;
                    break;
                case ExcelAlign.Left:
                    rang.HorizontalAlignment = Constants.xlLeft;
                    break;
                case ExcelAlign.Right:
                    rang.HorizontalAlignment = Constants.xlRight;
                    break;
                default:
                    rang.HorizontalAlignment = Constants.xlCenter;
                    break;

            }
        }
        /// <summary>
        /// 根据工作表名删除一个工作表
        /// </summary>
        /// <param name="name">工作表名字</param>
        protected void DeleteSheet(string name)
        {
            Worksheet sheet = this.GetSheet(name);
            if (sheet != null)
            {
                sheet.Delete();
            }
        }
        /// <summary>
        /// 根据索引删除一个工作表
        /// </summary>
        /// <param name="index">索引</param>
        protected void DeleteSheet(int index)
        {
            Worksheet sheet = this.GetSheet(index);
            if (sheet != null)
            {
                sheet.Delete();
            }
        }
        /// <summary>
        /// 打开excel
        /// </summary>
        protected void Create()
        {
            m_objExcel = new Application();
            m_objBooks = (Workbooks)m_objExcel.Workbooks;
            m_objBook = (_Workbook)(m_objBooks.Add(m_objOpt));

        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// deadshot123 modify at 2007-4-10 13:44
        protected void Save()
        {
            this.SaveAs(this.fileName);
        }
        /// <summary>
        /// 保存工作簿到相应的路径
        /// </summary>
        /// <param name="path">绝对路径</param>
        protected void SaveAs(string path)
        {
            if (m_objBook != null)
            {
                m_objBook.SaveAs(path, m_objOpt, m_objOpt, m_objOpt
                    , m_objOpt, m_objOpt, XlSaveAsAccessMode.xlNoChange, m_objOpt
                    , m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                m_objBook.Close(true, m_objOpt, m_objOpt);
                if (m_objBooks != null)
                {
                    m_objBooks.Close();
                }
                if (m_objExcel != null)
                {
                    m_objExcel.Quit();
                }
            }
        }
        /// <summary>
        /// 关闭excel
        /// </summary>
        public void Close()
        {
            #region 释放Excel资源

            //foreach (_Worksheet sheet in m_objBook.Sheets)
            //{
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
            //}
            if (m_objBooks != null && m_objExcel != null)
            {
                foreach (_Workbook book in m_objBooks)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBooks);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
            }
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheets);
            // System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objSheet);
            // System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objRange);
            // System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objFont);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBorders);


            m_objExcel = null;
            m_objBooks = null;
            m_objBook = null;
            GC.Collect();



            #endregion

        }
        #region 子类必须实现的
        /// <summary>
        /// 画Excel的头部
        /// </summary>
        protected virtual void DrawHeader()
        {
            Range rang = this.GetRange(1, 1, 1, this.ColLength);
            this.MergeCells(rang);
            this.SetRowHeight(1, this.HeaderHeight);
            this.SetRangBorderDefault(rang);
            this.SetRangBackColor(rang, 7);
            this.SetFont(rang, FirstTitle, 1);
            this.SetRangeText(rang, this.Title);

            this.CurrentRowIndex++;
        }
        /// <summary>
        /// 画Excel的内容
        /// </summary>
        protected virtual void DrawContent()
        {
        }
        /// <summary>
        /// 画excel的底部
        /// </summary>
        protected virtual void DrawFooter()
        {
            Range rang = this.GetRange(this.CurrentRowIndex, 1, this.CurrentRowIndex, this.ColLength);
            this.SetRangBorderDefault(rang);
            this.SetRowHeight(this.CurrentRowIndex, this.BottomHeight);
            this.SetFont(rang, BodyFont);
            this.SetRangBackColor(rang, 15);
            this.MergeCells(rang);
            rang.HorizontalAlignment = Constants.xlRight;
            this.SetRangeText(rang, string.Format(this.Bottom, System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
        }

        #endregion
        /// <summary>
        /// 获取文件绝对路径
        /// </summary>
        /// <returns>文件路径</returns>
        public string GetExcelReport()
        {
            if (File.Exists(this.fileName))
            {

            }
            else
            {
                // System.Globalization.CultureInfo org = System.Threading.Thread.CurrentThread.CurrentCulture;
                //  System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                this.Create();
                this.DrawHeader();
                this.DrawContent();
                this.DrawFooter();
                this.Save();
                this.Close();
                //  System.Threading.Thread.CurrentThread.CurrentCulture = org;
            }
            return this.fileName;
        }
        #region 设置单元格的边框为1
        /// <summary>
        /// 设置单元格的边框为1
        /// </summary>
        /// <param name="rang">单元格</param>
        protected void SetRangBorderDefault(Range rang)
        {
            if (rang != null)
            {
                rang.Cells.Borders.LineStyle = 1;
            }
        }
        #endregion
        #region 设置单元格的背景色
        /// <summary>
        /// 设置单元格的背景色
        /// </summary>
        /// <param name="rang">单元格</param>
        /// <param name="color">背景色</param>
        protected void SetRangBackColor(Range rang, System.Drawing.Color color)
        {
            if (rang != null)
            {
                //错误
                rang.Interior.Color = color;
                // rang.Interior.ColorIndex = index;
            }
        }
        /// <summary>
        /// 设置单元格的背景色
        /// </summary>
        /// <param name="rang">单元格</param>
        /// <param name="color">背景色索引</param>
        protected void SetRangBackColor(Range rang, int index)
        {
            if (rang != null)
            {
                rang.Interior.ColorIndex = index;
            }
        }
        #endregion
        #region MergeCells(Range p_Range)合并单元格，合并后，默认居中
        /// <summary>
        /// 合并指定范围内单元格，合并后，默认居中
        /// </summary>
        /// <param name="p_Range"></param>
        protected void MergeCells(Range p_Range)
        {
            p_Range.HorizontalAlignment = Constants.xlCenter;
            p_Range.VerticalAlignment = Constants.xlCenter;
            p_Range.WrapText = false;
            p_Range.Orientation = 0;
            p_Range.AddIndent = false;
            p_Range.IndentLevel = 0;
            p_Range.ShrinkToFit = false;
            //p_Range.ReadingOrder = Constants.xlContext;
            p_Range.MergeCells = false;
            p_Range.Merge(m_objOpt);

            //    With Selection
            //        .HorizontalAlignment = xlCenter
            //        .VerticalAlignment = xlCenter
            //        .WrapText = False
            //        .Orientation = 0
            //        .AddIndent = False
            //        .IndentLevel = 0
            //        .ShrinkToFit = False
            //        .ReadingOrder = xlContext
            //        .MergeCells = False
            //    End With
            //    Selection.Merge
        }
        #endregion
        #region 插入整行、整列InsertRow(int p_rowIndex)、InsertColumn(int p_colIndex)、InsertColumn(string p_colChars)
        /// <summary>
        /// 在指定的行上插入一整行
        /// </summary>
        /// <param name="p_rowIndex">行索引</param>
        protected void InsertRow(int p_rowIndex)
        {
            //    Rows("2:2").Select
            //    Selection.Insert Shift:=xlDown

            Range range;

            range = GetRange(p_rowIndex, "A");
            range.Select();

            //Excel2003支持两参数
            range.EntireRow.Insert(m_objOpt, m_objOpt);

            //Excel2000支持一个参数，经过测试，用Interop.ExcelV1.3(Excel2000)，可以正常运行在Excel2003中
            // range.EntireRow.Insert(m_objOpt);
        }

        /// <summary>
        /// 用模板行在指定的行上插入，即Excel的插入复制单元格
        /// </summary>
        /// <param name="p_rowIndex"></param>
        /// <param name="p_templateRowIndex"></param>
        protected void InsertRow(int p_rowIndex, int p_templateRowIndex)
        {
            Range range;
            range = (Range)m_objExcel.Rows[p_templateRowIndex.ToString() + ":" + p_templateRowIndex.ToString(), m_objOpt];
            range.Select();
            range.Copy(m_objOpt);

            InsertRow(p_rowIndex);
        }

        /// <summary>
        /// 在指定的列上插入一整列
        /// </summary>
        /// <param name="p_colIndex">列索引</param>
        protected void InsertColumn(int p_colIndex)
        {
            Range range;

            range = GetRange(1, p_colIndex);
            range.Select();

            //Excel2003支持两参数
            range.EntireRow.Insert(m_objOpt, m_objOpt);
            //Excel2000支持一个参数
            //range.EntireColumn.Insert(m_objOpt);
        }

        /// <summary>
        /// 在指定的列上插入一整列
        /// </summary>
        /// <param name="p_colChars">列字母或组合</param>
        protected void InsertColumn(string p_colChars)
        {
            Range range;

            range = GetRange(1, p_colChars);
            range.Select();
            //Excel2003支持两参数
            range.EntireRow.Insert(m_objOpt, m_objOpt);
            //Excel2000支持一个参数
            //range.EntireColumn.Insert(m_objOpt);
        }
        #endregion
        #region 删除整行、整列DeleteRow(int p_rowIndex)、DeleteColumn(int p_colIndex)、DeleteColumn(string p_colChars)
        /// <summary>
        /// 删除指定的整行
        /// </summary>
        /// <param name="p_rowIndex">行索引</param>
        protected void DeleteRow(int p_rowIndex)
        {
            Range range;

            range = GetRange(p_rowIndex, "A");
            range.Select();
            range.EntireRow.Delete(m_objOpt);
        }

        /// <summary>
        /// 删除指定的整列
        /// </summary>
        /// <param name="p_colIndex">列索引</param>
        protected void DeleteColumn(int p_colIndex)
        {
            Range range;

            range = GetRange(1, p_colIndex);
            range.Select();
            range.EntireColumn.Delete(m_objOpt);
        }

        /// <summary>
        /// 删除指定的整列
        /// </summary>
        /// <param name="p_colChars">列字母或组合</param>
        protected void DeleteColumn(string p_colChars)
        {
            Range range;

            range = GetRange(1, p_colChars);
            range.Select();
            range.EntireColumn.Delete(m_objOpt);
        }
        #endregion
        #region 设置行高列宽SetRowHeight(int p_rowIndex,float p_rowHeight)、SetColumnWidth(int p_colIndex,float p_colWidth)、SetColumnWidth(string p_colChars,float p_colWidth)
        /// <summary>
        /// Sets the height of the row.
        /// </summary>
        /// <param name="p_rowIndex">Index of the p_row.</param>
        /// <param name="p_rowHeight">Height of the p_row.</param>
        /// deadshot123 modify at 2007-4-10 13:44
        protected void SetRowHeight(int p_rowIndex, float p_rowHeight)
        {
            Range range;

            range = GetRange(p_rowIndex, "A");
            range.Select();
            range.RowHeight = p_rowHeight;
        }

        /// <summary>
        /// Sets the width of the column.
        /// </summary>
        /// <param name="p_colIndex">Index of the p_col.</param>
        /// <param name="p_colWidth">Width of the p_col.</param>
        /// deadshot123 modify at 2007-4-10 13:44
        protected void SetColumnWidth(int p_colIndex, float p_colWidth)
        {
            Range range;

            range = GetRange(1, p_colIndex);
            range.Select();
            range.ColumnWidth = p_colWidth;
        }

        /// <summary>
        /// Sets the width of the column.
        /// </summary>
        /// <param name="p_colChars">The p_col chars.</param>
        /// <param name="p_colWidth">Width of the p_col.</param>
        /// deadshot123 modify at 2007-4-10 13:45
        protected void SetColumnWidth(string p_colChars, float p_colWidth)
        {
            Range range;

            range = GetRange(1, p_colChars);
            range.Select();
            range.ColumnWidth = p_colWidth;
        }
        #endregion

        #region 获取单元格
        /// <summary>
        /// 获取指定单元格或指定范围内的单元格，行索引为从1开始的数字，最大65536，列索引为A~Z、AA~AZ、BA~BZ...HA~HZ、IA~IV的字母及组合，也可以是1-65536数字。
        /// </summary>
        /// <param name="p_rowIndex">单元格行索引，从1开始</param>
        /// <param name="p_colIndex">单元格列索引，从1开始，列索引也可以用字母A到Z或字母组合AA~AZ，最大IV的Excel字母索引</param>
        /// <returns></returns>
        protected Range GetRange(int p_rowIndex, int p_colIndex)
        {
            //单个	Range(10,3).Select		//第10行3列
            return GetRange(p_rowIndex, p_colIndex, p_rowIndex, p_colIndex);
        }

        /// <param name="p_colChars">单元格列字母及组合索引，从A开始</param>
        protected Range GetRange(int p_rowIndex, string p_colChars)
        {
            //单个	Range("C10").Select		//第10行3列			
            return GetRange(p_rowIndex, p_colChars, p_rowIndex, p_colChars);
        }

        /// <param name="p_startRowIndex">指定单元范围起始行索引，从1开始</param>
        /// <param name="p_startColIndex">指定单元范围起始列数字索引，从1开始</param>
        /// <param name="p_endRowIndex">指定单元范围结束行索引</param>
        /// <param name="p_endColIndex">指定单元范围结束列数字索引</param>
        protected Range GetRange(int p_startRowIndex, int p_startColIndex, int p_endRowIndex, int p_endColIndex)
        {
            Range range = null;
            if (m_objExcel != null)
            {
                range = m_objExcel.get_Range(m_objExcel.Cells[p_startRowIndex, p_startColIndex], m_objExcel.Cells[p_endRowIndex, p_endColIndex]);
            }

            return range;
        }

        /// <param name="p_startChars">指定单元范围起始列字母及组合索引</param>
        /// <param name="p_endChars">指定单元范围结束列字母及组合索引</param>
        protected Range GetRange(int p_startRowIndex, string p_startColChars, int p_endRowIndex, string p_endColChars)
        {
            //矩形	Range("D8:F11").Select
            Range range = null;

            if (m_objExcel != null)
            {
                range = m_objExcel.get_Range(p_startColChars + p_startRowIndex.ToString(), p_endColChars + p_endRowIndex.ToString());
            }

            return range;
        }
        #endregion
        #region 单元格字体设置
        /// <summary>
        /// 设置单元格字体，默认黑色
        /// </summary>
        /// <param name="p_Range">单元格</param>
        /// <param name="p_Font">字体</param>
        protected void SetFont(Range p_Range, System.Drawing.Font p_Font)
        {
            SetFont(p_Range, p_Font, 1);
        }
        /// <summary>
        /// 设置单元格字体以及颜色
        /// </summary>
        /// <param name="p_Range">单元格</param>
        /// <param name="p_Font">字体</param>
        /// <param name="p_color">颜色</param>
        protected void SetFont(Range p_Range, System.Drawing.Font p_Font, int index)
        {
            p_Range.Select();
            p_Range.Font.Name = p_Font.Name;
            p_Range.Font.Size = p_Font.Size;

            //p_Range.Font.Color = p_color;
            //p_Range.Font = p_Font;
            p_Range.Font.ColorIndex = index;


            p_Range.Font.Bold = p_Font.Bold;
            p_Range.Font.Italic = p_Font.Italic;

            p_Range.Font.Strikethrough = p_Font.Strikeout;
            p_Range.Font.Underline = p_Font.Underline;
        }
        protected void SetFont(Range rang, int index)
        {
            rang.Select();
            rang.Font.ColorIndex = index;
        }
        #endregion

        #region 单元格边框设置
        /// <summary>
        /// SetBordersEdge 设置指定范围边框（左、顶、右、底、往右下对角线、往右上对角线、内部水平线、内部垂直线、无线）线，并可指定线条的样式（无、虚线、点线等）及线粗细
        /// </summary>
        /// <param name="p_Range">单元格</param>
        /// <param name="p_BordersEdge">边框枚举</param>
        /// <param name="p_BordersLineStyle">边框样式</param>
        /// <param name="p_BordersWeight">线条宽度</param>
        protected void SetBordersEdge(Range p_Range, BordersEdge p_BordersEdge, BordersLineStyle p_BordersLineStyle, BordersWeight p_BordersWeight)
        {
            p_Range.Select();

            Border border = null;

            switch (p_BordersEdge)
            {
                //左右顶底的线
                case BordersEdge.xlLeft:
                    border = p_Range.Borders[XlBordersIndex.xlEdgeLeft];
                    break;
                case BordersEdge.xlRight:
                    border = p_Range.Borders[XlBordersIndex.xlEdgeRight];
                    break;
                case BordersEdge.xlTop:
                    border = p_Range.Borders[XlBordersIndex.xlEdgeTop];
                    break;
                case BordersEdge.xlBottom:
                    border = p_Range.Borders[XlBordersIndex.xlEdgeBottom];
                    break;
                //对角线
                case BordersEdge.xlDiagonalDown:
                    border = p_Range.Borders[XlBordersIndex.xlDiagonalDown];
                    break;
                case BordersEdge.xlDiagonalUp:
                    border = p_Range.Borders[XlBordersIndex.xlDiagonalUp];
                    break;
                //边框内部是横竖线(不包括边框)
                case BordersEdge.xlInsideHorizontal:
                    border = p_Range.Borders[XlBordersIndex.xlInsideHorizontal];
                    break;
                case BordersEdge.xlInsideVertical:
                    border = p_Range.Borders[XlBordersIndex.xlInsideVertical];
                    break;
                case BordersEdge.xlLineStyleNone:
                    //所先范围内所有线都没有
                    p_Range.Borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;		//xlNone
                    p_Range.Borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
                    p_Range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlLineStyleNone;
                    p_Range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlLineStyleNone;
                    p_Range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlLineStyleNone;
                    p_Range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlLineStyleNone;
                    p_Range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlLineStyleNone;
                    p_Range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlLineStyleNone;
                    break;
            }

            if (border != null)
            {
                //XlLineStyle
                XlLineStyle mXlLineStyle = XlLineStyle.xlContinuous;
                switch (p_BordersLineStyle)
                {
                    case BordersLineStyle.xlContinuous:
                        mXlLineStyle = XlLineStyle.xlContinuous;
                        break;
                    case BordersLineStyle.xlDash:
                        mXlLineStyle = XlLineStyle.xlDash;
                        break;
                    case BordersLineStyle.xlDashDot:
                        mXlLineStyle = XlLineStyle.xlDashDot;
                        break;
                    case BordersLineStyle.xlDashDotDot:
                        mXlLineStyle = XlLineStyle.xlDashDotDot;
                        break;
                    case BordersLineStyle.xlDot:
                        mXlLineStyle = XlLineStyle.xlDot;
                        break;
                    case BordersLineStyle.xlDouble:
                        mXlLineStyle = XlLineStyle.xlDouble;
                        break;
                    case BordersLineStyle.xlLineStyleNone:
                        mXlLineStyle = XlLineStyle.xlLineStyleNone;
                        break;
                    case BordersLineStyle.xlSlantDashDot:
                        mXlLineStyle = XlLineStyle.xlSlantDashDot;
                        break;
                }
                border.LineStyle = mXlLineStyle;

                //XlBorderWeight
                XlBorderWeight mXlBorderWeight = XlBorderWeight.xlThin;

                switch (p_BordersWeight)
                {
                    case BordersWeight.xlHairline:
                        mXlBorderWeight = XlBorderWeight.xlHairline;
                        break;
                    case BordersWeight.xlMedium:
                        mXlBorderWeight = XlBorderWeight.xlMedium;
                        break;
                    case BordersWeight.xlThick:
                        mXlBorderWeight = XlBorderWeight.xlThick;
                        break;
                    case BordersWeight.xlThin:
                        mXlBorderWeight = XlBorderWeight.xlThin;
                        break;
                }
                border.Weight = mXlBorderWeight;

            }//End IF

        }
        /// <summary>
        /// 用连续的普通粗细的线设置指定范围内的边界
        /// </summary>
        /// <param name="p_Range">单元格</param>
        /// <param name="p_BordersEdge">枚举</param>
        protected void SetRangeBorders(Range p_Range, BordersEdge p_BordersEdge)
        {
            SetBordersEdge(p_Range, p_BordersEdge, BordersLineStyle.xlContinuous, BordersWeight.xlThin);
        }
        /// <summary>
        /// 清除单元格的边框
        /// </summary>
        /// <param name="rang">单元格范围</param>
        protected void ClearRangeBorder(Range rang)
        {
            SetRangeBorders(rang, BordersEdge.xlLineStyleNone);
        }
        #endregion
        #region 单元格文本设置
        /// <summary>
        /// 获取单元格文本
        /// </summary>
        /// <param name="rang">单元格</param>
        /// <returns>获取的文本</returns>
        protected string GetRangeText(Range rang)
        {
            string result = string.Empty;
            result = rang.Formula.ToString();
            return result;
        }
        /// <summary>
        /// 设置单元格文本
        /// </summary>
        /// <param name="rang">单元格</param>
        /// <param name="text">文本</param>
        protected void SetRangeText(Range rang, string text)
        {
            // rang.Cells.FormulaR1C1=text;
            //rang.Cells.Formula = text;
            rang.Formula = text;
            //rang.FormulaR1C1 = text;
        }

        #endregion
    }
}
