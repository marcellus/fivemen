using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Resources;

namespace FingerCollection
{
    public class TrustLinkGeneralException : Exception
    {
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

    /******************************************************************************
    Object Name  = TrustLink_General
    Copyright    = Shenzhen AraTek Co.,Ltd. All Rights reserved.
    Developer    = Allen
    Version      = [1.0.0.0]
    Description  = 
      To create more convenient and reliable communication in Enterprise environment
    , Shenzhen Aratek Biometrics Technology Co., Ltd. provide a TrustLink General
    Function Component to make developer who develop with Microsoft Visual C# 2005 Express Edition can be simple
    also fast to control fingerprint application suite.

      Basically, The TrustLink General Function Component provides many kinds of
    public functions for the developer easily to use. As a result of such
    characteristic, The TrustLink General Function Component has the merit which
    may simply use and uses again.

      TrustLink General Function Component public functions as below:
      function:
        NewEnroll     : Add the registration fingerprint user.
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
        LastErrMsg    : Last produces error message.
        LastErrReason : Possible reason of last produces error.
        LastErrCode   : Return error code of last produces error.
        XSDevName     : Load fingerprint devices corresponds DLLs.

    Updaye Date = 2006/04/12
    *******************************************************************************/
    /******************************************************************************
    Company Infomation:
      This copyright turns over to the Aratek Biometrics Technology Co.,LTD.
      Only supplies the development which purchases TrustLink platform product
      and Aratek certified BIO-EC.
      If has any question about this sample code, Welcome to visit Aratek website:
      WWW.ARATEK.COM.CN or Call Aratek: +86-755-26018866 to contact us.
    *******************************************************************************/

    public class TrustLinkGeneralController
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

        #region DLL_Import

        [DllImport("ISDev.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitAgent(IntPtr lib, string ProductID, int PacketType, string HostName, int Port, bool Persistent);

        /// <summary>
        /// Connect to TrustLink XServer
        /// </summary>
        /// <param name="lib">DLL Handle</param>
        /// <returns>0=success,else=failure</returns>
        [DllImport("ISDev.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Connect(IntPtr lib);

        /// <summary>
        /// Check UserID is exist or not
        /// </summary>
        /// <param name="lib">DLL Handle</param>
        /// <param name="UserID">The User will be check</param>
        /// <returns>0=success(the user is exist),else=(the user is not exist)</returns>
        [DllImport("ISDev.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IsUserExisted(IntPtr lib, string UserID);

        /// <summary>
        /// Register user to TrustLink XServer
        /// </summary>
        /// <param name="lib">DLL Handle</param>
        /// <param name="UserID">The User will be register</param>
        /// <param name="AuthenID">Authen User ID of TrustLink Server</param>
        /// <param name="AuthenPwd">Authen User Password of TrustLink Server</param>
        /// <returns>0=success(Register User success),else=(Register User falure)</returns>
        [DllImport("ISDev.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int AddUserByPwd(IntPtr lib, string UserID, string AuthenID, string AuthenPwd);

        /// <summary>
        /// Get then exist user Enrolled Fingers
        /// </summary>
        /// <param name="lib">DLL Handle</param>
        /// <param name="UserID">The registered userID</param>
        /// <param name="Finger">If success, the Enrolled Fingers message else then empty</param>
        /// <param name="Len">The Enrolled Fingers message StringBuilder Finger length</param>
        /// <returns>0=success,else=falure</returns>
        [DllImport("ISDev.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetEnrolledFingers(IntPtr lib, string UserID, StringBuilder Finger, ref int Len);

        /// <summary>
        /// User Enroll Fingerprint
        /// </summary>
        /// <param name="lib">DLL Handle</param>
        /// <param name="UserID">The registered userID</param>
        /// <param name="EnrolledFingers">Already EnrolledFingers</param>
        /// <param name="AVAILABLE_FINGERS">Available EnrollFingers</param>
        /// <param name="MinCount"></param>
        /// <param name="MaxCount"></param>
        /// <param name="AuthenID">Authen User ID of TrustLink Server</param>
        /// <param name="AuthenPwd">Authen User Password of TrustLink Server</param>
        /// <returns>0=success(Enroll Fingerprint success),else=falure</returns>
        [DllImport("ISDev.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int EnrollByPwd(IntPtr lib, string UserID, string EnrolledFingers, string AVAILABLE_FINGERS, int MinCount, int MaxCount, string AuthenID, string AuthenPwd);

        /// <summary>
        /// User Fingerprint Authen
        /// </summary>
        /// <param name="lib">DLL Handle</param>
        /// <param name="AuthenID">Will be Authen User ID</param>
        /// <param name="AUTHEN_FINGERS">Will be Authen Fingers</param>
        /// <param name="AuthenMode">Authen Mode,default general 0</param>
        /// <param name="UserID">Authen success,the user of result message.</param>
        /// <param name="Len">Authen result StringBuilder UserID length</param>
        /// <returns>0=success(Authen success),else=falure</returns>
        [DllImport("ISDev.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int FPAuthenDlg(IntPtr lib, string AuthenID, string AUTHEN_FINGERS, int AuthenMode, StringBuilder UserID, ref int Len);

        /// <summary>
        /// Delete TrustLink User 
        /// </summary>
        /// <param name="lib">DLL Handle</param>
        /// <param name="UserID">the user will be delete</param>
        /// <param name="AuthenID">Authen User ID of TrustLink Server</param>
        /// <param name="AuthenPwd">Authen User Password of TrustLink Server</param>
        /// <returns>0=success(Delete success),else=falure</returns>
        [DllImport("ISDev.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeleteUserByPwd(IntPtr lib, string UserID, string AuthenID, string AuthenPwd);

        #endregion

        private DllPlugin _dllPlugin;

        private ResourceManager TrustLinkGeneralRes;
        private CultureInfo AP_culture = CultureInfo.CurrentCulture;
       // private CultureInfo AP_culture = CultureInfo.CurrentUICulture;
        public TrustLinkGeneralController()
        {
            //load language resource
            string strResName = "FingerCollection.Resource.Resource1";
            TrustLinkGeneralRes = new ResourceManager(strResName, this.GetType().Assembly);
            //found the native language resource
            TrustLinkGeneralRes.GetResourceSet(AP_culture, true, true);

        }

        ~TrustLinkGeneralController()
        {
            _dllPlugin = null;
        }

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

        private string _XSDev;
        public string XSDevName
        {
            get
            {
                return _XSDev;
            }
            set
            {
                if (_XSDev != value)
                {
                    _XSDev = value;
                    _dllPlugin = new DllPlugin(value);
                }
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

        private int _ResultCode;
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
            return TrustLinkGeneralRes.GetString(aIdent, AP_culture);
        }

        private string GetErrRsn(ProcID aProcID)
        {
            string strProc = "";
            switch (aProcID)
            {
                case ProcID.AddUserProc:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                            "\n" + loadStr("IDS_DELETE_EXISTED_USER_ID") +
                            "\n" + loadStr("IDS_ADD_USER_AGAIN");
                    break;
                case ProcID.DelUserProc:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                            "\n" + loadStr("IDS_CHECK_USER_ID");
                    break;
                case ProcID.ConnectServers:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                            "\n" + loadStr("IDS_XSERVER_SHUT_DOWN") +
                            "\n" + loadStr("IDS_XSERVER_RESTART") +
                            "\n" + loadStr("IDS_CHECK_PRODUCT_ID") +
                            "\n" + loadStr("IDS_CHECK_PORT_NUMBER");
                    break;
                case ProcID.CheckXSDevHandle:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                            "\n" + loadStr("IDS_MISSING_DLL") +
                            "\n" + loadStr("IDS_CHECK_DLL_EXISTED");
                    break;
                case ProcID.EnrollByPwdProc:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                           "\n" + loadStr("IDS_ADD_ENROLL_FINGERS_AGAIN");
                    break;
                case ProcID.GetEnrolledFingers:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                            "\n" + loadStr("IDS_CHECK_USER_EXIST") +
                            "\n" + loadStr("IDS_IS_USER_FINGER_EXIST");
                    break;
                case ProcID.FPAuthenDlg:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                            "\n" + loadStr("IDS_USE_VALID_ENROLL_FINGERS_AGAIN");
                    break;
                case ProcID.FPIdentify:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                               "\n" + loadStr("IDS_CHECK_USER_EXIST") +
                               "\n" + loadStr("IDS_IS_USER_FINGER_EXIST");
                    break;
                case ProcID.UnknowErr:
                    strProc = "\n" + loadStr("IDS_SUGGEST_ITEM") +
                            "\n" + loadStr("IDS_CONTACT_VENDOR");
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
                _ResultCode = ERR_UNKNOWN;
                ProcErr(ProcID.CheckXSDevHandle, true); //Operation Exception and throw
            }
        }

        /// <summary>
        /// Connect TrustLink XServer
        /// </summary>
        private void BK_Connectservers()
        {
            InitAgent(_dllPlugin.library, _ProductID, 0, _HostName, _Port, false);
            _ResultCode = Connect(_dllPlugin.library);
            if (_ResultCode != SUCCESSED)
            {
                ProcErr(ProcID.ConnectServers, true); //Operation Exception and throw
            }
        }

        /// <summary>
        /// Register User to TrustLink Server
        /// </summary>
        /// <param name="aUserID">Will be register userID</param>
        private void BK_AddUser(string aUserID)
        {
            _ResultCode = AddUserByPwd(_dllPlugin.library, aUserID, _AuthenID, _AuthenPwd);
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
            _ResultCode = EnrollByPwd(_dllPlugin.library, aUserID, EMPTY_ENROLLED_FINGERS, AVAILABLE_FINGERS, 0, 0, _AuthenID, _AuthenPwd);
            if (_ResultCode != SUCCESSED)
            {
                ProcErr(ProcID.EnrollByPwdProc, false);
                //if register falure, then delete the user by TrustLink Server
                DeleteUserByPwd(_dllPlugin.library, aUserID, _AuthenID, _AuthenPwd);
                throw new TrustLinkGeneralException();
            }
        }

        /// <summary>
        /// Update Enroll user fingerprint
        /// </summary>
        /// <param name="aUserID">The user will be Update fingerprint </param>
        /// <param name="aEnrolledFingers">The user already enrolled fingerprints</param>
        /// <returns>0=success,else=falure.</returns>
        private void BK_FPUpdateEnroll(string aUserID, string aEnrolledFingers)
        {
            _ResultCode = EnrollByPwd(_dllPlugin.library, aUserID, aEnrolledFingers, AVAILABLE_FINGERS, 0, 0, _AuthenID, _AuthenPwd);
            if (_ResultCode != SUCCESSED)
            {
                ProcErr(ProcID.EnrollByPwdProc, true);
            }
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
            _ResultCode = GetEnrolledFingers(_dllPlugin.library, aUserID, sbEnrolledFinger, ref iEnrolledFingerLen);
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
            int iTempLen = 40;
            StringBuilder sbTemp = new StringBuilder(iTempLen);
            _ResultCode = FPAuthenDlg(_dllPlugin.library, aUserID, aEnrolledFingers, 0, sbTemp, ref iTempLen);
            if (_ResultCode != SUCCESSED)
            {
                ProcErr(ProcID.FPAuthenDlg, true);
            }
        }

        /// <summary>
        /// Vindicate Fingerprint
        /// </summary>
        /// <returns>user and fingerprint message</returns>
        private string BK_FPIdentify()
        {
            int iIdentifiedUserLen = 40;
            StringBuilder sbIdentifiedUser = new StringBuilder(iIdentifiedUserLen);
            _ResultCode = FPAuthenDlg(_dllPlugin.library, EMPTY_AUTHEN_ID, AUTHEN_FINGERS, 0, sbIdentifiedUser, ref iIdentifiedUserLen);
            if (_ResultCode != SUCCESSED)
            {
                ProcErr(ProcID.FPIdentify, false);
                throw new TrustLinkGeneralException();
            }
            else
            {
                return sbIdentifiedUser.ToString();
            }
        }

        /// <summary>
        /// Delete user by TrustLink Server
        /// </summary>
        /// <param name="aUserID">Will be delete userID</param>
        private void BK_DeleteUserFun(string aUserID)
        {
            _ResultCode = DeleteUserByPwd(_dllPlugin.library, aUserID, _AuthenID, _AuthenPwd);
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
                // return 0;
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
                //return 0;
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
        //    FPUserIdentify(var aIdetifyUser: string): integer;
        //Parameter description:
        //  aIdetifyUser: Idetified User ID.
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
        /// <param name="aIdetifyUser">Vindicate success, the user will be return</param>
        /// <returns>0=success,else=error code</returns>
        public int FPUserIdentify(ref string aIdetifyUser)
        {
            try
            {
                BK_CheckXSDevHandle(); //Check Device Handle
                BK_Connectservers(); //Connect TrustLink Server
                aIdetifyUser = BK_FPIdentify(); //Vindicate fingerprint
                return _ResultCode;
                //return 0;
            }
            catch (TrustLinkGeneralException)
            {
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
                //return 0;
            }
            catch (TrustLinkGeneralException)
            {
                return _LastErrCode;
            }
        }
        #endregion
    }
}
