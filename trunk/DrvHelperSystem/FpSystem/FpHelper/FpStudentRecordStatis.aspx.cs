using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.WebServiceInterface.DrvQuery;
using System.Data;
using FT.Commons.Tools;
using FT.Web.Tools;
using System.Collections;
using FT.DAL.Orm;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using System.Threading;

public partial class FpSystem_FpHelper_FpStudentRecordStatis : System.Web.UI.Page
{

    private string _sqlPattern = @"  select distinct(dep.c_depcode),dep.c_depnickname,
   (select count(fp.idcard) from fp_student fp where fp.school_code=dep.c_depcode and fp.create_time between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD')) as total_num
   ,(select count(fp.idcard) from fp_student fp where fp.school_code=dep.c_depcode and fp.create_time between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD') and fp.fee_statue!='Y') as new_num
   ,(select count(fp.idcard) from fp_student fp where fp.school_code=dep.c_depcode and fp.create_time between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD') and fp.fee_statue='Y') as fee_num
   ,(select count(fp.idcard) from fp_student fp where fp.school_code=dep.c_depcode and fp.create_time between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD') and fp.statue>=2) as lesson_finish_num
    from table_departments dep
    
	".Replace("\r\n", "").Replace("\t", "");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DrvQueryHelper.BindDropDownListBustype(this.cbBustype);
            string startDate = DateTime.Now.ToString("yyyy-MM-dd");
            string endDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            this.qDateStart.Value = startDate;
            this.qDateEnd.Value = endDate;
            //cbBustype.Items.Insert(0, new ListItem("全部", "@"));
            // this.cbBustype.DataTextField = "全部";
            // this.cbBustype.DataValueField = "@";
            BindData(qDateStart.Value, qDateEnd.Value);
        }
    }


    private void BindData(string begin, string end)
    {

        string sql = string.Format(_sqlPattern, begin, end);
        DataTable dt = WholeWebConfig.GetDrvIDataAccessDecode().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }

    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindData(qDateStart.Value, qDateEnd.Value);
    }
   
   

    private Dictionary<string, List<FpStudentObject>> QueryStudentGroupbySchool(string busType, string startDate, string endDate)
    {

        string sqlCondition = "";

        sqlCondition = "where create_time between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD') order by create_time desc";

        ArrayList students = SimpleOrmOperator.QueryConditionList<FpStudentObject>(string.Format(sqlCondition, startDate, endDate));
        Dictionary<string, List<FpStudentObject>> dictStudents = new Dictionary<string, List<FpStudentObject>>();
        foreach (FpStudentObject student in students) {
            if (string.IsNullOrEmpty(student.SCHOOL_CODE)) continue;
            if (!dictStudents.ContainsKey(student.SCHOOL_CODE)) {
                dictStudents.Add(student.SCHOOL_CODE, new List<FpStudentObject>());
            }
            dictStudents[student.SCHOOL_CODE].Add(student);
        }
        return dictStudents;

    }

    private void exportExcel() {
        Excel.Application xlApp = new Excel.ApplicationClass();
        if (xlApp == null)
        {
            WebTools.Alert("Excel无法启动");
            return;
        }
        // 创建Excel工作薄
        

        Dictionary<string, List<FpStudentObject>> schoolStudents = QueryStudentGroupbySchool(null,qDateStart.Value,qDateEnd.Value);
        String[] sheetTitles={"缺受理号","未收费","已收费"};
        String[] sheetColumns={"受理号","姓名","身份证号码","准驾车型","导入时间"};
        
        String dir = MapPath(string.Format("~/temp/{0}/", Session.SessionID));
        if (Directory.Exists(dir))
        {
            Directory.Delete(dir,true);
        }
       
            Directory.CreateDirectory(dir);
        
        String pathPattern = dir+"{0}.xls";
       
        foreach (string schoolCode in schoolStudents.Keys) {
            Excel.Workbook xlBook = xlApp.Workbooks.Add(Missing.Value);
            int[] rowIndexs = { 0, 0, 0 };
            List<FpStudentObject> students = schoolStudents[schoolCode];
            string schoolName=null;

            xlBook.Sheets.Add(Missing.Value, Missing.Value, sheetTitles.Length-1,Missing.Value);
            foreach(FpStudentObject student in students){
                int sheetIndex = -1;
                if (string.IsNullOrEmpty(student.LSH)) {
                    sheetIndex = 0;
                    
                }
                else if (student.FEE_STATUE != "Y") {
                    sheetIndex = 1;
                }
                else if (student.FEE_STATUE == "Y") {
                    sheetIndex = 2;
                }

                if (sheetIndex >= 0) {
                    
                    Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[sheetIndex];
                    xlSheet.Name = string.Format("{0}({1})", sheetTitles[sheetIndex],rowIndexs[sheetIndex]+1);
                    int colIndex = 1;
                    int rowIndex = rowIndexs[sheetIndex]+1;
                    Excel.Range rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Select();
                    rang.ColumnWidth = 200;
                    rang.Formula = student.LSH;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Select();
                    rang.ColumnWidth = 120;
                    rang.Formula = student.NAME;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Select();
                    rang.ColumnWidth = 250;
                    rang.Formula = student.IDCARD;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Formula = student.CAR_TYPE;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Select();
                    rang.ColumnWidth = 120;
                    rang.Value2 = student.CREATE_TIME.ToLongDateString();
                    rowIndexs[sheetIndex]++;
                    
                }
                schoolName=student.SCHOOL_NAME;
            }
            if(string.IsNullOrEmpty(schoolName))continue;
            try
            {
                xlBook.Save();
                xlBook.Saved = true;
                String path = string.Format(pathPattern, schoolName);
                if (File.Exists(path)) {
                    File.Delete(path);
                }
                xlBook.SaveCopyAs(path);
                
            }
            finally
            {
                xlBook.Close(true, Missing.Value, Missing.Value);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook.Worksheets);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook);  
            }
        }
        xlApp.Workbooks.Close();
        xlApp.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp.Workbooks); 
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);  
        String zipFileName=string.Format("指纹记录[{0}][{1}].zip",qDateStart.Value,qDateEnd.Value);
        if (File.Exists(zipFileName)) {
            File.Delete(zipFileName);
        }
        string zipPath = dir + zipFileName;
        FileHelper.ZipDir(dir,zipPath);
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(zipFileName, Encoding.UTF8));
        Response.WriteFile(zipPath);
        Response.End();
        Response.Close();
      
        
 
        
    }


    private void exportExcel2()
    {
        Excel.Application xlApp = new Excel.ApplicationClass();
        
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp.Workbooks);
        if (xlApp == null)
        {
            WebTools.Alert("Excel无法启动");
            return;
        }
        // 创建Excel工作薄


        Dictionary<string, List<FpStudentObject>> schoolStudents = QueryStudentGroupbySchool(null, qDateStart.Value, qDateEnd.Value);
        String[] sheetTitles = { "缺受理号", "未收费", "已收费" };
        String[] sheetColumns = { "受理号", "姓名", "身份证号码", "准驾车型", "导入时间" };

        String dir = MapPath(string.Format("~/temp/{0}/",Session.SessionID));
        Directory.CreateDirectory(dir);
        String excelName=string.Format("指纹记录[{0}][{1}].xls",this.qDateStart.Value,this.qDateEnd.Value);
        String excelPath = dir +excelName ;
        if (File.Exists(excelPath)) {
            File.Delete(excelPath);
        }
        xlApp.SheetsInNewWorkbook = schoolStudents.Keys.Count ;
        xlApp.Workbooks.Add(Missing.Value);
        Excel.Workbook xlBook = xlApp.ActiveWorkbook;
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBook.Worksheets);
        
        int sheetIndex = 0;
      //  try
       // {
          
            //xlBook.Worksheets.Add(Missing.Value, Missing.Value, schoolStudents.Keys.Count - 1, Missing.Value);
        //}
       // catch (Exception ex) {
       //     WebTools.Alert(ex.Message);
       //     return;
      //  }
        foreach (string schoolCode in schoolStudents.Keys)
        {
            WebTools.Alert(schoolCode);
            sheetIndex++;
            List<FpStudentObject> students = schoolStudents[schoolCode];
            string schoolName =schoolCode;
            ArrayList deps= SimpleOrmOperator.QueryConditionList<DepartMent>(string.Format("where c_depcode='{0}'", schoolCode));
            if (deps.Count > 0) {
                schoolName = (deps[0] as DepartMent).DepNickName;
            }
            
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
                else {
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
                    rowIndex++;
            }


        }
        try{
            xlBook.Save();
            xlBook.Saved = true;
            
            xlBook.SaveCopyAs(excelPath);
            WebTools.Alert("保存成功");
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
        
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(excelName, Encoding.UTF8));
        Response.WriteFile(excelPath);
        Response.End();
        Response.Close();




    }

}
