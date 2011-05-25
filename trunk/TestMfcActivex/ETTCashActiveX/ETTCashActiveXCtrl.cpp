// ETTCashActiveXCtrl.cpp : CETTCashActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTCashActiveX.h"
#include "ETTCashActiveXCtrl.h"
#include "ETTCashActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTCashActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTCashActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTCashActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTCashActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTCashActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTCashActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 
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
CETTCashActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 

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
CETTCashActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTCashActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTCashActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTCashActiveXCtrl, "LoadCashDll", dispidLoadCashDll, LoadCashDll, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashActiveXCtrl, "DestoryDll", dispidDestoryDll, DestoryDll, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashActiveXCtrl, "AcceptMoney", dispidAcceptMoney, AcceptMoney, VT_EMPTY, VTS_I2)
	DISP_FUNCTION_ID(CETTCashActiveXCtrl, "TestMethod", dispidTestMethod, TestMethod, VT_EMPTY, VTS_NONE)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTCashActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTCashActiveXCtrl, 1)
	PROPPAGEID(CETTCashActiveXPropPage::guid)
END_PROPPAGEIDS(CETTCashActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTCashActiveXCtrl, "ETTCASHACTIVEX.ETTCashActiveXCtrl.1",
	0x52857b7e, 0x9aeb, 0x4273, 0xb6, 0x57, 0x46, 0x41, 0xf5, 0x4d, 0xb1, 0x79)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTCashActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTCashActiveX =
		{ 0x9DF7813F, 0x13B1, 0x4CFC, { 0xB0, 0xD1, 0x51, 0x89, 0x40, 0x95, 0xE6, 0x2D } };
const IID BASED_CODE IID_DETTCashActiveXEvents =
		{ 0xD026003A, 0x10F7, 0x44DF, { 0xA3, 0x1D, 0xA9, 0x3A, 0x64, 0xA7, 0xA7, 0x3F } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTCashActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTCashActiveXCtrl, IDS_ETTCASHACTIVEX, _dwETTCashActiveXOleMisc)



// CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CETTCashActiveXCtrl 的系统注册表项

BOOL CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTCASHACTIVEX,
			IDB_ETTCASHACTIVEX,
			afxRegApartmentThreading,
			_dwETTCashActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// 授权字符串

static const TCHAR BASED_CODE _szLicFileName[] = _T("ETTCashActiveX.lic");

static const WCHAR BASED_CODE _szLicString[] =
	L"Copyright (c) 2011 ";



// CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::VerifyUserLicense -
// 检查是否存在用户许可证

BOOL CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::VerifyUserLicense()
{
	return AfxVerifyLicFile(AfxGetInstanceHandle(), _szLicFileName,
		_szLicString);
}



// CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::GetLicenseKey -
// 返回运行时授权密钥

BOOL CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::GetLicenseKey(DWORD dwReserved,
	BSTR FAR* pbstrKey)
{
	if (pbstrKey == NULL)
		return FALSE;

	*pbstrKey = SysAllocString(_szLicString);
	return (*pbstrKey != NULL);
}



// CETTCashActiveXCtrl::CETTCashActiveXCtrl - 构造函数

CETTCashActiveXCtrl::CETTCashActiveXCtrl()
{
	InitializeIIDs(&IID_DETTCashActiveX, &IID_DETTCashActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTCashActiveXCtrl::~CETTCashActiveXCtrl - 析构函数

CETTCashActiveXCtrl::~CETTCashActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTCashActiveXCtrl::OnDraw - 绘图函数

void CETTCashActiveXCtrl::OnDraw(
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



// CETTCashActiveXCtrl::DoPropExchange - 持久性支持

void CETTCashActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTCashActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTCashActiveXCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// 在活动和不活动状态之间进行转换时，
	// 不会重新绘制控件。
	dwFlags |= noFlickerActivate;

	// 控件通过不还原设备上下文中的
	// 原始 GDI 对象，可以优化它的 OnDraw 方法。
	dwFlags |= canOptimizeDraw;
	return dwFlags;
}



// CETTCashActiveXCtrl::OnResetState - 将控件重置为默认状态

void CETTCashActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTCashActiveXCtrl 消息处理程序

void CETTCashActiveXCtrl::LoadCashDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	DLLInstPrint=LoadLibrary("BillValidator.dll");
	//AfxMessageBox("LoadLibrary -sdtapi.dll 成功！");
	//AfxMessageBox("LoadLibrary -WltRS.dll 成功！");
	if(DLLInstPrint!=NULL)
	{
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		StartIdentify=(int(__stdcall *)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message))GetProcAddress(DLLInstPrint,"StartIdentify");
		StopIdentify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"StopIdentify");
		Identify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Identify");
		Reset=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Reset");
	
	}
	else
	{
		AfxMessageBox("加载动态库BillValidator.dll失败！");
		exit(0);
	}

	// TODO: 在此添加调度处理程序代码
}

void CETTCashActiveXCtrl::DestoryDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	if(DLLInstPrint!=NULL)
		FreeLibrary(DLLInstPrint);

	// TODO: 在此添加调度处理程序代码
}

void CETTCashActiveXCtrl::AcceptMoney(SHORT money)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	AfxMessageBox("开始加载DLL");
	this->LoadCashDll();
	/*
	OpenDevice;
	Reset;
	StartIdentify;
	while ()
	{
		Identify;
		if (投币结束 && 可以退出)
			break;
	}
	StopIdentify;
	CloseDevice;
	*/
	AfxMessageBox("开始执行AcceptMoney");
	CString tmp;

	char msg[255];
	int ret=-1;
	ret=OpenDevice(2,msg);
	tmp.Format(_T("打开设备端口%d结果%d"),2,ret);
	AfxMessageBox(tmp);
	ret=Reset(msg);
	tmp.Format(_T("复位识别器%d"),ret);
	AfxMessageBox(tmp);
	ret=StartIdentify("lsh","userno","1111111",msg);
	tmp.Format(_T("开始投币%d"),ret);
	AfxMessageBox(tmp);
	int all=0;
	while(true)
	{
       ret=Identify(msg);
	   //tmp.Format(_T("已经收了多少钱%d"),ret);
	  // AfxMessageBox(tmp);
	   all=all+ret;
	   if(all==money)
	   {
		   AfxMessageBox("已经收足额的钱！");
		   break;
	   }
	}

	ret=StopIdentify(msg);
	tmp.Format(_T("停止识币%d"),ret);
	AfxMessageBox(tmp);
   
	ret=CloseDevice(msg);
	tmp.Format(_T("关闭设备%d"),ret);
	AfxMessageBox(tmp);

     
	this->DestoryDll();

	// TODO: 在此添加调度处理程序代码
}

void CETTCashActiveXCtrl::TestMethod(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	AfxMessageBox("执行测试方法！");
}
