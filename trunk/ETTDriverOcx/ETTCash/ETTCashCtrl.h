#pragma once

// ETTCashCodeActiveXCtrl.h : CETTCashCodeActiveXCtrl ActiveX 控件类的声明。


// CETTCashCodeActiveXCtrl : 有关实现的信息，请参阅 ETTCashCodeActiveXCtrl.cpp。
static HINSTANCE DLLInstPrint = NULL;

//------------------------------------------------------
//两个dll都有的函数定义现金识别器动态库函数功能定义
//------------------------------------------------------
int (__stdcall *OpenDevice)(int iPort, char* Message);
int (__stdcall *CloseDevice)(char* Message);
int (__stdcall *GetDeviceStatus)(char* Message);
int (__stdcall *StartIdentify)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message);
int (__stdcall *StartIdentifyV2)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message);

int (__stdcall *StopIdentify)(char* Message);
int (__stdcall *Identify)(char* Message);
int (__stdcall *IdentifyV2)(int iMaxBillValue,char* Message);
int (__stdcall *Reset)(char* Message);



#include <objsafe.h>//导入安全接口
#include "windows.h"

// ETTCashCtrl.h : CETTCashCtrl ActiveX 控件类的声明。


// CETTCashCtrl : 有关实现的信息，请参阅 ETTCashCtrl.cpp。

class CETTCashCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTCashCtrl)
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
	CETTCashCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTCashCtrl();

	DECLARE_OLECREATE_EX(CETTCashCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTCashCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTCashCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTCashCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidEndCreditcard = 18L,
		dispidGetCreditcard = 17L,
		dispidInitCreditcard = 16L,
		dispidStartIdentifyV2Ex = 15L,
		dispidStartIdentifyV2Ex2 = 14L,
		dispidResetEx = 13L,
		dispidStopIdentifyEx = 12L,
		dispidGetDeviceStatusEx = 11L,
		dispidCloseDeviceEx = 10L,
		dispidOpenDeviceEx = 9L,
		dispidCloseCashCode = 8L,
		dispidIdentifyExV2 = 7L,
		dispidInitCashCodeV2 = 6L,
		dispidInitCashCode = 5L,
		dispidDestroyDll = 4L,
		dispidLoadDll = 3L,
		dispidMessage = 2,
		dispidHasAcceptMoney = 1
	};
protected:
	void OnHasAcceptMoneyChanged(void);
	SHORT m_HasAcceptMoney;
	void OnMessageChanged(void);
	CString m_Message;
	SHORT LoadDll(void);
	SHORT DestroyDll(void);
	SHORT InitCashCode(SHORT port);
	SHORT InitCashCodeV2(SHORT port);
	SHORT IdentifyExV2(SHORT maxmoney);
	SHORT CloseCashCode(void);
	SHORT OpenDeviceEx(SHORT port);
	SHORT CloseDeviceEx(void);
	SHORT GetDeviceStatusEx(void);
	SHORT StopIdentifyEx(void);
	SHORT ResetEx(void);
	SHORT StartIdentifyV2Ex2(LPCTSTR denominations);
	SHORT StartIdentifyV2Ex(LPCTSTR denominations);
	SHORT InitCreditcard(LPCTSTR sfzmhm, LONG money, LPCTSTR bz);
	SHORT GetCreditcard(void);
	SHORT EndCreditcard(void);
};

