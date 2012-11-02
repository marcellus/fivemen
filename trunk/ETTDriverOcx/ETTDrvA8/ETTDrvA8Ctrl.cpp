// ETTDrvA8Ctrl.cpp : CETTDrvA8Ctrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTDrvA8.h"
#include "ETTDrvA8Ctrl.h"
#include "ETTDrvA8PropPage.h"
#include "LoadMyLibrary.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTDrvA8Ctrl, COleControl)
BEGIN_INTERFACE_MAP(   CETTDrvA8Ctrl,   COleControl   ) 
	INTERFACE_PART(CETTDrvA8Ctrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTDrvA8Ctrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTDrvA8Ctrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTDrvA8Ctrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTDrvA8Ctrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTDrvA8Ctrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTDrvA8Ctrl,   ObjSafe) 
		return   (HRESULT)pThis-> ExternalQueryInterface(&iid,   ppvObj); 
} 

const   DWORD   dwSupportedBits   =   
INTERFACESAFE_FOR_UNTRUSTED_CALLER   | 
INTERFACESAFE_FOR_UNTRUSTED_DATA; 
const   DWORD   dwNotSupportedBits   =   ~   dwSupportedBits; 

///////////////////////////////////////////////////////////////////////////// 
//   CStopLiteCtrl::XObjSafe::GetInterfaceSafetyOptions 
//   Allows   container   to   query   what   interfaces   are   safe   for   what.   We 're 
//   optimizing   significantly   by   ignoring   which   interface   the   caller   is 
//   asking   for. 
HRESULT   STDMETHODCALLTYPE   
CETTDrvA8Ctrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTDrvA8Ctrl,   ObjSafe) 

		HRESULT   retval   =   ResultFromScode(S_OK); 

	//   does   interface   exist? 
	IUnknown   FAR*   punkInterface; 
	retval   =   pThis-> ExternalQueryInterface(&riid,   
		(void   *   *)&punkInterface); 
	if   (retval   !=   E_NOINTERFACE)   { //   interface   exists 
		punkInterface-> Release();   //   release   it--just   checking! 
	} 

	//   we   support   both   kinds   of   safety   and   have   always   both   set, 
	//   regardless   of   interface 
	*pdwSupportedOptions   =   *pdwEnabledOptions   =   dwSupportedBits; 

	return   retval;   //   E_NOINTERFACE   if   QI   failed 
} 

///////////////////////////////////////////////////////////////////////////// 
//   CStopLiteCtrl::XObjSafe::SetInterfaceSafetyOptions 
//   Since   we 're   always   safe,   this   is   a   no-brainer--but   we   do   check   to   make 
//   sure   the   interface   requested   exists   and   that   the   options   we 're   asked   to 
//   set   exist   and   are   set   on   (we   don 't   support   unsafe   mode). 
HRESULT   STDMETHODCALLTYPE   
CETTDrvA8Ctrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTDrvA8Ctrl,   ObjSafe) 

		//   does   interface   exist? 
		IUnknown   FAR*   punkInterface; 
	pThis-> ExternalQueryInterface(&riid,   (void   *   *)&punkInterface); 
	if   (punkInterface)   { //   interface   exists 
		punkInterface-> Release();   //   release   it--just   checking! 
	} 
	else   {   //   interface   doesn 't   exist 
		return   ResultFromScode(E_NOINTERFACE); 
	} 

	//   can 't   set   bits   we   don 't   support 
	if   (dwOptionSetMask   &   dwNotSupportedBits)   {   
		return   ResultFromScode(E_FAIL); 
	} 

	//   can 't   set   bits   we   do   support   to   zero 
	dwEnabledOptions   &=   dwSupportedBits; 
	//   (we   already   know   there   are   no   extra   bits   in   mask   ) 
	if   ((dwOptionSetMask   &   dwEnabledOptions)   != 
		dwOptionSetMask)   { 
			return   ResultFromScode(E_FAIL); 
	} 

	//   don 't   need   to   change   anything   since   we 're   always   safe 
	return   ResultFromScode(S_OK); 
}



// 消息映射

BEGIN_MESSAGE_MAP(CETTDrvA8Ctrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTDrvA8Ctrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "IdCardImgFileName", dispidIdCardImgFileName, m_IdCardImgFileName, OnIdCardImgFileNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "IdCardFrontImgFileName", dispidIdCardFrontImgFileName, m_IdCardFrontImgFileName, OnIdCardFrontImgFileNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "IdCardEndImgFileName", dispidIdCardEndImgFileName, m_IdCardEndImgFileName, OnIdCardEndImgFileNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "IsReaded", dispidIsReaded, m_IsReaded, OnIsReadedChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "UserName", dispidUserName, m_UserName, OnUserNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "SexCode", dispidSexCode, m_SexCode, OnSexCodeChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "SexName", dispidSexName, m_SexName, OnSexNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "NationCode", dispidNationCode, m_NationCode, OnNationCodeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "NationName", dispidNationName, m_NationName, OnNationNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "Birth", dispidBirth, m_Birth, OnBirthChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "Address", dispidAddress, m_Address, OnAddressChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "Fzjg", dispidFzjg, m_Fzjg, OnFzjgChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "StartDate", dispidStartDate, m_StartDate, OnStartDateChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "EndDate", dispidEndDate, m_EndDate, OnEndDateChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "YxqxCode", dispidYxqxCode, m_YxqxCode, OnYxqxCodeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "YxqxName", dispidYxqxName, m_YxqxName, OnYxqxNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "IdCard", dispidIdCard, m_IdCard, OnIdCardChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "EnterCardEx", dispidEnterCardEx, EnterCardEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "EjectCardEx", dispidEjectCardEx, EjectCardEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "ReadAndScanEx", dispidReadAndScanEx, ReadAndScanEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "GetDeviceStatusEx", dispidGetDeviceStatusEx, GetDeviceStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "CalibrationEx", dispidCalibrationEx, CalibrationEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "InitNationArray", dispidInitNationArray, InitNationArray, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "GetCardStatusEx", dispidGetCardStatusEx, GetCardStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "ReadAndScanDpiEx", dispidReadAndScanDpiEx, ReadAndScanDpiEx, VT_I2, VTS_I4)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "ReadRFID", dispidReadRFID, ReadRFID, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTDrvA8Ctrl, "CompressJpg", dispidCompressJpg, m_CompressJpg, OnCompressJpgChanged, VT_I2)
	DISP_FUNCTION_ID(CETTDrvA8Ctrl, "BmpToJpeg", dispidBmpToJpeg, BmpToJpeg, VT_I2, VTS_BSTR VTS_BSTR)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTDrvA8Ctrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTDrvA8Ctrl, 1)
PROPPAGEID(CETTDrvA8PropPage::guid)
END_PROPPAGEIDS(CETTDrvA8Ctrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTDrvA8Ctrl, "ETTDRVA8.ETTDrvA8Ctrl.1",
					   0xb64a8ad1, 0xb76, 0x4d7b, 0x92, 0xa6, 0xb8, 0x85, 0x19, 0x25, 0x40, 0x91)



					   // 键入库 ID 和版本

					   IMPLEMENT_OLETYPELIB(CETTDrvA8Ctrl, _tlid, _wVerMajor, _wVerMinor)



					   // 接口 ID

					   const IID BASED_CODE IID_DETTDrvA8 =
{ 0xFC198BC9, 0x9B80, 0x49AD, { 0xBD, 0xF7, 0xB5, 0xEB, 0x38, 0xEC, 0xBC, 0xE4 } };
const IID BASED_CODE IID_DETTDrvA8Events =
{ 0xE5780630, 0xB504, 0x44BE, { 0x8B, 0x73, 0xEA, 0x3E, 0x73, 0xC1, 0xD7, 0x18 } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTDrvA8OleMisc =
OLEMISC_SETCLIENTSITEFIRST |
OLEMISC_INSIDEOUT |
OLEMISC_CANTLINKINSIDE |
OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTDrvA8Ctrl, IDS_ETTDRVA8, _dwETTDrvA8OleMisc)



// CETTDrvA8Ctrl::CETTDrvA8CtrlFactory::UpdateRegistry -
// 添加或移除 CETTDrvA8Ctrl 的系统注册表项

BOOL CETTDrvA8Ctrl::CETTDrvA8CtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: 验证您的控件是否符合单元模型线程处理规则。
	// 有关更多信息，请参考 MFC 技术说明 64。
	// 如果您的控件不符合单元模型规则，则
	// 必须修改如下代码，将第六个参数从
	// afxRegApartmentThreading 改为 0。

	if (bRegister)
		return AfxOleRegisterControlClass(
		AfxGetInstanceHandle(),
		m_clsid,
		m_lpszProgID,
		IDS_ETTDRVA8,
		IDB_ETTDRVA8,
		afxRegApartmentThreading,
		_dwETTDrvA8OleMisc,
		_tlid,
		_wVerMajor,
		_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTDrvA8Ctrl::CETTDrvA8Ctrl - 构造函数

CETTDrvA8Ctrl::CETTDrvA8Ctrl()
{
	InitializeIIDs(&IID_DETTDrvA8, &IID_DETTDrvA8Events);
	// TODO: 在此初始化控件的实例数据。
}



// CETTDrvA8Ctrl::~CETTDrvA8Ctrl - 析构函数

CETTDrvA8Ctrl::~CETTDrvA8Ctrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTDrvA8Ctrl::OnDraw - 绘图函数

void CETTDrvA8Ctrl::OnDraw(
						   CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);

	if (!IsOptimizedDraw())
	{
		// 容器不支持优化绘图。

		// TODO: 如果将任何 GDI 对象选入到设备上下文 *pdc 中，
		//		请在此处恢复先前选定的对象。
	}
}



// CETTDrvA8Ctrl::DoPropExchange - 持久性支持

void CETTDrvA8Ctrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTDrvA8Ctrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTDrvA8Ctrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// 不用创建窗口即可激活控件。
	// TODO: 编写控件的消息处理程序时，在使用
	//		m_hWnd 成员变量之前应首先检查它的值是否
	//		非 null。
	dwFlags |= windowlessActivate;

	// 控件通过不还原设备上下文中的
	// 原始 GDI 对象，可以优化它的 OnDraw 方法。
	dwFlags |= canOptimizeDraw;
	return dwFlags;
}



// CETTDrvA8Ctrl::OnResetState - 将控件重置为默认状态

void CETTDrvA8Ctrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTDrvA8Ctrl 消息处理程序

void CETTDrvA8Ctrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnIdCardImgFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnIdCardFrontImgFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnIdCardEndImgFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnIsReadedChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();


}

void CETTDrvA8Ctrl::OnUserNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnSexCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnSexNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnNationCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnNationNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnBirthChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnAddressChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnFzjgChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnStartDateChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnEndDateChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnYxqxCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnYxqxNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTDrvA8Ctrl::OnIdCardChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTDrvA8Ctrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋

	char ErrorInfo[256] = {0x00};
	
	if(!LoadMyLibrary(ErrorInfo))
	{
		return -1;
	}
	

	#pragma endregion
#pragma region 矽感
	//// TODO: 在此添加调度处理程序代码
	//// AfxMessageBox("准备加载TTCardReaderV2！");
	//SYSCAN_hDrvModule=LoadLibrary(SCANNER_DLL_NAME);
	////DLLInst=LoadLibrary("TTReadCard.dll");
	////AfxMessageBox("加载完成TTCardReaderV2！");
	//if(SYSCAN_hDrvModule!=NULL)
	//{
	//	//AfxMessageBox("开始加载TTCardReaderV2中的函数！");
	//	SYSCAN_HasScanner               = (BOOL(__stdcall *)(char*))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_HasScanner"));
	//	SYSCAN_CloseDevice				= (BOOL(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CloseDevice"));
	//	SYSCAN_GetButtonStatus          = (SC_STATUS(__stdcall *)(unsigned long *))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetButtonStatus"));
	//	SYSCAN_ResetDevice				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule, TEXT("IO_ResetDevice"));
	//	SYSCAN_GetDeviceStatus			= (SC_STATUS(__stdcall *)(SC_STATUS* status))GetProcAddress(SYSCAN_hDrvModule, TEXT("IO_GetDeviceStatus"));
	//	//	SYSCAN_SetScanMode				= (SC_STATUS(__cdecl *)(const SC_MODE* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_SetScanMode"));
	//	//	SYSCAN_GetScanMode				= (SC_STATUS(__cdecl *)(SC_MODE* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetScanMode"));
	//	//	SYSCAN_BeginScan				= (SC_STATUS(__cdecl *)(SC_MODE* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_BeginScan"));
	//	SYSCAN_CancelScan				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CancelScan"));
	//	SYSCAN_GetScanData				= (SC_STATUS(__stdcall *)(unsigned char* buffer, unsigned long length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetScanData"));
	//	SYSCAN_StartCalib				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StartCalib"));
	//	SYSCAN_CancelCalib				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CancelCalib"));
	//	//	SYSCAN_CalibrateScanner         = (SC_STATUS(__cdecl *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CalibrateScanner"));
	//	//	SYSCAN_GetLines					= (SC_STATUS(__cdecl *)(BYTE *pAreaBuf,unsigned long lines, SC_MODE * mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetLines"));

	//	//SYSCAN_BeginScan				= (SC_STATUS(__cdecl *)(SC_MODEA8* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_BeginScan"));
	//	SYSCAN_BeginScan				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_BeginScan"));

	//	//	SYSCAN_EndScan  			   = (SC_STATUS(__cdecl *)(SC_MODEA8* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_EndScan"));
	//	SYSCAN_EndScan  			   = (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_EndScan"));	//20080304,delete parameters

	//	SYSCAN_StartMotor				= (SC_STATUS(__stdcall *)(unsigned long speed))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StartMotor"));
	//	SYSCAN_StopMotor               = (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StopMotor"));

	//	/////////////////////////////////////////////////////////////////////////////////////

	//	SYSCAN_ConfiscateCard =(SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_ConfiscateCard"));
	//	SYSCAN_EjectCard =(SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_EjectCard"));
	//	SYSCAN_GetSensorStatus=(SC_STATUS(__stdcall *)(SC_STATUS* status))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetSensorStatus"));
	//	SYSCAN_GetCardStatus=(SC_STATUS(__stdcall *)(SC_STATUS* status))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetCardStatus"));
	//	SYSCAN_StartSuckCard = (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StartSuckCard"));
	//	SYSCAN_CancelSuckCard = (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CancelSuckCard"));

	//	SYSCAN_SetScanModeA8 = (SC_STATUS(__stdcall *)(const SC_MODEA8* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_SetScanModeA8"));
	//	SYSCAN_GetScanModeA8 = (SC_STATUS(__stdcall *)(SC_MODEA8* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetScanModeA8"));

	//	SYSCAN_GetScanDataLength=(SC_STATUS (__stdcall *)(unsigned long * status))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetScanDataLength"));
	//	SYSCAN_GetImageBlockA8 = (short(__stdcall *)(VOID * pAreaBuf1, VOID * pAreaBuf2,short line,unsigned long index,unsigned short *usOverFlag))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetImageBlockA8"));

	//	//Add by chengxiang,20080304
	//	SYSCAN_GetChipID=(SC_STATUS(__stdcall *)(UINT * pChipID))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetChipID"));
	//	SYSCAN_Beep=(SC_STATUS(__stdcall *)(int time))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_Beep"));
	//	SYSCAN_GetVersion=(SC_STATUS(__stdcall *)(char * version))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetVersion"));
	//	//End add

	//	SYSCAN_GetMagcardDataLength = (SC_STATUS(__stdcall *)(unsigned long track, unsigned long * length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetMagcardDataLength"));
	//	SYSCAN_GetMagcardData = (SC_STATUS(__stdcall *)(unsigned long track, unsigned char* buffer, unsigned long* length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetMagcardData"));

	//	SYSCAN_GetMagcardRawDataLength = (SC_STATUS(__stdcall *)(unsigned long track, unsigned long * length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetMagcardRawDataLength"));
	//	SYSCAN_GetMagcardRawData = (SC_STATUS(__stdcall *)(unsigned long track, unsigned char* buffer, unsigned long* length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetMagcardRawData"));

	//	SYSCAN_GetCalibData		=	(SC_STATUS(__stdcall *)(SC_CALIBDATA *))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetCalibData"));
	//	SYSCAN_GetDeviceError	=	(SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetDeviceError"));	
	//	SYSCAN_GetImgFromUnit   =   (SC_STATUS(__stdcall *)(unsigned long lDpi,
	//		const char *pImgPath1,unsigned long *lImgW1,unsigned long *lImgH1,
	//		const char *pImgPath2,unsigned long *lImgW2,unsigned long *lImgH2))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetImgFromUnit"));
	//	SYSCAN_GetColorImgFromUnit   =   (SC_STATUS(__stdcall *)(unsigned long lDpi,
	//		const char *pImgPath1,unsigned long *lImgW1,unsigned long *lImgH1,
	//		const char *pImgPath2,unsigned long *lImgW2,unsigned long *lImgH2))GetProcAddress(SYSCAN_hDrvModule,TEXT("SYSCAN_GetColorImgFromUnit"));

	//	SYSCAN_GetHeadFromImage =   (SC_STATUS(__stdcall *)(const char *pImgPath1,const char *pImgPath2,const char *pImgHeadPath))
	//		GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetHeadFromImage"));

	//	//add for rfid
	//	SYSCAN_StopRFID                = (long(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StopRFID"));
	//	SYSCAN_StartRFID               = (long(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StartRFID"));
	//	SYSCAN_HaltCard				   = (long(__stdcall *)(const SC_RFID* param))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_HaltCard"));
	//	SYSCAN_RequestCard			   = (long(__stdcall *)(unsigned long* type))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_RequestCard"));
	//	SYSCAN_ReadCard	               = (long(__stdcall *)(const SC_RFID* param, unsigned char* buffer, unsigned long* length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_ReadCard"));
	//	SYSCAN_ReadRFIDInfo			   = (long(__stdcall *)(id_Card *pIdCard))GetProcAddress(SYSCAN_hDrvModule,"IO_ReadRFIDInfo");
	//	//add for rfid end

	//	SYSCAN_CalibBmpFile		=	(void(__stdcall *)(char *pFilePath))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CalibBmpFile"));
	//	SYSCAN_BmpToJpeg		=	(int (__stdcall *)(char *srcFileName,char *dstFileName))GetProcAddress(SYSCAN_hDrvModule,"BmpToJpeg");
	//	SYSCAN_Dpi600To300		=   (BOOL (__stdcall *)(BYTE *srcbuf,BYTE *dstbuf,int width,int height,BYTE imgMode))GetProcAddress(SYSCAN_hDrvModule,"Dpi600To300");
	//	SYSCAN_SetCalibdata=(int (__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,"IO_SetCalibdata");

	//	//AfxMessageBox("加载完成TTCardReaderV2中的函数！");

	//}
	//else
	//{
	//	AfxMessageBox("加载动态库A8.dll失败！");
	//	exit(0);
	//}

#pragma endregion

	return 0;
}

SHORT CETTDrvA8Ctrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋
int		                    SuccessFlag = -1; 
	SuccessFlag = OpenConnection(SecDeviceNum);
	//SuccessFlag = OpenConnInPath(SecDeviceNum,NULL);
	if(IDDIGITALCOPIER_NO_ERROR != SuccessFlag)
	{
		this->m_Message= "启动扫描失败";
		return -1;	
	}
	return 0;

	#pragma endregion


#pragma region 是否授权
	/*
	HMODULE regLib = LoadLibrary("ETTUtils.dll");

	int (WINAPI *Util_GetMachineKey )(char *strKey);
	BOOL (WINAPI *Util_ValidateReg )(char *strKey);
	Util_GetMachineKey=(int(WINAPI*)(char *msg))GetProcAddress(regLib,TEXT("GetMachineKey"));

	Util_ValidateReg=(int(WINAPI*)(char *msg))GetProcAddress(regLib,TEXT("ValidateReg"));
	if(!Util_ValidateReg("ETTSelfA8ActiveX"))
	{
		FreeLibrary(regLib);
		AfxMessageBox("该控件未授权！");
		return -1;
	}
	else
	{
		FreeLibrary(regLib);
		//return 0;
	}
/**/
#pragma endregion
#pragma region 矽感
	/*
	if (SYSCAN_HasScanner(SCANNER_NAME))
	{
		CString dispinfo;
		dispinfo.Format("open device ok");
		//GetDlgItem(IDC_STATIC_STATUS)->SetWindowText(dispinfo);		
		scan_running = true;

		//GetDlgItem(IDC_OPEN_DEV) ->EnableWindow(false);
		modeA8.mode_d = 7;		//
		modeA8.mode_d_r	= 7;
		modeA8.mode_u = 7;
		modeA8.mode_u_r	= 7 ;
		modeA8.auto_reverse	= 0 ;
		SYSCAN_SetScanModeA8(&modeA8);
		this->m_Message="成功";
		return 0;

	}
	else
	{
		//CString dispinfo;
		//dispinfo.Format("open device fail");
		//GetDlgItem(IDC_STATIC_STATUS)->SetWindowText(dispinfo);
		this->m_Message="失败";
		return -1;
		//OnBtnClose();
	}
	//bRFIDEnable = FALSE;
	CalibrationEx();
	*/
#pragma endregion

	return 0;
}


SHORT CETTDrvA8Ctrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	#pragma region 新北洋

	CloseConnection(SecDeviceNum);

	#pragma endregion

#pragma region 矽感
	/*
	// TODO: 在此添加调度处理程序代码
	if (scan_running)
	{	
		SYSCAN_CloseDevice();
		scan_running = false;
	}   
	SYSCAN_CloseDevice();
	*/
#pragma endregion

	return 0;
}

SHORT CETTDrvA8Ctrl::EnterCardEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋
    
	#pragma endregion
#pragma region 矽感
	/*
	long lRet = 0;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       llllllllllllllllkjjiooooooooooooooooooooooooooooooooooooooooooo[hj                                                                                                                                                                                                                                                                                               hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhihjooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooot	`1``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````();
	if(lRet==SCS_OK)
	{
		this->m_Message="成功";
		return 0;
	}
	this->m_Message="失败";
	*/
#pragma endregion

	return -1;
}

SHORT CETTDrvA8Ctrl::EjectCardEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋
    //DirectFeedIdCard(SecDeviceNum);
	 EjectIdCard(SecDeviceNum);
	#pragma endregion
#pragma region 矽感
	/*
	unsigned long status =  SYSCAN_EjectCard();
	if(status==SCS_OK)
	{

		this->m_Message="成功";
		SYSCAN_CancelSuckCard();
		return 0;
	}
	this->m_Message="失败";
	*/
#pragma endregion

	return -1;
}

SHORT CETTDrvA8Ctrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋
if(!UnloadMyLibrary())
{
	return -1;
}

	#pragma endregion
#pragma region 矽感
	/*
	if(SYSCAN_hDrvModule!=NULL)
	{
		FreeLibrary(SYSCAN_hDrvModule);
		SYSCAN_hDrvModule=NULL;
	}
	*/
	/*
	if(DLLInst2!=NULL)
	{
	FreeLibrary(DLLInst2);
	DLLInst2=NULL;
	}
	if(DLLInst3!=NULL)
	{
	FreeLibrary(DLLInst3);
	DLLInst3=NULL;
	}
	*/
#pragma endregion

	return 0;
}

SHORT CETTDrvA8Ctrl::ReadAndScanEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码

	return this->ReadAndScanDpiEx(300);
}

SHORT CETTDrvA8Ctrl::GetDeviceStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋
//DEVICESTATUS    DeviceStatus = {0,0,0};  
   GetDeviceStatus(SecDeviceNum, &DeviceStatus);

	//设备所处状态
	switch(DeviceStatus.Status)
	{
	case IDDIGITALCOPIER_STATUS_IDLE:
		m_Message="空闲";
		break;
	case IDDIGITALCOPIER_STATUS_SCAN:
		m_Message="扫描";
		break;
	case IDDIGITALCOPIER_STATUS_WAIT:
		m_Message="等待";
		break;
	case IDDIGITALCOPIER_STATUS_RETIRECARD:
		m_Message="退卡";
		break;
	case IDDIGITALCOPIER_STATUS_ERROR:
		m_Message="错误";
		break;
	default :
		break;
	}
   return 0;
	#pragma endregion
#pragma region 矽感
	/*
	SC_STATUS Cstatus;                                            
	SC_STATUS DeviceStatus =  SYSCAN_GetDeviceStatus(&Cstatus);
	this->m_Message = "error";
	if(DeviceStatus == SCS_PARAM)
	{
		m_Message = MSG_SCS_PARAM;

	}
	//else if(DeviceStatus == SCS_ERROR)
	//{
	//m_Message = "SCS_ERROR";

	//}
	else if(DeviceStatus == SCS_OK)
	{
		m_Message = MSG_SCS_OK;

	}
	////////
	else if(DeviceStatus == SCS_FAIL)
	{
		m_Message = MSG_SCS_FAIL;

	}
	else if(DeviceStatus == SCS_NODATA)
	{
		m_Message = MSG_SCS_NODATA;

	}

	else if(DeviceStatus == SCS_BUSY)
	{
		m_Message = MSG_SCS_BUSY;

	}
	else if(DeviceStatus == SCS_CALIB)
	{
		m_Message = MSG_SCS_CALIB;

	}	
	else if(DeviceStatus == SCS_CLEAN)
	{
		m_Message = MSG_SCS_CLEAN;

	}
	else if(DeviceStatus == SCS_SCAN)
	{
		m_Message = MSG_SCS_SCAN;

	}	
	//else if(DeviceStatus == SCS_CARD)
	//{
	//m_Message = "SCS_CARD";

	//}
	//else if(DeviceStatus == SCS_MOTOR)
	//{
	//m_Message = "SCS_MOTOR";
	//} 



	return 0;*/

	#pragma endregion
}

SHORT CETTDrvA8Ctrl::CalibrationEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋

	#pragma endregion
#pragma region 矽感
	/*
	modeA8.mode_d = 7;		//
	modeA8.mode_d_r	= 7;
	modeA8.mode_u = 7;
	modeA8.mode_u_r	= 7 ;
	modeA8.auto_reverse	= 0 ;
	SYSCAN_SetScanModeA8(&modeA8);

	unsigned long status=1;
	memset(&CalibData,0xff,sizeof(SC_CALIBDATA));

	long retValue;
	retValue=SYSCAN_GetCalibData(&CalibData);
	CString disdata;
	if (retValue!=SCS_OK)
	{
		disdata.Format("获取校准的参数出错");
		return -2;
	}

	status=CalibData.bCalibStatus;
	if (status==0)	//未校准
	{
		disdata.Format("The device didn't calibrate till now, acquiring the data need accomplished the calibration process.");

		return -1;
	}
	else		//已校准
	{
		//write calibration data to file
		char filename[]="calibdata.txt";
		//CFile file(strFileName,CFile::modeWrite);
		disdata.Format("Get calibration parameter OK!");
		return 0;
	}
*/
#pragma endregion

	return 0;
}

SHORT CETTDrvA8Ctrl::InitNationArray(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	this->m_nationArray.Add("01", "汉族");
	this->m_nationArray.Add("02", "蒙古族");
	this->m_nationArray.Add("03", "回族");
	this->m_nationArray.Add("04", "藏族");
	this->m_nationArray.Add("05", "维吾尔族");
	this->m_nationArray.Add("06", "苗族");
	this->m_nationArray.Add("07", "彝族");
	this->m_nationArray.Add("08", "壮族");
	this->m_nationArray.Add("09", "布依族");
	this->m_nationArray.Add("10", "朝鲜族");
	this->m_nationArray.Add("11", "满族");
	this->m_nationArray.Add("12", "侗族");
	this->m_nationArray.Add("13", "瑶族");
	this->m_nationArray.Add("14", "白族");
	this->m_nationArray.Add("15", "土家族");
	this->m_nationArray.Add("16", "哈尼族");
	this->m_nationArray.Add("17", "哈萨克族");
	this->m_nationArray.Add("18", "傣族");
	this->m_nationArray.Add("19", "黎族");
	this->m_nationArray.Add("20", "傈僳族");
	this->m_nationArray.Add("21", "佤族");
	this->m_nationArray.Add("22", "畲族");
	this->m_nationArray.Add("23", "高山族");
	this->m_nationArray.Add("24", "拉祜族");
	this->m_nationArray.Add("25", "水族");
	this->m_nationArray.Add("26", "东乡族");
	this->m_nationArray.Add("27", "纳西族");
	this->m_nationArray.Add("28", "景颇族");
	this->m_nationArray.Add("29", "柯尔克孜族");
	this->m_nationArray.Add("30", "土族");
	this->m_nationArray.Add("31", "达翰尔族");
	this->m_nationArray.Add("32", "仫佬族");
	this->m_nationArray.Add("33", "羌族");
	this->m_nationArray.Add("34", "布朗族");
	this->m_nationArray.Add("35", "撒拉族");
	this->m_nationArray.Add("36", "毛南族");
	this->m_nationArray.Add("37", "仡佬族");
	this->m_nationArray.Add("38", "锡伯族");
	this->m_nationArray.Add("39", "阿昌族");
	this->m_nationArray.Add("40", "普米族");
	this->m_nationArray.Add("41", "塔吉克族");
	this->m_nationArray.Add("42", "怒族");
	this->m_nationArray.Add("43", "乌孜别克族");
	this->m_nationArray.Add("44", "俄罗斯族");
	this->m_nationArray.Add("45", "鄂温克族");
	this->m_nationArray.Add("46", "德昂族");
	this->m_nationArray.Add("47", "保安族");
	this->m_nationArray.Add("48", "裕固族");
	this->m_nationArray.Add("49", "京族");
	this->m_nationArray.Add("50", "塔塔尔族");
	this->m_nationArray.Add("51", "独龙族");
	this->m_nationArray.Add("52", "鄂伦春族");
	this->m_nationArray.Add("53", "赫哲族");
	this->m_nationArray.Add("54", "门巴族");
	this->m_nationArray.Add("55", "珞巴族");
	this->m_nationArray.Add("56", "基诺族");
	this->m_nationArray.Add("57", "其它");
	this->m_nationArray.Add("98", "外国人入籍");



	return 0;
}



SHORT CETTDrvA8Ctrl::GetCardStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋
	//DEVICESTATUS    DeviceStatus = {0,0,0};  
   GetDeviceStatus(SecDeviceNum, &DeviceStatus);

	//设备所处状态
	switch(DeviceStatus.Status)
	{
	case IDDIGITALCOPIER_STATUS_IDLE:
		m_Message="空闲";
		break;
	case IDDIGITALCOPIER_STATUS_SCAN:
		m_Message="扫描";
		break;
	case IDDIGITALCOPIER_STATUS_WAIT:
		m_Message="等待";
		break;
	case IDDIGITALCOPIER_STATUS_RETIRECARD:
		m_Message="退卡";
		break;
	case IDDIGITALCOPIER_STATUS_ERROR:
		m_Message="错误";
		break;
	default :
		break;
	}
   return 0;

	#pragma endregion

#pragma region 矽感
	/*
	// TODO: 在此添加调度处理程序代码

	SC_STATUS Cstatus;                                            
	//SC_STATUS DeviceStatus =  SYSCAN_GetCardStatus(&Cstatus);
	SYSCAN_GetCardStatus(&Cstatus);
	this->m_Message = "error";
	if(Cstatus == STATUS_CARD_F_READY )
	{
		m_Message = MSG_STATUS_CARD_F_READY;

	}else if(Cstatus == STATUS_CARD_R_READY ){
		m_Message = MSG_STATUS_CARD_R_READY;
	}else if(Cstatus == STATUS_CARD_NONE ){
		m_Message = MSG_STATUS_CARD_NONE;
	}else if(Cstatus == STATUS_CARD_F_SCANNING ){
		m_Message = MSG_STATUS_CARD_F_SCANNING;
	}else if(Cstatus == STATUS_CARD_R_SCANNING ){
		m_Message = MSG_STATUS_CARD_R_SCANNING;
	}else if(Cstatus == STATUS_CARD_DONE ){
		m_Message = MSG_STATUS_CARD_DONE;
	}else if(Cstatus == STATUS_CARD_EJECTING ){
		m_Message = MSG_STATUS_CARD_EJECTING;
	}else if(Cstatus == STATUS_CARD_CONFISCATING ){
		m_Message = MSG_STATUS_CARD_CONFISCATING;
	}else if(Cstatus == STATUS_CARD_ABORT ){

		//this->EjectCardEx();
		SYSCAN_EjectCard();
		Sleep(100);
		//SYSCAN_GetCardStatus(&Cstatus);

		m_Message = MSG_STATUS_CARD_ABORT;

	}

	else if(Cstatus==STATUS_CARD_UNKOWN){ 

		this->EnterCardEx();
		SYSCAN_SetCalibdata();
		Sleep(100);
		//SYSCAN_GetCardStatus(&Cstatus);

		m_Message = MSG_STATUS_CARD_UNKOWN;

	}

	return Cstatus;
*/

#pragma endregion

return 0;
}



SHORT CETTDrvA8Ctrl::ReadAndScanDpiEx(LONG dpi)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋
	
	int		ReturnValue = IDDIGITALCOPIER_NO_ERROR;
	bool    IsLastCard = false;
    ReturnValue = TakeIDCard(SecDeviceNum, Uni_ReclaimTimeout);
		if(ReturnValue == IDDIGITALCOPIER_PORT_ERROR)   //通讯错误
		{
			goto EXITPOINT;
		}
		else if(ReturnValue == IDDIGITALCOPIER_TIMEOUT_ERROR)  //超时时间未取走卡, 吞卡
		{
			if(Uni_ActionAfterScan == 1)
			{
				ScanIdCard(SecDeviceNum);
				FeedIdCard(SecDeviceNum);
			}
		}
		else if (ReturnValue != IDDIGITALCOPIER_NO_ERROR)  //卡未被取走，循环等待
		{
		}

		///***************************************************************************************************************
		//检测卡
		ReturnValue = CheckIdCard(SecDeviceNum, 1);           //检测1秒
		if(ReturnValue == IDDIGITALCOPIER_PORT_ERROR)         //通讯错误
		{
			goto EXITPOINT;
		}
		else if(ReturnValue == IDDIGITALCOPIER_STATUS_COVER_OPENED || ReturnValue == IDDIGITALCOPIER_STATUS_PASSAGE_JAM)  //状态错误
		{
			goto StatusError;
		}
		else if(ReturnValue == IDDIGITALCOPIER_TIMEOUT_ERROR)    //超时，继续等待
		{
			AfxMessageBox("请放入证件扫描...");
           	Sleep(200);
		}
		

		
	    ///***************************************************************************************************************
		///启动扫描前设置分辨率
		if(SetConfig(SecDeviceNum, Uni_ScanLight, Uni_ImageDPI, 80) != IDDIGITALCOPIER_NO_ERROR)
		{
			AfxMessageBox("设置图像光源和分辨率失败!");
			
		}

		///***************************************************************************************************************
		//启动扫描
		AfxMessageBox("正在证件扫描...");
		

		///***************************************************************************************************************
		//前入卡机器，首先进行识读，然后进入扫描流程
		if (true) 
		{
			if (Uni_Card_Enter[SecDeviceNum] == 0)
			{
				ReturnValue = GetID2Info(SecDeviceNum, &mIDInfo, 1, Uni_SaveNewImagePath);//识别完成后保存头像到Uni_SaveNewImagePath下
			
				if (ReturnValue == IDDIGITALCOPIER_NO_ERROR)
				{
					//isShowInfo =  true;
				}
				else
				{
					//isShowInfo = false;
					AfxMessageBox("获取信息失败!");
	             	//SendMessage((HWND)(AfxGetApp()->GetMainWnd()->GetSafeHwnd()), WM_SHOWMSG, (LPARAM)0, NULL);
				}
			}
			//前入卡时，首先显示识别信息
			//SendMessage((HWND)(AfxGetApp()->GetMainWnd()->GetSafeHwnd()), WM_SCANFLOW, (LPARAM)1, NULL);
		}

		ReturnValue = ScanIdCard(SecDeviceNum);
		
		if(ReturnValue == IDDIGITALCOPIER_STATUS_COVER_OPENED || ReturnValue == IDDIGITALCOPIER_STATUS_PASSAGE_JAM)  //状态错误
		{
			goto StatusError;
		}
		else if(ReturnValue == IDDIGITALCOPIER_PORT_ERROR)
		{
			goto EXITPOINT;
		}
		else if(ReturnValue == IDDIGITALCOPIER_START_SCAN_FAILED)   //启动扫描失败
		{
			//continue;
		}
		
		
		
		///***************************************************************************************************************
		//出卡（Uni_ActionAfterScan == 0正常出卡;Uni_ActionAfterScan == 1 超时退卡）
		if(Uni_ActionAfterScan == 0)
		{
			ReturnValue = DirectFeedIdCard(SecDeviceNum);
		}
		else 
		{
			ReturnValue = EjectIdCard(SecDeviceNum);
		}
		
		if(ReturnValue == IDDIGITALCOPIER_STATUS_COVER_OPENED || ReturnValue == IDDIGITALCOPIER_STATUS_PASSAGE_JAM)//状态错误引起退卡失败
		{
			goto StatusError;
		}
		else
		{
			AfxMessageBox("扫描完成...");
			//PostMessage((HWND)(AfxGetApp()->GetMainWnd()->GetSafeHwnd()), WM_SHOWMSG, (LPARAM)1, NULL);
		}
		//continue;		
StatusError:
		this->m_Message="状态错误，请重新扫描...";
		Sleep(2500);//延时等待状态恢复
		
EXITPOINT:	
		return -1;

	#pragma endregion
#pragma region 矽感
//	
//	// TODO: 在此添加调度处理程序代码
//
//	//AfxMessageBox("Begin Activex ReadAndScanEx Method!");
//	BOOL bScanOk = FALSE;
//	//define bitmap file
//	SC_CALIBDATA * pTempCalibData;
//	SC_CALIBDATA tempCalibData;
//	pTempCalibData=&tempCalibData;
//	*pTempCalibData=CalibData;
//	//if (MessageBox("Calibrate scan data?","scan",MB_YESNO)==IDNO)
//	//{
//	//	(SC_CALIBDATA * )memset(pTempCalibData,0,sizeof(CalibData));
//	//}
//
//	FILE*          pFile1 = NULL;
//	FILE*          pFile2 = NULL;
//	FILE*          pFile3 = NULL;
//	FILE*          pFile4 = NULL;
//	//AfxMessageBox("Begin Activex ReadAndScanEx Method2!");
//
//	DWORD dwStart;
//	const long cntlImgLinePerBlock = 8;//8;//block one change to four //Changed by liqian on 2010-11-08 for test
//	char ImgFilePath1[260],ImgFilePath2[260],ImgFilePath3[260],ImgFilePath4[260];
//	char ImgFilePath1Jpg[260],ImgFilePath2Jpg[260],ImgFilePath3Jpg[260],ImgFilePath4Jpg[260];
//	unsigned char *pBmp1=NULL,*pBmp2=NULL,*pBmp3=NULL,*pBmp4=NULL;
//
//	CString disdata;
//	CString	dispinfo;
//	//AfxMessageBox("Begin Activex ReadAndScanEx Method3!");
//
//	//m_staticinfo.SetWindowText(dispinfo);
//	long			lImgW = const_imgW;
//	long			lImgH = Const_MaxImageHeight;//const_imgH;
//	long			lImgLineScaned = 0;
//	long			lImgLineOfLastBlock = 0;
//	unsigned char*	pImgBuf = NULL;
//	int				nBytesPerLine = 0;/*image bytes per scann-line*/
//	int				nStartScanPos  = 0;
//	int				nLineBytesForward,nLineBytesReverse;
//	int				nOffsetForward,nOffsetReverse;
//	long			lImgLinePerBlock = cntlImgLinePerBlock;//block one change to four
//	SC_STATUS		status;
//	SC_STATUS Cstatus; 
//	BOOL bReadDataForwardOk=FALSE,bReadDataReverseOk=FALSE;
//	char AA[1024] = {0};
//	unsigned short mIs_ScanOver = 0;
//
//	dispinfo.Format("");
//	//AfxMessageBox("Begin Activex ReadAndScanEx Method4!");
//
//	//check device has been opened
//	if(!scan_running)
//	{
//		//AfxMessageBox("Begin Activex ReadAndScanEx Method5!");
//		//Notice();
//	}
//	//AfxMessageBox("Begin Activex ReadAndScanEx Method5!");
//	status = SYSCAN_StartSuckCard();
//	if (status != SCS_OK)
//	{
//		dispinfo.Format("Start suck card failed");
//		//AfxMessageBox(dispinfo);
//		return -1;
//	}
//	//check card status
//	/*
//	DWORD dwEnd;
//	dwStart = GetTickCount();
//	//while (1)
//	//{
//	dwEnd = GetTickCount();
//	//AfxMessageBox("Begin Activex ReadAndScanEx Method6!");
//	if (dwEnd - dwStart > 10000)
//	{
//		dispinfo.Format("Wait card timeout");
//		//AfxMessageBox(dispinfo);
//		status = SYSCAN_CancelSuckCard();
//		if (status != SCS_OK)
//		{
//			dispinfo.Format("Cancel suck card error");
//			//AfxMessageBox(dispinfo);
//		}
//		return -1;
//	}
//	*/
//	//AfxMessageBox("Begin Activex ReadAndScanEx Method7!");
//	status = SYSCAN_GetCardStatus(&Cstatus);
//	dispinfo.Format("get card Status->%d",status);
//	//AfxMessageBox(dispinfo);
//	if(status != SCS_OK)
//	{
//		dispinfo.Format("SC_COMMUNICATION_ERR");
//		//AfxMessageBox(dispinfo);
//		return -1;
//	}
//	if(Cstatus == STATUS_CARD_NONE)
//	{
//		dispinfo.Format("please insert card");
//		//AfxMessageBox(dispinfo);
//		return -1;
//	}
//	else if((Cstatus != STATUS_CARD_F_READY) && (Cstatus != STATUS_CARD_R_READY) && (Cstatus != STATUS_CARD_DONE))
//	{
//		dispinfo.Format("scanner is busy");
//		//AfxMessageBox(dispinfo);
//		return -1;
//	}
//	//else
//	//{
//	//AfxMessageBox("Begin Activex ReadAndScanEx Method8!");
//	//return -1;
//	//}
//	//}
//	//check card status complete
//	//AfxMessageBox("Begin Read RFID");
//	//Read RFID
//	id_Card acard;
//	memset(&acard,0,sizeof(acard));
//	//acard->
//	//AfxMessageBox("Begin SYSCAN_ReadRFIDInfo ");
//	status = SYSCAN_ReadRFIDInfo(&acard);
//	dispinfo.Format("SYSCAN_ReadRFIDInfo Status->%d",status);
//	//AfxMessageBox(dispinfo);
//	//AfxMessageBox("End Read RFID");
//	if (status == SCS_OK)
//	{
//		char id_Name[30] = {0};			  //姓名	  30   bytes
//		char id_Sex[4] = {0};				  //性别	  2    bytes
//		char id_National[4] = {0};		  //民族	  4    bytes
//		char id_Born[16] = {0};			  //出生	  16   bytes
//		char id_Home[70] = {0};			  //家庭	  70   bytes
//		char id_Code[36] = {0};			  //身份证号  36   bytes
//		char id_RegOrg[30] = {0};		  //机关	  30   bytes
//		char id_ValidPeriod[32] = {0};	  //有效期限  32   bytes 	 
//		char id_NewAddr[36] = {0};		  //最新地址  36   bytes
//
//
//		char	strTmp1[300];
//
//		LPSTR	lpBmpData = NULL;
//
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,acard.id_Name,15,strTmp1,300,NULL,NULL);
//
//		strcpy(id_Name, strTmp1);
//
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,&(acard.id_Sex),1,strTmp1,300,NULL,NULL);
//		if (1==atoi(strTmp1)) 
//		{
//			strcpy(id_Sex, "男");
//			this->m_SexCode=1;
//		}
//		else if (2==atoi(strTmp1))
//		{	strcpy(id_Sex, "女");
//		this->m_SexCode=2;
//		}
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,acard.id_National,2,strTmp1,300,NULL,NULL);
//		strcpy(id_National, strTmp1);
//
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,acard.id_Born,8,strTmp1,300,NULL,NULL);
//		strcpy(id_Born, strTmp1);
//
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,acard.id_Home,35,strTmp1,/*0*/300,NULL,NULL);
//		strcpy(id_Home, strTmp1);
//
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,acard.id_Code,18,strTmp1,/*0*/300,NULL,NULL);
//		strcpy(id_Code, strTmp1);
//
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,acard.id_RegOrg,15,strTmp1,/*0*/300,NULL,NULL);
//		strcpy(id_RegOrg, strTmp1);
//
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,acard.id_ValidPeriod,16,strTmp1,/*0*/300,NULL,NULL);
//		strcpy(id_ValidPeriod, strTmp1);
//
//		memset(strTmp1,0x00,300);
//		WideCharToMultiByte(0,0,acard.id_NewAddr,18,strTmp1,/*0*/300,NULL,NULL);
//		strcpy(id_NewAddr, strTmp1);
//
//
//		char str[1284];
//		memset(str,0,1284);
//		this->m_Address=_com_util::ConvertStringToBSTR(id_Home);
//		this->m_UserName=_com_util::ConvertStringToBSTR(id_Name);
//		this->m_NationCode=_com_util::ConvertStringToBSTR(id_National);
//		this->InitNationArray();
//		this->m_NationName=this->m_nationArray.Get(this->m_NationCode);
//		this->m_SexName=_com_util::ConvertStringToBSTR(id_Sex);
//		this->m_Birth=_com_util::ConvertStringToBSTR(id_Born);
//		this->m_IdCard=_com_util::ConvertStringToBSTR(id_Code);
//		this->m_Fzjg=_com_util::ConvertStringToBSTR(id_RegOrg);
//		this->m_YxqxName=_com_util::ConvertStringToBSTR(id_ValidPeriod);
//
//
//		this->bViewBmp = TRUE;
//		//AfxMessageBox("创建WLT文件开始");
//		if(! this->CreateWltFile(acard.id_pImage))//CREATE WLT FILE
//		{
//			//AfxMessageBox("create WLT file fail");
//			//AfxMessageBox("创建WLT文件失败");
//			return SCS_RDTYPE2FILEERR;
//		}
//
//
//		//LPTSTR   prefpath   =   this->m_ImgPathPreX.GetBuffer(); 
//		//   在这里添加使用p的代码 
//		//if(prefpath   !=   NULL)   
//		//*prefpath   =   _T( '\0 '); 
//		//this->m_ImgPathPreX.ReleaseBuffer();   //   使用完后及时释放，以便能使用其它的CString成员函数 
//
//
//		GetExePath(ImgFilePath1);
//		strcat(ImgFilePath1,"Picture1.bmp");
//		GetExePath(ImgFilePath2);
//		strcat(ImgFilePath2,"Picture2.bmp");
//		GetExePath(ImgFilePath1Jpg);
//		strcat(ImgFilePath1Jpg,"Picture1.jpg");
//		GetExePath(ImgFilePath2Jpg);
//		strcat(ImgFilePath2Jpg,"Picture2.jpg");
//
//
///*		GetExePath(ImgFilePath2);
//		strcat(ImgFilePath2,"Picture2.bmp");
//		
//
//		GetExePath(ImgFilePath3);
//		strcat(ImgFilePath3,"Picture3.bmp");
//		GetExePath(ImgFilePath3Jpg);
//		strcat(ImgFilePath3Jpg,"Picture3.jpg");
//
//		GetExePath(ImgFilePath4);
//		strcat(ImgFilePath4,"Picture4.bmp");
//		GetExePath(ImgFilePath4Jpg);
//		strcat(ImgFilePath4Jpg,"Picture4.jpg");
//		*/
//
//		//set bitmap filename complete
//
//		//check scan mode
//		if(modeA8.mode_u == 16)	
//		{
//			nLineBytesForward = const_imgW * 3;
//			nOffsetForward = 54;
//		}
//		else
//		{
//			nLineBytesForward = const_imgW;    
//			nOffsetForward = 1078;
//		}
//
//		if(modeA8.mode_u == 16)
//		{
//			nLineBytesReverse = const_imgW * 3;
//			nOffsetReverse = 54;
//		}
//		else
//		{
//			nLineBytesReverse = const_imgW; 
//			nOffsetReverse = 1078;
//		}
//
//		int iRet;
//		unsigned long lImgW1=600,lImgH1=400;
//		//AfxMessageBox("开始扫描");
//		iRet=SYSCAN_GetImgFromUnit(dpi,ImgFilePath1,&lImgW1,&lImgH1,ImgFilePath2,&lImgW1,&lImgH1);
//		//if (this->m_CompressJpg==1)	//判断是否要压缩成JPEG格式
//		//{
//			SYSCAN_BmpToJpeg(ImgFilePath1,ImgFilePath1Jpg);
//			SYSCAN_BmpToJpeg(ImgFilePath2,ImgFilePath2Jpg);
//			/*if (bReadDataReverseOk)
//			{
//			SYSCAN_BmpToJpeg(ImgFilePath3,ImgFilePath3Jpg);
//			SYSCAN_BmpToJpeg(ImgFilePath4,ImgFilePath4Jpg);
//			}*/
//		//}
//		//iRet=SYSCAN_GetColorImgFromUnit(dpi,ImgFilePath1,&lImgW1,&lImgH1,ImgFilePath2,&lImgW1,&lImgH1);
//		//AfxMessageBox("结束扫描");
//		if(iRet == 0)
//		{
//			SYSCAN_EjectCard();
//			//SYSCAN_ResetDevice();
//			Sleep(100);
//			//AfxMessageBox("scan success");
//			//iRet = SYSCAN_GetHeadFromImage(ImgFilePath1,ImgFilePath2,"c:\\imgHead.bmp");
//		}else {
//			SYSCAN_EjectCard();
//			SYSCAN_ResetDevice();
//			AfxMessageBox("图片扫描异常，设备已复位，请重试");
//		}
//
//		return 0;
//	}
//	
#pragma endregion

	return 0;
}

SHORT CETTDrvA8Ctrl::ReadRFID(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	return 0;
}

unsigned long CETTDrvA8Ctrl::CreateWltFile(BYTE *pBuf)
{
	char szPath[MAX_PATH];

	strcpy(szPath, "c:\\Picture.wlt");

	HANDLE hFile = INVALID_HANDLE_VALUE;
	DWORD dwBytesReturned;



	hFile = CreateFile(szPath,
		GENERIC_WRITE,
		0,
		NULL,
		CREATE_ALWAYS,
		FILE_ATTRIBUTE_NORMAL,
		NULL);

	if(hFile == INVALID_HANDLE_VALUE)
	{
		return 0;
	}

	BOOL bRes;
	bRes = WriteFile(hFile, pBuf, 1024 * sizeof( BYTE ), &dwBytesReturned, NULL);
	if (bRes)
	{
		CloseHandle( hFile );
		return 1;
	}
	else
		return 0;
}


void CETTDrvA8Ctrl::GetExePath(LPSTR tmppath)
{
	CString str;
	str = "c:\\";
	//AfxMessageBox(m_ImgPathPreX);
	//LPCTSTR buf = (LPCTSTR)this->m_ImgPathPreX; 
	LPCTSTR buf = (LPCTSTR)str; 

	int i;                       // get application directory
	lstrcpy(tmppath, buf);             
	for( i = lstrlen(tmppath); i >= 0 && tmppath[i] != '\\'; i--);
	tmppath[i+1] = '\0';
}
void CETTDrvA8Ctrl::OnCompressJpgChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTDrvA8Ctrl::BmpToJpeg(LPCTSTR src, LPCTSTR dest)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
#pragma region 新北洋

	#pragma endregion

#pragma region 矽感
	/*
    this->LoadDll();
	SYSCAN_BmpToJpeg((char*)src,(char*)dest);
	this->DestroyDll();
	*/
#pragma endregion

	return 0;
}
