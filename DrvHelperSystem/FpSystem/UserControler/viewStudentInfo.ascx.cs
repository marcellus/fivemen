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
using FT.WebServiceInterface.DrvQuery;

public partial class FpSystem_UserControler_viewStudentInfo : System.Web.UI.UserControl
{
    public static string SESSION_STUDENT="student";


    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        string lStrIDCard = "";
        if (Request.Params[FPSystemBiz.PARAM_RESULT] == null)
          return ;
        lStrIDCard = Request.Params[FPSystemBiz.PARAM_RESULT].ToString();
        if (lStrIDCard.Length < 1)
        {
            this.lbAlertMsg.Text = "没有该学员的指纹信息";
                return;
        }
        //int lIntResultCode = FPSystemBiz.fnIdendityStudentLesson(lStrIDCard);
        //lStrIDCard = "'" + lStrIDCard + "'";
        //FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(lStrIDCard);
        TempStudentInfo tempStudentInfo= DrvQueryHelper.QueryStudent(lStrIDCard);
        FpStudentObject fso = new FpStudentObject();
        if (tempStudentInfo == null)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "没有该学员的个人信息";
            return;
        }
        fso.fromTempStudentInfo(tempStudentInfo);
        Session[SESSION_STUDENT] = fso;
        this.fnUILoadStudentRecord(fso,tempStudentInfo);
         */
    }

    private void fnUILoadStudentRecord(FpStudentObject fso,TempStudentInfo tso)
    {
        
        if (fso == null) {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "没有该学员的指纹记录信息";
        }
        else if (tso == null)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "没有该学员的个人信息";
        }
        else {
            fso.fromTempStudentInfo(tso);
            try {
                this.lbName.Text = fso.NAME;
                this.lbSex.Text = fso.SEX;
                this.lbIdCard.Text = fso.IDCARD;
                this.imgPerson.ImageUrl = string.Format("~/ShowImage.aspx?idcardtype=A&idcard={0}", fso.IDCARD);
                this.lbIDCardType.Text = "第二代身份证";
                this.lbBrithday.Text = DateTimeHelper.fnIsNewDateTime(fso.BRITHDAY) ? "" : fso.BRITHDAY.ToString();
                this.lbPhone.Text = fso.PHONE;
                this.lbAddress.Text = fso.ADDRESS;
                this.lbDrvSchool.Text = fso.DRV_SCHOOL;
                this.lbDocNum.Text = fso.DRV_DOCNUM;
                this.lbDrvType.Text = fso.DRV_TYPE;
                this.lbRemark.Text = fso.REMARK;
                this.lbAlertMsg.Text = "";
 
            }
            catch (NullReferenceException nre) { 
                      
            }
        
        }
    }

    public void fnUILoadStudentRecord(string idcard)
    {
        idcard = StringHelper.fnFormatNullOrBlankString(idcard, "");
        if (idcard != "") {
            TempStudentInfo tempStudentInfo = DrvQueryHelper.QueryStudent(idcard);
            FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>("'"+idcard+"'");
            fnUILoadStudentRecord(fso,tempStudentInfo);
        }

    }


}
