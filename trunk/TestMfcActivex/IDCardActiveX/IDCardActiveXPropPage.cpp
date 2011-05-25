// IDCardActiveXPropPage.cpp : CIDCardActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "IDCardActiveX.h"
#include "IDCardActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CIDCardActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CIDCardActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CIDCardActiveXPropPage, "IDCARDACTIVEX.IDCardActiveXPropPage.1",
	0x48a89b0f, 0x50e9, 0x45b5, 0x8b, 0x78, 0xa0, 0x2d, 0xef, 0xe3, 0xf1, 0x62)



// CIDCardActiveXPropPage::CIDCardActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CIDCardActiveXPropPage 的系统注册表项

BOOL CIDCardActiveXPropPage::CIDCardActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_IDCARDACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CIDCardActiveXPropPage::CIDCardActiveXPropPage - 构造函数

CIDCardActiveXPropPage::CIDCardActiveXPropPage() :
	COlePropertyPage(IDD, IDS_IDCARDACTIVEX_PPG_CAPTION)
{
}



// CIDCardActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CIDCardActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CIDCardActiveXPropPage 消息处理程序
