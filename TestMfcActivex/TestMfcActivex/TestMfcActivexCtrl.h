#pragma once

// TestMfcActivexCtrl.h : CTestMfcActivexCtrl ActiveX �ؼ����������


// CTestMfcActivexCtrl : �й�ʵ�ֵ���Ϣ������� TestMfcActivexCtrl.cpp��

class CTestMfcActivexCtrl : public COleControl
{
	DECLARE_DYNCREATE(CTestMfcActivexCtrl)

// ���캯��
public:
	CTestMfcActivexCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CTestMfcActivexCtrl();

	DECLARE_OLECREATE_EX(CTestMfcActivexCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CTestMfcActivexCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CTestMfcActivexCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CTestMfcActivexCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

	afx_msg void AboutBox();

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
	};
};

