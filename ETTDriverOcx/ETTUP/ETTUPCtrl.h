#pragma once

//Include .h file 
#include <log4cplus/logger.h> 
#include <log4cplus/fileappender.h> 
#include <log4cplus/consoleappender.h> 
#include <log4cplus/layout.h> 
#include <log4cplus/configurator.h>
#include <log4cplus/helpers/loglog.h>
#include <log4cplus/helpers/stringhelper.h>

using namespace log4cplus; 
using namespace log4cplus::helpers; 

// Link Lib 
#ifndef _DEBUG 
#pragma comment(lib,"log4cplusUS.lib") 
#else 
#pragma comment(lib,"log4cplusUSD.lib") 
#endif 



// ETTUPCtrl.h : CETTUPCtrl ActiveX �ؼ����������


// CETTUPCtrl : �й�ʵ�ֵ���Ϣ������� ETTUPCtrl.cpp��

class CETTUPCtrl : public COleControl
{
	DECLARE_DYNCREATE(CETTUPCtrl)

// ���캯��
public:
	CETTUPCtrl();

// ��д
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();

// ʵ��
protected:
	~CETTUPCtrl();

	DECLARE_OLECREATE_EX(CETTUPCtrl)    // �๤���� guid
	DECLARE_OLETYPELIB(CETTUPCtrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTUPCtrl)     // ����ҳ ID
	DECLARE_OLECTLTYPE(CETTUPCtrl)		// �������ƺ�����״̬

// ��Ϣӳ��
	DECLARE_MESSAGE_MAP()

// ����ӳ��
	DECLARE_DISPATCH_MAP()

// �¼�ӳ��
	DECLARE_EVENT_MAP()

// ���Ⱥ��¼� ID
public:
	enum {
		dispidLog = 20L,
		dispidPayBack = 19L,
		dispidSignIn = 18L,
		dispidPay = 17L,
		dispidQueryBalance = 16L,
		dispidMake0400 = 15L,
		dispidMake0200 = 14L,
		dispidMake0800 = 13L,
		dispidUPSendData = 12L,
		dispidUnUnionPayPack = 11L,
		dispidOldSerialNo = 10,
		dispidServerPort = 9,
		dispidServerIp = 8,
		dispidRetCode = 7,
		dispidAllowBalance = 6,
		dispidBalance = 5,
		dispidBusinessNo = 4,
		dispidDeviceNo = 3,
		dispidSerialNo = 2,
		dispidMessage = 1
	};
protected:
	void OnMessageChanged(void);
	CString m_Message;
	void OnSerialNoChanged(void);
	CString m_SerialNo;
	void OnDeviceNoChanged(void);
	CString m_DeviceNo;
	void OnBusinessNoChanged(void);
	CString m_BusinessNo;
	void OnBalanceChanged(void);
	LONG m_Balance;
	void OnAllowBalanceChanged(void);
	LONG m_AllowBalance;
	void OnRetCodeChanged(void);
	SHORT m_RetCode;
	void OnServerIpChanged(void);
	CString m_ServerIp;
	void OnServerPortChanged(void);
	SHORT m_ServerPort;
	void OnOldSerialNoChanged(void);
	CString m_OldSerialNo;
	BSTR UnUnionPayPack(LPCTSTR data);
	BSTR UPSendData(LPCTSTR data);
	BSTR Make0800(void);
	BSTR Make0200(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd);
	BSTR Make0400(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd);
	void QueryBalance(LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd);
	void Pay(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd);
	void SignIn(void);
	void PayBack(LONG money, LPCTSTR track2, LPCTSTR track3, LPCTSTR pwd);
	void Log(LPCTSTR str);
};

