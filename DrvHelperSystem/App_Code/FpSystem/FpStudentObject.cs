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
using System.Collections.Generic;

/// <summary>
///FpStudentObject 的摘要说明
/// </summary>
///
[SimpleTable("FP_STUDENT")] 
[Alias("学员表")]
[Serializable]
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


    public static readonly int STATUE_NEW = 0;         //记录创建成功
    public static readonly int STATUE_COLLECT = 1;         //采集成功
    public static readonly int STATUE_LESSON_START=2;    //开始上课
    public static readonly int STATUE_LESSON_END=3;        //完成上课
    public static readonly int STATUE_KM1_ENTER = 4;       //科目一入场
    public static readonly int STATUE_KM2_ENTER = 5;         //科目二入场
    public static readonly int STATUE_3IN9_ENTER = 5;          //九选三入场
    public static readonly int STATUE_TRAIN_START = 6;       //入场训练开始
    public static readonly int STATUE_TRAIN_END = 7;          //入场训练结束
    
    public static readonly int STATUE_KM3_ENTER = 8;          //科目三入场
    public static readonly int STATUE_FINISH = 9;             //完成考勤


    public static Dictionary<int, string> GetDictStatue() {

        Dictionary<int, string> status = new Dictionary<int,string>();
        status.Add(STATUE_NEW, "新创建");
        status.Add(STATUE_COLLECT, "采集成功");
        //status.Add(STATUE_FEE, "已交费");
        status.Add(STATUE_LESSON_START, "开始上课");
        status.Add(STATUE_LESSON_END,"完成上课");
        status.Add(STATUE_TRAIN_START, "开始入场训练");
        status.Add(STATUE_TRAIN_END,"完成入场训练");
        status.Add(STATUE_KM1_ENTER, "完成科目一考试");
        status.Add(STATUE_KM2_ENTER, "完成科目二考试");
        status.Add(STATUE_KM3_ENTER, "完成科目三考试");
        status.Add(STATUE_FINISH, "完成所有考勤");
       // status.Add(STATUE_3IN9_ENTER, "完成九选三考试");

        return status;
    }

    public FpStudentObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //

    }

    [SimplePK]
    [SimpleColumn(Column= "IDCARD",AllowInsert=true,ColumnType=SimpleColumnType.String)]
    private string idcard;
    [SimpleColumn(Column="LSH")]
    private string lsh;
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

    [SimpleColumn(Column = "TRAIN_END_DATE", ColumnType = SimpleColumnType.Date)]
    private DateTime train_end_date;

    [SimpleColumn(Column = "KM1_ENTER", ColumnType = SimpleColumnType.Date)]
    private DateTime km1_enter;
    [SimpleColumn(Column = "KM2_ENTER", ColumnType = SimpleColumnType.Date)]
    private DateTime km2_enter;
    [SimpleColumn(Column = "KM3_ENTER", ColumnType = SimpleColumnType.Date)]
    private DateTime km3_enter;
    [SimpleColumn(Column = "KM2_3IN9_ENTER", ColumnType = SimpleColumnType.Date)]
    private DateTime km2_3in9_enter;


    [SimpleColumn(Column = "STATUE",ColumnType=SimpleColumnType.Int)]
    private int statue;
    [SimpleColumn(Column = "LOCALTYPE",ColumnType=SimpleColumnType.Int)]
    private int  localtype;

    [SimpleColumn(Column = "KM3_VERIFY")]
    private string km3Verify="N";

    [SimpleColumn(Column = "FEE_STATUE")]
    private string feeStatue="N";

    [SimpleColumn(Column="FEE_VERIFY_DATE", ColumnType = SimpleColumnType.Date)]
    private DateTime feeVerifyDate;

    [SimpleColumn(Column = "SCHOOL_CODE")]
    private string schoolCode;

    [SimpleColumn(Column = "SCHOOL_NAME")]
    private string schoolName;

    [SimpleColumn(Column = "CAR_TYPE")]
    private string carType;
    
    public string IDCARD
    {
        get { return this.idcard; }
        set { this.idcard = value; }
    }

    public string LSH {
        get { return this.lsh; }
        set { this.lsh = value; }
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

    public DateTime TRAIN_END_DATE
    {
        get { return this.train_end_date; }
        set { this.train_end_date = value; }
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

    public DateTime KM2_3IN9_ENTER
    {
        get { return this.km2_3in9_enter; }
        set { this.km2_3in9_enter = value; }
    }

    public int STATUE
    {
        get { return this.statue; }
        set { this.statue=value; }
    }

    public int LOCALTYPE
    {
        get { return this.localtype; }
        set { this.localtype=value; }
    }

    public string KM3_VERIFY {

        get { return this.km3Verify; }
        set { this.km3Verify = value; }
    }


    public string FEE_STATUE
    {

        get { return this.feeStatue; }
        set { this.feeStatue = value; }
    }
    public string SCHOOL_CODE
    {

        get { return this.schoolCode; }
        set { this.schoolCode = value; }
    }
    public string SCHOOL_NAME
    {

        get { return this.schoolName; }
        set { this.schoolName = value; }
    }


    public DateTime FEE_VERIFY_DATE {
        get { return this.feeVerifyDate; }
        set { this.feeVerifyDate = value; }
       
    }

    public string CAR_TYPE{
    
       get{ return this.carType;}
       set{this.carType=value;}
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



    public bool checkin(FpSite fpSite,FpLocalType fpLocalType, DateTime lDtIdentity)
    {
        //int gIntLessonInterval = StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_LESSON_INTERVAL"), 45);
        //int gIntTrainInterval = StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_TRAIN_INTERVAL"), 45);
        FPConfig config = FPSystemBiz.GetCurrConfig();
        int gIntLessonInterval = config.FP_LESSON_INTERVAL;
        int gIntTrainInterval = config.FP_TRAIN_INTERVAL;

        bool isCheckin = false;
       // DateTime lDtIdentity=DateTime.Now;
        DateTime lDtNull=new DateTime(0);
        string lStrIdentity= lDtIdentity.ToString("yyyy-MM-dd HH:mm:ss");
        switch (fpSite.BUSTYPE)
        {
            case "lesson":
                {
                   

                    if (this.statue < STATUE_COLLECT) {
                        this.remark = string.Format("{0}  学员未进行指纹采集", lStrIdentity);
                        break;
                    }
                    else if (fpLocalType.LESSON_IND != "Y") {
                        this.remark = string.Format("学员类型：{0}，无需进行上课",fpLocalType.NAME);
                    }
                    else if (this.feeStatue != "Y")
                    {

                        this.remark = string.Format("{0}  学员交费审核未通过，不能进行上课", lStrIdentity);
                        break;
                    }
                    else if (this.statue >= STATUE_LESSON_END)
                    {
                        this.remark = string.Format("{0}  学员已完成上课学时", lStrIdentity);
                        break;
                    }

                    DateTime dtLesson2Leavel = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,config.FP_LESSON_ENTER_2_HH,config.FP_LESSON_ENTER_2_MM,0).AddMinutes(config.FP_LESSON_INTERVAL);
                   
                    if (DateTimeHelper.fnIsNewDateTime(this.LESSON_ENTER_1))
                    {
                        if (!DateTimeHelper.fnIsBeforeTime(lDtIdentity, config.FP_LESSON_ENTER_1_HH, config.FP_LESSON_ENTER_1_MM)
                            && fnIsVaildTime(lDtIdentity, dtLesson2Leavel))
                        {
                            this.remark = string.Format("{0} 早场第一节上课超过限制时间 {1}:{2},考勤无效",
                           lStrIdentity, config.FP_LESSON_ENTER_1_HH, config.FP_LESSON_ENTER_1_MM);
                            break;
                        }
                        else if (!DateTimeHelper.fnIsBeforeTime(lDtIdentity, config.FP_LESSON_ENTER_3_HH, config.FP_LESSON_ENTER_3_MM))
                        {
                            this.remark = string.Format("{0} 晚场第一节上课超过限制时间 {1}:{2},考勤无效",
                                lStrIdentity, config.FP_LESSON_ENTER_3_HH, config.FP_LESSON_ENTER_3_MM);
                            break;
                        }
                        //else if (!DateTimeHelper.fnIsBeforeTime(lDtIdentity, config.FP_LESSON_ENTER_1_HH, config.FP_LESSON_ENTER_1_MM))
                        //{
                        //    this.remark = string.Format("{0} 上午上课超过限制时间 {1}:{2},考勤无效",
                        //        lStrIdentity, config.FP_LESSON_ENTER_1_HH, config.FP_LESSON_ENTER_1_MM);
                        //    break;
                        //}

                            this.LESSON_ENTER_1 = lDtIdentity;
                            this.statue = STATUE_LESSON_START;
                            this.remark = string.Format("{0}  开始进行第一节上课", lStrIdentity);
                            isCheckin = true;
                      
                    }
                    else if (!fnIsVaildTime(this.LESSON_ENTER_1, lDtIdentity, 0))
                    {
                        //lStrUpdateSqlClearRecord = string.Format(lStrUpdateSqlClearRecord, lStrParm2);
                        //FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(lStrUpdateSqlClearRecord);
                        //lIntReturn = LESSON_ENTER_1_FAILE;
                        this.LESSON_ENTER_1= lDtNull;
                        this.LESSON_ENTER_2 = lDtNull;
                        this.LESSON_LEAVE_2 = lDtNull;
                        this.LESSON_LEAVE_1 = lDtNull;
                        this.remark = string.Format("{0} 本次上课与上次不在同一天进行，旧上课记录已被清空，请再次确认上课", lStrIdentity);
                        
                        this.statue = STATUE_COLLECT;
                    }
                    else if (DateTimeHelper.fnIsNewDateTime(this.LESSON_LEAVE_1))
                    {
                        if (fnIsVaildTime(this.LESSON_ENTER_1, lDtIdentity, gIntLessonInterval))
                        {
                            this.LESSON_LEAVE_1 = lDtIdentity;
                            this.remark = string.Format("{0} 第一节上课离场成功，请今天再来第二节上课入场确认", lStrIdentity);
                            isCheckin = true;
                        }
                        else
                        {
                            // lIntReturn = LESSON_ENTER_2_FAILE;
                            this.remark = string.Format("{0} 第一节上课时间未达到{1}分钟,提早离场将被视为无效", lStrIdentity, gIntLessonInterval);
                        }
                    }
                    else if (DateTimeHelper.fnIsNewDateTime(this.LESSON_ENTER_2))
                    {
                        //if (fnIsVaildTime(this.LESSON_LEAVE_1, lDtIdentity, gIntLessonInterval))
                        if (!DateTimeHelper.fnIsBeforeTime(lDtIdentity,config.FP_LESSON_ENTER_2_HH,config.FP_LESSON_ENTER_2_MM)
                           && fnIsVaildTime(lDtIdentity, dtLesson2Leavel)
                        )
                        {
                            // lIntReturn = LESSON_ENTER_2_FAILE;
                            //this.remark = string.Format("{0} 上午上课时间未达到{1}分钟，不能进行下午上课", lStrIdentity,gIntLessonInterval);
                            this.remark = string.Format("{0} 早场第二节上课超过限制时间 {1}:{2},考勤无效",
                            lStrIdentity,config.FP_LESSON_ENTER_2_HH,config.FP_LESSON_ENTER_2_MM);
                            break;
                        }     
                        else if (!DateTimeHelper.fnIsBeforeTime(lDtIdentity, config.FP_LESSON_ENTER_4_HH, config.FP_LESSON_ENTER_4_MM))
                        {
                            // lIntReturn = LESSON_ENTER_2_FAILE;
                            //this.remark = string.Format("{0} 上午上课时间未达到{1}分钟，不能进行下午上课", lStrIdentity,gIntLessonInterval);
                            this.remark = string.Format("{0} 晚场第二节上课超过限制时间 {1}:{2},考勤无效",
                            lStrIdentity, config.FP_LESSON_ENTER_4_HH, config.FP_LESSON_ENTER_4_MM);
                            break;
                        } 
                                 
                            this.LESSON_ENTER_2 = lDtIdentity;
                            this.remark = string.Format("{0} 开始进行第二节上课", lStrIdentity);
                            isCheckin = true;
                     

                    }
                    else if (DateTimeHelper.fnIsNewDateTime(this.LESSON_LEAVE_2))
                    {
                        if (fnIsVaildTime(this.LESSON_ENTER_2, lDtIdentity, gIntLessonInterval))
                        {
                            // lStrParm0 = lStrPrfLESSON_LEAVE + "_2";
                            this.LESSON_LEAVE_2 = lDtIdentity;
                            //this.statue = STATUE_LESSON_END;
                            this.statue = fpLocalType.nextStatus(STATUE_LESSON_END);
                            this.remark = string.Format("{0} 完成上课学时要求", lStrIdentity);
                      
                            isCheckin = true;
                        }
                        else
                        {
                            this.remark = string.Format("{0} 第二节上课时间未达到{1}分钟，提早离场将被视为无效", lStrIdentity, gIntLessonInterval);
                        }
                    }
                    break;
                }//case "lesson"
            case "km1": {
                if (fpLocalType.KM1_IND != "Y") {
                    this.remark = string.Format("学员类型：{0}，无需进行科目1考试", fpLocalType.NAME);
                        break;
                }
                else if (fpLocalType.LESSON_IND=="Y" &&this.statue < STATUE_LESSON_END)
                {
                    this.remark = string.Format("{0} 未完成上课，不能进行科目1考试", lStrIdentity);
                    break;
                }
                else if (!DateTimeHelper.fnIsNewDateTime(this.KM1_ENTER))
                {
                    this.remark = string.Format("{0} 学员在{1}已进行科目1考试，不能重复考试", lStrIdentity, this.KM1_ENTER.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                }
  
                    this.km1_enter = lDtIdentity;
                    //this.statue = STATUE_KM1_ENTER;
                    this.statue = fpLocalType.nextStatus(STATUE_KM1_ENTER);
                    this.remark = string.Format("{0} 科目1考试验证成功", lStrIdentity);
                    isCheckin = true;
                break; 
            } //case km1
            case "km2": {
                if (fpLocalType.KM2_IND != "Y")
                {
                    this.remark = string.Format("学员类型：{0}，无需进行科目2桩考", fpLocalType.NAME);
                    break;
                }
                else if (fpLocalType.KM1_IND=="Y"&& this.statue < STATUE_KM1_ENTER)
                {
                    this.remark = string.Format("{0} 未进行科目1考试，不能进行科目2考试", lStrIdentity);
                    break;
                }
                else if (!DateTimeHelper.fnIsNewDateTime(this.KM2_ENTER))
                {
                    this.remark = string.Format("{0} 学员在{1}已进行科目2考试，不能重复考试", lStrIdentity, this.KM2_ENTER.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                }

                    this.km2_enter = lDtIdentity;
                    if (this.statue < STATUE_TRAIN_END) {
                        //this.statue = STATUE_KM2_ENTER;
                        this.statue = fpLocalType.nextStatus(STATUE_KM2_ENTER);
                    }
                    
                    this.remark = string.Format("{0} 科目2考试验证成功", lStrIdentity);
                    isCheckin = true;
                break; 
            } //case km2
            case "train": {
                if (fpLocalType.TRAIN_TIMES <1)
                {
                    this.remark = string.Format("学员类型：{0}，无需进行入场训练", fpLocalType.NAME);
                    break;
                }
                else if (fpLocalType.KM1_IND=="Y"&& this.statue < STATUE_KM1_ENTER)
                {
                    this.remark = string.Format("{0} 未进行科目1考试，不能进行入场训练", lStrIdentity);
                    break;
                }
                else if (this.statue >=  STATUE_TRAIN_END)
                {
                    this.remark = string.Format("{0} 已完成入场训练", lStrIdentity);
                    break;
                }
                int trainTimes = 0;
                string re = string.Empty;
                string patternTrainEnter="{0}  开始进行第{1}次入场训练";
                string patternTrainEnterNotToday = "{0} 第{1}次的训练未完成,第{1}次的记录将被清空，请再次验证";
                string patternTrainLeave = "{0} 已完成今天的入场训练";
                string patternTrainLeaveFaile = "{0} 今天的入场训练时间未达到{1}分钟，离场将被作为训练无效处理";
                string patternTrainEnterIsToday = "{0}  今天的入场训练已完成，同一天不能入场两次";
                string patternTrainFinish = "{0}  已进行{1}次入场训练，入场训练完成";
                string patternTrainLeveeFaile2 = "{0} 未达到离场最早限制时间 {1}:{2}，现在离场将被视为考勤无效";
                //1
                if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_1) || DateTimeHelper.fnIsNewDateTime(this.TRAIN_LEAVE_1))
                {
                    if (DateTimeHelper.fnIsNewDateTime(this.TRAIN_ENTER_1))
                    {
                        re = config.checkTrainEnter(lDtIdentity);
                        if (re != string.Empty) {
                            this.remark = re;
                            break;
                        }
                        this.train_enter_1 = lDtIdentity;
                        this.statue = STATUE_TRAIN_START;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity,1);
                        isCheckin = true;
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_1, lDtIdentity))
                    {

                        this.train_enter_1 = lDtNull;
                        this.train_leave_1 = lDtNull;
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 1);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_1, lDtIdentity, gIntTrainInterval))
                    {
                        re = config.checkTrainLeave(lDtIdentity,this.TRAIN_ENTER_1);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_leave_1 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                        isCheckin = true;
                        trainTimes = 1;
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

                        re = config.checkTrainEnter(lDtIdentity);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_enter_2 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 2);
                        isCheckin = true;
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_2, lDtIdentity))
                    {
                        this.train_enter_2 = lDtNull;
                        this.train_leave_2 = lDtNull;
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 2);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_2, lDtIdentity, gIntTrainInterval))
                    {
                        re = config.checkTrainLeave(lDtIdentity, this.TRAIN_ENTER_2);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_leave_2 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                        isCheckin = true;
                        trainTimes = 2;
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

                        re = config.checkTrainEnter(lDtIdentity);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        } 
                        this.train_enter_3 = lDtIdentity;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity,3);
                        isCheckin = true;
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_3, lDtIdentity))
                    {
                        this.train_enter_3 = lDtNull;
                        this.train_leave_3 = lDtNull;
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 3);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_3, lDtIdentity, gIntTrainInterval))
                    {
                        re = config.checkTrainLeave(lDtIdentity, this.TRAIN_ENTER_3);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_leave_3 = lDtIdentity;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                        isCheckin = true;
                        trainTimes = 3;
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
                        re = config.checkTrainEnter(lDtIdentity);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_enter_4 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 4);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_4, lDtIdentity))
                    {
                        this.train_enter_4 = lDtNull;
                        this.train_leave_4 = lDtNull;
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 4);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_4, lDtIdentity, gIntTrainInterval))
                    {
                        re = config.checkTrainLeave(lDtIdentity, this.TRAIN_ENTER_4);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_leave_4 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                        trainTimes = 4;
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
                        re = config.checkTrainEnter(lDtIdentity);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_enter_5 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 5);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_5, lDtIdentity))
                    {
                        this.train_enter_5 = lDtNull;
                        this.train_leave_5 = lDtNull;
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 5);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_5, lDtIdentity, gIntTrainInterval))
                    {
                        re = config.checkTrainLeave(lDtIdentity, this.TRAIN_ENTER_5);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_leave_5 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                        trainTimes = 5;
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
                        re = config.checkTrainEnter(lDtIdentity);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_enter_6 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 6);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_6, lDtIdentity))
                    {
                        this.train_enter_6 = lDtNull;
                        this.train_leave_6 = lDtNull;
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 6);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_6, lDtIdentity, gIntTrainInterval))
                    {
                        re = config.checkTrainLeave(lDtIdentity, this.TRAIN_ENTER_6);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_leave_6 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                        trainTimes = 6;
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
                        re = config.checkTrainEnter(lDtIdentity);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_enter_7 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 7);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_7, lDtIdentity))
                    {
                        this.train_enter_7 = lDtNull;
                        this.train_leave_7 = lDtNull;
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 7);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_7, lDtIdentity, gIntTrainInterval))
                    {
                        re = config.checkTrainLeave(lDtIdentity, this.TRAIN_ENTER_7);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_leave_7 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainLeave, lStrIdentity);
                        trainTimes = 7;
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
                        re = config.checkTrainEnter(lDtIdentity);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_enter_8 = lDtIdentity;
                        isCheckin = true;
                        this.remark = string.Format(patternTrainEnter, lStrIdentity, 8);
                    }
                    else if (!fnIsVaildTime(this.TRAIN_ENTER_8, lDtIdentity))
                    {
                        this.train_enter_8 = lDtNull;
                        this.train_leave_8 = lDtNull;
                        this.remark = string.Format(patternTrainEnterNotToday, lStrIdentity, 8);
                    }
                    else if (fnIsVaildTime(this.TRAIN_ENTER_8, lDtIdentity, gIntTrainInterval))
                    {
                        re = config.checkTrainLeave(lDtIdentity, this.TRAIN_ENTER_8);
                        if (re != string.Empty)
                        {
                            this.remark = re;
                            break;
                        }
                        this.train_leave_8 = lDtIdentity;
                        isCheckin = true;
                        this.statue = STATUE_TRAIN_END;
                        this.remark = string.Format(patternTrainFinish, lStrIdentity,8);
                        trainTimes = 8;
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

                //入场训练学员分类
                if (trainTimes >= fpLocalType.TRAIN_TIMES) {
                    //this.statue = STATUE_TRAIN_END;
                    this.statue = fpLocalType.nextStatus(STATUE_TRAIN_END);
                    this.TRAIN_END_DATE = DateTime.Now;
                    this.remark = string.Format(patternTrainLeave, lStrIdentity,trainTimes);                 
                }
                break; 
            }//case "train"
            case "3in9":
                {
                    if (fpLocalType.KM2_3IN9_IND != "Y")
                    {
                        this.remark = string.Format("学员类型：{0}，无需进行9选3考试", fpLocalType.NAME);
                        break;
                    }
                    else if (fpLocalType.KM1_IND == "Y" && this.statue < STATUE_KM1_ENTER)
                    {
                        this.remark = string.Format("{0} 未完成科目1考试，不能进行9选3考试", lStrIdentity);
                        break;
                    }
                    else if (!DateTimeHelper.fnIsNewDateTime(this.KM2_3IN9_ENTER))
                    {
                        this.remark = string.Format("{0} 学员在{1}已进行9选3考试，不能重复考试", lStrIdentity,this.KM2_3IN9_ENTER.ToString("yyyy-MM-dd HH:mm:ss"));
                        break;
                    }

                    this.km2_3in9_enter = lDtIdentity;
                    isCheckin = true;
                    if (this.statue < STATUE_TRAIN_END)
                    {
                        //this.statue = STATUE_3IN9_ENTER;
                        this.statue = fpLocalType.nextStatus(STATUE_3IN9_ENTER);
                    }
                    this.remark = string.Format("{0} 9选3考试验证成功", lStrIdentity);
                    break;
                }//case 3in9
            case "km3": {
                if (fpLocalType.KM3_IND != "Y")
                {
                    this.remark = string.Format("学员类型：{0}，无需进行科目3考试", fpLocalType.NAME);
                    break;
                }
                else if (fpLocalType.KM2_3IN9_IND == "Y" && DateTimeHelper.fnIsNewDateTime(this.KM2_3IN9_ENTER))
                {
                    this.remark = string.Format("{0} 未完成9选3考试，不能进行科目3考试", lStrIdentity);
                    break;
                }
                else if (fpLocalType.KM2_IND == "Y" && DateTimeHelper.fnIsNewDateTime(this.KM2_ENTER))
                {
                    this.remark = string.Format("{0} 未完成科目2考试，不能进行科目3考试", lStrIdentity);
                    break;
                }

                 else if (this.statue < STATUE_TRAIN_END&&fpLocalType.TRAIN_TIMES>0)
                 {
                     this.remark = string.Format("{0} 未完成入场训练，不能进行科目3考试", lStrIdentity);
                     break;
                 }
                 else if (fpLocalType.KM3_VERIFY_IND == "Y" && this.KM3_VERIFY != "Y")
                 {
                     this.remark = string.Format("{0} 学员未通过科目3审核，不能进行科目3考试", lStrIdentity);
                     break;
                 }
                 else if (this.statue >= STATUE_KM3_ENTER)
                 {
                     this.remark = string.Format("{0} 学员在{1}已进行科目3考试，不能重复考试", lStrIdentity, this.KM3_ENTER.ToString("yyyy-MM-dd HH:mm:ss"));
                     break;
                 }

                this.km3_enter = lDtIdentity;
                isCheckin = true;
                //this.statue = STATUE_KM3_ENTER;
                this.statue = fpLocalType.nextStatus(STATUE_KM3_ENTER);
                this.remark = string.Format("{0} 科目3考试验证成功", lStrIdentity);
                break; 
            }//case km3
            default : break;
        }
        return isCheckin;
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
