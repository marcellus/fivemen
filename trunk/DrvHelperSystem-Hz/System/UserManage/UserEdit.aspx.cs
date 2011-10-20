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
using FT.Commons.Tools;
using DrvHelperSystemBLL.System.Rbac.BLL;
using DrvHelperSystemBLL.System.Rbac.Model;
using FT.Commons.Security;
using DrvHelperSystemBLL.System;

public partial class System_UserManage_UserEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Constants.BindDepType(this.cbDepTypeValue);
            RoleInfoOperator.Bind(this.cbRoleIdValue);
            DepartmentInfoOperator.BindDept(this.cbDepIdValue);
            if (Request.Params["id"] != null)
            {
                UserInfo model = UserInfoOperator.Get(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, model);
                string[] ips = model.BeginIp.Split('.');
                this.txtBeginIp1.Text = ips[0].ToString();
                this.txtBeginIp2.Text = ips[1].ToString();
                this.txtBeginIp3.Text = ips[2].ToString();
                this.txtBeginIp4.Text = ips[3].ToString();
                ips = model.EndIp.Split('.');
                this.txtEndIp1.Text = ips[0].ToString();
                this.txtEndIp2.Text = ips[1].ToString();
                this.txtEndIp3.Text = ips[2].ToString();
                this.txtEndIp4.Text = ips[3].ToString();
            }

        }

    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        UserInfo model = new UserInfo();
        WebFormHelper.GetDataFromForm(this, model);
        model.BeginIp = this.txtBeginIp1.Text.Trim() + "." + this.txtBeginIp2.Text.Trim() + "." + this.txtBeginIp3.Text.Trim() + "." + this.txtBeginIp4.Text.Trim();
        model.EndIp = this.txtEndIp1.Text.Trim() + "." + this.txtEndIp2.Text.Trim() + "." + this.txtEndIp3.Text.Trim() + "." + this.txtEndIp4.Text.Trim();
        UserInfoOperator.CreateOrUpdate(model);
        
    }
}
