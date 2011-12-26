// TestCombineActiveCtrl.cpp : CTestCombineActiveCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "TestCombineActive.h"
#include "TestCombineActiveCtrl.h"
#include "TestCombineActivePropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombineActiveCtrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CTestCombineActiveCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CTestCombineActiveCtrl, COleControl)
	DISP_FUNCTION_ID(CTestCombineActiveCtrl, "HelloWordA", dispidHelloWordA, HelloWordA, VT_I2, VTS_NONE)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CTestCombineActiveCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CTestCombineActiveCtrl, 1)
	PROPPAGEID(CTestCombineActivePropPage::guid)
END_PROPPAGEIDS(CTestCombineActiveCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CTestCombineActiveCtrl, "TESTCOMBINEACTIV.TestCombineActivCtrl.1",
	0x8128503e, 0x4d53, 0x4b22, 0xab, 0xb3, 0x88, 0xa2, 0x8c, 0x89, 0x91, 0xa1)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CTestCombineActiveCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DTestCombineActive =
		{ 0xC761E55F, 0xDED9, 0x41BD, { 0xB4, 0x46, 0x22, 0x36, 0x5F, 0x85, 0x1E, 0x1A } };
const IID BASED_CODE IID_DTestCombineActiveEvents =
		{ 0x1C0CB663, 0xD6DC, 0x4AED, { 0xB3, 0xE4, 0xF0, 0x8B, 0xE4, 0x3B, 0x7B, 0x45 } };



// 控件类型信息

static const DWORD BASED_CODE _dwTestCombineActiveOleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CTestCombineActiveCtrl, IDS_TESTCOMBINEACTIVE, _dwTestCombineActiveOleMisc)



// CTestCombineActiveCtrl::CTestCombineActiveCtrlFactory::UpdateRegistry -
// 添加或移除 CTestCombineActiveCtrl 的系统注册表项

BOOL CTestCombineActiveCtrl::CTestCombineActiveCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_TESTCOMBINEACTIVE,
			IDB_TESTCOMBINEACTIVE,
			afxRegApartmentThreading,
			_dwTestCombineActiveOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CTestCombineActiveCtrl::CTestCombineActiveCtrl - 构造函数

CTestCombineActiveCtrl::CTestCombineActiveCtrl()
{
	InitializeIIDs(&IID_DTestCombineActive, &IID_DTestCombineActiveEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CTestCombineActiveCtrl::~CTestCombineActiveCtrl - 析构函数

CTestCombineActiveCtrl::~CTestCombineActiveCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CTestCombineActiveCtrl::OnDraw - 绘图函数

void CTestCombineActiveCtrl::OnDraw(
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



// CTestCombineActiveCtrl::DoPropExchange - 持久性支持

void CTestCombineActiveCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CTestCombineActiveCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CTestCombineActiveCtrl::GetControlFlags()
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



// CTestCombineActiveCtrl::OnResetState - 将控件重置为默认状态

void CTestCombineActiveCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CTestCombineActiveCtrl 消息处理程序

SHORT CTestCombineActiveCtrl::HelloWordA(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码

	return 1;
}
