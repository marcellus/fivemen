// IDCardActiveXCtrl.cpp : CIDCardActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "IDCardActiveX.h"
#include "IDCardActiveXCtrl.h"
#include "IDCardActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CIDCardActiveXCtrl, COleControl)

////////////////////////////////////////////////////////////////////////////
//                        设置activex安全接口
////////////////////////////////////////////////////////////////////////////
BEGIN_INTERFACE_MAP(   CIDCardActiveXCtrl,   COleControl   ) 
INTERFACE_PART(CIDCardActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CIDCardActiveXCtrl::XObjSafe::AddRef() 
{ 
        METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 
        return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CIDCardActiveXCtrl::XObjSafe::Release() 
{ 
        METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 
        return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CIDCardActiveXCtrl::XObjSafe::QueryInterface( 
        REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
        METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 
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
CIDCardActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
/*   [in]   */   REFIID   riid, 
                /*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
                /*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 

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
CIDCardActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
                /*   [in]   */   REFIID   riid, 
                /*   [in]   */   DWORD   dwOptionSetMask, 
                /*   [in]   */   DWORD   dwEnabledOptions) 
{ 
        METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 

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

////////////////////////////////////////////////////////////////////////////
//                        设置activex安全接口
////////////////////////////////////////////////////////////////////////////

// 消息映射

BEGIN_MESSAGE_MAP(CIDCardActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CIDCardActiveXCtrl, COleControl)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CIDCardActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CIDCardActiveXCtrl, 1)
	PROPPAGEID(CIDCardActiveXPropPage::guid)
END_PROPPAGEIDS(CIDCardActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CIDCardActiveXCtrl, "IDCARDACTIVEX.IDCardActiveXCtrl.1",
	0xfd63286f, 0x7a4f, 0x4c01, 0x96, 0x5, 0x21, 0x63, 0xc1, 0xed, 0x11, 0x90)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CIDCardActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DIDCardActiveX =
		{ 0xCE963D6C, 0xDA9E, 0x4E6F, { 0xAE, 0xAC, 0x7F, 0x27, 0xF1, 0x24, 0x8D, 0xE1 } };
const IID BASED_CODE IID_DIDCardActiveXEvents =
		{ 0xF356B5E6, 0x5D6A, 0x4691, { 0xA5, 0x2C, 0x87, 0xB5, 0x23, 0xF6, 0x1, 0x73 } };



// 控件类型信息

static const DWORD BASED_CODE _dwIDCardActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CIDCardActiveXCtrl, IDS_IDCARDACTIVEX, _dwIDCardActiveXOleMisc)



// CIDCardActiveXCtrl::CIDCardActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CIDCardActiveXCtrl 的系统注册表项

BOOL CIDCardActiveXCtrl::CIDCardActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_IDCARDACTIVEX,
			IDB_IDCARDACTIVEX,
			afxRegApartmentThreading,
			_dwIDCardActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CIDCardActiveXCtrl::CIDCardActiveXCtrl - 构造函数

CIDCardActiveXCtrl::CIDCardActiveXCtrl()
{
	InitializeIIDs(&IID_DIDCardActiveX, &IID_DIDCardActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CIDCardActiveXCtrl::~CIDCardActiveXCtrl - 析构函数

CIDCardActiveXCtrl::~CIDCardActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CIDCardActiveXCtrl::OnDraw - 绘图函数

void CIDCardActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CIDCardActiveXCtrl::DoPropExchange - 持久性支持

void CIDCardActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CIDCardActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CIDCardActiveXCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// 不用创建窗口即可激活控件。
	// TODO: 编写控件的消息处理程序时，在使用
	//		m_hWnd 成员变量之前应首先检查它的值是否
	//		非 null。
	dwFlags |= windowlessActivate;
	return dwFlags;
}



// CIDCardActiveXCtrl::OnResetState - 将控件重置为默认状态

void CIDCardActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CIDCardActiveXCtrl 消息处理程序
