// TestMfcActivexPropPage.cpp : CTestMfcActivexPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "TestMfcActivex.h"
#include "TestMfcActivexPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestMfcActivexPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CTestMfcActivexPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CTestMfcActivexPropPage, "TESTMFCACTIVEX.TestMfcActivexPropPage.1",
	0xb06096b1, 0x4a51, 0x4141, 0xa0, 0xf3, 0x6, 0xa5, 0x87, 0x1e, 0xf5, 0xa8)



// CTestMfcActivexPropPage::CTestMfcActivexPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CTestMfcActivexPropPage ��ϵͳע�����

BOOL CTestMfcActivexPropPage::CTestMfcActivexPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_TESTMFCACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CTestMfcActivexPropPage::CTestMfcActivexPropPage - ���캯��

CTestMfcActivexPropPage::CTestMfcActivexPropPage() :
	COlePropertyPage(IDD, IDS_TESTMFCACTIVEX_PPG_CAPTION)
{
}



// CTestMfcActivexPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CTestMfcActivexPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CTestMfcActivexPropPage ��Ϣ�������
