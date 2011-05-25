// USBVideoActiveXPropPage.cpp : CUSBVideoActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "USBVideoActiveX.h"
#include "USBVideoActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CUSBVideoActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CUSBVideoActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CUSBVideoActiveXPropPage, "USBVIDEOACTIVE.USBVideoActivePropPage.1",
	0xe6ff64f8, 0xfaa0, 0x4e99, 0x84, 0x3c, 0xa5, 0x20, 0xea, 0xe6, 0x3b, 0x78)



// CUSBVideoActiveXPropPage::CUSBVideoActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CUSBVideoActiveXPropPage 的系统注册表项

BOOL CUSBVideoActiveXPropPage::CUSBVideoActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_USBVIDEOACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CUSBVideoActiveXPropPage::CUSBVideoActiveXPropPage - 构造函数

CUSBVideoActiveXPropPage::CUSBVideoActiveXPropPage() :
	COlePropertyPage(IDD, IDS_USBVIDEOACTIVEX_PPG_CAPTION)
{
}



// CUSBVideoActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CUSBVideoActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CUSBVideoActiveXPropPage 消息处理程序
