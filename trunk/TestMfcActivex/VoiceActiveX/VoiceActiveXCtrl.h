#pragma once


// VoiceActiveXCtrl.h : CVoiceActiveXCtrl ActiveX 控件类的声明。


// CVoiceActiveXCtrl : 有关实现的信息，请参阅 VoiceActiveXCtrl.cpp。

#include <objsafe.h>//导入安全接口
#include <mmsystem.h>//导入声音头文件
#pragma comment(lib,"winmm.lib")//导入声音头文件库
//public IObjectSafetyImpl<CVoiceActiveXCtrl>
class CVoiceActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CVoiceActiveXCtrl)
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
	CVoiceActiveXCtrl();
	CString m_FileName;
	void OnFileNameChanged(void);
	void PlayVoice(LPCTSTR IDR_Voice);

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CVoiceActiveXCtrl();

	DECLARE_OLECREATE_EX(CVoiceActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CVoiceActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CVoiceActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CVoiceActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidPlayVoice = 2L,
		dispidFileName = 1
	};
protected:
	
	
};

