#pragma once


// VoiceActiveXCtrl.h : CVoiceActiveXCtrl ActiveX �ؼ����������


// CVoiceActiveXCtrl : �й�ʵ�ֵ���Ϣ������� VoiceActiveXCtrl.cpp��

#include <objsafe.h>//���밲ȫ�ӿ�
#include <mmsystem.h>//��������ͷ�ļ�
#pragma comment(lib,"winmm.lib")//��������ͷ�ļ���
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


// ���캯��
public:
	CVoiceActiveXCtrl();
	CString m_FileName;
	void OnFileNameChanged(void);
	void PlayVoice(LPCTSTR IDR_Voice);

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CVoiceActiveXCtrl();

	DECLARE_OLECREATE_EX(CVoiceActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CVoiceActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CVoiceActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CVoiceActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidPlayVoice = 2L,
		dispidFileName = 1
	};
protected:
	
	
};

