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
using FT.Web.Tools;

public partial class FpSystem_UserControler_viewStudentInfo : System.Web.UI.UserControl
{
    public static string SESSION_STUDENT="student";


    protected void Page_Load(object sender, EventArgs e)
    {
        
        string lStrIDCard = "";
        if (Request.Params[FPSystemBiz.PARAM_RESULT] == null)
        {
            ///this.lbAlertMsg.Text = "没有该学员的指纹信息";
            return;
        }
        lStrIDCard = Request.Params[FPSystemBiz.PARAM_RESULT].ToString();
        if (string.IsNullOrEmpty(lStrIDCard))
        {
            this.lbAlertMsg.Text = "学员指纹信息不存在";
            WebTools.PlaySound("../../sound/学员指纹信息不存在.wav");
                return;
        }
        //int lIntResultCode = FPSystemBiz.fnIdendityStudentLesson(lStrIDCard);
        //lStrIDCard = "'" + lStrIDCard + "'";
        FpStudentObject fso = SimpleOrmOperator.Query<FpStudentObject>(lStrIDCard);
        //TempStudentInfo tempStudentInfo= DrvQueryHelper.QueryStudent(lStrIDCard);
        //FpStudentObject fso = new FpStudentObject();
        if (fso == null)
        {
            this.lbAlertMsg.Visible = true;
            this.lbAlertMsg.Text = "没有该学员的个人信息";
            return;
        }
        //fso.fromTempStudentInfo(tempStudentInfo);
        Session[SESSION_STUDENT] = fso;
        this.fnUILoadStudentRecord(fso,new TempStudentInfo());
         
    }

    private void fnUILoadStudentRecord(FpStudentObject fso ,TempStudentInfo tso)
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
            //fso.fromTempStudentInfo(tso);
            try {
                this.lbName.Text = fso.NAME;
              //  this.lbSex.Text = fso.SEX;/;
                this.lbIdCard.Text = fso.IDCARD;
              //  this.imgPerson.ImageUrl = string.Format("~/ShowImage.aspx?idcardtype=A&idcard={0}", fso.IDCARD);
               // this.lbIDCardType.Text = "第二代身份证";
              //  this.lbBrithday.Text = DateTimeHelper.fnIsNewDateTime(fso.BRITHDAY) ? "" : fso.BRITHDAY.ToString();
              //  this.lbPhone.Text = fso.PHONE;
              //  this.lbAddress.Text = fso.ADDRESS;
              //  this.lbDrvSchool.Text = fso.DRV_SCHOOL;
              //  this.lbDocNum.Text = fso.DRV_DOCNUM;
             //   this.lbDrvType.Text = fso.DRV_TYPE;
                this.lbRemark.Text = fso.REMARK;
                this.lbAlertMsg.Text = "";
                this.lbLsh.Text = fso.LSH;
                this.lbSchoolName.Text = fso.SCHOOL_NAME;
                this.lbStaute.Text = FpStudentObject.GetDictStatue()[fso.STATUE];
                this.lbFeeStatue.Text = fso.FEE_STATUE == "Y" ? "是" : "否";
                this.lbKm3Verify.Text = fso.KM3_VERIFY == "Y" ? "是" : "否";
                this.lbCarType.Text = fso.CAR_TYPE;
                FpLocalType localType=SimpleOrmOperator.Query<FpLocalType>(fso.LOCALTYPE);
                this.lbLocalType.Text = localType == null ? "" : localType.NAME;
            }
            catch (NullReferenceException nre) { 
                      
            }
        
        }
    }

    public void fnUILoadStudentRecord(FpStudentObject fso)
    {
 
            fnUILoadStudentRecord(fso,new TempStudentInfo());
        

    }


}
