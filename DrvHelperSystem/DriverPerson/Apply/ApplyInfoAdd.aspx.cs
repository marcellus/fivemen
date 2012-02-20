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

    string sqlPattern = "select "
+ " (select dmsm1 from trff_app.frm_code where dmz=concat(substr(t.dmz,0,2),'0000') and dmlb='0033' ) as sf "
+ ",(select dmsm1 from trff_app.frm_code where dmz=concat(substr(t.dmz,0,4),'00') and dmlb='0033' ) as cs "
+ ", dmz,dmsm1 "
+ " from trff_app.frm_code t where dmlb='0033' and dmz = '{0}' ";


    private static string getDefaultCityCode() {
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
            hidJxdm.Value = this.Operator.Desp3;
            foreach (ListItem li in this.cbTjyy.Items) {
                if (li.Value.StartsWith(getDefaultCityCode())) {
                    tjyys.Add(li);
                }
            }
            
    
            this.cbTjyy.Items.Clear();
            foreach (ListItem li in tjyys) {
                this.cbTjyy.Items.Add(li);
            }
            this.cbTjyy.Items.Add(new ListItem("深圳恒生龙安医院", "440300000037"));
            this.cbTjyy.Items.Add(new ListItem("深圳市职业病防治院", "440300000038"));

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
            this.cbDjzsxzqhValue.Items.Clear();

            foreach (ListItem li in xzqhs)
            {
                //this.cbXzqhValue.Items.Add(new ListItem(li.Text,li.Value));
                this.cbLxzsxzqhValue.Items.Add(new ListItem(li.Text, li.Value));
                this.cbXzqhValue.Items.Add(new ListItem(li.Text, li.Value));
                this.cbDjzsxzqhValue.Items.Add(new ListItem(li.Text, li.Value));

            }
            

            DrvQueryHelper.BindDropDownListLy(this.cbLyValue);
            DrvQueryHelper.BindDropDownListZkcx(this.cbZkcxValue);
            DrvQueryHelper.BindDropDownListNational(this.cbGjValue);
            //DrvQueryHelper.BindDropDownListLocalArea(this.cbDjzsxzqhValue);
            //DrvQueryHelper.BindDropDownListLocalArea(this.cbLxzsxzqhValue);
            this.cbGjValue.SelectedValue = "156";
            this.cbDjzsxzqhValue.Items.Add(new ListItem("外地", "000000"));
            if (!string.IsNullOrEmpty( Request.Params["id"]))
            {
                StudentApplyInfo entity = SimpleOrmOperator.Query<StudentApplyInfo>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
                this.txtTjrq.Value = entity.Tjrq;
                this.txtCsrq.Value = entity.Csrq;
                //this.cbDjzsxzqhValue.Items.Clear();
                //this.cbDjzsxzqhValue.Items.Add(new ListItem(entity.Djzsxzqh, entity.Djzsxzqh));
                //this.cbDjzsxzqhValue.Items.Clear();
                //this.cbDjzsxzqhValue.Text = entity.Djzsxzqh;
                this.imgPhoto.ImageUrl = "ApplyInfoPhoto.aspx?idcard=" + entity.Sfzmhm;
                this.cbBustype.SelectedValue = entity.PhotoSrc;
                if (this.cbDjzsxzqhValue.Items.FindByValue(entity.Djzsxzqh) == null)
                {
                    //this.cbDjzsxzqhValue.Items.Add(new ListItem("外地", entity.Lxzsxzqh));
                    this.cbDjzsxzqhValue.SelectedValue = entity.Djzsxzqh;
                }
                else {
                    
                }
                this.hidDjzsxzqh.Value = entity.Djzsxzqh;
                
            }
            else {
                this.imgPhoto.ImageUrl = "~/images/no_photo.jpg";
                //this.cbLxzsxzqhValue.SelectedValue = "440500";
                //this.cbXzqhValue.SelectedValue = "440500";
                //this.cbDjzsxzqhValue.SelectedValue = "440500";
                this.txtYsl.Text="5.0";
                this.txtZsl.Text = "5.0";
                this.cbZkcxValue.SelectedValue = "C1";
                this.txtLxzsyzbm.Text = "510000";
                
            }

            if (string.IsNullOrEmpty( Request.Params["allowcheck"]))
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
        
       // if (!string.IsNullOrEmpty(Request.Params["cbDjzsxzqhValue"]))
       // {
       //     entity.Djzsxzqh = Request.Params["cbDjzsxzqhValue"];
       // }
        entity.Djzsxzqh = this.hidDjzsxzqh.Value;
        
        entity.CheckDate = DateTime.Now.ToString("yyyy-MM-dd");
       // entity.DepName = this.cbDepCodeValue.SelectedItem.Text;
        entity.Jxdm = this.Operator.Desp3;
        entity.Jxmc = this.Operator.Desp3;
        if (entity.Id < 0)
        {
           
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
    protected void cbDjzsxzqhValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (string.IsNullOrEmpty(cbDjzsxzqhValue.SelectedValue)) {
            txtDjzsxxdz.Text = "广东省";
            return;
        }
        string sql = string.Format(sqlPattern, cbDjzsxzqhValue.SelectedValue);
         DataTable dt = WholeWebConfig.GetDrvIDataAccessDecode().SelectDataTable(sql, "tmp");
         if (dt == null) return;
         try
         {
             string sf = dt.Rows[0]["sf"].ToString();
             string cs = dt.Rows[0]["cs"].ToString();
             string dmsm1 = dt.Rows[0]["dmsm1"].ToString();
             txtDjzsxxdz.Text = string.Format("{0}{1}{2}", sf, cs, dmsm1);
             this.hidDjzsxzqh.Value = cbDjzsxzqhValue.SelectedValue;
         }
         catch (Exception ex) { }
        
    }
    protected void cbLxzsxzqhValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (string.IsNullOrEmpty(cbLxzsxzqhValue.SelectedValue))
        {
            txtLxzsxxdz.Text = "广东省";
            return;
        }
        string sql = string.Format(sqlPattern, cbLxzsxzqhValue.SelectedValue);
        DataTable dt = WholeWebConfig.GetDrvIDataAccessDecode().SelectDataTable(sql, "tmp");
        if (dt == null) return;
        try
        {
            string sf = dt.Rows[0]["sf"].ToString();
            string cs = dt.Rows[0]["cs"].ToString();
            string dmsm1 = dt.Rows[0]["dmsm1"].ToString();
            txtLxzsxxdz.Text = string.Format("{0}{1}{2}", sf, cs, dmsm1);
        }
        catch (Exception ex) { }
        }
}
