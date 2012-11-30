#pragma once
#include "ISO8583.h"
#include "LogFile.h"
#include "BalanceInquiry.h"

class CPayment
{
public:
	CPayment(void);
	virtual ~CPayment(void);

public:
	int Init();
	int ZtPwdEncryptInput();
	int GetCardNo(char *cBuf,int &nLen);
	int SendPaymentData(LPCTSTR sfxm,LONG Money,LPCTSTR bz);

	void Read8583Package(CIso8583Parse *package,BYTE *pBuf,int nField,int nLen,BYTE *pOutData);
	int GetMacData(CIso8583Package *package,char *sAccount);
	int BuildPackage(CIso8583Package *package,LONG Money);
	int ReleaseResource();
	LPCTSTR GetInputState();
public:
	CString szPayState; //0 - µ»¥˝À¢ø®£¨ 2 - µ»¥˝ ‰»Î√‹¬Î

private:
	CBalanceInquiry bi;
	CString szServerIP;
	CString szPort;
	CString szTermID;
	CString szMercCode;
	CString szKeyMode;
	CString szPinMode;
	CString szZTComPort;
	CString szZTComBaud;
	CString szTestMode;
	CString szTMIcCom;
	//CString szProCode; 
	CString szTraceCode;
	CString szTPDU;
	CString szHeader;

	bool AllowInput;
	HANDLE handle;
};
