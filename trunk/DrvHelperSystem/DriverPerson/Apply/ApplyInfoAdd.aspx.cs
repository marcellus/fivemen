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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DrvQueryHelper.BindDropDownListSfzmmc(this.cbSfzmmcValue);
            DrvQueryHelper.BindDropDownListHospital(this.cbTjyy);

            DrvQueryHelper.BindDropDownListLocalArea(this.cbXzqhValue);
            DrvQueryHelper.BindDropDownListLy(this.cbLyValue);
            DrvQueryHelper.BindDropDownListZkcx(this.cbZkcxValue);
            DrvQueryHelper.BindDropDownListNational(this.cbGjValue);
            DrvQueryHelper.BindDropDownListLocalArea(this.cbDjzsxzqhValue);
            DrvQueryHelper.BindDropDownListLocalArea(this.cbLxzsxzqhValue);
            this.cbGjValue.SelectedValue = "156";

            if (Request.Params["id"] != null)
            {
                StudentApplyInfo entity = SimpleOrmOperator.Query<StudentApplyInfo>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
                this.txtTjrq.Value = entity.Tjrq;
                this.txtCsrq.Value = entity.Csrq;
                //this.cbDjzsxzqhValue.Items.Add(entity.Djzsxzqh, entity.Djzsxzqh);
                this.cbDjzsxzqhValue.Items.Clear();
                this.cbDjzsxzqhValue.SelectedValue = entity.Djzsxzqh;
                
            }

            if (Request.Params["allowcheck"] == null)
            {
                this.btnCheck.Visible = false;
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
        StudentApplyInfoOperator.UpdatePhoto(sfzmhm, buffer);
        this.imgPhoto.ImageUrl = "ApplyInfoPhoto.aspx?idcard="+sfzmhm;

        
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
            if (StudentApplyInfoOperator.CheckInfoAndPhoto(entity, this.Operator.OperatorName))
            {
                WebTools.Alert(this, "审核通过！");
            }
            else
            {
                WebTools.Alert(this, "审核失败！");
            }
        }
    }
}
