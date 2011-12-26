// TTCard.h : CTTCard 的声明

#pragma once
#include "resource.h"       // 主符号

#include "ETTSelf_i.h"
#include "_ITTCardEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE 平台(如不提供完全 DCOM 支持的 Windows Mobile 平台)上无法正确支持单线程 COM 对象。定义 _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA 可强制 ATL 支持创建单线程 COM 对象实现并允许使用其单线程 COM 对象实现。rgs 文件中的线程模型已被设置为“Free”，原因是该模型是非 DCOM Windows CE 平台支持的唯一线程模型。"
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
