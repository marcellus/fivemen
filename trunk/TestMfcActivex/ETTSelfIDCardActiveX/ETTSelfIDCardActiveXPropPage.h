#pragma once

// ETTSelfIDCardActiveXPropPage.h : CETTSelfIDCardActiveXPropPage 属性页类的声明。


// CETTSelfIDCardActiveXPropPage : 有关实现的信息，请参阅 ETTSelfIDCardActiveXPropPage.cpp。

class CETTSelfIDCardActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTSelfIDCardActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTSelfIDCardActiveXPropPage)

// 构造函数
public:
	CETTSelfIDCardActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTSELFIDCARDACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

