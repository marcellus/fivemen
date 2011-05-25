// ETTSelfUSBVideoActiveXCtrl.cpp : CETTSelfUSBVideoActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTSelfUSBVideoActiveX.h"
#include "ETTSelfUSBVideoActiveXCtrl.h"
#include "ETTSelfUSBVideoActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfUSBVideoActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTSelfUSBVideoActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTSelfUSBVideoActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTSelfUSBVideoActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTSelfUSBVideoActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTSelfUSBVideoActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 
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
CETTSelfUSBVideoActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 

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
CETTSelfUSBVideoActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTSelfUSBVideoActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
	ON_WM_SIZE()
	ON_WM_CREATE()
	//ON_BN_CLICKED(IDC_Video, OnBnClickedButton1)
	//ON_BN_CLICKED(IDC_Bmp, OnBnClickedButton2)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTSelfUSBVideoActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTSelfUSBVideoActiveXCtrl, "BeginCapture", dispidBeginCapture, BeginCapture, VT_BSTR, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfUSBVideoActiveXCtrl, "CaptureBmp", dispidCaptureBmp, CaptureBmp, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfUSBVideoActiveXCtrl, "FileName", dispidFileName, m_FileName, OnFileNameChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTSelfUSBVideoActiveXCtrl, "CaptureBmpDpi", dispidCaptureBmpDpi, CaptureBmpDpi, VT_I2, VTS_I2 VTS_I2)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTSelfUSBVideoActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTSelfUSBVideoActiveXCtrl, 1)
	PROPPAGEID(CETTSelfUSBVideoActiveXPropPage::guid)
END_PROPPAGEIDS(CETTSelfUSBVideoActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTSelfUSBVideoActiveXCtrl, "ETTSELFUSBVIDEOA.ETTSelfUSBVideoACtrl.1",
	0x7970878, 0x4c36, 0x470c, 0xac, 0xdc, 0x9a, 0xb3, 0x6f, 0xa2, 0x8, 0x4b)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTSelfUSBVideoActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTSelfUSBVideoActiveX =
		{ 0x922573C6, 0x1BED, 0x4891, { 0xB7, 0xB1, 0x1, 0x39, 0x5, 0x37, 0x57, 0x63 } };
const IID BASED_CODE IID_DETTSelfUSBVideoActiveXEvents =
		{ 0x5055CF7F, 0x7352, 0x4ECF, { 0xBA, 0xF3, 0x91, 0x83, 0xFF, 0x65, 0x28, 0x1E } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTSelfUSBVideoActiveXOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTSelfUSBVideoActiveXCtrl, IDS_ETTSELFUSBVIDEOACTIVEX, _dwETTSelfUSBVideoActiveXOleMisc)



// CETTSelfUSBVideoActiveXCtrl::CETTSelfUSBVideoActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CETTSelfUSBVideoActiveXCtrl 的系统注册表项

BOOL CETTSelfUSBVideoActiveXCtrl::CETTSelfUSBVideoActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTSELFUSBVIDEOACTIVEX,
			IDB_ETTSELFUSBVIDEOACTIVEX,
			afxRegApartmentThreading,
			_dwETTSelfUSBVideoActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTSelfUSBVideoActiveXCtrl::CETTSelfUSBVideoActiveXCtrl - 构造函数

CETTSelfUSBVideoActiveXCtrl::CETTSelfUSBVideoActiveXCtrl()
{
	InitializeIIDs(&IID_DETTSelfUSBVideoActiveX, &IID_DETTSelfUSBVideoActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTSelfUSBVideoActiveXCtrl::~CETTSelfUSBVideoActiveXCtrl - 析构函数

CETTSelfUSBVideoActiveXCtrl::~CETTSelfUSBVideoActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTSelfUSBVideoActiveXCtrl::OnDraw - 绘图函数

void CETTSelfUSBVideoActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	//pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	//pdc->Ellipse(rcBounds);
	pdc->Rectangle(rcBounds);

	if (!IsOptimizedDraw())
	{
		// 容器不支持优化绘图。

		// TODO: 如果将任何 GDI 对象选入到设备上下文 *pdc 中，
		//		请在此处恢复先前选定的对象。
	}
}



// CETTSelfUSBVideoActiveXCtrl::DoPropExchange - 持久性支持

void CETTSelfUSBVideoActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTSelfUSBVideoActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTSelfUSBVideoActiveXCtrl::GetControlFlags()
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



// CETTSelfUSBVideoActiveXCtrl::OnResetState - 将控件重置为默认状态

void CETTSelfUSBVideoActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTSelfUSBVideoActiveXCtrl 消息处理程序

void CETTSelfUSBVideoActiveXCtrl::OnSize(UINT nType, int cx, int cy)
{
	COleControl::OnSize(nType, cx, cy);

	// TODO: 在此处添加消息处理程序代码
}

int CETTSelfUSBVideoActiveXCtrl::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (COleControl::OnCreate(lpCreateStruct) == -1)
		return -1;

	// TODO:  在此添加您专用的创建代码
	//m_button1.Create(_T("显示视频"),WS_CHILD|WS_VISIBLE,CRect(10,210,90,240),this,IDC_Video);

	//m_button2.Create(_T("截    图"),WS_CHILD|WS_VISIBLE,CRect(20,210,200,240),this,IDC_Bmp);

	return 0;
}


BSTR CETTSelfUSBVideoActiveXCtrl::BeginCapture(int iDevId)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: Add your control notification handler code here
	//开如接收视频源到窗口
	//AfxMessageBox("开始获取activex控件句柄！");
	HWND VideoWnd=this->m_hWnd;
	CRect rect;
	this->GetClientRect(&rect);
	//AfxMessageBox("获取矩形位置");
	//GetDlgItem(IDC_VIDEOPLAY)->GetClientRect(&rect);
	m_Vmr.Init(iDevId,VideoWnd,rect.Width()-30,rect.Height()-40);
	//AfxMessageBox("初始化连接设备！");
	//GetDlgItem(IDC_Video)->EnableWindow(false);
	//GetDlgItem(IDC_Bmp)->EnableWindow(true);

	return strResult.AllocSysString();
}

SHORT CETTSelfUSBVideoActiveXCtrl::CaptureBmp(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//AfxMessageBox("准备创建bmp失败!");
	if(!m_Vmr.ImageCapture(this->m_FileName))
	{
		AfxMessageBox("捕获bmp失败!");
		return 0;
	}
	
	// TODO: 在此添加调度处理程序代码

	return 1;
}

void CETTSelfUSBVideoActiveXCtrl::OnFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

SHORT CETTSelfUSBVideoActiveXCtrl::CaptureBmpDpi(SHORT xdpi, SHORT ydpi)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(!m_Vmr.ImageCaptureEx(xdpi,ydpi,this->m_FileName))
	{
		AfxMessageBox("捕获bmp失败!");
		return 0;
	}

	// TODO: 在此添加调度处理程序代码

	return 1;
}
