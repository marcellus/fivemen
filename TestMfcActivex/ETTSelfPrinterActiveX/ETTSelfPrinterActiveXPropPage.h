#pragma once

// ETTSelfPrinterActiveXPropPage.h : CETTSelfPrinterActiveXPropPage 属性页类的声明。


// CETTSelfPrinterActiveXPropPage : 有关实现的信息，请参阅 ETTSelfPrinterActiveXPropPage.cpp。

class CETTSelfPrinterActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTSelfPrinterActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTSelfPrinterActiveXPropPage)

// 构造函数
public:
	CETTSelfPrinterActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTSELFPRINTERACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

