// ETTSelfPrinterActiveXPropPage.cpp : CETTSelfPrinterActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTSelfPrinterActiveX.h"
#include "ETTSelfPrinterActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfPrinterActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTSelfPrinterActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTSelfPrinterActiveXPropPage, "ETTSELFPRINTER.ETTSelfPrinterPropPage.1",
	0xa837e89f, 0x9453, 0x49a6, 0xb8, 0x50, 0xa9, 0xdd, 0x2, 0x12, 0xf3, 0xc8)



// CETTSelfPrinterActiveXPropPage::CETTSelfPrinterActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTSelfPrinterActiveXPropPage 的系统注册表项

BOOL CETTSelfPrinterActiveXPropPage::CETTSelfPrinterActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTSELFPRINTERACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTSelfPrinterActiveXPropPage::CETTSelfPrinterActiveXPropPage - 构造函数

CETTSelfPrinterActiveXPropPage::CETTSelfPrinterActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTSELFPRINTERACTIVEX_PPG_CAPTION)
{
}



// CETTSelfPrinterActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTSelfPrinterActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTSelfPrinterActiveXPropPage 消息处理程序
