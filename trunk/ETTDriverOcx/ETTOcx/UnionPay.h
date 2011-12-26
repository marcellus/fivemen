// UnionPay.h : CUnionPay 的声明

#pragma once
#include "resource.h"       // 主符号

#include "ETTOcx_i.h"
#include "_IUnionPayEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE 平台(如不提供完全 DCOM 支持的 Windows Mobile 平台)上无法正确支持单线程 COM 对象。定义 _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA 可强制 ATL 支持创建单线程 COM 对象实现并允许使用其单线程 COM 对象实现。rgs 文件中的线程模型已被设置为“Free”，原因是该模型是非 DCOM Windows CE 平台支持的唯一线程模型。"
#endif



// CUnionPay

class ATL_NO_VTABLE CUnionPay :
	public IObjectSafetyImpl<CUnionPay, INTERFACESAFE_FOR_UNTRUSTED_CALLER| INTERFACESAFE_FOR_UNTRUSTED_DATA>,
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CUnionPay, &CLSID_UnionPay>,
	public ISupportErrorInfo,
	public IConnectionPointContainerImpl<CUnionPay>,
	public CProxy_IUnionPayEvents<CUnionPay>,
	public IObjectWithSiteImpl<CUnionPay>,
	public IDispatchImpl<IUnionPay, &IID_IUnionPay, &LIBID_ETTOcxLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CUnionPay()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_UNIONPAY)


BEGIN_COM_MAP(CUnionPay)
	COM_INTERFACE_ENTRY(IUnionPay)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY(IObjectWithSite)
	COM_INTERFACE_ENTRY(IObjectSafety)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CUnionPay)
	CONNECTION_POINT_ENTRY(__uuidof(_IUnionPayEvents))
END_CONNECTION_POINT_MAP()
// ISupportsErrorInfo
	STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid);


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

OBJECT_ENTRY_AUTO(__uuidof(UnionPay), CUnionPay)
