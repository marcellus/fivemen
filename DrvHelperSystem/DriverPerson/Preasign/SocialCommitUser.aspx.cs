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
using FT.DAL.Orm;
using FT.DAL;

public partial class DriverPerson_Preasign_SocialCommitUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DictOperator.BindDropDownList("考试地点", this.cbKsdd);
            DictOperator.BindDropDownList("考试场次", this.cbKscc);
           // SchoolCarInfoOperator.Bind(this.cbCarNo, this.Operator.Desp3);
            if (Request.Params["id"] != null)
            {
                YuyueLimit entity = YuyueLimitOperator.Get(Convert.ToInt32(Request.Params["id"]));
                //this.yuyueLimit = entity;
                this.InitYuyueLimit(entity);
            }
        }
    }

    private void InitYuyueLimit(YuyueLimit entity)
    {
        this.cbKscc.SelectedValue = entity.KsccCode;
        this.cbKsdd.SelectedValue = entity.KsddCode;
        this.lbYkrq.Text = entity.Ksrq;
        this.cbKm.SelectedValue = entity.Km.ToString();
        this.hidPaiBanId.Value = entity.Id.ToString();
        this.lbSchoolName.Text = "非培训队报考人员";
        



    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string idcard = this.txtIdCard.Text.Trim();
        if (idcard.Length == 15)
        {
            idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
        }
        else if (idcard.Length == 18)
        {
            string tmpstr = FT.Commons.Tools.IDCardHelper.Validate(idcard);
            if (tmpstr.Length > 0)
            {
                WebTools.Alert(this, tmpstr);
                return;
            }
        }
        int km = int.Parse(this.cbKm.SelectedValue);
        string glbm = System.Configuration.ConfigurationManager.AppSettings["DrvHelperSystem_glbm"];
        DateTime yyrq = Convert.ToDateTime(lbYkrq.Text);
        DateTime now = System.DateTime.Now;
       
        int bkjg = int.Parse(ConfigurationManager.AppSettings["DrvHelperSystem_bkjg"].ToString());
        bool boolAfterDay = bool.Parse(ConfigurationManager.AppSettings["Drv_Yuyue_After_Days_Boolean"].ToString());
        int afterDay = int.Parse(ConfigurationManager.AppSettings["Drv_Yuyue_After_Days"].ToString());
        if (boolAfterDay)
        {
            if (now.AddDays(afterDay).CompareTo(yyrq) < 0)
            {
                WebTools.Alert(this, "只能预约" + afterDay + "天之后的排班！");
                return;
            }
        }
        ArrayList list = SimpleOrmOperator.QueryConditionList<YuyueInfo>(" where i_km=" + km + " and c_idcard='" + idcard + "'");
        if (list != null && list.Count > 0 && km == 1)
        {
            WebTools.Alert(this, "科目一预约只能在本系统预约一次，补考预约请到业务大厅！");
            return;

        }
        if (km > 1 && list != null)
        {
            if (list.Count == 2)
            {
                WebTools.Alert(this, "科目二、三预约只能在本系统预约二次，补考预约请到业务大厅！");
                return;
            }
            if (list.Count == 1)
            {
                YuyueInfo yytmp = list[0] as YuyueInfo;
                if (yytmp.Checked == 0)
                {
                    WebTools.Alert(this, "科目二、三预约身份证明号码" + idcard + "已经预约过考试日期为：" + yytmp.Ksrq + ",处于待审核中！");
                    return;
                }
            }

        }
       
        // ArrayList cars = SimpleOrmOperator.QueryConditionList<SchoolCarInfo>(" where hmhp='"+this.cbCarNo.SelectedItem.Text+"'");
        string jly = "";
        string sql = "update table_yuyue_limit set i_used_num=i_used_num+1  where i_used_num<i_total and id=" + this.hidPaiBanId.Value;
        bool result = DataAccessFactory.GetDataAccess().ExecuteSql(sql);
        YuyueInfo info;
        if (result)
        {
            info = new YuyueInfo();
            info.Checked = 0;
           
            info.Hmhp = this.txtCarNo.Text.Trim();
            info.IdCard = this.txtIdCard.Text.Trim();
           
            info.Km = km;
            info.Kscc = this.cbKscc.SelectedItem.Text;
            info.KsccCode = this.cbKscc.SelectedItem.Value;
            info.Ksdd = this.cbKsdd.SelectedItem.Text;
            info.KsddCode = this.cbKsdd.SelectedItem.Value;
            info.Ksrq = this.lbYkrq.Text.Trim();
           
            info.PaibanId = int.Parse(this.hidPaiBanId.Value);
            info.Pxshrq = "";
           
            SimpleOrmOperator.Create(info);
            WebTools.Alert(this, "预约成功！");
            return;
        }
        else
        {
            sql = "update table_yuyue_limit set i_tpused_num=i_tpused_num+1  where i_tpused_num<i_tptotal and id=" + this.hidPaiBanId.Value;

            result = DataAccessFactory.GetDataAccess().ExecuteSql(sql); 
            if (result)
            {
                info = new YuyueInfo();
                info.Checked = 0;
               
                info.Hmhp = this.txtCarNo.Text.Trim();
                info.IdCard = this.txtIdCard.Text.Trim();
                info.DlrCode = "social";
                info.Km = km;
                info.Kscc = this.cbKscc.SelectedItem.Text;
                info.KsccCode = this.cbKscc.SelectedItem.Value;
                info.Ksdd = this.cbKsdd.SelectedItem.Text;
                info.KsddCode = this.cbKsdd.SelectedItem.Value;
                info.Ksrq = this.lbYkrq.Text.Trim();
                
                info.PaibanId = int.Parse(this.hidPaiBanId.Value);
                info.Pxshrq = "";
                
                SimpleOrmOperator.Create(info);
                WebTools.Alert(this, "预约成功！");
                return;
            }
        }
        WebTools.Alert(this, "预约已满人！");
        return;
    }
}
