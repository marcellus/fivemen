// ETTSelfUSBVideoActiveXPropPage.cpp : CETTSelfUSBVideoActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTSelfUSBVideoActiveX.h"
#include "ETTSelfUSBVideoActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfUSBVideoActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTSelfUSBVideoActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTSelfUSBVideoActiveXPropPage, "ETTSELFUSBVIDE.ETTSelfUSBVidePropPage.1",
	0x1fc1a563, 0x8a70, 0x4a69, 0x9b, 0x2b, 0x49, 0x1c, 0xef, 0xcb, 0x60, 0xd4)



// CETTSelfUSBVideoActiveXPropPage::CETTSelfUSBVideoActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTSelfUSBVideoActiveXPropPage ��ϵͳע�����

BOOL CETTSelfUSBVideoActiveXPropPage::CETTSelfUSBVideoActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTSELFUSBVIDEOACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTSelfUSBVideoActiveXPropPage::CETTSelfUSBVideoActiveXPropPage - ���캯��

CETTSelfUSBVideoActiveXPropPage::CETTSelfUSBVideoActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTSELFUSBVIDEOACTIVEX_PPG_CAPTION)
{
}



// CETTSelfUSBVideoActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTSelfUSBVideoActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTSelfUSBVideoActiveXPropPage ��Ϣ�������
