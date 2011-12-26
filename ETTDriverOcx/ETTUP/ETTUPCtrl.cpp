// ETTUPCtrl.cpp : CETTUPCtrl ActiveX 控件类的实现。

#include "stdafx.h"
#include "ETTUP.h"
#include "ETTUPCtrl.h"
#include "ETTUPPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTUPCtrl, COleControl)



// 消息映射

BEGIN_MESSAGE_MAP(CETTUPCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// 调度映射

BEGIN_DISPATCH_MAP(CETTUPCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "SerialNo", dispidSerialNo, m_SerialNo, OnSerialNoChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "DeviceNo", dispidDeviceNo, m_DeviceNo, OnDeviceNoChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "BusinessNo", dispidBusinessNo, m_BusinessNo, OnBusinessNoChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "Balance", dispidBalance, m_Balance, OnBalanceChanged, VT_I4)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "AllowBalance", dispidAllowBalance, m_AllowBalance, OnAllowBalanceChanged, VT_I4)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "RetCode", dispidRetCode, m_RetCode, OnRetCodeChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "ServerIp", dispidServerIp, m_ServerIp, OnServerIpChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "ServerPort", dispidServerPort, m_ServerPort, OnServerPortChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTUPCtrl, "OldSerialNo", dispidOldSerialNo, m_OldSerialNo, OnOldSerialNoChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTUPCtrl, "UnUnionPayPack", dispidUnUnionPayPack, UnUnionPayPack, VT_BSTR, VTS_BSTR)
	DISP_FUNCTION_ID(CETTUPCtrl, "UPSendData", dispidUPSendData, UPSendData, VT_BSTR, VTS_BSTR)
	DISP_FUNCTION_ID(CETTUPCtrl, "Make0800", dispidMake0800, Make0800, VT_BSTR, VTS_NONE)
	DISP_FUNCTION_ID(CETTUPCtrl, "Make0200", dispidMake0200, Make0200, VT_BSTR, VTS_I4 VTS_BSTR VTS_BSTR VTS_BSTR)
	DISP_FUNCTION_ID(CETTUPCtrl, "Make0400", dispidMake0400, Make0400, VT_BSTR, VTS_I4 VTS_BSTR VTS_BSTR VTS_BSTR)
	DISP_FUNCTION_ID(CETTUPCtrl, "QueryBalance", dispidQueryBalance, QueryBalance, VT_EMPTY, VTS_BSTR VTS_BSTR VTS_BSTR)
	DISP_FUNCTION_ID(CETTUPCtrl, "Pay", dispidPay, Pay, VT_EMPTY, VTS_I4 VTS_BSTR VTS_BSTR VTS_BSTR)
	DISP_FUNCTION_ID(CETTUPCtrl, "SignIn", dispidSignIn, SignIn, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTUPCtrl, "PayBack", dispidPayBack, PayBack, VT_EMPTY, VTS_I4 VTS_BSTR VTS_BSTR VTS_BSTR)
	DISP_FUNCTION_ID(CETTUPCtrl, "Log", dispidLog, Log, VT_EMPTY, VTS_BSTR)
END_DISPATCH_MAP()



// 事件映射

BEGIN_EVENT_MAP(CETTUPCtrl, COleControl)
END_EVENT_MAP()



// 属性页

// TODO: 按需要添加更多属性页。请记住增加计数!
BEGIN_PROPPAGEIDS(CETTUPCtrl, 1)
	PROPPAGEID(CETTUPPropPage::guid)
END_PROPPAGEIDS(CETTUPCtrl)



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTUPCtrl, "ETTUP.ETTUPCtrl.1",
	0xdc25e28d, 0xc0c6, 0x4f6c, 0xb9, 0xe5, 0x32, 0x12, 0x14, 0x6c, 0x5e, 0xbd)



// 键入库 ID 和版本

IMPLEMENT_OLETYPELIB(CETTUPCtrl, _tlid, _wVerMajor, _wVerMinor)



// 接口 ID

const IID BASED_CODE IID_DETTUP =
		{ 0xE4350F3B, 0x8F66, 0x4871, { 0x8A, 0x33, 0x81, 0x51, 0x52, 0x76, 0xA0, 0x1D } };
const IID BASED_CODE IID_DETTUPEvents =
		{ 0xFDC4BAFF, 0x5206, 0x428D, { 0x8C, 0xD, 0xD8, 0x92, 0x1, 0xD2, 0xEF, 0x7F } };



// 控件类型信息

static const DWORD BASED_CODE _dwETTUPOleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTUPCtrl, IDS_ETTUP, _dwETTUPOleMisc)



// CETTUPCtrl::CETTUPCtrlFactory::UpdateRegistry -
// 添加或移除 CETTUPCtrl 的系统注册表项

BOOL CETTUPCtrl::CETTUPCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTUP,
			IDB_ETTUP,
			afxRegApartmentThreading,
			_dwETTUPOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTUPCtrl::CETTUPCtrl - 构造函数

CETTUPCtrl::CETTUPCtrl()
{
	InitializeIIDs(&IID_DETTUP, &IID_DETTUPEvents);
	// TODO: 在此初始化控件的实例数据。
}



// CETTUPCtrl::~CETTUPCtrl - 析构函数

CETTUPCtrl::~CETTUPCtrl()
{
	// TODO: 在此清理控件的实例数据。
}



// CETTUPCtrl::OnDraw - 绘图函数

void CETTUPCtrl::OnDraw(
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



// CETTUPCtrl::DoPropExchange - 持久性支持

void CETTUPCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: 为每个持久的自定义属性调用 PX_ 函数。
}



// CETTUPCtrl::GetControlFlags -
// 自定义 MFC 的 ActiveX 控件实现的标志。
//
DWORD CETTUPCtrl::GetControlFlags()
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



// CETTUPCtrl::OnResetState - 将控件重置为默认状态

void CETTUPCtrl::OnResetState()
{
	COleControl::OnResetState();  // 重置 DoPropExchange 中找到的默认值

	// TODO: 在此重置任意其他控件状态。
}



// CETTUPCtrl 消息处理程序

void CETTUPCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnSerialNoChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnDeviceNoChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnBusinessNoChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnBalanceChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnAllowBalanceChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnRetCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnServerIpChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnServerPortChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

void CETTUPCtrl::OnOldSerialNoChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加属性处理程序代码

	SetModifiedFlag();
}

BSTR CETTUPCtrl::UnUnionPayPack(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: 在此添加调度处理程序代码

	return strResult.AllocSysString();
}

BSTR CETTUPCtrl::UPSendData(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: 在此添加调度处理程序代码

	return strResult.AllocSysString();
}

BSTR CETTUPCtrl::Make0800(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: 在此添加调度处理程序代码

	return strResult.AllocSysString();
}

BSTR CETTUPCtrl::Make0200(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: 在此添加调度处理程序代码

	return strResult.AllocSysString();
}

BSTR CETTUPCtrl::Make0400(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: 在此添加调度处理程序代码

	return strResult.AllocSysString();
}

void CETTUPCtrl::QueryBalance(LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
}

void CETTUPCtrl::Pay(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
}

void CETTUPCtrl::SignIn(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
}

void CETTUPCtrl::PayBack(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: 在此添加调度处理程序代码
}

void CETTUPCtrl::Log(LPCTSTR str)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	LogLog::getLogLog()->setInternalDebugging(true);
	//Logger root = Logger::getRoot();
	try {
/*
		char   lpszPath[1024]; 
		memset(lpszPath,0,sizeof(char)*1024); 
        GetModuleFileName(AfxGetInstanceHandle(),(LPWCH)lpszPath,1024); 
		char   lpszPath2[1024]; 
		sprintf(lpszPath2,   "%s\\log4cplus.properties ",lpszPath); 
		MessageBox((LPCTSTR)lpszPath); 
        MessageBox((LPCTSTR)lpszPath2); 
*/

		//MessageBox(_T("1"),_T("Title(标题)"),MB_OK); 
		PropertyConfigurator::doConfigure(LOG4CPLUS_TEXT("d:\\ocx\\log4cplus.properties"));
		//MessageBox(_T("2"),_T("Title(标题)"),MB_OK); 
		Logger fileCat = Logger::getInstance(LOG4CPLUS_TEXT("UnionPayLogger"));
		LOG4CPLUS_WARN(fileCat, (char*)str);
	}
	catch(...) {
		MessageBox(_T("exception"),_T("Title(标题)"),MB_OK); 
		//LOG4CPLUS_FATAL(root, "Exception occured...");
	}
}
