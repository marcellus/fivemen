// TestCombine2Ctrl.cpp : CTestCombine2Ctrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "TestCombine2.h"
#include "TestCombine2Ctrl.h"
#include "TestCombine2PropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombine2Ctrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CTestCombine2Ctrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CTestCombine2Ctrl, COleControl)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CTestCombine2Ctrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CTestCombine2Ctrl, 1)
	PROPPAGEID(CTestCombine2PropPage::guid)
END_PROPPAGEIDS(CTestCombine2Ctrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CTestCombine2Ctrl, "TESTCOMBINE2.TestCombine2Ctrl.1",
	0xeecae990, 0x8734, 0x4964, 0xbb, 0xc5, 0x30, 0x5, 0x25, 0xe9, 0x36, 0x2c)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CTestCombine2Ctrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DTestCombine2 =
		{ 0x7265DE52, 0xFDE8, 0x44C9, { 0xB6, 0xAA, 0xAD, 0xA3, 0x41, 0xAE, 0x33, 0x38 } };
const IID BASED_CODE IID_DTestCombine2Events =
		{ 0x4757EEFE, 0x940C, 0x4C06, { 0xBA, 0xD, 0xB6, 0x54, 0x50, 0xE, 0x39, 0xE7 } };



// 控件类型信息

static const DWORD BASED_CODE _dwTestCombine2OleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CTestCombine2Ctrl, IDS_TESTCOMBINE2, _dwTestCombine2OleMisc)



// CTestCombine2Ctrl::CTestCombine2CtrlFactory::UpdateRegistry -
// 添加或移除 CTestCombine2Ctrl 的系统注册表项

BOOL CTestCombine2Ctrl::CTestCombine2CtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_TESTCOMBINE2,
			IDB_TESTCOMBINE2,
			afxRegApartmentThreading,
			_dwTestCombine2OleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CTestCombine2Ctrl::CTestCombine2Ctrl - 构造函数

CTestCombine2Ctrl::CTestCombine2Ctrl()
{
	InitializeIIDs(&IID_DTestCombine2, &IID_DTestCombine2Events);
	// TODO: 在此初始化控件的实例数据。
}



// CTestCombine2Ctrl::~CTestCombine2Ctrl - 析构函数

CTestCombine2Ctrl::~CTestCombine2Ctrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CTestCombine2Ctrl::OnDraw - 绘图函数

void CTestCombine2Ctrl::OnDraw(
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



// CTestCombine2Ctrl::DoPropExchange - 持久性支持

void CTestCombine2Ctrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CTestCombine2Ctrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CTestCombine2Ctrl::GetControlFlags()
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



// CTestCombine2Ctrl::OnResetState - 将控件重置为默认状态

void CTestCombine2Ctrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CTestCombine2Ctrl 消息处理程序
