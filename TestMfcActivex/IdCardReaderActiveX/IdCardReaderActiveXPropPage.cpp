// IdCardReaderActiveXPropPage.cpp : CIdCardReaderActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "IdCardReaderActiveX.h"
#include "IdCardReaderActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CIdCardReaderActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CIdCardReaderActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CIdCardReaderActiveXPropPage, "IDCARDREADERAC.IdCardReaderAcPropPage.1",
	0xcf969933, 0xaa25, 0x4fdc, 0x8e, 0x87, 0xd4, 0xfe, 0x3b, 0x96, 0x25, 0x9c)



// CIdCardReaderActiveXPropPage::CIdCardReaderActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CIdCardReaderActiveXPropPage ��ϵͳע�����

BOOL CIdCardReaderActiveXPropPage::CIdCardReaderActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_IDCARDREADERACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CIdCardReaderActiveXPropPage::CIdCardReaderActiveXPropPage - ���캯��

CIdCardReaderActiveXPropPage::CIdCardReaderActiveXPropPage() :
	COlePropertyPage(IDD, IDS_IDCARDREADERACTIVEX_PPG_CAPTION)
{
}



// CIdCardReaderActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CIdCardReaderActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CIdCardReaderActiveXPropPage ��Ϣ�������
