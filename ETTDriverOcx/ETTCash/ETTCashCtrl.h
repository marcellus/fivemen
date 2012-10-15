#pragma once

// ETTCashCodeActiveXCtrl.h : CETTCashCodeActiveXCtrl ActiveX �ؼ����������


// CETTCashCodeActiveXCtrl : �й�ʵ�ֵ���Ϣ������� ETTCashCodeActiveXCtrl.cpp��
static HINSTANCE DLLInstPrint = NULL;

//------------------------------------------------------
//����dll���еĺ��������ֽ�ʶ������̬�⺯�����ܶ���
//------------------------------------------------------
int (__stdcall *OpenDevice)(int iPort, char* Message);
int (__stdcall *CloseDevice)(char* Message);
int (__stdcall *GetDeviceStatus)(char* Message);
int (__stdcall *StartIdentify)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message);
int (__stdcall *StartIdentifyV2)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message);

int (__stdcall *StopIdentify)(char* Message);
int (__stdcall *Identify)(char* Message);
int (__stdcall *IdentifyV2)(int iMaxBillValue,char* Message);
int (__stdcall *Reset)(char* Message);



#include <objsafe.h>//���밲ȫ�ӿ�
#include "windows.h"

// ETTCashCtrl.h : CETTCashCtrl ActiveX �ؼ����������


// CETTCashCtrl : �й�ʵ�ֵ���Ϣ������� ETTCashCtrl.cpp��

class CETTCashCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTCashCtrl)
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
	CETTCashCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTCashCtrl();

	DECLARE_OLECREATE_EX(CETTCashCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CETTCashCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTCashCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTCashCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidEndCreditcard = 18L,
		dispidGetCreditcard = 17L,
		dispidInitCreditcard = 16L,
		dispidStartIdentifyV2Ex = 15L,
		dispidStartIdentifyV2Ex2 = 14L,
		dispidResetEx = 13L,
		dispidStopIdentifyEx = 12L,
		dispidGetDeviceStatusEx = 11L,
		dispidCloseDeviceEx = 10L,
		dispidOpenDeviceEx = 9L,
		dispidCloseCashCode = 8L,
		dispidIdentifyExV2 = 7L,
		dispidInitCashCodeV2 = 6L,
		dispidInitCashCode = 5L,
		dispidDestroyDll = 4L,
		dispidLoadDll = 3L,
		dispidMessage = 2,
		dispidHasAcceptMoney = 1
	};
protected:
	void OnHasAcceptMoneyChanged(void);
	SHORT m_HasAcceptMoney;
	void OnMessageChanged(void);
	CString m_Message;
	SHORT LoadDll(void);
	SHORT DestroyDll(void);
	SHORT InitCashCode(SHORT port);
	SHORT InitCashCodeV2(SHORT port);
	SHORT IdentifyExV2(SHORT maxmoney);
	SHORT CloseCashCode(void);
	SHORT OpenDeviceEx(SHORT port);
	SHORT CloseDeviceEx(void);
	SHORT GetDeviceStatusEx(void);
	SHORT StopIdentifyEx(void);
	SHORT ResetEx(void);
	SHORT StartIdentifyV2Ex2(LPCTSTR denominations);
	SHORT StartIdentifyV2Ex(LPCTSTR denominations);
	SHORT InitCreditcard(LPCTSTR sfzmhm, LONG money, LPCTSTR bz);
	SHORT GetCreditcard(void);
	SHORT EndCreditcard(void);
};

