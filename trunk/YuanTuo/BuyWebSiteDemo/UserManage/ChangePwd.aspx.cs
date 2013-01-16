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
using FT.Web;
using FT.Web.Tools;

public partial class UserManage_ChangePwd : AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        string result = UserOperator.ChangePwd(this.Operator.OperatorID, this.txtOldPwd.Text.Trim(), this.txtNewPwd.Text.Trim());
        if (result.Length > 0)
        {
            WebTools.Alert(this, result);
            return;
        }
        else
        {
            WebTools.Alert(this, "修改成功，请重新登录！");
            return;
        }
    }
}
