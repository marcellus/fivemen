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

public partial class DriverPreson_Hospital_BusRecord : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DictOperator.BindDropDownList("身份证明名称", this.cbIdCardType);
            DictOperator.BindDropDownList("体检业务类型", this.cbBusType);
            DictOperator.BindDropDownList("本地行政区划", this.cbRegArea);
            this.txtDabh1.Text = ConfigurationManager.AppSettings["DefaultDabh"];
            
        }
        this.txtHospital.Text = this.Operator.Desp4;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BusAllInfo info = null;
        ArrayList infos = SimpleOrmOperator.QueryConditionList<BusAllInfo>(" where c_idcard='" + this.txtIdCard.Text.Trim() + "' and i_state=0");
        if (infos.Count != 0)
        {
            info = infos[0] as BusAllInfo;
            this.btnPrintReturn.Enabled = true;
            this.cbRegArea.SelectedValue = info.RegAreaCode;
           this.txtRegArea.Text= info.RegArea;
           this.txtPostCode.Text = info.PostCode;
           this.txtPhone.Text = info.Phone;
           this.txtHeight.Text = info.Height;
           this.txtZsl.Text = info.Zsl;
           this.txtYsl.Text = info.Ysl;
           this.cbBsl.Text = info.Bsl;
           this.cbTl.Text = info.Tl;
           this.cbSz.Text = info.Sz;
           this.cbZxz.Text = info.Zxz;
           this.cbYxz.Text = info.Yxz;
           this.cbQgjb.Text = info.Qgjb;
           this.txtCheckDate.Value = info.CheckDate;
           this.txtHospital.Text = info.Hospital;
           this.hidLsh.Value = info.Lsh;
           if (this.txtRegArea.Text.Trim().Length == 0)
           {
               this.btnPrintReturn.Enabled = false;
               this.btnQuitBus.Enabled = true;
           }
           else
           {
               this.btnPrintReturn.Enabled = true;
               this.btnQuitBus.Enabled = false;
           }
        }
        else
        {
            WebTools.Alert(this, "请先受理该体检人！");
            return;
           // info = DriverInterface.GetFromUser(this.cbIdCardType.SelectedValue.ToString(), this.txtIdCard.Text.Trim(), this.txtDabh1.Text + this.txtDabh2);
            //this.hidLsh.Value = info.Lsh;
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
        this.imgPerson.ImageUrl = "../../ShowImage.aspx?idcard=" + this.txtIdCard.Text.Trim();
    }
    
    protected void btnQuitBus_Click(object sender, EventArgs e)
    {
        string sql = "select * from table_bus_all_info where c_idcard='" + this.lbIdCard.Text.Trim() + "' and i_state=0";
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmpdb");
        if (dt.Rows.Count == 0)
        {

            string sql2 = "update table_bus_all_info set i_state=2 where c_idcard='" + this.lbIdCard.Text.Trim() + "' and i_state=0";
            if (FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql2))
            {
                WebTools.Alert(this, "退办成功！");
            }
            else
            {
                WebTools.Alert(this, "退办失败！");
            }
        }
    }
    protected void btnPrintReturn_Click(object sender, EventArgs e)
    {
        string sql = "select * from table_bus_all_info where c_idcard='" + this.lbIdCard.Text.Trim() + "' and i_state=0";
        DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmpdb");
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
        }
        else
        {
            sql = "update table_bus_all_info set I_PRINT_ADD=I_PRINT_ADD+1 where c_idcard='" + this.lbIdCard.Text.Trim() + "' and i_state=0";
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
            this.LogBus("补打回执单", "进行" + this.lbIdCard.Text.Trim() + "的补打回执单！");
        }
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.lbIdCard.Text.Trim().Length > 0)
        {
            BusAllInfo info = null;
            ArrayList infos = SimpleOrmOperator.QueryConditionList<BusAllInfo>(" where c_idcard='" + this.lbIdCard.Text + "' and i_state=0");
            if (infos.Count != 0)
            {
                info = infos[0] as BusAllInfo;
                info.RegAreaCode = this.cbRegArea.SelectedValue.ToString();
                info.RegArea = this.txtRegArea.Text.Trim();
                info.PostCode = this.txtPostCode.Text.Trim();
                info.Phone = this.txtPhone.Text.Trim();
                info.Height = this.txtHeight.Text.Trim();
                info.Zsl = this.txtZsl.Text.Trim();
                info.Ysl = this.txtYsl.Text.Trim();
                info.Bsl = this.cbBsl.Text;
                info.Tl = this.cbTl.Text;
                info.Sz = this.cbSz.Text;
                info.Zxz = this.cbZxz.Text;
                info.Yxz = this.cbYxz.Text;
                info.Qgjb = this.cbQgjb.Text;
                info.CheckDate = this.txtCheckDate.Value;
                info.Hospital = this.txtHospital.Text;

                SimpleOrmOperator.Update(info);
                this.LogBus("进行体检信息录入","进行"+this.lbIdCard.Text.Trim()+"的体检信息录入！");
                this.btnPrintReturn.Enabled = true;
                this.btnQuitBus.Enabled = false;
                //this.btnPrintReturn.Enabled = true;
            }
        }
    }
}
