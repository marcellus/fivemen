// ETTCashPropPage.cpp : CETTCashPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTCash.h"
#include "ETTCashPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTCashPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTCashPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTCashPropPage, "ETTCASH.ETTCashPropPage.1",
	0xf6225a61, 0xb90e, 0x4f54, 0xb7, 0x9f, 0x33, 0xe3, 0xd5, 0x6c, 0x2b, 0xd8)



// CETTCashPropPage::CETTCashPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTCashPropPage ��ϵͳע�����

BOOL CETTCashPropPage::CETTCashPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTCASH_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTCashPropPage::CETTCashPropPage - ���캯��

CETTCashPropPage::CETTCashPropPage() :
	COlePropertyPage(IDD, IDS_ETTCASH_PPG_CAPTION)
{
}



// CETTCashPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTCashPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTCashPropPage ��Ϣ�������
