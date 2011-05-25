#pragma once

// ETTCashActiveXPropPage.h : CETTCashActiveXPropPage 属性页类的声明。


// CETTCashActiveXPropPage : 有关实现的信息，请参阅 ETTCashActiveXPropPage.cpp。

class CETTCashActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTCashActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTCashActiveXPropPage)

// 构造函数
public:
	CETTCashActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTCASHACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

