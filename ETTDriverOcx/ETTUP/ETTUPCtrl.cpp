// ETTUPCtrl.cpp : CETTUPCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTUP.h"
#include "ETTUPCtrl.h"
#include "ETTUPPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTUPCtrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTUPCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

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



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTUPCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTUPCtrl, 1)
	PROPPAGEID(CETTUPPropPage::guid)
END_PROPPAGEIDS(CETTUPCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTUPCtrl, "ETTUP.ETTUPCtrl.1",
	0xdc25e28d, 0xc0c6, 0x4f6c, 0xb9, 0xe5, 0x32, 0x12, 0x14, 0x6c, 0x5e, 0xbd)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTUPCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DETTUP =
		{ 0xE4350F3B, 0x8F66, 0x4871, { 0x8A, 0x33, 0x81, 0x51, 0x52, 0x76, 0xA0, 0x1D } };
const IID BASED_CODE IID_DETTUPEvents =
		{ 0xFDC4BAFF, 0x5206, 0x428D, { 0x8C, 0xD, 0xD8, 0x92, 0x1, 0xD2, 0xEF, 0x7F } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTUPOleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTUPCtrl, IDS_ETTUP, _dwETTUPOleMisc)



// CETTUPCtrl::CETTUPCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTUPCtrl ��ϵͳע�����

BOOL CETTUPCtrl::CETTUPCtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: ��֤���Ŀؼ��Ƿ���ϵ�Ԫģ���̴߳������
	// �йظ�����Ϣ����ο� MFC ����˵�� 64��
	// ������Ŀؼ������ϵ�Ԫģ�͹�����
	// �����޸����´��룬��������������
	// afxRegApartmentThreading ��Ϊ 0��

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



// CETTUPCtrl::CETTUPCtrl - ���캯��

CETTUPCtrl::CETTUPCtrl()
{
	InitializeIIDs(&IID_DETTUP, &IID_DETTUPEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTUPCtrl::~CETTUPCtrl - ��������

CETTUPCtrl::~CETTUPCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTUPCtrl::OnDraw - ��ͼ����

void CETTUPCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);

	if (!IsOptimizedDraw())
	{
		// ������֧���Ż���ͼ��

		// TODO: ������κ� GDI ����ѡ�뵽�豸������ *pdc �У�
		//		���ڴ˴��ָ���ǰѡ���Ķ���
	}
}



// CETTUPCtrl::DoPropExchange - �־���֧��

void CETTUPCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTUPCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTUPCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// ���ô������ڼ��ɼ���ؼ���
	// TODO: ��д�ؼ�����Ϣ�������ʱ����ʹ��
	//		m_hWnd ��Ա����֮ǰӦ���ȼ������ֵ�Ƿ�
	//		�� null��
	dwFlags |= windowlessActivate;

	// �ؼ�ͨ������ԭ�豸�������е�
	// ԭʼ GDI ���󣬿����Ż����� OnDraw ������
	dwFlags |= canOptimizeDraw;
	return dwFlags;
}



// CETTUPCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTUPCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTUPCtrl ��Ϣ�������

void CETTUPCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnSerialNoChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnDeviceNoChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnBusinessNoChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnBalanceChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnAllowBalanceChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnRetCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnServerIpChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnServerPortChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTUPCtrl::OnOldSerialNoChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

BSTR CETTUPCtrl::UnUnionPayPack(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: �ڴ���ӵ��ȴ���������

	return strResult.AllocSysString();
}

BSTR CETTUPCtrl::UPSendData(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: �ڴ���ӵ��ȴ���������

	return strResult.AllocSysString();
}

BSTR CETTUPCtrl::Make0800(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: �ڴ���ӵ��ȴ���������

	return strResult.AllocSysString();
}

BSTR CETTUPCtrl::Make0200(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: �ڴ���ӵ��ȴ���������

	return strResult.AllocSysString();
}

BSTR CETTUPCtrl::Make0400(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: �ڴ���ӵ��ȴ���������

	return strResult.AllocSysString();
}

void CETTUPCtrl::QueryBalance(LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTUPCtrl::Pay(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTUPCtrl::SignIn(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTUPCtrl::PayBack(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
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

		//MessageBox(_T("1"),_T("Title(����)"),MB_OK); 
		PropertyConfigurator::doConfigure(LOG4CPLUS_TEXT("d:\\ocx\\log4cplus.properties"));
		//MessageBox(_T("2"),_T("Title(����)"),MB_OK); 
		Logger fileCat = Logger::getInstance(LOG4CPLUS_TEXT("UnionPayLogger"));
		LOG4CPLUS_WARN(fileCat, (char*)str);
	}
	catch(...) {
		MessageBox(_T("exception"),_T("Title(����)"),MB_OK); 
		//LOG4CPLUS_FATAL(root, "Exception occured...");
	}
}
