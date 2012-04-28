using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using FT.Commons.Tools;
using System.Collections;
using FT.DAL.Orm;
using FT.DAL;
using FT.DAL.Oracle;
using FingerMonitor.Config;
using FT.Commons.Cache;
using System.Threading;

namespace FingerMonitor
{
    public partial class StudentRecordStatisForm : Form
    {
        private IDataAccess oraclDataAccess = null;
        private string target = string.Empty;

        public StudentRecordStatisForm()
        {
            InitializeComponent();
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
            oraclDataAccess = new OracleDataHelper(config.TnsName, config.OraUser, config.OraPwd);
            
            dtpEnd.Value = DateTime.Now.AddDays(1);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            string excelName = string.Format("指纹记录[{0}][{1}].xls", dtpStart.Value.ToShortDateString(), dtpEnd.Value.ToShortDateString());
 
            target = FT.Commons.Tools.FileDialogHelper.Save("请选择导出Excel的路径", "Excel(*.xls)|*.xls", excelName);
            if (!string.IsNullOrEmpty(target))
            {
                Thread t = new Thread(new ThreadStart(exportExcel));
                t.Start();
                //exportExcel(target);
            }
            
        }

      

        private void exportExcel() {
            this.btnExport.Enabled = false;
            string btnText = this.btnExport.Text;
            this.btnExport.Text = "报表生成中....";
            Excel.Application xlApp = new Excel.ApplicationClass();
            if (xlApp == null)
            {

                MessageBoxHelper.Show("Microsoft Excel 无法启动");
                return;
            }
            // 创建Excel工作薄
            Dictionary<string, DepartMent> cacheDeps = DepartMent.queryDict(oraclDataAccess);

            Dictionary<string, List<FpStudentObject>> schoolStudents = FpStudentObject.QueryGroupbySchool(oraclDataAccess,null, dtpStart.Value.ToShortDateString(), dtpEnd.Value.ToShortDateString());
            String[] sheetTitles = { "缺受理号", "未收费", "已收费" };
            String[] sheetColumns = { "受理号", "姓名", "身份证号码", "准驾车型", "导入时间" };

            //String dir = MapPath("~/temp/");
            //Directory.CreateDirectory(dir);
            //String excelPath = this.openFileDialog1.FileName;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp.Workbooks);
            if (schoolStudents.Keys.Count < 1) {
                MessageBoxHelper.Show("没有查询到记录");
                return;
            }
            xlApp.SheetsInNewWorkbook = schoolStudents.Keys.Count;
            Excel.Workbook xlBook = xlApp.Workbooks.Add(Missing.Value);
           
            int sheetIndex = 0;
            //xlBook.Sheets.Add(Missing.Value, Missing.Value, schoolStudents.Keys.Count - 1, Missing.Value);
            
            foreach (string schoolCode in schoolStudents.Keys)
            {

                sheetIndex++;
                List<FpStudentObject> students = schoolStudents[schoolCode];
                string schoolName = schoolCode;
                try
                {
                    schoolName = cacheDeps[schoolCode].DepNickName;
                }
                catch (Exception ex) { }
                tssInfo.Text = string.Format("({2}/{3}).{0}:{1}...", schoolName, students.Count, sheetIndex, schoolStudents.Keys.Count);
                
                int rowIndex = 1;
                foreach (FpStudentObject student in students)
                {


                    int color = 0;
                    string result = "";
                    if (string.IsNullOrEmpty(student.LSH))
                    {
                        color = 3;
                        result = "缺流水号";
                    }
                    else if (student.FEE_STATUE != "Y")
                    {
                        color = 6;
                        result = "收费审核未通过";
                    }
                    else
                    {
                        result = "考勤进行中";
                    }


                    Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[sheetIndex];
                    xlSheet.Name = string.Format("{0}({1})", schoolName, schoolStudents[schoolCode].Count);
                    int colIndex = 1;

                    Excel.Range rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    //rang.Select();
                    rang.NumberFormatLocal = "@";
                    rang.ColumnWidth = 20;
                    rang.Interior.ColorIndex = color;
                    rang.Formula = student.LSH;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    //rang.Select();
                    rang.NumberFormatLocal = "@";
                    rang.ColumnWidth = 15;
                    rang.Formula = student.NAME;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    //rang.Select();
                    rang.NumberFormatLocal = "@";
                    rang.ColumnWidth = 25;
                    rang.Formula = student.IDCARD;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Formula = student.CAR_TYPE;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    //rang.Select();
                    rang.ColumnWidth = 15;
                    rang.Value2 = student.CREATE_TIME.ToLongDateString();
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    //rang.Select();
                    rang.ColumnWidth = 30;
                    rang.Value2 = result;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    //rang.Select();
                    rang.ColumnWidth = 30;
                    rang.Value2 = student.SCHOOL_NAME;
                    rowIndex++;
                }


            }
            try
            {
                xlBook.Save();
                xlBook.Saved = true;

                xlBook.SaveCopyAs(target);

            }
            finally
            {
                xlBook.Close(true, Missing.Value, Missing.Value);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook.Worksheets);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);
            }
            xlApp.Workbooks.Close();
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp.Workbooks);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            this.btnExport.Text = btnText;
            this.btnExport.Enabled = true;
            this.target = string.Empty;
            this.tssInfo.Text = string.Empty;
        }
    }
}
