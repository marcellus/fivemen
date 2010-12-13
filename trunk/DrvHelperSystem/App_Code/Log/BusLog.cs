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
///BusLog 的摘要说明
/// </summary>

[SimpleTable("table_buslogs")]
[Alias("业务日志")]
public class BusLog
{
    public BusLog()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_buslog")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "c_operator")]
    [Alias("操作者")]
    public String Operator;

    public String 操作者
    {
        get { return Operator; }
        set { Operator = value; }
    }

    [SimpleColumn(Column = "c_bustype")]
    [Alias("业务类别")]
    public String BusType;

    public String 业务类别
    {
        get { return BusType; }
        set { BusType = value; }
    }

    [SimpleColumn(Column = "regdate",AllowInsert=false,AllowUpdate=false)]
    [Alias("操作时间")]
    public String RegDate;

    public String 操作时间
    {
        get { return RegDate; }
        set { 操作时间 = value; }
    }

    [SimpleColumn(Column = "c_content")]
    [Alias("具体内容")]
    public String Content;

    public String 具体内容
    {
        get { return Content; }
        set { Content = value; }
    }


    [SimpleColumn(Column = "c_des1")]
    [Alias("预留字段1")]
    public String Des1;

    public String 预留字段1
    {
        get { return Des1; }
        set { Des1 = value; }
    }

    [SimpleColumn(Column = "c_des2")]
    [Alias("预留字段2")]
    public String Des2;

    public String 预留字段2
    {
        get { return Des2; }
        set { Des2 = value; }
    }

    [SimpleColumn(Column = "c_des3")]
    [Alias("预留字段3")]
    public String Des3;

    public String 预留字段3
    {
        get { return Des3; }
        set { Des3 = value; }
    }

    [SimpleColumn(Column = "i_depid")]
    [Alias("部门ID")]
    public String DepId;

    public String 部门ID
    {
        get { return DepId; }
        set { DepId = value; }
    }
}
