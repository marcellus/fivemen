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
using FT.Web.Tools;
using FT.Commons.Web.Tools;
using FT.Commons.Web;
using FT.Web;
using FT.DAL.Orm;
using FT.Commons.Tools;


public partial class DriverPerson_Apply_ApplyInfoAdd : AuthenticatedPage
{

    private string getDefaultCityCode() {
        return System.Configuration.ConfigurationManager.AppSettings["DefaultCityCode"];
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DrvQueryHelper.BindDropDownListBustype(this.cbBustype);
            DrvQueryHelper.BindDropDownListSfzmmc(this.cbSfzmmcValue);
            DrvQueryHelper.BindDropDownListHospital(this.cbTjyy);
            ListItemCollection tjyys = new ListItemCollection();
            lbJxmc.Text = this.Operator.Desp4;
            foreach (ListItem li in this.cbTjyy.Items) {
                if (li.Value.StartsWith(getDefaultCityCode())) {
                    tjyys.Add(li);
                }
            }
            this.cbTjyy.Items.Clear();
            foreach (ListItem li in tjyys) {
                this.cbTjyy.Items.Add(li);
            }

            DrvQueryHelper.BindDropDownListLocalArea2(this.cbLxzsxzqhValue);
            ListItemCollection xzqhs = new ListItemCollection();
            foreach (ListItem li in this.cbLxzsxzqhValue.Items)
            {
                if (li.Value.StartsWith(getDefaultCityCode())&&li.Value!=getDefaultCityCode()+"00")
                {
                    xzqhs.Add(li);
                }
            }
            this.cbXzqhValue.Items.Clear();
            this.cbLxzsxzqhValue.Items.Clear();
            foreach (ListItem li in xzqhs)
            {
                //this.cbXzqhValue.Items.Add(new ListItem(li.Text,li.Value));
                this.cbLxzsxzqhValue.Items.Add(new ListItem(li.Text, li.Value));
                this.cbXzqhValue.Items.Add(new ListItem(li.Text, li.Value));
            }
            this.cbXzqhValue.Items.Add(new ListItem("其它（外地）", "440907"));

            DrvQueryHelper.BindDropDownListLy(this.cbLyValue);
            DrvQueryHelper.BindDropDownListZkcx(this.cbZkcxValue);
            DrvQueryHelper.BindDropDownListNational(this.cbGjValue);
            DrvQueryHelper.BindDropDownListLocalArea(this.cbDjzsxzqhValue);
            //DrvQueryHelper.BindDropDownListLocalArea(this.cbLxzsxzqhValue);
            DrvQueryHelper.BindDDLProvince(this.cbLxzsxzqhP);
            DrvQueryHelper.BindDDLProvince(this.cbDjzsxzqhP);
            this.cbGjValue.SelectedValue = "156";

            if (Request.Params["id"] != null)
            {
                StudentApplyInfo entity = SimpleOrmOperator.Query<StudentApplyInfo>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
                this.txtTjrq.Value = entity.Tjrq;
                this.txtCsrq.Value = entity.Csrq;
                this.cbDjzsxzqhValue.Items.Clear();
                //this.cbDjzsxzqhValue.Items.Add(new ListItem(entity.Djzsxzqh, entity.Djzsxzqh));
                //this.cbDjzsxzqhValue.Items.Clear();
                //this.cbDjzsxzqhValue.Text = entity.Djzsxzqh;
                this.imgPhoto.ImageUrl = "ApplyInfoPhoto.aspx?idcard=" + entity.Sfzmhm;
                this.cbBustype.SelectedValue = entity.PhotoSrc;
                if (!string.IsNullOrEmpty(entity.Lxzsxzqh)) {
                    this.cbLxzsxzqhP.SelectedValue = string.Format("{0}0000",entity.Lxzsxzqh.Substring(0,2));
                    DrvQueryHelper.BindDDLCity(cbLxzsxzqhC, this.cbLxzsxzqhP.SelectedValue);
                    this.cbLxzsxzqhC.SelectedValue = string.Format("{0}00", entity.Lxzsxzqh.Substring(0,4));
                    DrvQueryHelper.BindDDLArea(cbLxzsxzqhValue, this.cbLxzsxzqhC.SelectedValue);
                    this.cbLxzsxzqhValue.SelectedValue = entity.Lxzsxzqh;
                }
                if (!string.IsNullOrEmpty(entity.Djzsxzqh))
                {
                    this.cbDjzsxzqhP.SelectedValue = string.Format("{0}0000", entity.Djzsxzqh.Substring(0, 2));
                    DrvQueryHelper.BindDDLCity(cbDjzsxzqhC, this.cbDjzsxzqhP.SelectedValue);
                    this.cbDjzsxzqhC.SelectedValue = string.Format("{0}00", entity.Djzsxzqh.Substring(0, 4));
                    DrvQueryHelper.BindDDLArea(cbDjzsxzqhValue, this.cbDjzsxzqhC.SelectedValue);
                    this.cbDjzsxzqhValue.SelectedValue = entity.Djzsxzqh;
                }
            }
            else {
                this.imgPhoto.ImageUrl = "~/images/no_photo.jpg";
                //this.cbLxzsxzqhValue.SelectedValue = "440500";
                //this.cbXzqhValue.SelectedValue = "440500";
                //this.cbDjzsxzqhValue.SelectedValue = "440500";

                this.cbLxzsxzqhP.SelectedValue = string.Format("{0}0000",this.getDefaultCityCode().Substring(0, 2));
                DrvQueryHelper.BindDDLCity(cbLxzsxzqhC, this.cbLxzsxzqhP.SelectedValue);
                this.cbLxzsxzqhC.SelectedValue = string.Format("{0}00", this.getDefaultCityCode());
                DrvQueryHelper.BindDDLArea(cbLxzsxzqhValue, this.cbLxzsxzqhC.SelectedValue);

                this.cbDjzsxzqhP.SelectedValue = string.Format("{0}0000", this.getDefaultCityCode().Substring(0, 2));
                DrvQueryHelper.BindDDLCity(cbDjzsxzqhC, this.cbDjzsxzqhP.SelectedValue);
                this.cbDjzsxzqhC.SelectedValue = string.Format("{0}00", this.getDefaultCityCode().Substring(0, 4));
                DrvQueryHelper.BindDDLArea(cbDjzsxzqhValue, this.cbDjzsxzqhC.SelectedValue);

                this.txtYsl.Text="5.0";
                this.txtZsl.Text = "5.0";
                this.cbZkcxValue.SelectedValue = "C1";
                this.txtLxzsyzbm.Text = "510000";
            }

            if (Request.Params["allowcheck"] == null)
            {
                this.btnCheck.Visible = false;
                this.btnCheckImage.Visible = false;
            }
            else {
                this.btnSure.Visible = false;
                this.cbBustype.Enabled = false;
            }

        }

    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        int depId = this.Operator.DeptId;
        DepartMent dep = SimpleOrmOperator.Query<DepartMent>(depId);

        DrvAuthObject auth = SimpleOrmOperator.Query<DrvAuthObject>(dep.DepCode);

        if (auth == null || auth.YLR_IND != 1) {
            WebTools.Alert("未获得授权不能使用预录入功能!");
            return;
        }

        StudentApplyInfo entity = new StudentApplyInfo();
        WebFormHelper.GetDataFromForm(this, entity);
        entity.Csrq = this.txtCsrq.Value.Trim();
        entity.Tjrq = this.txtTjrq.Value.Trim();
        //借用一下这个字段
        entity.PhotoSrc = this.cbBustype.SelectedValue;
        
        if (!string.IsNullOrEmpty(Request.Params["cbDjzsxzqhValue"]))
        {
            entity.Djzsxzqh = Request.Params["cbDjzsxzqhValue"];
        }


        entity.CheckDate = DateTime.Now.ToString("yyyy-MM-dd");
       // entity.DepName = this.cbDepCodeValue.SelectedItem.Text;
        if (entity.Id < 0)
        {
            entity.Jxdm = this.Operator.Desp3;
            entity.Jxmc = this.Operator.Desp4;
            if (SimpleOrmOperator.Create(entity))
            {
                WebTools.Alert("添加成功！");
            }
            else
            {
                WebTools.Alert("添加失败！");

            }
        }
        else
        {
            if (SimpleOrmOperator.Update(entity))
            {
                WebTools.Alert("修改成功！");
            }
            else
            {
                WebTools.Alert("修改失败！");

            }

        }
    }
    protected void imgPhoto_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnImgUpdate_Click(object sender, EventArgs e)
    {
        string sfzmhm=this.txtSfzmhm.Text.Trim();
        int size=this.FileUpload1.PostedFile.ContentLength;
        byte[] buffer=new byte[size];
        this.FileUpload1.PostedFile.InputStream.Read(buffer, 0, size);
         bool isOk= StudentApplyInfoOperator.UpdatePhoto(sfzmhm, buffer);
         if (isOk)
         {
             this.imgPhoto.ImageUrl = "ApplyInfoPhoto.aspx?idcard=" + sfzmhm;
         }
         else {
             WebTools.Alert("图片上传失败");
         }
        
    }
    protected void cbTjyy_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = this.cbTjyy.SelectedItem.Text.Trim();
        //this.txtTjyymc.Text = str ;
       
        int i = str.IndexOf("：");
        if (i != -1)
        {
            this.txtTjyymc.Text = str.Substring(i + 1);
        }
        else
        {
            this.txtTjyymc.Text = str+"-"+i;
        }
        
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty( Request.Params["id"]))
        {
            StudentApplyInfo entity = SimpleOrmOperator.Query<StudentApplyInfo>(Convert.ToInt32(Request.Params["id"]));
            entity.CheckDate = DateTime.Now.ToString("yyyy-MM-dd");
            entity.CheckOperator = this.Operator.OperatorName;
            if (StudentApplyInfoOperator.CheckInfo(entity, this.Operator.OperatorName))
            {
                WebTools.Alert(this, "资料审核通过！");
            }
            else
            {
                WebTools.Alert(this, "资料审核失败！");
            }
        }
    }

    protected void txtSfzmhm_TextChanged(object sender, EventArgs e)
    {
        string idcard = this.txtSfzmhm.Text.Trim();
        if (string.IsNullOrEmpty(idcard)||idcard.Length<18) {
            WebTools.Alert("身份证长度不足18位");
            //this.txtSfzmhm.Text="";
            this.txtSfzmhm.Focus();
            return;
        }
        string re = IDCardHelper.Validate(idcard);
        if (!string.IsNullOrEmpty(re)) {
            WebTools.Alert(re);
            this.txtSfzmhm.Focus();
        }
        string birthday= IDCardHelper.GetBirthday(idcard).ToString("yyyy-MM-dd");
        string sex = IDCardHelper.GetSexName(idcard)=="男"?"1":"2";
        this.txtCsrq.Value = birthday;
        this.cbXbValue.SelectedValue=sex;
    }



    protected void btnCheckImage_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Params["id"]))
        {
            StudentApplyInfo entity = SimpleOrmOperator.Query<StudentApplyInfo>(Convert.ToInt32(Request.Params["id"]));
            entity.CheckDate = DateTime.Now.ToString("yyyy-MM-dd");
            entity.CheckOperator = this.Operator.OperatorName;
            if (StudentApplyInfoOperator.CheckPhoto(entity))
            {
                WebTools.Alert(this, "图片审核通过！");
            }
            else
            {
                WebTools.Alert(this, "图片审核失败！");
            }
        }
    }
    protected void cbLxzsxzqhP_SelectedIndexChanged(object sender, EventArgs e)
    {
        string code = cbLxzsxzqhP.SelectedValue;

        cbLxzsxzqhC.Items.Clear();
        cbLxzsxzqhValue.Items.Clear();
        DrvQueryHelper.BindDDLCity(cbLxzsxzqhC, code);
        DrvQueryHelper.BindDDLArea(cbLxzsxzqhValue, cbLxzsxzqhC.SelectedValue);
    }
    protected void cbLxzsxzqhC_SelectedIndexChanged(object sender, EventArgs e)
    {
        string code = cbLxzsxzqhC.SelectedValue;
        cbLxzsxzqhValue.Items.Clear();
        DrvQueryHelper.BindDDLArea(cbLxzsxzqhValue, code);
    }
    protected void cbDjzsxzqhP_SelectedIndexChanged(object sender, EventArgs e)
    {
        string code = cbDjzsxzqhP.SelectedValue;

        cbDjzsxzqhC.Items.Clear();
        cbDjzsxzqhValue.Items.Clear();
        DrvQueryHelper.BindDDLCity(cbDjzsxzqhC, code);
        DrvQueryHelper.BindDDLArea(cbDjzsxzqhValue, cbDjzsxzqhC.SelectedValue);
    }
    protected void cbDjzsxzqhC_SelectedIndexChanged(object sender, EventArgs e)
    {
        string code = cbDjzsxzqhC.SelectedValue;
        cbDjzsxzqhValue.Items.Clear();
        DrvQueryHelper.BindDDLArea(cbDjzsxzqhValue, code);
    }
}
