#pragma once

// ETTCashActiveXCtrl.h : CETTCashActiveXCtrl ActiveX �ؼ����������


// CETTCashActiveXCtrl : �й�ʵ�ֵ���Ϣ������� ETTCashActiveXCtrl.cpp��

static HINSTANCE DLLInstPrint = NULL;

//------------------------------------------------------
//����dll���еĺ��������ֽ�ʶ������̬�⺯�����ܶ���
//------------------------------------------------------
int (__stdcall *OpenDevice)(int iPort, char* Message);
int (__stdcall *CloseDevice)(char* Message);
int (__stdcall *GetDeviceStatus)(char* Message);
int (__stdcall *StartIdentify)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message);
int (__stdcall *StopIdentify)(char* Message);
int (__stdcall *Identify)(char* Message);
int (__stdcall *Reset)(char* Message);


#include <objsafe.h>//���밲ȫ�ӿ�

class CETTCashActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTCashActiveXCtrl)

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
	CETTCashActiveXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTCashActiveXCtrl();

	BEGIN_OLEFACTORY(CETTCashActiveXCtrl)        // �๤���� guid
		virtual BOOL VerifyUserLicense();
		virtual BOOL GetLicenseKey(DWORD, BSTR FAR*);
	END_OLEFACTORY(CETTCashActiveXCtrl)

	DECLARE_OLETYPELIB(CETTCashActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTCashActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTCashActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidTestMethod = 1L,
		dispidAcceptMoney = 3L,
		dispidDestoryDll = 2L,
		dispidLoadCashDll = 1L
	};
protected:
	void LoadCashDll(void);
	void DestoryDll(void);
	void AcceptMoney(SHORT money);
	void TestMethod(void);
};

