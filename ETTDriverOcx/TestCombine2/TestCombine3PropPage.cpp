// TestCombine3PropPage.cpp : CTestCombine3PropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "TestCombine3.h"
#include "TestCombine3PropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombine3PropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CTestCombine3PropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CTestCombine3PropPage, "TESTCOMBINE3.TestCombine3PropPage.1",
					   0x6514336c, 0x3825, 0x489b, 0xa5, 0xd7, 0x46, 0x54, 0xa9, 0x2, 0xf9, 0x72)



					   // CTestCombine3PropPage::CTestCombine3PropPageFactory::UpdateRegistry -
					   // ��ӻ��Ƴ� CTestCombine3PropPage ��ϵͳע�����

					   BOOL CTestCombine3PropPage::CTestCombine3PropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
		m_clsid, IDS_TESTCOMBINE3_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CTestCombine3PropPage::CTestCombine3PropPage - ���캯��

CTestCombine3PropPage::CTestCombine3PropPage() :
COlePropertyPage(IDD, IDS_TESTCOMBINE3_PPG_CAPTION)
{
}



// CTestCombine3PropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CTestCombine3PropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CTestCombine3PropPage ��Ϣ�������
