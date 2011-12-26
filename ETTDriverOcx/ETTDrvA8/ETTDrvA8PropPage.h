#pragma once

// ETTDrvA8PropPage.h : CETTDrvA8PropPage 属性页类的声明。


// CETTDrvA8PropPage : 有关实现的信息，请参阅 ETTDrvA8PropPage.cpp。

class CETTDrvA8PropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTDrvA8PropPage)
	DECLARE_OLECREATE_EX(CETTDrvA8PropPage)

// 构造函数
public:
	CETTDrvA8PropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTDRVA8 };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

