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

class CETTCashCodeActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTCashCodeActiveXCtrl)

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
	CETTCashCodeActiveXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTCashCodeActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTCashCodeActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CETTCashCodeActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTCashCodeActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTCashCodeActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidMessage = 18,
		dispidStartIdentifyV2Ex = 17L,
		dispidResetEx = 16L,
		dispidStopIdentifyEx = 15L,
		dispidStartIdentifyEx = 14L,
		dispidGetDeviceStatusEx = 13L,
		dispidCloseDeviceEx = 12L,
		dispidOpenDeviceEx = 11L,
		dispidIdentifyExV2 = 10L,
		dispidInitCashCodeV2 = 9L,
		dispidIdentifyEx = 8L,
		dispidCloseCashCode = 7L,
		dispidInitCashCode = 6L,
		dispidHasAcceptMoney = 5,
		dispidAcceptMoney = 4L,
		dispidDestroyDll = 3L,
		dispidLoadDll = 2L,
		dispidTestMethod = 1L
	};
protected:
	void TestMethod(void);
	SHORT LoadDll(void);
	SHORT DestroyDll(void);
	SHORT AcceptMoney(SHORT port, SHORT money);
	void OnHasAcceptMoneyChanged(void);
	SHORT m_HasAcceptMoney;
	SHORT InitCashCode(SHORT port);
	SHORT CloseCashCode(void);
	SHORT IdentifyEx(void);
	SHORT InitCashCodeV2(SHORT port);
	SHORT IdentifyExV2(SHORT maxmoney);
	SHORT OpenDeviceEx(SHORT port);
	SHORT CloseDeviceEx(void);
	SHORT GetDeviceStatusEx(void);
	SHORT StartIdentifyEx(LPCTSTR denominations);
	SHORT StopIdentifyEx(void);
	SHORT ResetEx(void);
	SHORT StartIdentifyV2Ex(LPCTSTR denominations);
	void OnMessageChanged(void);
	CString m_Message;
};

