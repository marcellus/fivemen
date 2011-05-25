#pragma once

// ETTTTReaderActiveXPropPage.h : CETTTTReaderActiveXPropPage 属性页类的声明。


// CETTTTReaderActiveXPropPage : 有关实现的信息，请参阅 ETTTTReaderActiveXPropPage.cpp。

class CETTTTReaderActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTTTReaderActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTTTReaderActiveXPropPage)

// 构造函数
public:
	CETTTTReaderActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTTTREADERACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

