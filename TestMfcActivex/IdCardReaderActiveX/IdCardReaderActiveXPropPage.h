#pragma once

// IdCardReaderActiveXPropPage.h : CIdCardReaderActiveXPropPage 属性页类的声明。


// CIdCardReaderActiveXPropPage : 有关实现的信息，请参阅 IdCardReaderActiveXPropPage.cpp。

class CIdCardReaderActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CIdCardReaderActiveXPropPage)
	DECLARE_OLECREATE_EX(CIdCardReaderActiveXPropPage)

// 构造函数
public:
	CIdCardReaderActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_IDCARDREADERACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

