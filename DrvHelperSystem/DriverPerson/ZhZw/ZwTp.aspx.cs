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
using FT.Web.Tools;
using FT.WebServiceInterface.WebService;
using FT.WebServiceInterface.DrvQuery;

public partial class DriverPerson_ZhZw_ZwTp : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "fp_approve";
            this.ProcedurePager1.FieldString = @"id ,
	idcard ,
	name ,
	school,
    approver ,
	approve_time ,
    type ,
    remark 
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        /*
        ZwTpObject tp = new ZwTpObject();
        tp.Approver = "test";
        tp.ApproveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        tp.IdCard = this.txtIdCardInput.Text.Trim();
        tp.Name = "testname";
        tp.School ="testschool";
        tp.Type = this.DropDownList1.Text;
        ZwTpOperator.Create(tp);
         */
        TempStudentInfo info=DrvQueryHelper.QueryStudent(WholeWebConfig.Glbm, this.txtIdCard.Text.Trim());
       
        if (info == null || info.name == null || info.name.Length == 0)
        {
            WebTools.Alert(this, "未找到该学员在本车管所报名的信息！");
             return;
        }
        else
        {
            ZwTpObject tp = new ZwTpObject();
            tp.Approver = this.Operator.OperatorName;
            tp.ApproveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tp.IdCard = this.txtIdCardInput.Text.Trim();
            tp.Name = info.name;
            tp.School = info.jxmc;
            tp.Type = this.DropDownList1.Text;
            ZwTpOperator.Create(tp);
            this.btnSearch_Click(null, null);
        }
        

    }
    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ZwTpOperator.Delete(id);
            WebTools.Alert(this, "删除成功！");
            this.ProcedurePager1.Changed = true;
        }
    }
}
