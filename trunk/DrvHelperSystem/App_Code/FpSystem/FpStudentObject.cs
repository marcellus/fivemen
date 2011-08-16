using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL.Orm;
using FT.WebServiceInterface.DrvQuery;
using FT.Commons.Tools;
using FT.Commons.Cache;

/// <summary>
///FpStudentObject 的摘要说明
/// </summary>
///
[SimpleTable("FP_STUDENT")] 
[Alias("学员表")]
public class FpStudentObject
{

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

    public static readonly int KM1_ENTER_SUCCESS = 9;
    public static readonly int KM1_ENTER_FAILE = 10;
    public static readonly int KM2_ENTER_SUCCESS = 11;
    public static readonly int KM2_ENTER_FAILE = 12;
    public static readonly int KM3_ENTER_SUCCESS = 13;
    public static readonly int KM3_ENTER_FAILE = 14;

    private int gIntLessonInterval;
    private int gIntTrainInterval;

    public FpStudentObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
        gIntLessonInterval = StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_LESSON_INTERVAL"), 45);
        gIntTrainInterval = StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_TRAIN_INTERVAL"), 45);
    }

    [SimplePK]
    [SimpleColumn(Column= "IDCARD")]
    private string idcard;
    [SimpleColumn(Column="NAME")]
    private string name;
    [SimpleColumn(Column="SEX")]
    private string sex;
    [SimpleColumn(Column="BRITHDAY")]
    private DateTime brithday;
    [SimpleColumn(Column="PHONE")]
    private string phone;
    [SimpleColumn(Column="ADDRESS")]
    private string address;
    [SimpleColumn(Column="DRV_SCHOOL")]
    private string drv_school;
    [SimpleColumn(Column="DRV_TYPE")]
    private string drv_type;
    [SimpleColumn(Column="DRV_DOCNUM")]
    private string drv_docnum;
    [SimpleColumn(Column="REMARK")]
    private string remark;
    [SimpleColumn(Column="CREATER")]
    private string creater;
    [SimpleColumn(Column="CREATE_TIME")]
    private DateTime create_time;
    [SimpleColumn(Column="LASTMODIFY_TIME")]
    private DateTime lastmodify_time;
    [SimpleColumn(Column = "LESSON_ENTER_1")]
    private DateTime lesson_enter_1;
    [SimpleColumn(Column = "LESSON_LEAVE_1")]
    private DateTime lesson_leave_1;
    [SimpleColumn(Column = "LESSON_ENTER_2")]
    private DateTime lesson_enter_2;
    [SimpleColumn(Column = "LESSON_LEAVE_2")]
    private DateTime lesson_leave_2;


    [SimpleColumn(Column = "TRAIN_ENTER_1")]
    private DateTime train_enter_1;
    [SimpleColumn(Column = "TRAIN_LEAVE_1")]
    private DateTime train_leave_1;
    [SimpleColumn(Column = "TRAIN_ENTER_2")]
    private DateTime train_enter_2;
    [SimpleColumn(Column = "TRAIN_LEAVE_2")]
    private DateTime train_leave_2;
    [SimpleColumn(Column = "TRAIN_ENTER_3")]
    private DateTime train_enter_3;
    [SimpleColumn(Column = "TRAIN_LEAVE_3")]
    private DateTime train_leave_3;
    [SimpleColumn(Column = "TRAIN_ENTER_4")]
    private DateTime train_enter_4;
    [SimpleColumn(Column = "TRAIN_LEAVE_4")]
    private DateTime train_leave_4;
    [SimpleColumn(Column = "TRAIN_ENTER_5")]
    private DateTime train_enter_5;
    [SimpleColumn(Column = "TRAIN_LEAVE_5")]
    private DateTime train_leave_5;
    [SimpleColumn(Column = "TRAIN_ENTER_6")]
    private DateTime train_enter_6;
    [SimpleColumn(Column = "TRAIN_LEAVE_6")]
    private DateTime train_leave_6;
    [SimpleColumn(Column = "TRAIN_ENTER_7")]
    private DateTime train_enter_7;
    [SimpleColumn(Column = "TRAIN_LEAVE_7")]
    private DateTime train_leave_7;
    [SimpleColumn(Column = "TRAIN_ENTER_8")]
    private DateTime train_enter_8;
    [SimpleColumn(Column = "TRAIN_LEAVE_8")]
    private DateTime train_leave_8;

    [SimpleColumn(Column = "KM1_ENTER")]
    private DateTime km1_enter;
    [SimpleColumn(Column = "KM2_ENTER")]
    private DateTime km2_enter;
    [SimpleColumn(Column = "KM3_ENTER")]
    private DateTime km3_enter;
    [SimpleColumn(Column = "STATUE")]
    private string statue;
    [SimpleColumn(Column = "LOCALTYPE")]
    private string localtype;


    

    
    public string IDCARD
    {
        get { return this.idcard; }
        set { this.idcard = value; }
    }
   
    public string NAME
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string SEX
    {
        get { return this.sex; }
        set { this.sex = value; }
    }
    

    public DateTime  BRITHDAY
    {
        get { return this.brithday ; }
        set { this.brithday = value; }
    }


    public string PHONE
    {
        get { return this.phone; }
        set { this.phone = value; }
    }

    public string ADDRESS
    {
        get { return this.address; }
        set { this.address = value; }
    }



    public string DRV_SCHOOL
    {
        get { return this.drv_school; }
        set { this.drv_school = value; }
    }


    public string DRV_TYPE
    {
        get { return this.drv_type; }
        set { this.drv_type = value; }
    }


    public string DRV_DOCNUM
    {
        get { return this.drv_docnum; }
        set { this.drv_docnum = value; }
    }

    public string REMARK
    {
        get { return this.remark; }
        set { this.remark = value; }
    }
   
    public string CREATER
    {
        get { return this.creater; }
        set { this.creater = value; }
    }


    public DateTime CREATE_TIME
    {
        get { return this.create_time; }
        set { this.create_time = value; }
    }


    public DateTime LASTMODIFY_TIME
    {
        get { return this.lastmodify_time; }
        set { this.lastmodify_time = value; }
    }

    public DateTime LESSON_ENTER_1
    {
        get { return this.lesson_enter_1; }
        set { this.lesson_enter_1 = value; }
    }

    public DateTime LESSON_LEAVE_1
    {
        get { return this.lesson_leave_1; }
        set { this.lesson_leave_1 = value; }
    }

    public DateTime LESSON_ENTER_2
    {
        get { return this.lesson_enter_2; }
        set { this.lesson_enter_2 = value; }
    }

    public DateTime LESSON_LEAVE_2
    {
        get { return this.lesson_leave_2; }
        set { this.lesson_leave_2 = value; }
    }






    public DateTime TRAIN_ENTER_1
    {
        get { return this.train_enter_1; }
        set { this.train_enter_1 = value; }
    }

    public DateTime TRAIN_LEAVE_1
    {
        get { return this.train_leave_1; }
        set { this.train_leave_1 = value; }
    }

    public DateTime TRAIN_ENTER_2
    {
        get { return this.train_enter_2; }
        set { this.train_enter_2 = value; }
    }

    public DateTime TRAIN_LEAVE_2
    {
        get { return this.train_leave_2; }
        set { this.train_leave_2 = value; }
    }

    public DateTime TRAIN_ENTER_3
    {
        get { return this.train_enter_3; }
        set { this.train_enter_3 = value; }
    }

    public DateTime TRAIN_LEAVE_3
    {
        get { return this.train_leave_3; }
        set { this.train_leave_3 = value; }
    }

    public DateTime TRAIN_ENTER_4
    {
        get { return this.train_enter_4; }
        set { this.train_enter_4 = value; }
    }

    public DateTime TRAIN_LEAVE_4
    {
        get { return this.train_leave_4; }
        set { this.train_leave_4 = value; }
    }

    public DateTime TRAIN_ENTER_5
    {
        get { return this.train_enter_5; }
        set { this.train_enter_5 = value; }
    }

    public DateTime TRAIN_LEAVE_5
    {
        get { return this.train_leave_5; }
        set { this.train_leave_5 = value; }
    }

    public DateTime TRAIN_ENTER_6
    {
        get { return this.train_enter_6; }
        set { this.train_enter_6 = value; }
    }

    public DateTime TRAIN_LEAVE_6
    {
        get { return this.train_leave_6; }
        set { this.train_leave_6 = value; }
    }

     public DateTime TRAIN_ENTER_7
    {
        get { return this.train_enter_7; }
        set { this.train_enter_7 = value; }
    }

    public DateTime TRAIN_LEAVE_7
    {
        get { return this.train_leave_7; }
        set { this.train_leave_7 = value; }
    }

    public DateTime TRAIN_ENTER_8
    {
        get { return this.train_enter_8; }
        set { this.train_enter_8 = value; }
    }

    public DateTime TRAIN_LEAVE_8
    {
        get { return this.train_leave_8; }
        set { this.train_leave_8 = value; }
    }


    public DateTime KM1_ENTER
    {
        get { return this.km1_enter; }
        set { this.km1_enter = value; }
    }

    public DateTime KM2_ENTER
    {
        get { return this.km2_enter; }
        set { this.km2_enter = value; }
    }

    public DateTime KM3_ENTER
    {
        get { return this.km3_enter; }
        set { this.km3_enter = value; }
    }

    public string STATUE
    {
        get { return this.statue; }
        set { this.statue=value; }
    }

    public string LOCALTYPE
    {
        get { return this.localtype; }
        set { this.localtype=value; }
    }


    public void fromTempStudentInfo(TempStudentInfo info) {
        if (info == null) return;
        this.name = info.name;
        this.sex = info.sex;
        this.phone = info.phone;
        this.address = info.address;
        this.brithday = DateTime.Parse(info.birthday);
        this.idcard = info.idCard;
    }



    public int checkin(string bustype) {
        int lIntReturn=0;
        DateTime lDtIdentity=DateTime.Now;
        switch (bustype)
        {
            case "lesson":
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.LESSON_ENTER_1))
                    {
                        this.LESSON_ENTER_1 = lDtIdentity;
                    }
                    else if (!fnIsVaildTime(this.LESSON_ENTER_1, lDtIdentity, 0))
                    {
                        //lStrUpdateSqlClearRecord = string.Format(lStrUpdateSqlClearRecord, lStrParm2);
                        //FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSqlClearRecord);
                        //lIntReturn = LESSON_ENTER_1_FAILE;
                    }
                    else if (DateTimeHelper.fnIsNewDateTime(this.LESSON_ENTER_2))
                    {
                        if (fnIsVaildTime(this.LESSON_ENTER_1, lDtIdentity, gIntLessonInterval))
                        {
                            //lStrParm0 = lStrPrfLESSON_ENTER + "_2";
                        }
                        else
                        {
                            // lIntReturn = LESSON_ENTER_2_FAILE;
                        }
                    }
                    else if (DateTimeHelper.fnIsNewDateTime(this.LESSON_LEAVE_2))
                    {
                        if (fnIsVaildTime(this.LESSON_ENTER_2, lDtIdentity, gIntLessonInterval))
                        {
                            // lStrParm0 = lStrPrfLESSON_LEAVE + "_2";

                        }
                        else
                        {
                            // lIntReturn = LESSON_LEAVE_2_FAILE;
                        }
                    }
                    break;
                }//case "lesson"
            case "km1": {
                this.km1_enter = lDtIdentity;
                break; 
            } //case km1
            case "km2": {
                this.km2_enter = lDtIdentity;
                break; 
            } //case km2
            case "train": {
                if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_1) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_1))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_1))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_1, lDtIdentity))
                    {
                       // lStrClearParm0 = "1";
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_1, lDtIdentity, gIntTrainInterval))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1"; 
                    }
                    else
                    {

                        lIntReturn = TRAIN_LEAVE_FAILE;
                    }

                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_1, lDtIdentity))
                {
                    lIntReturn = CHECK_SAMEDAY_FAILE;
                }
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_2) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_2))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_2))
                    { 
                      //  lStrParm0 = lStrPrfTRAIN_ENTER + "_2"; 
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_2, lDtIdentity))
                    {
                      //  lStrClearParm0 = "2";
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_2, lDtIdentity, gIntTrainInterval))
                    { 
                       // lStrParm0 = lStrPrfTRAIN_LEAVE + "_2"; 
                    }
                    else
                    {
                        lIntReturn = TRAIN_LEAVE_FAILE;
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_2, lDtIdentity))
                {

                    lIntReturn = CHECK_SAMEDAY_FAILE;
                }
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_3) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_3))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_3))
                    { 
                       // lStrParm0 = lStrPrfTRAIN_ENTER + "_3"; 
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_3, lDtIdentity))
                    {
                       // lStrClearParm0 = "3";
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_3, lDtIdentity, gIntTrainInterval))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_3"; 
                    }
                    else
                    {
                        lIntReturn = TRAIN_LEAVE_FAILE;
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_3, lDtIdentity))
                {
                    lIntReturn = CHECK_SAMEDAY_FAILE;
                }
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_4) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_4))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_4))
                    { 
                       /// lStrParm0 = lStrPrfTRAIN_ENTER + "_4"; 
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_4, lDtIdentity))
                    {
                        //lStrClearParm0 = "4";
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_4, lDtIdentity, gIntTrainInterval))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_4"; 
                    }
                    else
                    {
                        lIntReturn = TRAIN_LEAVE_FAILE;
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_4, lDtIdentity))
                {
                    lIntReturn = CHECK_SAMEDAY_FAILE;
                }
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_5) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_5))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_5))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_5"; 
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_5, lDtIdentity))
                    {
                        //lStrClearParm0 = "5";
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_5, lDtIdentity, gIntTrainInterval))
                    { 
                       // lStrParm0 = lStrPrfTRAIN_LEAVE + "_5"; 
                    }
                    else
                    {
                        lIntReturn = TRAIN_LEAVE_FAILE;
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_5, lDtIdentity))
                {
                    //lStrClearParm0 = "5";
                    lIntReturn = CHECK_SAMEDAY_FAILE;
                }
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_6) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_6))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_6))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_6"; 
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_6, lDtIdentity))
                    {
                       // lStrClearParm0 = "6";
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_6, lDtIdentity, gIntTrainInterval))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_6"; 
                    }
                    else
                    {
                        lIntReturn = TRAIN_LEAVE_FAILE;
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_6, lDtIdentity))
                {
                    //lStrClearParm0 = "6";
                    lIntReturn = CHECK_SAMEDAY_FAILE;
                }
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_7) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_7))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_7))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_7"; 
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_7, lDtIdentity))
                    {
                        //lStrClearParm0 = "7";
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_7, lDtIdentity, gIntTrainInterval))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_7"; 
                    }
                    else
                    {
                        lIntReturn = TRAIN_LEAVE_FAILE;
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_7, lDtIdentity))
                {
                    //lStrClearParm0 = "7";
                    lIntReturn = CHECK_SAMEDAY_FAILE;
                }
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_8) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_8))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_8))
                    { 
                       // lStrParm0 = lStrPrfTRAIN_ENTER + "_8"; 
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_8, lDtIdentity))
                    {
                        //lStrClearParm0 = "8";
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_8, lDtIdentity, gIntTrainInterval))
                    { 
                       // lStrParm0 = lStrPrfTRAIN_LEAVE + "_8"; 
                    }
                    else
                    {
                        lIntReturn = TRAIN_LEAVE_FAILE;
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_8, lDtIdentity))
                {
                    // lStrClearParm0 = "8";
                    lIntReturn = CHECK_SAMEDAY_FAILE;
                }
                break; 
            }//case "train"
            case "km3": {
                this.km3_enter = lDtIdentity;
                break; 
            }//case km3
            default : break;
        }   
          

        return lIntReturn;
        }
    






    private static Boolean fnIsVaildTime(DateTime pDtFrom, DateTime pDtTo)
    {

        return fnIsVaildTime(pDtFrom, pDtTo, 0);
    }


    private static Boolean fnIsVaildTime(DateTime pDtFrom, DateTime pDtTo, int pIntMinute)
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
