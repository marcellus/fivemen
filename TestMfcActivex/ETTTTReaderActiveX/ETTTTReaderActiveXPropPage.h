#pragma once

// ETTTTReaderActiveXPropPage.h : CETTTTReaderActiveXPropPage ����ҳ���������


// CETTTTReaderActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTTTReaderActiveXPropPage.cpp��

class CETTTTReaderActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTTTReaderActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTTTReaderActiveXPropPage)

// ���캯��
public:
	CETTTTReaderActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTTTREADERACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

