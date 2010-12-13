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
///DictType 的摘要说明
/// </summary>
[SimpleTable("table_dicttype")]
[Alias("字典类别表")]
public class DictType
{
    public DictType()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_dicttype")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "c_typename")]
    [Alias("类别名")]
    public String TypeName;

    public String 类别名
    {
        get { return TypeName; }
        set { TypeName = value; }
    }

    [SimpleColumn(Column = "c_description")]
    [Alias("类别描述")]
    public String Description;

    public String 类别描述
    {
        get { return Description; }
        set { Description = value; }
    }
}
