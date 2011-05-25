#pragma once

// USBVideoActiveXCtrl.h : CUSBVideoActiveXCtrl ActiveX �ؼ����������


// CUSBVideoActiveXCtrl : �й�ʵ�ֵ���Ϣ������� USBVideoActiveXCtrl.cpp��

//#include <atlctrls.h>

class CUSBVideoActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CUSBVideoActiveXCtrl)

// ���캯��
public:
	CUSBVideoActiveXCtrl();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();
	CButton m_button1;
	CButton m_button2;

// ʵ��
protected:
	~CUSBVideoActiveXCtrl();

	DECLARE_OLECREATE_EX(CUSBVideoActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CUSBVideoActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CUSBVideoActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CUSBVideoActiveXCtrl)		// �������ƺ�����״̬

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
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
};

