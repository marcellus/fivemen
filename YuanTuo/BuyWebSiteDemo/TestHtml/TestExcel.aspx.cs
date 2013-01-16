using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class TestHtml_TestExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string title = "测试excel";
        string path = Server.MapPath("~/YuanTuo/ReportFiles/测试excel.xls");
        DataTable dt = new DataTable();
        dt.Columns.Add("name");
        dt.Columns.Add("sex");
        for (int i = 0; i < 20; i++)
        {
            dt.Rows.Add(new string[] {"name"+i.ToString(),"sex"+i.ToString() });
        }
        FT.Commons.Com.Excels.ListExcel excel = new FT.Commons.Com.Excels.ListExcel(path, dt);
        excel.IsReplaceReport = true;
        excel.Title = title;
       // excel.HeaderWidth = new int[] { 10, 40, 10, 10, 20, 20, 20, 10, 10 };
        // excel.HasHeader = false;
        // excel.HasFooter = false;
        //excel.GetExcelReport();
        FT.Web.Tools.WebTools.ExportExcelReport(title + ".xls", excel);
    }
}
