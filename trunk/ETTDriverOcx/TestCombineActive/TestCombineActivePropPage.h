#pragma once

// TestCombineActivePropPage.h : CTestCombineActivePropPage 属性页类的声明。


// CTestCombineActivePropPage : 有关实现的信息，请参阅 TestCombineActivePropPage.cpp。

class CTestCombineActivePropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CTestCombineActivePropPage)
	DECLARE_OLECREATE_EX(CTestCombineActivePropPage)

// 构造函数
public:
	CTestCombineActivePropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_TESTCOMBINEACTIVE };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

