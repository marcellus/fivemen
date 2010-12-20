using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Globalization;

/// <summary>
///FpBase 的摘要说明
/// </summary>
public class FpBase
{

    public static int SUCCESSED = 0;
    private const string TRUSTLINK_INI_FILENAME = "TrustLink.ini";
    private const string TRUSTLINK_INI_PARAMETERS = "Parameters";
    private const string TRUSTLINK_INI_XSDEV_HANDLE = "XSDevHandle";
    private const string TRUSTLINK_INI_HOSTNAME = "HostName";
    private const string TRUSTLINK_INI_PRODUCT_ID = "ProductID";
    private const string TRUSTLINK_INI_PORT = "Port";
    private const string TRUSTLINK_INI_AUTHEN_ID = "AuthenID";
    private const string TRUSTLINK_INI_AUTHEN_PWD = "AuthenPwd";

    private const string TRUSTLINK_INI_DEVICE_TYPE = "Device Type";
    private const string TRUSTLINK_INI_DEVICE_NO = "No";
    private const string TRUSTLINK_INI_DEVICE_INDEX = "DEV";
    private const string TRUSTLINK_INI_SET_DEVICE_TYPE = "SetDeiveType";
    private const string TRUSTLINK_INI_ENROLL = "Enroll";
    private const string TRUSTLINK_INI_VERIFY = "Verify";
    private const string TRUSTLINK_INI_OCXNAME = "OcxName";

    private const string ENROLL_CLSID = "540BE1A4-553C-4676-9932-85F61D4034E0";
    private const string VERIFY_CLSID = "F4C54CF0-BBDD-40B4-98BC-96AC9DB8F091";
    //declare form public variable 
    private Boolean blDefaultAlert;     //是否使用内部错误提示
    private TrustLinkGeneralController _TG;
    private CultureInfo AP_culture = CultureInfo.CurrentCulture;


    public FpBase(Page cs,EventHandler eh)
    {
        _TG = new TrustLinkGeneralController();
        this.GetXParam();
        
       cs.Controls.Add(_TG);
       _TG.OnOperDlgPostEvent += eh;
        blDefaultAlert = true;
    }

    public FpBase(Page cs,EventHandler eh, Boolean blDefalutAlert)
    {
        _TG = new TrustLinkGeneralController();
        this.GetXParam();
        cs.Controls.Add(_TG);
        _TG.OnOperDlgPostEvent += eh;
        blDefaultAlert = blDefalutAlert;
    }



    public CultureInfo getAP_culture()
    {
        return this.AP_culture;
    }

    private void GetXParam()
    {
        _TG.HostName = "127.0.0.1";
        _TG.ProductID = "DEMO";
        _TG.Port = 26057;
        _TG.AuthenID = "sa";
        _TG.AuthenPwd = "sa";
        _TG.DeviceType = "31";
        _TG.OcxClassID = VERIFY_CLSID;
        _TG.OcxName = "XECtrl103.ocx";
    }



    private void ErrMsgDlg()
    {
        ShowMyMessage(Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDS_RESULT_CODE", AP_culture)
            + _TG.LastErrCode.ToString()
            + "\\n" + _TG.LastErrMsg
            + "\\n" + _TG.LastErrReason);
    }

    private void ShowMyMessage(string strMessage)
    {

        ClientScriptManager newCSM = _TG.Page.ClientScript;
        string SCP_SCRIPT_START = "<script language=\"javascript\">\n";
        string SCP_ALERT = "    alert('" + strMessage + "'); \n";
        string SCP_SCRIPT_END = "</script>\n";
        newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(), SCP_SCRIPT_START + SCP_ALERT + SCP_SCRIPT_END);
    }

    public int FpNewUser(string aUserID)
    {
        _TG.OcxClassID = ENROLL_CLSID;
        int result=_TG.NewEnroll(aUserID);
        
        if (result != SUCCESSED && this.blDefaultAlert)
        {
            ErrMsgDlg();
        }
        return result;
    }

    public int FpUpdateUser(string aUserID)
    {
        _TG.OcxClassID = ENROLL_CLSID;
        int result = _TG.UpdateEnroll(aUserID);
       
        if (result != SUCCESSED && this.blDefaultAlert)
        {
            ErrMsgDlg();
        }
        return result;
    }

    public int FpVerifyUser(string aUserID)
    {
        _TG.OcxClassID = VERIFY_CLSID;
        int result = _TG.FPUserVerify(aUserID);

        if (result != SUCCESSED && this.blDefaultAlert)
        {
            ErrMsgDlg();
        }
        return result;
    }

    public int FpIdentityUser()
    {
        _TG.OcxClassID = VERIFY_CLSID;
        int result = _TG.FPUserIdentify();
        
        if (result != SUCCESSED && this.blDefaultAlert)
        {
            ErrMsgDlg();
        }
        return result;
    }

    
}
