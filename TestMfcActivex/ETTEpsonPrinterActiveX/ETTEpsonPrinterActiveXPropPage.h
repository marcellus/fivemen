#pragma once

// ETTEpsonPrinterActiveXPropPage.h : CETTEpsonPrinterActiveXPropPage ����ҳ���������


// CETTEpsonPrinterActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTEpsonPrinterActiveXPropPage.cpp��

class CETTEpsonPrinterActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTEpsonPrinterActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTEpsonPrinterActiveXPropPage)

// ���캯��
public:
	CETTEpsonPrinterActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTEPSONPRINTERACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

