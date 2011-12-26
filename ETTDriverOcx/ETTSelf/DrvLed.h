// DrvLed.h : CDrvLed ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_IDrvLedEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CDrvLed

class ATL_NO_VTABLE CDrvLed :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CDrvLed, &CLSID_DrvLed>,
	public IConnectionPointContainerImpl<CDrvLed>,
	public CProxy_IDrvLedEvents<CDrvLed>,
	public IDispatchImpl<IDrvLed, &IID_IDrvLed, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CDrvLed()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_DRVLED)


BEGIN_COM_MAP(CDrvLed)
	COM_INTERFACE_ENTRY(IDrvLed)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CDrvLed)
	CONNECTION_POINT_ENTRY(__uuidof(_IDrvLedEvents))
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

	STDMETHOD(TurnOnA8)(void);
	STDMETHOD(TurnOffA8)(void);
	STDMETHOD(TurnOnCard)(void);
	STDMETHOD(TurnOffCard)(void);
	STDMETHOD(TurnOnHotPrinter)(void);
	STDMETHOD(TurnOffHotPrinter)(void);
	STDMETHOD(TurnOnPort)(SHORT port, SHORT index);
	STDMETHOD(TurnOffAll)(void);
	STDMETHOD(TurnOnLed)(SHORT index);
	STDMETHOD(BeepHint)(void);
	STDMETHOD(Beep)(SHORT freq, SHORT duration);
};

OBJECT_ENTRY_AUTO(__uuidof(DrvLed), CDrvLed)
