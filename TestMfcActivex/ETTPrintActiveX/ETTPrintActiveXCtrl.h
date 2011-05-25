#pragma once

// ETTPrintActiveXCtrl.h : CETTPrintActiveXCtrl ActiveX 控件类的声明。


// CETTPrintActiveXCtrl : 有关实现的信息，请参阅 ETTPrintActiveXCtrl.cpp。

#include <objsafe.h>//导入安全接口
#include "qprint.h"

class CETTPrintActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTPrintActiveXCtrl)
	//ISafeObject
	DECLARE_INTERFACE_MAP()

	BEGIN_INTERFACE_PART(ObjSafe, IObjectSafety)
		STDMETHOD_(HRESULT, GetInterfaceSafetyOptions) ( 
		/* [in] */ REFIID riid,
		/* [out] */ DWORD __RPC_FAR *pdwSupportedOptions,
		/* [out] */ DWORD __RPC_FAR *pdwEnabledOptions
		);

		STDMETHOD_(HRESULT, SetInterfaceSafetyOptions) ( 
			/* [in] */ REFIID riid,
			/* [in] */ DWORD dwOptionSetMask,
			/* [in] */ DWORD dwEnabledOptions
			);
	END_INTERFACE_PART(ObjSafe);

// 构造函数
public:
	CETTPrintActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTPrintActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTPrintActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTPrintActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTPrintActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTPrintActiveXCtrl)		// 类型名称和杂项状态

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
	// 机动车受理凭证打印
	int CarAcceptPrint(void);
	// 打印控件类
	CQPrint *m_CQPrint;
};

