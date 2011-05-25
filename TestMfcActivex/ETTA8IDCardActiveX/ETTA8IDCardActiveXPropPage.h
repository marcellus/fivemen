#pragma once

// ETTA8IDCardActiveXPropPage.h : CETTA8IDCardActiveXPropPage 属性页类的声明。


// CETTA8IDCardActiveXPropPage : 有关实现的信息，请参阅 ETTA8IDCardActiveXPropPage.cpp。

class CETTA8IDCardActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTA8IDCardActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTA8IDCardActiveXPropPage)

// 构造函数
public:
	CETTA8IDCardActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTA8IDCARDACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

