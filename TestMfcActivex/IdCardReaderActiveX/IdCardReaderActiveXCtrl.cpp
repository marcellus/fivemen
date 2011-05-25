// IdCardReaderActiveXCtrl.cpp : CIdCardReaderActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "IdCardReaderActiveX.h"
#include "IdCardReaderActiveXCtrl.h"
#include "IdCardReaderActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CIdCardReaderActiveXCtrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CIdCardReaderActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CIdCardReaderActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CIdCardReaderActiveXCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
	
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Password", Password, VT_BSTR)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"ComPort", ComPort, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"baud", baud, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"parity", parity, VT_BSTR)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"databits", databits, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"stopbits", stopbits, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Change", Change, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Timeout", Timeout, VT_I4)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"TrackNo", TrackNo, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Tk_Data2", Tk_Data2, VT_BSTR)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Tk_Data3", Tk_Data3, VT_BSTR)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"port", port, VT_BSTR)

	DISP_FUNCTION(CIdCardReaderActiveXCtrl, "ReadString", ReadString, VT_I2, VTS_NONE)

	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"ResultStr", ResultStr, VT_BSTR)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CIdCardReaderActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CIdCardReaderActiveXCtrl, 1)
	PROPPAGEID(CIdCardReaderActiveXPropPage::guid)
END_PROPPAGEIDS(CIdCardReaderActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CIdCardReaderActiveXCtrl, "IDCARDREADERACTI.IdCardReaderActiCtrl.1",
	0xd25db37e, 0x478, 0x408c, 0x95, 0xca, 0x1e, 0x63, 0xa, 0x88, 0xca, 0xbf)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CIdCardReaderActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DIdCardReaderActiveX =
		{ 0x51F544AC, 0x51EB, 0x4BDC, { 0xBC, 0xF9, 0xBC, 0x57, 0x15, 0x3A, 0x95, 0xBB } };
const IID BASED_CODE IID_DIdCardReaderActiveXEvents =
		{ 0xEDCD5E37, 0x21B4, 0x4900, { 0x83, 0xB9, 0x6A, 0xED, 0xD9, 0x21, 0x87, 0xD4 } };



// 控件类型信息

static const DWORD BASED_CODE _dwIdCardReaderActiveXOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CIdCardReaderActiveXCtrl, IDS_IDCARDREADERACTIVEX, _dwIdCardReaderActiveXOleMisc)



// CIdCardReaderActiveXCtrl::CIdCardReaderActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CIdCardReaderActiveXCtrl 的系统注册表项

BOOL CIdCardReaderActiveXCtrl::CIdCardReaderActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_IDCARDREADERACTIVEX,
			IDB_IDCARDREADERACTIVEX,
			afxRegApartmentThreading,
			_dwIdCardReaderActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CIdCardReaderActiveXCtrl::CIdCardReaderActiveXCtrl - 构造函数

CIdCardReaderActiveXCtrl::CIdCardReaderActiveXCtrl()
{
	InitializeIIDs(&IID_DIdCardReaderActiveX, &IID_DIdCardReaderActiveXEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CIdCardReaderActiveXCtrl::~CIdCardReaderActiveXCtrl - 析构函数

CIdCardReaderActiveXCtrl::~CIdCardReaderActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CIdCardReaderActiveXCtrl::OnDraw - 绘图函数

void CIdCardReaderActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CIdCardReaderActiveXCtrl::DoPropExchange - 持久性支持

void CIdCardReaderActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CIdCardReaderActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CIdCardReaderActiveXCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// 不用创建窗口即可激活控件。
	// TODO: 编写控件的消息处理程序时，在使用
	//		m_hWnd 成员变量之前应首先检查它的值是否
	//		非 null。
	dwFlags |= windowlessActivate;
	return dwFlags;
}



// CIdCardReaderActiveXCtrl::OnResetState - 将控件重置为默认状态

void CIdCardReaderActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CIdCardReaderActiveXCtrl::AboutBox - 向用户显示“关于”框

void CIdCardReaderActiveXCtrl::AboutBox()
{
	CDialog dlgAbout(IDD_ABOUTBOX_IDCARDREADERACTIVEX);
	dlgAbout.DoModal();
}



// CIdCardReaderActiveXCtrl 消息处理程序

short CIdCardReaderActiveXCtrl::ReadString() 
{
	return 0;
}
