// ================================================================================
// 		File: ModuleConfiguration.cs
// 		Desc: 模块配置类ModuleConfiguration.
//			  ModuleConfiguration继承自ACEWebConfiguration（或AppConfiguration），
//			  用于读取在数据库中或Web.Config中配置的内容、数据库连接串等。
//			  按照“ACE.模块名.键名称”的格式定义各个键值。
//			  负责创建配置类的静态实例并负责缓存处理。
//  
// 		Called by:   Zine
//               
// 		Auth: 
// 		Date: 2007-4-13
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//    
// ================================================================================
//  Copyright (C) 2004-2005 ACE  Corporation
// ================================================================================
using System;
using ACE.Common;

/// <summary>
///模块配置类ModuleConfiguration和配置键值类ModuleConfigKeys。
///ModuleConfiguration继承自ACEWebConfiguration（或AppConfiguration），
///用于读取在数据库中或Web.Config中配置的内容、数据库连接串等。
///按照“ACE.模块名.键名称”的格式定义各个键值。
///负责创建配置类的静态实例并负责缓存处理。
/// </summary>	
public class ModuleConfiguration : ACE.Common.Web.ACEWebConfiguration
{
    #region 成员变量和构造函数
    /// <summary>
    /// 创建 ModuleConfiguration 的实例。
    /// </summary>
    public ModuleConfiguration()
        : base("HSBC")
    {
    }
    #endregion

    #region 获取ModuleConfiguration静态实例

    public static ModuleConfiguration m_config;
    /// <summary>
    /// 创建 ModuleConfiguration 的静态实例。
    /// </summary>
    static ModuleConfiguration()
    {
        m_config = new ModuleConfiguration();
    }

    /// <summary>
    /// 获取当前应用系统模块的静态配置信息。
    /// </summary>
    public new static ModuleConfiguration ModuleConfig
    {
        get
        {
            return m_config;
        }
    }
    #endregion

    #region 登陆页面地址
    /// <summary>
    /// 获取登陆页面地址.
    /// </summary>
    public string LoginUrl
    {
        get
        {
            return m_config.GetConfigValue("loginUrl");
        }
    }
    #endregion
    #region 文件存储路径
    /// <summary>
    /// 文件存信息主目录 最后不带"\"
    /// </summary>
    public string FileServerPath
    {
        get
        {
            return m_config.GetConfigValue("FileServerPath");
        }
    }
    /// <summary>
    /// DPX文件存放目录 最后不带"\"
    /// </summary>
    public string DPXFilePath
    {
        get
        {
            return String.Format(@"{0}\{1}", FileServerPath, m_config.GetConfigValue("DPX"));
        }
    }
    #endregion
    #region report processing jobs
    /// <summary>
    /// 获取登陆页面地址.
    /// </summary>
    public int ReportClassProcessingJobs
    {
        get
        {
            if (m_config.GetConfigValue("ReportClassProcessingJobs") != string.Empty)
            {
                return int.Parse(m_config.GetConfigValue("ReportClassProcessingJobs"));
            }
            else
            {
                return -1;
            }
        }
    }
    #endregion

    #region DBConnectionString
    public string BJ_DBConnectionString
    {
        get
        {
            return m_config.GetConfigValue("BJ_DBConnectionString");
        }
    }

    public string HK_DBConnectionString
    {
        get
        {
            return m_config.GetConfigValue("HK_DBConnectionString");
        }
    }

    public string KL_DBConnectionString
    {
        get
        {
            return m_config.GetConfigValue("KL_DBConnectionString");
        }
    } 
    #endregion
    #region 系统参数配置
    /// <summary>
    /// 查询数据时间长度(月)
    /// </summary>
    public int NoOfMonthFilter
    {
        get
        {
            int temp = 0;
            int.TryParse(m_config.GetConfigValue("no_of_month_filter"), out temp);
            return temp;
        }
    }
    /// <summary>
    /// 银行设置((总行)
    /// </summary>
    public string BankOrgID
    {
        get
        {
            return m_config.GetConfigValue("bank_org_id");
        }
    }
    /// <summary>
    /// 查询结果的最大记录数
    /// </summary>
    public int MaxRecordDisplay
    {
        get
        {
            int temp = 500;
            int.TryParse(m_config.GetConfigValue("max_record_display"), out temp);
            return temp;
        }
    }
    /// <summary>
    /// PDF报表存放文件夹
    /// </summary>
    public string PDFReportFolder
    {
        get
        {
            return m_config.GetConfigValue("PDFReportFolder");
        }
    }
    /// <summary>
    /// PDF报表路径
    /// </summary>
    public string PDFReportURL
    {
        get
        {
            return m_config.GetConfigValue("PDFReportURL");
        }
    }
    #endregion
}