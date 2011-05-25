// ETTTTReaderActiveXCtrl.cpp : CETTTTReaderActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTTTReaderActiveX.h"
#include "ETTTTReaderActiveXCtrl.h"
#include "ETTTTReaderActiveXPropPage.h"
#include <comutil.h>
#include "windows.h"

#pragma comment(lib,"comsuppw.lib")


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTTTReaderActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTTTReaderActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTTTReaderActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTTTReaderActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTTTReaderActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTTTReaderActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTTTReaderActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTTTReaderActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTTTReaderActiveXCtrl,   ObjSafe) 
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
CETTTTReaderActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTTTReaderActiveXCtrl,   ObjSafe) 

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
CETTTTReaderActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTTTReaderActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTTTReaderActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTTTReaderActiveXCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTTTReaderActiveXCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "DisableEntryEx", dispidDisableEntryEx, DisableEntryEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "CaptureCardEx", dispidCaptureCardEx, CaptureCardEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "EjectCardEx", dispidEjectCardEx, EjectCardEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "EnableEntryEx", dispidEnableEntryEx, EnableEntryEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "GetDeviceStatusEx", dispidGetDeviceStatusEx, GetDeviceStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTTTReaderActiveXCtrl, "ReadTracksEx", dispidReadTracksEx, ReadTracksEx, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTTTReaderActiveXCtrl, "Track1", dispidTrack1, m_Track1, OnTrack1Changed, VT_BSTR)
	
	DISP_PROPERTY_NOTIFY_ID(CETTTTReaderActiveXCtrl, "Track3", dispidTrack3, m_Track3, OnTrack3Changed, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTTTReaderActiveXCtrl, "Track2", dispidTrack2, m_Track2, OnTrack2Changed, VT_BSTR)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTTTReaderActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTTTReaderActiveXCtrl, 1)
	PROPPAGEID(CETTTTReaderActiveXPropPage::guid)
END_PROPPAGEIDS(CETTTTReaderActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTTTReaderActiveXCtrl, "ETTTTREADERACTIV.ETTTTReaderActivCtrl.1",
	0x959b27cc, 0x94e2, 0x416e, 0x96, 0x35, 0xc7, 0x1b, 0x76, 0xb0, 0xa1, 0x3e)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTTTReaderActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTTTReaderActiveX =
		{ 0x1E9465C2, 0x56F8, 0x444B, { 0x80, 0x77, 0x78, 0x3C, 0x42, 0x61, 0x47, 0xB7 } };
const IID BASED_CODE IID_DETTTTReaderActiveXEvents =
		{ 0x865397F5, 0x6B68, 0x4F40, { 0x9F, 0xE6, 0xCD, 0xB5, 0xF0, 0x6D, 0xB5, 0x15 } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTTTReaderActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTTTReaderActiveXCtrl, IDS_ETTTTREADERACTIVEX, _dwETTTTReaderActiveXOleMisc)



// CETTTTReaderActiveXCtrl::CETTTTReaderActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CETTTTReaderActiveXCtrl 的系统注册表项

BOOL CETTTTReaderActiveXCtrl::CETTTTReaderActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTTTREADERACTIVEX,
			IDB_ETTTTREADERACTIVEX,
			afxRegApartmentThreading,
			_dwETTTTReaderActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTTTReaderActiveXCtrl::CETTTTReaderActiveXCtrl - 构造函数

CETTTTReaderActiveXCtrl::CETTTTReaderActiveXCtrl()
{
	InitializeIIDs(&IID_DETTTTReaderActiveX, &IID_DETTTTReaderActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTTTReaderActiveXCtrl::~CETTTTReaderActiveXCtrl - 析构函数

CETTTTReaderActiveXCtrl::~CETTTTReaderActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTTTReaderActiveXCtrl::OnDraw - 绘图函数

void CETTTTReaderActiveXCtrl::OnDraw(
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



// CETTTTReaderActiveXCtrl::DoPropExchange - 持久性支持

void CETTTTReaderActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTTTReaderActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTTTReaderActiveXCtrl::GetControlFlags()
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



// CETTTTReaderActiveXCtrl::OnResetState - 将控件重置为默认状态

void CETTTTReaderActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTTTReaderActiveXCtrl 消息处理程序

void CETTTTReaderActiveXCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTTTReaderActiveXCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
 // AfxMessageBox("准备加载TTCardReaderV2！");
   DLLInst=LoadLibrary("TTCardReaderV2.dll");
	//DLLInst=LoadLibrary("TTReadCard.dll");
	//AfxMessageBox("加载完成TTCardReaderV2！");
	if(DLLInst!=NULL)
	{
		//AfxMessageBox("开始加载TTCardReaderV2中的函数！");
		EjectCard=(int(__stdcall *)(char* msg))GetProcAddress(DLLInst,"EjectCard");
		ReadTracks=(int(__stdcall *)(char* track1,char* track2,char* track3,char* msg))GetProcAddress(DLLInst,"ReadTracks");
		CaptureCard=(int(__stdcall *)(char* msg))GetProcAddress(DLLInst,"CaptureCard");
		DisableEntry=(int(__stdcall *)(char* msg))GetProcAddress(DLLInst,"DisableEntry");
		EnableEntry=(int(__stdcall *)(char* msg))GetProcAddress(DLLInst,"EnableEntry");

		GetDeviceStatus=(int(__stdcall *)(char* msg))GetProcAddress(DLLInst,"GetDeviceStatus");
		CloseDevice=(int(__stdcall *)(char* msg))GetProcAddress(DLLInst,"CloseDevice");

		OpenDevice=(int(__stdcall *)(int port,char* msg))GetProcAddress(DLLInst,"OpenDevice");
		//AfxMessageBox("加载完成TTCardReaderV2中的函数！");

	}
	else
	{
		AfxMessageBox("加载动态库TTCardReaderV2.dll失败！");
		exit(0);
	}
	

	return 0;
}

SHORT CETTTTReaderActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	if(DLLInst!=NULL)
	{
		FreeLibrary(DLLInst);
		DLLInst=NULL;
	}

	return 0;
}

SHORT CETTTTReaderActiveXCtrl::DisableEntryEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=DisableEntry(msg);

	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTTTReaderActiveXCtrl::CaptureCardEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CaptureCard(msg);

	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTTTReaderActiveXCtrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	
	char msg[255];
	int ret=-1;
	ret=OpenDevice(port,msg);

	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;

	//return 0;
}

SHORT CETTTTReaderActiveXCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CloseDevice(msg);

	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTTTReaderActiveXCtrl::EjectCardEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=EjectCard(msg);

	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTTTReaderActiveXCtrl::EnableEntryEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=EnableEntry(msg);

	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTTTReaderActiveXCtrl::GetDeviceStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=GetDeviceStatus(msg);

	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTTTReaderActiveXCtrl::ReadTracksEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	char track1[255];
	memset(track1,0,sizeof(track1));
	char track2[255];
	memset(track2,0,sizeof(track2));
	char track3[255];
	memset(track3,0,sizeof(track3));
	int ret=-1;
	//AfxMessageBox("开始调用DLL的ReadTracks函数");
	ret=ReadTracks(track1,track2,track3,msg);
//AfxMessageBox("结束调用DLL的ReadTracks函数");
	this->m_Message=_com_util::ConvertStringToBSTR(msg);
	this->m_Track1=_com_util::ConvertStringToBSTR(track1);
	this->m_Track2=_com_util::ConvertStringToBSTR(track2);
	this->m_Track3=_com_util::ConvertStringToBSTR(track3);

	return ret;
}

void CETTTTReaderActiveXCtrl::OnTrack1Changed(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}



void CETTTTReaderActiveXCtrl::OnTrack3Changed(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTTTReaderActiveXCtrl::OnTrack2Changed(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}
