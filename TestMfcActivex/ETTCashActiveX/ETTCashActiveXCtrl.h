#pragma once

// ETTCashActiveXCtrl.h : CETTCashActiveXCtrl ActiveX 控件类的声明。


// CETTCashActiveXCtrl : 有关实现的信息，请参阅 ETTCashActiveXCtrl.cpp。

static HINSTANCE DLLInstPrint = NULL;

//------------------------------------------------------
//两个dll都有的函数定义现金识别器动态库函数功能定义
//------------------------------------------------------
int (__stdcall *OpenDevice)(int iPort, char* Message);
int (__stdcall *CloseDevice)(char* Message);
int (__stdcall *GetDeviceStatus)(char* Message);
int (__stdcall *StartIdentify)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message);
int (__stdcall *StopIdentify)(char* Message);
int (__stdcall *Identify)(char* Message);
int (__stdcall *Reset)(char* Message);


#include <objsafe.h>//导入安全接口

class CETTCashActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTCashActiveXCtrl)

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
	CETTCashActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTCashActiveXCtrl();

	BEGIN_OLEFACTORY(CETTCashActiveXCtrl)        // 类工厂和 guid
		virtual BOOL VerifyUserLicense();
		virtual BOOL GetLicenseKey(DWORD, BSTR FAR*);
	END_OLEFACTORY(CETTCashActiveXCtrl)

	DECLARE_OLETYPELIB(CETTCashActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTCashActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTCashActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidTestMethod = 1L,
		dispidAcceptMoney = 3L,
		dispidDestoryDll = 2L,
		dispidLoadCashDll = 1L
	};
protected:
	void LoadCashDll(void);
	void DestoryDll(void);
	void AcceptMoney(SHORT money);
	void TestMethod(void);
};

