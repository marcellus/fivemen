#pragma once

// ETTSelfUSBVideoActiveXCtrl.h : CETTSelfUSBVideoActiveXCtrl ActiveX 控件类的声明。
#define  IDC_Video 1
#define IDC_Bmp 2
#define IDC_Panel 3

// CETTSelfUSBVideoActiveXCtrl : 有关实现的信息，请参阅 ETTSelfUSBVideoActiveXCtrl.cpp。
#include <objsafe.h>//导入安全接口
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

// 构造函数
public:
	CETTSelfUSBVideoActiveXCtrl();
	//afx_msg void OnBnClickedButton1();
	//afx_msg void OnBnClickedButton2();
	//CButton m_button1;
	//CButton m_button2;
	CVMR_Capture m_Vmr;


// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTSelfUSBVideoActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTSelfUSBVideoActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTSelfUSBVideoActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTSelfUSBVideoActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTSelfUSBVideoActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
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

