#pragma once

// ETTCashActiveXPropPage.h : CETTCashActiveXPropPage ����ҳ���������


// CETTCashActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTCashActiveXPropPage.cpp��

class CETTCashActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTCashActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTCashActiveXPropPage)

// ���캯��
public:
	CETTCashActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTCASHACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

