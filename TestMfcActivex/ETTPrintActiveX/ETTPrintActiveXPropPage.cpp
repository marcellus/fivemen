// ETTPrintActiveXPropPage.cpp : CETTPrintActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTPrintActiveX.h"
#include "ETTPrintActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTPrintActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTPrintActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTPrintActiveXPropPage, "ETTPRINTACTIVE.ETTPrintActivePropPage.1",
	0x40c250cf, 0x120e, 0x4075, 0xb0, 0xa4, 0x4c, 0x5, 0xc2, 0x86, 0x11, 0xcc)



// CETTPrintActiveXPropPage::CETTPrintActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTPrintActiveXPropPage ��ϵͳע�����

BOOL CETTPrintActiveXPropPage::CETTPrintActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTPRINTACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTPrintActiveXPropPage::CETTPrintActiveXPropPage - ���캯��

CETTPrintActiveXPropPage::CETTPrintActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTPRINTACTIVEX_PPG_CAPTION)
{
}



// CETTPrintActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTPrintActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTPrintActiveXPropPage ��Ϣ�������
