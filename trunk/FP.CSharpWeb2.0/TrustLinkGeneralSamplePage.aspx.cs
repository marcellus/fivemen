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
using System.Globalization;
using System.Resources;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

public partial class TrustLinkGeneralSamplePage : System.Web.UI.Page
{
    private const int SUCCESSED = 0;
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

    //declare form public variable 
    private TrustLinkGeneralController _TG;
    private CultureInfo AP_culture = CultureInfo.CurrentCulture;
    private IniFile _IniFile;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitIniFile();
        _TG = new TrustLinkGeneralController();
        _TG.OnOperDlgPostEvent += new EventHandler(TrustLink_OperDlgPostEvent); //notice add the event
        foreach (Control c in this.Controls)
        {
            if (c is HtmlForm)
            {
                c.Controls.Add(_TG);
            }
        }

        if (!this.IsPostBack)
        {
            this.SetUIWording();
            this.LoadIniFile();
            SetDefaultParas();
        }
    }

    /// <summary>
    /// Process user action after operation fingerprint
    /// Notice: if don't process user operation fingerprint then use the TrustLinkGereralControler achieve the Result
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TrustLink_OperDlgPostEvent(object sender, EventArgs e) 
    {
        string SCP_SCRIPT_START = "\n<script language=\"javascript\">\n";
        string SCP_ALERT = "";
        string SCP_SCRIPT_END = "</script>\n";

        ResultCodeArgs re = (ResultCodeArgs)e;
        string strMessage = re.ResultMessage;
        if (re.ResultCode == SUCCESSED)
        {
            SCP_ALERT = "alert(\"" + Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDS_SUCCESS", AP_culture)
                + "\\n" + strMessage + "\");\n";
        }
        else
        {
            SCP_ALERT = "alert(\"" + Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDS_RESULT_CODE",AP_culture)
                        + re.ResultCode.ToString() + "\\n" + strMessage + "\");\n";
        }
        ClientScriptManager newCSM = Page.ClientScript;
        newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(), SCP_SCRIPT_START + SCP_ALERT + SCP_SCRIPT_END);
    }
    
    private void LoadIniFile()
    {
        //load ini file
        try
        {
            this.cboProductType.Items.Clear();
            int iDeviceType = Convert.ToInt32(_IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_DEVICE_NO));
            for (int i = 1; i <= iDeviceType; i++)
            {
                this.cboProductType.Items.Add(_IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_DEVICE_INDEX + i.ToString()));
            }
            this.cboProductType.Text = _IniFile.IniReadValue(TRUSTLINK_INI_PARAMETERS, TRUSTLINK_INI_XSDEV_HANDLE);
        }
        catch
        {
        }
    }

    ////////////////////////////////////////////////////////////////////////////////
    //Description:
    //  Get error result code, error message, and error reason.
    //  three kinds of language.Such as English, Simplified Chinese, and Traditional
    //  Chinese.
    ////////////////////////////////////////////////////////////////////////////////
    private void ErrMsgDlg(TrustLinkGeneralController aTG)
    {
        ShowMyMessage(Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDS_RESULT_CODE", AP_culture) 
            + aTG.LastErrCode.ToString()
            + "\\n" + aTG.LastErrMsg
            + "\\n" + aTG.LastErrReason);
    }

    private void ShowMyMessage(string strMessage)
    {
        ClientScriptManager newCSM = Page.ClientScript;
        string SCP_SCRIPT_START = "<script language=\"javascript\">\n";
        string SCP_ALERT = "    alert('" + strMessage + "'); \n";
        string SCP_SCRIPT_END = "</script>\n";
        newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(), SCP_SCRIPT_START + SCP_ALERT + SCP_SCRIPT_END);
    }

    ////////////////////////////////////////////////////////////////////////////////
    //Description:
    //  Set UI wording according to different OS language. At present provides up to
    //  three kinds of language.Such as English, Simplified Chinese, and Traditional
    //  Chinese.
    ////////////////////////////////////////////////////////////////////////////////
    private void SetUIWording()
    {
        this.lblTitle.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_TITLE",AP_culture);
        this.btnSetDefaultParas.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_INI_FILE_TEXT",AP_culture);
        this.lblFingerprintType.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_FINGERPRINT_TYPE",AP_culture);
        this.grpSetParameters.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_SET_SYS_PARAS",AP_culture);
        this.lblHostName.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_HOST_NAME",AP_culture);
        this.lblProductID.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_PRODUCT_ID",AP_culture);
        this.lblPort.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_USE_PORT",AP_culture);
        this.lblAdminName.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_AUTHEN_USER_NAME",AP_culture);
        this.lblAdminPassword.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_AUTHEN_PASS",AP_culture);
        this.grpRegister.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_GRP_REGISTER",AP_culture);
        this.cbDisapproveUpdateFP.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_DISAP_UPDATE_FP",AP_culture);
        this.lblRegUser.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_LBL_REGUSER",AP_culture);
        this.btnNewEnroll.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_BTN_NEW_ENROLL",AP_culture);
        this.grpVerify.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_GRP_VERIFY",AP_culture);
        this.lblVerifyUser.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_LBL_VERIFY_USER",AP_culture);
        this.btnFPUserVerify.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_BTN_FPUSER_VERIFY",AP_culture);
        this.grpIdentify.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_GRP_IDENTIFY",AP_culture);
        this.btnFPUserIdentify.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_BTN_FPUSER_IDENTIFY",AP_culture);
        this.grpDelete.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_GRP_DELETE",AP_culture);
        this.lblDeleteUser.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_LBL_DELETE_USER",AP_culture);
        this.btnDeleteUser.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_BTN_DELETE_USER",AP_culture);
        this.btnExit.Text = Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDE_BTN_EXIT",AP_culture);
    }

    ////////////////////////////////////////////////////////////////////////////////
    //Description:
    //  Set system parameters.
    ////////////////////////////////////////////////////////////////////////////////
    private void GetXParam()
    {
        _TG.HostName = this.txtHostName.Text.Trim();
        _TG.ProductID = this.txtProductID.Text.Trim();
        _TG.Port = Convert.ToInt32(this.txtPort.Text.Trim());
        _TG.AuthenID = this.txtAuthenId.Text.Trim();
        _TG.AuthenPwd = this.txtAdminPassword.Text.Trim();
    }

    protected void btnNewEnroll_Click(object sender, EventArgs e)
    {
        int intResult = SUCCESSED;
        GetXParam();
        int intIndex = this.cboProductType.SelectedIndex + 1;
        string strDeviceType = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_SET_DEVICE_TYPE + intIndex.ToString());
        string strOcxClassID = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_ENROLL + intIndex.ToString());
        string strOcxName = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_OCXNAME + intIndex.ToString());
        _TG.DeviceType = strDeviceType;
        _TG.OcxClassID = strOcxClassID;
        _TG.OcxName = strOcxName;

        if (this.cbDisapproveUpdateFP.Checked)
        {
            intResult = _TG.NewEnroll(this.txtRegUser.Text.Trim());
        }
        else
        {
            intResult = _TG.UpdateEnroll(this.txtRegUser.Text.Trim());
        }

        if (intResult != SUCCESSED)
        {
            ErrMsgDlg(_TG);
        }
    }

    protected void btnSetDefaultParas_Click(object sender, EventArgs e)
    {
        this.SetDefaultParas();
    }

    private void InitIniFile()
    {
        if (_IniFile == null)
        {
            string strFileName = this.MapPath(TRUSTLINK_INI_FILENAME);
            _IniFile = new IniFile(strFileName);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////
    //Description:
    //  Load default system parameters from ini file.
    ////////////////////////////////////////////////////////////////////////////////
    private void SetDefaultParas()
    {
        try
        {
            this.txtHostName.Text = _IniFile.IniReadValue(TRUSTLINK_INI_PARAMETERS,TRUSTLINK_INI_HOSTNAME);
            this.txtProductID.Text = _IniFile.IniReadValue(TRUSTLINK_INI_PARAMETERS,TRUSTLINK_INI_PRODUCT_ID);
            this.txtPort.Text = _IniFile.IniReadValue(TRUSTLINK_INI_PARAMETERS,TRUSTLINK_INI_PORT);
            this.txtAuthenId.Text = _IniFile.IniReadValue(TRUSTLINK_INI_PARAMETERS,TRUSTLINK_INI_AUTHEN_ID);
            this.txtAdminPassword.Text = _IniFile.IniReadValue(TRUSTLINK_INI_PARAMETERS,TRUSTLINK_INI_AUTHEN_PWD);
        }
        catch (Exception ex)
        {
            ShowMyMessage(ex.Message);
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        ClientScriptManager newCSM = Page.ClientScript;
        string SCP_SCRIPT_START = "<script language=\"javascript\">\n";
        string SCP_CONTENT = "  window.opener = null; \n";
        SCP_CONTENT += "  window.close();";
        string SCP_SCRIPT_END = "</script>\n";
        newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(), SCP_SCRIPT_START + SCP_CONTENT + SCP_SCRIPT_END);
    }
    protected void btnDeleteUser_Click(object sender, EventArgs e)
    {
        GetXParam();
        int intIndex = this.cboProductType.SelectedIndex + 1;
        string strDeviceType = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_SET_DEVICE_TYPE + intIndex.ToString());
        _TG.DeviceType = strDeviceType;
        if (_TG.DeleteUser(this.txtDeleteUser.Text.Trim()) == SUCCESSED)
        {
            ShowMyMessage(Resources.TrustLinkGeneralSampleFormRes.ResourceManager.GetString("IDS_DELETE_SUCCESS", AP_culture));
        }
        else
        {
            ErrMsgDlg(_TG);
        }
    }
    protected void btnFPUserIdentify_Click(object sender, EventArgs e)
    {
        GetXParam();
        int intIndex = this.cboProductType.SelectedIndex + 1;
        string strDeviceType = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_SET_DEVICE_TYPE + intIndex.ToString());
        string strOcxClassID = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_VERIFY + intIndex.ToString());
        string strOcxName = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_OCXNAME + intIndex.ToString());
        _TG.DeviceType = strDeviceType;
        _TG.OcxClassID = strOcxClassID;
        _TG.OcxName = strOcxName;

        if (_TG.FPUserIdentify() != SUCCESSED)
        {
            ErrMsgDlg(_TG);
        }
 
    }



    protected void btnFPUserVerify_Click(object sender, EventArgs e)
    {
        GetXParam();
        int intIndex = this.cboProductType.SelectedIndex + 1;
        string strDeviceType = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_SET_DEVICE_TYPE + intIndex.ToString());
        string strOcxClassID = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_VERIFY + intIndex.ToString());
        string strOcxName = _IniFile.IniReadValue(TRUSTLINK_INI_DEVICE_TYPE, TRUSTLINK_INI_OCXNAME + intIndex.ToString());
        _TG.DeviceType = strDeviceType;
        _TG.OcxClassID = strOcxClassID;
        _TG.OcxName = strOcxName;

        if (_TG.FPUserVerify(this.txtVerifyUser.Text.Trim()) != SUCCESSED)
        {
            ErrMsgDlg(_TG);
        }
    }
}

#region IniFile class
public class IniFile
{
    //ini file name
    public string Path;

    //declare read and write ini file API 
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


    //structure function
    public IniFile(string inipath)
    {
        //
        // TODO: Add constructor logic here
        //
        Path = inipath;
    }

    //write ini file
    public void IniWriteValue(string Section, string Key, string Value)
    {
        WritePrivateProfileString(Section, Key, Value, this.Path);
    }

    //read INI file content
    public string IniReadValue(string Section, string Key)
    {
        StringBuilder temp = new StringBuilder(255);
        int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.Path);
        return temp.ToString();
    }
}
#endregion