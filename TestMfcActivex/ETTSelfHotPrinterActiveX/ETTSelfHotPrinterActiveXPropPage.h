#pragma once

// ETTSelfHotPrinterActiveXPropPage.h : CETTSelfHotPrinterActiveXPropPage ����ҳ���������


// CETTSelfHotPrinterActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTSelfHotPrinterActiveXPropPage.cpp��

class CETTSelfHotPrinterActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTSelfHotPrinterActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTSelfHotPrinterActiveXPropPage)

// ���캯��
public:
	CETTSelfHotPrinterActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTSELFHOTPRINTERACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

