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
using FT.Commons.Tools;
using FT.DAL.Orm;
using FT.Web.Tools;
using FT.Commons.Security;


public partial class UserManage_UserEdit : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RoleOperator.Bind(this.cbRoleIdValue);
            DepartMentOperator.Bind(this.cbDepIdValue);
            if (Request.Params["id"] != null)
            {
                UserObject dep = SimpleOrmOperator.Query<UserObject>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, dep);
                string[] ips = dep.BeginIp.Split('.');
                this.txtBeginIp1.Text = ips[0].ToString();
                this.txtBeginIp2.Text = ips[1].ToString();
                this.txtBeginIp3.Text = ips[2].ToString();
                this.txtBeginIp4.Text = ips[3].ToString();
                ips = dep.EndIp.Split('.');
                this.txtEndIp1.Text = ips[0].ToString();
                this.txtEndIp2.Text = ips[1].ToString();
                this.txtEndIp3.Text = ips[2].ToString();
                this.txtEndIp4.Text = ips[3].ToString();
            }

        }

    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        UserObject dep = new UserObject();
        WebFormHelper.GetDataFromForm(this, dep);
        dep.BeginIp = this.txtBeginIp1.Text.Trim() + "." + this.txtBeginIp2.Text.Trim() + "." + this.txtBeginIp3.Text.Trim() + "." + this.txtBeginIp4.Text.Trim();
        dep.EndIp = this.txtEndIp1.Text.Trim() + "." + this.txtEndIp2.Text.Trim() + "." + this.txtEndIp3.Text.Trim() + "." + this.txtEndIp4.Text.Trim();
        if (dep.Id < 0)
        {
            dep.Password = SecurityFactory.GetSecurity().Encrypt(ConfigurationManager.AppSettings["DefaultPassword"].ToString());
            
            if (SimpleOrmOperator.Create(dep))
            {
                WebTools.Alert("添加成功！");
            }
            else
            {
                WebTools.Alert("添加失败！");

            }
        }
        else
        {
            if (SimpleOrmOperator.Update(dep))
            {
                WebTools.Alert("修改成功！");
            }
            else
            {
                WebTools.Alert("修改失败！");

            }
        }
    }
}
