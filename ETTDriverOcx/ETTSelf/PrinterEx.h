// PrinterEx.h : CPrinterEx ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_IPrinterExEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CPrinterEx

class ATL_NO_VTABLE CPrinterEx :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CPrinterEx, &CLSID_PrinterEx>,
	public IConnectionPointContainerImpl<CPrinterEx>,
	public CProxy_IPrinterExEvents<CPrinterEx>,
	public IDispatchImpl<IPrinterEx, &IID_IPrinterEx, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CPrinterEx()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_PRINTEREX)


BEGIN_COM_MAP(CPrinterEx)
	COM_INTERFACE_ENTRY(IPrinterEx)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CPrinterEx)
	CONNECTION_POINT_ENTRY(__uuidof(_IPrinterExEvents))
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

};

OBJECT_ENTRY_AUTO(__uuidof(PrinterEx), CPrinterEx)
