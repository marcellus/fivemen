#pragma once

// IdCardReaderActiveXCtrl.h : CIdCardReaderActiveXCtrl ActiveX �ؼ����������


// CIdCardReaderActiveXCtrl : �й�ʵ�ֵ���Ϣ������� IdCardReaderActiveXCtrl.cpp��

class CIdCardReaderActiveXCtrl : public COleControl
{
	DECLARE_DYNCREATE(CIdCardReaderActiveXCtrl)

// ���캯��
public:
	CIdCardReaderActiveXCtrl();
	short ComPort,baud,databits,stopbits,Change,TrackNo;
	CString parity,Password,Tk_Data2,Tk_Data3,port,ResultStr;
	long Timeout;

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CIdCardReaderActiveXCtrl();

	DECLARE_OLECREATE_EX(CIdCardReaderActiveXCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CIdCardReaderActiveXCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CIdCardReaderActiveXCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CIdCardReaderActiveXCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()
	

	afx_msg short ReadString();

// ����ӳ��
	DECLARE_DISPATCH_MAP()

	afx_msg void AboutBox();

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
	};
};

