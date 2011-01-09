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

public partial class DriverPerson_Preasign_YuyueResultSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcedurePager1.AllowBinded = false;
            this.ProcedurePager1.TableName = "table_yuyue_info";
            this.ProcedurePager1.FieldString = @"id,c_lsh,date_ksrq,c_kscc,c_ksdd, decode(i_km,1,'科目一',2,'科目二',3,'科目三') i_km,c_idcard,
c_xm,date_pxshrq,c_hmhp,c_jbr,
decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked,
c_check_result
	".Replace("\r\n", "").Replace("\t", "");
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
        this.ProcedurePager1.RowFilter = " c_idcard='" + idcard + "'";
        //else
        //this.ProcedurePager1.RowFilter = "";
        this.ProcedurePager1.AllowBinded = true;
        this.ProcedurePager1.Changed = true;
        //this.ProcedurePager1.DataBind();
    }
}
