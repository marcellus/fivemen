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

public partial class DriverPerson_Apply_ApplyInfoCheckList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.AllowBinded = true;
            this.ProcedurePager1.TableName = "table_student_apply_info";
            this.ProcedurePager1.FieldString = @"id,c_lsh,sfzmhm,c_xm,c_jxmc,
decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') as i_checked,
c_check_result
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
        }

    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.ProcedurePager1.RowFilter += " sfzmhm like '%" + this.txtIdCard.Text.Trim() + "%'" + " and c_jxdm='" + this.Operator.Desp3 + "'";
        this.ProcedurePager1.Changed = true;
           
    }


    private void Pop(int id)
    {
        string url = "ApplyInfoAdd.aspx";
        if (id > 0)
        {
            url += "?allowcheck=true&id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 1024, 600);
    }


    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        //allowcheck
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            StudentApplyInfo record = StudentApplyInfoOperator.Get(id);
            if (record != null && record.Checked == 1)
            {
                WebTools.Alert(this, "已审核过的数据无法删除！");
            }
            else
            {
                StudentApplyInfoOperator.Delete(id);
                WebTools.Alert(this, "删除成功！");
                this.ProcedurePager1.Changed = true;
            }
        }
        else if (e.CommandName == "Detail")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            this.Pop(id);

        }
    }
}
