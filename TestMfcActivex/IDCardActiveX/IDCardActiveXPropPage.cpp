// IDCardActiveXPropPage.cpp : CIDCardActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "IDCardActiveX.h"
#include "IDCardActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CIDCardActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CIDCardActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CIDCardActiveXPropPage, "IDCARDACTIVEX.IDCardActiveXPropPage.1",
	0x48a89b0f, 0x50e9, 0x45b5, 0x8b, 0x78, 0xa0, 0x2d, 0xef, 0xe3, 0xf1, 0x62)



// CIDCardActiveXPropPage::CIDCardActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CIDCardActiveXPropPage ��ϵͳע�����

BOOL CIDCardActiveXPropPage::CIDCardActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_IDCARDACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CIDCardActiveXPropPage::CIDCardActiveXPropPage - ���캯��

CIDCardActiveXPropPage::CIDCardActiveXPropPage() :
	COlePropertyPage(IDD, IDS_IDCARDACTIVEX_PPG_CAPTION)
{
}



// CIDCardActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CIDCardActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CIDCardActiveXPropPage ��Ϣ�������
