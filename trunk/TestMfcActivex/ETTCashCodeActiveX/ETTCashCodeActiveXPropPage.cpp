// ETTCashCodeActiveXPropPage.cpp : CETTCashCodeActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTCashCodeActiveX.h"
#include "ETTCashCodeActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTCashCodeActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTCashCodeActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTCashCodeActiveXPropPage, "ETTCASHCODEACT.ETTCashCodeActPropPage.1",
	0xdde76c80, 0xd051, 0x4417, 0xad, 0x9a, 0xfd, 0x4e, 0xc8, 0xb8, 0xdf, 0x8c)



// CETTCashCodeActiveXPropPage::CETTCashCodeActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTCashCodeActiveXPropPage 的系统注册表项

BOOL CETTCashCodeActiveXPropPage::CETTCashCodeActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTCASHCODEACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTCashCodeActiveXPropPage::CETTCashCodeActiveXPropPage - 构造函数

CETTCashCodeActiveXPropPage::CETTCashCodeActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTCASHCODEACTIVEX_PPG_CAPTION)
{
}



// CETTCashCodeActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTCashCodeActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTCashCodeActiveXPropPage 消息处理程序
