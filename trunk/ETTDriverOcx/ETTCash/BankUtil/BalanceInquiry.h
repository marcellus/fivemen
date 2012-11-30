#pragma once
#include "ISO8583.h"
#include "LogFile.h"


class CBalanceInquiry
{
public:
	CBalanceInquiry(void);
	virtual ~CBalanceInquiry(void);

public:
	int SendBalanceInquiryData();

	int BuildPackage(CIso8583Package *package);
	int	 Read8583Package(CIso8583Parse *package,BYTE *pBuf);
	void Read8583Package(CIso8583Parse *package,BYTE *pBuf,int nField,int nLen,BYTE *pOutData);

	int Init();
	int ZtPwdEncryptInput();
	int GetCardNo(char *cBuf,int &nLen);

	int GetMacData(CIso8583Package *package,char *sAccount);
	int ReleaseResource();

public:
	CString szPayState; //0 - µ»¥˝À¢ø®£¨ 2 - µ»¥˝ ‰»Î√‹¬Î

private:
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
	CString szAcquirerID;
	CString szForwardingID;
	CString szProCode;
	CString szTraceCode;
	CString szTPDU;
	CString szHeader;

	bool AllowInput;
	HANDLE handle;
};
