// VoiceActiveXPropPage.cpp : CVoiceActiveXPropPage ����ҳ���ʵ�֡�

#include "stdafx.h"
#include "VoiceActiveX.h"
#include "VoiceActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CVoiceActiveXPropPage, COlePropertyPage)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CVoiceActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CVoiceActiveXPropPage, "VOICEACTIVEX.VoiceActiveXPropPage.1",
	0x49a80ac0, 0x371b, 0x41a0, 0x8f, 0x4f, 0xce, 0x9a, 0x74, 0x46, 0xfc, 0xfd)



// CVoiceActiveXPropPage::CVoiceActiveXPropPageFactory::UpdateRegistry -
// ��ӻ��Ƴ� CVoiceActiveXPropPage ��ϵͳע�����

BOOL CVoiceActiveXPropPage::CVoiceActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_VOICEACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CVoiceActiveXPropPage::CVoiceActiveXPropPage - ���캯��

CVoiceActiveXPropPage::CVoiceActiveXPropPage() :
	COlePropertyPage(IDD, IDS_VOICEACTIVEX_PPG_CAPTION)
{
}



// CVoiceActiveXPropPage::DoDataExchange - ��ҳ�����Լ��ƶ�����

void CVoiceActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CVoiceActiveXPropPage ��Ϣ�������
