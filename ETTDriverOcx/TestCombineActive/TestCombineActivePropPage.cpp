// TestCombineActivePropPage.cpp : CTestCombineActivePropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "TestCombineActive.h"
#include "TestCombineActivePropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombineActivePropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CTestCombineActivePropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CTestCombineActivePropPage, "TESTCOMBINEACT.TestCombineActPropPage.1",
	0xa02477a0, 0xfc63, 0x4deb, 0xb1, 0x78, 0x20, 0xbe, 0x1b, 0x7a, 0xdf, 0x99)



// CTestCombineActivePropPage::CTestCombineActivePropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CTestCombineActivePropPage ��ϵͳע�����

BOOL CTestCombineActivePropPage::CTestCombineActivePropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_TESTCOMBINEACTIVE_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CTestCombineActivePropPage::CTestCombineActivePropPage - ���캯��

CTestCombineActivePropPage::CTestCombineActivePropPage() :
	COlePropertyPage(IDD, IDS_TESTCOMBINEACTIVE_PPG_CAPTION)
{
}



// CTestCombineActivePropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CTestCombineActivePropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CTestCombineActivePropPage ��Ϣ�������
