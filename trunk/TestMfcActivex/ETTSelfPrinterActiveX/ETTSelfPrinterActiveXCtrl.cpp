// ETTSelfPrinterActiveXCtrl.cpp : CETTSelfPrinterActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTSelfPrinterActiveX.h"
#include "ETTSelfPrinterActiveXCtrl.h"
#include "ETTSelfPrinterActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfPrinterActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTSelfPrinterActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTSelfPrinterActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTSelfPrinterActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTSelfPrinterActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTSelfPrinterActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 
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
CETTSelfPrinterActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 

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
CETTSelfPrinterActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTSelfPrinterActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTSelfPrinterActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "CarPrint", dispidCarPrint, CarPrint, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "GLBM", dispidGLBM, m_GLBM, OnGLBMChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "LSH", dispidLSH, m_LSH, OnLSHChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "YWLX", dispidYWLX, m_YWLX, OnYWLXChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Owner", dispidOwner, m_Owner, OnOwnerChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Hmhp", dispidHmhp, m_Hmhp, OnHmhpChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Slrq", dispidSlrq, m_Slrq, OnSlrqChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Fee", dispidFee, m_Fee, OnFeeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Hint", dispidHint, m_Hint, OnHintChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Jszh", dispidJszh, m_Jszh, OnJszhChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Ksrq", dispidKsrq, m_Ksrq, OnKsrqChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Yyrq", dispidYyrq, m_Yyrq, OnYyrqChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "PrinterName", dispidPrinterName, m_PrinterName, OnPrinterNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "MyTestMessage", dispidMyTestMessage, m_MyTestMessage, OnMyTestMessageChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "LoadReceiptDll", dispidLoadReceiptDll, LoadReceiptDll, VT_BSTR, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "LoadInvoiceDll", dispidLoadInvoiceDll, LoadInvoiceDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "SetRowDistanceEx", dispidSetRowDistanceEx, SetRowDistanceEx, VT_I2, VTS_I2)
	
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "CutPaperEx", dispidCutPaperEx, CutPaperEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "PrintLineEx2", dispidPrintLineEx2, PrintLineEx2, VT_I2, VTS_PBSTR)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "ClearAll", dispidClearAll, ClearAll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "AddString", dispidAddString, AddString, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "Test", dispidTest, Test, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "ShowArray", dispidShowArray, ShowArray, VT_EMPTY, VTS_NONE)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTSelfPrinterActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTSelfPrinterActiveXCtrl, 1)
	PROPPAGEID(CETTSelfPrinterActiveXPropPage::guid)
END_PROPPAGEIDS(CETTSelfPrinterActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTSelfPrinterActiveXCtrl, "ETTSELFPRINTERAC.ETTSelfPrinterAcCtrl.1",
	0x4f193682, 0x5451, 0x4cd5, 0x83, 0x40, 0x63, 0xdd, 0x4, 0xd2, 0xfa, 0xd9)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTSelfPrinterActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTSelfPrinterActiveX =
		{ 0xD30B98E7, 0xF1BB, 0x402D, { 0x8E, 0x60, 0x6D, 0x7F, 0xAD, 0x93, 0xF6, 0x28 } };
const IID BASED_CODE IID_DETTSelfPrinterActiveXEvents =
		{ 0x889818F0, 0x7383, 0x4B13, { 0xA1, 0x50, 0x6E, 0x77, 0x72, 0x78, 0xAB, 0xBC } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTSelfPrinterActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTSelfPrinterActiveXCtrl, IDS_ETTSELFPRINTERACTIVEX, _dwETTSelfPrinterActiveXOleMisc)



// CETTSelfPrinterActiveXCtrl::CETTSelfPrinterActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CETTSelfPrinterActiveXCtrl 的系统注册表项

BOOL CETTSelfPrinterActiveXCtrl::CETTSelfPrinterActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTSELFPRINTERACTIVEX,
			IDB_ETTSELFPRINTERACTIVEX,
			afxRegApartmentThreading,
			_dwETTSelfPrinterActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTSelfPrinterActiveXCtrl::CETTSelfPrinterActiveXCtrl - 构造函数

CETTSelfPrinterActiveXCtrl::CETTSelfPrinterActiveXCtrl()
{
	InitializeIIDs(&IID_DETTSelfPrinterActiveX, &IID_DETTSelfPrinterActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTSelfPrinterActiveXCtrl::~CETTSelfPrinterActiveXCtrl - 析构函数

CETTSelfPrinterActiveXCtrl::~CETTSelfPrinterActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTSelfPrinterActiveXCtrl::OnDraw - 绘图函数

void CETTSelfPrinterActiveXCtrl::OnDraw(
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



// CETTSelfPrinterActiveXCtrl::DoPropExchange - 持久性支持

void CETTSelfPrinterActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTSelfPrinterActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTSelfPrinterActiveXCtrl::GetControlFlags()
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



// CETTSelfPrinterActiveXCtrl::OnResetState - 将控件重置为默认状态

void CETTSelfPrinterActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTSelfPrinterActiveXCtrl 消息处理程序

SHORT CETTSelfPrinterActiveXCtrl::CarPrint(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//AfxMessageBox((LPCTSTR)"提示信息",0,0);
	this->m_CQPrint=new CQPrint();
	//AfxMessageBox((LPCTSTR)"执行Dialog",0,0);
	int dialogint=0;
	if(m_PrinterName.GetLength()!=0)
	{
	    dialogint=m_CQPrint->Dialog(m_PrinterName.GetBuffer(m_PrinterName.GetLength()),1);
	}
	else

	{
		dialogint=m_CQPrint->Dialog(NULL,1);
	}
	if(dialogint==-1)
	{
		return -1;
	}
	//m_CQPrint->Dialog("Microsoft Office Document Image Writer",1);
	//m_CQPrint->Dialog("\\\\192.168.1.150\\Share-Printer",1);
	//AfxMessageBox((LPCTSTR)"执行StartPrint",0,0);
	//CString str = new CString();
	//str.Format("%d",this->dispidPrinterName);
	//str.
	//m_CQPrint->Dialog("1",1);
	m_CQPrint->StartPrint();
	m_CQPrint->AddFontToEnvironment("宋体",7,16);
	m_CQPrint->SetMargins(20,20,20,20);
	m_CQPrint->SetDistance(5);
	//m_CQPrint->ActivateHF());
	int size_temp[]={5};
	m_CQPrint->SetTableColumnsSize(1,size_temp);
	//AfxMessageBox((LPCTSTR)"执行StartPage",0,0);
	m_CQPrint->StartPage();
	//AfxMessageBox((LPCTSTR)"执行SetMargins",0,0);
	
	//m_CQPrint->SetTableColumns(1);
	
	//AfxMessageBox((LPCTSTR)"执行AddTableRecord",0,0);
	//m_CQPrint->AddTableRecord(0,"我要居中对齐！",FORMAT_CENTER);
	//m_CQPrint->
	//m_CQPrint->Print(0,"我是中间商1！",FORMAT_CENTER,0);
	m_CQPrint->Print(0,this->m_GLBM,FORMAT_CENTER,0);
    m_CQPrint->Print(0,(LPCTSTR)"机动车受理凭证",FORMAT_CENTER,0);
	CString strFormat;
	strFormat.Format("流 水 号：%s",this->m_LSH);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
    strFormat.Format("业务类型：%s",this->m_YWLX);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
    strFormat.Format("所 有 人：%s",this->m_Owner);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
	strFormat.Format("号码号牌：%s",this->m_Hmhp);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
	strFormat.Format("受理日期：%s",this->m_Slrq);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
	strFormat.Format("收费金额：%s",this->m_Fee);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
    strFormat.Format("所需材料：%s",this->m_Hint);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
	//m_CQPrint->Line(PS_DOT);

	//m_CQPrint->Print(0,"我是中间商2！",FORMAT_CENTER,0);
	//m_CQPrint->Line(PS_SOLID);
	//AfxMessageBox((LPCTSTR)"执行EndPage",0,0);
	m_CQPrint->EndPage();
	//m_CQPrint->Print(0,"我是中间商3！",FORMAT_CENTER,0);
	//AfxMessageBox((LPCTSTR)"执行EndPrint",0,0);
	m_CQPrint->EndPrint();

	return 0;
}

void CETTSelfPrinterActiveXCtrl::OnGLBMChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnLSHChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnYWLXChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnOwnerChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnHmhpChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnSlrqChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnFeeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnHintChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnJszhChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnKsrqChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnYyrqChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnPrinterNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnMyTestMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTSelfPrinterActiveXCtrl::LoadReceiptDll(void)
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
	}
	else
	{
		AfxMessageBox("加载动态库ReceiptPrinter.dll失败！");
		exit(0);
	}
	
	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::LoadInvoiceDll(void)
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
	}
	else
	{
		AfxMessageBox("加载动态库InvoicePrinter.dll失败！");
		exit(0);
	}

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(DLLInstPrint!=NULL)
		FreeLibrary(DLLInstPrint);

	return 0;
}


SHORT CETTSelfPrinterActiveXCtrl::OpenDeviceEx(int port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strError;
	
	char* msg;
	int ret=OpenDevice(port,msg);
	strError.Format(_T("打开端口结果！=%u;i_ret = %u"),port,ret);
	AfxMessageBox(strError);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	CString strError;

	char* msg;
	int ret=CloseDevice(msg);
	strError.Format(_T("关闭端口结果！=%u;"),ret);
	AfxMessageBox(strError);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::SetRowDistanceEx(int distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	// TODO: 在此添加调度处理程序代码
	CString strError;

	char* msg;
	int ret=SetRowDistance(distance,msg);
	strError.Format(_T("关闭端口结果！=%u;"),ret);
	AfxMessageBox(strError);

	return 0;
}


SHORT CETTSelfPrinterActiveXCtrl::CutPaperEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	CString strError;

	char* msg;
	int ret=CutPaper(msg);
	strError.Format(_T("切纸结果！=%u;"),ret);
	AfxMessageBox(strError);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::PrintLineEx2(BSTR* data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
CString strError;
	char* msg;
	//char* data2 = data;
	int ret=PrintLine(msg,msg);
	strError.Format(_T("切纸结果！=%u;"),ret);
	AfxMessageBox(strError);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::ClearAll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	this->arrStr.RemoveAll();

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::AddString(BSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	AfxMessageBox("开始执行AddString");
	//CString str;
	//str.Format(_T("增加数组为！=%u;"),data);
	//AfxMessageBox(str);
	//this->arrStr.Add(data);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::Test(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	AfxMessageBox("开始执行Test");

	// TODO: 在此添加调度处理程序代码
	/*CString str;
	str.Format(_T("数组对象长度！=%d;"),arrStr.GetCount());
	AfxMessageBox(str);
	for (int i=0;i<arrStr.GetCount();i++)
	{
		str.Format(_T("增加数组为！=%u;"),arrStr.GetAt(i));
		AfxMessageBox(str);
	}
	*/

	return 0;
}

void CETTSelfPrinterActiveXCtrl::ShowArray(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
	
AfxMessageBox("开始执行ShowArray");
	/*CString str;
	str.Format(_T("数组对象长度！=%d;"),arrStr.GetCount());
	AfxMessageBox(str);
	for (int i=0;i<arrStr.GetCount();i++)
	{
		str.Format(_T("增加数组为！=%u;"),arrStr.GetAt(i));
		AfxMessageBox(str);
	}
	*/

}
