using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FT.DAL.Orm;
using FT.DAL;
using FT.Web.Tools;
using FT.Commons.Tools;

public partial class Admin_ProductEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["id"] != null)
            {
                ProductObject entity = SimpleOrmOperator.Query<ProductObject>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
                this.txtContent.Text = System.Web.HttpContext.Current.Server.HtmlDecode(entity.Content);
            }
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        ProductObject dep = new ProductObject();
        WebFormHelper.GetDataFromForm(this, dep);
        if (dep.Id < 0)
        {
            dep.Content=System.Web.HttpContext.Current.Server.HtmlEncode(dep.Content);
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
