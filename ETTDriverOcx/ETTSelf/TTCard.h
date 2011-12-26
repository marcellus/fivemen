// TTCard.h : CTTCard ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_ITTCardEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CTTCard

class ATL_NO_VTABLE CTTCard :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CTTCard, &CLSID_TTCard>,
	public IConnectionPointContainerImpl<CTTCard>,
	public CProxy_ITTCardEvents<CTTCard>,
	public IDispatchImpl<ITTCard, &IID_ITTCard, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CTTCard()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_TTCARD)


BEGIN_COM_MAP(CTTCard)
	COM_INTERFACE_ENTRY(ITTCard)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CTTCard)
	CONNECTION_POINT_ENTRY(__uuidof(_ITTCardEvents))
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

	STDMETHOD(get_Message)(BSTR* pVal);
	STDMETHOD(put_Message)(BSTR newVal);
	STDMETHOD(get_Track1)(BSTR* pVal);
	STDMETHOD(put_Track1)(BSTR newVal);
	STDMETHOD(get_Track3)(BSTR* pVal);
	STDMETHOD(put_Track3)(BSTR newVal);
	STDMETHOD(get_Track2)(BSTR* pVal);
	STDMETHOD(put_Track2)(BSTR newVal);
	STDMETHOD(LoadDll)(void);
	STDMETHOD(DestroyDll)(void);
	STDMETHOD(DisableEntryEx)(void);
	STDMETHOD(CaptureCardEx)(void);
	STDMETHOD(OpenDeviceEx)(SHORT port);
	STDMETHOD(CloseDeviceEx)(void);
	STDMETHOD(EjectCardEx)(void);
	STDMETHOD(EnableEntryEx)(void);
	STDMETHOD(GetDeviceStatusEx)(void);
	STDMETHOD(ReadTracksEx)(void);
};

OBJECT_ENTRY_AUTO(__uuidof(TTCard), CTTCard)
