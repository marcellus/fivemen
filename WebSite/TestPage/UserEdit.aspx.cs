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
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class TestPage_UserEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TestUser user=new TestUser();
        WebFormHelper.GetDataFromForm(this, user);
        FT.DAL.Orm.SimpleOrmOperator.Create(user);
        WebTools.Alert("添加成功！");
        WebTools.CloseSelf(this);
    }
}
