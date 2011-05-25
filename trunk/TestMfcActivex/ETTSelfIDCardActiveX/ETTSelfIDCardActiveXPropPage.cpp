// ETTSelfIDCardActiveXPropPage.cpp : CETTSelfIDCardActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTSelfIDCardActiveX.h"
#include "ETTSelfIDCardActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfIDCardActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTSelfIDCardActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTSelfIDCardActiveXPropPage, "ETTSELFIDCARDA.ETTSelfIDCardAPropPage.1",
	0x1da26e8d, 0x4f37, 0x4e8f, 0x9b, 0x20, 0x51, 0xc0, 0xc1, 0x6e, 0x38, 0xb6)



// CETTSelfIDCardActiveXPropPage::CETTSelfIDCardActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTSelfIDCardActiveXPropPage 的系统注册表项

BOOL CETTSelfIDCardActiveXPropPage::CETTSelfIDCardActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTSELFIDCARDACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTSelfIDCardActiveXPropPage::CETTSelfIDCardActiveXPropPage - 构造函数

CETTSelfIDCardActiveXPropPage::CETTSelfIDCardActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTSELFIDCARDACTIVEX_PPG_CAPTION)
{
}



// CETTSelfIDCardActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTSelfIDCardActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTSelfIDCardActiveXPropPage 消息处理程序
