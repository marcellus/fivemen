#pragma once

// ETTSelfUSBVideoActiveXCtrl.h : CETTSelfUSBVideoActiveXCtrl ActiveX �ؼ����������
#define  IDC_Video 1
#define IDC_Bmp 2
#define IDC_Panel 3

// CETTSelfUSBVideoActiveXCtrl : �й�ʵ�ֵ���Ϣ������� ETTSelfUSBVideoActiveXCtrl.cpp��
#include <objsafe.h>//���밲ȫ�ӿ�
#include "VMR_Capture.h"

class CETTSelfUSBVideoActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTSelfUSBVideoActiveXCtrl)
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
	CETTSelfUSBVideoActiveXCtrl();
	//afx_msg void OnBnClickedButton1();
	//afx_msg void OnBnClickedButton2();
	//CButton m_button1;
	//CButton m_button2;
	CVMR_Capture m_Vmr;


// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTSelfUSBVideoActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTSelfUSBVideoActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CETTSelfUSBVideoActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTSelfUSBVideoActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTSelfUSBVideoActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidCaptureBmpDpi = 4L,
		dispidFileName = 3,
		dispidCaptureBmp = 2L,
		dispidBeginCapture = 1L
	};
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	BSTR BeginCapture(int iDevId);
	SHORT CaptureBmp(void);
protected:
	
	
	void OnFileNameChanged(void);
	CString m_FileName;
	SHORT CaptureBmpDpi(SHORT xdpi, SHORT ydpi);
};

