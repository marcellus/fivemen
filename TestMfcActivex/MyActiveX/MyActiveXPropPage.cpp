// MyActiveXPropPage.cpp : CMyActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "MyActiveX.h"
#include "MyActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CMyActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CMyActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CMyActiveXPropPage, "MYACTIVEX.MyActiveXPropPage.1",
	0x7846e2c2, 0x4e03, 0x481f, 0x92, 0x42, 0x3b, 0x48, 0xad, 0x50, 0xa7, 0x5d)



// CMyActiveXPropPage::CMyActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CMyActiveXPropPage ��ϵͳע�����

BOOL CMyActiveXPropPage::CMyActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_MYACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CMyActiveXPropPage::CMyActiveXPropPage - ���캯��

CMyActiveXPropPage::CMyActiveXPropPage() :
	COlePropertyPage(IDD, IDS_MYACTIVEX_PPG_CAPTION)
{
}



// CMyActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CMyActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CMyActiveXPropPage ��Ϣ�������
