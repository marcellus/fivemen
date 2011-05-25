#pragma once

// ETTEpsonPrinterActiveXPropPage.h : CETTEpsonPrinterActiveXPropPage 属性页类的声明。


// CETTEpsonPrinterActiveXPropPage : 有关实现的信息，请参阅 ETTEpsonPrinterActiveXPropPage.cpp。

class CETTEpsonPrinterActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTEpsonPrinterActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTEpsonPrinterActiveXPropPage)

// 构造函数
public:
	CETTEpsonPrinterActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTEPSONPRINTERACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

