// TestCombine2PropPage.cpp : CTestCombine2PropPage 属性页类的实现。

#include "stdafx.h"
#include "TestCombine2.h"
#include "TestCombine2PropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CTestCombine2PropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CTestCombine2PropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CTestCombine2PropPage, "TESTCOMBINE2.TestCombine2PropPage.1",
	0xa8364f1f, 0x8a77, 0x4622, 0x9b, 0xd8, 0x95, 0x97, 0x98, 0x58, 0x72, 0xdf)



// CTestCombine2PropPage::CTestCombine2PropPageFactory::UpdateRegistry -
// 添加或移除 CTestCombine2PropPage 的系统注册表项

BOOL CTestCombine2PropPage::CTestCombine2PropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_TESTCOMBINE2_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CTestCombine2PropPage::CTestCombine2PropPage - 构造函数

CTestCombine2PropPage::CTestCombine2PropPage() :
	COlePropertyPage(IDD, IDS_TESTCOMBINE2_PPG_CAPTION)
{
}



// CTestCombine2PropPage::DoDataExchange - 在页和属性间移动数据

void CTestCombine2PropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CTestCombine2PropPage 消息处理程序
