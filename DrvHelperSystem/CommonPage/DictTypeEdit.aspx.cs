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
using FT.DAL.Orm;
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class CommonPage_DictTypeEdit : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             if (Request.Params["id"] != null)
            {
                DictType entity = SimpleOrmOperator.Query<DictType>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, entity);
            }
            
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        DictType entity = new DictType();
        WebFormHelper.GetDataFromForm(this, entity);
        if (entity.Id < 0)
        {
            if (SimpleOrmOperator.Create(entity))
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
            if (SimpleOrmOperator.Update(entity))
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
