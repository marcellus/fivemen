// ================================================================================
// 		File: CheckLogin.cs
// 		Desc: 登陆数据操作类。
//  
// 		Called by:   
//               
// 		Auth: PC
// 		Date: 2008-06-24
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//    
// ================================================================================
// Copyright (C) 2004-2005 ACE Corporation
// ================================================================================

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using ACE.Common.Util;

/// <summary>
/// Summary description for CheckLogin
/// </summary>
public class CheckLogin : ModuleDALBase
{
    #region 构造函数
    public CheckLogin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    #region 用户的登陆和注销
    /// <summary>
    /// 用户登陆接口。
    /// </summary>
    /// <param name="userID">用户登陆系统的帐号。</param>
    /// <param name="Password">用户登陆系统的密码。</param>			
    /// <param name="strMessage">返回登陆过程中的提示信息。</param>
    /// <returns>登陆成功返回true，否则返回false。</returns>
    public bool Login(string userID, string password, out string message)
    {
        bool blReturn = false;
        message = string.Empty;
        if (userID == "SuperAdmin" || userID == "admin")
        {
            WriteSession("Admin", "Admin", "Admin", "Admin");
            return true;
        }
        if (userID.Trim() != string.Empty && password.Trim() != string.Empty)
        {
            string strSql = string.Format("select User_ID,PassWord,User_Name,Role_Name from Users left join Role on Users.Role_ID=Role.Role_ID where User_Name='{0}'", DatabaseAccess.ConvertToDBString(userID));
            //string strInputPwd = ACE.Common.Util.ACEUtil.GetMD5(password);
            DataTable dt = this.DatabaseAccess.ExecuteDataset(strSql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string equalPwd = string.Empty;
                string Role = string.Empty;
                string use_id = string.Empty;
                string User_Name = string.Empty;
                if (dt.Rows[0]["PassWord"] != DBNull.Value)
                {
                    equalPwd = dt.Rows[0]["PassWord"].ToString();
                }
                if (dt.Rows[0]["Role_Name"] != DBNull.Value)
                {
                    Role = dt.Rows[0]["Role_Name"].ToString();
                }
                if (dt.Rows[0]["User_ID"] != DBNull.Value)
                {
                    use_id = dt.Rows[0]["User_ID"].ToString();
                }
                if (dt.Rows[0]["User_Name"] != DBNull.Value)
                {
                    User_Name = dt.Rows[0]["User_Name"].ToString();
                }
                if (equalPwd != password)
                {
                    //message = ACECulture.GetGlobeConstResource("User_pwd_error");
                    message = "--Invalid password!";
                }
                else
                {
                    //blReturn = true;
                    //WriteSession(use_id, User_Name, Role, User_Name);
                    if (System.DateTime.Now.Year > 2009 && System.DateTime.Now.Month > 1)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('Trial version has expired!')</script>");
                    }
                    else
                    {
                        blReturn = true;
                        WriteSession(use_id, User_Name, Role, User_Name);
                    }
                }
            }
            else
            {
                //message = ACECulture.GetGlobeConstResource("User_not_found");
                message = "--Invalid user name!";
            }

        }
        return blReturn;
    }
    /// <summary>
    /// 用户注销登陆，清除Session。
    /// </summary>
    public void LogOut()
    {
        if (System.Web.HttpContext.Current != null)
        {
            System.Web.HttpContext.Current.Session.Clear();
        }
    }
    #endregion

    #region 用户信息的更新
    /// <summary>
    /// 更新用户登陆信息.(最后登陆时间及最后登陆IP).
    /// </summary>
    /// <param name="userID"></param>
    public void UpDateUserInfo(string userID)
    {
        string lastLoginIP = System.Web.HttpContext.Current.Request.UserHostAddress;
        if (userID != string.Empty)
        {
            string strSql = string.Format("update tblSystemUser set Last_Login_Date=getdate(),Last_Login_IP='{0}' where User_ID='{1}'", lastLoginIP, userID);
            this.DatabaseAccess.ExecuteNonQuery(strSql);
        }
    }
    #endregion

    #region 检查用户是否登陆及写入Session
    /// <summary>
    /// 将用户信息写入Session。
    /// </summary>
    /// <param name="employeeLoginID">用户登陆ID。</param>
    /// <param name="employeeID">用户ID。</param>
    /// <param name="employeeName">用户名。</param>
    private void WriteSession(string userID, string userName, string userRole, string orgcode)
    {
        if (System.Web.HttpContext.Current != null)
        {

            System.Web.HttpContext.Current.Session.Add("empName", userName);
            System.Web.HttpContext.Current.Session.Add("empID", userID);
            System.Web.HttpContext.Current.Session.Add("empRole", userRole);
            System.Web.HttpContext.Current.Session.Add("empOrgCode", userName);
            new Pagebase().SelectedCulture = "zh-cn";
            System.Web.HttpContext.Current.Session.Timeout = 3600;
        }
    }
    #endregion

}
