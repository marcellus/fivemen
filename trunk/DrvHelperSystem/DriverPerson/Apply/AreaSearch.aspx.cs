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

public partial class DriverPerson_Apply_AreaSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DrvQueryHelper.BindDDLProvince(this.ddlProvince);
            this.ddlProvince_SelectedIndexChanged(null, null);
            this.ddlCity_SelectedIndexChanged(null, null);

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string sql = "select distinct dmz,dmz||'：'||dmmc1 as dmmc1 from drv_admin.drv_code t where dmlb=33 and (dmz = '" +this.txtCode.Text.Trim() + "' or dmmc1='"+this.txtName.Text.Trim()+"')";
        IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
        DataTable dt1 = access.SelectDataTable(sql, "tmp");
        if (dt1 != null && dt1.Rows.Count > 0)
        {
            string code=dt1.Rows[0][0].ToString();
            if (code.EndsWith("0000"))
            {
                this.ddlProvince.SelectedValue = code;
            }
            else if (code.EndsWith("00"))
            {
                this.ddlProvince.SelectedValue = code.Substring(0, 2) + "0000";
                this.ddlProvince_SelectedIndexChanged(null,null);
                this.ddlCity.SelectedValue = code;
            }
            else
            {
                this.ddlProvince.SelectedValue = code.Substring(0, 2) + "0000";
                this.ddlProvince_SelectedIndexChanged(null,null);
                this.ddlCity.SelectedValue = code.Substring(0, 4) + "00";
                this.ddlCity_SelectedIndexChanged(null,null);
                
                this.ddlArea.SelectedValue = code;
            }
        }
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        string code = this.ddlProvince.SelectedValue;
        if (code.Length > 0)
        {
            DrvQueryHelper.BindDDLCity(this.ddlCity, code);
        }
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        string code = this.ddlCity.SelectedValue;
        if (code.Length > 0)
        {
            DrvQueryHelper.BindDDLArea(this.ddlArea, code);
        }

    }
}
