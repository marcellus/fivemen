// IdCard.h : CIdCard ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_IIdCardEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CIdCard

class ATL_NO_VTABLE CIdCard :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CIdCard, &CLSID_IdCard>,
	public IConnectionPointContainerImpl<CIdCard>,
	public CProxy_IIdCardEvents<CIdCard>,
	public IDispatchImpl<IIdCard, &IID_IIdCard, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CIdCard()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_IDCARD)


BEGIN_COM_MAP(CIdCard)
	COM_INTERFACE_ENTRY(IIdCard)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CIdCard)
	CONNECTION_POINT_ENTRY(__uuidof(_IIdCardEvents))
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

OBJECT_ENTRY_AUTO(__uuidof(IdCard), CIdCard)
