#pragma once

// ETTA8IDCardActiveXPropPage.h : CETTA8IDCardActiveXPropPage ����ҳ���������


// CETTA8IDCardActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTA8IDCardActiveXPropPage.cpp��

class CETTA8IDCardActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTA8IDCardActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTA8IDCardActiveXPropPage)

// ���캯��
public:
	CETTA8IDCardActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTA8IDCARDACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

