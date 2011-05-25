#pragma once

// ETTSelfUSBVideoActiveXPropPage.h : CETTSelfUSBVideoActiveXPropPage 属性页类的声明。


// CETTSelfUSBVideoActiveXPropPage : 有关实现的信息，请参阅 ETTSelfUSBVideoActiveXPropPage.cpp。

class CETTSelfUSBVideoActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTSelfUSBVideoActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTSelfUSBVideoActiveXPropPage)

// 构造函数
public:
	CETTSelfUSBVideoActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_ETTSELFUSBVIDEOACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

