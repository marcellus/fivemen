// ETTDrvA8PropPage.cpp : CETTDrvA8PropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTDrvA8.h"
#include "ETTDrvA8PropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTDrvA8PropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTDrvA8PropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTDrvA8PropPage, "ETTDRVA8.ETTDrvA8PropPage.1",
	0xb586128c, 0xc834, 0x4af5, 0x9f, 0x87, 0x5d, 0x55, 0xf, 0x40, 0x6e, 0xd8)



// CETTDrvA8PropPage::CETTDrvA8PropPageFactory::UpdateRegistry -
// 添加或移除 CETTDrvA8PropPage 的系统注册表项

BOOL CETTDrvA8PropPage::CETTDrvA8PropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTDRVA8_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTDrvA8PropPage::CETTDrvA8PropPage - 构造函数

CETTDrvA8PropPage::CETTDrvA8PropPage() :
	COlePropertyPage(IDD, IDS_ETTDRVA8_PPG_CAPTION)
{
}



// CETTDrvA8PropPage::DoDataExchange - 在页和属性间移动数据

void CETTDrvA8PropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTDrvA8PropPage 消息处理程序
