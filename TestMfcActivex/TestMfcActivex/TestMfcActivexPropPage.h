#pragma once

// TestMfcActivexPropPage.h : CTestMfcActivexPropPage ����ҳ���������


// CTestMfcActivexPropPage : �й�ʵ�ֵ���Ϣ������� TestMfcActivexPropPage.cpp��

class CTestMfcActivexPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CTestMfcActivexPropPage)
	DECLARE_OLECREATE_EX(CTestMfcActivexPropPage)

// ���캯��
public:
	CTestMfcActivexPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_TESTMFCACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

