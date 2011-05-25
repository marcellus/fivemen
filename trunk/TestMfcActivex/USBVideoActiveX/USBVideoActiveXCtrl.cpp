// USBVideoActiveXCtrl.cpp : CUSBVideoActiveXCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "USBVideoActiveX.h"
#include "USBVideoActiveXCtrl.h"
#include "USBVideoActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CUSBVideoActiveXCtrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CUSBVideoActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
	ON_WM_CREATE()
	ON_BN_CLICKED(1, OnBnClickedButton1)
	ON_BN_CLICKED(2, OnBnClickedButton2)
	//ON_WM_SIZE()
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CUSBVideoActiveXCtrl, COleControl)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CUSBVideoActiveXCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CUSBVideoActiveXCtrl, 1)
	PROPPAGEID(CUSBVideoActiveXPropPage::guid)
END_PROPPAGEIDS(CUSBVideoActiveXCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CUSBVideoActiveXCtrl, "USBVIDEOACTIVEX.USBVideoActiveXCtrl.1",
	0x1009cfdd, 0xfda, 0x4e6f, 0x8a, 0xac, 0xaa, 0x3f, 0x38, 0x15, 0x52, 0x21)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CUSBVideoActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DUSBVideoActiveX =
		{ 0x99D458C9, 0x4608, 0x4ED5, { 0xAE, 0xE7, 0x43, 0xCB, 0x5B, 0x82, 0x10, 0xFE } };
const IID BASED_CODE IID_DUSBVideoActiveXEvents =
		{ 0xA0A6C942, 0x950D, 0x40CD, { 0xBE, 0x76, 0x1E, 0x69, 0x36, 0x2D, 0x29, 0x41 } };



// 控件类型信息

static const DWORD BASED_CODE _dwUSBVideoActiveXOleMisc =
	OLEMISC_SIMPLEFRAME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CUSBVideoActiveXCtrl, IDS_USBVIDEOACTIVEX, _dwUSBVideoActiveXOleMisc)



// CUSBVideoActiveXCtrl::CUSBVideoActiveXCtrlFactory::UpdateRegistry -
// 添加或移除 CUSBVideoActiveXCtrl 的系统注册表项

BOOL CUSBVideoActiveXCtrl::CUSBVideoActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_USBVIDEOACTIVEX,
			IDB_USBVIDEOACTIVEX,
			afxRegApartmentThreading,
			_dwUSBVideoActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CUSBVideoActiveXCtrl::CUSBVideoActiveXCtrl - 构造函数

CUSBVideoActiveXCtrl::CUSBVideoActiveXCtrl()
{
	InitializeIIDs(&IID_DUSBVideoActiveX, &IID_DUSBVideoActiveXEvents);

	EnableSimpleFrame();
	// TODO: 在此初始化控件的实例数据。
}



// CUSBVideoActiveXCtrl::~CUSBVideoActiveXCtrl - 析构函数

CUSBVideoActiveXCtrl::~CUSBVideoActiveXCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CUSBVideoActiveXCtrl::OnDraw - 绘图函数

void CUSBVideoActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: 用您自己的绘图代码替换下面的代码。
	//pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	//pdc->Ellipse(rcBounds);
	//pdc->DrawText()
	pdc->Rectangle(rcBounds);

	if (!IsOptimizedDraw())
	{
		// 容器不支持优化绘图。

		// TODO: 如果将任何 GDI 对象选入到设备上下文 *pdc 中，
		//		请在此处恢复先前选定的对象。
	}
}



// CUSBVideoActiveXCtrl::DoPropExchange - 持久性支持

void CUSBVideoActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CUSBVideoActiveXCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CUSBVideoActiveXCtrl::GetControlFlags()
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



// CUSBVideoActiveXCtrl::OnResetState - 将控件重置为默认状态

void CUSBVideoActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}


void CUSBVideoActiveXCtrl::OnBnClickedButton1()
{
	AfxMessageBox(_T("显示视频!"));
	
}

void CUSBVideoActiveXCtrl::OnBnClickedButton2()
{
	AfxMessageBox(_T("开始截图!"));

	//GetDlgItem(1)->EnableWindow(false);
}


// CUSBVideoActiveXCtrl 消息处理程序

int CUSBVideoActiveXCtrl::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (COleControl::OnCreate(lpCreateStruct) == -1)
		return -1;
   
m_button1.Create(_T("显示视频"),WS_CHILD|WS_VISIBLE,CRect(10,10,50,30),this,1);
	//m_button1.Create(_T("显示视频"),WS_CHILD|WS_VISIBLE,CRect(10,210,110,30),this,1);

	m_button2.Create(_T("截    图"),WS_CHILD|WS_VISIBLE,CRect(80,10,110,30),this,2);
	AfxMessageBox(L"创建控件完成！");

	// TODO:  在此添加您专用的创建代码

	return 0;
}

void CUSBVideoActiveXCtrl::OnSize(UINT nType, int cx, int cy)
{
	COleControl::OnSize(nType, cx, cy);

	// TODO: 在此处添加消息处理程序代码
}
