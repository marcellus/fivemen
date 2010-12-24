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
[SimpleTable("fp_approve")]
[Alias("指纹特批")]
public class ZwTpObject
{
    public ZwTpObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_fp_approve")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "name")]
    [Alias("姓名")]
    public String Name;

    public String 姓名
    {
        get { return Name; }
        set { Name = value; }
    }


    [SimpleColumn(Column = "school")]
    [Alias("驾校")]
    public String School;

    public String 驾校
    {
        get { return School; }
        set { School = value; }
    }


  

    [SimpleColumn(Column = "approver")]
    [Alias("特批人")]
    public String Approver;

    public String 特批人
    {
        get { return Approver; }
        set { Approver = value; }
    }

    [SimpleColumn(Column = "type")]
    [Alias("特批类别")]
    public String Type;

    public String 特批类别
    {
        get { return Type; }
        set { Type = value; }
    }

    [SimpleColumn(Column = "idcard")]
    [Alias("身份证明号码")]
    public String IdCard;

    public String 身份证明号码
    {
        get { return IdCard; }
        set { IdCard = value; }
    }

    [SimpleColumn(Column = "APPROVE_TIME")]
    [Alias("特批时间")]
    public String ApproveTime;

    public String 特批时间
    {
        get { return ApproveTime; }
        set { ApproveTime = value; }
    }
}
