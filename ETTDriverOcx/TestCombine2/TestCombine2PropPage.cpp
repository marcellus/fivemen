// TestCombine2PropPage.cpp : CTestCombine2PropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "TestCombine2.h"
#include "TestCombine2PropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombine2PropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CTestCombine2PropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CTestCombine2PropPage, "TESTCOMBINE2.TestCombine2PropPage.1",
	0xa8364f1f, 0x8a77, 0x4622, 0x9b, 0xd8, 0x95, 0x97, 0x98, 0x58, 0x72, 0xdf)



// CTestCombine2PropPage::CTestCombine2PropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CTestCombine2PropPage ��ϵͳע�����

BOOL CTestCombine2PropPage::CTestCombine2PropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_TESTCOMBINE2_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CTestCombine2PropPage::CTestCombine2PropPage - ���캯��

CTestCombine2PropPage::CTestCombine2PropPage() :
	COlePropertyPage(IDD, IDS_TESTCOMBINE2_PPG_CAPTION)
{
}



// CTestCombine2PropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CTestCombine2PropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CTestCombine2PropPage ��Ϣ�������
