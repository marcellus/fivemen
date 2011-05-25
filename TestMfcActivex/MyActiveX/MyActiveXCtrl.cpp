// MyActiveXCtrl.cpp : CMyActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "MyActiveX.h"
#include "MyActiveXCtrl.h"
#include "MyActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CMyActiveXCtrl, COleControl)


BEGIN_INTERFACE_MAP(   CMyActiveXCtrl,   COleControl   ) 
INTERFACE_PART(CMyActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CMyActiveXCtrl::XObjSafe::AddRef() 
{ 
        METHOD_PROLOGUE(CMyActiveXCtrl,   ObjSafe) 
        return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CMyActiveXCtrl::XObjSafe::Release() 
{ 
        METHOD_PROLOGUE(CMyActiveXCtrl,   ObjSafe) 
        return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CMyActiveXCtrl::XObjSafe::QueryInterface( 
        REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
        METHOD_PROLOGUE(CMyActiveXCtrl,   ObjSafe) 
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
CMyActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
/*   [in]   */   REFIID   riid, 
                /*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
                /*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
METHOD_PROLOGUE(CMyActiveXCtrl,   ObjSafe) 

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
CMyActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
                /*   [in]   */   REFIID   riid, 
                /*   [in]   */   DWORD   dwOptionSetMask, 
                /*   [in]   */   DWORD   dwEnabledOptions) 
{ 
        METHOD_PROLOGUE(CMyActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CMyActiveXCtrl, COleControl)
	ON_MESSAGE(OCM_COMMAND, &CMyActiveXCtrl::OnOcmCommand)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CMyActiveXCtrl, COleControl)
	DISP_FUNCTION(CMyActiveXCtrl, "ShowMessageBox", ShowMessageBox, VT_I2, VTS_NONE)
	DISP_PROPERTY(CMyActiveXCtrl,"MessageStr", MessageStr, VT_BSTR)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CMyActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CMyActiveXCtrl, 1)
	PROPPAGEID(CMyActiveXPropPage::guid)
END_PROPPAGEIDS(CMyActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CMyActiveXCtrl, "MYACTIVEX.MyActiveXCtrl.1",
	0x3978bb54, 0xfc56, 0x4784, 0x9a, 0x6b, 0xe8, 0x80, 0xc8, 0xe7, 0x1b, 0x41)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CMyActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DMyActiveX =
		{ 0x8CE1671B, 0xAA29, 0x4130, { 0x85, 0x4B, 0x61, 0x3A, 0x39, 0xA8, 0x22, 0x98 } };
const IID BASED_CODE IID_DMyActiveXEvents =
		{ 0xABCE71F8, 0xC8D6, 0x4B80, { 0xB2, 0x4C, 0x0, 0x73, 0xD6, 0x3C, 0x1C, 0xAE } };



// 控件类型信息

static const DWORD BASED_CODE _dwMyActiveXOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CMyActiveXCtrl, IDS_MYACTIVEX, _dwMyActiveXOleMisc)



// CMyActiveXCtrl::CMyActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CMyActiveXCtrl 的系统注册表项

BOOL CMyActiveXCtrl::CMyActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_MYACTIVEX,
			IDB_MYACTIVEX,
			afxRegApartmentThreading,
			_dwMyActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CMyActiveXCtrl::CMyActiveXCtrl - 构造函数

CMyActiveXCtrl::CMyActiveXCtrl()
{
	InitializeIIDs(&IID_DMyActiveX, &IID_DMyActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CMyActiveXCtrl::~CMyActiveXCtrl - 析构函数

CMyActiveXCtrl::~CMyActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CMyActiveXCtrl::OnDraw - 绘图函数

void CMyActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	DoSuperclassPaint(pdc, rcBounds);
}



// CMyActiveXCtrl::DoPropExchange - 持久性支持

void CMyActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CMyActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CMyActiveXCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// 在活动和不活动状态之间进行转换时，
	// 不会重新绘制控件。
	dwFlags |= noFlickerActivate;
	return dwFlags;
}



// CMyActiveXCtrl::OnResetState - 将控件重置为默认状态

void CMyActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CMyActiveXCtrl::PreCreateWindow - 修改 CreateWindowEx 的参数

BOOL CMyActiveXCtrl::PreCreateWindow(CREATESTRUCT& cs)
{
	cs.lpszClass = _T("STATIC");
	return COleControl::PreCreateWindow(cs);
}



// CMyActiveXCtrl::IsSubclassedControl - 这是一个子类控件

BOOL CMyActiveXCtrl::IsSubclassedControl()
{
	return TRUE;
}



// CMyActiveXCtrl::OnOcmCommand - 处理命令消息

LRESULT CMyActiveXCtrl::OnOcmCommand(WPARAM wParam, LPARAM lParam)
{
#ifdef _WIN32
	WORD wNotifyCode = HIWORD(wParam);
#else
	WORD wNotifyCode = HIWORD(lParam);
#endif

	// TODO: 在此接通 wNotifyCode。

	return 0;
}



// CMyActiveXCtrl 消息处理程序

short CMyActiveXCtrl::ShowMessageBox() 
{
	//this->MessageStr;
	AfxMessageBox(MessageStr,0,0);
	return 0;
}
