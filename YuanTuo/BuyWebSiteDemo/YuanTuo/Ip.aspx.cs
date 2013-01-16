using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FT.Commons.Web.Tools;

public partial class YuanTuo_Ip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cityIp = WebToolsHelper.GetIp();
        this.Label1.Text = cityIp;

       // 客户端ip:
        string tmp = "客户端ip：" + Request.ServerVariables.Get("Remote_Addr").ToString();
//客户端主机名:
tmp += "客户端主机名：" + Request.ServerVariables.Get("Remote_Host").ToString();
//客户端浏览器IE：
tmp += "客户端浏览器IE：" + Request.Browser.Browser.ToString();
//客户端浏览器 版本号：
tmp += "客户端浏览器 版本号：" + Request.Browser.MajorVersion;
//客户端操作系统：
tmp += "客户端操作系统：" + Request.Browser.Platform;
//服务器ip:
tmp += "服务器ip：" + Request.ServerVariables.Get("Local_Addr").ToString();
//服务器名：
tmp += "服务器名："+Request.ServerVariables.Get("Server_Name").ToString();
this.Label1.Text = tmp;
    }
}
