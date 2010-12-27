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

public partial class DriverPerson_ZhZw_SimplePreasign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.ProcedurePager1.TableName = "table_yuyue_info";
            this.ProcedurePager1.FieldString = @"id,c_lsh,date_ksrq,c_kscc,c_ksdd,i_km,c_idcard,
c_xm,date_pxshrq,c_hmhp,c_jbr,
decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked,
c_check_result
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
        }
    }
    /*
     
      info = new YuyueInfo();
            info.Checked = 0;
            info.Dlr = this.Operator.Desp4;
            info.DlrCode = this.Operator.Desp3;
            info.Hmhp = this.cbCarNo.SelectedItem.Text;
            info.IdCard = this.txtIdCard.Text.Trim();
            info.JlyIdCard = jly;
            
            info.Km = km;
            info.Kscc = this.cbKscc.SelectedItem.Text;
            info.KsccCode = this.cbKscc.SelectedItem.Value;
            info.Ksdd = this.cbKsdd.SelectedItem.Text;
            info.KsddCode = this.cbKsdd.SelectedItem.Value;
            info.Ksrq = this.lbYkrq.Text.Trim();
           
            info.PaibanId = int.Parse(this.hidPaiBanId.Value);
            info.Pxshrq = this.txtDate.Value;

            SimpleOrmOperator.Create(info);
            WebTools.Alert(this, "预约成功！");
     
     YuyueInfoOperator.Check(id,this.Operator.OperatorName);
     
     */
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string idcard = this.txtIdCardSearch.Text.Trim();
        if (idcard.Length == 15)
        {
            idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
        }
        this.ProcedurePager1.RowFilter = " c_idcard='" + idcard + "'";
        this.ProcedurePager1.Changed = true;
    }
}
