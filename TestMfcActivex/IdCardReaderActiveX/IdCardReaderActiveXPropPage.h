#pragma once

// IdCardReaderActiveXPropPage.h : CIdCardReaderActiveXPropPage ����ҳ���������


// CIdCardReaderActiveXPropPage : �й�ʵ�ֵ���Ϣ������� IdCardReaderActiveXPropPage.cpp��

class CIdCardReaderActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CIdCardReaderActiveXPropPage)
	DECLARE_OLECREATE_EX(CIdCardReaderActiveXPropPage)

// ���캯��
public:
	CIdCardReaderActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_IDCARDREADERACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

