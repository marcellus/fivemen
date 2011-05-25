#pragma once
////////////////////////////////////////////////////////////////////////////
//                        ����activex��ȫ�ӿ�
////////////////////////////////////////////////////////////////////////////
#include <objsafe.h>
////////////////////////////////////////////////////////////////////////////
//                        ����activex��ȫ�ӿ�
////////////////////////////////////////////////////////////////////////////
//public IObjectSafetyImpl<CIDCardActiveXCtrl>

// IDCardActiveXCtrl.h : CIDCardActiveXCtrl ActiveX �ؼ����������


// CIDCardActiveXCtrl : �й�ʵ�ֵ���Ϣ������� IDCardActiveXCtrl.cpp��

class CIDCardActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CIDCardActiveXCtrl)
////////////////////////////////////////////////////////////////////////////
//                        ����activex��ȫ�ӿ�
////////////////////////////////////////////////////////////////////////////
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

////////////////////////////////////////////////////////////////////////////
//                        ����activex��ȫ�ӿ�
////////////////////////////////////////////////////////////////////////////

// ���캯��
public:
	CIDCardActiveXCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CIDCardActiveXCtrl();

	DECLARE_OLECREATE_EX(CIDCardActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CIDCardActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CIDCardActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CIDCardActiveXCtrl)		// �������ƺ�����״̬

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
};

