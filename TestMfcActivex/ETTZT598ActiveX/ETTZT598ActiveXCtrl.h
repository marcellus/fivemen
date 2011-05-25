#pragma once

// ETTZT598ActiveXCtrl.h : CETTZT598ActiveXCtrl ActiveX �ؼ����������


// CETTZT598ActiveXCtrl : �й�ʵ�ֵ���Ϣ������� ETTZT598ActiveXCtrl.cpp��

static HINSTANCE DLLInst = NULL;

//------------------------------------------------------
//����dll���еĺ��������ֽ�ʶ������̬�⺯�����ܶ���
//------------------------------------------------------
/*
short ZT_EPP_OpenCom( short iPort, long lBaud)
short   ZT_EPP_CloseCom()
short ZT_EPP_PinInitialization( short iInitMode )
Short ZT_EPP_PinReadVersion(char *cpVersion,char *cpSN,char *cpRechang)
short ZT_EPP_SetDesPara(short iPara,short iFCode)
short  ZT_EPP_PinLoadMasterKey( short iKMode,short iKeyNo, LPCTSTR lpKey,char *cpExChk)

short  ZT_EPP_PinLoadWorkKey(short iKMode,short iMKeyNo,short iKeyNo,LPCTSTR lpKey,char *cpExChk)
short ZT_EPP_ActivWorkPin(short iMKeyNo,short iWKeyNo)
short  ZT_EPP_PinLoadCardNo(LPCTSTR lpCardNo)
short ZT_EPP_OpenKeyVoic( short iValue)
short ZT_EPP_PinStartAdd(short iPinLen,short iDispMode,short iPINMode,short iPromMode,short iTimeOut)
short ZT_EPP_PinReportPressed(char *cpKey,short iTimeOut)

short ZT_EPP_PinReadPin(short iKMode, char *cpPinBlock)
short ZT_EPP_PinCalMAC(short iKMode, short iMacMode,LPCTSTR lpValue, char *cpExValue)
short ZT_EPP_PinAdd(short iKMode,short iMode, LPCTSTR lpValue,char *cpExValue)
short ZT_EPP_PinUnAdd(short iKMode,short iMode,LPCTSTR lpValue,char *cpExValue)
short WINAPI ZT_EPP_SetICType(short iIC,short iICType);
short WINAPI ZT_EPP_ICOnPower( char *chOutData )
short ZT_EPP_ICControl(LPCTSTR lpValue, char *cpExValue)

*/
short (__stdcall *ZT_EPP_OpenCom)( short iPort, long lBaud);
short (__stdcall *ZT_EPP_CloseCom)();
short (__stdcall *ZT_EPP_PinInitialization)( short iInitMode);
short (__stdcall *ZT_EPP_PinReadVersion)(char *cpVersion,char *cpSN,char *cpRechang);
short (__stdcall *ZT_EPP_SetDesPara)(short iPara,short iFCode);
short (__stdcall *ZT_EPP_PinLoadMasterKey)( short iKMode,short iKeyNo, LPCTSTR lpKey,char *cpExChk);

short (__stdcall *ZT_EPP_PinLoadWorkKey)(short iKMode,short iMKeyNo,short iKeyNo,LPCTSTR lpKey,char *cpExChk);
short (__stdcall *ZT_EPP_ActivWorkPin) (short iMKeyNo,short iWKeyNo);
short (__stdcall *ZT_EPP_PinLoadCardNo) (LPCTSTR lpCardNo);
short (__stdcall *ZT_EPP_OpenKeyVoic)( short iValue);
short (__stdcall *ZT_EPP_PinStartAdd)(short iPinLen,short iDispMode,short iPINMode,short iPromMode,short iTimeOut);
short (__stdcall *ZT_EPP_PinReportPressed)(char *cpKey,short iTimeOut);

short (__stdcall *ZT_EPP_PinReadPin)(short iKMode, char *cpPinBlock);
short (__stdcall *ZT_EPP_PinCalMAC)(short iKMode, short iMacMode,LPCTSTR lpValue, char *cpExValue);
short (__stdcall *ZT_EPP_PinAdd)(short iKMode,short iMode, LPCTSTR lpValue,char *cpExValue);
short (__stdcall *ZT_EPP_PinUnAdd)(short iKMode,short iMode,LPCTSTR lpValue,char *cpExValue);
short (__stdcall *ZT_EPP_SetICType)(short iIC,short iICType);
short (__stdcall *ZT_EPP_ICOnPower)( char *chOutData );
short (__stdcall *ZT_EPP_ICControl)(LPCTSTR lpValue, char *cpExValue);




#include <objsafe.h>//���밲ȫ�ӿ�

class CETTZT598ActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTZT598ActiveXCtrl)
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
	CETTZT598ActiveXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTZT598ActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTZT598ActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CETTZT598ActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTZT598ActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTZT598ActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidGetUserPin = 14L,
		dispidPinReportPressedEx = 13L,
		dispidPinReadPinEx = 12L,
		dispidPinStartAddEx = 11L,
		dispidOpenKeyVoicEx = 10L,
		dispidActivWorkPinEx = 9L,
		dispidPinLoadCardNoEx = 8L,
		dispidIsInputOver = 7,
		dispidOpenDeviceEx = 6L,
		dispidCloseDeviceEx = 5L,
		
		dispidDestroyDll = 3L,

		dispidLoadDll = 2L,
		dispidMessage = 1
	};
protected:
	void OnMessageChanged(void);
	CString m_Message;
	SHORT LoadDll(void);

	SHORT DestroyDll(void);
	
	SHORT CloseDeviceEx(void);
	SHORT OpenDeviceEx(SHORT port);
	void OnIsInputOverChanged(void);
	SHORT m_IsInputOver;
	SHORT PinLoadCardNoEx(LPCTSTR pan);
	SHORT ActivWorkPinEx(SHORT masterKeyIndex, SHORT workKeyIndex);
	SHORT OpenKeyVoicEx(SHORT param);
	SHORT PinStartAddEx(SHORT len, SHORT pinMode, SHORT timeout);
	SHORT PinReadPinEx(void);
	SHORT PinReportPressedEx(void);
	SHORT GetUserPin(SHORT peaMode);
};

