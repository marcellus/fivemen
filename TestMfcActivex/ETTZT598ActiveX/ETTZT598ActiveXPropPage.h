#pragma once

// ETTZT598ActiveXPropPage.h : CETTZT598ActiveXPropPage ����ҳ���������


// CETTZT598ActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTZT598ActiveXPropPage.cpp��

class CETTZT598ActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTZT598ActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTZT598ActiveXPropPage)

// ���캯��
public:
	CETTZT598ActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTZT598ACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

