// ETTPrinterPropPage.cpp : CETTPrinterPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTPrinter.h"
#include "ETTPrinterPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTPrinterPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTPrinterPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTPrinterPropPage, "ETTPRINTER.ETTPrinterPropPage.1",
	0xc940102b, 0xd656, 0x4133, 0x83, 0x87, 0x7e, 0x61, 0x49, 0x3f, 0xa3, 0x51)



// CETTPrinterPropPage::CETTPrinterPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTPrinterPropPage ��ϵͳע�����

BOOL CETTPrinterPropPage::CETTPrinterPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTPRINTER_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTPrinterPropPage::CETTPrinterPropPage - ���캯��

CETTPrinterPropPage::CETTPrinterPropPage() :
	COlePropertyPage(IDD, IDS_ETTPRINTER_PPG_CAPTION)
{
}



// CETTPrinterPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTPrinterPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTPrinterPropPage ��Ϣ�������
