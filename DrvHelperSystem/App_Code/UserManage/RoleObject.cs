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
///Role 的摘要说明
/// </summary>
[SimpleTable("table_roles")]
[Alias("角色表")]
public class RoleObject
{
    public RoleObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_role")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }

    [SimpleColumn(Column = "c_name")]
    [Alias("角色名")]
    public String RoleName;

    public String 角色名
    {
        get { return RoleName; }
        set { RoleName = value; }
    }

    [SimpleColumn(Column = "c_description")]
    [Alias("角色描述")]
    public String RoleDescription;

    public String 角色描述
    {
        get { return RoleDescription; }
        set { RoleDescription = value; }
    }


    [SimpleColumn(Column = "c_rolestring")]
    [Alias("角色字符串")]
    public String RoleString;

    public String 角色字符串
    {
        get { return RoleString; }
        set { RoleString = value; }
    }
}
