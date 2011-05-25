// ETTTTReaderActiveXPropPage.cpp : CETTTTReaderActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "ETTTTReaderActiveX.h"
#include "ETTTTReaderActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTTTReaderActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CETTTTReaderActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CETTTTReaderActiveXPropPage, "ETTTTREADERACT.ETTTTReaderActPropPage.1",
	0x777cf571, 0xc785, 0x4d3d, 0x9d, 0xfa, 0x47, 0x65, 0xcf, 0xaf, 0xa3, 0x17)



// CETTTTReaderActiveXPropPage::CETTTTReaderActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CETTTTReaderActiveXPropPage 的系统注册表项

BOOL CETTTTReaderActiveXPropPage::CETTTTReaderActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_ETTTTREADERACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CETTTTReaderActiveXPropPage::CETTTTReaderActiveXPropPage - 构造函数

CETTTTReaderActiveXPropPage::CETTTTReaderActiveXPropPage() :
	COlePropertyPage(IDD, IDS_ETTTTREADERACTIVEX_PPG_CAPTION)
{
}



// CETTTTReaderActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CETTTTReaderActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CETTTTReaderActiveXPropPage 消息处理程序
