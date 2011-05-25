// TestMfcActivexCtrl.cpp : CTestMfcActivexCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "TestMfcActivex.h"
#include "TestMfcActivexCtrl.h"
#include "TestMfcActivexPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestMfcActivexCtrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CTestMfcActivexCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CTestMfcActivexCtrl, COleControl)
	DISP_FUNCTION_ID(CTestMfcActivexCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CTestMfcActivexCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CTestMfcActivexCtrl, 1)
	PROPPAGEID(CTestMfcActivexPropPage::guid)
END_PROPPAGEIDS(CTestMfcActivexCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CTestMfcActivexCtrl, "TESTMFCACTIVEX.TestMfcActivexCtrl.1",
	0xe5df618a, 0xe0cc, 0x4f68, 0xac, 0xb2, 0x15, 0x5a, 0x1d, 0x3b, 0xaf, 0xca)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CTestMfcActivexCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DTestMfcActivex =
		{ 0x8BB622EB, 0x3854, 0x4B1E, { 0xB9, 0x75, 0x1F, 0x75, 0xBE, 0xAD, 0x42, 0xF5 } };
const IID BASED_CODE IID_DTestMfcActivexEvents =
		{ 0xD8505EB0, 0x1BCD, 0x4E2F, { 0x91, 0xAD, 0x11, 0x5E, 0xF4, 0xCF, 0xAE, 0xF8 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwTestMfcActivexOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CTestMfcActivexCtrl, IDS_TESTMFCACTIVEX, _dwTestMfcActivexOleMisc)



// CTestMfcActivexCtrl::CTestMfcActivexCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CTestMfcActivexCtrl ��ϵͳע�����

BOOL CTestMfcActivexCtrl::CTestMfcActivexCtrlFactory::UpdateRegistry(BOOL bRegister)
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



// CTestMfcActivexCtrl::CTestMfcActivexCtrl - ���캯��

CTestMfcActivexCtrl::CTestMfcActivexCtrl()
{
	InitializeIIDs(&IID_DTestMfcActivex, &IID_DTestMfcActivexEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CTestMfcActivexCtrl::~CTestMfcActivexCtrl - ��������

CTestMfcActivexCtrl::~CTestMfcActivexCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CTestMfcActivexCtrl::OnDraw - ��ͼ����

void CTestMfcActivexCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CTestMfcActivexCtrl::DoPropExchange - �־���֧��

void CTestMfcActivexCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CTestMfcActivexCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CTestMfcActivexCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// ���ô������ڼ��ɼ���ؼ���
	// TODO: ��д�ؼ�����Ϣ�������ʱ����ʹ��
	//		m_hWnd ��Ա����֮ǰӦ���ȼ������ֵ�Ƿ�
	//		�� null��
	dwFlags |= windowlessActivate;
	return dwFlags;
}



// CTestMfcActivexCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CTestMfcActivexCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CTestMfcActivexCtrl::AboutBox - ���û���ʾ�����ڡ���

void CTestMfcActivexCtrl::AboutBox()
{
	CDialog dlgAbout(IDD_ABOUTBOX_TESTMFCACTIVEX);
	dlgAbout.DoModal();
}



// CTestMfcActivexCtrl ��Ϣ�������
