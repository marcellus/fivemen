using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;
using FT.Commons.Tools;

namespace FT.Commons.Com.Excels
{
    /// <summary>
    /// 静态的ExcelHelper工具
    /// </summary>
    public class ExcelHelper
    {
        private ExcelHelper()
        {
        }

        public static bool ExportExcel(DataGridView dgv,string reportname)
        {
            string path=FileDialogHelper.SaveExcel();
            if (path.Length > 0)
            {
                if ( dgv.Columns.Count== 0) return false;
                //DataGridTableStyle ts = dgv.TableStyles[0];
                // 列索引，行索引，总列数，总行数
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = dgv.Columns.Count;
                int RowCount = dgv.Rows.Count;
                // 创建Excel对象                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel无法启动");
                    return false;
                }
                // 创建Excel工作薄
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // 设置标题
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = reportname;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

               

                // 创建缓存数据
                object[,] objData = new object[RowCount + 1, colCount];
                // 获取列标题
                foreach (DataGridViewColumn cs in dgv.Columns)
                {
                    objData[RowIndex, colIndex++] = cs.HeaderText;
                }
                object tmpcell=null;
                // 获取数据
                for (RowIndex = 1; RowIndex < RowCount; RowIndex++)
                {
                    for (colIndex = 0; colIndex < colCount; colIndex++)
                    {
                        tmpcell=dgv.Rows[RowIndex-1].Cells[colIndex].Value;
                        objData[RowIndex, colIndex] = tmpcell==null?"":"'"+tmpcell.ToString();
                    }
                    Application.DoEvents();
                }
                // 写入Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount, colCount]);
                range.Value2 = objData;

                // 保存
                try
                {
                    xlBook.Saved = true;
                    xlBook.SaveCopyAs(path);
                }
                catch
                {
                    MessageBox.Show("保存出错,请检查!");
                    return false;
                }
                finally
                {
                    xlApp.Quit();
                    GC.Collect();
                }
            }
           return true;
        }
    }
}
