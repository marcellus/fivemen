#pragma once

// TestCombine3Ctrl.h : CTestCombine3Ctrl ActiveX 控件类的声明。


// CTestCombine3Ctrl : 有关实现的信息，请参阅 TestCombine3Ctrl.cpp。

class CTestCombine3Ctrl : public COleControl
{
	DECLARE_DYNCREATE(CTestCombine3Ctrl)

	// 构造函数
public:
	CTestCombine3Ctrl();

	// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

	// 实现
protected:
	~CTestCombine3Ctrl();

	DECLARE_OLECREATE_EX(CTestCombine3Ctrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CTestCombine3Ctrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CTestCombine3Ctrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CTestCombine3Ctrl)		// 类型名称和杂项状态

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

