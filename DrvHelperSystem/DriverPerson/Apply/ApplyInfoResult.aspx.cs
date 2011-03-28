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

public partial class DriverPerson_Apply_ApplyInfoResult : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.AllowBinded = false;
            this.ProcedurePager1.TableName = "table_student_apply_info";
            this.ProcedurePager1.FieldString = @"id,c_lsh,sfzmhm,c_xm,c_jxmc,
decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') as i_checked,
c_check_result
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.RowFilter = " c_jxdm='" + this.Operator.Desp3 + "'";
            this.ProcedurePager1.SortString = " order by id desc";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string idcard = this.txtIdCard.Text.Trim();
        if (idcard.Length == 15)
        {
            idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
        }
        this.txtIdCard.Text = idcard;
        this.ProcedurePager1.RowFilter = " sfzmhm='" + idcard + "' and c_jxdm='"+this.Operator.Desp3+"'";
        //else
        //this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.AllowBinded = true;
        this.ProcedurePager1.Changed = true;
        //this.ProcedurePager1.DataBind();
    }
}
