#pragma once

// ETTSelfUSBVideoActiveXPropPage.h : CETTSelfUSBVideoActiveXPropPage ����ҳ���������


// CETTSelfUSBVideoActiveXPropPage : �й�ʵ�ֵ���Ϣ������� ETTSelfUSBVideoActiveXPropPage.cpp��

class CETTSelfUSBVideoActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CETTSelfUSBVideoActiveXPropPage)
	DECLARE_OLECREATE_EX(CETTSelfUSBVideoActiveXPropPage)

// ���캯��
public:
	CETTSelfUSBVideoActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_ETTSELFUSBVIDEOACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

