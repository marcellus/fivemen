#pragma once

// TestCombine3PropPage.h : CTestCombine3PropPage 属性页类的声明。


// CTestCombine3PropPage : 有关实现的信息，请参阅 TestCombine3PropPage.cpp。

class CTestCombine3PropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CTestCombine3PropPage)
	DECLARE_OLECREATE_EX(CTestCombine3PropPage)

// 构造函数
public:
	CTestCombine3PropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_TESTCOMBINE3 };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

