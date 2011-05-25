#pragma once

// IDCardActiveXPropPage.h : CIDCardActiveXPropPage 属性页类的声明。


// CIDCardActiveXPropPage : 有关实现的信息，请参阅 IDCardActiveXPropPage.cpp。

class CIDCardActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CIDCardActiveXPropPage)
	DECLARE_OLECREATE_EX(CIDCardActiveXPropPage)

// 构造函数
public:
	CIDCardActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_IDCARDACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

