// Camera.h : CCamera ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_ICameraEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CCamera

class ATL_NO_VTABLE CCamera :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CCamera, &CLSID_Camera>,
	public IConnectionPointContainerImpl<CCamera>,
	public CProxy_ICameraEvents<CCamera>,
	public IDispatchImpl<ICamera, &IID_ICamera, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CCamera()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_CAMERA)


BEGIN_COM_MAP(CCamera)
	COM_INTERFACE_ENTRY(ICamera)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CCamera)
	CONNECTION_POINT_ENTRY(__uuidof(_ICameraEvents))
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

OBJECT_ENTRY_AUTO(__uuidof(Camera), CCamera)
