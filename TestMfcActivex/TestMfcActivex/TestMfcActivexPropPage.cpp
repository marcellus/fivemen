// TestMfcActivexPropPage.cpp : CTestMfcActivexPropPage 属性页类的实现。

#include "stdafx.h"
#include "TestMfcActivex.h"
#include "TestMfcActivexPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestMfcActivexPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CTestMfcActivexPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CTestMfcActivexPropPage, "TESTMFCACTIVEX.TestMfcActivexPropPage.1",
	0xb06096b1, 0x4a51, 0x4141, 0xa0, 0xf3, 0x6, 0xa5, 0x87, 0x1e, 0xf5, 0xa8)



// CTestMfcActivexPropPage::CTestMfcActivexPropPageFactory::UpdateRegistry -
// 添加或移除 CTestMfcActivexPropPage 的系统注册表项

BOOL CTestMfcActivexPropPage::CTestMfcActivexPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_TESTMFCACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CTestMfcActivexPropPage::CTestMfcActivexPropPage - 构造函数

CTestMfcActivexPropPage::CTestMfcActivexPropPage() :
	COlePropertyPage(IDD, IDS_TESTMFCACTIVEX_PPG_CAPTION)
{
}



// CTestMfcActivexPropPage::DoDataExchange - 在页和属性间移动数据

void CTestMfcActivexPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CTestMfcActivexPropPage 消息处理程序
