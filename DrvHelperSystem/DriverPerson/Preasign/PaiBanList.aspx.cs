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
using FT.Web.Tools;
using FT.Web;
using FT.DAL;

public partial class DriverPerson_Preasign_PaiBanList : AuthenticatedPage
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
        string date = this.txtDate.Value;
        if (date.Length == 0)
        {
            WebTools.Alert(this, "必须选择一个日期！");
            return;
        }
        string sql = "select id,date_ksrq,c_ksdd,c_kscc,decode(i_km,1,'科目一',2,'科目二',3,'科目三') c_km,c_school_name,(i_total+i_tptotal) as total,(i_used_num+i_tpused_num) as used,(i_checked_num+i_tpchecked_num) as checked from table_yuyue_limit where date_ksrq='" + date + "'";
        
        string sql2 = "select id,c_lsh,c_idcard,i_paibanid,c_xm,date_pxshrq,c_hmhp,c_jbr,decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked from table_yuyue_info"
            + "  where i_checked=1 and date_ksrq='" + date + "'";
        
        //天排班
        if (this.RadioButtonList1.SelectedIndex == 1)
        {
            sql += " and i_km= "+this.cbKm.SelectedItem.Value+" and c_kscc_code ='"+this.cbKscc.SelectedItem.Value+"'"
                +"  and c_ksdd_code='"+this.cbKsdd.SelectedItem.Value+"'";

            sql2 += " and i_km= " + this.cbKm.SelectedItem.Value + " and c_kscc_code ='" + this.cbKscc.SelectedItem.Value + "'"
                + "  and c_ksdd_code='" + this.cbKsdd.SelectedItem.Value + "'";
        }
        DataSet ds = new DataSet();
        DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "parent");
        if (dt != null)
        {
            ds.Tables.Add(dt);
            dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql2, "child");

            ds.Tables.Add(dt);
            if (dt != null)
            {
                ds.Relations.Add("myrelation",
               ds.Tables["parent"].Columns["id"],
                   ds.Tables["child"].Columns["i_paibanid"]);
               
            }
            parentRepeater.DataSource = ds.Tables["parent"];
            parentRepeater.DataBind();
        }
       




    }
}
