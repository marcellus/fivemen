#pragma once

// IdCardReaderActiveXCtrl.h : CIdCardReaderActiveXCtrl ActiveX 控件类的声明。


// CIdCardReaderActiveXCtrl : 有关实现的信息，请参阅 IdCardReaderActiveXCtrl.cpp。

class CIdCardReaderActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CIdCardReaderActiveXCtrl)

// 构造函数
public:
	CIdCardReaderActiveXCtrl();
	short ComPort,baud,databits,stopbits,Change,TrackNo;
	CString parity,Password,Tk_Data2,Tk_Data3,port,ResultStr;
	long Timeout;

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// 实现
protected:
	~CIdCardReaderActiveXCtrl();

	DECLARE_OLECREATE_EX(CIdCardReaderActiveXCtrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CIdCardReaderActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CIdCardReaderActiveXCtrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CIdCardReaderActiveXCtrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()
	

	afx_msg short ReadString();

// 调度映射
	DECLARE_DISPATCH_MAP()

	afx_msg void AboutBox();

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
	};
};

