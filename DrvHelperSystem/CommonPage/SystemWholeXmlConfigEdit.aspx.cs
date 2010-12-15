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
using FT.Commons.Cache;
using FT.Commons.Tools;
using FT.Web.Tools;

public partial class CommonPage_SystemWholeXmlConfigEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Params["key"] != null && Request.Params["key"].Length>0)
            {
                SystemWholeXmlConfig entity=SystemWholeXmlConfigManager.Caches[Request.Params["key"]] as SystemWholeXmlConfig;
                if (entity != null)
                {
                    WebFormHelper.SetDataToForm(this, entity);
                    this.rblState.SelectedIndex = entity.Valid;
                }
            }

        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        SystemWholeXmlConfig entity = new SystemWholeXmlConfig();
        WebFormHelper.GetDataFromForm(this, entity);
        entity.Valid = this.rblState.SelectedIndex;
        SystemWholeXmlConfigManager.SaveConfig(entity);
        WebTools.Alert(this, "配置系统参数成功！");
    }
}
