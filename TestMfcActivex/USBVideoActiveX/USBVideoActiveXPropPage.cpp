// USBVideoActiveXPropPage.cpp : CUSBVideoActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "USBVideoActiveX.h"
#include "USBVideoActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CUSBVideoActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CUSBVideoActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CUSBVideoActiveXPropPage, "USBVIDEOACTIVE.USBVideoActivePropPage.1",
	0xe6ff64f8, 0xfaa0, 0x4e99, 0x84, 0x3c, 0xa5, 0x20, 0xea, 0xe6, 0x3b, 0x78)



// CUSBVideoActiveXPropPage::CUSBVideoActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CUSBVideoActiveXPropPage ��ϵͳע�����

BOOL CUSBVideoActiveXPropPage::CUSBVideoActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_USBVIDEOACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CUSBVideoActiveXPropPage::CUSBVideoActiveXPropPage - ���캯��

CUSBVideoActiveXPropPage::CUSBVideoActiveXPropPage() :
	COlePropertyPage(IDD, IDS_USBVIDEOACTIVEX_PPG_CAPTION)
{
}



// CUSBVideoActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CUSBVideoActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CUSBVideoActiveXPropPage ��Ϣ�������
