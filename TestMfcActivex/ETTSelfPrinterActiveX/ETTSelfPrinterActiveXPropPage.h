#pragma once

// ETTSelfPrinterActiveXPropPage.h : CETTSelfPrinterActiveXPropPage ����ҳ���������


// CETTSelfPrinterActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTSelfPrinterActiveXPropPage.cpp��

class CETTSelfPrinterActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTSelfPrinterActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTSelfPrinterActiveXPropPage)

// ���캯��
public:
	CETTSelfPrinterActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTSELFPRINTERACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

