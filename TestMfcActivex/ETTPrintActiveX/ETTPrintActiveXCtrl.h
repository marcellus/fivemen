#pragma once

// ETTPrintActiveXCtrl.h : CETTPrintActiveXCtrl ActiveX �ؼ����������


// CETTPrintActiveXCtrl : �й�ʵ�ֵ���Ϣ������� ETTPrintActiveXCtrl.cpp��

#include <objsafe.h>//���밲ȫ�ӿ�
#include "qprint.h"

class CETTPrintActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTPrintActiveXCtrl)
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
	CETTPrintActiveXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTPrintActiveXCtrl();

	DECLARE_OLECREATE_EX(CETTPrintActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CETTPrintActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTPrintActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTPrintActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
	};
	// ����������ƾ֤��ӡ
	int CarAcceptPrint(void);
	// ��ӡ�ؼ���
	CQPrint *m_CQPrint;
};

