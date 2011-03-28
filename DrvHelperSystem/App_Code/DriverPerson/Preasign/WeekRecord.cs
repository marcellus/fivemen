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

/// <summary>
///WeekRecord 的摘要说明
/// </summary>
[SimpleTable("table_week_record")]
[Alias("周排班表")]
public class WeekRecord
{
    public WeekRecord()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_week_record")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "i_week_num")]
    [Alias("第几周")]
    public int WeekNum;

    public int 第几周
    {
        get { return WeekNum; }
        set { WeekNum = value; }
    }

    [SimpleColumn(Column = "i_week1_km1_num")]
    [Alias("周一科目一总数")]
    public int Week1km1Num=0;

    public int 周一科目一总数
    {
        get { return Week1km1Num; }
        set { Week1km1Num = value; }
    }

    [SimpleColumn(Column = "i_week1_km1_fp")]
    [Alias("周一科目一分配")]
    public String Week1km1fp ;

    public String 周一科目一分配
    {
        get { return Week1km1fp; }
        set { Week1km1fp = value; }
    }

    [SimpleColumn(Column = "i_week1_km2_num")]
    [Alias("周一科目二总数")]
    public int Week1km2Num = 0;

    public int 周一科目二总数
    {
        get { return Week1km2Num; }
        set { Week1km2Num = value; }
    }

    [SimpleColumn(Column = "i_week1_km2_fp")]
    [Alias("周一科目二分配")]
    public String Week1km2fp ;

    public String 周一科目二分配
    {
        get { return Week1km2fp; }
        set { Week1km2fp = value; }
    }


    [SimpleColumn(Column = "i_week1_km3_num")]
    [Alias("周一科目一总数")]
    public int Week1km3Num = 0;

    public int 周一科目三总数
    {
        get { return Week1km3Num; }
        set { Week1km3Num = value; }
    }

    [SimpleColumn(Column = "i_week1_km3_fp")]
    [Alias("周一科目三分配")]
    public String Week1km3fp ;

    public String 周一科目三分配
    {
        get { return Week1km3fp; }
        set { Week1km3fp = value; }
    }

    [SimpleColumn(Column = "i_week2_km1_num")]
    [Alias("周二科目一总数")]
    public int Week2km1Num = 0;

    public int 周二科目一总数
    {
        get { return Week2km1Num; }
        set { Week2km1Num = value; }
    }

    [SimpleColumn(Column = "i_week2_km1_fp")]
    [Alias("周二科目一分配")]
    public String Week2km1fp ;

    public String 周二科目一分配
    {
        get { return Week2km1fp; }
        set { Week2km1fp = value; }
    }

    [SimpleColumn(Column = "i_week2_km2_num")]
    [Alias("周二科目二总数")]
    public int Week2km2Num = 0;

    public int 周二科目二总数
    {
        get { return Week2km2Num; }
        set { Week2km2Num = value; }
    }

    [SimpleColumn(Column = "i_week2_km2_fp")]
    [Alias("周二科目二分配")]
    public String Week2km2fp ;

    public String 周二科目二分配
    {
        get { return Week2km2fp; }
        set { Week2km2fp = value; }
    }


    [SimpleColumn(Column = "i_week2_km3_num")]
    [Alias("周二科目一总数")]
    public int Week2km3Num = 0;

    public int 周二科目三总数
    {
        get { return Week2km3Num; }
        set { Week2km3Num = value; }
    }

    [SimpleColumn(Column = "i_week2_km3_fp")]
    [Alias("周二科目三分配")]
    public String Week2km3fp ;

    public String 周二科目三分配
    {
        get { return Week2km3fp; }
        set { Week2km3fp = value; }
    }

    [SimpleColumn(Column = "i_week3_km1_num")]
    [Alias("周三科目一总数")]
    public int Week3km1Num = 0;

    public int 周三科目一总数
    {
        get { return Week3km1Num; }
        set { Week3km1Num = value; }
    }

    [SimpleColumn(Column = "i_week3_km1_fp")]
    [Alias("周三科目一分配")]
    public String Week3km1fp;

    public String 周三科目一分配
    {
        get { return Week3km1fp; }
        set { Week3km1fp = value; }
    }

    [SimpleColumn(Column = "i_week3_km2_num")]
    [Alias("周三科目二总数")]
    public int Week3km2Num = 0;

    public int 周三科目二总数
    {
        get { return Week3km2Num; }
        set { Week3km2Num = value; }
    }

    [SimpleColumn(Column = "i_week3_km2_fp")]
    [Alias("周三科目二分配")]
    public String Week3km2fp ;

    public String 周三科目二分配
    {
        get { return Week3km2fp; }
        set { Week3km2fp = value; }
    }


    [SimpleColumn(Column = "i_week3_km3_num")]
    [Alias("周三科目一总数")]
    public int Week3km3Num = 0;

    public int 周三科目三总数
    {
        get { return Week3km3Num; }
        set { Week3km3Num = value; }
    }

    [SimpleColumn(Column = "i_week3_km3_fp")]
    [Alias("周三科目三分配")]
    public String Week3km3fp ;

    public String 周三科目三分配
    {
        get { return Week3km3fp; }
        set { Week3km3fp = value; }
    }

    [SimpleColumn(Column = "i_week4_km1_num")]
    [Alias("周四科目一总数")]
    public int Week4km1Num = 0;

    public int 周四科目一总数
    {
        get { return Week4km1Num; }
        set { Week4km1Num = value; }
    }

    [SimpleColumn(Column = "i_week4_km1_fp")]
    [Alias("周四科目一分配")]
    public String Week4km1fp ;

    public String 周四科目一分配
    {
        get { return Week4km1fp; }
        set { Week4km1fp = value; }
    }

    [SimpleColumn(Column = "i_week4_km2_num")]
    [Alias("周四科目二总数")]
    public int Week4km2Num = 0;

    public int 周四科目二总数
    {
        get { return Week4km2Num; }
        set { Week4km2Num = value; }
    }

    [SimpleColumn(Column = "i_week4_km2_fp")]
    [Alias("周四科目二分配")]
    public String Week4km2fp ;

    public String 周四科目二分配
    {
        get { return Week4km2fp; }
        set { Week4km2fp = value; }
    }


    [SimpleColumn(Column = "i_week4_km3_num")]
    [Alias("周四科目一总数")]
    public int Week4km3Num = 0;

    public int 周四科目三总数
    {
        get { return Week4km3Num; }
        set { Week4km3Num = value; }
    }

    [SimpleColumn(Column = "i_week4_km3_fp")]
    [Alias("周四科目三分配")]
    public String Week4km3fp ;

    public String 周四科目三分配
    {
        get { return Week4km3fp; }
        set { Week4km3fp = value; }
    }


    [SimpleColumn(Column = "i_week5_km1_num")]
    [Alias("周五科目一总数")]
    public int Week5km1Num = 0;

    public int 周五科目一总数
    {
        get { return Week5km1Num; }
        set { Week5km1Num = value; }
    }

    [SimpleColumn(Column = "i_week5_km1_fp")]
    [Alias("周五科目一分配")]
    public String Week5km1fp ;

    public String 周五科目一分配
    {
        get { return Week5km1fp; }
        set { Week5km1fp = value; }
    }

    [SimpleColumn(Column = "i_week5_km2_num")]
    [Alias("周五科目二总数")]
    public int Week5km2Num = 0;

    public int 周五科目二总数
    {
        get { return Week5km2Num; }
        set { Week5km2Num = value; }
    }

    [SimpleColumn(Column = "i_week5_km2_fp")]
    [Alias("周五科目二分配")]
    public String Week5km2fp ;

    public String 周五科目二分配
    {
        get { return Week5km2fp; }
        set { Week5km2fp = value; }
    }


    [SimpleColumn(Column = "i_week5_km3_num")]
    [Alias("周五科目一总数")]
    public int Week5km3Num = 0;

    public int 周五科目三总数
    {
        get { return Week5km3Num; }
        set { Week5km3Num = value; }
    }

    [SimpleColumn(Column = "i_week5_km3_fp")]
    [Alias("周五科目三分配")]
    public String Week5km3fp ;

    public String 周五科目三分配
    {
        get { return Week5km3fp; }
        set { Week5km3fp = value; }
    }

    [SimpleColumn(Column = "i_week6_km1_num")]
    [Alias("周六科目一总数")]
    public int Week6km1Num = 0;

    public int 周六科目一总数
    {
        get { return Week6km1Num; }
        set { Week6km1Num = value; }
    }

    [SimpleColumn(Column = "i_week6_km1_fp")]
    [Alias("周六科目一分配")]
    public String Week6km1fp ;

    public String 周六科目一分配
    {
        get { return Week6km1fp; }
        set { Week6km1fp = value; }
    }

    [SimpleColumn(Column = "i_week6_km2_num")]
    [Alias("周六科目二总数")]
    public int Week6km2Num = 0;

    public int 周六科目二总数
    {
        get { return Week6km2Num; }
        set { Week6km2Num = value; }
    }

    [SimpleColumn(Column = "i_week6_km2_fp")]
    [Alias("周六科目二分配")]
    public String Week6km2fp ;

    public String 周六科目二分配
    {
        get { return Week6km2fp; }
        set { Week6km2fp = value; }
    }


    [SimpleColumn(Column = "i_week6_km3_num")]
    [Alias("周六科目一总数")]
    public int Week6km3Num = 0;

    public int 周六科目三总数
    {
        get { return Week6km3Num; }
        set { Week6km3Num = value; }
    }

    [SimpleColumn(Column = "i_week6_km3_fp")]
    [Alias("周六科目三分配")]
    public String Week6km3fp ;

    public String 周六科目三分配
    {
        get { return Week6km3fp; }
        set { Week6km3fp = value; }
    }

    [SimpleColumn(Column = "i_week7_km1_num")]
    [Alias("周日科目一总数")]
    public int Week7km1Num = 0;

    public int 周日科目一总数
    {
        get { return Week7km1Num; }
        set { Week7km1Num = value; }
    }

    [SimpleColumn(Column = "i_week7_km1_fp")]
    [Alias("周日科目一分配")]
    public String Week7km1fp ;

    public String 周日科目一分配
    {
        get { return Week7km1fp; }
        set { Week7km1fp = value; }
    }

    [SimpleColumn(Column = "i_week7_km2_num")]
    [Alias("周日科目二总数")]
    public int Week7km2Num = 0;

    public int 周日科目二总数
    {
        get { return Week7km2Num; }
        set { Week7km2Num = value; }
    }

    [SimpleColumn(Column = "i_week7_km2_fp")]
    [Alias("周日科目二分配")]
    public String Week7km2fp ;

    public String 周日科目二分配
    {
        get { return Week7km2fp; }
        set { Week7km2fp = value; }
    }


    [SimpleColumn(Column = "i_week7_km3_num")]
    [Alias("周日科目一总数")]
    public int Week7km3Num = 0;

    public int 周日科目三总数
    {
        get { return Week7km3Num; }
        set { Week7km3Num = value; }
    }

    [SimpleColumn(Column = "i_week7_km3_fp")]
    [Alias("周日科目三分配")]
    public String Week7km3fp ;

    public String 周日科目三分配
    {
        get { return Week7km3fp; }
        set { Week7km3fp = value; }
    }


    [SimpleColumn(Column = "c_check_operator")]
    [Alias("审核人")]
    public String CheckOperator;

    public String 审核人
    {
        get { return CheckOperator; }
        set { CheckOperator = value; }
    }

    [SimpleColumn(Column = "c_check_date")]
    [Alias("审核时间")]
    public String CheckDate;

    public String 审核时间
    {
        get { return CheckDate; }
        set { CheckDate = value; }
    }


    [SimpleColumn(Column = "i_checked")]
    [Alias("是否审核")]
    public int Checked;

    public int 是否审核
    {
        get { return Checked; }
        set { Checked = value; }
    }

    [SimpleColumn(Column = "c_week_range")]
    [Alias("时间范围")]
    public String WeekRange;

    public String 时间范围
    {
        get { return WeekRange; }
        set { WeekRange = value; }
    }


    

}
