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
using System.Threading;

public partial class addfinger : System.Web.UI.Page
{
    private wsFinger.wsFingerImplService wsFingerM = new wsFinger.wsFingerImplService();
    private wsUser.wsUserImplService wsUserM = new wsUser.wsUserImplService();
    protected void Page_Load(object sender, EventArgs e)

    {
        string strTmp = Request.QueryString["strTmp"].ToString();
        int result = wsFingerM.wsFPEnroll(strTmp);
        if (result == 0)
        {
           lbResult.Text="指纹注册成功！";
            
        }
        else
        {
            lbResult.Text="指纹注册失败！错误代码为："+result;
        }
    }
}
