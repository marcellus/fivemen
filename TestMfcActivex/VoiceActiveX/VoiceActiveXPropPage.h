#pragma once

// VoiceActiveXPropPage.h : CVoiceActiveXPropPage 属性页类的声明。


// CVoiceActiveXPropPage : 有关实现的信息，请参阅 VoiceActiveXPropPage.cpp。

class CVoiceActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CVoiceActiveXPropPage)
	DECLARE_OLECREATE_EX(CVoiceActiveXPropPage)

// 构造函数
public:
	CVoiceActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_VOICEACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

