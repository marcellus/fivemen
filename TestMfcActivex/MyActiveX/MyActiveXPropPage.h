#pragma once

// MyActiveXPropPage.h : CMyActiveXPropPage ����ҳ���������


// CMyActiveXPropPage : �й�ʵ�ֵ���Ϣ������� MyActiveXPropPage.cpp��

class CMyActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CMyActiveXPropPage)
	DECLARE_OLECREATE_EX(CMyActiveXPropPage)

// ���캯��
public:
	CMyActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_MYACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

