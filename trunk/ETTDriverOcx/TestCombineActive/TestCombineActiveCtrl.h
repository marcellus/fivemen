#pragma once

// TestCombineActiveCtrl.h : CTestCombineActiveCtrl ActiveX 控件类的声明。


// CTestCombineActiveCtrl : 有关实现的信息，请参阅 TestCombineActiveCtrl.cpp。

class CTestCombineActiveCtrl : public COleControl
{
	DECLARE_DYNCREATE(CTestCombineActiveCtrl)

// 构造函数
public:
	CTestCombineActiveCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CTestCombineActiveCtrl();

	DECLARE_OLECREATE_EX(CTestCombineActiveCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CTestCombineActiveCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CTestCombineActiveCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CTestCombineActiveCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidHelloWordA = 1L
	};
protected:
	SHORT HelloWordA(void);
};

