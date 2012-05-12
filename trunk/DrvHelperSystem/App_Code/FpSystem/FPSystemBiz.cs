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
using FT.Commons.Cache;
using FT.DAL.Orm;
using System.Collections.Generic;

/// <summary>
///FPSystemBiz 的摘要说明
/// </summary>
public class FPSystemBiz
{
    public static string PARAM_RESULT = "identityResult";

    public static readonly int CHECHIN_NO_RECARD = -2;
    public static readonly int CHECKIN_FAILE = -1;
    public static readonly int CHECKIN_SUCCESS = 0;
    public static readonly int LESSON_ENTER_1_FAILE = 1;
    public static readonly int LESSON_ENTER_2_FAILE = 2;
    public static readonly int LESSON_LEAVE_2_FAILE = 3;
    public static readonly int CHECK_SAMEDAY_FAILE = 4;
    public static readonly int TRAIN_LEAVE_FAILE = 5;
    public static readonly int TRAIN_ENTER_FAILE = 6;

    public static readonly int LESSON_FINISH = 7;
    public static readonly int TRAIN_FINISH = 8;


    public FPSystemBiz()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region 业务方法，供页面调用

    //添加或修改一条学员记录
    public static Boolean fnAddOrUpdateStudentRecord(FpStudentObject fso)
    {

        string idCard = StringHelper.fnFormatNullOrBlankString(fso.IDCARD,"");
        fso.NAME = StringHelper.fnFormatNullOrBlankString(fso.NAME,"");
        if (SimpleOrmOperator.Create(fso) || FPSystemBiz.fnStundentUdpate(fso))
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
        int lIntLessonInterval=StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_LESSON_INTERVAL"),45);
        FpStudentObject fso = null;
        ArrayList lArrStu= FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<FpStudentObject>("where idcard='"+pStrIdCard+"'");
        if (lArrStu.Count != 1)
            return CHECHIN_NO_RECARD;
        fso = lArrStu[0] as FpStudentObject;
        bool lBlResult = false;
        DateTime lDtIdentity=DateTime.Now;
        string lStrUpdateSql = "update fp_student set {0}=TO_DATE('{1}','yyyy-mm-dd hh24:mi:ss') where idcard='{2}'";
        string lStrUpdateSqlClearRecord = "update fp_student set LESSON_ENTER_1=null,LESSON_ENTER_2=null,LESSON_LEAVE_2=null where idcard='{0}'";
        string lStrLessonFinishSql = "update fp_student set LESSON_FINISH=1 where idcard='{0}'";
        string lStrParm0=null;
        string lStrParm1= lDtIdentity.ToString();
        string lStrParm2 = fso.IDCARD;
        string lStrPrfLESSON_ENTER = "LESSON_ENTER";
        string lStrPrfLESSON_LEAVE = "LESSON_LEAVE";

       
        if (DateTimeHelper.fnIsNewDateTime(fso.LESSON_ENTER_1) )
        {
            lStrParm0 = lStrPrfLESSON_ENTER+"_1";
        }
        else if (!fnIsVaildTime(fso.LESSON_ENTER_1, lDtIdentity, 0))
        {
            lStrUpdateSqlClearRecord = string.Format(lStrUpdateSqlClearRecord,lStrParm2);
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSqlClearRecord);
            lIntReturn = LESSON_ENTER_1_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.LESSON_ENTER_2))
        {
            if (fnIsVaildTime(fso.LESSON_ENTER_1, lDtIdentity, lIntLessonInterval))
            {
                lStrParm0 = lStrPrfLESSON_ENTER + "_2";
            }
            else
            {
                lIntReturn = LESSON_ENTER_2_FAILE;
            }
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.LESSON_LEAVE_2))
        {
            if (fnIsVaildTime(fso.LESSON_ENTER_2, lDtIdentity, lIntLessonInterval))
            {
                lStrParm0 = lStrPrfLESSON_LEAVE + "_2";
                
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
            lIntReturn = CHECKIN_SUCCESS;
            if (lStrParm0 == lStrPrfLESSON_LEAVE + "_2")
            {
                lStrLessonFinishSql = string.Format(lStrLessonFinishSql, lStrParm2);
                lBlResult = FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrLessonFinishSql);
                if (lBlResult) {
                    lIntReturn = LESSON_FINISH;
                }
            }
        }

        return lIntReturn;
    }

    //记录学员入场训练时间
    public static int fnIdendityStudentTrain(String pStrIdCard)
    {
        //FT.DAL.Orm.SimpleOrmOperator.QueryList
        int lIntReturn = CHECKIN_FAILE;
        int lIntTrainInterval = StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_TRAIN_INTERVAL"), 45);
        FpStudentObject fso = null;
        ArrayList lArrStu = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<FpStudentObject>("where idcard='" + pStrIdCard + "'");
        if (lArrStu.Count != 1)
            return CHECHIN_NO_RECARD;
        fso = lArrStu[0] as FpStudentObject;
        bool lBlResult = false;
        DateTime lDtIdentity = DateTime.Now;
        string lStrUpdateSql = "update fp_student set {0}=TO_DATE('{1}','yyyy-mm-dd hh24:mi:ss') where idcard='{2}'";
        string lStrTrainFinishSql = "update fp_student set TRAIN_FINISH=1 where idcard='{0}'";
        string lStrParm0 = null;
        string lStrParm1 = lDtIdentity.ToString();
        string lStrParm2 = fso.IDCARD;
        string lStrPrfTRAIN_ENTER = "TRAIN_ENTER";
        string lStrPrfTRAIN_LEAVE = "TRAIN_LEAVE";
        string lStrClearParm0 = null;


        if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_1)||DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_1))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_1))
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; }
            else if (!fnIsVaildTime(fso.TRAIN_ENTER_1, lDtIdentity)) {
                lStrClearParm0 = "1";
            }
            else if (fnIsVaildTime(fso.TRAIN_ENTER_1, lDtIdentity, lIntTrainInterval))
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_1"; }
            else
            {

                lIntReturn = TRAIN_LEAVE_FAILE;
            }
            
        }
        else if(fnIsVaildTime(fso.TRAIN_ENTER_1, lDtIdentity))
        {
            lIntReturn=CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_2) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_2))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_2) )
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_2"; }
            else if (!fnIsVaildTime(fso.TRAIN_ENTER_2, lDtIdentity))
            {
                lStrClearParm0 = "2";
            }
            else if (fnIsVaildTime(fso.TRAIN_ENTER_2, lDtIdentity, lIntTrainInterval))
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_2"; }
            else
            {
                lIntReturn = TRAIN_LEAVE_FAILE;
            }
        }
        else if(fnIsVaildTime(fso.TRAIN_ENTER_2, lDtIdentity))
        {
       
         lIntReturn=CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_3) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_3))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_3) )
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_3"; }
            else if (!fnIsVaildTime(fso.TRAIN_ENTER_3, lDtIdentity))
            {
                lStrClearParm0 = "3";
            }
            else if (fnIsVaildTime(fso.TRAIN_ENTER_3, lDtIdentity, lIntTrainInterval))
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_3"; }
            else
            {
                lIntReturn = TRAIN_LEAVE_FAILE;
            }
        }
        else if(fnIsVaildTime(fso.TRAIN_ENTER_3, lDtIdentity))
        {
          lIntReturn=CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_4) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_4))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_4) )
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_4"; }
            else if (!fnIsVaildTime(fso.TRAIN_ENTER_4, lDtIdentity))
            {
                lStrClearParm0 = "4";
            }
            else if (fnIsVaildTime(fso.TRAIN_ENTER_4, lDtIdentity, lIntTrainInterval))
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_4"; }
            else
            {
                lIntReturn = TRAIN_LEAVE_FAILE;
            }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_4, lDtIdentity))
        {
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_5) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_5))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_5) )
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_5"; }
            else if (!fnIsVaildTime(fso.TRAIN_ENTER_5, lDtIdentity))
            {
                lStrClearParm0 = "5";
            }
            else if (fnIsVaildTime(fso.TRAIN_ENTER_5, lDtIdentity, lIntTrainInterval))
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_5"; }
            else
            {
                lIntReturn = TRAIN_LEAVE_FAILE;
            }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_5, lDtIdentity))
        {
            //lStrClearParm0 = "5";
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_6) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_6))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_6) )
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_6"; }
            else if (!fnIsVaildTime(fso.TRAIN_ENTER_6, lDtIdentity))
            {
                lStrClearParm0 = "6";
            }
            else if (fnIsVaildTime(fso.TRAIN_ENTER_6, lDtIdentity, lIntTrainInterval))
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_6"; }
            else
            {
                lIntReturn = TRAIN_LEAVE_FAILE;
            }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_6, lDtIdentity))
        {
            //lStrClearParm0 = "6";
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_7) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_7))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_7) )
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_7"; }
            else if (!fnIsVaildTime(fso.TRAIN_ENTER_7, lDtIdentity))
            {
                lStrClearParm0 = "7";
            }
            else if (fnIsVaildTime(fso.TRAIN_ENTER_7, lDtIdentity, lIntTrainInterval))
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_7"; }
            else
            {
                lIntReturn = TRAIN_LEAVE_FAILE;
            }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_7, lDtIdentity))
        {
            //lStrClearParm0 = "7";
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }
        else if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_8) || DateTimeHelper.fnIsNewDateTime(fso.TRAIN_LEAVE_8))
        {
            if (DateTimeHelper.fnIsNewDateTime(fso.TRAIN_ENTER_8) )
            { lStrParm0 = lStrPrfTRAIN_ENTER + "_8"; }
            else if (!fnIsVaildTime(fso.TRAIN_ENTER_8, lDtIdentity))
            {
                lStrClearParm0 = "8";
            }
            else if (fnIsVaildTime(fso.TRAIN_ENTER_8, lDtIdentity, lIntTrainInterval))
            { lStrParm0 = lStrPrfTRAIN_LEAVE + "_8"; }
            else
            {
                lIntReturn = TRAIN_LEAVE_FAILE;
            }
        }
        else if (fnIsVaildTime(fso.TRAIN_ENTER_8, lDtIdentity))
        {
           // lStrClearParm0 = "8";
            lIntReturn = CHECK_SAMEDAY_FAILE;
        }

        if (lStrParm0 != null)
        {
            lStrUpdateSql = string.Format(lStrUpdateSql, lStrParm0, lStrParm1, lStrParm2);
            lBlResult = FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSql);
            lIntReturn = CHECKIN_SUCCESS;
            if (lStrParm0 == lStrPrfTRAIN_LEAVE + "_8")
            {
                lStrTrainFinishSql = string.Format(lStrTrainFinishSql,lStrParm2);
                lBlResult = FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrTrainFinishSql);
                if (lBlResult) {
                    lIntReturn = TRAIN_FINISH;
                }
            }
        }
        else if (lStrClearParm0 != null) {
            string lStrUpdateSqlClearRecord = "update fp_student set TRAIN_LEAVE_{0}=null,TRAIN_ENTER_{0}=null where idcard='{1}'";
            lStrUpdateSqlClearRecord = string.Format(lStrUpdateSqlClearRecord, lStrClearParm0, lStrParm2);
            lBlResult = FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSqlClearRecord);
            lIntReturn = TRAIN_ENTER_FAILE;
        }

        return lIntReturn;
    }

    public static Dictionary<int, FpLocalType> DictFpLocalTypes = new Dictionary<int, FpLocalType>();
    public static Dictionary<int, FpSite> DictFpSites = new Dictionary<int, FpSite>();

    public static Boolean fnStudentCheckIn(ref FpStudentObject fso, FpSite fpSite, DateTime lDtCheckin)
    {
        bool isCheckin = false;
        //FpSite fpSite = SimpleOrmOperator.Query<FpSite>(site_id);
        string bustype = fpSite.BUSTYPE;
        int localType = fso.LOCALTYPE;
        if (fpSite.LIMIT > 0)
        {
            string condition = string.Format(" where SITE_ID={0} and BUSTYPE='{1}' and to_char(CHECKIN_DATE,'YYYY-MM-DD') = '{2}' order by CHECKIN_DATE DESC "
                , fpSite.ID
                , bustype
                , lDtCheckin
            );

            int checkinCount = SimpleOrmOperator.QueryCounts<FpSite>(condition);
            if (checkinCount >= fpSite.LIMIT) {
                string fullMsg=string.Format("场地：{0} 今天的入场人数已超过{1},不能再入场",fpSite.NAME,fpSite.LIMIT);
                throw new Exception(fullMsg);
            }
        }
        FpLocalType fpLocalType=null;
        if (DictFpLocalTypes.ContainsKey(localType))
        {
            fpLocalType = DictFpLocalTypes[localType];
        }
        else {
            fpLocalType = SimpleOrmOperator.Query<FpLocalType>(localType);
            DictFpLocalTypes.Add(localType, fpLocalType);
        }
        

        isCheckin = fso.checkin(fpSite,fpLocalType,lDtCheckin);

        //fso.IDCARD="'"+fso.IDCARD+"'";
        SimpleOrmOperator.Update(fso);
        fso.IDCARD = fso.IDCARD.Trim('\''); ;
        

        if (isCheckin) {
            FpCheckinLog log = new FpCheckinLog();
            log.BUSTYPE = bustype;
            log.SITE_ID = fpSite.ID;
            log.CHECKIN_NAME = fso.NAME;
            log.CHECKIN_IDCARD = fso.IDCARD;
            log.CHECKIN_DATE = lDtCheckin;
            log.REMARK = fso.REMARK;
            log.CHECKIN_STATUE = fso.STATUE;
            int statue = fso.STATUE;
            if (statue == FpStudentObject.STATUE_KM1_ENTER)
            {
                log.REMARK = "科目1进场";
            }
            else if (statue == FpStudentObject.STATUE_KM2_ENTER) {
                log.REMARK = "科目2进场";
            }
            else if (statue == FpStudentObject.STATUE_KM1_ENTER)
            {
                log.REMARK = "科目3进场";
            }
            else if (statue == FpStudentObject.STATUE_LESSON_START)
            {
                log.REMARK = "上课进场";
            }
            else if (statue == FpStudentObject.STATUE_LESSON_END)
            {
                log.REMARK = "下课离场";
            }
            
            isCheckin= SimpleOrmOperator.Create(log);
        }
        return isCheckin;

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
        string lStrInsert = "update fp_student set name='{1}',localtype={2},lsh='{3}' where idcard='{0}'";
        lStrInsert = string.Format(lStrInsert,
                  fso.IDCARD.Trim('\''),   //0
                  fso.NAME,      //1
                  fso.LOCALTYPE
                  ,fso.LSH
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
