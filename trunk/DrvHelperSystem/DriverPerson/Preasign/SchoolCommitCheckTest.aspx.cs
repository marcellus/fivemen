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

public partial class DriverPerson_Preasign_SchoolCommitCheckTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            this.ProcedurePager1.TableName = "table_yuyue_info";
            this.ProcedurePager1.FieldString = @"id ,
	        c_lsh,
            c_idcard,
            c_xm,
            date_pxshrq,
            date_ksrq,
            decode(i_km,1,'科目一',2,'科目二',3,'科目三') i_km,
            c_hmhp,
            c_jbr,
            decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
            //this.SetCondition();
            // this.ProcedurePager1.RowFilter = " i_checked=0 ";
            // */
            // this.MockBind();
        }
    }
}
