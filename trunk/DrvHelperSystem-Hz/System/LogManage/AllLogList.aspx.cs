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
using DrvHelperSystemBLL.System;

public partial class System_LogManage_AllLogList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.TableName = "TABLE_LOG_INFO";
            this.ProcedurePager1.FieldString = @"id ,
	c_operator ,
	c_bustype ,
	c_content,
    regdate ,
    i_dep_id,
    "+Constants.DecodeDepType+@",
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
	c_content,
    regdate ,
    i_dep_id,
    " + Constants.DecodeDepType + @",
	c_des1 ,
    c_des2 ,
    c_des3 
	 from TABLE_LOG_INFO order by regdate desc".Replace("\r\n", "").Replace("\t", "");
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
