// CZCard.h : CCZCard ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_ICZCardEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CCZCard

class ATL_NO_VTABLE CCZCard :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCZCard, &CLSID_CZCard>,
	public IConnectionPointContainerImpl<CCZCard>,
	public CProxy_ICZCardEvents<CCZCard>,
	public IDispatchImpl<ICZCard, &IID_ICZCard, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CCZCard()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_CZCARD)


BEGIN_COM_MAP(CCZCard)
	COM_INTERFACE_ENTRY(ICZCard)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CCZCard)
	CONNECTION_POINT_ENTRY(__uuidof(_ICZCardEvents))
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

OBJECT_ENTRY_AUTO(__uuidof(CZCard), CCZCard)
