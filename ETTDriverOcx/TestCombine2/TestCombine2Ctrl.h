#pragma once

// TestCombine2Ctrl.h : CTestCombine2Ctrl ActiveX 控件类的声明。


// CTestCombine2Ctrl : 有关实现的信息，请参阅 TestCombine2Ctrl.cpp。

class CTestCombine2Ctrl : public COleControl
{
	DECLARE_DYNCREATE(CTestCombine2Ctrl)

// 构造函数
public:
	CTestCombine2Ctrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CTestCombine2Ctrl();

	DECLARE_OLECREATE_EX(CTestCombine2Ctrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CTestCombine2Ctrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CTestCombine2Ctrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CTestCombine2Ctrl)		// 类型名称和杂项状态

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
};

