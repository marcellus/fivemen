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


    public static readonly int STATUE_NEW = 0;
    public static readonly int STATUE_LESSON_START=1;
    public static readonly int STATUE_LESSON_END=2;
    public static readonly int STATUE_KM1_ENTER = 3;
    public static readonly int STATUE_KM2_ENTER = 4;
    public static readonly int STATUE_TRAIN_START = 5;
    public static readonly int STATUE_TRAIN_END = 6;
    public static readonly int STATUE_KM3_ENTER = 7;
    public static readonly int STATUE_FINISH = 8;


    //private int gIntLessonInterval;
    //private int gIntTrainInterval;

    public FpStudentObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //

    }

    [SimplePK]
    [SimpleColumn(Column= "IDCARD")]
    private string idcard;
    [SimpleColumn(Column="NAME")]
    private string name;
    [SimpleColumn(Column="SEX")]
    private string sex;
    [SimpleColumn(Column="BRITHDAY",ColumnType=SimpleColumnType.Date)]
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
    [SimpleColumn(Column = "CREATE_TIME", ColumnType = SimpleColumnType.Date)]
    private DateTime create_time;
    [SimpleColumn(Column = "LASTMODIFY_TIME", ColumnType = SimpleColumnType.Date)]
    private DateTime lastmodify_time;
    [SimpleColumn(Column = "LESSON_ENTER_1", ColumnType = SimpleColumnType.Date)]
    private DateTime lesson_enter_1;
    [SimpleColumn(Column = "LESSON_LEAVE_1", ColumnType = SimpleColumnType.Date)]
    private DateTime lesson_leave_1;
    [SimpleColumn(Column = "LESSON_ENTER_2", ColumnType = SimpleColumnType.Date)]
    private DateTime lesson_enter_2;
    [SimpleColumn(Column = "LESSON_LEAVE_2", ColumnType = SimpleColumnType.Date)]
    private DateTime lesson_leave_2;


    [SimpleColumn(Column = "TRAIN_ENTER_1", ColumnType = SimpleColumnType.Date)]
    private DateTime train_enter_1;
    [SimpleColumn(Column = "TRAIN_LEAVE_1", ColumnType = SimpleColumnType.Date)]
    private DateTime train_leave_1;
    [SimpleColumn(Column = "TRAIN_ENTER_2", ColumnType = SimpleColumnType.Date)]
    private DateTime train_enter_2;
    [SimpleColumn(Column = "TRAIN_LEAVE_2", ColumnType = SimpleColumnType.Date)]
    private DateTime train_leave_2;
    [SimpleColumn(Column = "TRAIN_ENTER_3", ColumnType = SimpleColumnType.Date)]
    private DateTime train_enter_3;
    [SimpleColumn(Column = "TRAIN_LEAVE_3", ColumnType = SimpleColumnType.Date)]
    private DateTime train_leave_3;
    [SimpleColumn(Column = "TRAIN_ENTER_4", ColumnType = SimpleColumnType.Date)]
    private DateTime train_enter_4;
    [SimpleColumn(Column = "TRAIN_LEAVE_4", ColumnType = SimpleColumnType.Date)]
    private DateTime train_leave_4;
    [SimpleColumn(Column = "TRAIN_ENTER_5", ColumnType = SimpleColumnType.Date)]
    private DateTime train_enter_5;
    [SimpleColumn(Column = "TRAIN_LEAVE_5", ColumnType = SimpleColumnType.Date)]
    private DateTime train_leave_5;
    [SimpleColumn(Column = "TRAIN_ENTER_6", ColumnType = SimpleColumnType.Date)]
    private DateTime train_enter_6;
    [SimpleColumn(Column = "TRAIN_LEAVE_6", ColumnType = SimpleColumnType.Date)]
    private DateTime train_leave_6;
    [SimpleColumn(Column = "TRAIN_ENTER_7", ColumnType = SimpleColumnType.Date)]
    private DateTime train_enter_7;
    [SimpleColumn(Column = "TRAIN_LEAVE_7", ColumnType = SimpleColumnType.Date)]
    private DateTime train_leave_7;
    [SimpleColumn(Column = "TRAIN_ENTER_8", ColumnType = SimpleColumnType.Date)]
    private DateTime train_enter_8;
    [SimpleColumn(Column = "TRAIN_LEAVE_8", ColumnType = SimpleColumnType.Date)]
    private DateTime train_leave_8;

    [SimpleColumn(Column = "KM1_ENTER", ColumnType = SimpleColumnType.Date)]
    private DateTime km1_enter;
    [SimpleColumn(Column = "KM2_ENTER", ColumnType = SimpleColumnType.Date)]
    private DateTime km2_enter;
    [SimpleColumn(Column = "KM3_ENTER", ColumnType = SimpleColumnType.Date)]
    private DateTime km3_enter;


    [SimpleColumn(Column = "STATUE",ColumnType=SimpleColumnType.Int)]
    private int statue;
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

    public int STATUE
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
       // this.brithday = DateTime.Parse(info.birthday);
        this.idcard = info.idCard;
    }



    public void checkin(string bustype) {
        int gIntLessonInterval = StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_LESSON_INTERVAL"), 45);
        int gIntTrainInterval = StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_TRAIN_INTERVAL"), 45);
        int lIntReturn=0;
        DateTime lDtIdentity=DateTime.Now;
        DateTime lDtNull=new DateTime(0);
        string lStrIdentity= lDtIdentity.ToString("yyyy-MM-dd HH:mm:ss");
        switch (bustype)
        {
            case "lesson":
                {
                    if (this.statue < STATUE_NEW) {
                        this.remark = string.Format("{0}  学员未进行指纹采集", lStrIdentity);
                        break;
                    }
                    else if (this.statue >= STATUE_LESSON_END) {
                        this.remark = string.Format("{0}  学员已完成上课学时", lStrIdentity);
                        break;
                    }

                    if (DateTimeHelper.fnIsNewDateTime(this.LESSON_ENTER_1))
                    {
                        this.LESSON_ENTER_1 = lDtIdentity;
                        this.statue = STATUE_LESSON_START;
                        this.remark = string.Format("{0}  开始进行上午上课", lStrIdentity);
                    }
                    else if (!fnIsVaildTime(this.LESSON_ENTER_1, lDtIdentity, 0))
                    {
                        //lStrUpdateSqlClearRecord = string.Format(lStrUpdateSqlClearRecord, lStrParm2);
                        //FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSqlClearRecord);
                        //lIntReturn = LESSON_ENTER_1_FAILE;
                        this.LESSON_ENTER_1= lDtNull;
                        this.LESSON_ENTER_2 = lDtNull;
                        this.LESSON_LEAVE_2 = lDtNull;
                        this.remark = string.Format("{0} 本次上课与上次不在同一天进行，旧上课记录已被清空，请再次确认上课", lStrIdentity);
                    }
                    else if (DateTimeHelper.fnIsNewDateTime(this.LESSON_ENTER_2))
                    {
                        if (fnIsVaildTime(this.LESSON_ENTER_1, lDtIdentity, gIntLessonInterval))
                        {               
                            this.LESSON_ENTER_2 = lDtIdentity;
                            this.remark = string.Format("{0} 开始进行下午上课", lStrIdentity);
                        }
                        else
                        {
                            // lIntReturn = LESSON_ENTER_2_FAILE;
                            this.remark = string.Format("{0} 上午上课时间未达到{1}分钟，不能进行下午上课", lStrIdentity,gIntLessonInterval);
                        }
                    }
                    else if (DateTimeHelper.fnIsNewDateTime(this.LESSON_LEAVE_2))
                    {
                        if (fnIsVaildTime(this.LESSON_ENTER_2, lDtIdentity, gIntLessonInterval))
                        {
                            // lStrParm0 = lStrPrfLESSON_LEAVE + "_2";
                            this.LESSON_LEAVE_2 = lDtIdentity;
                            this.statue = STATUE_LESSON_END;
                            this.remark = string.Format("{0} 完成上课学时要求", lStrIdentity);
                        }
                        else
                        {
                            this.remark = string.Format("{0} 下午上课时间未达到{1}分钟，不能提早离场", lStrIdentity, gIntLessonInterval);
                        }
                    }
                    break;
                }//case "lesson"
            case "km1": {
                if (this.statue < STATUE_LESSON_END)
                {
                    this.remark = string.Format("{0} 未完成上课，不能进行科目1考试", lStrIdentity);
                    break;
                }
                else if (this.statue >= STATUE_KM1_ENTER) {
                    this.remark = string.Format("{0} 已完成科目1考试", lStrIdentity);
                    break;
                }
  
                    this.km1_enter = lDtIdentity;
                    this.statue = STATUE_KM1_ENTER;
                    this.remark = string.Format("{0} 科目1考试验证成功", lStrIdentity);
                break; 
            } //case km1
            case "km2": {
                if (this.statue < STATUE_KM1_ENTER)
                {
                    this.remark = string.Format("{0} 未进行科目1考试，不能进行科目2考试", lStrIdentity);
                    break;
                }
                else if (this.statue >= STATUE_KM2_ENTER)
                {
                    this.remark = string.Format("{0} 已完成科目2考试", lStrIdentity);
                    break;
                }

                    this.km2_enter = lDtIdentity;
                    this.statue = STATUE_KM2_ENTER;
                    this.remark = string.Format("{0} 科目2考试验证成功", lStrIdentity);
                break; 
            } //case km2
            case "train": {
                if (this.statue < STATUE_KM1_ENTER)
                {
                    this.remark = string.Format("{0} 未进行科目1考试，不能进行入场训练", lStrIdentity);
                    break;
                }
                else if (this.statue >=  STATUE_TRAIN_END)
                {
                    this.remark = string.Format("{0} 已完成入场训练", lStrIdentity);
                    break;
                }

                string patternTrainEnter="{0}  开始进行第{1}次入场训练";
                string patternTrainEnterNotToday = "{0} 第{1}次的训练未完成,第{1}次的记录将被清空，请再次验证";
                string patternTrainLeave = "{0} 已完成今天的入场训练";
                string patternTrainLeaveFaile = "{0} 今天的入场训练时间未达到{1}分钟，离场将被作为训练无效处理";
                string patternTrainEnterIsToday = "{0}  今天的入场训练已完成，同一天不能入场两次";
                //1
                if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_1) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_1))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_1))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                        this.train_enter_1 = lDtIdentity;
                        this.statue = STATUE_TRAIN_START;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity,1);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_1, lDtIdentity))
                    {
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 1);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_1, lDtIdentity, gIntTrainInterval))
                    { 
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1";
                        this.train_leave_1 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                    }
                    else
                    {
                        this.remark = string.Format(patternTrainLeaveFaile, lStrIdentity, gIntTrainInterval);
                    }

                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_1, lDtIdentity))
                {
                    //lIntReturn = CHECK_SAMEDAY_FAILE;
                    this.remark = string.Format(patternTrainEnterIsToday,lDtIdentity);
                }


                //2
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_2) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_2))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_2))
                    {
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                        this.train_enter_2 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 2);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_2, lDtIdentity))
                    {
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 2);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_2, lDtIdentity, gIntTrainInterval))
                    {
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1";
                        this.train_leave_2 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                    }
                    else
                    {
                        this.remark = string.Format(patternTrainLeaveFaile, lStrIdentity, gIntTrainInterval);
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_2, lDtIdentity))
                {

                    this.remark = string.Format(patternTrainEnterIsToday, lDtIdentity);
                }


                //3
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_3) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_3))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_3))
                    {
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                        this.train_enter_3 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity,3);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_3, lDtIdentity))
                    {
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 3);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_3, lDtIdentity, gIntTrainInterval))
                    {
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1";
                        this.train_leave_3 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                    }
                    else
                    {
                        this.remark = string.Format(patternTrainLeaveFaile, lStrIdentity, gIntTrainInterval);
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_3, lDtIdentity))
                {
                    this.remark = string.Format(patternTrainEnterIsToday, lDtIdentity);
                }


                //4
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_4) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_4))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_4))
                    {
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                        this.train_enter_4 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 4);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_4, lDtIdentity))
                    {
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 4);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_4, lDtIdentity, gIntTrainInterval))
                    {
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1";
                        this.train_leave_4 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                    }
                    else
                    {
                        this.remark = string.Format(patternTrainLeaveFaile, lStrIdentity, gIntTrainInterval);
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_4, lDtIdentity))
                {
                    this.remark = string.Format(patternTrainEnterIsToday, lDtIdentity);
                }



                //5
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_5) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_5))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_5))
                    {
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                        this.train_enter_5 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 5);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_5, lDtIdentity))
                    {
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 5);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_5, lDtIdentity, gIntTrainInterval))
                    {
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1";
                        this.train_leave_5 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                    }
                    else
                    {
                        this.remark = string.Format(patternTrainLeaveFaile, lStrIdentity, gIntTrainInterval);
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_5, lDtIdentity))
                {
                    //lStrClearParm0 = "5";
                    this.remark = string.Format(patternTrainEnterIsToday, lDtIdentity);
                }



                //6
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_6) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_6))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_6))
                    {
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                        this.train_enter_6 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 6);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_6, lDtIdentity))
                    {
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 6);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_6, lDtIdentity, gIntTrainInterval))
                    {
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1";
                        this.train_leave_6 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                    }
                    else
                    {
                        this.remark = string.Format(patternTrainLeaveFaile, lStrIdentity, gIntTrainInterval);
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_6, lDtIdentity))
                {
                    //lStrClearParm0 = "6";
                    this.remark = string.Format(patternTrainEnterIsToday, lDtIdentity);
                }


                //7
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_7) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_7))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_7))
                    {
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                        this.train_enter_7 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 7);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_7, lDtIdentity))
                    {
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 7);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_7, lDtIdentity, gIntTrainInterval))
                    {
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1";
                        this.train_leave_7 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                    }
                    else
                    {
                        this.remark = string.Format(patternTrainLeaveFaile, lStrIdentity, gIntTrainInterval);
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_7, lDtIdentity))
                {
                    //lStrClearParm0 = "7";
                    this.remark = string.Format(patternTrainEnterIsToday, lDtIdentity);
                }


                //8
                else if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_8) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_8))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_8))
                    {
                        //lStrParm0 = lStrPrfTRAIN_ENTER + "_1"; 
                        this.train_enter_8 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 8);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_8, lDtIdentity))
                    {
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 8);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_8, lDtIdentity, gIntTrainInterval))
                    {
                        //lStrParm0 = lStrPrfTRAIN_LEAVE + "_1";
                        this.train_leave_8 = lDtIdentity;
                        this.statue = STATUE_TRAIN_END;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                    }
                    else
                    {
                        this.remark = string.Format(patternTrainLeaveFaile, lStrIdentity, gIntTrainInterval);
                    }
                }
                else if (fnIsVaildTime(this.TRAIN_ENTER_8, lDtIdentity))
                {
                    // lStrClearParm0 = "8";
                    this.remark = string.Format(patternTrainEnterIsToday, lDtIdentity);
                }
                break; 
            }//case "train"
            case "km3": {
                if (this.statue < STATUE_TRAIN_END)
                {
                    this.remark = string.Format("{0} 未完成入场训练，不能进行科目3考试", lStrIdentity);
                    break;
                }
                else if (this.statue >= STATUE_KM3_ENTER)
                {
                    this.remark = string.Format("{0} 已完成科目3考试", lStrIdentity);
                    break;
                }

                this.km3_enter = lDtIdentity;
                this.statue = STATUE_KM3_ENTER;
                this.remark = string.Format("{0} 科目3考试验证成功", lStrIdentity);
                break; 
            }//case km3
            default : break;
        }   
          
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
