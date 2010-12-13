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

public partial class DriverPreson_Hospital_BusSearch : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DictOperator.BindDropDownList("车辆类型", this.cbCarType);
            this.cbCarType.Items.Insert(0,"全部车型");
            this.ProcedurePager1.TableName = "table_bus_all_info";
            this.ProcedurePager1.FieldString = @"c_lsh ,
	c_idcard ,
	c_dabh ,
	c_xm,
    regdate ,
	c_car_type ,
    decode(i_state,0,'受理中',1,'已体检',2,'已退办') as c_state
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by regdate desc";
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        this.ProcedurePager1.RowFilter = " c_idcard like '%"+this.txtIdCard.Text.Trim()+"%'";
        if(this.txtDabh.Text.Trim().Length!=0)
            this.ProcedurePager1.RowFilter += " and  c_dabh='" + this.txtDabh.Text.Trim() + "'";
        if (this.txtXm.Text.Trim().Length != 0)
            this.ProcedurePager1.RowFilter += " and c_xm='" + this.txtXm.Text.Trim() + "'";
        if (this.cbCarType.SelectedIndex!=0)
            this.ProcedurePager1.RowFilter += " and c_car_type='" + this.cbCarType.Text.Trim() + "'";
        if (this.txtOperator.Text.Trim().Length != 0)
            this.ProcedurePager1.RowFilter += " and c_operator='" + this.txtOperator.Text.Trim() + "'";
        
        if (this.txtBeginDate.Value.Length > 0 && this.txtEndDate.Value.Length > 0)
            this.ProcedurePager1.RowFilter += " and regdate between to_date('" + this.txtBeginDate.Value.Trim() + " 00:00:00','yyyy-MM-dd HH24:mi:ss') and to_date('" + this.txtEndDate.Value.Trim() + " 23:59:59','yyyy-MM-dd HH24:mi:ss')";
        else
            this.ProcedurePager1.RowFilter += "";
        this.ProcedurePager1.Changed = true;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
}
