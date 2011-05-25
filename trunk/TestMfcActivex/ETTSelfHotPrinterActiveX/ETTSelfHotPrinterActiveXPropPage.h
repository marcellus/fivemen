#pragma once

// ETTSelfHotPrinterActiveXPropPage.h : CETTSelfHotPrinterActiveXPropPage 属性页类的声明。


// CETTSelfHotPrinterActiveXPropPage : 有关实现的信息，请参阅 ETTSelfHotPrinterActiveXPropPage.cpp。

class CETTSelfHotPrinterActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTSelfHotPrinterActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTSelfHotPrinterActiveXPropPage)

// 构造函数
public:
	CETTSelfHotPrinterActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTSELFHOTPRINTERACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

