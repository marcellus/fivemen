// ETTSelfHotPrinterActiveXPropPage.cpp : CETTSelfHotPrinterActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTSelfHotPrinterActiveX.h"
#include "ETTSelfHotPrinterActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfHotPrinterActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTSelfHotPrinterActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTSelfHotPrinterActiveXPropPage, "ETTSELFHOTPRIN.ETTSelfHotPrinPropPage.1",
	0xadaf509f, 0xca6b, 0x490d, 0xa6, 0xa2, 0x3c, 0x75, 0x36, 0xdd, 0x9c, 0xdf)



// CETTSelfHotPrinterActiveXPropPage::CETTSelfHotPrinterActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTSelfHotPrinterActiveXPropPage 的系统注册表项

BOOL CETTSelfHotPrinterActiveXPropPage::CETTSelfHotPrinterActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTSELFHOTPRINTERACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTSelfHotPrinterActiveXPropPage::CETTSelfHotPrinterActiveXPropPage - 构造函数

CETTSelfHotPrinterActiveXPropPage::CETTSelfHotPrinterActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTSELFHOTPRINTERACTIVEX_PPG_CAPTION)
{
}



// CETTSelfHotPrinterActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTSelfHotPrinterActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTSelfHotPrinterActiveXPropPage 消息处理程序
