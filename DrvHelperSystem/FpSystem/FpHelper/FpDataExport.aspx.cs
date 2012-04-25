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
using FT.Commons.Tools;
using FT.Web.Tools;
using FT.DAL.Orm;
using System.Text;
using System.Collections.Generic;

public partial class FpSystem_FpHelper_FpDataExport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            qDateStart.Value = DateTime.Now.ToString("yyyy-MM-dd");
            qDateEnd.Value = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            foreach (string key in GetDictType().Keys)
            {
                ListItem li = new ListItem(GetDictType()[key],key);
                ddlExportType.Items.Add(li);
            }
        }
    }

    public static Dictionary<string, string> GetDictType()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("0", "已完成上课");
        dict.Add("1", "已完成入场训练");
        //dict.Add("2", "未完成上课");
        //dict.Add("3", "未完成入场训练");
        return dict;
    }


    private ArrayList QueryStudent(string busType, string startDate, string endDate)
    {

        string sqlCondition = "";
        if (busType == "0")
        {
            sqlCondition = "where LESSON_LEAVE_2 between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD')";
            //fileName = string.Format(fileNamePattern, startDate, endDate, "已完成上课");
        }
        else if (busType == "1")
        {
            sqlCondition = "where TRAIN_END_DATE between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD')";
            //fileName = string.Format(fileNamePattern, startDate, endDate, "已完成入场训练");
        }
        else { return new ArrayList(); }

        ArrayList students = SimpleOrmOperator.QueryConditionList<FpStudentObject>(string.Format(sqlCondition, startDate, endDate));
        return students;

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
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
        // if (qStrBustype == "0") {
        // sqlCondition = "where LESSON_LEAVE_2 between to_date('{0}','YYYY-MM-DD') and to_date('{1}','YYYY-MM-DD')";
        //      fileName = string.Format(fileNamePattern, qStrDateStart, qStrDateEnd,"已完成上课");
        //}
        // else if (qStrBustype == "1")
        {
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
                Response.Write(string.Format(rblFormat.SelectedItem.Value, student.LSH, student.NAME) + "\r\n");
                
            }

            //Response.Flush();

            Response.End();//End和Close的顺序是什么，测试时，两个位置排列交换后对执行没有任何影响
            Response.Close();

        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string qStrBustype = StringHelper.fnFormatNullOrBlankString(ddlExportType.SelectedValue, "");
        string qStrDateStart = StringHelper.fnFormatNullOrBlankString(qDateStart.Value, "");
        string qStrDateEnd = StringHelper.fnFormatNullOrBlankString(qDateEnd.Value, "");
        ArrayList students = this.QueryStudent(qStrBustype, qStrDateStart, qStrDateEnd);
        rpStuedts.DataSource = students;
        rpStuedts.DataBind();
    }
}