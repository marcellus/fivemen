// ETTUPPropPage.cpp : CETTUPPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTUP.h"
#include "ETTUPPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTUPPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTUPPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTUPPropPage, "ETTUP.ETTUPPropPage.1",
	0x83728187, 0x2a5e, 0x4627, 0xb9, 0x20, 0x98, 0xbe, 0xfc, 0x60, 0x20, 0xec)



// CETTUPPropPage::CETTUPPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTUPPropPage ��ϵͳע�����

BOOL CETTUPPropPage::CETTUPPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTUP_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTUPPropPage::CETTUPPropPage - ���캯��

CETTUPPropPage::CETTUPPropPage() :
	COlePropertyPage(IDD, IDS_ETTUP_PPG_CAPTION)
{
}



// CETTUPPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTUPPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTUPPropPage ��Ϣ�������
