#pragma once

// ETTPrinterPropPage.h : CETTPrinterPropPage ����ҳ���������


// CETTPrinterPropPage : �й�ʵ�ֵ���Ϣ������� ETTPrinterPropPage.cpp��

class CETTPrinterPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTPrinterPropPage)
	DECLARE_OLECREATE_EX(CETTPrinterPropPage)

// ���캯��
public:
	CETTPrinterPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTPRINTER };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

