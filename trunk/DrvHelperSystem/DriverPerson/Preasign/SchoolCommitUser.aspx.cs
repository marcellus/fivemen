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

public partial class DriverPreson_Preasign_SchoolCommitUser : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DictOperator.BindDropDownList("考试地点", this.cbKsdd);
            DictOperator.BindDropDownList("考试场次", this.cbKscc);
            SchoolCarInfoOperator.Bind(this.cbCarNo, this.Operator.Desp3);
            if (Request.Params["id"] != null)
            {
                YuyueLimit entity = YuyueLimitOperator.Get(Convert.ToInt32(Request.Params["id"]));
                //this.yuyueLimit = entity;
                this.InitYuyueLimit(entity);
            }
        }
    }

   // private YuyueLimit yuyueLimit;

    private void ReBind()
    {
        YuyueLimit entity = YuyueLimitOperator.Get(Convert.ToInt32(this.hidPaiBanId.Value));
        string sql = "select id,c_lsh,c_idcard,c_xm,date_pxshrq,c_hmhp,c_jbr,decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked,c_check_result from table_yuyue_info"
            + "  where (i_checked<>2 or i_checked is null) and i_paibanid=" + entity.Id;
        dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.trueNum = dt.Rows.Count;
          
        }
        else
        {
            dt = MockDataTable();
            this.trueNum = 0;
        }
        int num = entity.Total + entity.TpTotal - trueNum;
        for (int i = 0; i < num; i++)
        {
            dt.Rows.Add(dt.NewRow());
        }
        this.DataGrid1.DataSource = dt;
        this.DataGrid1.DataBind();

        sql = "select id,c_lsh,c_idcard,c_xm,date_pxshrq,c_hmhp,c_jbr,decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked,c_check_result from table_yuyue_info"
           + "  where i_checked=2 and i_paibanid=" + entity.Id;
        dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid2.DataSource = dt;
            this.DataGrid2.DataBind();

        }
    }

    private DataTable MockDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("c_lsh");

        dt.Columns.Add("c_idcard");
        dt.Columns.Add("c_xm");

        dt.Columns.Add("date_pxshrq");
        dt.Columns.Add("c_hmhp");

        dt.Columns.Add("c_jbr");
        dt.Columns.Add("i_checked");

        dt.Columns.Add("c_check_result");
        return dt;

    }

    private DataTable dt;
    private int trueNum;
    private void InitYuyueLimit(YuyueLimit entity)
    {
        this.cbKscc.SelectedValue = entity.KsccCode;
        this.cbKsdd.SelectedValue = entity.KsddCode;
        this.lbYkrq.Text = entity.Ksrq;
        this.cbKm.SelectedValue = entity.Km.ToString();
        this.hidPaiBanId.Value = entity.Id.ToString();
        this.lbSchoolName.Text = this.Operator.Desp4;
        string sql = "select id,c_lsh,c_idcard,c_xm,date_pxshrq,c_hmhp,c_jbr,decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked,c_check_result from table_yuyue_info"
            + "  where (i_checked<>2 or i_checked is null) and i_paibanid="+entity.Id;
        dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql,"tmp");
        if (dt != null)
        {
            this.trueNum = dt.Rows.Count;

        }
        else
        {
            dt = MockDataTable();
            this.trueNum = 0;
        }
        int num = entity.Total + entity.TpTotal - trueNum;
        for (int i = 0; i < num; i++)
        {
            dt.Rows.Add(dt.NewRow());
        }
        this.DataGrid1.DataSource = dt;
        this.DataGrid1.DataBind();

        sql = "select id,c_lsh,c_idcard,c_xm,date_pxshrq,c_hmhp,c_jbr,decode(i_checked,0,'未审核',1,'已审核',2,'审核不过') i_checked,c_check_result from table_yuyue_info"
           + "  where i_checked=2 and i_paibanid=" + entity.Id;
        dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
        if (dt != null)
        {
            this.DataGrid2.DataSource = dt;
            this.DataGrid2.DataBind();

        }

        
        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.txtDate.Value.Trim().Length == 0)
        {
            WebTools.Alert(this, "必须输入培训审核日期！");
            return;
        }
       
        string idcard=this.txtIdCard.Text.Trim();
        if (idcard.Length == 15)
        {
            idcard = FT.Commons.Tools.IDCardHelper.IdCard15To18(idcard);
        }
        else if (idcard.Length == 18)
        {
            string tmpstr=FT.Commons.Tools.IDCardHelper.Validate(idcard);
            if (tmpstr.Length > 0)
            {
                WebTools.Alert(this, tmpstr);
                return;
            }
        }
        int km=int.Parse(this.cbKm.SelectedValue);
        string glbm=this.Operator.Desp2;
        DateTime yyrq = Convert.ToDateTime(this.txtDate.Value);
        DateTime now = System.DateTime.Now;
       // if (dt != null)
       // {
        string tmpid = "";
        tmpid = this.DataGrid1.Items[this.DataGrid1.Items.Count-1].Cells[2].Text;
        if (tmpid != null && tmpid.Replace("&nbsp;","").Length > 0)
        {
            WebTools.Alert(this, tmpid+"本期允许约考人员已经约考完毕！");
            return;
        }
            for (int i = 0; i < this.DataGrid1.Items.Count; i++)
            {
                tmpid = this.DataGrid1.Items[i].Cells[2].Text;

                if (tmpid!=null&&tmpid == idcard)
                {
                    ///TODO:
                    WebTools.Alert(this, "身份证明号码" + idcard + "该学员已经在本期约考过！");
                    return;
                }
            }
        //}
        int bkjg = int.Parse(ConfigurationManager.AppSettings["DrvHelperSystem_bkjg"].ToString());
        bool boolAfterDay = bool.Parse(ConfigurationManager.AppSettings["Drv_Yuyue_After_Days_Boolean"].ToString());
        int afterDay = int.Parse(ConfigurationManager.AppSettings["Drv_Yuyue_After_Days"].ToString());
        if (boolAfterDay)
        {
            if (now.AddDays(afterDay).CompareTo(yyrq) < 0)
            {
                WebTools.Alert(this, "只能预约" + afterDay+ "天之后的排班！");
                return;
            }
        }
        ArrayList list = SimpleOrmOperator.QueryConditionList<YuyueInfo>(" where i_checked<>2 and i_km=" + km + " and c_idcard='" + idcard + "'");
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
        string jly=this.cbCarNo.SelectedItem.Value==null?"":this.cbCarNo.SelectedItem.Value.ToString();
        string sql1 = "update table_yuyue_limit t set t.i_used_num=(select count(*) from table_yuyue_info m where m.i_checked<>2 and m.i_paibanid=" + this.hidPaiBanId.Value + ") where t.id=" + this.hidPaiBanId.Value;
        DataAccessFactory.GetDataAccess().ExecuteSql(sql1);
        string sql = "update table_yuyue_limit set i_used_num=i_used_num+1  where i_used_num<i_total and id=" + this.hidPaiBanId.Value;
        bool result = DataAccessFactory.GetDataAccess().ExecuteSql(sql);
        YuyueInfo info;
        if (result)
        {
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
            this.ReBind();
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
                this.ReBind();
                return;
            }
        }
        WebTools.Alert(this, "预约已满人！");
        return;
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (YuyueInfoOperator.Delete(id))
            {
                WebTools.Alert(this, "已经撤销申请成功！");
                this.ReBind();
            }
            else
            {
                WebTools.Alert(this, "无法撤销审核过的申请！");
            }
            
            
        }
        
    }
}
