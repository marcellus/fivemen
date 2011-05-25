#pragma once

// ETTTTReaderActiveXCtrl.h : CETTTTReaderActiveXCtrl ActiveX 控件类的声明。


// CETTTTReaderActiveXCtrl : 有关实现的信息，请参阅 ETTTTReaderActiveXCtrl.cpp。

static HINSTANCE DLLInst = NULL;

//------------------------------------------------------
//两个dll都有的函数定义现金识别器动态库函数功能定义
//------------------------------------------------------
int (__stdcall *OpenDevice)(int iPort, char* Message);
int (__stdcall *CloseDevice)(char* Message);
int (__stdcall *GetDeviceStatus)(char* Message);

int (__stdcall *ReadTracks)(char* track1, char* track2, char* track3, char* Message);

int (__stdcall *EjectCard)(char* Message);
int (__stdcall *CaptureCard)(char* Message);
int (__stdcall *DisableEntry)(char* Message);
int (__stdcall *EnableEntry)(char* Message);

#include <objsafe.h>//导入安全接口

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

// 构造函数
public:
	CETTTTReaderActiveXCtrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CETTTTReaderActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTTTReaderActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTTTReaderActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTTTReaderActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTTTReaderActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
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

