// ETTA8IDCardActiveXPropPage.cpp : CETTA8IDCardActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTA8IDCardActiveX.h"
#include "ETTA8IDCardActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTA8IDCardActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTA8IDCardActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTA8IDCardActiveXPropPage, "ETTA8IDCARDACT.ETTA8IDCardActPropPage.1",
	0xe036a6b1, 0x2517, 0x4bbd, 0x9f, 0xd8, 0xf7, 0xcf, 0x5d, 0x3d, 0x4f, 0xee)



// CETTA8IDCardActiveXPropPage::CETTA8IDCardActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTA8IDCardActiveXPropPage 的系统注册表项

BOOL CETTA8IDCardActiveXPropPage::CETTA8IDCardActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTA8IDCARDACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTA8IDCardActiveXPropPage::CETTA8IDCardActiveXPropPage - 构造函数

CETTA8IDCardActiveXPropPage::CETTA8IDCardActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTA8IDCARDACTIVEX_PPG_CAPTION)
{
}



// CETTA8IDCardActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTA8IDCardActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTA8IDCardActiveXPropPage 消息处理程序
