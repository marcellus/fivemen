using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Text;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;

public class TrustLinkGeneralException : Exception
{
}

/// <summary>
/// TrustLinkGeneralController Return content after user operation fingerprint action
/// </summary>
public class ResultCodeArgs : EventArgs 
{
    public int ResultCode;  
    public string ResultMessage; 
    
    public ResultCodeArgs(int aResultCode, string aResultMessage)
    {
        this.ResultCode = aResultCode; //receive TrustLinkGeneralController Return Resultcode after user operation fingerprint action
        this.ResultMessage = aResultMessage; //receive TrustLinkGeneralController Return ResultMessage after user operation fingerprint action
    }
}

/******************************************************************************
Object Name  = TrustLinkGeneralController
Copyright    = Shenzhen AraTek Co.,Ltd. All Rights reserved.
Developer    = Allen
Version      = [1.0.0.0]
Description  = 
  To create more convenient and reliable communication in Enterprise environment
, Shenzhen Aratek Biometrics Technology Co., Ltd. provide a TrustLink General
Function Component to make developer who develop with Microsoft Visual Web Developer 2005 Express Edition can be simple
also fast to control fingerprint application suite.

  Basically, The TrustLink General Function Component provides many kinds of
public functions for the developer easily to use. As a result of such
characteristic, The TrustLink General Function Component has the merit which
may simply use and uses again.

  TrustLink General Function Component public functions as below:
  function:
    NewEnroll     : Add the registration fingerprint user.
    UpdateEnroll  : Update the already fingerprint user registeration
    FPUserVerify  : Verify user with registrried fingerprints.
    FPUserIdentify: Identify user with registried fingerprints.
    DeleteUser    : Delete user account and registried fingerprint.
  destructor:
    Destroy       : Destroy TrustLink General Function Component after use.
  property:
    HostName      : Establishes TrustLink XServer name or IP position.
    ProductID     : XServer can inspect client product ID. XServer can only
                    provide the service if two product IDs are the same.
    Port          : Configure the connection port which TrustLink XServer used.
    AuthenID      : Administration user account.
    AuthenPwd     : Administrator's password.
    DeviceType    : Client use the DeviceType value
    OcxClassID    : Client use the Device OCX class id value
    OcxName       : Client use the Device OCX filename
    LastErrMsg    : Last produces error message.
    LastErrReason : Possible reason of last produces error.
    LastErrCode   : Return error code of last produces error.

Updaye Date = 2006/04/28
*******************************************************************************/
/******************************************************************************
Company Infomation:
  This copyright turns over to the Aratek Biometrics Technology Co.,LTD.
  Only supplies the development which purchases TrustLink platform product
  and Aratek certified BIO-EC.
  If has any question about this sample code, Welcome to visit Aratek website:
  WWW.ARATEK.COM.CN or Call Aratek: +86-755-26018866 to contact us.
*******************************************************************************/

/// <summary>
/// TrustLinkGeneralController, notice inherit System.Web.UI.Control and implement System.Web.UI.IPostBackEventHandler
/// </summary>
public class TrustLinkGeneralController : System.Web.UI.Control, System.Web.UI.IPostBackEventHandler
{
    private const string EMPTY_ENROLLED_FINGERS = "";
    private const string AVAILABLE_FINGERS = "";
    private const string EMPTY_AUTHEN_ID = "";
    private const string AUTHEN_FINGERS = "";
    private const int USER_NOT_EXIST = 62;
    private const int NOT_REGISTER_AUTHENTIFICATION = 14;
    private const int ERR_UNKNOWN = -1;
    private const int SUCCESSED = 0;
    private const int ENROLLED_FINGER_LEN = 21;
    private const string DEVICE_TYPE = "31";
    private const string XDEV_DLL_NAME = "XNMiddle.dll";

    #region DLL_Import

    [DllImport("XNMiddle.dll")]
    public static extern void InitAgent(
        string ProductID,
        int PacketType,
        [MarshalAs(UnmanagedType.AnsiBStr)]
		string HostName,
        int Port,
        bool Persistent);

    [DllImport("XNMiddle.dll")]
    public static extern int ConnectServer();

    [DllImport("XNMiddle.dll", EntryPoint = "AddUserByPwd", CallingConvention = CallingConvention.Cdecl)]
    public static extern int AddUserByPwd(string UserID, string AuthenID, string AuthenPwd);

    [DllImport("XNMiddle.dll", EntryPoint = "DeleteUserByPwd", CallingConvention = CallingConvention.Cdecl)]
    public static extern int DeleteUserByPwd(string UserID, string AuthenID, string AuthenPwd);

    [DllImport("XNMiddle.dll", EntryPoint = "SetFPDeviceType", CallingConvention = CallingConvention.Cdecl)]
    public static extern int SetFPDeviceType(int DeviceType);

    [DllImport("XNMiddle.dll", EntryPoint = "IsUserExisted", CallingConvention = CallingConvention.Cdecl)]
    public static extern int IsUserExisted(string UserID);

    [DllImport("XNMiddle.dll", EntryPoint = "GetEnrolledFingers", CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetEnrolledFingers(string UserID, StringBuilder Finger);

    [DllImport("XNMiddle.dll", EntryPoint = "GetAgentInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern int GetAgentInfo(StringBuilder AgentInfo);

    [DllImport("XNMiddle.dll")]
    public static extern int ExecutePacket(string TemplaeData);

    [DllImport("XNMiddle.dll")]
    public static extern int FPGetUser(StringBuilder User);

    #endregion

    private CultureInfo AP_culture = CultureInfo.CurrentCulture;
    private DllPlugin _dllPlugin;

    public TrustLinkGeneralController()
    {
        _dllPlugin = new DllPlugin(XDEV_DLL_NAME);
    }

   ~TrustLinkGeneralController()
    {
        _dllPlugin = null;
    }
    
    #region Property

    private string _HostName;
    public string HostName
    {
        get
        {
            return _HostName;
        }
        set
        {
            _HostName = value;
        }
    }

    private string _ProductID;
    public string ProductID
    {
        get
        {
            return _ProductID;
        }
        set
        {
            _ProductID = value;
        }
    }

    private int _Port;
    public int Port
    {
        get
        {
            return _Port;
        }
        set
        {
            _Port = value;
        }
    }

    private string _AuthenID;
    public string AuthenID
    {
        get
        {
            return _AuthenID;
        }
        set
        {
            _AuthenID = value;
        }
    }

    private string _AuthenPwd;
    public string AuthenPwd
    {
        get
        {
            return _AuthenPwd;
        }
        set
        {
            _AuthenPwd = value;
        }
    }

    private string _DeviceType = DEVICE_TYPE;
    public string DeviceType
    {
        get
        {
            return _DeviceType; 
        }
        set
        {
            _DeviceType = value;
        }
    }

    private string _OcxClassID;
    public string OcxClassID
    {
        get
        {
            return _OcxClassID;
        }
        set
        {
            _OcxClassID = value;
        }
    }

    private string _OcxName;
    public string OcxName
    {
        get
        {
            return _OcxName;
        }
        set
        {
            _OcxName = value;
        }
    }

    private string _LastErrMsg = "N/A";
    public string LastErrMsg
    {
        get
        {
            return _LastErrMsg;
        }
    }

    private string _LastErrReason = "N/A";
    public string LastErrReason
    {
        get
        {
            return _LastErrReason;
        }
    }

    private int _LastErrCode = -1;
    public int LastErrCode
    {
        get
        {
            return _LastErrCode;
        }
    }
    #endregion


    private static object _eventOperDlgPostEvent = new object(); 
    /// <summary>
    /// Declare an EventHandler
    /// </summary>
    public event EventHandler OnOperDlgPostEvent 
    {
        add
        {
            Events.AddHandler(_eventOperDlgPostEvent, value);
        }
        remove
        {
            Events.RemoveHandler(_eventOperDlgPostEvent, value);
        }
    }

    /// <summary>
    /// Tigger OnOperDlgPostEvent and send Result to Class ResultCodeArgs
    /// </summary>
    /// <param name="aResultCode">Operation Result Return Code Value</param>
    /// <param name="aResultMessage">Operation Result Return Message</param>
    public void DoOperDlgPostEvent(int aResultCode, string aResultMessage) 
    {
        EventHandler handler = (EventHandler)Events[_eventOperDlgPostEvent];
        if (handler != null) handler(this, new ResultCodeArgs(aResultCode,aResultMessage));
    }

    /// <summary>
    /// Post Back Event
    /// </summary>
    /// <param name="eventArgument">Process type and Fingerprint template data</param>
    void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
    {
        int iResultCode = SUCCESSED;
        string strLastErrMsg = "";
        string strLastErrReason = "";
        string strResultMessage = "";

        try
        {
            string[] strArgs = eventArgument.Split(',');
            ProcID intAction = (ProcID)(Convert.ToInt32(strArgs[0].ToString()));

            string strTemplateData = strArgs[1].ToString();
            iResultCode = ExecutePacket(strTemplateData);

            if (iResultCode == SUCCESSED)
            {
                //if the process type is fingerprint Identify, then Get the Identify user message
                if (intAction == ProcID.FPIdentify) 
                {
                    strResultMessage = BK_FPGetUser();
                }
            }
            else
            {
                strLastErrMsg = getErrMsg(intAction);
                strLastErrReason = GetErrRsn(intAction);
                strResultMessage = strLastErrMsg + strLastErrReason;
            }
        }
        catch
        {
            iResultCode = ERR_UNKNOWN;
            strLastErrMsg = getErrMsg(ProcID.UnknowErr);
            strLastErrReason = GetErrRsn(ProcID.UnknowErr);
            strResultMessage = strLastErrMsg + strLastErrReason;
        }
        //execute the Event trigger process
        DoOperDlgPostEvent(iResultCode, strResultMessage); 
    }

    public int _ResultCode;
    private enum ProcID : int
    {
        CheckXSDevHandle,
        ConnectServers,
        AddUserProc,
        EnrollByPwdProc,
        DelUserProc,
        UnknowErr,
        GetEnrolledFingers,
        FPAuthenDlg,
        FPIdentify
    }

    private string loadStr(string aIdent)
    {
        return Resources.TrustLinkGeneralRes.ResourceManager.GetString(aIdent, AP_culture);
    }

    private string GetErrRsn(ProcID aProcID)
    {
        string strProc = "";
        switch (aProcID)
        {
            case ProcID.AddUserProc:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                        "\\n" + loadStr("IDS_DELETE_EXISTED_USER_ID") +
                        "\\n" + loadStr("IDS_ADD_USER_AGAIN");
                break;
            case ProcID.DelUserProc:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                        "\\n" + loadStr("IDS_CHECK_USER_ID");
                break;
            case ProcID.ConnectServers:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                        "\\n" + loadStr("IDS_XSERVER_SHUT_DOWN") +
                        "\\n" + loadStr("IDS_XSERVER_RESTART") +
                        "\\n" + loadStr("IDS_CHECK_PRODUCT_ID") +
                        "\\n" + loadStr("IDS_CHECK_PORT_NUMBER");
                break;
            case ProcID.CheckXSDevHandle:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                        "\\n" + loadStr("IDS_MISSING_DLL") +
                        "\\n" + loadStr("IDS_CHECK_DLL_EXISTED");
                break;
            case ProcID.EnrollByPwdProc:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                       "\\n" + loadStr("IDS_ADD_ENROLL_FINGERS_AGAIN");
                break;
            case ProcID.GetEnrolledFingers:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                        "\\n" + loadStr("IDS_CHECK_USER_EXIST") +
                        "\\n" + loadStr("IDS_IS_USER_FINGER_EXIST");
                break;
            case ProcID.FPAuthenDlg:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                        "\\n" + loadStr("IDS_USE_VALID_ENROLL_FINGERS_AGAIN");
                break;
            case ProcID.FPIdentify:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                           "\\n" + loadStr("IDS_CHECK_USER_EXIST") +
                           "\\n" + loadStr("IDS_IS_USER_FINGER_EXIST");
                break;
            case ProcID.UnknowErr:
                strProc = "\\n" + loadStr("IDS_SUGGEST_ITEM") +
                        "\\n" + loadStr("IDS_CONTACT_VENDOR");
                break;
        }
        return strProc;
    }

    /// <summary>
    /// Return the error message
    /// </summary>
    /// <param name="aProcID">Action number of enum ProcID</param>
    /// <returns>Return the error message</returns>
    private string getErrMsg(ProcID aProcID)
    {
        string strProc = "";
        switch (aProcID)
        {
            case ProcID.AddUserProc:
                strProc = loadStr("IDS_ADD_USER_FAILED");
                break;
            case ProcID.DelUserProc:
                strProc = loadStr("IDS_DELETE_USER_FAILED");
                break;
            case ProcID.ConnectServers:
                strProc = loadStr("IDS_XSERVER_CONNECT_FAILED");
                break;
            case ProcID.CheckXSDevHandle:
                strProc = loadStr("IDS_LOAD_DLL_FAILED");
                break;
            case ProcID.EnrollByPwdProc:
                strProc = loadStr("IDS_ENROLL_FINGERS_FAILED");
                break;
            case ProcID.GetEnrolledFingers:
                strProc = loadStr("IDS_GET_ENROLL_FINGER_ERROR");
                break;
            case ProcID.FPAuthenDlg:
                strProc = loadStr("IDS_FPAUTHEN_ERROR");
                break;
            case ProcID.FPIdentify:
                strProc = loadStr("IDS_FPIDENT_ERROR");
                break;
            case ProcID.UnknowErr:
                strProc = loadStr("IDS_UNKNOW_ERROR");
                break;
        }
        return strProc;
    }

    /// <summary>
    /// Exception throw
    /// </summary>
    /// <param name="aProcID">Operation Action enum</param>
    /// <param name="aIsRaise">Throw the exception or not</param>
    private void ProcErr(ProcID aProcID, bool aIsRaise)
    {
        _LastErrCode = _ResultCode;
        _LastErrMsg = getErrMsg(aProcID);
        _LastErrReason = GetErrRsn(aProcID);
        TempLog.Info("亚略特自带错误处理-》_LastErrCode->" + _LastErrCode.ToString() + "\r\n_LastErrMsg->" + _LastErrMsg + "\r\n_LastErrReason->"+_LastErrReason);
        if (aIsRaise)
        {
            throw new TrustLinkGeneralException();
        }
    }

    /// <summary>
    /// Check Device Handle
    /// </summary>
    private void BK_CheckXSDevHandle()
    {
        if (_dllPlugin.library == IntPtr.Zero)
        {
            TempLog.Info("XSDevHandle不存在，请检查是否安装Xmiddle!");
            _ResultCode = ERR_UNKNOWN;
            ProcErr(ProcID.CheckXSDevHandle, true); //Operation Exception and throw
        }
    }

    /// <summary>
    /// Connect TrustLink XServer
    /// </summary>
    private void BK_Connectservers()
    {
        TempLog.Info("开始调用Xmiddle的InitAgent");
        InitAgent(_ProductID, 0, _HostName, _Port, false);
        TempLog.Info("结束调用Xmiddle的InitAgent并调用Xmiddle的ConnectServer！");
       // _ResultCode = ConnectServer();

        /**/
         
          int i=3;
        while(i>0)
        {
            _ResultCode = ConnectServer();
            if (_ResultCode == SUCCESSED)
            {
                break;
            }
            else
            {
                System.Threading.Thread.Sleep(50);
            }
            i--;
        }
         
        TempLog.Info("结束调用Xmiddle的ConnectServer，ResultCode->"+_ResultCode.ToString());
        if (_ResultCode != SUCCESSED)
        {

            
            ProcErr(ProcID.ConnectServers, true); //Operation Exception and throw
        }
        TempLog.Info("开始调用Xmiddle的SetFPDeviceType");
        SetFPDeviceType(Convert.ToInt32(this.DeviceType)); //设定设备的类型
        TempLog.Info("结束调用Xmiddle的SetFPDeviceType");
    }

    /// <summary>
    /// Register User to TrustLink Server
    /// </summary>
    /// <param name="aUserID">Will be register userID</param>
    private void BK_AddUser(string aUserID)
    {
        _ResultCode = AddUserByPwd(aUserID, _AuthenID, _AuthenPwd);
        if (_ResultCode != SUCCESSED)
        {
            ProcErr(ProcID.AddUserProc, true);
        }
    }

    /// <summary>
    /// Register user fingerprint to TrustLink Server,if register falure, then delete the user by TrustLink Server
    /// </summary>
    /// <param name="aUserID">Will be register userID</param>
    private void BK_FPEnroll(string aUserID)
    {
        //Get Agent Info
        StringBuilder af_AgentInfo = new StringBuilder(60);
        _ResultCode = GetAgentInfo(af_AgentInfo);

        //Write Enroll OCX 
        Page.Response.ContentType = "text/html";
        Page.Response.Write("<html>");
        Page.Response.Write("<BODY bgcolor=#FFFFFF >");
        Page.Response.Write("<FORM  id=EnrollForm method=post name=EnrollFormEnroll >");
        Page.Response.Write("	<OBJECT ID=EnrollX  ");
        Page.Response.Write("		classid=clsid:" + this.OcxClassID);
        Page.Response.Write("		codebase=" + this.OcxName);
        Page.Response.Write("		hspace=0  ");
        Page.Response.Write("		vspace=0 >");
        Page.Response.Write("		<PARAM name=IconVisible VALUE=0>");
        Page.Response.Write("	</OBJECT>");
        Page.Response.Write("</FORM>");
        Page.Response.Write("</BODY>");
        Page.Response.Write("</html>");

        //Dialog
        string sFinger = "";
        string sAuthenID = this.AuthenID;
        string sAuthenPwd = this.AuthenPwd;
        string SCP_SCRIPT_START = "\n<script language=\"javascript\">\n";
        string SCP_SET_AGENT_INFO = "EnrollForm.EnrollX.SetAgentInfo(\"" + af_AgentInfo + "\");\n";
        string SCP_ENROLL_BY_PWD = "strTemplateData = '" + (int)ProcID.EnrollByPwdProc + ",' + EnrollForm.EnrollX.EnrollByPwdExport(\"" + aUserID + "\", \"" + sFinger + "\", \" \", 0, 0, \"" + sAuthenID + "\", \"" + sAuthenPwd + "\"); \n";
        ClientScriptManager newCSM = Page.ClientScript;
        string SCP_SET_POST_BACK = Regex.Replace(newCSM.GetPostBackEventReference(this, ""), "''", "strTemplateData") + "\n";
        string SCP_SCRIPT_END = "</script>\n";
        
        newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(),
            SCP_SCRIPT_START + SCP_SET_AGENT_INFO + SCP_ENROLL_BY_PWD + SCP_SET_POST_BACK + SCP_SCRIPT_END);
    }

    /// <summary>
    /// Update Enroll user fingerprint
    /// </summary>
    /// <param name="aUserID">The user will be Update fingerprint </param>
    /// <param name="aEnrolledFingers">The user already enrolled fingerprints</param>
    /// <returns>0=success,else=falure.</returns>
    private void BK_FPUpdateEnroll(string aUserID, string aEnrolledFingers)
    {
        //Get Agent Info
        StringBuilder af_AgentInfo = new StringBuilder(60);
        _ResultCode = GetAgentInfo(af_AgentInfo);

        //Write Enroll OCX 
        Page.Response.ContentType = "text/html";
        Page.Response.Write("<html>");
        Page.Response.Write("<BODY bgcolor=#FFFFFF >");
        Page.Response.Write("<FORM  id=EnrollForm method=post name=EnrollFormEnroll >");
        Page.Response.Write("	<OBJECT ID=EnrollX  ");
        Page.Response.Write("		classid=clsid:" + this.OcxClassID);
        Page.Response.Write("		codebase=" + this.OcxName);
        Page.Response.Write("		hspace=0  ");
        Page.Response.Write("		vspace=0 >");
        Page.Response.Write("		<PARAM name=IconVisible VALUE=0>");
        Page.Response.Write("	</OBJECT>");
        Page.Response.Write("</FORM>");
        Page.Response.Write("</BODY>");
        Page.Response.Write("</html>");

        //Dialog
        string sFinger = aEnrolledFingers;
        string sAuthenID = this.AuthenID;
        string sAuthenPwd = this.AuthenPwd;
        string SCP_SCRIPT_START = "\n<script language=\"javascript\">\n";
        string SCP_SET_AGENT_INFO = "EnrollForm.EnrollX.SetAgentInfo(\"" + af_AgentInfo + "\");\n";
        string SCP_ENROLL_BY_PWD = "strTemplateData = '" + (int)ProcID.EnrollByPwdProc + ",' + EnrollForm.EnrollX.EnrollByPwdExport(\"" + aUserID + "\", \"" + sFinger + "\", \" \", 0, 0, \"" + sAuthenID + "\", \"" + sAuthenPwd + "\"); \n";
        ClientScriptManager newCSM = Page.ClientScript;
        string SCP_SET_POST_BACK = Regex.Replace(newCSM.GetPostBackEventReference(this, ""), "''", "strTemplateData") + "\n";
        string SCP_SCRIPT_END = "</script>\n";

        newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(),
            SCP_SCRIPT_START + SCP_SET_AGENT_INFO + SCP_ENROLL_BY_PWD + SCP_SET_POST_BACK + SCP_SCRIPT_END);
    }

    /// <summary>
    /// Get user Enrolled Fingers
    /// </summary>
    /// <param name="aUserID">registered userID</param>
    /// <returns>registered Enrolled Fingers message</returns>
    private string BK_GetEnrolledFingers(string aUserID)
    {
        int iEnrolledFingerLen = ENROLLED_FINGER_LEN;
        StringBuilder sbEnrolledFinger = new StringBuilder(iEnrolledFingerLen);
        _ResultCode = GetEnrolledFingers(aUserID, sbEnrolledFinger);
        if (_ResultCode != SUCCESSED)
        {
            ProcErr(ProcID.GetEnrolledFingers, true);
            return "";
        }
        else
        {
            return sbEnrolledFinger.ToString();
        }
    }

    /// <summary>
    /// Authen Fingerprint
    /// </summary>
    /// <param name="aUserID">Authen userID</param>
    /// <param name="aEnrolledFingers">Authen userID Enrolled Fingers</param>
    private void BK_FPAuthen(string aUserID, string aEnrolledFingers)
    {
        //Get Agent Info
        StringBuilder af_AgentInfo = new StringBuilder(60);
        _ResultCode = GetAgentInfo(af_AgentInfo);

        //Write Verify OCX 
        Page.Response.ContentType = "text/html";
        Page.Response.Write("<html>");
        Page.Response.Write("<BODY bgcolor=#FFFFFF >");
        Page.Response.Write("<FORM  id=VerifyForm method=post name=EnrollFormEnroll >");
        Page.Response.Write("	<OBJECT ID=VerifyX  ");
        Page.Response.Write("		classid=clsid:" + this.OcxClassID);
        Page.Response.Write("		codebase=" + this.OcxName);
        Page.Response.Write("		hspace=0  ");
        Page.Response.Write("		vspace=0 >");
        Page.Response.Write("		<PARAM name=IconVisible VALUE=0>");
        Page.Response.Write("	</OBJECT>");
        Page.Response.Write("</FORM>");
        Page.Response.Write("</BODY>");
        Page.Response.Write("</html>");

        //Dialog
        // string sFinger = "";
        //  string sAuthenID = "sa";
        //   string sAuthenPwd = "sa";
        string SCP_SCRIPT_START = "\n<script language=\"javascript\">\n";
        string SCP_SET_AGENT_INFO = "VerifyForm.VerifyX.SetAgentInfo(\"" + af_AgentInfo + "\");\n";
        string SCP_AUTHEN = "strTemplateData = '" + (int)ProcID.FPAuthenDlg + ",' +VerifyForm.VerifyX.AuthenDlgExport(\"" + aUserID + "\", \"" + aEnrolledFingers + "\", 0);\n ";
        ClientScriptManager newCSM = Page.ClientScript;
        string SCP_SET_POST_BACK = Regex.Replace(newCSM.GetPostBackEventReference(this, ""), "''", "strTemplateData") + "\n";
        string SCP_SCRIPT_END = "</script>\n";
        newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(),
            SCP_SCRIPT_START + SCP_SET_AGENT_INFO + SCP_AUTHEN + SCP_SET_POST_BACK + SCP_SCRIPT_END);
    }

    /// <summary>
    /// Vindicate Fingerprint
    /// </summary>
    /// <returns>user and fingerprint message</returns>
    private void BK_FPIdentify()
    {
        //Get Agent Info
        StringBuilder af_AgentInfo = new StringBuilder(60);
        TempLog.Info("开始调用Xmiddle的GetAgentInfo");
        _ResultCode = GetAgentInfo(af_AgentInfo);
        TempLog.Info("结束调用Xmiddle的GetAgentInfo,并准备输入html,ResultCode->"+_ResultCode.ToString());
        //Write Verify OCX 
        Page.Response.ContentType = "text/html";
        Page.Response.Write("<html>");
        Page.Response.Write("<BODY bgcolor=#FFFFFF >");
        Page.Response.Write("<FORM  id=VerifyForm method=post name=EnrollFormEnroll >");
        Page.Response.Write("	<OBJECT ID=VerifyX  ");
        Page.Response.Write("		classid=clsid:" + this.OcxClassID);
        Page.Response.Write("		codebase=" + this.OcxName);
        Page.Response.Write("		hspace=0  ");
        Page.Response.Write("		vspace=0 >");
        Page.Response.Write("		<PARAM name=IconVisible VALUE=0>");
        Page.Response.Write("	</OBJECT>");
        Page.Response.Write("</FORM>");
        Page.Response.Write("</BODY>");
        Page.Response.Write("</html>");

        //Dialog
        //  string sFinger = "";
        //   string sAuthenID = "sa";
        //    string sAuthenPwd = "sa";
        string SCP_SCRIPT_START = "\n<script language=\"javascript\">\n";
        string SCP_SET_AGENT_INFO = "VerifyForm.VerifyX.SetAgentInfo(\"" + af_AgentInfo + "\");\n";
        string SCP_AUTHEN = "strTemplateData = '" + (int)ProcID.FPIdentify + ",' + VerifyForm.VerifyX.AuthenDlgExport(\"" + "" + "\", \"" + "" + "\", 0);\n ";
        ClientScriptManager newCSM = Page.ClientScript;
        string SCP_SET_POST_BACK = Regex.Replace(newCSM.GetPostBackEventReference(this, ""), "''", "strTemplateData") + "\n";
        string SCP_SCRIPT_END = "</script>\n";
        newCSM.RegisterStartupScript(this.GetType(), this.GetHashCode().ToString(),
            SCP_SCRIPT_START + SCP_SET_AGENT_INFO + SCP_AUTHEN + SCP_SET_POST_BACK + SCP_SCRIPT_END);
        TempLog.Info("结束Html的输出!");
    }

    private string BK_FPGetUser()
    {
        StringBuilder sbUser = new StringBuilder(40);
        FPGetUser(sbUser);
        return sbUser.ToString();
    }

    /// <summary>
    /// Delete user by TrustLink Server
    /// </summary>
    /// <param name="aUserID">Will be delete userID</param>
    private void BK_DeleteUserFun(string aUserID)
    {
        _ResultCode = DeleteUserByPwd(aUserID, _AuthenID, _AuthenPwd);
        if (_ResultCode != SUCCESSED)
        {
            ProcErr(ProcID.DelUserProc, true);
        }
    }

    #region NewEnroll

    //******************************************************************************
    //Function Name:
    //    NewEnroll.
    //Functional description:
    //    The NewEnroll function consists of five blocks below:
    //        1. BK_CheckXSDevHandle:
    //               Check the fingerprint device corresponds DLL.
    //        2. BK_Connectservers: Connected to the Server.
    //               i. Call InitAgent function of DLL to initial XAgent action.
    //              ii. Call ConnectServer functiono f DLL to test TrustLink XServer connect situation.
    //        3. BK_AddUser(aUserID): Add a user to the Server.
    //               i. Call AddUserByPwd function
    //        4. BK_FPEnroll(aUserID): Manage add user fingerprints.
    //               i. Call EnrollByPwd function.
    //        5. Exception
    //
    //Function Declaration:
    //    NewEnroll(aUserID: string): integer;
    //Parameter description:
    //  aUserID: Authenticatee ID.
    //Result value:
    //        0: NewEnroll successfully.
    //       14: Fingers of the authenticatee have not been enrolled.
    //       31ID has been registered.
    //         Suggestion item:
    //           1. Delete existed user ID.
    //           2. Add user ID again.
    //       60: No connection copyright of Client product.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //      202: TrustLink Xserver connection error.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //      215: System parameter lack error.
    //         Suggestion item:
    //           1. Delete existed user ID.
    //           2. Add user ID again.
    //      404: The user requires to cancel and leave.
    //         Suggestion item:
    //           1. Please enroll fingers again.
    //******************************************************************************

    /// <summary>
    /// Register User and Register Fingerprint
    /// </summary>
    /// <param name="aUserID">the user will be register</param>
    /// <returns>0=success,else=error coce</returns>
    public int NewEnroll(string aUserID)
    {
        try
        {
            BK_CheckXSDevHandle(); //Check Device Handle
            BK_Connectservers(); //Connect TrustLink Server
            BK_AddUser(aUserID); //Register User
            BK_FPEnroll(aUserID); //Register Fingerprint
            return _ResultCode;
        }
        catch (TrustLinkGeneralException)
        {
            return _LastErrCode;
        }
    }
    #endregion

    #region  UpdateEnroll

    //******************************************************************************
    //Function Name:
    //    UpdateEnroll.
    //Functional description:
    //    The UpdateEnroll function consists of five blocks below:
    //        1. BK_CheckXSDevHandle:
    //               Check the fingerprint device corresponds DLL.
    //        2. BK_Connectservers: Connected to the Server.
    //               i. Call InitAgent function of DLL to initial XAgent action.
    //              ii. Call ConnectServer functiono f DLL to test TrustLink XServer connect situation.
    //        3. BK_GetEnrolledFingers(aUserID): Query enrolled fingers of the user.
    //               i. Call GetEnrolledFingers function.
    //        4. BK_FPUpdateEnroll(aUserID, aEnrolledFingers): Manage (update/delete) user fingerprints.
    //               i. Call EnrollByPwd function.
    //        5. self.NewEnroll(aUserID)
    //        6. Exception
    //
    //Function Declaration:
    //    UpdateEnroll(aUserID: string): integer;
    //Parameter description:
    //  aUserID: Authenticatee ID.
    //Result value:
    //        0: NewEnroll successfully.
    //       60: No connection copyright of Client product.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //      202: TrustLink Xserver connection error.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //      215: System parameter lack error.
    //         Suggestion item:
    //           1. Delete existed user ID.
    //           2. Add user ID again.
    //      404: The user requires to cancel and leave.
    //         Suggestion item:
    //           1. Please enroll fingers again.
    //******************************************************************************

    public int UpdateEnroll(string aUserID)
    {
        try
        {
            BK_CheckXSDevHandle();
            BK_Connectservers();
            try
            {
                BK_FPUpdateEnroll(aUserID, BK_GetEnrolledFingers(aUserID));
            }
            catch (TrustLinkGeneralException)
            {
                switch (_LastErrCode)
                {
                    case USER_NOT_EXIST: //UserNoExist
                        _ResultCode = NewEnroll(aUserID);
                        break;
                    case NOT_REGISTER_AUTHENTIFICATION: //NOT_REGISTER_AUTHENTIFICATION
                        BK_FPUpdateEnroll(aUserID, EMPTY_ENROLLED_FINGERS);
                        break;
                    default:
                        _ResultCode = _LastErrCode;
                        break;
                }
            }
        }
        catch (TrustLinkGeneralException)
        {
            _ResultCode = _LastErrCode;
        }
        return _ResultCode;
    }
    #endregion

    #region FPUserVerify

    //******************************************************************************
    //Function Name:
    //    FPUserVerify.
    //Functional description:
    //    The FPUserVerify function consists of five blocks below:
    //        1. BK_CheckXSDevHandle:
    //               Check the fingerprint device corresponds DLL.
    //        2. BK_Connectservers: Connected to the Server.
    //               i. Call InitAgent function of DLL to initial XAgent action.
    //              ii. Call ConnectServer functiono f DLL to test TrustLink XServer connect situation.
    //        3. BK_GetEnrolledFingers(aUserID): Query enrolled fingers of the user.
    //               i. Call GetEnrolledFingers function
    //        4. BK_FPAuthen(aUserID, aEnrolledFingers): Fingerprint authentication.
    //               i. Call FPAuthenDlg function of DLL to verify user account and fingerprint.
    //        5. Exception
    //
    //Function Declaration:
    //    FPUserVerify(aUserID: string): integer;
    //Parameter description:
    //  aUserID: Authenticatee ID.
    //Result value:
    //        0: Verified successfully.
    //       12: User ID not input
    //         Suggestion item:
    //           1. Check user has registration user ID.
    //           2. Check user has registration enroll fingers.
    //       14: Fingers of the authenticatee have not been enrolled.
    //       33: Incorrect verification.
    //         Suggestion item:
    //           1. Please identify again with valid finger.
    //       60: No connection copyright of Client product.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //       62: The User ID does not exist.
    //         Suggestion item:
    //           1. Check user has registration user ID.
    //           2. Check user has registration enroll fingers.
    //      202: TrustLink Xserver connection error.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //      215: System parameter lack error.
    //         Suggestion item:
    //           1. Delete existed user ID.
    //           2. Add user ID again.
    //      404: The user requires to cancel and leave.
    //         Suggestion item:
    //           1. Please enroll fingers again.
    //******************************************************************************   

    /// <summary>
    /// Verify Fingerpfint
    /// </summary>
    /// <param name="aUserID">the user will be verify</param>
    /// <returns>0=success,else=error code</returns>
    public int FPUserVerify(string aUserID)
    {
        try
        {
            BK_CheckXSDevHandle(); //Check Device Handle
            BK_Connectservers(); //Connect TrustLink Server
            BK_FPAuthen(aUserID, BK_GetEnrolledFingers(aUserID)); //Authen finterprint
            return _ResultCode;
        }
        catch (TrustLinkGeneralException)
        {
            return _LastErrCode;
        }
    }
    #endregion

    #region FPUserIdentify

    //******************************************************************************
    //Function Name:
    //    FPUserIdentify.
    //Functional description:
    //    The FPUserIdentify function consists of five blocks below:
    //        1. BK_CheckXSDevHandle:
    //               Check the fingerprint device corresponds DLL.
    //        2. BK_Connectservers: Connected to the Server.
    //               i. Call InitAgent function of DLL to initial XAgent action.
    //              ii. Call ConnectServer functiono f DLL to test TrustLink XServer connect situation.
    //        3. BK_FPIdentify(): Fingerprint authentication.
    //               i. Call FPAuthenDlg function of DLL to verify user account and fingerprint.
    //        4. Exception
    //                
    //Function Declaration:
    //    FPUserIdentify(): integer;
    //Result value:
    //        0: Identified successfully.
    //       39Cannot be identified.
    //         Suggestion item:
    //           1. Check user has registration user ID.
    //           2. Check user has registration enroll fingers.
    //       60: No connection copyright of Client product.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //      202: TrustLink Xserver connection error.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //      215: System parameter lack error.
    //         Suggestion item:
    //           1. Delete existed user ID.
    //           2. Add user ID again.
    //      404: The user requires to cancel and leave.
    //         Suggestion item:
    //           1. Please enroll fingers again.
    //******************************************************************************

    /// <summary>
    /// Vindicate fingerprint
    /// </summary>
    /// <returns>0=success,else=error code</returns>
    public int FPUserIdentify()
    {
        try
        {
            TempLog.Info("开始检测XSdevHandle是否存在！");
            BK_CheckXSDevHandle(); //Check Device Handle
            TempLog.Info("结束检测XSdevHandle是否存在并开始连接服务器！");
            BK_Connectservers(); //Connect TrustLink Server
            TempLog.Info("结束连接服务器并开始指纹验证！");
            BK_FPIdentify(); //Vindicate fingerprint
            TempLog.Info("结束指纹验证！_ResultCode为-》" + _ResultCode);
            return _ResultCode;
        }
        catch (TrustLinkGeneralException e)
        {
            TempLog.Info("一对多指纹验证出现异常，_LastErrCode为-》" + _LastErrCode+"异常信息:" +e.ToString());
            return _LastErrCode;
        }
    }
    #endregion

    #region DeleteUser

    //******************************************************************************
    //Function Name:
    //    DeleteUser.
    //Functional description:
    //    The DeleteUser function consists of five blocks below:
    //        1. BK_CheckXSDevHandle:
    //               Check the fingerprint device corresponds DLL.
    //        2. BK_Connectservers: Connected to the Server.
    //               i. Call InitAgent function of DLL to initial XAgent action.
    //              ii. Call ConnectServer functiono f DLL to test TrustLink XServer connect situation.
    //        3. BK_DeleteUserFun(aUserID): Delete the user from the Server.
    //               i. Call DeleteUserByPwd function
    //        4. Exception
    //
    //Function Declaration:
    //    DeleteUser(aUserID: string): integer;
    //Parameter description:
    //  aUserID: Authenticatee ID.
    //Result value:
    //        0: Delete successfully.
    //       12: User ID not input
    //         Suggestion item:
    //           1. Check user has registration user ID.
    //           2. Check user has registration enroll fingers.
    //       28Authentication information not input.
    //       33: Incorrect verification.
    //         Suggestion item:
    //           1. 1. Please identify again with valid finger.
    //       60: No connection copyright of Client product.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //       62: The User ID does not exist.
    //         Suggestion item:
    //           1. Check user has registration user ID.
    //           2. Check user has registration enroll fingers.
    //      202: TrustLink Xserver connection error.
    //         Suggestion item:
    //           1. Inspects whether stopped using TrustLink XServer
    //           2. Restart XServer.
    //           3. Make sure Product ID is correct.
    //           4. Make sure Port number is correct.
    //      215: System parameter lack error.
    //         Suggestion item:
    //           1. Delete existed user ID.
    //           2. Add user ID again.
    //******************************************************************************

    /// <summary>
    /// Delete User
    /// </summary>
    /// <param name="aUserID">the user will be delete</param>
    /// <returns>0=success,else=error code</returns>
    public int DeleteUser(string aUserID)
    {
        try
        {
            BK_CheckXSDevHandle(); //Check Device Handle
            BK_Connectservers(); //Connect TrustLink Server
            BK_DeleteUserFun(aUserID); //Delete User
            return _ResultCode;
        }
        catch (TrustLinkGeneralException)
        {
            return _LastErrCode;
        }
    }
    #endregion
}

/// <summary>
/// DLL Load Operation
/// </summary>
public class DllPlugin
{
    [DllImport("kernel32.dll")]
    private extern static IntPtr LoadLibrary(string fileName);

    [DllImport("kernel32.dll")]
    private extern static bool FreeLibrary(IntPtr lib);

    private IntPtr _lib = IntPtr.Zero;

    public DllPlugin(string aDeviceName)
    {
        _lib = LoadLibrary(aDeviceName);
    }


    ~DllPlugin()
    {
        dispose();
    }

    private void dispose()
    {
        if (_lib == IntPtr.Zero)
        {
            return;
        }
        FreeLibrary(_lib);
        _lib = IntPtr.Zero;
    }

    public IntPtr library
    {
        get
        {
            return _lib;
        }
    }
}
