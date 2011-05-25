#pragma once

// ETTCashCodeActiveXPropPage.h : CETTCashCodeActiveXPropPage 属性页类的声明。


// CETTCashCodeActiveXPropPage : 有关实现的信息，请参阅 ETTCashCodeActiveXPropPage.cpp。

class CETTCashCodeActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTCashCodeActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTCashCodeActiveXPropPage)

// 构造函数
public:
	CETTCashCodeActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTCASHCODEACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

