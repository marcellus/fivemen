// ETTSelfIDCardActiveXPropPage.cpp : CETTSelfIDCardActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTSelfIDCardActiveX.h"
#include "ETTSelfIDCardActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfIDCardActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTSelfIDCardActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTSelfIDCardActiveXPropPage, "ETTSELFIDCARDA.ETTSelfIDCardAPropPage.1",
	0x1da26e8d, 0x4f37, 0x4e8f, 0x9b, 0x20, 0x51, 0xc0, 0xc1, 0x6e, 0x38, 0xb6)



// CETTSelfIDCardActiveXPropPage::CETTSelfIDCardActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTSelfIDCardActiveXPropPage ��ϵͳע�����

BOOL CETTSelfIDCardActiveXPropPage::CETTSelfIDCardActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTSELFIDCARDACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTSelfIDCardActiveXPropPage::CETTSelfIDCardActiveXPropPage - ���캯��

CETTSelfIDCardActiveXPropPage::CETTSelfIDCardActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTSELFIDCARDACTIVEX_PPG_CAPTION)
{
}



// CETTSelfIDCardActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTSelfIDCardActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTSelfIDCardActiveXPropPage ��Ϣ�������
