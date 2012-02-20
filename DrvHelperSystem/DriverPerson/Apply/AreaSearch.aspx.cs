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
using FT.WebServiceInterface.DrvQuery;
using FT.DAL;
using FT.DAL.Oracle;
using FT.Web;

public partial class DriverPerson_Apply_AreaSearch : System.Web.UI.Page
{


    string sqlPattern = "select "
+ " (select dmsm1 from trff_app.frm_code where dmz=concat(substr(t.dmz,0,2),'0000') and dmlb='0033' ) as sf "
+ ",(select dmsm1 from trff_app.frm_code where dmz=concat(substr(t.dmz,0,4),'00') and dmlb='0033' ) as cs "
+ ", dmz,dmsm1 "
+ " from trff_app.frm_code t where dmlb='0033' and (dmz like '%{0}%' or dmsm1 like '%{0}%')";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtCode.Text))
        {
            return;
        }
        string sql = string.Format(sqlPattern, txtCode.Text);

        DataTable dt = WholeWebConfig.GetDrvIDataAccessDecode().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }
    }
}
