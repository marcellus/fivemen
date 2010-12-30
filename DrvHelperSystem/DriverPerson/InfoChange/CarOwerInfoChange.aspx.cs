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
using FT.DAL.Orm;

public partial class DriverPerson_PersonInfoChange_CarOwerInfoChange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CarOwnerInfoChange entity = new CarOwnerInfoChange();
        WebFormHelper.GetDataFromForm(this, entity);
        entity.Hmhp = this.txtHmhpPrefix.Text + this.txtHmhpEnd.Text.Trim();
        if (SimpleOrmOperator.Create(entity))
        {
            WebTools.Alert("提交车主联系方式变更备案成功！");
        }
        else
        {
            WebTools.Alert("提交车主联系方式变更备案失败！");

        }
    }
}
