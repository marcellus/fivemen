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

/// <summary>
///FPSystemBiz 的摘要说明
/// </summary>
public class FPSystemBiz
{

  

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
    public static FpStudentObject fnIdendityStudentLesson(String pStrIdCard)
    {
        //FT.DAL.Orm.SimpleOrmOperator.QueryList
        FpStudentObject fso = null;
        ArrayList lArrStu= FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<FpStudentObject>("where idcard='"+pStrIdCard+"'");
        if (lArrStu.Count!=1)
            return null;
        fso = lArrStu[0] as FpStudentObject;
        bool lBlResult = false;
        DateTime lDtIdentity=DateTime.Now;
        string lStrUpdateSql = "update fp_student set {0}=TO_DATE('{1}','yyyy-mm-dd hh24:mi:ss') where idcard='{2}'";
        string lStrParm0=null;
        string lStrParm1= lDtIdentity.ToString();
        string lStrParm2 = fso.IDCARD;
        string lStrPrfLESSON_ENTER = "LESSON_ENTER";
        string lStrPrfLESSON_LEAVE = "LESSON_LEAVE";

       
        if (fso.LESSON_ENTER_1 == null || fnIsNewDateTime(fso.LESSON_ENTER_1) )
        {
            lStrParm0 = lStrPrfLESSON_ENTER+"_1";
        }
        else if (fso.LESSON_LEAVE_1 == null || fnIsNewDateTime(fso.LESSON_LEAVE_1))
        {
            if (fnIsVaileTime(fso.LESSON_ENTER_1, lDtIdentity))
            lStrParm0 = lStrPrfLESSON_LEAVE+"_1";
        }
        else if (fso.LESSON_ENTER_2 == null || fnIsNewDateTime(fso.LESSON_ENTER_2))
        {
            lStrParm0 = lStrPrfLESSON_ENTER+"_2";
        }
        else if (fso.LESSON_LEAVE_2 == null || fnIsNewDateTime(fso.LESSON_LEAVE_2))
        {
            if (fnIsVaileTime(fso.LESSON_ENTER_2, lDtIdentity))
              lStrParm0 = lStrPrfLESSON_LEAVE+ "_2";
        }

        if (lStrParm0 != null)
        {
            lStrUpdateSql = string.Format(lStrUpdateSql, lStrParm0, lStrParm1, lStrParm2);
            lBlResult=FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSql);
            ArrayList lArrStuTemp = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<FpStudentObject>("where idcard='" + pStrIdCard + "'");
            if (lArrStuTemp.Count == 1)
                fso = lArrStuTemp[0] as FpStudentObject;
        }

        return fso;
    }

    private static Boolean fnIsVaileTime(DateTime pDtFrom, DateTime pDtTo)
    {
        int lIntDiff = pDtTo.Millisecond - pDtFrom.Millisecond;
        if (lIntDiff<=0)
            return false;
        else
            return true;
    }

    private static double fnGetTotalMillsecond(DateTime pDt)
    {
    
       DateTime d2 = new DateTime(1970, 1, 1);  
       return  pDt.Subtract(d2).TotalMilliseconds; 

    }

    private static Boolean fnIsNewDateTime(DateTime pDt)
    {
        return fnGetTotalMillsecond(pDt) == fnGetTotalMillsecond(new DateTime());
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
}
