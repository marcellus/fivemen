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
        
    }
   
    protected void btnExportDetailExcel_Click(object sender, EventArgs e)
    {
        exportExcel();
        /*
        string fileNamePattern = "[{0}]至[{1}]@{2}.txt";
        string fileName = "";
        string qStrBustype = StringHelper.fnFormatNullOrBlankString(ddlExportType.SelectedValue, "");
        string qStrDateStart = StringHelper.fnFormatNullOrBlankString(qDateStart.Value, "");
        string qStrDateEnd = StringHelper.fnFormatNullOrBlankString(qDateEnd.Value, "");

        if (qStrDateStart == "" || qStrDateEnd == "")
        {
            WebTools.Alert("请输入时间范围!");
        }
        else if (qStrBustype == "")
        {
            WebTools.Alert("请选择导出类型");

        }

        string sqlCondition = "";
  
            // sqlCondition = "where TRAIN_LEAVE_8 between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD')";
            fileName = string.Format(fileNamePattern, qStrDateStart, qStrDateEnd, GetDictType()[qStrBustype]);
            //}
            //else { return; }

            ArrayList students = this.QueryStudent(qStrBustype, qStrDateStart, qStrDateEnd);
            string context = " ";



            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";

            //Response.Charset = "utf-8";//可有可无？

            //下面两个语句是一个含义，不知网上的人为什么要加一个this，非常的不解！
            //this.EnableViewState = false;
            EnableViewState = false;

            //Response.ContentType = "application/ms-excel"; //可有可无？
            //Response.ContentEncoding = System.Text.Encoding.UTF8;//可有可无？

            //直接写下面的语句，客户端看到的文件名是乱码
            //Response.AppendHeader("Content-Disposition","attachment;filename=" + saveFileName); 
            //必须写成这种

            byte[] fileBuffer = System.Text.Encoding.Default.GetBytes(context);


            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" +fileName);

            //Response.WriteFile(saveFileName);
            foreach (FpStudentObject student in students)
            {
                //context += string.Format(rblFormat.SelectedItem.Value, student.LSH, student.NAME);
                // context += "\r";
               // Response.Write(string.Format(rblFormat.SelectedItem.Value, student.LSH, student.NAME) + "\r\n");
                //Response.OutputStream;
            }

            //Response.Flush();

            Response.End();//End和Close的顺序是什么，测试时，两个位置排列交换后对执行没有任何影响
            Response.Close();

        */
    }

    private Dictionary<string, List<FpStudentObject>> QueryStudentGroupbySchool(string busType, string startDate, string endDate)
    {

        string sqlCondition = "";

        sqlCondition = "where create_time between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD')";

        ArrayList students = SimpleOrmOperator.QueryConditionList<FpStudentObject>(string.Format(sqlCondition, startDate, endDate));
        Dictionary<string, List<FpStudentObject>> dictStudents = new Dictionary<string, List<FpStudentObject>>();
        foreach (FpStudentObject student in students) {
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
        int[] rowIndexs = { 0, 0, 0 };
        String dir = MapPath(string.Format("~/temp/{0}/", Session.SessionID));
        Directory.CreateDirectory(dir);
        String pathPattern = dir+"{0}.xls";
       
        foreach (string schoolCode in schoolStudents.Keys) {
            Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
     
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
                    
                    Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[sheetIndex-1];
                    xlSheet.Name = string.Format("{0}({1})", sheetTitles[sheetIndex],rowIndexs[sheetIndex]+1);
                    int colIndex = 1;
                    int rowIndex = rowIndexs[sheetIndex]+1;
                    Excel.Range rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Value2 = student.LSH;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Value2 = student.NAME;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Value2 = student.IDCARD;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Value2 = student.CAR_TYPE;
                    rang = (Excel.Range)xlSheet.Cells[rowIndex, colIndex++];
                    rang.Value2 = student.CREATE_TIME.ToLongDateString();
                    rowIndexs[sheetIndex]++;
                }
                schoolName=student.SCHOOL_NAME;
            }
            if(string.IsNullOrEmpty(schoolName))continue;
            xlBook.Save();
            xlBook.Saved = true;
            String path=string.Format(pathPattern,schoolName);
            xlBook.SaveCopyAs(path);
        }
        xlApp.Quit();
        
    }

}
