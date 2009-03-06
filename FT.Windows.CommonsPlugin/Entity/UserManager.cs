using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FT.Windows.CommonsPlugin.Entity
{
    public class UserManager
    {
        private static User loginUser = null;

        /// <summary>
        /// 获取登陆的用户
        /// </summary>
        /// <value>登陆的用户信息</value>
        public static User LoginUser
        {
            get { return UserManager.loginUser; }
        }

        public static bool HasLogin()
        {
            return loginUser != null;
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">未加密的密码</param>
        /// <returns>是否登陆成功,0 代表成功，1代表密码错误，2代表用户名不存在</returns>
        public static int Login(string name, string pwd)
        {

            ArrayList users = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList(typeof(User), " where c_name='"+name+"'");
            if(users.Count>0)
            {
                loginUser = users[0] as User;
                pwd = FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt(pwd);
                if (pwd == loginUser.Password)
                    return 0;
                else
                    return 1;
            }
            return 2;
        }
        /// <summary>
        /// 重设密码
        /// </summary>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public static bool ResetPwd(string newpwd)
        {
            string tmp = loginUser.Password;
            loginUser.Password = FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt(newpwd);
            bool result= FT.DAL.Orm.SimpleOrmOperator.Update(loginUser);
            if (result)
            {
               
            }
            else
            {
                loginUser.Password = tmp;
                
            }
            return result;
        }

    }
}
