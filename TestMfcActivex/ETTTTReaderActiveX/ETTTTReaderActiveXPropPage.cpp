// ETTTTReaderActiveXPropPage.cpp : CETTTTReaderActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "ETTTTReaderActiveX.h"
#include "ETTTTReaderActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTTTReaderActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTTTReaderActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTTTReaderActiveXPropPage, "ETTTTREADERACT.ETTTTReaderActPropPage.1",
	0x777cf571, 0xc785, 0x4d3d, 0x9d, 0xfa, 0x47, 0x65, 0xcf, 0xaf, 0xa3, 0x17)



// CETTTTReaderActiveXPropPage::CETTTTReaderActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTTTReaderActiveXPropPage ��ϵͳע�����

BOOL CETTTTReaderActiveXPropPage::CETTTTReaderActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTTTREADERACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTTTReaderActiveXPropPage::CETTTTReaderActiveXPropPage - ���캯��

CETTTTReaderActiveXPropPage::CETTTTReaderActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTTTREADERACTIVEX_PPG_CAPTION)
{
}



// CETTTTReaderActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CETTTTReaderActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTTTReaderActiveXPropPage ��Ϣ�������
