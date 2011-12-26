// TestCombine3PropPage.cpp : CTestCombine3PropPage 属性页类的实现。

#include "stdafx.h"
#include "TestCombine3.h"
#include "TestCombine3PropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombine3PropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CTestCombine3PropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CTestCombine3PropPage, "TESTCOMBINE3.TestCombine3PropPage.1",
					   0x6514336c, 0x3825, 0x489b, 0xa5, 0xd7, 0x46, 0x54, 0xa9, 0x2, 0xf9, 0x72)



					   // CTestCombine3PropPage::CTestCombine3PropPageFactory::UpdateRegistry -
					   // 添加或移除 CTestCombine3PropPage 的系统注册表项

					   BOOL CTestCombine3PropPage::CTestCombine3PropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
		m_clsid, IDS_TESTCOMBINE3_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CTestCombine3PropPage::CTestCombine3PropPage - 构造函数

CTestCombine3PropPage::CTestCombine3PropPage() :
COlePropertyPage(IDD, IDS_TESTCOMBINE3_PPG_CAPTION)
{
}



// CTestCombine3PropPage::DoDataExchange - 在页和属性间移动数据

void CTestCombine3PropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CTestCombine3PropPage 消息处理程序
