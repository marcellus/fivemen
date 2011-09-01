using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.DAL.Orm;
using FT.Web.Tools;
using FT.WebServiceInterface.DrvQuery;
using System.Collections;

public partial class FpSystem_FpHelper_FpRecordCollect2 : System.Web.UI.Page
{
    private const string ACTION_NAME = "ACTION_RECORD_COLLECT";
    private const int ACTION_NONE = 0;
    private const int ACTION_NEW_ENROLL_STUDENT = 1;
    private const int ACTION_VERIFY_STUDENT = 2;
    private const int ACTION_IDENTITY_STUDENT = 3;

    private FpBase _FP;

    protected void Page_Load(object sender, EventArgs e)
    {
        this._FP = new FpBase(this, new EventHandler(TrustLink_OperDlgPostEvent));
        if (!IsPostBack) {
            ArrayList listLoacaltype = SimpleOrmOperator.QueryConditionList<FpLocalType>("");
            ddlLocaltype.DataSource = listLoacaltype;
            ddlLocaltype.DataTextField = "NAME";
            ddlLocaltype.DataValueField = "ID";
            ddlLocaltype.DataBind();
        }
        //WebTools.PlayBackGroupSound("孙燕姿-02.追.是时候.mp3", 1);
        //Response.Write("<bgsound loop=1 src='孙燕姿-02.追.是时候.mp3' />");
        //WebTools.WriteScript("alert('hhlin');");
        //WebTools.PlaySound("孙燕姿-02.追.是时候.mp3");
        BeepHelper.Beep(800,8000);
        
    }
    protected void btnSaveStudent_Click(object sender, EventArgs e)
    {

        string lStrIDCard = StringHelper.fnFormatNullOrBlankString(this.txtIDCard.Text,"");
        if (lStrIDCard == "") {
            WebTools.Alert("身份证号码不能为空");
            return;
        }else if((lStrIDCard.Length==15||lStrIDCard.Length==18)){
            string re=IDCardHelper.Validate(lStrIDCard);
            if(re!=string.Empty){
              WebTools.Alert(re);
                return;
            }
        }
   
        FpStudentObject fso = new FpStudentObject();
        fso.IDCARD = lStrIDCard;
        int localtype = StringHelper.fnFormatNullOrBlankInt(ddlLocaltype.SelectedValue);
        fso.LOCALTYPE = localtype;
        fso.STATUE = FpStudentObject.STATUE_NEW;
        if (FPSystemBiz.fnAddOrUpdateStudentRecord(fso))
        {
            fnUISaveStudentInfoSucess(true);
        }
        else
        {
            fnUISaveStudentInfoSucess(false);
        }
    }
    protected void btnNewEnrolStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        string lStrIDCard = this.txtIDCard.Text.Trim();
        if (_FP.FpNewUser(lStrIDCard) == 31)
            _FP.FpUpdateUser(lStrIDCard);
        Session[ACTION_NAME] = ACTION_NEW_ENROLL_STUDENT;
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
        int lIntAction = ACTION_NONE;
        if (Session[ACTION_NAME] == null)
            return;
        try
        {
            lIntAction = int.Parse(Session[ACTION_NAME].ToString());
        }
        catch (Exception ex)
        {
            lIntAction = ACTION_NONE;
        }
        switch (lIntAction)
        {
            case ACTION_NONE: break;
            case ACTION_NEW_ENROLL_STUDENT:
                string qIDCard = this.txtIDCard.Text;
                lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>("'" + qIDCard + "'");
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

}
