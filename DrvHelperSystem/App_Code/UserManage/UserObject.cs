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
///UserObject 的摘要说明
/// </summary>
[SimpleTable("table_users")]
[Alias("用户表")]
public class UserObject
{
    public UserObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    [SimplePK]
    [OracleSeqAttribute(SeqName = "seq_user")]
    public int Id;

    public int 编号
    {
        get { return Id; }
        set { Id = value; }
    }


    [SimpleColumn(Column = "c_login_name")]
    [Alias("登陆名")]
    public String UserLoginName;

    public String 登陆名
    {
        get { return UserLoginName; }
        set { UserLoginName = value; }
    }

    [SimpleColumn(Column = "c_full_name")]
    [Alias("用户全名")]
    public String FullName;

    public String 用户全名
    {
        get { return FullName; }
        set { FullName = value; }
    }


    [SimpleColumn(Column = "c_pwd",AllowUpdate=false)]
    [Alias("密码")]
    public String Password;

    public String 密码
    {
        get { return Password; }
        set { Password = value; }
    }

    [SimpleColumn(Column = "i_roleid")]
    [Alias("角色ID")]
    public int RoleId;

    public int 角色ID
    {
        get { return RoleId; }
        set { RoleId = value; }
    }

    [SimpleColumn(Column = "i_depid")]
    [Alias("部门ID")]
    public int DepId;

    public int 部门ID
    {
        get { return DepId; }
        set { DepId = value; }
    }

    [SimpleColumn(Column = "c_idcard")]
    [Alias("身份证明号码")]
    public String IdCard;

    public String 身份证明号码
    {
        get { return IdCard; }
        set { IdCard = value; }
    }

    [SimpleColumn(Column = "c_workid")]
    [Alias("工号")]
    public String WorkId;

    public String 工号
    {
        get { return WorkId; }
        set { WorkId = value; }
    }

    [SimpleColumn(Column = "c_beginip")]
    [Alias("IP起始地址")]
    public String BeginIp;

    public String IP起始地址
    {
        get { return BeginIp; }
        set { BeginIp = value; }
    }

    [SimpleColumn(Column = "c_endip")]
    [Alias("IP结束地址")]
    public String EndIp;

    public String IP结束地址
    {
        get { return EndIp; }
        set { EndIp = value; }
    }

    [SimpleColumn(Column = "c_state")]
    [Alias("状态")]
    public String State;

    public String 状态
    {
        get { return State; }
        set { State = value; }
    }
}
