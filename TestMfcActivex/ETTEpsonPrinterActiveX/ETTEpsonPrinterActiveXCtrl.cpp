// ETTEpsonPrinterActiveXCtrl.cpp : CETTEpsonPrinterActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTEpsonPrinterActiveX.h"
#include "ETTEpsonPrinterActiveXCtrl.h"
#include "ETTEpsonPrinterActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTEpsonPrinterActiveXCtrl, COleControl)


BEGIN_INTERFACE_MAP(   CETTEpsonPrinterActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTEpsonPrinterActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTEpsonPrinterActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTEpsonPrinterActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTEpsonPrinterActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 
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
CETTEpsonPrinterActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 

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
CETTEpsonPrinterActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTEpsonPrinterActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTEpsonPrinterActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "AddString", dispidAddString, AddString, VT_EMPTY, VTS_BSTR)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "RemoveAllString", dispidRemoveAllString, RemoveAllString, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "TestMethod", dispidTestMethod, TestMethod, VT_EMPTY, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTEpsonPrinterActiveXCtrl, "PrinterName", dispidPrinterName, m_PrinterName, OnPrinterNameChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "PrinterPort", dispidPrinterPort, PrinterPort, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTEpsonPrinterActiveXCtrl, "Port", dispidPort, m_Port, OnPortChanged, VT_I2)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTEpsonPrinterActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTEpsonPrinterActiveXCtrl, 1)
	PROPPAGEID(CETTEpsonPrinterActiveXPropPage::guid)
END_PROPPAGEIDS(CETTEpsonPrinterActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTEpsonPrinterActiveXCtrl, "ETTEPSONPRINTERA.ETTEpsonPrinterACtrl.1",
	0x55f3ec13, 0x28ab, 0x469e, 0x98, 0xde, 0x82, 0xe8, 0x62, 0x70, 0x3f, 0xc0)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTEpsonPrinterActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTEpsonPrinterActiveX =
		{ 0xB6C5706, 0xC674, 0x4856, { 0xA3, 0x42, 0x84, 0x5A, 0x5E, 0x1F, 0xE5, 0x5A } };
const IID BASED_CODE IID_DETTEpsonPrinterActiveXEvents =
		{ 0x7BD881A4, 0x9BCF, 0x4F89, { 0x8B, 0xCF, 0x9, 0x5D, 0x16, 0xF, 0x28, 0x1 } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTEpsonPrinterActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTEpsonPrinterActiveXCtrl, IDS_ETTEPSONPRINTERACTIVEX, _dwETTEpsonPrinterActiveXOleMisc)



// CETTEpsonPrinterActiveXCtrl::CETTEpsonPrinterActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CETTEpsonPrinterActiveXCtrl 的系统注册表项

BOOL CETTEpsonPrinterActiveXCtrl::CETTEpsonPrinterActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTEPSONPRINTERACTIVEX,
			IDB_ETTEPSONPRINTERACTIVEX,
			afxRegApartmentThreading,
			_dwETTEpsonPrinterActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTEpsonPrinterActiveXCtrl::CETTEpsonPrinterActiveXCtrl - 构造函数

CETTEpsonPrinterActiveXCtrl::CETTEpsonPrinterActiveXCtrl()
{
	InitializeIIDs(&IID_DETTEpsonPrinterActiveX, &IID_DETTEpsonPrinterActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTEpsonPrinterActiveXCtrl::~CETTEpsonPrinterActiveXCtrl - 析构函数

CETTEpsonPrinterActiveXCtrl::~CETTEpsonPrinterActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTEpsonPrinterActiveXCtrl::OnDraw - 绘图函数

void CETTEpsonPrinterActiveXCtrl::OnDraw(
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



// CETTEpsonPrinterActiveXCtrl::DoPropExchange - 持久性支持

void CETTEpsonPrinterActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTEpsonPrinterActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTEpsonPrinterActiveXCtrl::GetControlFlags()
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



// CETTEpsonPrinterActiveXCtrl::OnResetState - 将控件重置为默认状态

void CETTEpsonPrinterActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTEpsonPrinterActiveXCtrl 消息处理程序

SHORT CETTEpsonPrinterActiveXCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	DLLInstPrint=LoadLibrary("ReceiptPrinter.dll");
	if(DLLInstPrint!=NULL)
	{
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		SetRowDistance=(int(__stdcall *)(int,char* Message))GetProcAddress(DLLInstPrint,"SetRowDistance");
		PrintLine=(int(__stdcall *)(const char* print_data, char* Message))GetProcAddress(DLLInstPrint,"PrintLine");
		CutPaper=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CutPaper");
		SetTextStyle=(int(__stdcall *)(const char *pszStyle, char* Message))GetProcAddress(DLLInstPrint,"SetTextStyle");

		SetLeftDistance=(int(__stdcall *)(int distance, char* Message))GetProcAddress(DLLInstPrint,"SetLeftDistance");
		PrintBitmapNV=(int(__stdcall *)(int index, int size, int nSpace, char* Message))GetProcAddress(DLLInstPrint,"PrintBitmapNV");
	}
	else
	{
		AfxMessageBox("加载动态库ReceiptPrinter.dll失败！");
		exit(0);
	}

	return 0;
}

SHORT CETTEpsonPrinterActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	if(DLLInstPrint!=NULL)
		FreeLibrary(DLLInstPrint);

	return 0;
}

void CETTEpsonPrinterActiveXCtrl::AddString(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	this->arrStr.Add(data);
}

void CETTEpsonPrinterActiveXCtrl::RemoveAllString(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	this->arrStr.RemoveAll();
}

void CETTEpsonPrinterActiveXCtrl::TestMethod(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	AfxMessageBox("开始执行ShowArray");
	CString str;
	str.Format(_T("数组对象长度！=%d;"),arrStr.GetCount());
	AfxMessageBox(str);
	for (int i=0;i<arrStr.GetCount();i++)
	{
		str.Format(_T("增加数组为！=%s;"),arrStr.GetAt(i));
		AfxMessageBox(str);
	}
}

void CETTEpsonPrinterActiveXCtrl::OnPrinterNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTEpsonPrinterActiveXCtrl::PrinterPort(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	this->m_CQPrint->Dialog(this->m_PrinterName.GetBuffer(),1);
	HPRIVATEFONT font=this->m_CQPrint->AddFontToEnvironment("仿宋_GB2312",10,16);
	this->m_CQPrint->StartPrint();
	this->m_CQPrint->StartPage();
	
	for (int i=0;i<arrStr.GetCount();i++)
	{
		this->m_CQPrint->Print(font,arrStr.GetAt(i),FORMAT_NORMAL,0);
	}

	this->m_CQPrint->EndPage();
	this->m_CQPrint->EndPrint();

	return 0;
}

void CETTEpsonPrinterActiveXCtrl::OnPortChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}
