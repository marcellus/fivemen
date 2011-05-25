// ETTPrintActiveXPropPage.cpp : CETTPrintActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTPrintActiveX.h"
#include "ETTPrintActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTPrintActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTPrintActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTPrintActiveXPropPage, "ETTPRINTACTIVE.ETTPrintActivePropPage.1",
	0x40c250cf, 0x120e, 0x4075, 0xb0, 0xa4, 0x4c, 0x5, 0xc2, 0x86, 0x11, 0xcc)



// CETTPrintActiveXPropPage::CETTPrintActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTPrintActiveXPropPage 的系统注册表项

BOOL CETTPrintActiveXPropPage::CETTPrintActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTPRINTACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTPrintActiveXPropPage::CETTPrintActiveXPropPage - 构造函数

CETTPrintActiveXPropPage::CETTPrintActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTPRINTACTIVEX_PPG_CAPTION)
{
}



// CETTPrintActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTPrintActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTPrintActiveXPropPage 消息处理程序
