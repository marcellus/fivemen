#pragma once

// MyActiveXCtrl.h : CMyActiveXCtrl ActiveX �ؼ����������


// CMyActiveXCtrl : �й�ʵ�ֵ���Ϣ������� MyActiveXCtrl.cpp��
#include <objsafe.h>
//public IObjectSafetyImpl<CMyActiveXCtrl>

class CMyActiveXCtrl : public COleControl 
{
	DECLARE_DYNCREATE(CMyActiveXCtrl)

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
	CMyActiveXCtrl();
	CString MessageStr;

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CMyActiveXCtrl();

	DECLARE_OLECREATE_EX(CMyActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CMyActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CMyActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CMyActiveXCtrl)		// �������ƺ�����״̬

	// ����ؼ�֧��
	BOOL IsSubclassedControl();
	LRESULT OnOcmCommand(WPARAM wParam, LPARAM lParam);

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()
    afx_msg short ShowMessageBox();

// ����ӳ��
	DECLARE_DISPATCH_MAP()
	
//	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
	};
};

