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
using FT.Commons.Web.Tools;
using FT.Web.Bll.Terminal;

public partial class YuanTuo_Index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (!IsPostBack)
       // {
       // Session.Clear();
            
          //  Session["Store"] = null;
       // }
    }

    public string VedioUrl
    {
        get
        {
            string cityIp = WebToolsHelper.GetIp();
            TerminalStatus terminal = TerminalOnlineMonitorThread.GetTerminal(cityIp);
            TerminalGroupEntity group=FT.DAL.Orm.SimpleOrmOperator.Query<TerminalGroupEntity>(terminal.MachineGroupId);
            return group.AdUrl;
        }
    }
}
