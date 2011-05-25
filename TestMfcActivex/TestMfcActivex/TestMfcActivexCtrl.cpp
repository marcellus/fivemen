// TestMfcActivexCtrl.cpp : CTestMfcActivexCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "TestMfcActivex.h"
#include "TestMfcActivexCtrl.h"
#include "TestMfcActivexPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestMfcActivexCtrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CTestMfcActivexCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CTestMfcActivexCtrl, COleControl)
	DISP_FUNCTION_ID(CTestMfcActivexCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CTestMfcActivexCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CTestMfcActivexCtrl, 1)
	PROPPAGEID(CTestMfcActivexPropPage::guid)
END_PROPPAGEIDS(CTestMfcActivexCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CTestMfcActivexCtrl, "TESTMFCACTIVEX.TestMfcActivexCtrl.1",
	0xe5df618a, 0xe0cc, 0x4f68, 0xac, 0xb2, 0x15, 0x5a, 0x1d, 0x3b, 0xaf, 0xca)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CTestMfcActivexCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DTestMfcActivex =
		{ 0x8BB622EB, 0x3854, 0x4B1E, { 0xB9, 0x75, 0x1F, 0x75, 0xBE, 0xAD, 0x42, 0xF5 } };
const IID BASED_CODE IID_DTestMfcActivexEvents =
		{ 0xD8505EB0, 0x1BCD, 0x4E2F, { 0x91, 0xAD, 0x11, 0x5E, 0xF4, 0xCF, 0xAE, 0xF8 } };



// 控件类型信息

static const DWORD BASED_CODE _dwTestMfcActivexOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CTestMfcActivexCtrl, IDS_TESTMFCACTIVEX, _dwTestMfcActivexOleMisc)



// CTestMfcActivexCtrl::CTestMfcActivexCtrlFactory::UpdateRegistry -
// 添加或移除 CTestMfcActivexCtrl 的系统注册表项

BOOL CTestMfcActivexCtrl::CTestMfcActivexCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_TESTMFCACTIVEX,
			IDB_TESTMFCACTIVEX,
			afxRegApartmentThreading,
			_dwTestMfcActivexOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CTestMfcActivexCtrl::CTestMfcActivexCtrl - 构造函数

CTestMfcActivexCtrl::CTestMfcActivexCtrl()
{
	InitializeIIDs(&IID_DTestMfcActivex, &IID_DTestMfcActivexEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CTestMfcActivexCtrl::~CTestMfcActivexCtrl - 析构函数

CTestMfcActivexCtrl::~CTestMfcActivexCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CTestMfcActivexCtrl::OnDraw - 绘图函数

void CTestMfcActivexCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CTestMfcActivexCtrl::DoPropExchange - 持久性支持

void CTestMfcActivexCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CTestMfcActivexCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CTestMfcActivexCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// 不用创建窗口即可激活控件。
	// TODO: 编写控件的消息处理程序时，在使用
	//		m_hWnd 成员变量之前应首先检查它的值是否
	//		非 null。
	dwFlags |= windowlessActivate;
	return dwFlags;
}



// CTestMfcActivexCtrl::OnResetState - 将控件重置为默认状态

void CTestMfcActivexCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CTestMfcActivexCtrl::AboutBox - 向用户显示“关于”框

void CTestMfcActivexCtrl::AboutBox()
{
	CDialog dlgAbout(IDD_ABOUTBOX_TESTMFCACTIVEX);
	dlgAbout.DoModal();
}



// CTestMfcActivexCtrl 消息处理程序
