// CashCode.h : CCashCode 的声明

#pragma once
#include "resource.h"       // 主符号

#include "ETTSelf_i.h"
#include "_ICashCodeEvents_CP.h"



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


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE 平台(如不提供完全 DCOM 支持的 Windows Mobile 平台)上无法正确支持单线程 COM 对象。定义 _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA 可强制 ATL 支持创建单线程 COM 对象实现并允许使用其单线程 COM 对象实现。rgs 文件中的线程模型已被设置为“Free”，原因是该模型是非 DCOM Windows CE 平台支持的唯一线程模型。"
#endif



// CCashCode

class ATL_NO_VTABLE CCashCode :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCashCode, &CLSID_CashCode>,
	public IConnectionPointContainerImpl<CCashCode>,
	public CProxy_ICashCodeEvents<CCashCode>,
	public IDispatchImpl<ICashCode, &IID_ICashCode, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CCashCode()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_CASHCODE)


BEGIN_COM_MAP(CCashCode)
	COM_INTERFACE_ENTRY(ICashCode)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CCashCode)
	CONNECTION_POINT_ENTRY(__uuidof(_ICashCodeEvents))
END_CONNECTION_POINT_MAP()


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:

	STDMETHOD(get_HasAcceptMoney)(SHORT* pVal);
	STDMETHOD(put_HasAcceptMoney)(SHORT newVal);
	STDMETHOD(get_Message)(BSTR* pVal);
	STDMETHOD(put_Message)(BSTR newVal);
	STDMETHOD(LoadDll)(void);
	STDMETHOD(DestroyDll)(void);
	STDMETHOD(InitCashCode)(SHORT port);
	STDMETHOD(InitCashCodeV2)(SHORT port);
	STDMETHOD(IdentifyExV2)(SHORT maxmoney);
	STDMETHOD(CloseCashCode)(void);
	STDMETHOD(OpenDeviceEx)(SHORT port);
	STDMETHOD(CloseDeviceEx)(void);
	STDMETHOD(GetDeviceStatusEx)(void);
	STDMETHOD(StopIdentifyEx)(void);
	STDMETHOD(ResetEx)(void);
	STDMETHOD(StartIdentifyV2Ex)(void);
};

OBJECT_ENTRY_AUTO(__uuidof(CashCode), CCashCode)
