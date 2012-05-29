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
using FT.Web;
using wsFinger;
using wsUser;

public partial class FpSystem_FpHelper_FpRecordCollect2 : AuthenticatedPage
{


    public enum Key { 
      agentInfo,userId,fingers
    }

    private const string ACTION_NAME = "ACTION_RECORD_COLLECT";
    private const int ACTION_NONE = 0;
    private const int ACTION_NEW_ENROLL_STUDENT = 1;
    private const int ACTION_VERIFY_STUDENT = 2;
    private const int ACTION_IDENTITY_STUDENT = 3;
    private wsFinger.wsFingerImplService wsFingerM = new wsFinger.wsFingerImplService();
    private wsUser.wsUserImplService wsUserM = new wsUser.wsUserImplService();
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

            DepartMentOperator.Bind2(ddlSchool);
            ddlSchool.SelectedValue = "440400";

            DictOperator.BindDropDownList("车辆类型", ddlCarType);

            string strTmp=Request.Params["strTmp"];
            if (!string.IsNullOrEmpty(strTmp)) {
                int result = wsFingerM.wsFPEnroll(strTmp);
                this.fnUINewEnrollStudentSucess(result == FpBase.SUCCESSED);
            }
        }
        ///WebTools.PlaySound("../../sound/test1.wav");
        //WebTools.PlayBackGroupSound("孙燕姿-02.追.是时候.mp3", 1);
        //Response.Write("<bgsound loop=1 src='孙燕姿-02.追.是时候.mp3' />");
        //WebTools.WriteScript("alert('hhlin');");
        //WebTools.PlaySound("孙燕姿-02.追.是时候.mp3");
       // BeepHelper.Beep(800,8000);
        
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
        else if ( txtLsh.Text.Trim().Length < 13) {
            WebTools.Alert("受理号不能少于13位");
            return;
        }
   
        FpStudentObject fso = new FpStudentObject();
        fso.IDCARD = lStrIDCard;
        int localtype = StringHelper.fnFormatNullOrBlankInt(ddlLocaltype.SelectedValue);
        fso.LOCALTYPE = localtype;
        fso.NAME = txtName.Text;
        fso.STATUE = FpStudentObject.STATUE_NEW;
        fso.LSH=txtLsh.Text;
        fso.SCHOOL_CODE = ddlSchool.SelectedValue;
        fso.SCHOOL_NAME = ddlSchool.SelectedItem.Text;
        fso.CAR_TYPE = ddlCarType.SelectedValue;
        fso.CREATE_TIME = DateTime.Now;
        fso.LASTMODIFY_TIME = DateTime.Now;
        fso.BL_IND = cbBlInd.Checked ? "Y" : "N";
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

        Response.Redirect("~/FpSystem/FpV52/reg_finger.aspx?strreg=" + lStrIDCard);
       // string script = string.Format(" document.forms[0].UCtrl.SetAgentInfo('{0}');", ViewState[Key.agentInfo.ToString()].ToString());
        //script += string.Format("strTmp = document.forms[0].UCtrl.EnrollByPwdExport('{0}', '{1}', '', 0, 0, 'sa', 'sa');", ViewState[Key.userId.ToString()].ToString(), ViewState[Key.fingers.ToString()].ToString());
        //script += "strTmp = UrlEncode(strTmp);";
        //script += " window.location.search = '?strTmp=' + strTmp;";
        //WebTools.WriteScript("try{" +script+"}catch(ex){alert(ex);}");
       // int re=_FP.FpNewUser(lStrIDCard);
        //if (re !=FpBase.SUCCESSED)
       // {
           
       //     _FP.FpUpdateUser(lStrIDCard);
       // }
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
                lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(qIDCard);
                if (lObjStudent == null)
                {
                    this.fnUINewEnrollStudentSucess(false);
                    return;
                }
                else
                {
                    lObjStudent.STATUE = FpStudentObject.STATUE_COLLECT;
                    //FPSystemBiz.fnAddOrUpdateStudentRecord(lObjStudent);
                    this.fnUINewEnrollStudentSucess(SimpleOrmOperator.Update(lObjStudent));
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
            /*
            ViewState[Key.userId.ToString()] = this.txtIDCard.Text.Trim();
            ViewState[Key.agentInfo.ToString()] = wsFingerM.wsGetAgentInfo();//获取系统信息
            this.username.Value = ViewState[Key.userId.ToString()].ToString();
            int wsIsUserExisted_re = wsUserM.wsIsUserExisted(ViewState[Key.userId.ToString()].ToString());
            if (wsIsUserExisted_re == 1)
            {
                int wsAddUserByPwd_re = wsUserM.wsAddUserByPwd(ViewState[Key.userId.ToString()].ToString(), "sa", "sa");
                ViewState[Key.fingers.ToString()] = "";
                if (wsAddUserByPwd_re != 0)
                {
                    WebTools.Alert("添加失败！");
                }
            }
            else
            {
                ViewState[Key.fingers.ToString()] = wsFingerM.wsGetEnrolledFingersInResult(ViewState[Key.userId.ToString()].ToString(), "31");//获取该用户注册的指头 设备类型31
            }
             * */
        }
        else
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员信息保存失败";
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

    protected void btnQueryStuent_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtIDCard.Text)) {
            WebTools.Alert("证件号码不能为空");
            return;
        }
        FpStudentObject student = SimpleOrmOperator.Query<FpStudentObject>(txtIDCard.Text);
        if (student == null)
        {
            WebTools.Alert(string.Format("身份证号码:{0} 未录入", txtIDCard.Text));
        }
        else {

            txtLsh.Text = student.LSH;
            txtName.Text = student.NAME;
            ddlLocaltype.SelectedValue = student.LOCALTYPE.ToString();
            ddlSchool.SelectedValue = student.SCHOOL_CODE;
            ddlCarType.SelectedValue = student.CAR_TYPE;
            cbBlInd.Checked = student.BL_IND == "Y";
        }

    }
   
}
