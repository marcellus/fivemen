#pragma once

// TestCombine3PropPage.h : CTestCombine3PropPage ����ҳ���������


// CTestCombine3PropPage : �й�ʵ�ֵ���Ϣ������� TestCombine3PropPage.cpp��

class CTestCombine3PropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CTestCombine3PropPage)
	DECLARE_OLECREATE_EX(CTestCombine3PropPage)

// ���캯��
public:
	CTestCombine3PropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_TESTCOMBINE3 };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

