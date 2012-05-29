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

public partial class Reg_Finger : System.Web.UI.Page
{
    public string AGENT_INFO;
    public string USER_ID;
    public string ENROLLEDFINGERS;
    private wsFinger.wsFingerImplService wsFingerM = new wsFinger.wsFingerImplService();

    private wsUser.wsUserImplService wsUserM = new wsUser.wsUserImplService();
      

    protected void Page_Load(object sender, EventArgs e)
    {
        USER_ID = Request.QueryString["strreg"];
        AGENT_INFO = wsFingerM.wsGetAgentInfo();//获取系统信息
        this.username.Value = USER_ID;
        int wsIsUserExisted_re = wsUserM.wsIsUserExisted(USER_ID);
        if (wsIsUserExisted_re == 1)
        {
            int wsAddUserByPwd_re = wsUserM.wsAddUserByPwd(USER_ID, "sa", "sa");
            ENROLLEDFINGERS = "";
            if (wsAddUserByPwd_re != 0)
            {
                Response.Write("添加失败！</br>");
            }
        }
        else
        {
            ENROLLEDFINGERS = wsFingerM.wsGetEnrolledFingersInResult(USER_ID, "31");//获取该用户注册的指头 设备类型31
        }
    }

}
