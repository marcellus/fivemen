// TestCombine2Ctrl.cpp : CTestCombine2Ctrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "TestCombine2.h"
#include "TestCombine2Ctrl.h"
#include "TestCombine2PropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombine2Ctrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CTestCombine2Ctrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CTestCombine2Ctrl, COleControl)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CTestCombine2Ctrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CTestCombine2Ctrl, 1)
	PROPPAGEID(CTestCombine2PropPage::guid)
END_PROPPAGEIDS(CTestCombine2Ctrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CTestCombine2Ctrl, "TESTCOMBINE2.TestCombine2Ctrl.1",
	0xeecae990, 0x8734, 0x4964, 0xbb, 0xc5, 0x30, 0x5, 0x25, 0xe9, 0x36, 0x2c)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CTestCombine2Ctrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DTestCombine2 =
		{ 0x7265DE52, 0xFDE8, 0x44C9, { 0xB6, 0xAA, 0xAD, 0xA3, 0x41, 0xAE, 0x33, 0x38 } };
const IID BASED_CODE IID_DTestCombine2Events =
		{ 0x4757EEFE, 0x940C, 0x4C06, { 0xBA, 0xD, 0xB6, 0x54, 0x50, 0xE, 0x39, 0xE7 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwTestCombine2OleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CTestCombine2Ctrl, IDS_TESTCOMBINE2, _dwTestCombine2OleMisc)



// CTestCombine2Ctrl::CTestCombine2CtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CTestCombine2Ctrl ��ϵͳע�����

BOOL CTestCombine2Ctrl::CTestCombine2CtrlFactory::UpdateRegistry(BOOL bRegister)
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



// CTestCombine2Ctrl::CTestCombine2Ctrl - ���캯��

CTestCombine2Ctrl::CTestCombine2Ctrl()
{
	InitializeIIDs(&IID_DTestCombine2, &IID_DTestCombine2Events);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CTestCombine2Ctrl::~CTestCombine2Ctrl - ��������

CTestCombine2Ctrl::~CTestCombine2Ctrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CTestCombine2Ctrl::OnDraw - ��ͼ����

void CTestCombine2Ctrl::OnDraw(
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



// CTestCombine2Ctrl::DoPropExchange - �־���֧��

void CTestCombine2Ctrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CTestCombine2Ctrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CTestCombine2Ctrl::GetControlFlags()
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



// CTestCombine2Ctrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CTestCombine2Ctrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CTestCombine2Ctrl ��Ϣ�������
