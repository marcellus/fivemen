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
using FT.DAL.Orm;
using FT.WebServiceInterface.WebService;

public partial class DriverPreson_Hospital_BusAccept : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DictOperator.BindDropDownList("身份证明名称",this.cbIdCardType);
            DictOperator.BindDropDownList("体检业务类型", this.cbBusType);
            this.txtDabh1.Text=ConfigurationManager.AppSettings["DefaultDabh"];
        }

    }
    protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BusAllInfo info=null;
        ArrayList infos = SimpleOrmOperator.QueryConditionList<BusAllInfo>(" where c_idcard='" + this.txtIdCard.Text.Trim() + "' and i_state=0");
        if (infos.Count != 0)
        {
            info = infos[0] as BusAllInfo;
            this.btnQuitBus.Enabled = true;
            this.hidLsh.Value = info.Lsh;
        }
        else{
           info = DriverInterface.GetFromUser(this.cbIdCardType.SelectedValue.ToString(), this.txtIdCard.Text.Trim(), this.txtDabh1.Text + this.txtDabh2);
           hidLsh.Value = info.Lsh;
        }
        
        this.lbBrithday.Text = info.Birthday;
        this.lbDabh.Text = info.Dabh;
        this.lbIdCard.Text = info.IdCard;
        this.lbIDCardType.Text = info.IdCardType;
        this.lbNation.Text = info.Nation;
        this.lbSex.Text = info.Sex;
        this.lbXm.Text = info.Xm;
        this.lbLearnCar.Text = info.CarType;
        this.lbCheckDay.Text = info.CheckDate;
        //this.lbDescription.Text

        this.imgPerson.ImageUrl = "../../ShowImage.aspx?idcard="+this.txtIdCard.Text.Trim();
    }
    private void LogBus(string type, string content)
    {
        BusLog log = new BusLog();
        log.Operator = this.Operator.OperatorName;
        log.Des1 = this.lbIdCard.Text.Trim();
        log.Des2 = this.lbDabh.Text.Trim();
        log.Content = content;
        log.BusType = type;
        FT.DAL.Orm.SimpleOrmOperator.Create(log);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
         if (this.lbIdCard.Text.Trim().Length > 0)
        {
            string sql = "select * from table_bus_all_info where c_idcard='" + this.lbIdCard.Text.Trim() + "' and i_state=0";
            DataTable dt=FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql,"tmpdb");
            if (dt.Rows.Count == 0)
            {

                BusAllInfo info = new BusAllInfo();
                info.Birthday = this.lbBrithday.Text;
                info.Dabh = this.lbDabh.Text;
                info.IdCard = this.lbIdCard.Text;
                info.IdCardType = this.lbIDCardType.Text;
                info.Nation = this.lbNation.Text;
                info.Sex = this.lbSex.Text;
                info.Xm = this.lbXm.Text;
                info.CarType = this.lbLearnCar.Text;
                info.CheckDate = this.lbCheckDay.Text;
                info.State = 0;
                info.Operator = this.Operator.OperatorName;
                info.Lsh = this.hidLsh.Value;
                info.IsPrintAdd = 1;
                FT.DAL.Orm.SimpleOrmOperator.Create(info);
                this.LogBus("保存受理信息", "保存" + info.IdCard + "的受理信息！");
            }
            else
            {
                sql = "update table_bus_all_info set I_PRINT_ADD=I_PRINT_ADD+1 where c_idcard='" + this.lbIdCard.Text.Trim() + "' and i_state=0";
                FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
                this.LogBus("补打申请表", "补打" + this.lbIdCard.Text.Trim() + "的申请表！");

            }
            this.ClientScript.RegisterStartupScript(222.GetType(), "print", "<script type='text/javascript'>printExcel();</script>");
            //WebTools.WriteScript("PrintTemplate();");
            ///TODO: 打印申请表并进行受理
        }
        
    }
    protected void btnQuitBus_Click(object sender, EventArgs e)
    {
        if (this.lbIdCard.Text.Trim().Length > 0)
        {
            string sql = "select * from table_bus_all_info where c_idcard='" + this.lbIdCard.Text.Trim() + "' and i_state=0";
            DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmpdb");
            if (dt.Rows.Count == 0)
            {

                string sql2 = "update table_bus_all_info set i_state=2 where c_idcard='" + this.lbIdCard.Text.Trim() + "' and i_state=0";
                if (FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql2))
                {
                    this.LogBus("退办体检受理", "退办" + this.lbIdCard.Text.Trim() + "的体检受理！");
                    WebTools.Alert(this, "退办成功！");
                }
                else
                {
                    WebTools.Alert(this, "退办失败！");
                }
            }
        }
    }
}
