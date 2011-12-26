// TestCombineActiveCtrl.cpp : CTestCombineActiveCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "TestCombineActive.h"
#include "TestCombineActiveCtrl.h"
#include "TestCombineActivePropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombineActiveCtrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CTestCombineActiveCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CTestCombineActiveCtrl, COleControl)
	DISP_FUNCTION_ID(CTestCombineActiveCtrl, "HelloWordA", dispidHelloWordA, HelloWordA, VT_I2, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CTestCombineActiveCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CTestCombineActiveCtrl, 1)
	PROPPAGEID(CTestCombineActivePropPage::guid)
END_PROPPAGEIDS(CTestCombineActiveCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CTestCombineActiveCtrl, "TESTCOMBINEACTIV.TestCombineActivCtrl.1",
	0x8128503e, 0x4d53, 0x4b22, 0xab, 0xb3, 0x88, 0xa2, 0x8c, 0x89, 0x91, 0xa1)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CTestCombineActiveCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DTestCombineActive =
		{ 0xC761E55F, 0xDED9, 0x41BD, { 0xB4, 0x46, 0x22, 0x36, 0x5F, 0x85, 0x1E, 0x1A } };
const IID BASED_CODE IID_DTestCombineActiveEvents =
		{ 0x1C0CB663, 0xD6DC, 0x4AED, { 0xB3, 0xE4, 0xF0, 0x8B, 0xE4, 0x3B, 0x7B, 0x45 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwTestCombineActiveOleMisc =
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CTestCombineActiveCtrl, IDS_TESTCOMBINEACTIVE, _dwTestCombineActiveOleMisc)



// CTestCombineActiveCtrl::CTestCombineActiveCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CTestCombineActiveCtrl ��ϵͳע�����

BOOL CTestCombineActiveCtrl::CTestCombineActiveCtrlFactory::UpdateRegistry(BOOL bRegister)
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



// CTestCombineActiveCtrl::CTestCombineActiveCtrl - ���캯��

CTestCombineActiveCtrl::CTestCombineActiveCtrl()
{
	InitializeIIDs(&IID_DTestCombineActive, &IID_DTestCombineActiveEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CTestCombineActiveCtrl::~CTestCombineActiveCtrl - ��������

CTestCombineActiveCtrl::~CTestCombineActiveCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CTestCombineActiveCtrl::OnDraw - ��ͼ����

void CTestCombineActiveCtrl::OnDraw(
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



// CTestCombineActiveCtrl::DoPropExchange - �־���֧��

void CTestCombineActiveCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CTestCombineActiveCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CTestCombineActiveCtrl::GetControlFlags()
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



// CTestCombineActiveCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CTestCombineActiveCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CTestCombineActiveCtrl ��Ϣ�������

SHORT CTestCombineActiveCtrl::HelloWordA(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������

	return 1;
}
