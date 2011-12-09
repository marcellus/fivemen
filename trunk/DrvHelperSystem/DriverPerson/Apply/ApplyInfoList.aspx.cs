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
using FT.Web;

public partial class DriverPerson_Apply_ApplyInfoList : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.DataGrid1.ItemCommand += new DataGridCommandEventHandler(DataGrid1_ItemCommand1);
        if (!IsPostBack)
        {
            
            this.ProcedurePager1.AllowBinded = true;
            this.ProcedurePager1.TableName = "table_student_apply_info_i";
            this.ProcedurePager1.FieldString = @"id,c_lsh,sfzmhm,c_xm,c_jxmc,c_check_operator,
decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') as i_checked, c_zkcx,c_check_date,
c_check_result
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.RowFilter = "  c_jxdm='" + this.Operator.Desp3 + "'";
            this.ProcedurePager1.SortString = " order by id desc";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string queryValue = txtQueryValue.Text;
        string queryText = ddlQueryType.SelectedItem.Text;
        string queryType = ddlQueryType.SelectedValue;

        string query = " 1=1 ";
        if (!string.IsNullOrEmpty(queryValue))
        {
            query += string.Format(" and {0} like '%{1}%' ", queryType, queryValue);
        }
        query += "  and c_jxdm='" + this.Operator.Desp3 + "'";
        this.ProcedurePager1.RowFilter = query;
        this.ProcedurePager1.Changed = true;
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {
        this.Pop(-1);
    }

    private void Pop(int id)
    {
        string url = "ApplyInfoAdd.aspx";
        if (id > 0)
        {
            url += "?id=" + id;
        }
        WebTools.ShowModalWindows(this, url, 1024, 600);
    }

    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
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
