#pragma once

// VoiceActiveXPropPage.h : CVoiceActiveXPropPage ����ҳ���������


// CVoiceActiveXPropPage : �й�ʵ�ֵ���Ϣ������� VoiceActiveXPropPage.cpp��

class CVoiceActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CVoiceActiveXPropPage)
	DECLARE_OLECREATE_EX(CVoiceActiveXPropPage)

// ���캯��
public:
	CVoiceActiveXPropPage();

// �Ի�������
	enum { IDD = IDD_PROPPAGE_VOICEACTIVEX };

// ʵ��
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ��Ϣӳ��
protected:
	DECLARE_MESSAGE_MAP()
};

