// ETTCashPropPage.cpp : CETTCashPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTCash.h"
#include "ETTCashPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTCashPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTCashPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTCashPropPage, "ETTCASH.ETTCashPropPage.1",
	0xf6225a61, 0xb90e, 0x4f54, 0xb7, 0x9f, 0x33, 0xe3, 0xd5, 0x6c, 0x2b, 0xd8)



// CETTCashPropPage::CETTCashPropPageFactory::UpdateRegistry -
// 添加或移除 CETTCashPropPage 的系统注册表项

BOOL CETTCashPropPage::CETTCashPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTCASH_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTCashPropPage::CETTCashPropPage - 构造函数

CETTCashPropPage::CETTCashPropPage() :
	COlePropertyPage(IDD, IDS_ETTCASH_PPG_CAPTION)
{
}



// CETTCashPropPage::DoDataExchange - 在页和属性间移动数据

void CETTCashPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTCashPropPage 消息处理程序
