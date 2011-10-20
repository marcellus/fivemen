using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using FT.DAL;
using FT.DAL.Orm;
using FT.Commons.Security;
using System.Collections;
using DrvHelperSystemBLL.System.Rbac.Model;
using FT.Web;
using DrvHelperSystemBLL.System.Commons.BLL;
using FT.Web.Tools;
using System.Configuration;

namespace DrvHelperSystemBLL.System.Rbac.BLL
{
    public class UserInfoOperator
    {
        public static string Login(string name, string pwd)
        {
            string sql = "select * from table_user_info where c_login_name='" + DALSecurityTool.TransferInsertField(name) + "' and c_pwd='" +
                DALSecurityTool.TransferInsertField(SecurityFactory.GetSecurity().Encrypt(pwd)) + "'";
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryList(typeof(UserInfo), sql);
            if (lists.Count == 0)
            {
                return "2";
            }
            else
            {
                
                UserInfo user = lists[0] as UserInfo;
                RoleInfo role = FT.DAL.Orm.SimpleOrmOperator.Query<RoleInfo>(user.RoleId);
                DepartmentInfo dept = FT.DAL.Orm.SimpleOrmOperator.Query<DepartmentInfo>(user.DepId);
                OperatorTick ot = new OperatorTick(user.Id, user.FullName, user.DepId, role.MenuStr, pwd);
                ot.Desp1 = user.WorkId;
                ot.Desp2 = dept.GlbmCode;
                ot.Desp3 = dept.DepCode;
                ot.Desp4 = dept.DepFullName;
                ot.Desp5 = user.FullName;
                ot.Desp6 = role.MenuStr;
                ot.Desp7 = role.RightStr;
                ot.Desp8 = user.Km.ToString();
                

                return FT.Web.OperatorTick.GenerateOpTicket(ot);
            }
            //return "1";



        }

        public static string ChangePwd(int uid, string oldpwd, string newpwd)
        {
            return ChangePwd(Get(uid), oldpwd, newpwd);
        }

        public static string ChangePwd(UserInfo user, string oldpwd, string newpwd)
        {
            if (user.Password != SecurityFactory.GetSecurity().Encrypt(oldpwd))
            {
                return "旧密码输入错误！";
            }
            bool result = DataAccessFactory.GetDataAccess().ExecuteSql("update table_user_info set c_pwd='" + SecurityFactory.GetSecurity().Encrypt(newpwd) + "' where id=" + user.Id);
            if (result)
            {
                LogInfoOperator.LogSystem("修改密码", user.FullName + "修改自己的密码");
                return string.Empty;

            }
            else
                return "修改密码失败！";
        }

        public static bool ResetPwd(int id, string newpwd)
        {

            bool result = DataAccessFactory.GetDataAccess().ExecuteSql("update table_user_info set c_pwd='" + SecurityFactory.GetSecurity().Encrypt(newpwd) + "' where id=" + id);
            if (result)
            {
                LogInfoOperator.LogSystem("密码复位", "复位ID为" + id + "的密码");
                
                //log.Operator=


            }
            return result;
        }

        public static void Delete(int id)
        {
            LogInfoOperator.LogSystem("删除用户", "删除用户ID为" + id + "的密码");
            SimpleOrmOperator.Delete<UserInfo>(id);
        }

        public static UserInfo Get(int id)
        {
            return SimpleOrmOperator.Query<UserInfo>(id);
        }

        public static void CreateOrUpdate(UserInfo model)
        {
            if (model.Id < 0)
            {
                model.Password = SecurityFactory.GetSecurity().Encrypt(ConfigurationManager.AppSettings["DefaultPassword"].ToString());

                if (SimpleOrmOperator.Create(model))
                {
                    WebTools.Alert("添加成功！");
                }
                else
                {
                    WebTools.Alert("添加失败！");

                }
            }
            else
            {
                if (SimpleOrmOperator.Update(model))
                {
                    WebTools.Alert("修改成功！");
                }
                else
                {
                    WebTools.Alert("修改失败！");

                }
            }
        }

        public static DataTable Search(string username)
        {
            return DataAccessFactory.GetDataAccess().SelectDataTable("select t.*,decode(t.i_state,0,'无效',1,'有效') c_state from table_user_info t where c_full_name like '%" + username + "%'", "tempdb");
        }
    }
}
