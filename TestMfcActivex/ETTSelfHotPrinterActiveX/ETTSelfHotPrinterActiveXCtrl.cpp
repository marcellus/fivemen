// ETTSelfHotPrinterActiveXCtrl.cpp : CETTSelfHotPrinterActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTSelfHotPrinterActiveX.h"
#include "ETTSelfHotPrinterActiveXCtrl.h"
#include "ETTSelfHotPrinterActiveXPropPage.h"

#include <comutil.h>
#include "windows.h"
#pragma comment(lib,"comsuppw.lib")


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfHotPrinterActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTSelfHotPrinterActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTSelfHotPrinterActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTSelfHotPrinterActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTSelfHotPrinterActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTSelfHotPrinterActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 
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
CETTSelfHotPrinterActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 

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
CETTSelfHotPrinterActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTSelfHotPrinterActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTSelfHotPrinterActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "LoadReceiptDll", dispidLoadReceiptDll, LoadReceiptDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "LoadInvoiceDll", dispidLoadInvoiceDll, LoadInvoiceDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "AddString", dispidAddString, AddString, VT_EMPTY, VTS_BSTR)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "TestArray", dispidTestArray, TestArray, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "RemoveAllString", dispidRemoveAllString, RemoveAllString, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "PrintHot", dispidPrintHot, PrintHot, VT_EMPTY, VTS_I2 VTS_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfHotPrinterActiveXCtrl, "FontStyle", dispidFontStyle, m_FontStyle, OnFontStyleChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "GetDeviceStatusEx", dispidGetDeviceStatusEx, GetDeviceStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "SetRowDistanceEx", dispidSetRowDistanceEx, SetRowDistanceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "SetLeftDistanceEx", dispidSetLeftDistanceEx, SetLeftDistanceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "PrintLineEx", dispidPrintLineEx, PrintLineEx, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "CutPaperEx", dispidCutPaperEx, CutPaperEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "PrintBitmapNVEx", dispidPrintBitmapNVEx, PrintBitmapNVEx, VT_I2, VTS_I2 VTS_I2 VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "SetTextStyleEx", dispidSetTextStyleEx, SetTextStyleEx, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "SetBlackOffsetEx", dispidSetBlackOffsetEx, SetBlackOffsetEx, VT_I2, VTS_I2 VTS_I2 VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "BlackMarkIdentifyEx", dispidBlackMarkIdentifyEx, BlackMarkIdentifyEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "MovePaperEx", dispidMovePaperEx, MovePaperEx, VT_I2, VTS_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfHotPrinterActiveXCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTSelfHotPrinterActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTSelfHotPrinterActiveXCtrl, 1)
	PROPPAGEID(CETTSelfHotPrinterActiveXPropPage::guid)
END_PROPPAGEIDS(CETTSelfHotPrinterActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTSelfHotPrinterActiveXCtrl, "ETTSELFHOTPRINTE.ETTSelfHotPrinteCtrl.1",
	0xcada7da3, 0x25c6, 0x43e6, 0xb5, 0xc5, 0x7a, 0x5e, 0x94, 0x9a, 0x52, 0x96)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTSelfHotPrinterActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTSelfHotPrinterActiveX =
		{ 0x4FE5156D, 0x91B, 0x4A4B, { 0x98, 0xA0, 0xE9, 0x85, 0x66, 0x22, 0xD7, 0xD5 } };
const IID BASED_CODE IID_DETTSelfHotPrinterActiveXEvents =
		{ 0xBBBBCF47, 0xF600, 0x4371, { 0x8D, 0xD3, 0x36, 0x41, 0xC9, 0xDA, 0x18, 0x2E } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTSelfHotPrinterActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTSelfHotPrinterActiveXCtrl, IDS_ETTSELFHOTPRINTERACTIVEX, _dwETTSelfHotPrinterActiveXOleMisc)



// CETTSelfHotPrinterActiveXCtrl::CETTSelfHotPrinterActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CETTSelfHotPrinterActiveXCtrl 的系统注册表项

BOOL CETTSelfHotPrinterActiveXCtrl::CETTSelfHotPrinterActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTSELFHOTPRINTERACTIVEX,
			IDB_ETTSELFHOTPRINTERACTIVEX,
			afxRegApartmentThreading,
			_dwETTSelfHotPrinterActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTSelfHotPrinterActiveXCtrl::CETTSelfHotPrinterActiveXCtrl - 构造函数

CETTSelfHotPrinterActiveXCtrl::CETTSelfHotPrinterActiveXCtrl()
{
	InitializeIIDs(&IID_DETTSelfHotPrinterActiveX, &IID_DETTSelfHotPrinterActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTSelfHotPrinterActiveXCtrl::~CETTSelfHotPrinterActiveXCtrl - 析构函数

CETTSelfHotPrinterActiveXCtrl::~CETTSelfHotPrinterActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTSelfHotPrinterActiveXCtrl::OnDraw - 绘图函数

void CETTSelfHotPrinterActiveXCtrl::OnDraw(
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



// CETTSelfHotPrinterActiveXCtrl::DoPropExchange - 持久性支持

void CETTSelfHotPrinterActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTSelfHotPrinterActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTSelfHotPrinterActiveXCtrl::GetControlFlags()
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



// CETTSelfHotPrinterActiveXCtrl::OnResetState - 将控件重置为默认状态

void CETTSelfHotPrinterActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTSelfHotPrinterActiveXCtrl 消息处理程序

SHORT CETTSelfHotPrinterActiveXCtrl::LoadReceiptDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	DLLInstPrint=LoadLibrary("ReceiptPrinter.dll");
	//AfxMessageBox("LoadLibrary -sdtapi.dll 成功！");
	//AfxMessageBox("LoadLibrary -WltRS.dll 成功！");
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
		this->m_Message="成功";
		return 0;
	}
	else
	{
		this->m_Message="失败";
		return -1;
		AfxMessageBox("加载动态库ReceiptPrinter.dll失败！");
		exit(0);
	}


	// TODO: 在此添加调度处理程序代码
}

SHORT CETTSelfHotPrinterActiveXCtrl::LoadInvoiceDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	DLLInstPrint=LoadLibrary("InvoicePrinter.dll");
	//AfxMessageBox("LoadLibrary -sdtapi.dll 成功！");
	//AfxMessageBox("LoadLibrary -WltRS.dll 成功！");
	if(DLLInstPrint!=NULL)
	{
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		SetRowDistance=(int(__stdcall *)(int,char* Message))GetProcAddress(DLLInstPrint,"SetRowDistance");
		PrintLine=(int(__stdcall *)(const char* print_data, char* Message))GetProcAddress(DLLInstPrint,"PrintLine");
		CutPaper=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CutPaper");
		SetTextStyle=(int(__stdcall *)(const char *pszStyle, char* Message))GetProcAddress(DLLInstPrint,"SetTextStyle");

		SetBlackOffset=(int(__stdcall *)(int P, int L, int Q, char *Message))GetProcAddress(DLLInstPrint,"SetBlackOffset");
		BlackMarkIdentify=(int(__stdcall *)(char *Message))GetProcAddress(DLLInstPrint,"BlackMarkIdentify");
		MovePaper=(int(__stdcall *)(int Distance, char* Messagee))GetProcAddress(DLLInstPrint,"MovePaper");
		this->m_Message="成功";
		return 0;
	}
	else
	{
		this->m_Message="失败";
		return -1;
		AfxMessageBox("加载动态库InvoicePrinter.dll失败！");
		exit(0);
	}

	// TODO: 在此添加调度处理程序代码
}

SHORT CETTSelfHotPrinterActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	if(DLLInstPrint!=NULL)
	{
		FreeLibrary(DLLInstPrint);
		DLLInstPrint=NULL;
		this->m_Message="成功";
		return 0;
	}
	else
	{

		this->m_Message="失败";
		return -1;
	}

	// TODO: 在此添加调度处理程序代码
}

void CETTSelfHotPrinterActiveXCtrl::AddString(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//AfxMessageBox(L"开始执行AddString");
	//CString str;
	//str.Format(_T("增加数组为！=%u;"),data);
	//AfxMessageBox(str);
	this->arrStr.Add(data);

	// TODO: 在此添加调度处理程序代码
}

void CETTSelfHotPrinterActiveXCtrl::TestArray(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	AfxMessageBox("开始执行ShowArray");
	CString str;
	str.Format(_T("数组对象长度！=%d;"),arrStr.GetCount());
	AfxMessageBox(str);
	for (int i=0;i<arrStr.GetCount();i++)
	{
	str.Format(_T("增加数组为！=%s;"),arrStr.GetAt(i));
	AfxMessageBox(str);
	}
	

	// TODO: 在此添加调度处理程序代码
}

void CETTSelfHotPrinterActiveXCtrl::RemoveAllString(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	this->arrStr.RemoveAll();
}

void CETTSelfHotPrinterActiveXCtrl::PrintHot(SHORT port, SHORT distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	this->LoadReceiptDll();
	//char* msg="test";
	char msg[255];
	int ret=-1;
	ret=OpenDevice(port,msg);
	//CString tmp;
	//tmp.Format(_T("打开热敏打印机端口%d结果%d"),port,ret);
	//AfxMessageBox(tmp);
	if(m_FontStyle.GetLength()>0)
	{
		ret=SetTextStyle(m_FontStyle,msg);
	}
	for (int i=0;i<arrStr.GetCount();i++)
	{
		ret=PrintLine(arrStr.GetAt(i),msg);
		//tmp.Format(_T("打印字符串%u结果%d"),arrStr.GetAt(i),ret);
		//AfxMessageBox(tmp);
	}
	ret=CutPaper(msg);
	//tmp.Format(_T("切纸结果%d"),ret);
	//AfxMessageBox(tmp);
	ret=CloseDevice(msg);
	//tmp.Format(_T("关闭打印机端口，结果%d"),ret);
	//AfxMessageBox(tmp);
	this->DestroyDll();


	// TODO: 在此添加调度处理程序代码
}

void CETTSelfHotPrinterActiveXCtrl::OnFontStyleChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码
	

	SetModifiedFlag();
}

SHORT CETTSelfHotPrinterActiveXCtrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
   char msg[255];
   int ret=-1;
   ret=OpenDevice(port,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CloseDevice(msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::GetDeviceStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=GetDeviceStatus(msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::SetRowDistanceEx(SHORT distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=SetRowDistance(distance,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::SetLeftDistanceEx(SHORT distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=SetLeftDistance(distance,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::PrintLineEx(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=PrintLine(data,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::CutPaperEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CutPaper(msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::PrintBitmapNVEx(SHORT index, SHORT size, SHORT nspace)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=PrintBitmapNV(index,size,nspace,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::SetTextStyleEx(LPCTSTR style)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=SetTextStyle(style,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::SetBlackOffsetEx(SHORT P, SHORT L, SHORT Q)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=SetBlackOffset(P,L,Q,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::BlackMarkIdentifyEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=BlackMarkIdentify(msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::MovePaperEx(SHORT distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=MovePaper(distance,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

void CETTSelfHotPrinterActiveXCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}
