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
using FT.Commons.Tools;

/// <summary>
///FPConfig 的摘要说明
/// </summary>
[Serializable]
[SimpleTable("FP_CONFIG")]
[Alias("指蚊考勤配置表")]
public class FPConfig
{

    public string checkTrainEnter(DateTime dt)
    {
        string re = string.Empty;
        if (
            (DateTimeHelper.fnIsBetweenTime(dt, this.FP_TRAIN_1_ENTER_FROM_HH, this.FP_TRAIN_1_ENTER_FROM_MM, this.FP_TRAIN_1_ENTER_TO_HH, this.FP_TRAIN_1_ENTER_TO_MM))
           || (DateTimeHelper.fnIsBetweenTime(dt, this.FP_TRAIN_2_ENTER_FROM_HH, this.FP_TRAIN_2_ENTER_FROM_MM, this.FP_TRAIN_2_ENTER_TO_HH, this.FP_TRAIN_2_ENTER_TO_MM))
        || (DateTimeHelper.fnIsBetweenTime(dt, this.FP_TRAIN_3_ENTER_FROM_HH, this.FP_TRAIN_3_ENTER_FROM_MM, this.FP_TRAIN_3_ENTER_TO_HH, this.FP_TRAIN_3_ENTER_TO_MM))
        )
        {
            return re;
        }
        else {
            return string.Format("{0}  入场时间不在有效范围内，考勤无效",dt.ToString());
        }
    }

    public string checkTrainLeave(DateTime dt,DateTime ldt) {
        string re = string.Empty;
        if (DateTimeHelper.fnIsBetweenTime(ldt, this.FP_TRAIN_1_ENTER_FROM_HH, this.FP_TRAIN_1_ENTER_FROM_MM, this.FP_TRAIN_1_ENTER_TO_HH, this.FP_TRAIN_1_ENTER_TO_MM))
        {
            if (DateTimeHelper.fnIsBeforeTime(dt,this.FP_TRAIN_1_LEAVE_HH,this.FP_TRAIN_1_LEAVE_MM)) {
                re = string.Format("{0}  早场入场学员必需在{1}:{2}之后才能离场，提早离场将被视为考勤无效", dt.ToString(), this.FP_TRAIN_1_LEAVE_HH, this.FP_TRAIN_1_LEAVE_MM);
            }
        }
        else if (DateTimeHelper.fnIsBetweenTime(ldt, this.FP_TRAIN_2_ENTER_FROM_HH, this.FP_TRAIN_2_ENTER_FROM_MM, this.FP_TRAIN_2_ENTER_TO_HH, this.FP_TRAIN_2_ENTER_TO_MM))
        {
            if (DateTimeHelper.fnIsBeforeTime(dt, this.FP_TRAIN_2_LEAVE_HH, this.FP_TRAIN_2_LEAVE_MM))
            {
                re = string.Format("{0}  中场入场学员必需在{1}:{2}之后才能离场，提早离场将被视为考勤无效", dt.ToString(), this.FP_TRAIN_2_LEAVE_HH, this.FP_TRAIN_2_LEAVE_MM);
            }
        }
        else if (DateTimeHelper.fnIsBetweenTime(ldt, this.FP_TRAIN_3_ENTER_FROM_HH, this.FP_TRAIN_3_ENTER_FROM_MM, this.FP_TRAIN_3_ENTER_TO_HH, this.FP_TRAIN_3_ENTER_TO_MM))
        {
            if (DateTimeHelper.fnIsBeforeTime(dt, this.FP_TRAIN_3_LEAVE_HH, this.FP_TRAIN_3_LEAVE_MM))
            {
                re = string.Format("{0}  晚场入场学员必需在{1}:{2}之后才能离场，提早离场将被视为考勤无效", dt.ToString(), this.FP_TRAIN_3_LEAVE_HH, this.FP_TRAIN_3_LEAVE_MM);
            }
        }
        return re;
    }

    [SimplePK]
    [SimpleColumn(Column = "ID", ColumnType = SimpleColumnType.Int)]
    private int id ;

    [SimpleColumn(Column = "FP_LESSON_INTERVAL", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_interval;   // FP_LESSON_INTERVAL

    [SimpleColumn(Column = "FP_TRAIN_INTERVAL", ColumnType = SimpleColumnType.Int)]
    private int fp_train_interval;

    [SimpleColumn(Column = "FP_TRAIN_1_ENTER_FROM_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_1_enter_from_mm;

    [SimpleColumn(Column = "FP_TRAIN_1_ENTER_FROM_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_1_enter_from_hh;

    [SimpleColumn(Column = "FP_TRAIN_1_ENTER_TO_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_1_enter_to_mm;

    [SimpleColumn(Column = "FP_TRAIN_1_ENTER_TO_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_1_enter_to_hh;


    [SimpleColumn(Column = "FP_TRAIN_2_ENTER_FROM_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_2_enter_from_mm;

    [SimpleColumn(Column = "FP_TRAIN_2_ENTER_FROM_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_2_enter_from_hh;

    [SimpleColumn(Column = "FP_TRAIN_2_ENTER_TO_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_2_enter_to_mm;

    [SimpleColumn(Column = "FP_TRAIN_2_ENTER_TO_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_2_enter_to_hh;


    [SimpleColumn(Column = "FP_TRAIN_3_ENTER_FROM_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_3_enter_from_mm;

    [SimpleColumn(Column = "FP_TRAIN_3_ENTER_FROM_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_3_enter_from_hh;

    [SimpleColumn(Column = "FP_TRAIN_3_ENTER_TO_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_3_enter_to_mm;

    [SimpleColumn(Column = "FP_TRAIN_3_ENTER_TO_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_3_enter_to_hh;


    [SimpleColumn(Column = "FP_TRAIN_1_LEAVE_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_1_leave_mm;

    [SimpleColumn(Column = "FP_TRAIN_1_LEAVE_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_1_leave_hh;


    [SimpleColumn(Column = "FP_TRAIN_2_LEAVE_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_2_leave_mm;

    [SimpleColumn(Column = "FP_TRAIN_2_LEAVE_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_2_leave_hh;


    [SimpleColumn(Column = "FP_TRAIN_3_LEAVE_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_train_3_leave_mm;

    [SimpleColumn(Column = "FP_TRAIN_3_LEAVE_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_train_3_leave_hh;


    [SimpleColumn(Column = "FP_LESSON_ENTER_1_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_enter_1_mm;

    [SimpleColumn(Column = "FP_LESSON_ENTER_1_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_enter_1_hh;

    [SimpleColumn(Column = "FP_LESSON_ENTER_2_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_enter_2_mm;

    [SimpleColumn(Column = "FP_LESSON_ENTER_2_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_enter_2_hh;

    [SimpleColumn(Column = "FP_LESSON_ENTER_3_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_enter_3_mm;

    [SimpleColumn(Column = "FP_LESSON_ENTER_3_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_enter_3_hh;

    [SimpleColumn(Column = "FP_LESSON_ENTER_4_MM", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_enter_4_mm;

    [SimpleColumn(Column = "FP_LESSON_ENTER_4_HH", ColumnType = SimpleColumnType.Int)]
    private int fp_lesson_enter_4_hh;

    public FPConfig()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //

    }


    public int ID {
        get { return this.id; }
        set { this.id = value; }
    }


    public int FP_LESSON_INTERVAL
    {
        get { return this.fp_lesson_interval; }
        set { this.fp_lesson_interval = value; }
    }


    public int FP_TRAIN_INTERVAL
    {
        get { return this.fp_train_interval; }
        set { this.fp_train_interval = value; }
    }

    public int FP_TRAIN_1_ENTER_FROM_MM
    {
        get { return this.fp_train_1_enter_from_mm; }
        set { this.fp_train_1_enter_from_mm = value; }
    }

    public int FP_TRAIN_1_ENTER_FROM_HH
    {
        get { return this.fp_train_1_enter_from_hh; }
        set { this.fp_train_1_enter_from_hh = value; }
    }

    public int FP_TRAIN_1_ENTER_TO_MM
    {
        get { return this.fp_train_1_enter_to_mm; }
        set { this.fp_train_1_enter_to_mm = value; }
    }

    public int FP_TRAIN_1_ENTER_TO_HH
    {
        get { return this.fp_train_1_enter_to_hh; }
        set { this.fp_train_1_enter_to_hh = value; }
    }



    public int FP_TRAIN_2_ENTER_FROM_MM
    {
        get { return this.fp_train_2_enter_from_mm; }
        set { this.fp_train_2_enter_from_mm = value; }
    }

    public int FP_TRAIN_2_ENTER_FROM_HH
    {
        get { return this.fp_train_2_enter_from_hh; }
        set { this.fp_train_2_enter_from_hh = value; }
    }

    public int FP_TRAIN_2_ENTER_TO_MM
    {
        get { return this.fp_train_2_enter_to_mm; }
        set { this.fp_train_2_enter_to_mm = value; }
    }

    public int FP_TRAIN_2_ENTER_TO_HH
    {
        get { return this.fp_train_2_enter_to_hh; }
        set { this.fp_train_2_enter_to_hh = value; }
    }



    public int FP_TRAIN_3_ENTER_FROM_MM
    {
        get { return this.fp_train_3_enter_from_mm; }
        set { this.fp_train_3_enter_from_mm = value; }
    }

    public int FP_TRAIN_3_ENTER_FROM_HH
    {
        get { return this.fp_train_3_enter_from_hh; }
        set { this.fp_train_3_enter_from_hh = value; }
    }

    public int FP_TRAIN_3_ENTER_TO_MM
    {
        get { return this.fp_train_3_enter_to_mm; }
        set { this.fp_train_3_enter_to_mm = value; }
    }

    public int FP_TRAIN_3_ENTER_TO_HH
    {
        get { return this.fp_train_3_enter_to_hh; }
        set { this.fp_train_3_enter_to_hh = value; }
    }


    public int FP_TRAIN_1_LEAVE_MM
    {
        get { return this.fp_train_1_leave_mm; }
        set { this.fp_train_1_leave_mm = value; }
    }

    public int FP_TRAIN_1_LEAVE_HH
    {
        get { return this.fp_train_1_leave_hh; }
        set { this.fp_train_1_leave_hh = value; }
    }


    public int FP_TRAIN_2_LEAVE_MM
    {
        get { return this.fp_train_2_leave_mm; }
        set { this.fp_train_2_leave_mm = value; }
    }

    public int FP_TRAIN_2_LEAVE_HH
    {
        get { return this.fp_train_2_leave_hh; }
        set { this.fp_train_2_leave_hh = value; }
    }

    public int FP_TRAIN_3_LEAVE_MM
    {
        get { return this.fp_train_3_leave_mm; }
        set { this.fp_train_3_leave_mm = value; }
    }

    public int FP_TRAIN_3_LEAVE_HH
    {
        get { return this.fp_train_3_leave_hh; }
        set { this.fp_train_3_leave_hh = value; }
    }


    public int FP_LESSON_ENTER_1_MM
    {
        get { return this.fp_lesson_enter_1_mm; }
        set { this.fp_lesson_enter_1_mm = value; }
    }

    public int FP_LESSON_ENTER_1_HH
    {
        get { return this.fp_lesson_enter_1_hh; }
        set { this.fp_lesson_enter_1_hh = value; }
    }

    public int FP_LESSON_ENTER_2_MM
    {
        get { return this.fp_lesson_enter_2_mm; }
        set { this.fp_lesson_enter_2_mm = value; }
    }

    public int FP_LESSON_ENTER_2_HH
    {
        get { return this.fp_lesson_enter_2_hh; }
        set { this.fp_lesson_enter_2_hh = value; }
    }

    public int FP_LESSON_ENTER_3_MM
    {
        get { return this.fp_lesson_enter_3_mm; }
        set { this.fp_lesson_enter_3_mm = value; }
    }

    public int FP_LESSON_ENTER_3_HH
    {
        get { return this.fp_lesson_enter_3_hh; }
        set { this.fp_lesson_enter_3_hh = value; }
    }

    public int FP_LESSON_ENTER_4_MM
    {
        get { return this.fp_lesson_enter_3_mm; }
        set { this.fp_lesson_enter_3_mm = value; }
    }

    public int FP_LESSON_ENTER_4_HH
    {
        get { return this.fp_lesson_enter_4_hh; }
        set { this.fp_lesson_enter_4_hh = value; }
    }


    public static FPConfig GetCurrConfig() {

        return SimpleOrmOperator.QueryListAll(typeof(FPConfig))[0] as FPConfig;
    
    }

}
