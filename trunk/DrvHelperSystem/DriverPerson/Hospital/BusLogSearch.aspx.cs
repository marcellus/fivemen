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

public partial class DriverPreson_Hospital_BusLogSearch : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
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
        this.ProcedurePager1.RowFilter = " c_bustype in ('保存受理信息','进行体检信息录入','补打申请表','补打回执单','退办体检受理')";
        this.ProcedurePager1.SortString = " order by regdate desc";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.ProcedurePager1.RowFilter = " c_des1 like '%" + this.txtIdCard.Text.Trim() + "%'";
        if (this.txtDabh.Text.Trim().Length != 0)
            this.ProcedurePager1.RowFilter += " and  c_des2='" + this.txtDabh.Text.Trim() + "'";
      
        if (this.txtOperator.Text.Trim().Length != 0)
            this.ProcedurePager1.RowFilter += " and c_operator='" + this.txtOperator.Text.Trim() + "'";
        this.ProcedurePager1.RowFilter += " and c_bustype in ('保存受理信息','进行体检信息录入','补打申请表','补打回执单','退办体检受理')";
        if (this.txtBeginDate.Value.Length > 0 && this.txtEndDate.Value.Length > 0)
            this.ProcedurePager1.RowFilter += " and regdate between to_date('" + this.txtBeginDate.Value.Trim() + " 00:00:00','yyyy-MM-dd HH24:mi:ss') and to_date('" + this.txtEndDate.Value.Trim() + " 23:59:59','yyyy-MM-dd HH24:mi:ss')";
        else
            this.ProcedurePager1.RowFilter += "";
        this.ProcedurePager1.Changed = true;
    }
}
