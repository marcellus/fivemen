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

public partial class FpSystem_FpHelper_FpAttendTrain : System.Web.UI.Page
{
    private FpBase _FP;

    protected void Page_Load(object sender, EventArgs e)
    {
        _FP = new FpBase(this,new EventHandler(FpVerifyHandler));
    }

    private void FpVerifyHandler(object o, EventArgs e)
    {
        ResultCodeArgs re = (ResultCodeArgs)e;
        this.lbUserID.Text = re.ResultCode + ":" + re.ResultMessage;

    }



    protected void btnIdentity_Click(object sender, EventArgs e)
    {
        _FP.FpIdentityUser();
    }
}
