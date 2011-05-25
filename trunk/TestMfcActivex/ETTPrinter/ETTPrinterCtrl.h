#pragma once

// ETTPrintActiveXCtrl.h : CETTPrinterCtrl ActiveX 控件类的声明。


// CETTPrinterCtrl : 有关实现的信息，请参阅 ETTPrintActiveXCtrl.cpp。

#include <objsafe.h>//导入安全接口
#include "QPrint.h"

class CETTPrinterCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTPrinterCtrl)
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
	CETTPrinterCtrl();

	// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

	// 实现
protected:
	~CETTPrinterCtrl();

	DECLARE_OLECREATE_EX(CETTPrinterCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTPrinterCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTPrinterCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTPrinterCtrl)		// 类型名称和杂项状态

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

