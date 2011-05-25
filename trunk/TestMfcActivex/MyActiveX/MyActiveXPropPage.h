#pragma once

// MyActiveXPropPage.h : CMyActiveXPropPage 属性页类的声明。


// CMyActiveXPropPage : 有关实现的信息，请参阅 MyActiveXPropPage.cpp。

class CMyActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CMyActiveXPropPage)
	DECLARE_OLECREATE_EX(CMyActiveXPropPage)

// 构造函数
public:
	CMyActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_MYACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

