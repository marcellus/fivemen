// TestCombine3Ctrl.cpp : CTestCombine3Ctrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "TestCombine3.h"
#include "TestCombine3Ctrl.h"
#include "TestCombine3PropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombine3Ctrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CTestCombine3Ctrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CTestCombine3Ctrl, COleControl)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CTestCombine3Ctrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CTestCombine3Ctrl, 1)
	PROPPAGEID(CTestCombine3PropPage::guid)
END_PROPPAGEIDS(CTestCombine3Ctrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CTestCombine3Ctrl, "TESTCOMBINE3.TestCombine3Ctrl.1",
	0x164cfe46, 0x8493, 0x4bdd, 0x95, 0x8, 0x5, 0x27, 0x65, 0xb5, 0xf1, 0x4f)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CTestCombine3Ctrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DTestCombine3 =
		{ 0x16E1BCDC, 0x2C5F, 0x42E7, { 0x87, 0x96, 0x66, 0xAA, 0x15, 0x79, 0x2A, 0xDF } };
const IID BASED_CODE IID_DTestCombine3Events =
		{ 0xEA3FEAEB, 0x49C, 0x43BD, { 0x9A, 0x70, 0xC6, 0x6F, 0xF3, 0x69, 0x5D, 0xBF } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwTestCombine3OleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CTestCombine3Ctrl, IDS_TESTCOMBINE3, _dwTestCombine3OleMisc)



// CTestCombine3Ctrl::CTestCombine3CtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CTestCombine3Ctrl ��ϵͳע�����

BOOL CTestCombine3Ctrl::CTestCombine3CtrlFactory::UpdateRegistry(BOOL bRegister)
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



// CTestCombine3Ctrl::CTestCombine3Ctrl - ���캯��

CTestCombine3Ctrl::CTestCombine3Ctrl()
{
	InitializeIIDs(&IID_DTestCombine3, &IID_DTestCombine3Events);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CTestCombine3Ctrl::~CTestCombine3Ctrl - ��������

CTestCombine3Ctrl::~CTestCombine3Ctrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CTestCombine3Ctrl::OnDraw - ��ͼ����

void CTestCombine3Ctrl::OnDraw(
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



// CTestCombine3Ctrl::DoPropExchange - �־���֧��

void CTestCombine3Ctrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CTestCombine3Ctrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CTestCombine3Ctrl::GetControlFlags()
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



// CTestCombine3Ctrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CTestCombine3Ctrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CTestCombine3Ctrl ��Ϣ�������
