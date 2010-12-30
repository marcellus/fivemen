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
using FT.DAL;
using FT.Web.Tools;
using FT.DAL.Orm;

public partial class DriverPerson_ZhZw_SimplePreasign : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DictOperator.BindDropDownList("考试地点", this.cbKsdd);
            DictOperator.BindDropDownList("考试场次", this.cbKscc);
            
            DepartMentOperator.Bind(this.cbSchool, "驾校");
            DictOperator.BindDropDownList("考试科目",this.cbKm);

            this.ProcedurePager1.TableName = "table_yuyue_info";
            this.ProcedurePager1.FieldString = @"id,c_lsh,date_ksrq,c_kscc,c_ksdd,i_km,c_idcard,
c_xm,date_pxshrq,c_hmhp,c_jbr,
decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked,
c_check_result
	".Replace("\r\n", "").Replace("\t", "");
            this.ProcedurePager1.SortString = " order by id desc";
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string idcard = this.txtIdCardSearch.Text.Trim();
        if (idcard.Length == 15)
        {
            idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
        }
        this.ProcedurePager1.RowFilter = " c_idcard like '%" + idcard + "%'";
        this.ProcedurePager1.Changed = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
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

        YuyueInfo info = new YuyueInfo();
        info.Checked = 0;
        info.Dlr = this.cbSchool.SelectedItem.Text;
        info.DlrCode = this.cbSchool.SelectedItem.Value;
        info.Hmhp = this.cbCarNo.SelectedItem.Text;
        info.IdCard = this.txtIdCard.Text.Trim();
        info.JlyIdCard = this.cbCarNo.SelectedItem.Value;

        info.Km = int.Parse(this.cbKm.SelectedItem.Value);
        info.Kscc = this.cbKscc.SelectedItem.Text;
        info.KsccCode = this.cbKscc.SelectedItem.Value;
        info.Ksdd = this.cbKsdd.SelectedItem.Text;
        info.KsddCode = this.cbKsdd.SelectedItem.Value;
        info.Ksrq = this.txtYkrq.Value.Trim();

        info.PaibanId = int.Parse(this.hidPaiBanId.Value);
        info.Pxshrq = this.txtDate.Value;
        DataTable dttmp = FT.WebServiceInterface.DrvQuery.ZhZwQueryHelper.GetDataTable(info.IdCard);
        
        if (info.Km == 1)
        {
            if (dttmp == null || dttmp.Rows.Count == 0 || dttmp.Rows[0]["lesson_result"].ToString() == "未完成")
            {
                WebTools.Alert(this, "该用户没有完成足够的学时，无法进行科目一预约！");
                return;
            }

        }
        else if (info.Km == 3)
        {
            if (dttmp == null || dttmp.Rows.Count == 0 || dttmp.Rows[0]["train_result"].ToString() == "未完成")
            {
                WebTools.Alert(this, "该用户没有完成足够的入场训练，无法进行科目三预约！");
                return;
            }
        }

        SimpleOrmOperator.Create(info);
        ArrayList list = SimpleOrmOperator.QueryConditionList<YuyueInfo>(" where c_idcard='"+info.IdCard+"' order by id desc");
        if (list.Count != 0)
        {
            YuyueInfo tmp = list[0] as YuyueInfo;
            YuyueInfoOperator.Check(tmp.Id, this.Operator.OperatorName);
            this.btnSearch_Click(null, null);
        }

    }
    protected void cbSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        SchoolCarInfoOperator.Bind(this.cbCarNo, this.cbSchool.SelectedItem.Value);
    }
}
