#pragma once

// ETTUPPropPage.h : CETTUPPropPage ����ҳ���������


// CETTUPPropPage : �й�ʵ�ֵ���Ϣ������� ETTUPPropPage.cpp��

class CETTUPPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTUPPropPage)
	DECLARE_OLECREATE_EX(CETTUPPropPage)

// ���캯��
public:
	CETTUPPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTUP };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

