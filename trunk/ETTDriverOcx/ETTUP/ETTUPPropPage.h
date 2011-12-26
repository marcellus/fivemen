#pragma once

// ETTUPPropPage.h : CETTUPPropPage 属性页类的声明。


// CETTUPPropPage : 有关实现的信息，请参阅 ETTUPPropPage.cpp。

class CETTUPPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTUPPropPage)
	DECLARE_OLECREATE_EX(CETTUPPropPage)

// 构造函数
public:
	CETTUPPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTUP };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

