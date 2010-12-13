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
///SchoolCarInfo 的摘要说明
/// </summary>table_school_car_info
[SimpleTable("table_school_car_info")]
[Alias("驾校车辆信息")]
public class SchoolCarInfo
{
    public SchoolCarInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_school_car_info")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "clpp")]
    [Alias("车辆品牌")]
    public String Clpp;

    public String 车辆品牌
    {
        get { return Clpp; }
        set { Clpp = value; }
    }
    [SimpleColumn(Column = "coachno")]
    [Alias("教练证号")]
    public String CoachNo;

    public String 教练证号
    {
        get { return CoachNo; }
        set { CoachNo = value; }
    }

    [SimpleColumn(Column = "depcode")]
    [Alias("部门代码")]
    public String DepCode;

    public String 部门代码
    {
        get { return DepCode; }
        set { DepCode = value; }
    }


    [SimpleColumn(Column = "depname")]
    [Alias("部门名称")]
    public String DepName;

    public String 部门名称
    {
        get { return DepName; }
        set { DepName = value; }
    }

    [SimpleColumn(Column = "hmhp")]
    [Alias("号码号牌")]
    public String Hmhp;

    public String 号码号牌
    {
        get { return Hmhp; }
        set { Hmhp = value; }
    }

    [SimpleColumn(Column = "idcard")]
    [Alias("教练身份证明号")]
    public String IdCard;

    public String 教练身份证明号
    {
        get { return IdCard; }
        set { IdCard = value; }
    }

    [SimpleColumn(Column = "mobile")]
    [Alias("教练联系手机")]
    public String Mobile;

    public String 教练联系手机
    {
        get { return Mobile; }
        set { Mobile = value; }
    }

    [SimpleColumn(Column = "name")]
    [Alias("教练姓名")]
    public String CoachName;

    public String 教练姓名
    {
        get { return CoachName; }
        set { CoachName = value; }
    }

    [SimpleColumn(Column = "glbm")]
    [Alias("管理部门代码")]
    public String Glbm;

    public String 管理部门代码
    {
        get { return Glbm; }
        set { Glbm = value; }
    }
}
