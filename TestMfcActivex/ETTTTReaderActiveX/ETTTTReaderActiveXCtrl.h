#pragma once

// ETTTTReaderActiveXCtrl.h : CETTTTReaderActiveXCtrl ActiveX �ؼ����������


// CETTTTReaderActiveXCtrl : �й�ʵ�ֵ���Ϣ������� ETTTTReaderActiveXCtrl.cpp��

static HINSTANCE DLLInst = NULL;

//------------------------------------------------------
//����dll���еĺ��������ֽ�ʶ������̬�⺯�����ܶ���
//------------------------------------------------------
int (__stdcall *OpenDevice)(int iPort, char* Message);
int (__stdcall *CloseDevice)(char* Message);
int (__stdcall *GetDeviceStatus)(char* Message);

int (__stdcall *ReadTracks)(char* track1, char* track2, char* track3, char* Message);

int (__stdcall *EjectCard)(char* Message);
int (__stdcall *CaptureCard)(char* Message);
int (__stdcall *DisableEntry)(char* Message);
int (__stdcall *EnableEntry)(char* Message);

#include <objsafe.h>//���밲ȫ�ӿ�

class CETTTTReaderActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTTTReaderActiveXCtrl)

	//ISafeObject
	DECLARE_INTERFACE_MAP()

	BEGIN_INTERFACE_PART(ObjSafe, IObjectSafety)
		STDMETHOD_(HRESULT, GetInterfaceSafetyOptions) ( 
		/* [in] */ REFIID riid,
		/* [out] */ DWORD __RPC_FAR *pdwSupportedOptions,
		/* [out] */ DWORD __RPC_FAR *pdwEnabledOptions
		);

		STDMETHOD_(HRESULT, SetInterfaceSafetyOptions) ( 
			/* [in] */ REFIID riid,
			/* [in] */ DWORD dwOptionSetMask,
			/* [in] */ DWORD dwEnabledOptions
			);
	END_INTERFACE_PART(ObjSafe);

// ���캯��
public:
	CETTTTReaderActiveXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTTTReaderActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTTTReaderActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CETTTTReaderActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTTTReaderActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTTTReaderActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidTrack2 = 15,
		dispidTrack3 = 14,
		dispidTrack1 = 12,
		dispidReadTracksEx = 11L,
		dispidGetDeviceStatusEx = 10L,
		dispidEnableEntryEx = 9L,
		dispidEjectCardEx = 8L,
		dispidCloseDeviceEx = 7L,
		dispidOpenDeviceEx = 6L,
		dispidCaptureCardEx = 5L,
		dispidDisableEntryEx = 4L,
		dispidDestroyDll = 3L,
		dispidLoadDll = 2L,
		dispidMessage = 1
	};
protected:
	void OnMessageChanged(void);
	CString m_Message;
	SHORT LoadDll(void);
	SHORT DestroyDll(void);
	SHORT DisableEntryEx(void);
	SHORT CaptureCardEx(void);
	SHORT OpenDeviceEx(SHORT port);
	SHORT CloseDeviceEx(void);
	SHORT EjectCardEx(void);
	SHORT EnableEntryEx(void);
	SHORT GetDeviceStatusEx(void);
	SHORT ReadTracksEx(void);
	void OnTrack1Changed(void);
	CString m_Track1;
	void OnTrack3Changed(void);
	CString m_Track3;
	void OnTrack2Changed(void);
	CString m_Track2;
};

