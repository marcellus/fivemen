#pragma once

// TestMfcActivexCtrl.h : CTestMfcActivexCtrl ActiveX 控件类的声明。


// CTestMfcActivexCtrl : 有关实现的信息，请参阅 TestMfcActivexCtrl.cpp。

class CTestMfcActivexCtrl : public COleControl
{
	DECLARE_DYNCREATE(CTestMfcActivexCtrl)

// 构造函数
public:
	CTestMfcActivexCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CTestMfcActivexCtrl();

	DECLARE_OLECREATE_EX(CTestMfcActivexCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CTestMfcActivexCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CTestMfcActivexCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CTestMfcActivexCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

	afx_msg void AboutBox();

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
	};
};

