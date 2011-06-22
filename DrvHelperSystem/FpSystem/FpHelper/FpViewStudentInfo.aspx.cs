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
using FT.Commons.Tools;
using FT.DAL.Orm;

public partial class FpSystem_FpHelper_FpViewStudentInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params[FPSystemBiz.PARAM_RESULT] == null)
            return;
        string lStrIDCard = Request.Params[FPSystemBiz.PARAM_RESULT].ToString();
        if (lStrIDCard.Length < 1)
        {
            return;
        }
        int lIntResultCode = FPSystemBiz.fnIdendityStudentLesson(lStrIDCard);
        FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>("'"+lStrIDCard+"'");
        if (fso == null)
        {
            this.lbAlertMsg.Text = "没有该学员的个人信息";
            return;
        }
        this.fnUILoadStudentRecord(fso, lIntResultCode);
    }

    private void fnUILoadStudentRecord(FpStudentObject fso, int lIntResultCode)
    {
        this.lbName.Text = fso.NAME;
        this.lbSex.Text = fso.SEX;
        this.lbIdCard.Text = fso.IDCARD;
        this.lbIDCardType.Text = "第二代身份证";
        this.lbBrithday.Text = DateTimeHelper.fnIsNewDateTime(fso.BRITHDAY)?"":fso.BRITHDAY.ToString();
        this.lbPhone.Text = fso.PHONE;
        this.lbAddress.Text = fso.ADDRESS;
        this.lbDrvSchool.Text = fso.DRV_SCHOOL;
        this.lbDocNum.Text = fso.DRV_DOCNUM;
        this.lbDrvType.Text = fso.DRV_TYPE;
        this.lbRemark.Text = fso.REMARK;
        this.lbAlertMsg.Text = "指纹验证成功";
        this.lbAlertMsg.Visible = true;
 
    }
}
