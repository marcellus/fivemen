#pragma once

// ETTPrintActiveXPropPage.h : CETTPrintActiveXPropPage ����ҳ���������


// CETTPrintActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTPrintActiveXPropPage.cpp��

class CETTPrintActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTPrintActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTPrintActiveXPropPage)

// ���캯��
public:
	CETTPrintActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTPRINTACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

