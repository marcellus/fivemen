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
using FT.DAL.Orm;
using FT.DAL;

public partial class LogManage_LogList : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "table_buslogs";
            this.ProcedurePager1.FieldString = @"id ,
	c_operator ,
	c_bustype ,
	c_content,
    regdate ,
	c_des1 ,
    c_des2 ,
    c_des3 
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by regdate desc";
        }
        //
    }

    public DataTable GetDataTable()
    {
        string sql = @"select id ,
	c_operator ,
	c_bustype ,
	c_content ,
    regdate ,
	c_des1 ,
    c_des2 ,
    c_des3 
	 from table_buslogs order by regdate desc".Replace("\r\n", "").Replace("\t", "");
        return FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tablename");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (this.txtBeginDate.Value.Length > 0 && this.txtEndDate.Value.Length > 0)
            this.ProcedurePager1.RowFilter = " regdate between to_date('" + this.txtBeginDate.Value.Trim() + " 00:00:00','yyyy-MM-dd HH24:mi:ss') and to_date('" + this.txtEndDate.Value.Trim() + " 23:59:59','yyyy-MM-dd HH24:mi:ss')";
        else
            this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.Changed = true;
    }
}
