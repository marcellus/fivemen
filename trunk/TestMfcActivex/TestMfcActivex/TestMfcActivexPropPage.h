#pragma once

// TestMfcActivexPropPage.h : CTestMfcActivexPropPage 属性页类的声明。


// CTestMfcActivexPropPage : 有关实现的信息，请参阅 TestMfcActivexPropPage.cpp。

class CTestMfcActivexPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CTestMfcActivexPropPage)
	DECLARE_OLECREATE_EX(CTestMfcActivexPropPage)

// 构造函数
public:
	CTestMfcActivexPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_TESTMFCACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

