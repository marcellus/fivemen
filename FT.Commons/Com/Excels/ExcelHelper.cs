using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;
using FT.Commons.Tools;

namespace FT.Commons.Com.Excels
{
    /// <summary>
    /// ��̬��ExcelHelper����
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
                // ������������������������������
                int colIndex = 0;
                int RowIndex = 0;
                int colCount = dgv.Columns.Count;
                int RowCount = dgv.Rows.Count;
                // ����Excel����                    --LeeWenjie    2006-11-29
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel�޷�����");
                    return false;
                }
                // ����Excel������
                Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];

                // ���ñ���
                Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, colCount]);
                range.MergeCells = true;
                xlApp.ActiveCell.FormulaR1C1 = reportname;
                xlApp.ActiveCell.Font.Size = 20;
                xlApp.ActiveCell.Font.Bold = true;
                xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

               

                // ������������
                object[,] objData = new object[RowCount + 1, colCount];
                // ��ȡ�б���
                foreach (DataGridViewColumn cs in dgv.Columns)
                {
                    objData[RowIndex, colIndex++] = cs.HeaderText;
                }
                object tmpcell=null;
                // ��ȡ����
                for (RowIndex = 1; RowIndex < RowCount; RowIndex++)
                {
                    for (colIndex = 0; colIndex < colCount; colIndex++)
                    {
                        tmpcell=dgv.Rows[RowIndex-1].Cells[colIndex].Value;
                        objData[RowIndex, colIndex] = tmpcell==null?"":"'"+tmpcell.ToString();
                    }
                    Application.DoEvents();
                }
                // д��Excel
                range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount, colCount]);
                range.Value2 = objData;

                // ����
                try
                {
                    xlBook.Saved = true;
                    xlBook.SaveCopyAs(path);
                }
                catch
                {
                    MessageBox.Show("�������,����!");
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
