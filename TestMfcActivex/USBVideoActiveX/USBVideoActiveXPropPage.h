#pragma once

// USBVideoActiveXPropPage.h : CUSBVideoActiveXPropPage ����ҳ���������


// CUSBVideoActiveXPropPage : �й�ʵ�ֵ���Ϣ������� USBVideoActiveXPropPage.cpp��

class CUSBVideoActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CUSBVideoActiveXPropPage)
	DECLARE_OLECREATE_EX(CUSBVideoActiveXPropPage)

// ���캯��
public:
	CUSBVideoActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_USBVIDEOACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

