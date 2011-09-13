// ================================================================================
// 		File: ModuleConst.cs
// 		Desc: 常量类.
//  
// 		Called by:   
//               
// 		Author: Zine
// 		Date: 2007-8-09
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//    
// ================================================================================
// 
// ================================================================================
using System;
using System.Data;
using System.Configuration;
using ACE.Common.Util;
/// <summary>
/// Summary description for ModuleConst
/// </summary>
public class ModuleConst
{
    /// <summary>
    /// 标识为不可以用的常量.
    /// </summary>
    public static string DefaultUnusableValue = "ue72u83i2l19s83j2h38j1";


    private static string DateFormatEn1 = "yyyy/MM/dd ";
    private static string DateFormatCn1 = "yyyy-MM-dd";

    private static string DateFormatEn = "dd/MM/yyyy HH:mm:ss";
    private static string DateFormatCn = "yyyy-MM-dd HH:mm:ss";


    private static string DatePickStyleEn = "new WdatePicker(this,'%D/%M/%Y',true,'whyGreen')";
    private static string DatePickStyleCn = "new WdatePicker(this,'%Y-%M-%D',true,'whyGreen')";

    private static string DatePickStyleEn1 = "new WdatePicker(this,'%D/%M/%Y %h:%m:%s',true,'whyGreen')";
    private static string DatePickStyleCn1 = "new WdatePicker(this,'%Y-%M-%D'%h:%m:%s,true,'whyGreen')";

    #region 构造函数
    public ModuleConst()
    {
        //
        // TODO: Add constructor logic here
        //

    }
    #endregion


    #region 日期格式相关
    /// <summary>
    /// 根据当前区域获取文本框显示日期的格式(不带时间)
    /// </summary>
    public static string DateFormat
    {
        get
        {
            return ACECulture.CurrentCulture == enumCulture.English ? DateFormatEn1 : DateFormatCn1;
        }
    }
    /// <summary>
    /// 根据当前区域获取文本框显示日期的格式(带时间)
    /// </summary>
    public static string DateFormatWithTime
    {
        get
        {
            return ACECulture.CurrentCulture == enumCulture.English ? DateFormatEn : DateFormatCn;
        }
    }
    /// <summary>
    /// 日期选择框所显示的日期格式(不带时间)
    /// </summary>
    public static string DatePickStyle
    {
        get
        {
            return ACECulture.CurrentCulture == enumCulture.English ? DatePickStyleEn : DatePickStyleCn;
        }
    }
    /// <summary>
    /// 日期选择框所显示的日期格式(带时间)
    /// </summary>
    public static string DatePickStyleWithTime
    {
        get
        {
            return ACECulture.CurrentCulture == enumCulture.English ? DatePickStyleEn1 : DatePickStyleCn1;
        }
    }
    /// <summary>
    /// 按设置的日期格式把日期转为字符串
    /// </summary>
    /// <param name="dt">要转换的日期对象</param>
    /// <returns></returns>
    public static string DateToStr(DateTime dt)
    {
        return dt.ToString(ModuleConfiguration.ModuleConfig.GetConfigValue("DateStringFormat"), System.Globalization.DateTimeFormatInfo.InvariantInfo);
    }
    /// <summary>
    /// 按设置的日期格式把日期转为字符串
    /// </summary>
    /// <param name="dt">要转换的日期对象</param>
    /// <returns></returns>
    public static string DateTimeToStr(DateTime dt)
    {
        if (dt != System.DateTime.MinValue)
        {
            return dt.ToString(ModuleConfiguration.ModuleConfig.GetConfigValue("DateTimeStringFormat"), System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }
        else
        {
            return string.Empty;
        }
    }
    /// <summary>
    /// 按设置的日期格式把字符串转为日期对像,如果格式不对,返回当前日期
    /// </summary>
    /// <param name="dt">要转换的字符串</param>
    /// <returns></returns>
    public static DateTime StrToDate(string dt)
    {
        DateTime ret;
        if (DateTime.TryParseExact(dt, ModuleConfiguration.ModuleConfig.GetConfigValue("DateStringFormat"), System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AllowInnerWhite, out ret))
        {
            return ret;
        }
        else
        {
            return DateTime.Now;
        }
    }
    /// <summary>
    /// 按设置的日期格式把字符串转换为符合SQL的格式,如果格式不对,返回当前日期的字符串
    /// </summary>
    /// <param name="dt">要转换的字符串</param>
    /// <returns></returns>
    public static string StrToSqlStr(string dt)
    {
        DateTime temp;
        if (DateTime.TryParseExact(dt, ModuleConfiguration.ModuleConfig.GetConfigValue("DateStringFormat"), System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.AllowInnerWhite, out temp))
        {
            return temp.ToString("yyyy-MM-dd");
        }
        else
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
    /// <summary>
    /// 将日期对象转换为符合SQL的格式
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string DateToSqlStr(DateTime dt)
    {
        return dt.ToString("yyyy-MM-dd");
    }
    #endregion


}

/// <summary>
/// 查询条件符(like or '=').
/// </summary>
public enum enumITDGroup
{
    /// <summary>
    /// Building
    /// </summary>
    Building = 0x00,
    /// <summary>
    /// Site
    /// </summary>
    Site = 0x01
}
/// <summary>
/// Repeater中的命令类型
/// </summary>
public enum enumRepeaterCommandName
{
    /// <summary>
    /// 翻页
    /// </summary>
    PageTurn,
    /// <summary>
    /// 排序
    /// </summary>
    Sort,
    /// <summary>
    /// 修改
    /// </summary>
    Modify,
    /// <summary>
    /// 查看
    /// </summary>
    View,
    /// <summary>
    /// 复制
    /// </summary>
    Copy,
    /// <summary>
    /// 回复
    /// </summary>
    Reply,
    /// <summary>
    /// 转到报告
    /// </summary>
    Instruction,
    /// <summary>
    /// 转到口估记录
    /// </summary>
    Verbal
}
