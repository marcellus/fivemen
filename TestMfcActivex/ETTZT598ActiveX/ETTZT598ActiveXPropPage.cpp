// ETTZT598ActiveXPropPage.cpp : CETTZT598ActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTZT598ActiveX.h"
#include "ETTZT598ActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTZT598ActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTZT598ActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTZT598ActiveXPropPage, "ETTZT598ACTIVE.ETTZT598ActivePropPage.1",
	0xad2e36cc, 0x2bed, 0x4951, 0xb4, 0x29, 0xa3, 0x97, 0x2d, 0x5e, 0x9d, 0xaf)



// CETTZT598ActiveXPropPage::CETTZT598ActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTZT598ActiveXPropPage ��ϵͳע�����

BOOL CETTZT598ActiveXPropPage::CETTZT598ActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTZT598ACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTZT598ActiveXPropPage::CETTZT598ActiveXPropPage - ���캯��

CETTZT598ActiveXPropPage::CETTZT598ActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTZT598ACTIVEX_PPG_CAPTION)
{
}



// CETTZT598ActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTZT598ActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTZT598ActiveXPropPage ��Ϣ�������
