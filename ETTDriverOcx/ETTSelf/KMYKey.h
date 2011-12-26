// KMYKey.h : CKMYKey ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_IKMYKeyEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CKMYKey

class ATL_NO_VTABLE CKMYKey :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CKMYKey, &CLSID_KMYKey>,
	public IConnectionPointContainerImpl<CKMYKey>,
	public CProxy_IKMYKeyEvents<CKMYKey>,
	public IDispatchImpl<IKMYKey, &IID_IKMYKey, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CKMYKey()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_KMYKEY)


BEGIN_COM_MAP(CKMYKey)
	COM_INTERFACE_ENTRY(IKMYKey)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CKMYKey)
	CONNECTION_POINT_ENTRY(__uuidof(_IKMYKeyEvents))
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

OBJECT_ENTRY_AUTO(__uuidof(KMYKey), CKMYKey)
