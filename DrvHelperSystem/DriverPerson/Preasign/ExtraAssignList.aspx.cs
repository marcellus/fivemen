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
using FT.Web;
using FT.Web.Tools;

public partial class DriverPreson_Preasign_ExtraAssignList : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "table_yuyue_limit";
            this.ProcedurePager1.FieldString = @"id ,
	i_km ,
	c_school_code ,
	c_school_name,
    date_ksrq ,
	c_kscc ,
    c_ksdd ,
    i_total,
    i_tptotal,
    c_operator 
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
        }
    }
  
    protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Tp")
        {
            int tp = 0;
            try
            {
                tp = Convert.ToInt32(this.txtNum.Text.Trim());
            }
            catch (Exception ex)
            {
                WebTools.Alert(this,"特批数量必须是整数！");
                return;
            }
            int id = Convert.ToInt32(e.CommandArgument);
            YuyueLimit limit = YuyueLimitOperator.Get(id);
            limit.TpTotal =tp;
           
            YuyueLimitOperator.Update(limit);
            WebTools.Alert(this, "特批成功！");
            this.ProcedurePager1.Changed = true;
        }
       
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtDate.Value.Trim().Length > 0)
            this.ProcedurePager1.RowFilter = " date_ksrq='" + this.txtDate.Value.Trim() + "'";
        else
            this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
}
