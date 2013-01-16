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

    
}
