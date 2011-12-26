#pragma once

// ETTCashPropPage.h : CETTCashPropPage 属性页类的声明。


// CETTCashPropPage : 有关实现的信息，请参阅 ETTCashPropPage.cpp。

class CETTCashPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTCashPropPage)
	DECLARE_OLECREATE_EX(CETTCashPropPage)

// 构造函数
public:
	CETTCashPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTCASH };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

