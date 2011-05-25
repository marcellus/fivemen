#pragma once

// USBVideoActiveXCtrl.h : CUSBVideoActiveXCtrl ActiveX 控件类的声明。


// CUSBVideoActiveXCtrl : 有关实现的信息，请参阅 USBVideoActiveXCtrl.cpp。

//#include <atlctrls.h>

class CUSBVideoActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CUSBVideoActiveXCtrl)

// 构造函数
public:
	CUSBVideoActiveXCtrl();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();
	CButton m_button1;
	CButton m_button2;

// 实现
protected:
	~CUSBVideoActiveXCtrl();

	DECLARE_OLECREATE_EX(CUSBVideoActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CUSBVideoActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CUSBVideoActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CUSBVideoActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
	};
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
};

