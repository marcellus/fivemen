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

public partial class DriverPerson_PersonInfoChange_PersonInfoChange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DictOperator.BindDropDownList("身份证明名称", this.cbIdCardTypeValue);
            this.cbIdCardTypeValue.SelectedValue = "A";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PersonInfoChange entity = new PersonInfoChange();
        WebFormHelper.GetDataFromForm(this, entity);
         if (SimpleOrmOperator.Create(entity))
            {
                WebTools.Alert("提交驾驶人联系方式变更备案成功！");
            }
            else
            {
                WebTools.Alert("提交驾驶人联系方式变更备案失败！");

            }
       
    }
}
