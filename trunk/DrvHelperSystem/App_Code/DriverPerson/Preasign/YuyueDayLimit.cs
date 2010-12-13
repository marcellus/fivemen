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
///YuyueDayLimit 的摘要说明
/// </summary>
[SimpleTable("table_yuyue_day_limit")]
[Alias("预约的时间间隔")]
public class YuyueDayLimit
{
    public YuyueDayLimit()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_yuyue_day_limit")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "c_cartype")]
    [Alias("车辆类别")]
    public String CarType;

    public String 车辆类别
    {
        get { return CarType; }
        set { CarType = value; }
    }

    [SimpleColumn(Column = "i_days")]
    [Alias("间隔天数")]
    public int Days;

    public int 间隔天数
    {
        get { return Days; }
        set { Days = value; }
    }

    [SimpleColumn(Column = "i_km")]
    [Alias("科目")]
    public int Km;

    public int 科目
    {
        get { return Km; }
        set { Km = value; }
    }
}
