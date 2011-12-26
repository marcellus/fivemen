// A8.h : CA8 ������

#pragma once
#include "resource.h"       // ������

#include "ETTSelf_i.h"
#include "_IA8Events_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CA8

class ATL_NO_VTABLE CA8 :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CA8, &CLSID_A8>,
	public IConnectionPointContainerImpl<CA8>,
	public CProxy_IA8Events<CA8>,
	public IDispatchImpl<IA8, &IID_IA8, &LIBID_ETTSelfLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CA8()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_A8)


BEGIN_COM_MAP(CA8)
	COM_INTERFACE_ENTRY(IA8)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CA8)
	CONNECTION_POINT_ENTRY(__uuidof(_IA8Events))
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
	STDMETHOD(get_IdCardImgFileName)(BSTR* pVal);
	STDMETHOD(put_IdCardImgFileName)(BSTR newVal);
	STDMETHOD(get_IdCardFrontImgFileName)(BSTR* pVal);
	STDMETHOD(put_IdCardFrontImgFileName)(BSTR newVal);
	STDMETHOD(get_IdCardEndImgFileName)(BSTR* pVal);
	STDMETHOD(put_IdCardEndImgFileName)(BSTR newVal);
	STDMETHOD(get_IsReaded)(SHORT* pVal);
	STDMETHOD(put_IsReaded)(SHORT newVal);
	STDMETHOD(get_UserName)(BSTR* pVal);
	STDMETHOD(put_UserName)(BSTR newVal);
	STDMETHOD(get_SexCode)(SHORT* pVal);
	STDMETHOD(put_SexCode)(SHORT newVal);
	STDMETHOD(get_SexName)(BSTR* pVal);
	STDMETHOD(put_SexName)(BSTR newVal);
	STDMETHOD(get_NationCode)(BSTR* pVal);
	STDMETHOD(put_NationCode)(BSTR newVal);
	STDMETHOD(get_NationName)(BSTR* pVal);
	STDMETHOD(put_NationName)(BSTR newVal);
	STDMETHOD(get_Birth)(BSTR* pVal);
	STDMETHOD(put_Birth)(BSTR newVal);
	STDMETHOD(get_Address)(BSTR* pVal);
	STDMETHOD(put_Address)(BSTR newVal);
	STDMETHOD(get_Fzjg)(BSTR* pVal);
	STDMETHOD(put_Fzjg)(BSTR newVal);
	STDMETHOD(get_StartDate)(BSTR* pVal);
	STDMETHOD(put_StartDate)(BSTR newVal);
	STDMETHOD(get_EndDate)(BSTR* pVal);
	STDMETHOD(put_EndDate)(BSTR newVal);
	STDMETHOD(get_YxqxCode)(BSTR* pVal);
	STDMETHOD(put_YxqxCode)(BSTR newVal);
	STDMETHOD(get_YxqxName)(BSTR* pVal);
	STDMETHOD(put_YxqxName)(BSTR newVal);
	STDMETHOD(get_IdCard)(BSTR* pVal);
	STDMETHOD(put_IdCard)(BSTR newVal);
	STDMETHOD(LoadDll)(void);
	STDMETHOD(OpenDeviceEx)(SHORT port);
	STDMETHOD(CloseDeviceEx)(void);
	STDMETHOD(EnterCardEx)(void);
	STDMETHOD(EjectCardEx)(void);
	STDMETHOD(DestroyDll)(void);
	STDMETHOD(ReadAndScanEx)(void);
	STDMETHOD(GetDeviceStatusEx)(void);
	STDMETHOD(CalibrationEx)(void);
	STDMETHOD(InitNationArray)(void);
	STDMETHOD(GetCardStatusEx)(void);
	STDMETHOD(ReadAndScanDpiEx)(LONG dpi);
	STDMETHOD(ReadRFID)(void);
};

OBJECT_ENTRY_AUTO(__uuidof(A8), CA8)
