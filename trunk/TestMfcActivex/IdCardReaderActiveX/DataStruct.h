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
//普通消息分类。
#define DOWN_LINE 0x1
#define UP_LINE 0x2
#define DELETEUSERINFO 0x3
//////////////////////////////////////////////////////////////////////////
#define MSG_DEALWITHCOMMAND WM_USER+106
#define UM_USERSTATE WM_USER+1
#define MSG_ADDNEWUSER WM_USER+107	//增加项目
#define MSG_DELETENEWUSER WM_USER+108	//删除项目
#define MSG_NORMAL WM_USER+109
#define MSG_DATACOMEING WM_USER+110   //接收到一个完整数据包

#define BORDERWIDTHRATE 20

#define SOCKETRECBUFLEN 1024*64
#define MAXNAMELEN 255
#define MAXCOMMANDLEN 0xFFFF


class CClientSocket;

#pragma pack(1)
//采集数据结构
typedef struct  
{
	UINT iNumber;
	BYTE byteChannel;
	FLOAT ftData;
	BYTE byteTime[6];
} COLLECTDATA;

//socket 一次接收的数据单元
typedef struct  
{
	UINT iUsed;
	BYTE chRecBuf[SOCKETRECBUFLEN];
} DATAUNIT,*PDATAUNIT;


typedef struct  //每个用户的最大缓冲数据。
{
	UINT iUsed;
	BYTE chRecBuf[nMaxBuf];
}TOTALBUF,*PTOTALBUF;

typedef struct  
{
	OVERLAPPED ol;
	int nFlag;//操作标记
	DATAUNIT dataUnit;//数据缓冲
	PVOID pVoid;
} PER_IO,*PPER_IO;


//typedef CTypedPtrList<CPtrList,DATAUNIT*> DATABUF;

typedef struct  
{
	BYTE bAck;
	UINT uRetry;
}WAITACKTIMEOUT;

typedef struct  //线程数据
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
	CDC *pDC;   //绘图设备上下文
	UINT nType;  //绘图类型
//	CPoint 
	CString xCoordName;  //x坐标名
	CString yCoordName;  //y坐标名
	UINT xUnit;	//X坐标单位长度,0.01MM为单位
	UINT yUnit;	//y坐标单位长度
	UINT xCoordExtend;//x轴范围,0.01MM为单位
	UINT yCoordExtend;//y轴范围
	CPoint intersectionCoord;  //X轴与Y轴交点坐标
	CObArray pointArray; //CPoint数组
	CView* pView;  //视图指针
	CPoint offSet;   //拖拉偏移,设备坐标
	int iYCoordBorder;	//y坐标上下空白刻度,逻辑单位
	int iXCoordBorder;	//x坐标上下空白刻度,逻辑单位
	COLORREF colorBk;//图形背景色
	COLORREF colorText;//文本色
	COLORREF colorLine;//画笔颜色。
} DRAWGRAPHINFO;

typedef struct  
{
	BYTE bHead;
	SHORT sSize;
	BYTE bAck;
	BYTE bOpt;
} PKHEADER;

typedef struct  //仪器时间校准
{
	PKHEADER pkHeader;
	BYTE bTime[7];	
	BYTE bCheck;
} PK_TIMECHECK;

typedef struct  //定时测量
{
	PKHEADER pkHeader;
	BYTE bTimeUnit;
	BYTE bTimeInterVal;
	BYTE bStart[5];
	BYTE bCheck;
}PK_TESTBYTIME;

typedef struct  //报警电话号码设置
{
	PKHEADER pkHeader;
	BYTE bTelNumber[12];
	BYTE bType;
	BYTE bCheck;
}PK_TELSET;

typedef struct  //上位机URL设置
{
	PKHEADER pkHeader;
	BYTE bFlagUrl;
	BYTE chUrl[20];
	BYTE bCheck;
}PK_URLSET;

typedef struct  //上位机IP设置
{
	PKHEADER pkHeader;
	BYTE bFlagIP;
	UINT uIp;
	BYTE bCheck;
}PK_IPSET;

typedef struct  //读取历史数据
{
	PKHEADER pkHeader;
	BYTE bTimeLimit;
	BYTE bCheck;
}PK_HISTORYREAD;

typedef struct  //手动测量
{
	PKHEADER pkHeader;
	UINT iNumber;
	UINT iMask;
	BYTE bCheck;
}PK_TESTBYHAND;

typedef struct  //自检
{
	PKHEADER pkHeader;
	UINT iNumber;
	BYTE bCheck;
}PK_CHECKSELF;

typedef struct  //电压检测
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

typedef struct  //清空存储器
{
	PKHEADER pkHeader;
	BYTE bCheck;
}PK_CLEARMEM;


typedef struct  //读取编号
{
	PKHEADER pkHeader;
	BYTE bCheck;
} PK_GETNUMBER;


typedef struct  //应答指令
{
	PKHEADER pkHeader;
	BYTE bOpt2;
	BYTE bResult;
	BYTE bCheck;
} PK_REPLAY;

typedef struct  //测量数据头部
{
	PKHEADER pkHeader;
	UINT iNumber;
	BYTE bTime[6];
}PKHEADER_TESTDATA;

typedef struct  //报错，未找到采集箱
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

typedef struct  //列表控件项目lParam数据结构
{
	TCHAR * szlparam;
	BOOL dspColor;
} LISTLPARAM;

typedef struct  //弦内存映射结构
{
	UINT chordID;
	UINT sensorID;
} CHORDMEMSTRUCT;
typedef struct  
{
	PKHEADER pkHeader;
	UINT IDTNumber;
	BYTE bCheck;
} PK_IDTNUMBER;//IDT编号
typedef struct  
{
	PKHEADER pkHeader;
	float upperlimit;
	float lowerlimit;
	BYTE bCheck;
} PK_SAFETYVOLTAGE;//IDT安全电压上下限
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