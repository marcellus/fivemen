#pragma once

// TestCombineActiveCtrl.h : CTestCombineActiveCtrl ActiveX �ؼ����������


// CTestCombineActiveCtrl : �й�ʵ�ֵ���Ϣ������� TestCombineActiveCtrl.cpp��

class CTestCombineActiveCtrl : public COleControl
{
	DECLARE_DYNCREATE(CTestCombineActiveCtrl)

// ���캯��
public:
	CTestCombineActiveCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CTestCombineActiveCtrl();

	DECLARE_OLECREATE_EX(CTestCombineActiveCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CTestCombineActiveCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CTestCombineActiveCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CTestCombineActiveCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidHelloWordA = 1L
	};
protected:
	SHORT HelloWordA(void);
};

