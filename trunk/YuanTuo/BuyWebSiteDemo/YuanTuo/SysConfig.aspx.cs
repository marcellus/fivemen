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
using FT.Web.Bll.SystemConfig;

public partial class YuanTuo_SysConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
                SystemConfigEntity entity = SimpleOrmOperator.Query<SystemConfigEntity>(1);
                WebFormHelper.SetDataToForm(this, entity);
            

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SystemConfigEntity entity = new SystemConfigEntity();
        entity.Id = 1;
        WebFormHelper.GetDataFromForm(this, entity);
        if (entity.Id < 0)
        {
            if (SimpleOrmOperator.Create(entity))
            {
                this.lbMsg.Text = "(保存系统配置成功！)";
            }
            else
            {
                this.lbMsg.Text = "(保存系统配置失败！)";

            }
        }
        else
        {
            if (SimpleOrmOperator.Update(entity))
            {
                this.lbMsg.Text = "(保存系统配置成功！)";
            }
            else
            {
                this.lbMsg.Text = "(保存系统配置失败！)";

            }

        }
    }
}
