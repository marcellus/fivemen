#include "StdAfx.h"
#include "Register.h"
#include "ISO8583.h"
#include "Socket.h"
#include "LogFile.h"
#include "ZTKeyboardImporter.h"
#include "convert.h"

short (__stdcall* ZT_EPP_OpenCom)(short,long);
short (__stdcall* ZT_EPP_CloseCom)();
short (__stdcall* ZT_EPP_PinReadVersion)(char *,char *,char *);
short (__stdcall* ZT_EPP_PinLoadMasterKey)(int , short ,unsigned char *, char *);
short (__stdcall* ZT_EPP_SetDesPara)(short, short);
short (__stdcall* ZT_EPP_PinLoadWorkKey)(int , short ,short,unsigned char *, char * );
short (__stdcall* ZT_EPP_Des)(char *, char *, char *);
short (__stdcall* ZT_EPP_ActivWorkPin)(short ,short );
short (__stdcall* ZT_EPP_PinStartAdd)( short, short, short, short, short);
short (__stdcall* ZT_EPP_PinLoadCardNo)(char *);
short (__stdcall* ZT_EPP_OpenKeyVoic)( short );
short (__stdcall* ZT_EPP_PinReportPressed)(char *, int );
short (__stdcall* ZT_EPP_PinReadPin)(int,unsigned char *);
short (__stdcall* ZT_EPP_Undes)(char *,char *,char *);
void  (__stdcall* ZT_EPP_DllSplitBcd)(unsigned char *,unsigned char *,int);
short (__stdcall* ZT_EPP_PinCalMAC)( int, int ,char *,char *);
short (__stdcall* PinGenerateMAC)(char *,char *);
short (__stdcall* ZT_EPP_PinAdd)(int,int ,char *, char *);
short  (__stdcall* ZT_EPP_PinUnAdd)(int,int,char *, char *);
short (__stdcall* ZT_EPP_PinInitialization)( int );
short (__stdcall* ZT_EPP_TerminalNum)( char *, char * );
short (__stdcall* ZT_EPP_ICOnPower)( char * );
short (__stdcall* ZT_EPP_ICDownPower)( );
short (__stdcall* ZT_EPP_ICControl)( char *,char * );
short (__stdcall* ZT_EPP_SetICType)( int, int );
short (__stdcall* ZT_EPP_ReadICType)( int, char * );

extern LogFileEx gLog;//(".//Log", LogFileEx :: MONTH);

CRegister::CRegister(void)
{
}

CRegister::~CRegister(void)
{
}

int CRegister::SendRegisterData()
{
	TCHAR szCurPath[MAX_PATH];
	GetCurrentDirectory(sizeof(szCurPath),szCurPath);
	_tcscat(szCurPath,TEXT("\\Config.ini"));
	CString szServerIP = TEXT("");
	DWORD dwSize = 1024;
	GetPrivateProfileString(TEXT("Host"),TEXT("IP"),TEXT("127.0.0.1"),
		szServerIP.GetBuffer(dwSize),dwSize,szCurPath);
	szServerIP.ReleaseBuffer();

	CString szPort = TEXT("");
	GetPrivateProfileString(TEXT("Host"),TEXT("Port"),TEXT("18178"),
		szPort.GetBuffer(dwSize),dwSize,szCurPath);
	szPort.ReleaseBuffer();

	CString szTermID = TEXT("");
	GetPrivateProfileString(TEXT("Terminal"),TEXT("TermID"),TEXT("20292050"),
		szTermID.GetBuffer(dwSize),dwSize,szCurPath);
	szTermID.ReleaseBuffer();

	//商户号
	CString szMercCode = TEXT("");
	GetPrivateProfileString(TEXT("Merchant"),TEXT("MercCode"),TEXT("123456789012316"),
		szMercCode.GetBuffer(dwSize),dwSize,szCurPath);
	szMercCode.ReleaseBuffer();

	CString szKeyMode = TEXT("");
	GetPrivateProfileString(TEXT("KeyInputMode"),TEXT("InputMode"),TEXT("1"),
		szKeyMode.GetBuffer(dwSize),dwSize,szCurPath);
	szKeyMode.ReleaseBuffer();

	CString szTraceCode = TEXT("");
	GetPrivateProfileString(TEXT("TraceCode"),TEXT("TraceCode"),TEXT("1"),
		szTraceCode.GetBuffer(dwSize),dwSize,szCurPath);
	szTraceCode.ReleaseBuffer();

	CString szTPDU = TEXT("");
	GetPrivateProfileString(TEXT("TPDU"),TEXT("Tpdu"),TEXT("6000780000"),
		szTPDU.GetBuffer(dwSize),dwSize,szCurPath);
	szTPDU.ReleaseBuffer();

	CString szHeader = TEXT("");
	GetPrivateProfileString(TEXT("MsgHeader"),TEXT("Header"),TEXT("602200000000"),
		szHeader.GetBuffer(dwSize),dwSize,szCurPath);
	szHeader.ReleaseBuffer();

	//组包 (1) 发送请求签到
	CIso8583Package *package = new CIso8583Package();
	BuildPackage(package,szTermID.GetBuffer(),szMercCode.GetBuffer()/*,szProCode.GetBuffer()*/);
	
	BYTE cHeader[30];
	int nOffset = 0;
	cHeader[0] = 0x00;
	cHeader[1] = 0x3C;
	nOffset = 2;
	AscToBcd(cHeader + nOffset,(unsigned char *)szTPDU.GetBuffer(),szTPDU.GetLength());
	nOffset += szTPDU.GetLength() / 2;
	AscToBcd(cHeader + nOffset,(unsigned char *)szHeader.GetBuffer(),szHeader.GetLength());
	nOffset += szHeader.GetLength() / 2;
	cHeader[nOffset] = 0x08;
	nOffset += 1;
	cHeader[nOffset] = 0x00;
	nOffset += 1;

	BYTE cData[512];
	memset(cData,0,512);
	int nLen = package->GetData(cData,512,cHeader,nOffset,true);
	delete package;
	CSocket client;
	if( client.InitSocket() == FALSE) return -1;
	if( client.Connect(szServerIP,atoi(szPort)) == false) return -1;
	gLog.Log(cData,nLen);
	client.Send(cData,nLen);
	BYTE RecvData[512];
	memset(RecvData,0,512);  
	int nRecvLen = client.Receive(RecvData,512);
	if(nRecvLen != 0)
	{
		gLog.Log(RecvData,nRecvLen);
		CIso8583Parse *receivePackage = new CIso8583Parse();
		Read8583Package(receivePackage,RecvData);
		BYTE cKeyData[73];
		memset(cKeyData,0,73);
		receivePackage->ReadField(62,cKeyData,72);
		delete receivePackage;
		CString szZTComPort = TEXT("");
		GetPrivateProfileString(TEXT("ZTComPort"),TEXT("ComPort"),TEXT("3"),
			szZTComPort.GetBuffer(dwSize),dwSize,szCurPath);
		szZTComPort.ReleaseBuffer();

		CString szZTComBaud = TEXT("");
		GetPrivateProfileString(TEXT("ZTComPort"),TEXT("ComBaud"),TEXT("9600"),
			szZTComBaud.GetBuffer(dwSize),dwSize,szCurPath);
		szZTComBaud.ReleaseBuffer();

		LONG lProCode = 1;
		if( strcmp(szTraceCode.GetBuffer(),"999999") == 0)
			lProCode = 1;
		else
			lProCode = atol(szTraceCode.GetBuffer()) + 1;
		unsigned char cAsciiBuff[12];
		memset(cAsciiBuff,0,sizeof(cAsciiBuff));
		BinToAsc(cAsciiBuff,lProCode,6);
		WritePrivateProfileString(TEXT("TraceCode"),TEXT("TraceCode"),(char *)cAsciiBuff,szCurPath);

		//打开串口
		int iCode = ZT_EPP_OpenCom(atoi(szZTComPort),atoi(szZTComBaud));
		if(iCode != 0)
		{
			return -1;
		}

		//设置算法参数,工作密钥，3DES算法，16字节密钥长度
		if ( strcmp(szKeyMode,"IC") == 0)
			iCode = ZT_EPP_SetDesPara(0, 0x30);
		else if (strcmp(szKeyMode,"SAM") == 0)
			//下载工作密钥采用SAM卡内密码算法
			iCode = ZT_EPP_SetDesPara(0, 0x40);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error, " 任务出错: 设置算法参数出错！" + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}

		BYTE cPinKey[17],cMacKey[17];
		memset(cPinKey,0,17);
		memset(cMacKey,0,17);
		memcpy(cPinKey,cKeyData,16);
		memcpy(cMacKey,cKeyData+20,16);
		char cBuf[128];
		//设置工作密钥,0-PIN 加密密钥
		if (strcmp(szKeyMode,"IC") == 0)
		{
			CString sPinKey = Convert2Hex((char *)cPinKey,16);
			//0 - PIN 加密密钥
			iCode = ZT_EPP_PinLoadWorkKey(2, 0, 0, (unsigned char *)sPinKey.GetBuffer(),cBuf);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error, " 任务出错: 加载PIN密钥出错！错误码:" + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
			sPinKey.ReleaseBuffer();
			CString sMacKey = Convert2Hex((char *)cMacKey,16);//16
			//1 - MAC 加密密钥
			iCode = ZT_EPP_PinLoadWorkKey(2, 0, 1, (unsigned char *)sMacKey.GetBuffer(),cBuf);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error , " 任务出错: 加载MAC密钥失败！错误码:" + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
			sMacKey.ReleaseBuffer();
		}
		else if (strcmp(szKeyMode,"SAM") == 0 )
		{
			//(1)设置卡座,卡座1，CPU卡
			iCode = ZT_EPP_SetICType(1, 0x88);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error , " 任务出错: 设置卡座出错," + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
			//(2)上电
			iCode = ZT_EPP_ICOnPower(cBuf);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error , " 任务出错: IC卡上电出错," + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
			//(3)下载工作密钥,0 - PIK
			iCode = ZT_EPP_PinLoadWorkKey(0, 0, 0x40, cPinKey,cBuf);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error , " 任务出错: 加载PIN密钥出错！错误码:" + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
			//1 - MAC 加密密钥
			iCode = ZT_EPP_PinLoadWorkKey(0, 0, 0x41, cMacKey,cBuf);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error , " 任务出错: 加载MAC密钥失败！错误码:" + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
		}

		//关闭串口
		iCode = ZT_EPP_CloseCom();
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " 任务出错: 关闭串口失败！" + "\r\n");
			return -1;
		}
	}

	return 0;
}

void CRegister::BuildPackage(CIso8583Package *package,char *sTermID,char *sMercID/*,char *sProcCode*/)
{
	package->SetFieldData(11,6,(BYTE*)"000000");//sProcCode
	package->SetFieldData(41,8,(BYTE*)sTermID);
	package->SetFieldData(42,15,(BYTE*)sMercID);

	package->SetFieldData(60,11,(BYTE*)"00000001003");//自定义域
	package->SetFieldData(63,3,(BYTE*)"003");//自定义域
}

/* 读取报文 */
int CRegister::Read8583Package(CIso8583Parse *package,BYTE *pBuf)
{
	int fields[] = {11, 12, 13, 32, 37, 39, 41, 42, 60, 62};
	int nFields = sizeof(fields) / sizeof(int);
	if (!package->ReadMessage(pBuf,true))
		throw "Read package failed";

	return 0;
}