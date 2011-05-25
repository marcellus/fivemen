// ETTSelfUSBVideoActiveXPropPage.cpp : CETTSelfUSBVideoActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTSelfUSBVideoActiveX.h"
#include "ETTSelfUSBVideoActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfUSBVideoActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTSelfUSBVideoActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTSelfUSBVideoActiveXPropPage, "ETTSELFUSBVIDE.ETTSelfUSBVidePropPage.1",
	0x1fc1a563, 0x8a70, 0x4a69, 0x9b, 0x2b, 0x49, 0x1c, 0xef, 0xcb, 0x60, 0xd4)



// CETTSelfUSBVideoActiveXPropPage::CETTSelfUSBVideoActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTSelfUSBVideoActiveXPropPage 的系统注册表项

BOOL CETTSelfUSBVideoActiveXPropPage::CETTSelfUSBVideoActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTSELFUSBVIDEOACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTSelfUSBVideoActiveXPropPage::CETTSelfUSBVideoActiveXPropPage - 构造函数

CETTSelfUSBVideoActiveXPropPage::CETTSelfUSBVideoActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTSELFUSBVIDEOACTIVEX_PPG_CAPTION)
{
}



// CETTSelfUSBVideoActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTSelfUSBVideoActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTSelfUSBVideoActiveXPropPage 消息处理程序
