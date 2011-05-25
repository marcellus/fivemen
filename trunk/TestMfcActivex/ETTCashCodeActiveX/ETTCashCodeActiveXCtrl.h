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

class CETTCashCodeActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTCashCodeActiveXCtrl)

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
	CETTCashCodeActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTCashCodeActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTCashCodeActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTCashCodeActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTCashCodeActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTCashCodeActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidMessage = 18,
		dispidStartIdentifyV2Ex = 17L,
		dispidResetEx = 16L,
		dispidStopIdentifyEx = 15L,
		dispidStartIdentifyEx = 14L,
		dispidGetDeviceStatusEx = 13L,
		dispidCloseDeviceEx = 12L,
		dispidOpenDeviceEx = 11L,
		dispidIdentifyExV2 = 10L,
		dispidInitCashCodeV2 = 9L,
		dispidIdentifyEx = 8L,
		dispidCloseCashCode = 7L,
		dispidInitCashCode = 6L,
		dispidHasAcceptMoney = 5,
		dispidAcceptMoney = 4L,
		dispidDestroyDll = 3L,
		dispidLoadDll = 2L,
		dispidTestMethod = 1L
	};
protected:
	void TestMethod(void);
	SHORT LoadDll(void);
	SHORT DestroyDll(void);
	SHORT AcceptMoney(SHORT port, SHORT money);
	void OnHasAcceptMoneyChanged(void);
	SHORT m_HasAcceptMoney;
	SHORT InitCashCode(SHORT port);
	SHORT CloseCashCode(void);
	SHORT IdentifyEx(void);
	SHORT InitCashCodeV2(SHORT port);
	SHORT IdentifyExV2(SHORT maxmoney);
	SHORT OpenDeviceEx(SHORT port);
	SHORT CloseDeviceEx(void);
	SHORT GetDeviceStatusEx(void);
	SHORT StartIdentifyEx(LPCTSTR denominations);
	SHORT StopIdentifyEx(void);
	SHORT ResetEx(void);
	SHORT StartIdentifyV2Ex(LPCTSTR denominations);
	void OnMessageChanged(void);
	CString m_Message;
};

