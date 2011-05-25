#pragma once

// MyActiveXCtrl.h : CMyActiveXCtrl ActiveX 控件类的声明。


// CMyActiveXCtrl : 有关实现的信息，请参阅 MyActiveXCtrl.cpp。
#include <objsafe.h>
//public IObjectSafetyImpl<CMyActiveXCtrl>

class CMyActiveXCtrl : public COleControl 
{
	DECLARE_DYNCREATE(CMyActiveXCtrl)

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
	CMyActiveXCtrl();
	CString MessageStr;

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CMyActiveXCtrl();

	DECLARE_OLECREATE_EX(CMyActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CMyActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CMyActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CMyActiveXCtrl)		// 类型名称和杂项状态

	// 子类控件支持
	BOOL IsSubclassedControl();
	LRESULT OnOcmCommand(WPARAM wParam, LPARAM lParam);

// 消息映射
	DECLARE_MESSAGE_MAP()
    afx_msg short ShowMessageBox();

// 调度映射
	DECLARE_DISPATCH_MAP()
	
//	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
	};
};

