#pragma once

// ETTSelfIDCardActiveXPropPage.h : CETTSelfIDCardActiveXPropPage ����ҳ���������


// CETTSelfIDCardActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTSelfIDCardActiveXPropPage.cpp��

class CETTSelfIDCardActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTSelfIDCardActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTSelfIDCardActiveXPropPage)

// ���캯��
public:
	CETTSelfIDCardActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTSELFIDCARDACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

