// ActiveXLed.h : CActiveXLed ������

#pragma once
#include "resource.h"       // ������

#include "TestAltActivex_i.h"
#include "_IActiveXLedEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CActiveXLed

class ATL_NO_VTABLE CActiveXLed :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CActiveXLed, &CLSID_ActiveXLed>,
	public IConnectionPointContainerImpl<CActiveXLed>,
	public CProxy_IActiveXLedEvents<CActiveXLed>,
	public IDispatchImpl<IActiveXLed, &IID_IActiveXLed, &LIBID_TestAltActivexLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CActiveXLed()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_ACTIVEXLED)


BEGIN_COM_MAP(CActiveXLed)
	COM_INTERFACE_ENTRY(IActiveXLed)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CActiveXLed)
	CONNECTION_POINT_ENTRY(__uuidof(_IActiveXLedEvents))
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

	STDMETHOD(HelloB)(SHORT port);
	STDMETHOD(Hello)(void);
};

OBJECT_ENTRY_AUTO(__uuidof(ActiveXLed), CActiveXLed)
