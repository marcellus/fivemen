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
using FT.Web;
using FT.Web.Tools;

public partial class SystemAdmin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string userName = FT.DAL.DALSecurityTool.TransferInsertField(this.txtUserName.Text);
        string pwd = FT.DAL.DALSecurityTool.TransferInsertField(this.txtPassword.Text);
        pwd = DATA_CONVERT.CryptPasswd(pwd);
        DataTable dt=FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select a.*,b.rolestring from users a left join roletable b on a.userole=b.roleid where cusername='" + userName + "' and cpassword='" + pwd + "'","temptable");
        if(dt!=null&&dt.Rows.Count>0)
        {
            DataRow dr = dt.Rows[0];
            OperatorTick op = new OperatorTick(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), Convert.ToInt32(dr[10].ToString()), dr[13].ToString(), this.txtPassword.Text);
            Session["OperatorInfo"] = OperatorTick.GenerateOpTicket(op);
            Response.Redirect("../SystemAdmin/admin.htm");
         }
            else
            {
                FT.Web.Tools.WebTools.Alert(this.Page, "登陆失败，请检查用户名和密码！");
            }

    }
}
