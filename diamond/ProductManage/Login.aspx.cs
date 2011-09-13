using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login : Pagebase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["logout"] == "true")
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        CheckLogin checkLogin = new CheckLogin();
        string userID = this.txt_UserName.Text;
        string msg = string.Empty;

        if (checkLogin.Login(this.txt_UserName.Text, this.txt_Pwd.Text, out msg))
        {
            Response.Redirect("Product_List.aspx");
        }
        else
        {
            this.lbl_ErrorMessage.Text = msg;
            //WriteErrorMsg(msg);
        }

    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        this.lbl_ErrorMessage.Text = string.Empty;
        this.txt_Pwd.Text = string.Empty;
        this.txt_UserName.Text = string.Empty;
    }
}
