#include "StdAfx.h"
#include "Payment.h"
#include "ISO8583.h"
#include "Socket.h"
#include "ZTKeyboardImporter.h"
#include "M100_DLL.h"
#include "Register.h"
#include "convert.h"
#include "ReversalTransaction.h"

LogFileEx gLog(".//Log", LogFileEx :: MONTH);

CPayment::CPayment(void)
{
	Init();
}

CPayment::~CPayment(void)
{
	ReleaseResource();
}

int CPayment::Init()
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

	//�̻���
	szMercCode = TEXT("");
	GetPrivateProfileString(TEXT("Merchant"),TEXT("MercCode"),TEXT("123456789012316"),
		szMercCode.GetBuffer(dwSize),dwSize,szCurPath);
	szMercCode.ReleaseBuffer();

	szKeyMode = TEXT("");
	GetPrivateProfileString(TEXT("KeyInputMode"),TEXT("InputMode"),TEXT("1"),
		szKeyMode.GetBuffer(dwSize),dwSize,szCurPath);
	szKeyMode.ReleaseBuffer();

	szPinMode = TEXT("");
	GetPrivateProfileString(TEXT("PinMode"),TEXT("PinInputMode"),TEXT("1"),
		szPinMode.GetBuffer(dwSize),dwSize,szCurPath);
	szPinMode.ReleaseBuffer();

	szZTComPort = TEXT("");
	GetPrivateProfileString(TEXT("ZTComPort"),TEXT("ComPort"),TEXT("3"),
		szZTComPort.GetBuffer(dwSize),dwSize,szCurPath);
	szZTComPort.ReleaseBuffer();

	szZTComBaud = TEXT("");
	GetPrivateProfileString(TEXT("ZTComPort"),TEXT("ComBaud"),TEXT("9600"),
		szZTComBaud.GetBuffer(dwSize),dwSize,szCurPath);
	szZTComBaud.ReleaseBuffer();

	szTestMode = TEXT("");
	GetPrivateProfileString(TEXT("TestMode"),TEXT("Test"),TEXT("0"),
		szTestMode.GetBuffer(dwSize),dwSize,szCurPath);
	szTestMode.ReleaseBuffer();

	szTMIcCom = TEXT("");
	GetPrivateProfileString(TEXT("TMIcCom"),TEXT("IcCom"),TEXT("0"),
		szTMIcCom.GetBuffer(dwSize),dwSize,szCurPath);
	szTMIcCom.ReleaseBuffer();

	szTraceCode = TEXT("");
	GetPrivateProfileString(TEXT("TraceCode"),TEXT("TraceCode"),TEXT("000001"),
		szTraceCode.GetBuffer(dwSize),dwSize,szCurPath);
	szTraceCode.ReleaseBuffer();

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

int CPayment::SendPaymentData(LPCTSTR sfxm,LONG Money,LPCTSTR bz)
{
	bool bIsStand = true;

	szPayState = "3";//�������ڴ���

	//���
	CIso8583Package *package = new CIso8583Package();
	if (package != 0) 
	{
		szPayState = "E7";
		return -1;   //������ɹ������ش�����
	}
	char c48Field[255];
	memset(c48Field,0,sizeof(c48Field));

	if( strcmp(sfxm,"3001") == 0)
	{
		bIsStand = false;
		const char *split = "|"; 
		char *pTemp = new char[128];
		strcpy(pTemp,bz);
		char *pToken = strtok (pTemp,split); 
		if( pToken == NULL ) return -1;
		int nOffset = strlen(pToken);
		memcpy(c48Field,pToken,strlen(pToken));
		pToken = strtok(NULL,"|");
		if( pToken == NULL ) return -1;
		memcpy(c48Field + nOffset,pToken,strlen(pToken));
		nOffset += strlen(pToken);
		pToken = strtok(NULL,"|");
		if( pToken == NULL ) return -1;
		memcpy(c48Field + nOffset,pToken,strlen(pToken));
		nOffset += strlen(pToken);
		pToken = strtok(NULL,"|");
		if( pToken == NULL ) return -1;
		memcpy(c48Field + nOffset,pToken,strlen(pToken));
		nOffset += strlen(pToken);

		package->SetFieldData(48,nOffset,(BYTE *)c48Field);//48��Ŀǰ�����д�������޷������ҵ��

	}
	else
	{//���������շ���Ŀ
		int nOffset = 0;
		nOffset = strlen(sfxm);
		memcpy(c48Field,sfxm,nOffset);
		memcpy(c48Field + nOffset,bz,strlen(bz));
		nOffset += strlen(bz);
		package->SetFieldData(48,nOffset,(BYTE *)c48Field);//48��Ŀǰ�����д�������޷������ҵ��
	}

	int iRes = BuildPackage(package,Money);
	if (iRes != 0) 
	{
		szPayState = "E7";
		return iRes;   //������ɹ������ش�����
	}

	BYTE cHeader[30];
	int nOffset = 0;
	AscToBcd(cHeader + nOffset,(unsigned char *)szTPDU.GetBuffer(),szTPDU.GetLength());
	nOffset += szTPDU.GetLength() / 2;
	AscToBcd(cHeader + nOffset,(unsigned char *)szHeader.GetBuffer(),szHeader.GetLength());
	nOffset += szHeader.GetLength() / 2;
	cHeader[nOffset] = 0x02;
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

	TCHAR szCurPath[MAX_PATH];
	GetCurrentDirectory(sizeof(szCurPath),szCurPath);
	_tcscat(szCurPath,TEXT("\\Reversal.ini"));

	CSocket client;
	if( client.InitSocket() == FALSE)
	{
		szPayState = "E7";
		return -1;
	}
	if( client.Connect(szServerIP,atoi(szPort)) == false)
	{
		szPayState = "E7";
		return -1;
	}
	gLog.Log(cPackageData,nLen + 2);
	client.Send(cPackageData,nLen + 2);
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

		LONG lProCode = atol(szTraceCode.GetBuffer()) + 1;
		unsigned char cAsciiBuff[12];
		memset(cAsciiBuff,0,sizeof(cAsciiBuff));
		BinToAsc(cAsciiBuff,lProCode,6);
		WritePrivateProfileString(TEXT("TraceCode"),TEXT("TraceCode"),(char *)cAsciiBuff,szCurPath);
		if(strcmp(cResult,"A0") == 0) //�������������˵����MAC����Ҳ��Ҫ����
		{
			WritePrivateProfileString(TEXT("Reversal"),TEXT("Ack"),"A0",szCurPath);
			WritePrivateProfileString(TEXT("Reversal"),TEXT("Flag"),"0",szCurPath);//0 -- δ����
			CReversalTransaction transaction;
			transaction.SendReversalTransactionData();//��������
		}
		else if( strcmp(cResult,"05") == 0)
		{//��֤ʧ��
			szPayState = "E2";
			return -1;
		}
		else if( strcmp(cResult,"51") == 0)
		{
			szPayState = "E5";
			return -1;
		}
		else if( strcmp(cResult, "55") == 0)
		{
			szPayState = "E2";
			return -1;
		}
		else if( strcmp(cResult, "75") == 0)
		{
			szPayState = "E1";
			return -1;
		}
		szPayState = "1";//���׳ɹ�
	}
	else
	{//����ԭ�����ѳ���
		szPayState = "E6";
		WritePrivateProfileString(TEXT("Reversal"),TEXT("Ack"),"98",szCurPath);//POS�ն���ʱ����δ���յ�POS���ĵ�Ӧ����Ϣ������
		WritePrivateProfileString(TEXT("Reversal"),TEXT("Flag"),"0",szCurPath);//0 -- δ����
		CReversalTransaction transaction;
		transaction.SendReversalTransactionData();//��������
	}

	return 1;//���׳ɹ�
}

int CPayment::GetCardNo(char *cBuf,int &nLen)
{
	handle = M100_CommOpen(szTMIcCom.GetBuffer());
	if (handle == 0)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: �򿪴��ڳ���\r\n");
		return -1;
	}

	BYTE cVerInfo[128];
	int iCode = M100_Reset(handle, 0x31, cVerInfo);
	if (iCode != 0)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: ��λ����������\r\n");
		M100_CommClose(handle);
		return -1;
	}
	int state = 0;  //ˢ��״̬
	iCode = M100_EnterCard(handle, 0x30, 60000);  //ֱ�����뿨�ŷ��أ��ȴ�60��
	if (iCode == -3)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: �޿����룬�ȴ���ʱ��\r\n");
		M100_CommClose(handle);
		return -1;
	}
	else if (iCode != 0)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: �޿����룡\r\n");
		M100_CommClose(handle);
		return -1;
	}

	DWORD dataLen = 0;
	BYTE cTrackData[40];
	iCode = M100_ReadMagcardDecode(handle, 0x31, &dataLen, cTrackData);//��ȡ�ڶ������Ϣ
	if (iCode != 0)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: ��ȡ�ſ���Ϣ����\r\n");
		M100_CommClose(handle);
		return -1;
	}
	if (dataLen < 39)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: ��ȡ�ſ���Ϣ����\r\n");
		M100_CommClose(handle);
		return -1;
	}

	//iCode = M100_Reset(handle, 0x31, sVerInfo);

	//iCode = M100_CommClose(handle);
	//if (iCode != 0)
	//{
	//    LogManager.WriteLog(LogFile.Error , " �������: �ر�TM100���ڳ���\r\n");
	//}
	memcpy(cBuf,cTrackData + 2,37);

	return 0;
}

int CPayment::BuildPackage(CIso8583Package *package,LONG Money)
{
	int money = Money * 100;//* 100 
	char szMoney[13] = {'\0'};
	_snprintf(szMoney,12,"%012d",money);

	TCHAR szCurPath[MAX_PATH];
	GetCurrentDirectory(sizeof(szCurPath),szCurPath);
	_tcscat(szCurPath,TEXT("\\Reversal.ini"));
	char cTemp[5];
	WritePrivateProfileString(TEXT("Reversal"),TEXT("Money"),ltoa(Money,cTemp,10),szCurPath);

	package->SetFieldData(3,6,(BYTE*)"000000");
	package->SetFieldData(4,12,(BYTE*)szMoney);
	package->SetFieldData(11,6,(BYTE*)szTraceCode.GetBuffer());
	WritePrivateProfileString(TEXT("Reversal"),TEXT("TraceCode"),szTraceCode.GetBuffer(),szCurPath);

	if( strcmp(szTraceCode.GetBuffer(),"999999") == 0)
		szTraceCode = "000001";
	package->SetFieldData(22,3,(BYTE*)"021");
	package->SetFieldData(25,2,(BYTE*)"00");
	package->SetFieldData(26,2,(BYTE*)"12");


	char *pAccount;
	if (strcmp(szTestMode.GetBuffer(),"1") == 0)
	{
		package->SetFieldData(2,19,(BYTE*)"9559480089076438611"); //���ʺ�
		pAccount = "9559480089076438611";
		package->SetFieldData(35,37,(BYTE*)"9559480089076438611=00004209600000000");//�ŵ�
	}
	else
	{
		char cCard[40];
		int nLen = 0;
		if( GetCardNo(cCard,nLen) != 0) return -1;
		package->SetFieldData(35,37,(BYTE *)cCard);

		const char *split = "="; 
		pAccount = strtok (cCard,split); 
		if(pAccount == NULL) return -1;
		package->SetFieldData(2,strlen(pAccount),(BYTE *)pAccount);//19
		WritePrivateProfileString(TEXT("Reversal"),TEXT("Account"),pAccount,szCurPath);
	}

	package->SetFieldData(41,8,(BYTE*)szTermID.GetBuffer());	//�ն˺�
	package->SetFieldData(42,15,(BYTE*)szMercCode.GetBuffer()); //�̻���
	package->SetFieldData(49,3,(BYTE*)"156");
	package->SetFieldData(53,16,(BYTE*)"2600000000000000");
	char cReserved[9] = "22";
	strcat(cReserved,szTraceCode.GetBuffer());
	package->SetFieldData(60,8,(BYTE*)cReserved);//�Զ����� "22002025"
	package->SetFieldData(63,3,(BYTE*)"001");//�Զ�����

	if (GetMacData(package, pAccount) != 0)
	{
		return -1;
	}

	return 0;
}

int CPayment::GetMacData(CIso8583Package *package,char *sAccount)
{
	//�򿪴���
	int iCode = ZT_EPP_OpenCom(atoi(szZTComPort.GetBuffer()), atoi(szZTComBaud.GetBuffer()));
	if (iCode != 0)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: �򿪽���������̴��ڳ���,�˿ڱ�ռ�ã�" + "\r\n");
		return -1;
	}

	char cBuf[50];

	if (strcmp(szPinMode.GetBuffer(),"0") == 0) //ǰ����
	{
		//(1)����PIN����ʱʹ�õ���Կ�� -- ȡPINֵ,ǰ����
		if (strcmp(szKeyMode.GetBuffer(),"SAM") == 0)
		{
			//(1)���ÿ���,����1��CPU��
			iCode = ZT_EPP_SetICType(1, 0x88);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error , " �������: ���ÿ�������," + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
			//(2)�ϵ�
			iCode = ZT_EPP_ICOnPower(cBuf);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error , " �������: IC���ϵ����," + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
			//(3)�����㷨����
			iCode = ZT_EPP_SetDesPara(0, 0x30);
			if (iCode != 0)
			{
				//LogManager.WriteLog(LogFile.Error , " �������: �����㷨��������," + iCode + "\r\n");
				ZT_EPP_CloseCom();
				return -1;
			}
		}

		iCode = ZT_EPP_SetDesPara(1, 0x30);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " �������: �����㷨��������," + iCode + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}

		//(1)�������Կ
		iCode = ZT_EPP_ActivWorkPin(0, 0);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " �������: �������Կ," + iCode + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}

		//(2)���ÿ���
		char cAccount[13] ={'\0'};
		int offset = strlen(sAccount) - 13;
		memcpy(cAccount,sAccount + offset,12);
		iCode = ZT_EPP_PinLoadCardNo(cAccount);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " �������: �޷����ÿ��ţ�" + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}

		//(3)�رռ����Ҵ򿪰�������
		iCode = ZT_EPP_OpenKeyVoic(2);

		if (strcmp(szKeyMode.GetBuffer(),"IC") == 0)
		{
			//��������PIN��������3DES-2key�����㷨��������Կ����
			iCode = ZT_EPP_SetDesPara(1, 0x30); 
		}

		//��������PIN��ʱ����<F>ֵ���PIN�ұ�ֱ��8�ֽ�
		iCode = ZT_EPP_SetDesPara(2, 0xFF);

		//(4)����������̼���
		iCode = ZT_EPP_PinStartAdd(6, 1, 1, 0, 30);   

		AllowInput = true;
		//(5)ѭ����ȡʹ���߰�����ֵ
		ZtPwdEncryptInput();
		AllowInput = false;

		//(6)������ȡPIN����
		unsigned char cPin[20]={'\0'};
		iCode = ZT_EPP_PinReadPin(0, cPin);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " �������: ȡPIN���ĳ���," + iCode + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}
		package->SetFieldData(52,8,cPin);
	}
	else if (strcmp(szPinMode.GetBuffer(),"1") == 0)
	{
		//(2)�رռ����Ҵ򿪰�������
		iCode = ZT_EPP_OpenKeyVoic(2);

		////��������PIN��������3DES-2key�����㷨��������Կ����
		//iCode = ZT_EPP_SetDesPara(1, 0x30);

		//iCode = ZT_EPP_SetDesPara(2, 0xFF);

		//(3)����������̼���
		iCode = ZT_EPP_PinStartAdd(6, 1, 0, 0, 30);

		AllowInput = true;
		//(4)ѭ����ȡʹ���߰�����ֵ
		ZtPwdEncryptInput();
		AllowInput = false;

		//(5)����PIN����ʱʹ�õ���Կ�� -- ȡPINֵ,ǰ����
		if (strcmp(szKeyMode.GetBuffer(),"IC") == 0)
			iCode = ZT_EPP_ActivWorkPin(0, 0);
		else if (strcmp(szKeyMode.GetBuffer(),"SAM") == 0)
			iCode = ZT_EPP_ActivWorkPin(0, 0x40);

		////��������PIN��������3DES-2key�����㷨��������Կ����
		//iCode = ZT_EPP_SetDesPara(1, 0x30);
		////��������PIN��ʱ����<F>ֵ���PIN�ұ�ֱ��8�ֽ�
		//iCode = ZT_EPP_SetDesPara(2, 0xFF);

		iCode = ZT_EPP_SetDesPara(4, 0x10);

		//(6)���ÿ���
		char cAccount[13] ={'\0'};
		int offset = strlen(sAccount) - 13;
		memcpy(cAccount,sAccount + offset,12);
		iCode = ZT_EPP_PinLoadCardNo(cAccount);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " �������: �޷����ÿ��ţ�" + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}

		//(7)������ȡPIN����
		unsigned char cPin[20]={'\0'};
		iCode = ZT_EPP_PinReadPin(2, cPin);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " �������: ȡPIN���ĳ���," + iCode + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}
		package->SetFieldData(52,8,cPin);
	}
	//(7) �رս�������
	ZT_EPP_OpenKeyVoic(0);
	if (strcmp(szKeyMode.GetBuffer(),"SAM") == 0)
	{
		iCode = ZT_EPP_SetDesPara(0, 0x30);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " �������: �����㷨��������," + iCode + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}
		iCode = ZT_EPP_SetDesPara(1, 0x30);
		if (iCode != 0)
		{
			//LogManager.WriteLog(LogFile.Error , " �������: �����㷨��������," + iCode + "\r\n");
			ZT_EPP_CloseCom();
			return -1;
		}
	}
	//�������Կ - MAC
	iCode = ZT_EPP_ActivWorkPin(0, 1);

	//ȡ��Ҫ����MAC���������
	BYTE cData[1024];
	memset(cData,0,1024);
	BYTE cType[] ={0x02,0x00};
	int nLen = package->GetData(cData,1024,cType,2,true);
	int nGroup = 0;
	if( nLen % 8 == 0)
		nGroup = nLen / 8;
	else
		nGroup = nLen / 8 + 1;
	CString sMacData = Convert2Hex((char *)cData,nGroup * 8);

	//MAC��������
	char cMac[17]={'\0'};
	iCode = ZT_EPP_PinCalMAC(1, 4, /*cMacData*/sMacData.GetBuffer(), cMac);
	if (iCode != 0)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: MAC�����������," + iCode + "\r\n");
		ZT_EPP_CloseCom();
		return -1;
	}

	sMacData.ReleaseBuffer();

	//�رմ���
	iCode = ZT_EPP_CloseCom();

	package->SetFieldData(64,8,(BYTE*)cMac);

	return 0;
}

/* ��ȡ���� */
void CPayment::Read8583Package(CIso8583Parse *package,BYTE *pBuf,int nField,int nLen,BYTE *pOutData)
{
	if (!package->ReadMessage(pBuf,true))
		throw "Read package failed";

	package->ReadField(nField, pOutData, nLen);
}

int CPayment::ZtPwdEncryptInput()
{
	char pin1[20]={0},chpin[20]={0},cCount[3]={'\0'};
	short i=0;
	int iRet=0;
	MSG Message;
	unsigned long TimeCurr,TimeEnd;
	TimeCurr = GetTickCount();
	TimeEnd= 60*1000;

	while( 1 )
	{
		if(::PeekMessage(&Message,NULL,0,0,PM_REMOVE))
		{
			::TranslateMessage(&Message);
			::DispatchMessage(&Message);
		}

		//if ( !stop)
		//{
		//	ZT_EPP_OpenKeyVoic(0x00);
		//	break;
		//}
		if( GetTickCount()- TimeCurr>TimeEnd )
		{
			ZT_EPP_OpenKeyVoic(0x00);
			break;
		}

		iRet = ZT_EPP_PinReportPressed(pin1,500);
		if( iRet )
		{
			continue;
		}
		if(0x0D==pin1[0]&&i>0)
		{
			chpin[i]=pin1[0];
			ZT_EPP_OpenKeyVoic(0x00);
			//stop=false;
			break;
		}
		else if (0x08 == pin1[0])
		{
			memset(chpin,'\0',20);
			i=0;
			szPayState = "2";//�ȴ���������
			continue;
		}
		else if (0x1B == pin1[0])
		{
			i=0;
			break;
		}
		else if(0x2A == pin1[0])
		{
			chpin[i]=pin1[0];
			i++;
			_snprintf(cCount,2,"%02d",20 + i);
			szPayState = cCount;
		}
	}
	return 0;
}

int CPayment::ReleaseResource()
{
	BYTE cVerInfo[128];
	int iCode = M100_Reset(handle, 0x31, cVerInfo);
	if (iCode != 0)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: �ر�TM100���ڳ���\r\n");
		M100_CommClose(handle);
		return -1;
	}

	iCode = M100_CommClose(handle);
	if (iCode != 0)
	{
		//LogManager.WriteLog(LogFile.Error , " �������: �ر�TM100���ڳ���\r\n");
		return -1;
	}
	return 0;
}

LPCTSTR CPayment::GetInputState()
{
	return szPayState.GetBuffer();
}