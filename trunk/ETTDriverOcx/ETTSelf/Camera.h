// Camera.h : CCamera 的声明

#pragma once
#include "resource.h"       // 主符号

#include "ETTSelf_i.h"
#include "_ICameraEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE 平台(如不提供完全 DCOM 支持的 Windows Mobile 平台)上无法正确支持单线程 COM 对象。定义 _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA 可强制 ATL 支持创建单线程 COM 对象实现并允许使用其单线程 COM 对象实现。rgs 文件中的线程模型已被设置为“Free”，原因是该模型是非 DCOM Windows CE 平台支持的唯一线程模型。"
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
