#pragma once

// ETTCashCodeActiveXPropPage.h : CETTCashCodeActiveXPropPage ����ҳ���������


// CETTCashCodeActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTCashCodeActiveXPropPage.cpp��

class CETTCashCodeActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTCashCodeActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTCashCodeActiveXPropPage)

// ���캯��
public:
	CETTCashCodeActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTCASHCODEACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

