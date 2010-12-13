using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.Commons.Security;
using FT.DAL;
using FT.DAL.Orm;
using System.Collections;
using FT.Web.Tools;
using FT.Web;

/// <summary>
///UserOperator 的摘要说明
/// </summary>
public class UserOperator
{
    public UserOperator()
    {
        
    }

    public static string Login(string name, string pwd)
    {
        string sql = "select * from table_users where c_login_name='" + DALSecurityTool.TransferInsertField(name) + "' and c_pwd='"+
            DALSecurityTool.TransferInsertField(SecurityFactory.GetSecurity().Encrypt(pwd))+"'";
        ArrayList lists=FT.DAL.Orm.SimpleOrmOperator.QueryList(typeof(UserObject),sql);
        if (lists.Count == 0)
        {
            return "2";
        }
        else
        {
            UserObject user=lists[0] as UserObject;
            RoleObject role = FT.DAL.Orm.SimpleOrmOperator.Query<RoleObject>(user.RoleId);
            DepartMent dept = FT.DAL.Orm.SimpleOrmOperator.Query<DepartMent>(user.DepId);
            OperatorTick ot = new OperatorTick(user.Id, user.FullName, user.DepId,role.RoleString, pwd);
            ot.Desp1 = user.WorkId;
            ot.Desp2 = dept.ParentCode;
            ot.Desp3 = dept.DepCode;
            ot.Desp4 = dept.DepFullName;
            ot.Desp5 = user.FullName;
            ot.Desp6 = role.RoleName;

            return FT.Web.OperatorTick.GenerateOpTicket(ot);
        }
        //return "1";


        
    }

    public static string ChangePwd(int uid, string oldpwd, string newpwd)
    {
        return ChangePwd(Get(uid), oldpwd, newpwd);
    }

    public static string ChangePwd(UserObject user,string oldpwd, string newpwd)
    {
        if(user.Password!=SecurityFactory.GetSecurity().Encrypt(oldpwd))
        {
            return "旧密码输入错误！";
        }
        bool result=DataAccessFactory.GetDataAccess().ExecuteSql("update table_users set c_pwd='"+SecurityFactory.GetSecurity().Encrypt(newpwd)+"' where id="+user.Id);
        if (result)
        {
            BusLog log = new BusLog();
            log.BusType = "修改密码";
            log.Content = user.FullName+"修改自己的密码";
            BusLogOperator.InitByLoginUser(log);
            //log.Operator=
            return string.Empty;

        }
        else
            return "修改密码失败！";
    }

    public static bool ResetPwd(int id,string newpwd)
    {
        
        bool result = DataAccessFactory.GetDataAccess().ExecuteSql("update table_users set c_pwd='" + SecurityFactory.GetSecurity().Encrypt(newpwd) + "' where id=" + id);
        if (result)
        {
            BusLog log = new BusLog();
            log.BusType = "重设密码";
            log.Content ="admin修改ID为"+id+"的密码";
            BusLogOperator.InitByLoginUser(log);
            SimpleOrmOperator.Create(log);
            //log.Operator=
            

        }
        return result;
    }

    public static void Delete(int id)
    {
        SimpleOrmOperator.Delete<UserObject>(id);
    }

    public static UserObject Get(int id)
    {
        return SimpleOrmOperator.Query<UserObject>(id);
    }

    public static DataTable Search(string username)
    {
        return DataAccessFactory.GetDataAccess().SelectDataTable("select * from table_users where c_full_name like '%" + username + "%'", "tempdb");
    }
}
