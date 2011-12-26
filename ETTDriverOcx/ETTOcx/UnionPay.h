// UnionPay.h : CUnionPay ������

#pragma once
#include "resource.h"       // ������

#include "ETTOcx_i.h"
#include "_IUnionPayEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
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
