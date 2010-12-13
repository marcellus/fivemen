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

public partial class UserManage_DepartmentEdit : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             if (Request.Params["id"] != null)
            {
                DepartMent dep=SimpleOrmOperator.Query<DepartMent>(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, dep);
            }
            
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        DepartMent dep=new DepartMent();
        WebFormHelper.GetDataFromForm(this, dep);
        if(dep.Id<0)
        {
            if (SimpleOrmOperator.Create(dep))
            {
                WebTools.Alert("添加成功！");
            }
            else
            {
                WebTools.Alert("添加失败！");

            }
        }
        else{
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
