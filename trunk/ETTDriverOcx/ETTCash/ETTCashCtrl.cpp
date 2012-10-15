// ETTCashCtrl.cpp : CETTCashCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTCash.h"
#include "ETTCashCtrl.h"
#include "ETTCashPropPage.h"

#include <comutil.h>
#include "windows.h"
#pragma comment(lib,"comsuppw.lib")


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTCashCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTCashCtrl,   COleControl   ) 
	INTERFACE_PART(CETTCashCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTCashCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTCashCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTCashCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 
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
CETTCashCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 

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
CETTCashCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTCashCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTCashCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTCashCtrl, "HasAcceptMoney", dispidHasAcceptMoney, m_HasAcceptMoney, OnHasAcceptMoneyChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTCashCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTCashCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "InitCashCode", dispidInitCashCode, InitCashCode, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCtrl, "InitCashCodeV2", dispidInitCashCodeV2, InitCashCodeV2, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCtrl, "IdentifyExV2", dispidIdentifyExV2, IdentifyExV2, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCtrl, "CloseCashCode", dispidCloseCashCode, CloseCashCode, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "GetDeviceStatusEx", dispidGetDeviceStatusEx, GetDeviceStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "StopIdentifyEx", dispidStopIdentifyEx, StopIdentifyEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "ResetEx", dispidResetEx, ResetEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "StartIdentifyV2Ex2", dispidStartIdentifyV2Ex2, StartIdentifyV2Ex2, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTCashCtrl, "StartIdentifyV2Ex", dispidStartIdentifyV2Ex, StartIdentifyV2Ex, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTCashCtrl, "InitCreditcard", dispidInitCreditcard, InitCreditcard, VT_I2, VTS_BSTR VTS_I4 VTS_BSTR)
	DISP_FUNCTION_ID(CETTCashCtrl, "GetCreditcard", dispidGetCreditcard, GetCreditcard, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "EndCreditcard", dispidEndCreditcard, EndCreditcard, VT_I2, VTS_NONE)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTCashCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTCashCtrl, 1)
	PROPPAGEID(CETTCashPropPage::guid)
END_PROPPAGEIDS(CETTCashCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTCashCtrl, "ETTCASH.ETTCashCtrl.1",
	0xec8bc46b, 0x405, 0x47ca, 0xb5, 0x23, 0x3c, 0x40, 0x9f, 0xce, 0x78, 0xe2)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTCashCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTCash =
		{ 0xE7830902, 0xFE6B, 0x4AC0, { 0x8E, 0x15, 0xE9, 0x71, 0x2F, 0x29, 0x97, 0xF4 } };
const IID BASED_CODE IID_DETTCashEvents =
		{ 0x1A65DFCC, 0x6BD4, 0x4493, { 0x8F, 0x77, 0x6B, 0x6D, 0x6F, 0x44, 0x39, 0x28 } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTCashOleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTCashCtrl, IDS_ETTCASH, _dwETTCashOleMisc)



// CETTCashCtrl::CETTCashCtrlFactory::UpdateRegistry -
// 添加或移除 CETTCashCtrl 的系统注册表项

BOOL CETTCashCtrl::CETTCashCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTCASH,
			IDB_ETTCASH,
			afxRegApartmentThreading,
			_dwETTCashOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTCashCtrl::CETTCashCtrl - 构造函数

CETTCashCtrl::CETTCashCtrl()
{
	InitializeIIDs(&IID_DETTCash, &IID_DETTCashEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTCashCtrl::~CETTCashCtrl - 析构函数

CETTCashCtrl::~CETTCashCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTCashCtrl::OnDraw - 绘图函数

void CETTCashCtrl::OnDraw(
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



// CETTCashCtrl::DoPropExchange - 持久性支持

void CETTCashCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTCashCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTCashCtrl::GetControlFlags()
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



// CETTCashCtrl::OnResetState - 将控件重置为默认状态

void CETTCashCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTCashCtrl 消息处理程序

void CETTCashCtrl::OnHasAcceptMoneyChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTCashCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTCashCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	if(DLLInstPrint==NULL)
	{

		// AfxMessageBox("加载动态库BillValidator.dll！");
		DLLInstPrint=LoadLibrary("BillValidator.dll");
	}
	else
	{
		// AfxMessageBox("已经存在动态库BillValidator.dll！");
	}

	//AfxMessageBox("LoadLibrary -sdtapi.dll 成功！");
	//AfxMessageBox("LoadLibrary -WltRS.dll 成功！");
	if(DLLInstPrint!=NULL)
	{
		//AfxMessageBox("从动态库中获取函数！");
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		StartIdentify=(int(__stdcall *)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message))GetProcAddress(DLLInstPrint,"StartIdentify");

		StartIdentifyV2=(int(__stdcall *)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message))GetProcAddress(DLLInstPrint,"StartIdentifyV2");

		StopIdentify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"StopIdentify");
		Identify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Identify");

		IdentifyV2=(int(__stdcall *)(int,char* Message))GetProcAddress(DLLInstPrint,"IdentifyV2");

		Reset=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Reset");
		this->m_Message="成功";


	}
	else
	{
		this->m_Message="失败";
		AfxMessageBox("加载动态库BillValidator.dll失败！");

		exit(0);
	}



	return 0;
}

SHORT CETTCashCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(DLLInstPrint!=NULL)
	{
		//AfxMessageBox("释放DLL！");
		FreeLibrary(DLLInstPrint);
		DLLInstPrint=NULL;
		this->m_Message="成功";
	}
	else
	{
		this->m_Message="失败";
	}

	return 0;
}

SHORT CETTCashCtrl::InitCashCode(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码

	return 0;
}

SHORT CETTCashCtrl::InitCashCodeV2(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	int ret=-1;
	try
	{


		this->LoadDll();
		//AfxMessageBox("开始执行InitCashCodeV2");
		//Sleep(1000);
		CString tmp;

		char msg[255];
		//AfxMessageBox("准备打开纸币端口2");

		ret=OpenDevice(port,msg);
		//ret=OpenDevice(2,msg);
		//Sleep(100);
		//tmp.Format(_T("打开设备端口%d结果%d"),2,ret);
		//AfxMessageBox(tmp);
		ret=Reset(msg);
		Sleep(100);
		//tmp.Format(_T("复位识别器%d"),ret);
		//AfxMessageBox(tmp);
		ret=StartIdentifyV2("lsh","userno","1111111",msg);
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}

	catch (...)
	{
		DWORD dw = GetLastError();
		CString str;
		str.Format("GetLastError = %u",dw);
		AfxMessageBox(str);

	}

	return ret;
}

SHORT CETTCashCtrl::IdentifyExV2(SHORT maxmoney)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	CString tmp;

	char msg[255];
	int ret=-1;
	ret=IdentifyV2(maxmoney,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);


	return ret;
}

SHORT CETTCashCtrl::CloseCashCode(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString tmp;

	char msg[255];
	int ret=-1;

	ret=StopIdentify(msg);
	//tmp.Format(_T("停止识币%d"),ret);
	//AfxMessageBox(tmp);
	if(ret==0)
	{
		ret=CloseDevice(msg);
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}
	else
	{
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}
	return ret;
}

SHORT CETTCashCtrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=OpenDevice(port,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CloseDevice(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::GetDeviceStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=GetDeviceStatus(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::StopIdentifyEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StopIdentify(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::ResetEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=Reset(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::StartIdentifyV2Ex2(LPCTSTR denominations)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StartIdentifyV2("","",denominations,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::StartIdentifyV2Ex(LPCTSTR denominations)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StartIdentifyV2("","",denominations,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::InitCreditcard(LPCTSTR sfzmhm, LONG money, LPCTSTR bz)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	int ret=1;
	this->m_Message="初始化刷卡成功";
	return ret;
}

SHORT CETTCashCtrl::GetCreditcard(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	int ret=1;
	this->m_Message="完成刷卡动作";
	return ret;
}

SHORT CETTCashCtrl::EndCreditcard(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	int ret=1;
	this->m_Message="结束刷卡成功";
	return ret;
}
