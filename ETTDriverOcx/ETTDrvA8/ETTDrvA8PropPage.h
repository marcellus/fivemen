#pragma once

// ETTDrvA8PropPage.h : CETTDrvA8PropPage ����ҳ���������


// CETTDrvA8PropPage : �й�ʵ�ֵ���Ϣ������� ETTDrvA8PropPage.cpp��

class CETTDrvA8PropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTDrvA8PropPage)
	DECLARE_OLECREATE_EX(CETTDrvA8PropPage)

// ���캯��
public:
	CETTDrvA8PropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTDRVA8 };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

