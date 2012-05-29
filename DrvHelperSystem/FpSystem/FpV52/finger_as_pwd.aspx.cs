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

public partial class Finger_As_PWD : System.Web.UI.Page
{

    public string AGENT_INFO;
    public string USER_ID;
    public string ENROLLEDFINGERS;

    private wsFinger.wsFingerImplService wsFingerM = new wsFinger.wsFingerImplService();

    protected void Page_Load(object sender, EventArgs e)
    {
        USER_ID = Request.QueryString["strfp"];
        AGENT_INFO = wsFingerM.wsGetAgentInfo();//��ȡϵͳ��Ϣ
        ENROLLEDFINGERS = wsFingerM.wsGetEnrolledFingersInResult(USER_ID, "31");//��ȡ���û�ע����ָ��ְλ��Ϣ,�豸����Ĭ����31
    }

}
