#pragma once

// ETTPrintActiveXPropPage.h : CETTPrintActiveXPropPage 属性页类的声明。


// CETTPrintActiveXPropPage : 有关实现的信息，请参阅 ETTPrintActiveXPropPage.cpp。

class CETTPrintActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTPrintActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTPrintActiveXPropPage)

// 构造函数
public:
	CETTPrintActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTPRINTACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

