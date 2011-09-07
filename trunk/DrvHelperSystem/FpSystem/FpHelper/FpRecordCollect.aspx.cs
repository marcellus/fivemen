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
using FT.DAL.Orm;
using FT.Commons.Tools;
using FT.WebServiceInterface.DrvQuery;

public partial class FpSystem_FpHelper_FpRecordCollect : System.Web.UI.Page
{

    private const string ACTION_NAME="ACTION_RECORD_COLLECT";
    private const int ACTION_NONE = 0;
    private const int ACTION_NEW_ENROLL_STUDENT = 1;
    private const int ACTION_VERIFY_STUDENT = 2;
    private const int ACTION_IDENTITY_STUDENT = 3;
    private FpBase _FP;

    public const string VS_TEMP_STUDENT = "tempStudent";
   

    protected void Page_Load(object sender, EventArgs e)
    {
        this._FP = new FpBase(this,new EventHandler(TrustLink_OperDlgPostEvent));
        if(Request.Params[FPSystemBiz.PARAM_RESULT]!=null)
        {
            //this.txtIDCard.Text=Request.Params[FPSystemBiz.PARAM_RESULT].ToString();
            if(Request.Params[FPSystemBiz.PARAM_RESULT]!=null){
                string qIdCard = Request.Params[FPSystemBiz.PARAM_RESULT].ToString();
                this.hidIDCard.Value = qIdCard;
                //FpStudentObject lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>("'"+qIdCard+"'");
                TempStudentInfo tempStudentInfo = DrvQueryHelper.QueryStudent(qIdCard);
                this.fnUIQuerySucess(tempStudentInfo != null);
                ucStudentInfo.fnUILoadStudentRecord(qIdCard);
                ViewState[VS_TEMP_STUDENT] = tempStudentInfo;
            }

    
        }
    }
    protected void btnQueryStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        string qIdCard = this.txtIDCard.Text;
        //FpStudentObject lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>("'" + qIdCard + "'");

        TempStudentInfo tempStudentInfo = DrvQueryHelper.QueryStudent(qIdCard);
        if (tempStudentInfo == null)
        {
            this.fnUIQuerySucess(false);
            return;
        }
        else
        {
            this.fnUIQuerySucess(true);
            Response.Redirect(string.Format("{0}?{1}={2}", Request.Url.AbsolutePath, FPSystemBiz.PARAM_RESULT, this.txtIDCard.Text));
        }
        

    }
    protected void btnVerifyStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        _FP.FpVerifyUser(this.txtIDCard.Text);
        Session[ACTION_NAME] = ACTION_VERIFY_STUDENT;
    }



    protected void btnNewEnrolStudent_Click(object sender, EventArgs e)
    {
        if (this.hidIDCard.Value.Length == 0)
            return;
        string lStrIDCard = this.hidIDCard.Value.Trim();
        if (_FP.FpNewUser(lStrIDCard) == 31)
            _FP.FpUpdateUser(lStrIDCard);
        Session[ACTION_NAME] = ACTION_NEW_ENROLL_STUDENT;
    }

    protected void btnIdentity_Click(object sender, EventArgs e)
    {
        _FP.FpIdentityUser();
        Session[ACTION_NAME] = ACTION_IDENTITY_STUDENT;
    }



    protected void btnSaveStudent_Click(object sender, EventArgs e)
    {
        if (this.hidIDCard.Value.Length == 0)
            return;
        string lStrIDCard = this.hidIDCard.Value.Trim();
        TempStudentInfo tso = ViewState[VS_TEMP_STUDENT] as TempStudentInfo;
        FpStudentObject fso = new FpStudentObject();
        fso.fromTempStudentInfo(tso);
        int localtype =StringHelper.fnFormatNullOrBlankInt(ddlLocaltype.SelectedValue);
        fso.LOCALTYPE = localtype;
        fso.STATUE = FpStudentObject.STATUE_NEW;
        if (FPSystemBiz.fnAddOrUpdateStudentRecord(fso))
        {
            fnUISaveStudentInfoSucess(true);
        }
        else {
            fnUISaveStudentInfoSucess(false);
        }
    }



    /// <summary>
    /// Process user action after operation fingerprint
    /// Notice: if don't process user operation fingerprint then use the TrustLinkGereralControler achieve the Result
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TrustLink_OperDlgPostEvent(object sender, EventArgs e)
    {
        ResultCodeArgs re = (ResultCodeArgs)e;
        string[] lArrUserIds = FpBase.getUserIds(re);
        FpStudentObject lObjStudent = null;
        int lIntAction =ACTION_NONE;
        if (Session[ACTION_NAME] == null)
            return;
        try {
            lIntAction = int.Parse(Session[ACTION_NAME].ToString());
        }catch(Exception ex)
        {
            lIntAction = ACTION_NONE;
        }
        switch (lIntAction)
        {
            case ACTION_NONE: break;
            case ACTION_NEW_ENROLL_STUDENT:
                string qIDCard = this.hidIDCard.Value;
                lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(qIDCard);
                if (lObjStudent == null)
                {
                    this.fnUINewEnrollStudentSucess(false);
                    return;
                }
                else
                {
                    this.fnUINewEnrollStudentSucess(true);
                }
                break;
            case ACTION_VERIFY_STUDENT:
                if (re.ResultCode == FpBase.SUCCESSED)
                {
                    this.fnUIVerifyStudentInfoSucess(true);
                }
                else
                {
                    this.fnUIVerifyStudentInfoSucess(false);
                }

                break;
            case ACTION_IDENTITY_STUDENT:
                if (lArrUserIds.Length < 1)
                {
                    //this.lbIdentityAlertMsg.Text = "没有该学员的指纹信息";
                    return;
                } lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(lArrUserIds[0].ToString());
                if (lObjStudent == null)
                {
                    this.lbIdentityAlertMsg.Text = "没有该学员的信息";
                    return;
                }
                Response.Redirect(string.Format("{0}?{1}={2}", Request.Url.AbsolutePath, FPSystemBiz.PARAM_RESULT, lArrUserIds[0].ToString()));
   
                this.btnSaveStudent.Visible = true;
                this.lbIdentityAlertMsg.Text = "";
                break;

        }
    }


    
    private void fnUIQuerySucess( Boolean bl)
    {
        if (bl)
        {
            this.lbQueryAlertMsg.Text = "";
            this.btnSaveStudent.Visible = true;
            this.ddlLocaltype.Visible = true;
            ArrayList listLoacaltype;
            if (ViewState["listLocalType"] == null)
            {
                listLoacaltype = SimpleOrmOperator.QueryConditionList<FpLocalType>("");
                ViewState["listLocalType"] = listLoacaltype;
                ddlLocaltype.DataSource = listLoacaltype;
                ddlLocaltype.DataTextField = "NAME";
                ddlLocaltype.DataValueField = "ID";
                ddlLocaltype.DataBind();
            }
           // else {
           //     listLoacaltype = ViewState["listLocalType"] as ArrayList;
         //   }
          //  int ddlIndex = ddlLocaltype.SelectedIndex;

           // ddlLocaltype.SelectedIndex = ddlIndex;
            
        }
        else
        {
 
            this.lbQueryAlertMsg.Text = "没有该学员的信息";
            this.btnSaveStudent.Visible = false;
        }
    }

    private void fnUISaveStudentInfoSucess(Boolean bl)
    {
        if (bl)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员信息保存成功，可进行指纹采集";
            this.btnNewEnrolStudent.Visible = true;
        }
        else
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员信息保存失败";
            this.btnNewEnrolStudent.Visible = true;
            this.btnNewEnrolStudent.Visible = false;
        }
    }

    private void fnUINewEnrollStudentSucess(Boolean bl)
    {
        if (bl)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员指纹采集成功";
            this.btnVerifyStudent.Visible = false;
        }
        else
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员指纹采集失败";
            this.btnVerifyStudent.Visible = false;
        }
    }


    private void fnUIVerifyStudentInfoSucess(Boolean bl)
    {
        if (bl)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员指纹匹配正确";
            this.btnVerifyStudent.Visible = false;
        }
        else
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员指纹匹配错误";
        }
    }


    /**
    private void fnUISetStudentInfo(FpStudentObject fso)
    {
        this.lbXm.Text = fso.NAME;
        this.lbIdCard.Text = fso.IDCARD;
    }
    **/

    protected void btnClearStudent_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsolutePath);
    }
}
