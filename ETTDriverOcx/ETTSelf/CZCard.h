// CZCard.h : CCZCard 的声明

#pragma once
#include "resource.h"       // 主符号

#include "ETTSelf_i.h"
#include "_ICZCardEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE 平台(如不提供完全 DCOM 支持的 Windows Mobile 平台)上无法正确支持单线程 COM 对象。定义 _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA 可强制 ATL 支持创建单线程 COM 对象实现并允许使用其单线程 COM 对象实现。rgs 文件中的线程模型已被设置为“Free”，原因是该模型是非 DCOM Windows CE 平台支持的唯一线程模型。"
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
