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
///YuyueLimit 的摘要说明
/// </summary>
[SimpleTable("table_yuyue_limit")]
[Alias("限制条件")]
public class YuyueLimit
{
    public YuyueLimit()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_yuyue_limit")]
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



    [SimpleColumn(Column = "c_car_type")]
    [Alias("准考车型")]
    public String CarType;

    public String 准考车型
    {
        get { return CarType; }
        set { CarType = value; }
    }

    [SimpleColumn(Column = "i_dayofweek")]
    [Alias("星期")]
    public int DayOfWeek;

    public int 星期
    {
        get { return DayOfWeek; }
        set { DayOfWeek = value; }
    }

    [SimpleColumn(Column = "i_km")]
    [Alias("考试科目")]
    public int Km;

    public int 考试科目
    {
        get { return Km; }
        set { Km = value; }
    }

    [SimpleColumn(Column = "c_school_code")]
    [Alias("驾校代码")]
    public String SchoolCode;

    public String 驾校代码
    {
        get { return SchoolCode; }
        set { SchoolCode = value; }
    }

    [SimpleColumn(Column = "c_school_name")]
    [Alias("驾校名称")]
    public String SchoolName;

    public String 驾校名称
    {
        get { return SchoolName; }
        set { SchoolName = value; }
    }

    [SimpleColumn(Column = "date_ksrq")]
    [Alias("考试日期")]
    public String Ksrq;

    public String 考试日期
    {
        get { return Ksrq; }
        set { Ksrq = value; }
    }

    [SimpleColumn(Column = "c_kscc_code")]
    [Alias("考试场次代码")]
    public String KsccCode;

    public String 考试场次代码
    {
        get { return KsccCode; }
        set { KsccCode = value; }
    }

    [SimpleColumn(Column = "c_kscc")]
    [Alias("考试场次")]
    public String Kscc;

    public String 考试场次
    {
        get { return Kscc; }
        set { Kscc = value; }
    }

    [SimpleColumn(Column = "c_ksdd_code")]
    [Alias("考试地点代码")]
    public String KsddCode;

    public String 考试地点代码
    {
        get { return KsddCode; }
        set { KsddCode = value; }
    }

    [SimpleColumn(Column = "c_ksdd")]
    [Alias("考试地点")]
    public String Ksdd;

    public String 考试地点
    {
        get { return Ksdd; }
        set { Ksdd = value; }
    }

    [SimpleColumn(Column = "i_total")]
    [Alias("允许人数")]
    public int Total;

    public int 允许人数
    {
        get { return Total; }
        set { Total = value; }
    }

    [SimpleColumn(Column = "i_used_num")]
    [Alias("已使用人数")]
    public int UsedNum;

    public int 已使用人数
    {
        get { return UsedNum; }
        set { UsedNum = value; }
    }

    [SimpleColumn(Column = "i_checked_num")]
    [Alias("已审核的人数")]
    public int CheckedNum;

    public int 已审核的人数
    {
        get { return CheckedNum; }
        set { CheckedNum = value; }
    }

    [SimpleColumn(Column = "i_tptotal")]
    [Alias("特批允许人数")]
    public int TpTotal;

    public int 特批允许人数
    {
        get { return TpTotal; }
        set { TpTotal = value; }
    }

    [SimpleColumn(Column = "i_tpused_num")]
    [Alias("特批已使用人数")]
    public int TpUsedNum;

    public int 特批已使用人数
    {
        get { return TpUsedNum; }
        set { TpUsedNum = value; }
    }

    [SimpleColumn(Column = "i_tpchecked_num")]
    [Alias("特批已审核的人数")]
    public int TpCheckedNum;

    public int 特批已审核的人数
    {
        get { return TpCheckedNum; }
        set { TpCheckedNum = value; }
    }

    [SimpleColumn(Column = "c_operator")]
    [Alias("操作员")]
    public String Operator;

    public String 操作员
    {
        get { return Operator; }
        set { Operator = value; }
    }


}
