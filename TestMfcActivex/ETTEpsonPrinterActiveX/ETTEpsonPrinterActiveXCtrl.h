#pragma once

// ETTEpsonPrinterActiveXCtrl.h : CETTEpsonPrinterActiveXCtrl ActiveX �ؼ����������


// CETTEpsonPrinterActiveXCtrl : �й�ʵ�ֵ���Ϣ������� ETTEpsonPrinterActiveXCtrl.cpp��
static HINSTANCE DLLInstPrint = NULL;

//------------------------------------------------------
//����dll���еĺ�������������ӡ����̬�⺯�����ܶ���
//------------------------------------------------------
int (__stdcall *OpenDevice)(int iPort, char* Message);
int (__stdcall *CloseDevice)(char* Message);
int (__stdcall *GetDeviceStatus)(char* Message);
int (__stdcall *SetRowDistance)(int distance, char* Message);
int (__stdcall *PrintLine)(const char* print_data, char* Message);
int (__stdcall *CutPaper)(char* Message);
int (__stdcall *SetTextStyle)(const char *pszStyle, char* Message);
//------------------------------------------------------
//ReceiptPrinter.dll������ӡ����̬�⺯�����ܶ���
//------------------------------------------------------



int (__stdcall *SetLeftDistance) (int distance, char* Message);
int (__stdcall *PrintBitmapNV)(int index, int size, int nSpace, char* Message);



//------------------------------------------------------
//InvoicePrinter.dll��Ʊ��ӡ����̬�⺯�����ܶ���
//------------------------------------------------------



int (__stdcall *SetBlackOffset)(int P, int L, int Q, char *Message);
int (__stdcall *BlackMarkIdentify)(char *Message);
int (__stdcall *MovePaper)(int Distance, char* Message);
#include <objsafe.h>//���밲ȫ�ӿ�
#include "QPrint.h"
//#include <QPrint.h>

class CETTEpsonPrinterActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTEpsonPrinterActiveXCtrl)

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
	CETTEpsonPrinterActiveXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTEpsonPrinterActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTEpsonPrinterActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CETTEpsonPrinterActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTEpsonPrinterActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTEpsonPrinterActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidPort = 8,
		dispidPrinterPort = 7L,
		dispidPrinterName = 6,
		dispidTestMethod = 5L,
		dispidRemoveAllString = 4L,
		dispidAddString = 3L,
		dispidDestroyDll = 2L,
		dispidLoadDll = 1L
	};
	CQPrint *m_CQPrint;
	CStringArray arrStr;
protected:
	SHORT LoadDll(void);
	SHORT DestroyDll(void);
	void AddString(LPCTSTR data);
	void RemoveAllString(void);
	void TestMethod(void);
	void OnPrinterNameChanged(void);
	CString m_PrinterName;
	SHORT PrinterPort(void);
	void OnPortChanged(void);
	SHORT m_Port;
};

