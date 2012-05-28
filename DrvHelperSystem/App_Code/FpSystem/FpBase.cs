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
using FT.Commons.Cache;
using FT.Commons.Tools;
using System.Threading;

/// <summary>
///FpBase 的摘要说明
/// </summary>
public class FpBase
{
    private static DateTime lastIdentity = DateTime.Now;
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

    private string ENROLL_CLSID = "540BE1A4-553C-4676-9932-85F61D4034E0";
    private string VERIFY_CLSID = "F4C54CF0-BBDD-40B4-98BC-96AC9DB8F091";
    //declare form public variable 
    private Boolean blDefaultAlert;     //是否使用内部错误提示
    private TrustLinkGeneralController _TG;
    private CultureInfo AP_culture = CultureInfo.CurrentCulture;


    public static String getFingerCnName(String authen_info) {
        if(string.IsNullOrEmpty(authen_info)){
          return "参数不能为空";
        }
        string info="";
        if(authen_info.ToUpper().StartsWith("R")){
           info+="右手";
        }else if(authen_info.ToUpper().StartsWith("L")){
           info+="左手";
        }else{
           return "错误格式:"+authen_info;
        }
        int fingerNum=Convert.ToInt32(authen_info.Substring(1));
        switch(fingerNum){
            case 1:{info+="拇指";break;}
            case 2:{info+="食指";break;}
            case 3:{info+="中指";break;}
            case 4:{info+="无名指";break;}
            case 5:{info+="尾指";break;}
            default:{info+="未知手指代码:"+fingerNum;break;}
        }
        return info;
    }

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
        try
        {
            string host = "";
            if (HttpContext.Current.Session["host"] != null) {
                host = HttpContext.Current.Session["host"].ToString();

            }else{
                host= StringHelper.fnFormatNullOrBlankString(SystemWholeXmlConfigManager.GetConfig("FP_MIDDLEWARE_HOST"), "127.0.0.1");
        }
            _TG.HostName = HttpContext.Current.Request.Url.Host;
            VERIFY_CLSID = StringHelper.fnFormatNullOrBlankString(SystemWholeXmlConfigManager.GetConfig("FP_VERIFY_CLSID"), "F4C54CF0-BBDD-40B4-98BC-96AC9DB8F091");
            ENROLL_CLSID = StringHelper.fnFormatNullOrBlankString(SystemWholeXmlConfigManager.GetConfig("FP_ENROLL_CLSID"), "540BE1A4-553C-4676-9932-85F61D4034E0");
            _TG.ProductID = StringHelper.fnFormatNullOrBlankString(SystemWholeXmlConfigManager.GetConfig("FP_MIDDLEWARE_PRODRCTID"), "DEMO");
            _TG.Port = StringHelper.fnFormatNullOrBlankInt(SystemWholeXmlConfigManager.GetConfig("FP_MIDDLEWARE_PORT"), 26057);
            _TG.AuthenID = StringHelper.fnFormatNullOrBlankString(SystemWholeXmlConfigManager.GetConfig("FP_MIDDLEWARE_AUTHENID"), "sa");
            _TG.AuthenPwd = StringHelper.fnFormatNullOrBlankString(SystemWholeXmlConfigManager.GetConfig("FP_MIDDLEWARE_AUTHENPWD"), "sa");
            _TG.DeviceType = StringHelper.fnFormatNullOrBlankString(SystemWholeXmlConfigManager.GetConfig("PF_DEVICETYPE"), "31");
            _TG.OcxClassID = VERIFY_CLSID;
            _TG.OcxName = StringHelper.fnFormatNullOrBlankString(SystemWholeXmlConfigManager.GetConfig("FP_OCXNAME"), "XECtrl103.ocx");
        }
        catch (NullReferenceException nre)
        {
            _TG.HostName = "127.0.0.1";
            VERIFY_CLSID = "F4C54CF0-BBDD-40B4-98BC-96AC9DB8F091";
            ENROLL_CLSID = "540BE1A4-553C-4676-9932-85F61D4034E0";
            _TG.ProductID = "DEMO;";
            _TG.Port = 26057;
            _TG.AuthenID = "sa";
            _TG.AuthenPwd = "sa";
            _TG.DeviceType = "31";
            _TG.OcxClassID = VERIFY_CLSID;
            _TG.OcxName = "XECtrl103.ocx";
        }
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

    public int FpDeleteUser(string aUserID)
    {
        _TG.OcxClassID = ENROLL_CLSID;
        int result = _TG.DeleteUser(aUserID);
        if (result != SUCCESSED && this.blDefaultAlert)
        {
            ErrMsgDlg();
        }
        return result;
    }

    public int FpIdentityUser()
    {
        if (DateTime.Now.Subtract(lastIdentity).TotalMilliseconds < 200) {
            Thread.Sleep(200);
        }
        lastIdentity = DateTime.Now;
        _TG.OcxClassID = VERIFY_CLSID;
        int result = _TG.FPUserIdentify();
        //int retryTimes=0;
        //while (result != SUCCESSED && retryTimes++ < 5) {
        //    Thread.Sleep(500);
        //    result = _TG.FPUserIdentify();
        //}
        if (result != SUCCESSED &&this.blDefaultAlert)
        {
            ErrMsgDlg();
        }
        return result;
    }


    public static string[] getUserIds(ResultCodeArgs re)
    {
        string[] lArrUserIds = new string[] {};
        if (re.ResultCode != SUCCESSED||re.ResultMessage=="")
            return lArrUserIds;
        else
        {
            if (re.ResultMessage.Contains(";"))
            {
                lArrUserIds = re.ResultMessage.Split(';');
            }
            else
            {
                lArrUserIds = new string[] { ""};
                lArrUserIds[0]=re.ResultMessage;
            } 
            
            for (int i = 0; i < lArrUserIds.Length; i++)
            {
                string val = lArrUserIds[i].ToString();
                if (
                    val.EndsWith("_R1") || val.EndsWith("_R2") || val.EndsWith("_R3") || val.EndsWith("_R4") || val.EndsWith("_R5") ||
                    val.EndsWith("_L1") || val.EndsWith("_L2") || val.EndsWith("_L3") || val.EndsWith("_L4") || val.EndsWith("_L5")
                    )
                {
                    lArrUserIds[i] = val.Substring(0, val.LastIndexOf('_'));
                }
            }
        }
        return lArrUserIds;
    }
    
}
