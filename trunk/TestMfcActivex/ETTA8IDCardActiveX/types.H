#ifndef types
#define types
#define IDC_MYCMD WM_USER +100
#define SC_STATUS long
#ifndef _A8DOUBLE

#define SCS_PARAM	-2	// 参数错误
#define SCS_ERR		-1	// 通信错误码
#define SCS_OK		0	// OK
#define SCS_FAIL	1	// 失败
#define SCS_NODATA	2	// 数据已读完
#define SCS_BUSY	3	// 忙状态
#define SCS_CALIB	4	// 校准中
#define SCS_CLEAN	5	// 清洁CIS中
#define SCS_SCAN	6	// 扫描中
#define SCS_RFID	7	// RFID 操作中
#endif

#define SCS_RDTYPE2OK  0X00002000
#define SCS_RDTYPE2ERR 0X00002100
#define SCS_RDTYPE2FILEERR 0X00002300

#define SCS_RDTYPE1OK  0X00001000
#define SCS_RDTYPE1ERR 0X00001100


#define STATUS_CARD_NONE			0
#define STATUS_CARD_F_READY			1
#define STATUS_CARD_F_SCANNING  	2
#define STATUS_CARD_R_READY			3
#define STATUS_CARD_R_SCANNING		4
#define STATUS_CARD_DONE			5
#define STATUS_CARD_EJECTING		6
#define STATUS_CARD_CONFISCATING	7
#define STATUS_CARD_ABORT			8
//
#define SCS_PARAM	(-2)
#define SCS_ERROR	(-1)
#define SCS_OK		(0)
#define SCS_FAIL	(1)
#define SCS_NODATA	(2)
#define SCS_BUSY	(3)
#define SCS_CALIB	(4)
#define SCS_CLEAN	(5)
#define SCS_SCAN	(6)
#define SCS_CARD	(7)
#define SCS_MOTOR	(8)

#define SC_COMMUNICATION_ERR        0
#define SC_COMMUNICATION_OK			1
#define SC_DEV_ON                   2
#define SC_DEV_OFF                  3 
#define Const_LineBytesMONO   2576     // 1288 * 2  
typedef struct  _SC_COMMAND
{
	unsigned long	S_command;
	unsigned long	S_in_length;
	unsigned long	S_out_length;
	unsigned long	S_reserved;
} SC_COMMAND;

typedef struct _SC_MODEA8
{
	// Auto-Reverse mode
	unsigned long auto_reverse;	// 0-手动，1-自动
	unsigned long mode_u;	// 0-关灯，1-B，2-G，3-GB，4-R，5-RB，6-RG，7-RGB，8-IR，16-TC
	unsigned long mode_d;
	unsigned long mode_u_r;
	unsigned long mode_d_r;
}SC_MODEA8;

typedef struct _SC_TIMEs
{
	long second;        // seconds after the minute (from 0)
	long minute;        // minutes after the hour (from 0)
	long hour;       // hour of the day (from 0)
	long wday;		// day of the week(from 1)
	long mday;       // day of the month (from 1)
	long month;        // month of the year (from 1)
	long year;       // years since 2000 (from 0)
}SC_TIME;


typedef struct _SC_MODE
{
	unsigned long mode;	// 0-default，1-R，2-G，3-B，4-RGB，5-TC，6-IR
	unsigned long dpi;		// 0-default，300 / 600 DPI
	unsigned long led;	// 0-default（关灯扫），1-开灯扫
	unsigned long towards;	// 0-default（CIS就近归位），1-固定从开始位置扫描，2-固定从末端位置扫描
	unsigned long mirror;	// 该参数只读，0-正向图象，1-反向图象
	unsigned long x;		// 0-default，象素为单位
	unsigned long y;		// 0-default，象素为单位
	unsigned long cx;		// 0-default，象素为单位
	unsigned long cy;		// 0-default，象素为单位
}SC_MODE; 

typedef struct __Paper
{
	unsigned long P_w;
	unsigned long P_h;
	unsigned long P_BytesPerLine;
}Paper,*pPaper;

typedef struct _SC_CALIBDATA
{
	long bCalibStatus;		//Determines if the device need calibration;0,need calibration;1,need not calibration
	unsigned short R_Gain[Const_LineBytesMONO];	//Red calibration gain,0..2576
	unsigned short G_Gain[Const_LineBytesMONO];	//Green calibration gain,0..2576
	unsigned short B_Gain[Const_LineBytesMONO];	//Blue calibration gain,0..2576
	unsigned short IR_Gain[Const_LineBytesMONO];//IR calibration gain,0..2576
	char offset[Const_LineBytesMONO];		//offset of calibration data
	//	long nCheckSum;			//Check Sum,not used in PC
}SC_CALIBDATA;

#define const_imgW 1288
#define const_imgH 2344//2143 // 2070//2104//
//#define const_imgH 2025

/*****************Add for RFID 2008-10-15 chx******************/
typedef struct _SC_RFID
{
	unsigned long type;
	union
	{
		struct
		{
			unsigned long bytes_per_block;
			unsigned char pw_a[8];
			unsigned char pw_b[8];
			unsigned long sector;
			unsigned long block;
		} typeA;
		struct
		{
			unsigned long command;
		} ID2G;

		unsigned long reserved[7];
	} card;
} SC_RFID;

typedef struct __idcard
{
	WCHAR id_Rev[2];              //保留	  4    bytes
	WCHAR id_Name[15];			  //姓名	  30   bytes
	WCHAR id_Sex;				  //性别	  2    bytes
	WCHAR id_National[2];		  //民族	  4    bytes
	WCHAR id_Born[8];			  //出生	  16   bytes
	WCHAR id_Home[35];			  //家庭	  70   bytes
	WCHAR id_Code[18];			  //身份证号  36   bytes
	WCHAR id_RegOrg[15];		  //机关	  30   bytes
	WCHAR id_ValidPeriod[16];	  //有效期限  32   bytes 	 
	WCHAR id_NewAddr[18];		  //最新地址  36   bytes	 //以上字节数为260 bytes
	BYTE  id_pImage[1024];        //图像      1024 bytes 
}id_Card;

typedef struct _IDCARD
{
	char id_Rev[2];					//保留	  4    bytes
	char id_Name[15];				//姓名	  30   bytes
	char id_Sex;					//性别	  2    bytes
	char id_National[3];			//民族	  4    bytes
	char id_Born[9];				//出生	  16   bytes
	char id_Home[255];				//家庭	  70   bytes
	char id_Code[19];				//身份证号  36   bytes
	char id_RegOrg[255];			//机关	  30   bytes
	char id_ValidPeriod[17];		//有效期限  32   bytes 	 
	char id_NewAddr[255];			//最新地址  36   bytes	 //以上字节数为260 bytes
	BYTE  id_pImage[1024];			//图像      1024 bytes 
}IDCARD;
/**********************End for RFID************************/

//Added on 2010-11-1-29 for V1.3.8.0 ========================================
typedef struct _s_ScanOver
{

	unsigned int  Dir_Is_ScanOver;  //向前扫描时,如果扫描结束值为1,否为0;
	unsigned int  Rev_Is_ScanOver;  //返回扫描时,如果扫描结束值为1,否为0;

	unsigned int  Dir_scanCurrentLine;  //向前扫描时，目前扫描的线数。
	unsigned int  Rev_scanCurrentLine;  //返回扫描时，目前扫描的线数。

	unsigned int Rev_Dir_Or_Rev;		  //向前扫描时值为1,返回时值为2.
}Is_ScanOver;

#define Const_MaxImageHeight    3000      
#define SCAN_COMPLETE_SUCCESS   1  //扫描图像完成并成功
#define SCAN_COMPLETE_HAUL      2  //扫描图像完成，但图像超长或拉伸，可取返回扫描的图像
//End add ===================================================================

#endif


