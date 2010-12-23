using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using FT.DAL;
using FT.Commons.Tools;

/// <summary>
///FPSystemBiz 的摘要说明
/// </summary>
public class FPSystemBiz
{
    public static string PARAM_RESULT = "identityResult";
    private static int LESSON_ENTER_1_NEXT_MINUTE = 45;
    private static int LESSON_ENTER_2_NEXT_MINUTE = 45;

    public static readonly int CHECHIN_NO_RECARD = -2;
    public static readonly int CHECKIN_FAILE = -1;
    public static readonly int CHECKIN_SUCCESS = 0;
    public static readonly int LESSON_ENTER_1_FAILE = 1;
    public static readonly int LESSON_ENTER_2_FAILE = 2;
    public static readonly int LESSON_LEAVE_2_FAILE = 3;
    public static readonly int CHECK_SAMEDAY_FAILE = 4;



    public FPSystemBiz()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region 业务方法，供页面调用

    //添加或修改一条学员记录
    public static Boolean fnAddOrEditStudentRecord(FpStudentObject fso)
    {
        if (fso == null || fso.IDCARD.Length < 1 || fso.NAME.Length < 1)
            return false;
        if (fnStundentUdpate(fso))
        {
            return true;
        }
        else if (fnStundentInsert(fso))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public static Boolean fnRemoveStudentRecord(FpStudentObject fso)
    {
        return fnStudentDelete(fso);
    }

 

    //记录学员上课时间
    public static int fnIdendityStudentLesson(String pStrIdCard)
    {
        //FT.DAL.Orm.SimpleOrmOperator.QueryList
        int lIntReturn = CHECKIN_FAILE;
        FpStudentObject fso = null;
        ArrayList lArrStu= FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<FpStudentObject>("where idcard='"+pStrIdCard+"'");
        if (lArrStu.Count != 1)
            return CHECHIN_NO_RECARD;
        fso = lArrStu[0] as FpStudentObject;
        bool lBlResult = false;
        DateTime lDtIdentity=DateTime.Now;
        string lStrUpdateSql = "update fp_student set {0}=TO_DATE('{1}','yyyy-mm-dd hh24:mi:ss') where idcard='{2}'";
        string lStrUpdateSqlClearRecord = "update fp_student set LESSON_ENTER_1=null,LESSON_ENTER_2=null,LESSON_LEAVE_2=null where idcard='{0}'";
        string lStrParm0=null;
        string lStrParm1= lDtIdentity.ToString();
        string lStrParm2 = fso.IDCARD;
        string lStrPrfLESSON_ENTER = "LESSON_ENTER";
        string lStrPrfLESSON_LEAVE = "LESSON_LEAVE";

       
        if (DateTimeHelper.fnIsNewDateTime(fso.LESSON_ENTER_1) )
        {
            lStrParm0 = lStrPrfLESSON_ENTER+"_1";
            lIntReturn = CHECKIN_SUCCESS;
        }
        else if (!fnIsVaildTime(fso.LESSON_ENTER_1, lDtIdentity, 0))
        {
            lStrUpdateSqlClearRecord = string.Format(lStrUpdateSqlClearRecord,lStrParm2);
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSqlClearRecord);
            lIntReturn = LESSON_ENTER_1_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.LESSON_ENTER_2))
        {
            if (fnIsVaildTime(fso.LESSON_ENTER_1, lDtIdentity, LESSON_ENTER_1_NEXT_MINUTE))
            {
                lStrParm0 = lStrPrfLESSON_ENTER + "_2";
                lIntReturn = CHECKIN_SUCCESS;
            }
            else
            {
                lIntReturn = LESSON_ENTER_2_FAILE;
            }
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.LESSON_LEAVE_2))
        {
            if (fnIsVaildTime(fso.LESSON_ENTER_2, lDtIdentity, LESSON_ENTER_2_NEXT_MINUTE))
            {
                lStrParm0 = lStrPrfLESSON_LEAVE + "_2";
                lIntReturn = CHECKIN_SUCCESS;
            }
            else
            {
                lIntReturn = LESSON_LEAVE_2_FAILE;
            }
        }

        if (lStrParm0 != null)
        {
            lStrUpdateSql = string.Format(lStrUpdateSql, lStrParm0, lStrParm1, lStrParm2);
            lBlResult=FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSql);
        }

        return lIntReturn;
    }

    //记录学员入场训练时间
    public static int fnIdendityStudentTrain(String pStrIdCard)
    {
        //FT.DAL.Orm.SimpleOrmOperator.QueryList
        int lIntReturn = CHECKIN_FAILE;
        FpStudentObject fso = null;
        ArrayList lArrStu = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<FpStudentObject>("where idcard='" + pStrIdCard + "'");
        if (lArrStu.Count != 1)
            return CHECHIN_NO_RECARD;
        fso = lArrStu[0] as FpStudentObject;
        bool lBlResult = false;
        DateTime lDtIdentity = DateTime.Now;
        string lStrUpdateSql = "update fp_student set {0}=TO_DATE('{1}','yyyy-mm-dd hh24:mi:ss') where idcard='{2}'";
        string lStrUpdateSqlClearRecord = "update fp_student set LESSON_ENTER_1=null,LESSON_ENTER_2=null,LESSON_LEAVE_2=null where idcard='{0}'";
        string lStrParm0 = null;
        string lStrParm1 = lDtIdentity.ToString();
        string lStrParm2 = fso.IDCARD;
        string lStrPrfTRAIN_ENTER = "TRAIN_ENTER";
        string lStrPrfTRAIN_LEAVE = "TRAIN_LEAVE";


        if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_1)||DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_1))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_1)|| !fnIsVaildTime(fso.TRAIN_ENTER_1,lDtIdentity) )
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; }
            else
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_1"; }
            
        }
        else if(fnIsVaildTime(fso.TRAIN_ENTER_1, lDtIdentity))
        {
           lIntReturn=CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_2) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_2))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_2) || !fnIsVaildTime(fso.TRAIN_ENTER_2, lDtIdentity))
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_2"; }
            else
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_2"; }
        }
        else if(fnIsVaildTime(fso.TRAIN_ENTER_2, lDtIdentity))
        {
           lIntReturn=CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_3) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_3))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_3) || !fnIsVaildTime(fso.TRAIN_ENTER_3, lDtIdentity))
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_3"; }
            else
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_3"; }
        }
        else if(fnIsVaildTime(fso.TRAIN_ENTER_3, lDtIdentity))
        {
           lIntReturn=CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_4) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_4))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_4) || !fnIsVaildTime(fso.TRAIN_ENTER_4, lDtIdentity))
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_4"; }
            else
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_4"; }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_4, lDtIdentity))
        {
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_5) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_5))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_5) || !fnIsVaildTime(fso.TRAIN_ENTER_5, lDtIdentity))
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_5"; }
            else
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_5"; }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_5, lDtIdentity))
        {
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_6) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_6))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_6) || !fnIsVaildTime(fso.TRAIN_ENTER_6, lDtIdentity))
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_6"; }
            else
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_6"; }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_6, lDtIdentity))
        {
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_7) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_7))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_7) || !fnIsVaildTime(fso.TRAIN_ENTER_7, lDtIdentity))
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_7"; }
            else
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_7"; }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_7, lDtIdentity))
        {
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_8) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_8))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_8) || !fnIsVaildTime(fso.TRAIN_ENTER_8, lDtIdentity))
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_8"; }
            else
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_8"; }
        }

        if (lStrParm0 != null)
        {
            lStrUpdateSql = string.Format(lStrUpdateSql, lStrParm0, lStrParm1, lStrParm2);
            lBlResult = FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSql);
            lIntReturn = CHECKIN_SUCCESS;
        }

        return lIntReturn;
    }


    #endregion


    #region 数据库操作，私有

    private static Boolean fnStundentInsert(FpStudentObject fso)
    {
        string lStrInsert = "insert into fp_student (idcard,name) values ('{0}','{1}')";
        lStrInsert = string.Format(lStrInsert,
                  fso.IDCARD,   //0
                  fso.NAME      //1
             );
        return FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrInsert);
    }

    private static Boolean fnStundentUdpate(FpStudentObject fso)
    {
        string lStrInsert = "update fp_student set name='{1}' where idcard='{0}'";
        lStrInsert = string.Format(lStrInsert,
                  fso.IDCARD,   //0
                  fso.NAME      //1
             );
        return FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrInsert);
    }

    private static Boolean fnStudentDelete(FpStudentObject fso)
    {
        return true;
    }
    #endregion



    private static Boolean fnIsVaildTime(DateTime pDtFrom, DateTime pDtTo)
    {

       return fnIsVaildTime(pDtFrom, pDtTo, 0);
    }


    private static Boolean fnIsVaildTime(DateTime pDtFrom,DateTime pDtTo,int pIntMinute)
    {

        if (pDtTo.Year != pDtFrom.Year || pDtTo.DayOfYear != pDtFrom.DayOfYear)
        {
            return false;
        }
        else
        {
            return pDtTo.Subtract(pDtFrom).TotalMinutes >= pIntMinute;
        }
    }
}
