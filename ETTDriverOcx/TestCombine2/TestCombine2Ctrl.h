#pragma once

// TestCombine2Ctrl.h : CTestCombine2Ctrl ActiveX �ؼ����������


// CTestCombine2Ctrl : �й�ʵ�ֵ���Ϣ������� TestCombine2Ctrl.cpp��

class CTestCombine2Ctrl : public COleControl
{
	DECLARE_DYNCREATE(CTestCombine2Ctrl)

// ���캯��
public:
	CTestCombine2Ctrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CTestCombine2Ctrl();

	DECLARE_OLECREATE_EX(CTestCombine2Ctrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CTestCombine2Ctrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CTestCombine2Ctrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CTestCombine2Ctrl)		// �������ƺ�����״̬

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

