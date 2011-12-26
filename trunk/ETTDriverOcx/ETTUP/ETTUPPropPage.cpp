// ETTUPPropPage.cpp : CETTUPPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTUP.h"
#include "ETTUPPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTUPPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTUPPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTUPPropPage, "ETTUP.ETTUPPropPage.1",
	0x83728187, 0x2a5e, 0x4627, 0xb9, 0x20, 0x98, 0xbe, 0xfc, 0x60, 0x20, 0xec)



// CETTUPPropPage::CETTUPPropPageFactory::UpdateRegistry -
// 添加或移除 CETTUPPropPage 的系统注册表项

BOOL CETTUPPropPage::CETTUPPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTUP_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTUPPropPage::CETTUPPropPage - 构造函数

CETTUPPropPage::CETTUPPropPage() :
	COlePropertyPage(IDD, IDS_ETTUP_PPG_CAPTION)
{
}



// CETTUPPropPage::DoDataExchange - 在页和属性间移动数据

void CETTUPPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTUPPropPage 消息处理程序
