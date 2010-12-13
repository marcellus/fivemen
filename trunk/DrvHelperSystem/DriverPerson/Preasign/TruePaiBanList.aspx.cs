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
using FT.Web.Tools;
using FT.DAL;
using FT.DAL.Orm;
using FT.DAL.Oracle;

public partial class DriverPerson_Preasign_TruePaiBanList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DictOperator.BindDropDownList("考试地点", this.cbKsdd);
            DictOperator.BindDropDownList("考试场次", this.cbKscc);

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        /*select distinct lsh,sfzmhm,xm,kscx,pxshrq,kchp,ykrq,jbr,dmmc1 from drv_admin.drv_preasign t left join drv_admin.drv_code m on m.dmlb=42
 and m.dmz=t.dlr where t.glbm like '4405%'*/
        string date = this.txtDate.Value;
        if (date.Length == 0)
        {
            WebTools.Alert(this, "必须选择一个日期！");
            return;
        }
        string glbm = System.Configuration.ConfigurationManager.AppSettings["DrvHelperSystem_glbm"];
        string sql = "select distinct lsh,sfzmhm,decode(kskm,1,'科目一',2,'科目二',3,'科目三') kskm,xm,kscx,to_char(pxshrq,'yyyy-MM-dd') pxshrq,kchp,to_char(ykrq,'yyyy-MM-dd') ykrq,jbr,dmmc1  from drv_admin.drv_preasign t left join drv_admin.drv_code m on m.dmlb=42 and m.dmz=t.dlr ";
        sql += " where t.glbm like '" + glbm + "%'";
        //天排班
        if (this.RadioButtonList1.SelectedIndex == 0)
        {
            sql += " and trunc(ykrq)=trunc(to_date('"+this.txtDate.Value+"','yyyy-MM-dd'))";
        }
        else if (this.RadioButtonList1.SelectedIndex == 1)
        {
            sql += " and trunc(ykrq)=trunc(to_date('" + this.txtDate.Value + "','yyyy-MM-dd'))";
            sql += " and kskm= " + this.cbKm.SelectedItem.Value + " and kscc ='" + this.cbKscc.SelectedItem.Value + "'"
                + "  and ksdd='" + this.cbKsdd.SelectedItem.Value + "'";
        }
        IDataAccess access = new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
        DataTable dt = access.SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid1.DataSource = dt;
            this.DataGrid1.DataBind();
        }


    }
}
