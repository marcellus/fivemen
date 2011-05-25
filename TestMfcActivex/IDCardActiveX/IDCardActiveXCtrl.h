#pragma once
////////////////////////////////////////////////////////////////////////////
//                        设置activex安全接口
////////////////////////////////////////////////////////////////////////////
#include <objsafe.h>
////////////////////////////////////////////////////////////////////////////
//                        设置activex安全接口
////////////////////////////////////////////////////////////////////////////
//public IObjectSafetyImpl<CIDCardActiveXCtrl>

// IDCardActiveXCtrl.h : CIDCardActiveXCtrl ActiveX 控件类的声明。


// CIDCardActiveXCtrl : 有关实现的信息，请参阅 IDCardActiveXCtrl.cpp。

class CIDCardActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CIDCardActiveXCtrl)
////////////////////////////////////////////////////////////////////////////
//                        设置activex安全接口
////////////////////////////////////////////////////////////////////////////
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

////////////////////////////////////////////////////////////////////////////
//                        设置activex安全接口
////////////////////////////////////////////////////////////////////////////

// 构造函数
public:
	CIDCardActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CIDCardActiveXCtrl();

	DECLARE_OLECREATE_EX(CIDCardActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CIDCardActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CIDCardActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CIDCardActiveXCtrl)		// 类型名称和杂项状态

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

