// ETTZT598ActiveXPropPage.cpp : CETTZT598ActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTZT598ActiveX.h"
#include "ETTZT598ActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTZT598ActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTZT598ActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTZT598ActiveXPropPage, "ETTZT598ACTIVE.ETTZT598ActivePropPage.1",
	0xad2e36cc, 0x2bed, 0x4951, 0xb4, 0x29, 0xa3, 0x97, 0x2d, 0x5e, 0x9d, 0xaf)



// CETTZT598ActiveXPropPage::CETTZT598ActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTZT598ActiveXPropPage 的系统注册表项

BOOL CETTZT598ActiveXPropPage::CETTZT598ActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTZT598ACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTZT598ActiveXPropPage::CETTZT598ActiveXPropPage - 构造函数

CETTZT598ActiveXPropPage::CETTZT598ActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTZT598ACTIVEX_PPG_CAPTION)
{
}



// CETTZT598ActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTZT598ActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTZT598ActiveXPropPage 消息处理程序
