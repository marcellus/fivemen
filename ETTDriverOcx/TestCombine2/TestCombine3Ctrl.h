#pragma once

// TestCombine3Ctrl.h : CTestCombine3Ctrl ActiveX �ؼ����������


// CTestCombine3Ctrl : �й�ʵ�ֵ���Ϣ������� TestCombine3Ctrl.cpp��

class CTestCombine3Ctrl : public COleControl
{
	DECLARE_DYNCREATE(CTestCombine3Ctrl)

	// ���캯��
public:
	CTestCombine3Ctrl();

	// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

	// ʵ��
protected:
	~CTestCombine3Ctrl();

	DECLARE_OLECREATE_EX(CTestCombine3Ctrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CTestCombine3Ctrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CTestCombine3Ctrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CTestCombine3Ctrl)		// �������ƺ�����״̬

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

