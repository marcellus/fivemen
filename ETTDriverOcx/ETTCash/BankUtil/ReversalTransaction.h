#pragma once
#include "ISO8583.h"
#include "LogFile.h"

#define YES 1 
#define NO 0 

typedef struct
{
	char cAccount[22];//���˺�
	char cProCode[3]; //���״�����
	char cMoney[6];	  //���׽��
	char cTraceNum[3];//ϵͳ���ٺ�
}ReversalTransactionData;

class CReversalTransaction
{
public:
	CReversalTransaction(void);
	virtual ~CReversalTransaction(void);

public:
	int Init();
	int SendReversalTransactionData();
	int SendReversalTransactionData(char *pAccount,LONG Money,char *cTraceCode,char *cAck);
	void Read8583Package(CIso8583Parse *package,BYTE *pBuf,int nField,int nLen,BYTE *pOutData);
	int BuildPackage(CIso8583Package *package,char *pAccount,LONG Money,char *cTraceCode,char *cAck);

private:
	CString szServerIP;
	CString szPort;
	CString szTermID;
	CString szMercCode;
	CString szTPDU;
	CString szHeader;

	bool AllowInput;
	HANDLE handle;
};
