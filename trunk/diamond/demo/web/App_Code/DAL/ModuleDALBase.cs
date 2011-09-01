// ================================================================================
// 		File: ModuleDALBase.cs
// 		Desc: 数据操作层的基础类。
//  
// 		Called by:   
//               
// 		Auth: zine
// 		Date: 2007-4-13
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//    
// ================================================================================
// Copyright (C) 2004-2005 CAT  Corporation
// ================================================================================
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ACE.Common.DB;
using ACE.Common;

/// <summary>
/// Summary description for ModuleDALBase
/// </summary>
public class ModuleDALBase : ACE.Common.Web.ACEDALBase
{
    #region 成员变量和构造函数
    /// <summary>
    /// 创建 ModuleDALBase 的实例。
    /// </summary>
    public ModuleDALBase()
    {

    }
    #endregion

    #region 创建数据访问接口
    /// <summary>
    /// 创建数据访问接口。
    /// </summary>
    protected override void CreateDBAccess()
    {
        this.DatabaseAccess = ModuleConfiguration.ModuleConfig.DatabaseAccess;

        //this.DatabaseAccess = SessionManager.CurrentDBAccess;
    }
    #endregion



    #region 一些通用操作
    /// <summary>
    /// 获取表主键ID值.
    /// </summary>
    /// <param name="keyName">主键ID名称.</param>
    /// <returns></returns>
    public string GetTablePrimaryID(string keyName)
    {
        string strReturn = string.Empty;
        if (keyName != string.Empty)
        {
            string strSql = string.Format(" declare @id varchar(13) exec spGetTableID '{0}',@id out select @id", keyName);
            strReturn = Convert.ToString(DatabaseAccess.ExecuteScalar(strSql));
        }
        return strReturn;
    }
    /// <summary>
    /// 清理垃圾数据.
    /// </summary>
    /// <param name="uniqID">当前的UniqID即时间戳.</param>
    public void ClearData(string uniqID)
    {
        if (uniqID != string.Empty)
        {
            string strSql = "exec spClearGarbageData '" + uniqID + "',1";
            this.DatabaseAccess.ExecuteNonQuery(strSql);
        }
    }

    public DataSet GetDateSet(string sql)
    {
        return this.DatabaseAccess.ExecuteDataset(sql);
    }
    #endregion


}
