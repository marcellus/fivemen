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
using DrvHelperSystemBLL.System.Rbac.Model;
using DrvHelperSystemBLL.System.Rbac.BLL;

public partial class System_DepartmentManage_DepartmentEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["id"] != null)
            {
                DepartmentInfo dep = DepartmentInfoOperator.Get(Convert.ToInt32(Request.Params["id"]));
                WebFormHelper.SetDataToForm(this, dep);
            }
        }
    }

   

    protected void btnSure_Click(object sender, EventArgs e)
    {
       // string tt = this.txtDepNickName.Text;
       // string tttt2 = this.txtDepFullName.Text.Trim();
        DepartmentInfo dep = new DepartmentInfo();
        WebFormHelper.GetDataFromForm(this, dep);
        DepartmentInfoOperator.CreateOrUpdate(dep);
    }
}
