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

public partial class FpSystem_FpHelper_FpRecordCollect : System.Web.UI.Page
{

    private const string ACTION_NAME="ACTION_RECORD_COLLECT";
    private const int ACTION_NONE = 0;
    private const int ACTION_NEW_ENROLL_STUDENT = 1;
    private const int ACTION_VERIFY_STUDENT = 2;
    private FpBase _FP;
    

   

    protected void Page_Load(object sender, EventArgs e)
    {
        this._FP = new FpBase(this,new EventHandler(TrustLink_OperDlgPostEvent));
    }
    protected void btnQueryStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        FpStudentObject lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(this.txtIDCard.Text);
        if (lObjStudent == null)
            return;
        this.lbXm.Text = lObjStudent.NAME;
        this.btnSaveStudent.Visible = true;
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
        if (this.txtIDCard.Text.Length == 0)
            return;
        string lStrIDCard = this.txtIDCard.Text.Trim();
        if (_FP.FpNewUser(lStrIDCard) == 31)
            _FP.FpUpdateUser(lStrIDCard);
        Session[ACTION_NAME] = ACTION_NEW_ENROLL_STUDENT;
    }



    protected void btnSaveStudent_Click(object sender, EventArgs e)
    {
        if (this.txtIDCard.Text.Length == 0)
            return;
        string lStrIDCard = this.txtIDCard.Text.Trim();
        FpStudentObject lObjStu = new FpStudentObject();
        lObjStu.IDCARD = this.txtIDCard.Text.Trim();
        lObjStu.NAME = "hhlin";
        if (FPSystemBiz.fnAddOrEditStudentRecord(lObjStu))
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "学员信息保存成功，可进行指纹采集";
            this.btnNewEnrolStudent.Visible = true;
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
        string strMessage = re.ResultMessage;
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
                 lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(this.txtIDCard.Text);
                if (lObjStudent == null)
                   return;
                this.lbAlertMsg.Visible = true;
                this.lbAlertMsg.Text = "学员:" + lObjStudent.NAME + "  " + lObjStudent.IDCARD + "  指纹采集成功";
                break;
            case ACTION_VERIFY_STUDENT:
                lObjStudent = FT.DAL.Orm.SimpleOrmOperator.Query<FpStudentObject>(this.txtIDCard.Text);
                if (lObjStudent == null)
                    return;
                this.lbXm.Text = lObjStudent.NAME;
                break;
        }
    }
}
