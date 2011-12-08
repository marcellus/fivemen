using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.DAL;
using FT.DAL.Oracle;
using FT.Commons.Security;

/// <summary>
///WholeWebConfig 的摘要说明
/// </summary>
public class WholeWebConfig
{
    public WholeWebConfig()
    {
        
        //
        //TODO: 在此处添加构造函数逻辑
        //

       
        
    }
    /// <summary>
    /// 管理部门前缀
    /// </summary>
    public static string Glbm
    {
        get { return System.Configuration.ConfigurationManager.AppSettings["DrvHelperSystem_glbm"]; }

    }

    /// <summary>
    /// 发证机关前缀
    /// </summary>
    public static string Fzjg
    {
        get { return System.Configuration.ConfigurationManager.AppSettings["DrvHelperSystem_fzjg"]; }

    }
    /// <summary>
    /// 获取统一版数据库连接查询用户
    /// </summary>
    /// <returns></returns>
    public static IDataAccess GetDrvIDataAccess()
    {
        return new OracleDataHelper(System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"]);
    }

    public static IDataAccess GetDrvIDataAccessDecode() {
        string conn = System.Configuration.ConfigurationManager.AppSettings["DefaultConnString2"];
        conn = FT.Commons.Security.SecurityFactory.GetSecurity().Decrypt(conn);
        return new OracleDataHelper(conn);
    }
}
