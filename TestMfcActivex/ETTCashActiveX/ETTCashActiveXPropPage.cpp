// ETTCashActiveXPropPage.cpp : CETTCashActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTCashActiveX.h"
#include "ETTCashActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTCashActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTCashActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTCashActiveXPropPage, "ETTCASHACTIVEX.ETTCashActiveXPropPage.1",
	0x52d52a13, 0xe972, 0x4820, 0xbb, 0x8e, 0x79, 0xaa, 0x58, 0x5c, 0xbf, 0x38)



// CETTCashActiveXPropPage::CETTCashActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTCashActiveXPropPage ��ϵͳע�����

BOOL CETTCashActiveXPropPage::CETTCashActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTCASHACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTCashActiveXPropPage::CETTCashActiveXPropPage - ���캯��

CETTCashActiveXPropPage::CETTCashActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTCASHACTIVEX_PPG_CAPTION)
{
}



// CETTCashActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTCashActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTCashActiveXPropPage ��Ϣ�������
