// ETTDrvA8PropPage.cpp : CETTDrvA8PropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTDrvA8.h"
#include "ETTDrvA8PropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTDrvA8PropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTDrvA8PropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTDrvA8PropPage, "ETTDRVA8.ETTDrvA8PropPage.1",
	0xb586128c, 0xc834, 0x4af5, 0x9f, 0x87, 0x5d, 0x55, 0xf, 0x40, 0x6e, 0xd8)



// CETTDrvA8PropPage::CETTDrvA8PropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTDrvA8PropPage ��ϵͳע�����

BOOL CETTDrvA8PropPage::CETTDrvA8PropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTDRVA8_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTDrvA8PropPage::CETTDrvA8PropPage - ���캯��

CETTDrvA8PropPage::CETTDrvA8PropPage() :
	COlePropertyPage(IDD, IDS_ETTDRVA8_PPG_CAPTION)
{
}



// CETTDrvA8PropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTDrvA8PropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTDrvA8PropPage ��Ϣ�������
