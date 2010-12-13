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
using FT.Web;

public partial class DriverPreson_Preasign_SchoolCommitCheck :AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //id, from 
           // /*
            this.ProcedurePager1.TableName = "table_yuyue_info";
            this.ProcedurePager1.FieldString = @"id ,
	        c_lsh,
            c_idcard,
            c_xm,
            date_pxshrq,
            c_hmhp,
            c_jbr,
            decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
            this.ProcedurePager1.RowFilter = " i_checked=0 ";
            // */
           // this.MockBind();
        }
    }

    private void MockBind()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("c_lsh");
        dt.Columns.Add("c_idcard");
        dt.Columns.Add("c_xm");
        dt.Columns.Add("date_pxshrq");
        dt.Columns.Add("c_hmhp");

        dt.Columns.Add("c_jbr");
        dt.Columns.Add("i_checked");

        for (int i = 0; i < 10; i++)
        {
            dt.Rows.Add(new string[]{i.ToString(),"lsh","c_idcard","c_xm","date_pxshrq","c_hmhp","c_jbr","i_checked"});
        }
        this.DataGrid1.DataSource = dt;
        this.DataGrid1.DataBind();
    }


    protected void btnCheck_Click(object sender, EventArgs e)
    {
        CheckBox cb;
        int id=0;
        string tmp="";
       // WebTools.Alert(this, "row-cout：" + this.DataGrid1.Items.Count.ToString());
        for (int i = 0; i < this.DataGrid1.Items.Count; i++)
        {
           cb =this.DataGrid1.Items[i].FindControl("CheckBox1") as CheckBox;
           tmp = this.DataGrid1.Items[i].Cells[1].Text;
           id=int.Parse(tmp);
           if (cb.Checked)
           {
              // WebTools.Alert(this, "审核ID："+id.ToString());
              YuyueInfoOperator.Check(id,this.Operator.OperatorName);
           }
        }
        this.ProcedurePager1.Changed = true;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.cbCheckResult.SelectedItem.Value!="-1")
            this.ProcedurePager1.RowFilter = " i_checked=" +this.cbCheckResult.SelectedItem.Value;
        else
            this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
}
