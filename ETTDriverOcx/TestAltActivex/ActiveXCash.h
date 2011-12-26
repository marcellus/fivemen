// ActiveXCash.h : CActiveXCash ������

#pragma once
#include "resource.h"       // ������

#include "TestAltActivex_i.h"
#include "_IActiveXCashEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CActiveXCash

class ATL_NO_VTABLE CActiveXCash :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CActiveXCash, &CLSID_ActiveXCash>,
	public IConnectionPointContainerImpl<CActiveXCash>,
	public CProxy_IActiveXCashEvents<CActiveXCash>,
	public IDispatchImpl<IActiveXCash, &IID_IActiveXCash, &LIBID_TestAltActivexLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CActiveXCash()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_ACTIVEXCASH)


BEGIN_COM_MAP(CActiveXCash)
	COM_INTERFACE_ENTRY(IActiveXCash)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CActiveXCash)
	CONNECTION_POINT_ENTRY(__uuidof(_IActiveXCashEvents))
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

	STDMETHOD(HelloA)(LONG port);
	STDMETHOD(Hello)(void);
};

OBJECT_ENTRY_AUTO(__uuidof(ActiveXCash), CActiveXCash)
