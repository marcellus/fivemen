// ETTSelfPrinterActiveXPropPage.cpp : CETTSelfPrinterActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTSelfPrinterActiveX.h"
#include "ETTSelfPrinterActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfPrinterActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTSelfPrinterActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTSelfPrinterActiveXPropPage, "ETTSELFPRINTER.ETTSelfPrinterPropPage.1",
	0xa837e89f, 0x9453, 0x49a6, 0xb8, 0x50, 0xa9, 0xdd, 0x2, 0x12, 0xf3, 0xc8)



// CETTSelfPrinterActiveXPropPage::CETTSelfPrinterActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTSelfPrinterActiveXPropPage ��ϵͳע�����

BOOL CETTSelfPrinterActiveXPropPage::CETTSelfPrinterActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTSELFPRINTERACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTSelfPrinterActiveXPropPage::CETTSelfPrinterActiveXPropPage - ���캯��

CETTSelfPrinterActiveXPropPage::CETTSelfPrinterActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTSELFPRINTERACTIVEX_PPG_CAPTION)
{
}



// CETTSelfPrinterActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTSelfPrinterActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTSelfPrinterActiveXPropPage ��Ϣ�������
