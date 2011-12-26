// TestCombine3Ctrl.cpp : CTestCombine3Ctrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "TestCombine3.h"
#include "TestCombine3Ctrl.h"
#include "TestCombine3PropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombine3Ctrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CTestCombine3Ctrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CTestCombine3Ctrl, COleControl)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CTestCombine3Ctrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CTestCombine3Ctrl, 1)
	PROPPAGEID(CTestCombine3PropPage::guid)
END_PROPPAGEIDS(CTestCombine3Ctrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CTestCombine3Ctrl, "TESTCOMBINE3.TestCombine3Ctrl.1",
	0x164cfe46, 0x8493, 0x4bdd, 0x95, 0x8, 0x5, 0x27, 0x65, 0xb5, 0xf1, 0x4f)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CTestCombine3Ctrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DTestCombine3 =
		{ 0x16E1BCDC, 0x2C5F, 0x42E7, { 0x87, 0x96, 0x66, 0xAA, 0x15, 0x79, 0x2A, 0xDF } };
const IID BASED_CODE IID_DTestCombine3Events =
		{ 0xEA3FEAEB, 0x49C, 0x43BD, { 0x9A, 0x70, 0xC6, 0x6F, 0xF3, 0x69, 0x5D, 0xBF } };



// 控件类型信息

static const DWORD BASED_CODE _dwTestCombine3OleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CTestCombine3Ctrl, IDS_TESTCOMBINE3, _dwTestCombine3OleMisc)



// CTestCombine3Ctrl::CTestCombine3CtrlFactory::UpdateRegistry -
// 添加或移除 CTestCombine3Ctrl 的系统注册表项

BOOL CTestCombine3Ctrl::CTestCombine3CtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_TESTCOMBINE3,
			IDB_TESTCOMBINE3,
			afxRegApartmentThreading,
			_dwTestCombine3OleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CTestCombine3Ctrl::CTestCombine3Ctrl - 构造函数

CTestCombine3Ctrl::CTestCombine3Ctrl()
{
	InitializeIIDs(&IID_DTestCombine3, &IID_DTestCombine3Events);
	// TODO: 在此初始化控件的实例数据。
}



// CTestCombine3Ctrl::~CTestCombine3Ctrl - 析构函数

CTestCombine3Ctrl::~CTestCombine3Ctrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CTestCombine3Ctrl::OnDraw - 绘图函数

void CTestCombine3Ctrl::OnDraw(
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



// CTestCombine3Ctrl::DoPropExchange - 持久性支持

void CTestCombine3Ctrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CTestCombine3Ctrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CTestCombine3Ctrl::GetControlFlags()
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



// CTestCombine3Ctrl::OnResetState - 将控件重置为默认状态

void CTestCombine3Ctrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CTestCombine3Ctrl 消息处理程序
