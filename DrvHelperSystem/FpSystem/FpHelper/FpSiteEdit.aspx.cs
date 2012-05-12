using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FT.Commons.Tools;
using FT.DAL.Orm;
using FT.Web.Tools;

public partial class FpSystem_FpHelper_FpSiteEdit : FT.Web.AuthenticatedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = StringHelper.fnFormatNullOrBlankInt(Request.Params["id"], -1);
            FpSite site = SimpleOrmOperator.Query<FpSite>(id);
            if (site == null) { return; }
            this.lbId.Text = id.ToString();
            this.txtSiteName.Text = site.NAME;
            this.txtSiteLimit.Text = site.LIMIT == null ? "0" : site.LIMIT.ToString();
            this.dllBustype.SelectedValue = site.BUSTYPE;
            this.txtHost.Text = site.HOST;
        }
    }


    protected void btnCommit_Click(object sender, EventArgs e)
    {
        FpSite site = new FpSite();
        site.ID = StringHelper.fnFormatNullOrBlankInt(this.lbId.Text,-1);
        site.NAME = txtSiteName.Text;
        site.LIMIT = StringHelper.fnFormatNullOrBlankInt(txtSiteLimit.Text,0);
        site.BUSTYPE = this.dllBustype.SelectedValue;
        site.HOST = this.txtHost.Text;
        if (SimpleOrmOperator.Update(site)) {
            WebTools.Alert("修改成功！");
        }
        else if (SimpleOrmOperator.Create(site))
        {
            WebTools.Alert("添加成功！");
        }
        else {
            WebTools.Alert("保存失败！");
        }
        FPSystemBiz.DictFpSites.Clear();
    }
}
