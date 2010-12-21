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

public partial class DriverPerson_ZhZw_ZwRecordList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "fp_student";
            this.ProcedurePager1.FieldString = @"idcard ,
	name ,
	train_enter_1 ,
	train_leave_1,
train_enter_2 ,
	train_leave_2,
train_enter_3,
	train_leave_3,
train_enter_4,
	train_leave_4,
train_enter_5,
	train_leave_5,
train_enter_6,
	train_leave_6,
train_enter_7,
	train_leave_7,
train_enter_8,
	train_leave_8,
    lesson_leave_2 ,phone,drv_school
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by idcard desc";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (this.txtHphm.Text.Trim().Length > 0)
        this.ProcedurePager1.RowFilter = " idcard like '%" + this.txtIdCard.Text.Trim() + "%'";
        //else
        //this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
}
