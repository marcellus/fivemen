#pragma once

// ETTZT598ActiveXPropPage.h : CETTZT598ActiveXPropPage 属性页类的声明。


// CETTZT598ActiveXPropPage : 有关实现的信息，请参阅 ETTZT598ActiveXPropPage.cpp。

class CETTZT598ActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTZT598ActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTZT598ActiveXPropPage)

// 构造函数
public:
	CETTZT598ActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTZT598ACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

