#pragma once

// ETTCashPropPage.h : CETTCashPropPage ����ҳ���������


// CETTCashPropPage : �й�ʵ�ֵ���Ϣ������� ETTCashPropPage.cpp��

class CETTCashPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTCashPropPage)
	DECLARE_OLECREATE_EX(CETTCashPropPage)

// ���캯��
public:
	CETTCashPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTCASH };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

