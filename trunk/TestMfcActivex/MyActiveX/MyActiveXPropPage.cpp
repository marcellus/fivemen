// MyActiveXPropPage.cpp : CMyActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "MyActiveX.h"
#include "MyActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CMyActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CMyActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CMyActiveXPropPage, "MYACTIVEX.MyActiveXPropPage.1",
	0x7846e2c2, 0x4e03, 0x481f, 0x92, 0x42, 0x3b, 0x48, 0xad, 0x50, 0xa7, 0x5d)



// CMyActiveXPropPage::CMyActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CMyActiveXPropPage 的系统注册表项

BOOL CMyActiveXPropPage::CMyActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_MYACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CMyActiveXPropPage::CMyActiveXPropPage - 构造函数

CMyActiveXPropPage::CMyActiveXPropPage() :
	COlePropertyPage(IDD, IDS_MYACTIVEX_PPG_CAPTION)
{
}



// CMyActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CMyActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CMyActiveXPropPage 消息处理程序
