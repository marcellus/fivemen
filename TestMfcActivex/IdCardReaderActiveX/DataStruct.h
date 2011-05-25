#ifndef _DATASTRUCT_FILE_
#define _DATASTRUCT_FILE_
#include <afxmt.h>

//////////////////////////////////////////////////////////////////////////
#define GRAPHICINITEXTENTX 500
#define GRAPHICINITEXTENTY 400
#define DT_POLY 1
#define TIMERONE  1001
#define ACTIVEICO 1002
#define ID_TEST 5
#define ID_NOTEST 6

#define SENDREASON_FIRST 1
#define SENDREASON_ERRO 2
#define SENDREASON_RIGHT 3
#define SENDREASON_TIMEOUT 4
#define SENDREASON_COMMANDERRO 5
#define SENDREASON_COMMANDSECC 6


//////////////////////////////////////////////////////////////////////////
#define OPT_RSERVER1 0x00
#define OPT_TIMESET 0x03
#define OPT_TESTBYTIME 0x0C
#define OPT_TELSET 0x0F
#define OPT_URLESET 0x30
#define OPT_READHISTORY 0x33
#define OPT_TESTBYHAND 0x3C
#define OPT_CHECKSELF 0x3F
#define OPT_VOLTAGECHECK 0xC0
#define OPT_CLEARMEM 0xC3
#define OPT_GETNUMBER 0xCC
#define OPT_ERROCOLLECTBOXNOFOUND 0xCF
#define OPT_ERROCOLLECTBOXVOLTAGE 0xF0
#define OPT_ERRODTUVOLTAGE  0xFC
#define OPT_ERROCOLLECTBOXTESTFAILURE 0xF3
#define OPT_RSERVER4 0xFF
#define OPT_REPLAY 0xDD
#define OPT_IDTVOLTAGE 0xC1
#define OPT_SETCOLLECTADDRESS 0xAA
#define OPT_SETIDTADDRESS 0x13
#define OPT_GETIDTADDRESS 0x1C
#define OPT_GETIDTSTATE 0x1F
#define OPT_SETSAFETYVOLTAGE 0x1D


#define SOCK_READ 1
#define SOCK_WRITE 2
const int nMaxBuf=1024*128;
//��ͨ��Ϣ���ࡣ
#define DOWN_LINE 0x1
#define UP_LINE 0x2
#define DELETEUSERINFO 0x3
//////////////////////////////////////////////////////////////////////////
#define MSG_DEALWITHCOMMAND WM_USER+106
#define UM_USERSTATE WM_USER+1
#define MSG_ADDNEWUSER WM_USER+107	//������Ŀ
#define MSG_DELETENEWUSER WM_USER+108	//ɾ����Ŀ
#define MSG_NORMAL WM_USER+109
#define MSG_DATACOMEING WM_USER+110   //���յ�һ���������ݰ�

#define BORDERWIDTHRATE 20

#define SOCKETRECBUFLEN 1024*64
#define MAXNAMELEN 255
#define MAXCOMMANDLEN 0xFFFF


class CClientSocket;

#pragma pack(1)
//�ɼ����ݽṹ
typedef struct  
{
	UINT iNumber;
	BYTE byteChannel;
	FLOAT ftData;
	BYTE byteTime[6];
} COLLECTDATA;

//socket һ�ν��յ����ݵ�Ԫ
typedef struct  
{
	UINT iUsed;
	BYTE chRecBuf[SOCKETRECBUFLEN];
} DATAUNIT,*PDATAUNIT;


typedef struct  //ÿ���û�����󻺳����ݡ�
{
	UINT iUsed;
	BYTE chRecBuf[nMaxBuf];
}TOTALBUF,*PTOTALBUF;

typedef struct  
{
	OVERLAPPED ol;
	int nFlag;//�������
	DATAUNIT dataUnit;//���ݻ���
	PVOID pVoid;
} PER_IO,*PPER_IO;


//typedef CTypedPtrList<CPtrList,DATAUNIT*> DATABUF;

typedef struct  
{
	BYTE bAck;
	UINT uRetry;
}WAITACKTIMEOUT;

typedef struct  //�߳�����
{
	void* p1;
	void* p2;
	void* p3;
}THREADDATA;

typedef struct  
{
	void *p1;
	void *p2;
	void *p3;
}MSGDATA;

typedef struct  
{
	void *p1;
	void *p2;
	void *p3;
	void *p4;
	void *p5;
}NORMALMSGDATA;

typedef struct  
{
	CDC *pDC;   //��ͼ�豸������
	UINT nType;  //��ͼ����
//	CPoint 
	CString xCoordName;  //x������
	CString yCoordName;  //y������
	UINT xUnit;	//X���굥λ����,0.01MMΪ��λ
	UINT yUnit;	//y���굥λ����
	UINT xCoordExtend;//x�᷶Χ,0.01MMΪ��λ
	UINT yCoordExtend;//y�᷶Χ
	CPoint intersectionCoord;  //X����Y�ύ������
	CObArray pointArray; //CPoint����
	CView* pView;  //��ͼָ��
	CPoint offSet;   //����ƫ��,�豸����
	int iYCoordBorder;	//y�������¿հ׿̶�,�߼���λ
	int iXCoordBorder;	//x�������¿հ׿̶�,�߼���λ
	COLORREF colorBk;//ͼ�α���ɫ
	COLORREF colorText;//�ı�ɫ
	COLORREF colorLine;//������ɫ��
} DRAWGRAPHINFO;

typedef struct  
{
	BYTE bHead;
	SHORT sSize;
	BYTE bAck;
	BYTE bOpt;
} PKHEADER;

typedef struct  //����ʱ��У׼
{
	PKHEADER pkHeader;
	BYTE bTime[7];	
	BYTE bCheck;
} PK_TIMECHECK;

typedef struct  //��ʱ����
{
	PKHEADER pkHeader;
	BYTE bTimeUnit;
	BYTE bTimeInterVal;
	BYTE bStart[5];
	BYTE bCheck;
}PK_TESTBYTIME;

typedef struct  //�����绰��������
{
	PKHEADER pkHeader;
	BYTE bTelNumber[12];
	BYTE bType;
	BYTE bCheck;
}PK_TELSET;

typedef struct  //��λ��URL����
{
	PKHEADER pkHeader;
	BYTE bFlagUrl;
	BYTE chUrl[20];
	BYTE bCheck;
}PK_URLSET;

typedef struct  //��λ��IP����
{
	PKHEADER pkHeader;
	BYTE bFlagIP;
	UINT uIp;
	BYTE bCheck;
}PK_IPSET;

typedef struct  //��ȡ��ʷ����
{
	PKHEADER pkHeader;
	BYTE bTimeLimit;
	BYTE bCheck;
}PK_HISTORYREAD;

typedef struct  //�ֶ�����
{
	PKHEADER pkHeader;
	UINT iNumber;
	UINT iMask;
	BYTE bCheck;
}PK_TESTBYHAND;

typedef struct  //�Լ�
{
	PKHEADER pkHeader;
	UINT iNumber;
	BYTE bCheck;
}PK_CHECKSELF;

typedef struct  //��ѹ���
{
	PKHEADER pkHeader;
	UINT iNumber;
	BYTE bCheck;
}PK_VOLTAGECHECK;

typedef struct  
{
	PKHEADER pkHeader;
	BYTE bCheck;
}PK_DTUVOLTAGECHECK;

typedef struct  //��մ洢��
{
	PKHEADER pkHeader;
	BYTE bCheck;
}PK_CLEARMEM;


typedef struct  //��ȡ���
{
	PKHEADER pkHeader;
	BYTE bCheck;
} PK_GETNUMBER;


typedef struct  //Ӧ��ָ��
{
	PKHEADER pkHeader;
	BYTE bOpt2;
	BYTE bResult;
	BYTE bCheck;
} PK_REPLAY;

typedef struct  //��������ͷ��
{
	PKHEADER pkHeader;
	UINT iNumber;
	BYTE bTime[6];
}PKHEADER_TESTDATA;

typedef struct  //����δ�ҵ��ɼ���
{
	PKHEADER pkHeader;
	UINT iNumber;
	BYTE bCheck;
}PK_COLLECTBOXNOFOUND;

typedef struct  
{
	PKHEADER pkHeader;
	UINT iNumber;
	UINT iVoltage;
	BYTE bCheck;
} PK_ERROCOLLECTBOXVOLTAGE;

typedef struct  
{
	PKHEADER pkHeader;
	UINT iVoltage;
	BYTE bCheck;
} PK_ERRODTUVOLTAGE;

typedef struct  
{
	PKHEADER pkHeader;
	UINT iVoltage;
	BYTE bCheck;
} PK_DTUVOLTAGE;

typedef struct  //�б�ؼ���ĿlParam���ݽṹ
{
	TCHAR * szlparam;
	BOOL dspColor;
} LISTLPARAM;

typedef struct  //���ڴ�ӳ��ṹ
{
	UINT chordID;
	UINT sensorID;
} CHORDMEMSTRUCT;
typedef struct  
{
	PKHEADER pkHeader;
	UINT IDTNumber;
	BYTE bCheck;
} PK_IDTNUMBER;//IDT���
typedef struct  
{
	PKHEADER pkHeader;
	float upperlimit;
	float lowerlimit;
	BYTE bCheck;
} PK_SAFETYVOLTAGE;//IDT��ȫ��ѹ������
typedef struct  
{
	PKHEADER pkHeader;
	BYTE bCheck;
}PK_SIMPLEOPT;
typedef struct  
{
	PKHEADER pkHeader;
	BYTE code1;
	BYTE rlt;
	BYTE bCheck;
}PK_AUTOTESTRLT;
//////////////////////////////////////////////////////////////////////////
//
typedef CByteArray ACKLIST;
//////////////////////////////////////////////////////////////////////////
//function
#endif