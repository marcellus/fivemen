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

public partial class LogManage_LogCount : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "table_buslogs";
            this.ProcedurePager1.FieldString = @"
	c_operator,
	c_bustype,
	count(1) as  sl
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = "";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.ProcedurePager1.RowFilter = " c_operator like '%"+this.txtOperator.Text.Trim()+"%' ";

        if (this.txtBeginDate.Value.Length > 0 && this.txtEndDate.Value.Length > 0)
            this.ProcedurePager1.RowFilter += " and regdate between to_date('" + this.txtBeginDate.Value.Trim() + " 00:00:00','yyyy-MM-dd HH24:mi:ss') and to_date('" + this.txtEndDate.Value.Trim() + " 23:59:59','yyyy-MM-dd HH24:mi:ss')";
       
        
        this.ProcedurePager1.RowFilter += " group by c_operator,c_bustype";
       // this.ProcedurePager1.
        this.ProcedurePager1.Changed = true;
    }
}
