#pragma once

// IDCardActiveXPropPage.h : CIDCardActiveXPropPage ����ҳ���������


// CIDCardActiveXPropPage : �й�ʵ�ֵ���Ϣ������� IDCardActiveXPropPage.cpp��

class CIDCardActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CIDCardActiveXPropPage)
	DECLARE_OLECREATE_EX(CIDCardActiveXPropPage)

// ���캯��
public:
	CIDCardActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_IDCARDACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

