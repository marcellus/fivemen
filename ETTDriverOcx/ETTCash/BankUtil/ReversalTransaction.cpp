#include "StdAfx.h"
#include "ReversalTransaction.h"
#include "ISO8583.h"
#include "Socket.h"
#include "ZTKeyboardImporter.h"
#include "M100_DLL.h"
#include "convert.h"

extern LogFileEx gLog;

CReversalTransaction::CReversalTransaction(void)
{
}

CReversalTransaction::~CReversalTransaction(void)
{
}


int CReversalTransaction::Init()
{
	TCHAR szCurPath[MAX_PATH];
	GetCurrentDirectory(sizeof(szCurPath),szCurPath);
	_tcscat(szCurPath,TEXT("\\Config.ini"));
	szServerIP = TEXT("");
	DWORD dwSize = 1024;
	GetPrivateProfileString(TEXT("Host"),TEXT("IP"),TEXT("127.0.0.1"),
		szServerIP.GetBuffer(dwSize),dwSize,szCurPath);
	szServerIP.ReleaseBuffer();

	szPort = TEXT("");
	GetPrivateProfileString(TEXT("Host"),TEXT("Port"),TEXT("18178"),
		szPort.GetBuffer(dwSize),dwSize,szCurPath);
	szPort.ReleaseBuffer();

	szTermID = TEXT("");
	GetPrivateProfileString(TEXT("Terminal"),TEXT("TermID"),TEXT("20292050"),
		szTermID.GetBuffer(dwSize),dwSize,szCurPath);
	szTermID.ReleaseBuffer();

	//商户号
	szMercCode = TEXT("");
	GetPrivateProfileString(TEXT("Merchant"),TEXT("MercCode"),TEXT("123456789012316"),
		szMercCode.GetBuffer(dwSize),dwSize,szCurPath);
	szMercCode.ReleaseBuffer();

	szTPDU = TEXT("");
	GetPrivateProfileString(TEXT("TPDU"),TEXT("Tpdu"),TEXT("6000780000"),
		szTPDU.GetBuffer(dwSize),dwSize,szCurPath);
	szTPDU.ReleaseBuffer();

	szHeader = TEXT("");
	GetPrivateProfileString(TEXT("MsgHeader"),TEXT("Header"),TEXT("602200000000"),
		szHeader.GetBuffer(dwSize),dwSize,szCurPath);
	szHeader.ReleaseBuffer();

	return 0;
}

int CReversalTransaction::SendReversalTransactionData()
{
	TCHAR szCurPath[MAX_PATH];
	GetCurrentDirectory(sizeof(szCurPath),szCurPath);
	_tcscat(szCurPath,TEXT("\\Reversal.ini"));

	CString szAccount = TEXT("");
	CString szTraceCode = TEXT("");
	CString szMoney = TEXT("");
	CString szAck = TEXT("");
	CString szFlag = TEXT("");

	DWORD dwSize = 1024;

	GetPrivateProfileString(TEXT("Reversal"),TEXT("Account"),TEXT(""),
		szAccount.GetBuffer(dwSize),dwSize,szCurPath);
	szAccount.ReleaseBuffer();

	GetPrivateProfileString(TEXT("Reversal"),TEXT("TraceCode"),TEXT(""),
		szTraceCode.GetBuffer(dwSize),dwSize,szCurPath);
	szTraceCode.ReleaseBuffer();

	GetPrivateProfileString(TEXT("Reversal"),TEXT("Money"),TEXT(""),
		szMoney.GetBuffer(dwSize),dwSize,szCurPath);
	szMoney.ReleaseBuffer();

	GetPrivateProfileString(TEXT("Reversal"),TEXT("Ack"),TEXT(""),
		szAck.GetBuffer(dwSize),dwSize,szCurPath);
	szAck.ReleaseBuffer();

	GetPrivateProfileString(TEXT("Reversal"),TEXT("Flag"),TEXT(""),
		szFlag.GetBuffer(dwSize),dwSize,szCurPath);
	szFlag.ReleaseBuffer();

	if( strcmp(szFlag.GetBuffer(),"1") != 0 )
	{
		return SendReversalTransactionData(szAccount.GetBuffer(),atol(szMoney.GetBuffer()),szTraceCode.GetBuffer(),szAck.GetBuffer());
	}

	return 1;
}

int CReversalTransaction::SendReversalTransactionData(char *pAccount,LONG Money,char *cTraceCode,char *cAck)
{
	//组包
	CIso8583Package *package = new CIso8583Package();
	int iRes = BuildPackage(package,pAccount,Money,cTraceCode,cAck);
	if (iRes != 0) return iRes;   //组包不成功，返回错误码

	BYTE cHeader[30];
	int nOffset = 0;
	AscToBcd(cHeader + nOffset,(unsigned char *)szTPDU.GetBuffer(),szTPDU.GetLength());
	nOffset += szTPDU.GetLength() / 2;
	AscToBcd(cHeader + nOffset,(unsigned char *)szHeader.GetBuffer(),szHeader.GetLength());
	nOffset += szHeader.GetLength() / 2;
	cHeader[nOffset] = 0x04;
	nOffset += 1;
	cHeader[nOffset] = 0x00;
	nOffset += 1;

	BYTE cData[512];
	memset(cData,0,512);
	unsigned int nLen = package->GetData(cData,512,cHeader,nOffset,false);
	delete package;

	char cLen[5] = {'\0'};
	itoa_hex(nLen,cLen,2);
	unsigned char cDataLen[3] = {'\0'};
	AscToBcd(cDataLen,(unsigned char *)cLen,4);
	BYTE cPackageData[512];
	memset(cPackageData,0,sizeof(cPackageData));
	memcpy(cPackageData,cDataLen,2);
	memcpy(cPackageData + 2,cData,nLen);

	CSocket client;
	if( client.InitSocket() == FALSE) return -1;
	if( client.Connect(szServerIP,atoi(szPort)) == false) return -1;
	gLog.Log(cData,nLen);
	client.Send(cData,nLen);
	BYTE RecvData[1024];
	memset(RecvData,0,1024);
	nLen = client.Receive(RecvData,1024);
	if(nLen != 0)
	{
		gLog.Log(RecvData,nLen);
		CIso8583Parse *receivePackage = new CIso8583Parse();
		char cResult[128];
		memset(cResult,0,128);
		Read8583Package(receivePackage,RecvData,39,2,(BYTE *)cResult);
		delete receivePackage;
		if(strcmp(cResult,"00") == 0)
		{
			TCHAR szCurPath[MAX_PATH];
			GetCurrentDirectory(sizeof(szCurPath),szCurPath);
			_tcscat(szCurPath,TEXT("\\Reversal.ini"));
			WritePrivateProfileString(TEXT("Reversal"),TEXT("Account"),"",szCurPath);
			WritePrivateProfileString(TEXT("Reversal"),TEXT("TraceCode"),"",szCurPath);
			WritePrivateProfileString(TEXT("Reversal"),TEXT("Money"),"",szCurPath);
			WritePrivateProfileString(TEXT("Reversal"),TEXT("Ack"),"",szCurPath);
			WritePrivateProfileString(TEXT("Reversal"),TEXT("Flag"),"1",szCurPath);//1 -- 已处理
		}
	}

	return 1;
}

int CReversalTransaction::BuildPackage(CIso8583Package *package,char *pAccount,LONG Money,char *cTraceCode,char *cAck)
{
	if( pAccount == NULL ) return -1;
	if( cTraceCode == NULL ) return -1;
	if( cAck == NULL ) return -1;
	if( Money == 0) return -1;

	int money = Money * 100;//* 100 
	char szMoney[13] = {'\0'};
	_snprintf(szMoney,12,"%012d",money);

	package->SetFieldData(3,6,(BYTE*)"000000");
	package->SetFieldData(4,12,(BYTE*)szMoney);
	package->SetFieldData(11,6,(BYTE*)cTraceCode);

	package->SetFieldData(22,3,(BYTE*)"021");
	package->SetFieldData(25,2,(BYTE*)"00");
	package->SetFieldData(39,2,(BYTE*)cAck);

	package->SetFieldData(2,strlen(pAccount),(BYTE *)pAccount);

	package->SetFieldData(41,8,(BYTE*)szTermID.GetBuffer());	//终端号
	package->SetFieldData(42,15,(BYTE*)szMercCode.GetBuffer()); //商户号
	package->SetFieldData(49,3,(BYTE*)"156");
	char cReserved[9] = "22";
	strcat(cReserved,cTraceCode);
	package->SetFieldData(60,8,(BYTE*)cReserved);//自定义域 

	return 0;
}

void CReversalTransaction::Read8583Package(CIso8583Parse *package,BYTE *pBuf,int nField,int nLen,BYTE *pOutData)
{
	if (!package->ReadMessage(pBuf,true))
		throw "Read package failed";

	package->ReadField(nField, pOutData, nLen);
}
