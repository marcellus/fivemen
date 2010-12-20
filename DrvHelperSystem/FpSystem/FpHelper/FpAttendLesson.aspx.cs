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
using FT.DAL.Orm;


public partial class FpSystem_FpHelper_FpAttendLesson : System.Web.UI.Page
{
    private FpBase _FP;

    protected void Page_Load(object sender, EventArgs e)
    {
       if( IsPostBack)
           _FP = new FpBase(this, new EventHandler(FpVerifyHandler),true);
       
    }

    private void FpVerifyHandler(object o, EventArgs e)
    {
        ResultCodeArgs re = (ResultCodeArgs)e;
        //this.lbUserID.Text = re.ResultCode + ":" + re.ResultMessage;

        string[] msgs = re.ResultMessage.Split(';');
        if (msgs.Length == 0)
            return;
        string idcard = msgs[0];
       idcard=idcard.Substring(0,idcard.LastIndexOf('_'));
       FpStudentObject fos= FPSystemBiz.fnIdendityStudentLesson(idcard);
       if (fos != null)
       {
           this.lbStrName.Text = fos.NAME;
           this.lbStuIdCard.Text = fos.IDCARD;
           this.lbStuLessonEnter1.Text = fos.LESSON_ENTER_1.ToString();
           this.lbStuLessonLeave1.Text = fos.LESSON_LEAVE_1.ToString();
           this.lbStuLessonEnter2.Text = fos.LESSON_ENTER_2.ToString();
           this.lbStuLessonLeave2.Text = fos.LESSON_LEAVE_2.ToString();
       }
       
    }


    protected void btnIdentity_Click(object sender, EventArgs e)
    {

        _FP.FpIdentityUser();

    }
}
