#pragma once

// TestCombineActivePropPage.h : CTestCombineActivePropPage ����ҳ���������


// CTestCombineActivePropPage : �й�ʵ�ֵ���Ϣ������� TestCombineActivePropPage.cpp��

class CTestCombineActivePropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CTestCombineActivePropPage)
	DECLARE_OLECREATE_EX(CTestCombineActivePropPage)

// ���캯��
public:
	CTestCombineActivePropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_TESTCOMBINEACTIVE };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

