// ZT598.h : CZT598 ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_IZT598Events_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CZT598

class ATL_NO_VTABLE CZT598 :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CZT598, &CLSID_ZT598>,
	public IConnectionPointContainerImpl<CZT598>,
	public CProxy_IZT598Events<CZT598>,
	public IDispatchImpl<IZT598, &IID_IZT598, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CZT598()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_ZT598)


BEGIN_COM_MAP(CZT598)
	COM_INTERFACE_ENTRY(IZT598)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CZT598)
	CONNECTION_POINT_ENTRY(__uuidof(_IZT598Events))
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

OBJECT_ENTRY_AUTO(__uuidof(ZT598), CZT598)
