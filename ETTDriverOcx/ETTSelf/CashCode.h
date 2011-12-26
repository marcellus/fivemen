// CashCode.h : CCashCode ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_ICashCodeEvents_CP.h"



// CETTCashCodeActiveXCtrl : �й�ʵ�ֵ���Ϣ������� ETTCashCodeActiveXCtrl.cpp��
static HINSTANCE DLLInstPrint = NULL;

//------------------------------------------------------
//����dll���еĺ��������ֽ�ʶ������̬�⺯�����ܶ���
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
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
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
