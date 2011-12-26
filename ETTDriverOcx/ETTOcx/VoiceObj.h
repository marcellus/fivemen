// VoiceObj.h : CVoiceObj ������

#pragma once
#include "resource.h"       // ������

#include "ETTOcx_i.h"
#include "_IVoiceObjEvents_CP.h"

#include "comutil.h"

#include <windows.h> 
#include <stdlib.h> 
#include <time.h> 
#include <mmsystem.h> 

#pragma comment(lib, "winmm.lib") 

#pragma comment(lib, "comsuppw.lib")



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif



// CVoiceObj

class ATL_NO_VTABLE CVoiceObj :
	public IObjectSafetyImpl<CVoiceObj, INTERFACESAFE_FOR_UNTRUSTED_CALLER| INTERFACESAFE_FOR_UNTRUSTED_DATA>,
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CVoiceObj, &CLSID_VoiceObj>,
	public ISupportErrorInfo,
	public IConnectionPointContainerImpl<CVoiceObj>,
	public CProxy_IVoiceObjEvents<CVoiceObj>,
	public IObjectWithSiteImpl<CVoiceObj>,
	public IDispatchImpl<IVoiceObj, &IID_IVoiceObj, &LIBID_ETTOcxLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
	

{
public:
	CVoiceObj()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_VOICEOBJ)


BEGIN_COM_MAP(CVoiceObj)
	COM_INTERFACE_ENTRY(IVoiceObj)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY(IObjectWithSite)
	COM_INTERFACE_ENTRY(IObjectSafety)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CVoiceObj)
	CONNECTION_POINT_ENTRY(__uuidof(_IVoiceObjEvents))
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

	STDMETHOD(PlayVoice)(BSTR filename);
};

OBJECT_ENTRY_AUTO(__uuidof(VoiceObj), CVoiceObj)
