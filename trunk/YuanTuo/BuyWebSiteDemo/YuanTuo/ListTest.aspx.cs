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

public partial class YuanTuo_ListTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*
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
             * */
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ProcedurePager1.Changed = true;
    }
}
