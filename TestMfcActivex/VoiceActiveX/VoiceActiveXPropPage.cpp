// VoiceActiveXPropPage.cpp : CVoiceActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "VoiceActiveX.h"
#include "VoiceActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CVoiceActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CVoiceActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CVoiceActiveXPropPage, "VOICEACTIVEX.VoiceActiveXPropPage.1",
	0x49a80ac0, 0x371b, 0x41a0, 0x8f, 0x4f, 0xce, 0x9a, 0x74, 0x46, 0xfc, 0xfd)



// CVoiceActiveXPropPage::CVoiceActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CVoiceActiveXPropPage 的系统注册表项

BOOL CVoiceActiveXPropPage::CVoiceActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_VOICEACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CVoiceActiveXPropPage::CVoiceActiveXPropPage - 构造函数

CVoiceActiveXPropPage::CVoiceActiveXPropPage() :
	COlePropertyPage(IDD, IDS_VOICEACTIVEX_PPG_CAPTION)
{
}



// CVoiceActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CVoiceActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CVoiceActiveXPropPage 消息处理程序
