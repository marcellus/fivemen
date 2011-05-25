#pragma once

// USBVideoActiveXPropPage.h : CUSBVideoActiveXPropPage 属性页类的声明。


// CUSBVideoActiveXPropPage : 有关实现的信息，请参阅 USBVideoActiveXPropPage.cpp。

class CUSBVideoActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CUSBVideoActiveXPropPage)
	DECLARE_OLECREATE_EX(CUSBVideoActiveXPropPage)

// 构造函数
public:
	CUSBVideoActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_USBVIDEOACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

