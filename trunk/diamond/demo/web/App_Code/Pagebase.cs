using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Globalization;
using System.Threading;
using ACE.Common.Util;
using ACE.Common;

/// <summary>
/// Summary description for Pagebase
/// </summary>
public class Pagebase:ACE.Common.Web.NoramlPageBase
{

    #region 成员变量
    /// <summary>
    /// 选择的语言文化
    /// </summary>
    private const string Session_Selected_Culture = "SelectedCulture";

    /// <summary>
    /// 判断Session中是否保存有Culture信息
    /// </summary>
    public  bool SelectedCultureIsNull
    {
        get
        {
            return HttpContext.Current.Session[Session_Selected_Culture] == null;
        }
    }

    /// <summary>
    /// 待实现，目前预留。
    /// </summary>
    public GUIDEx CurrentOfficeID
    {
        get
        {
            return new GUIDEx("CurrentOfficeID01");
        }
    }
    /// <summary>
    /// 获取或设置Culture信息
    /// </summary>
    public  string SelectedCulture
    {
        get
        {
            if (SelectedCultureIsNull)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session[Session_Selected_Culture].ToString();
            }
        }
        set
        {
            if (value == "en")
            {
                value = "";
            }
            switch (value)
            {
                case "zh-cn":
                    HttpContext.Current.Session[Session_Selected_Culture] = "zh-cn";
                    break;
               
                case "zh-mo":
                    HttpContext.Current.Session[Session_Selected_Culture] = "zh-tw";
                    break;
                default:
                    HttpContext.Current.Session[Session_Selected_Culture] = "en-us";
                    break;
            }
        }
    }
    #endregion

    #region 构造函数
    public Pagebase()
    {
        //
        // TODO: Add constructor logic here
        //
        this.Theme = "Default";
    }
    #endregion


    #region 登陆跳转控制
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        //如果未登陆，则跳转至登陆页面.
        //if (!IsLogin())
        //{
        //    Response.Redirect(ModuleConfiguration.ModuleConfig.LoginUrl);
        //}
    }
    #endregion

    #region 重载基类初始化区域事件
    protected override void InitializeCulture()
    {
        if (!SelectedCultureIsNull && SelectedCulture != Thread.CurrentThread.CurrentCulture.Name)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(SelectedCulture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(SelectedCulture);
        }
    }
    #endregion

    #region 提供给子类的方法
    /// <summary>
    /// 关闭本页面.
    /// </summary>
    public void Close()
    {
        Response.Write("<script>window.opener=null;window.close();</script>");
    }
    public string SystemErrorMessage
    {
        get
        {
            return ACECulture.GetGlobeConstResource("exceptionMsg");
        }
    }
    public void WriteErrorMsg(string msg)
    {
        Response.Write(string.Format("<table border=1 style=\"border-color:red\"><tr><td align=\"left\"><b><font color='red'>Error:{0}</font></b></td></tr></table>", msg));
    }

    public string calJsName
    {
        get
        {
            string jsName = string.Empty;
            switch (ACECulture.CurrentCulture)
            {
                case enumCulture.English:
                    jsName = "../Controls/cal/popcalendar_en.js";
                    break;
                case enumCulture.S_Chinese:
                    jsName = "../Controls/cal/popcalendar.js";
                    break;
                case enumCulture.U_Chinese:
                    jsName = "../Controls/cal/popcalendar.js";
                    break;
                default:
                    jsName = "../Controls/cal/popcalendar_en.js";
                    break;
            }
            return jsName;
        }
    }
    #endregion

}
