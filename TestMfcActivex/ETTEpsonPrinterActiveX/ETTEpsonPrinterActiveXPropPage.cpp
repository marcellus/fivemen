// ETTEpsonPrinterActiveXPropPage.cpp : CETTEpsonPrinterActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTEpsonPrinterActiveX.h"
#include "ETTEpsonPrinterActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTEpsonPrinterActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTEpsonPrinterActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTEpsonPrinterActiveXPropPage, "ETTEPSONPRINTE.ETTEpsonPrintePropPage.1",
	0x396b4660, 0x766a, 0x49cf, 0xbe, 0xb8, 0xc4, 0x9d, 0x4d, 0x31, 0x35, 0x4c)



// CETTEpsonPrinterActiveXPropPage::CETTEpsonPrinterActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTEpsonPrinterActiveXPropPage ��ϵͳע�����

BOOL CETTEpsonPrinterActiveXPropPage::CETTEpsonPrinterActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTEPSONPRINTERACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTEpsonPrinterActiveXPropPage::CETTEpsonPrinterActiveXPropPage - ���캯��

CETTEpsonPrinterActiveXPropPage::CETTEpsonPrinterActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTEPSONPRINTERACTIVEX_PPG_CAPTION)
{
}



// CETTEpsonPrinterActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTEpsonPrinterActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTEpsonPrinterActiveXPropPage ��Ϣ�������
