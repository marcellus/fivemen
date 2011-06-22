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
using FT.Web.Tools;

public partial class UserManage_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
    {

        string result=UserOperator.Login(this.txtLoginName.Text.Trim(), this.txtPwd.Text.Trim());
        if (result =="2")
        {
            WebTools.Alert(this, "登陆失败，请检查用户名和密码");
        }
        else if (result =="1")
        {
            WebTools.Alert(this, "登陆失败,错误代码为1");
        }
        else
        {
            Session["OperatorInfo"] = result;
            Response.Redirect("~/index.aspx");
        }
        
    }
}
