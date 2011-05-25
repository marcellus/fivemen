#pragma once

// ETTPrinterPropPage.h : CETTPrinterPropPage 属性页类的声明。


// CETTPrinterPropPage : 有关实现的信息，请参阅 ETTPrinterPropPage.cpp。

class CETTPrinterPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTPrinterPropPage)
	DECLARE_OLECREATE_EX(CETTPrinterPropPage)

// 构造函数
public:
	CETTPrinterPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTPRINTER };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

