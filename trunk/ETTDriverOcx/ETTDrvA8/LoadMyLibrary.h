//**********************************************************************************************************************
//  Copyright (C), 2011, 山东新北洋信息技术股份有限公司 
//  文件名: LoadMyLibrary.h
//  版本 : V1.0
//  日期:  2011-01-29
//  描述:  加载动态库头文件
//  函数列表:  
//**********************************************************************************************************************
#ifndef __LOADMYLIBRARY_H__
#define	__LOADMYLIBRARY_H__

/**********************************************************************************************************************
* 变量类型定义
**********************************************************************************************************************/
typedef char				sint8;
typedef unsigned char		uint8;
typedef short				sint16;
typedef unsigned short		uint16;
typedef int					sint32;
typedef unsigned int		uint32;

/**********************************************************************************************************************
* 身份证信息结构体宏定义
**********************************************************************************************************************/
typedef struct HWIDCard
{ 
	uint8 personname[20];		// 姓名
	uint8 sex[3];		// 性别
	uint8 nation[20];	// 民族
	uint8 birthday[9];	// 出生日期，生日格式：“19780909”
	uint8 address[100];	// 住址信息，数字和字符也占2个字节；
	uint8 signDate[9];	// 签发日期 .形式“19960303”
	uint8 timeLimit[3];	// 有效期限,2个数字，一个字节一个数字
	uint8 number[20];	// 身份证号码，一个字节一个数字

	uint8 chDepartment[30];		//发证机关
	uint8 chSignStart[16];		//签发日期起始
	uint8 chSignEnd[16];		//签发日期结束
//	char HeadPortrait[256];     //头像信息
}HWIDCard;

#define RESULTNUMBER		10	//候选结果最多个数
typedef struct VehicCard
{ 
	int plate_num;			//号牌号码候选结果个数
	int vin_num;			//识别代码候选结果个数
	int ine_num;			//发动机号码候选结果个数
	int vet_num;			//车辆类型候选结果个数
	int regdate_num;		//注册时间候选结果个数
	int issuedate_num;		//发证时间候选结果个数
	
	char plate_result[RESULTNUMBER][30];	//号牌号码识别结果
	char vin_result[RESULTNUMBER][30];		//识别代号识别结果
	char engine_result[RESULTNUMBER][30];	//发动机号码识别结果
	char vet_result[RESULTNUMBER][30];		//车辆类型识别结果
	char regdate_result[RESULTNUMBER][30];	//注册时间识别结果
	char issuedate_result[RESULTNUMBER][30];//发证时间识别结果
}VehicCard;
static VehicCard null_vehcard = {0};

/**********************************************************************************************************************
* 二代证电子信息结构体宏定义
**********************************************************************************************************************/
typedef struct IDInfo
{
	char name[32];				//姓名		
	char sex[4];				//性别
	char nation[12];			//民族
	char birthday[20];			//出生日期
	char address[72];			//住址信息
	char number[40];			//身份证号码
	char department[32];		//签发机关
	char timeLimit[36];			//有效日期
	char Image[256];			//头像信息
}IDInfo;
#define Null_IDinfo	{{0},{0},{0},{0},{0},{0},{0},{0},{0}}

/**********************************************************************************************************************
* 位图图像结构体宏定义
**********************************************************************************************************************/
typedef struct  BY_BITMAP
{
	sint32	biWidth;		//图像宽度
	sint32	biHeight;		//图像高度
	sint32	biBitCount;		//颜色深度
	sint32	bfSize;			//位图缓冲区长度
	sint32	BytesPerLine;	//一行位图数据所占的字节数
	uint8	**ScanLine;		//行索引
	uint8	*buffer;		//图像缓冲区
}BY_BITMAP;
static	const BY_BITMAP null_bitmap = {0,0,0,0,0,0,0};

/**********************************************************************************************************************
* 证件类型宏定义
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_IDCard1				0x1					//一代证
#define	IDDIGITALCOPIER_IDCard2				0x2		            //二代证
#define	IDDIGITALCOPIER_XSZ      			0x3		            //行驶证
#define IDDIGITALCOPIER_Other			    0xa                 //其他

/**********************************************************************************************************************
* 保存图像类型宏定义
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_SAVE_BMP			0x0									//BMP位图
#define	IDDIGITALCOPIER_SAVE_JPG			(IDDIGITALCOPIER_SAVE_BMP + 0x1)	//JPG图像

/**********************************************************************************************************************
* 返回值宏定义
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_NO_ERROR					0x00								//正常
#define	IDDIGITALCOPIER_NO_DEVICE					(IDDIGITALCOPIER_NO_ERROR + 0x01)	//无设备
#define	IDDIGITALCOPIER_PORT_ERROR					(IDDIGITALCOPIER_NO_ERROR + 0x02)	//端口错误
#define	IDDIGITALCOPIER_TABPAR_NONE					(IDDIGITALCOPIER_NO_ERROR + 0x03)	//参数文件错误
#define	IDDIGITALCOPIER_HAVE_NOT_INIT				(IDDIGITALCOPIER_NO_ERROR + 0x04)	//未初始化
#define	IDDIGITALCOPIER_INVALID_ARGUMENT			(IDDIGITALCOPIER_NO_ERROR + 0x05)	//无效参数
#define	IDDIGITALCOPIER_TIMEOUT_ERROR				(IDDIGITALCOPIER_NO_ERROR + 0x06)	//超时错误
#define	IDDIGITALCOPIER_STATUS_COVER_OPENED			(IDDIGITALCOPIER_NO_ERROR + 0x07)	//上盖打开
#define	IDDIGITALCOPIER_STATUS_PASSAGE_JAM			(IDDIGITALCOPIER_NO_ERROR + 0x08)	//塞卡
#define	IDDIGITALCOPIER_START_SCAN_FAILED			(IDDIGITALCOPIER_NO_ERROR + 0x09)	//启动扫描失败
#define	IDDIGITALCOPIER_OUT_OF_MEMORY				(IDDIGITALCOPIER_NO_ERROR + 0x0A)	//内存溢出
#define	IDDIGITALCOPIER_INVALID_STATUS				(IDDIGITALCOPIER_NO_ERROR + 0x0B)	//无效状态
#define	IDDIGITALCOPIER_NO_IMAGE_DATA				(IDDIGITALCOPIER_NO_ERROR + 0x0C)	//没有图像数据
#define	IDDIGITALCOPIER_IMAGE_PROCESS_ERROR			(IDDIGITALCOPIER_NO_ERROR + 0x0D)	//图像处理错误
#define	IDDIGITALCOPIER_IMAGE_JUDGE_DIRECTION_ERROR	(IDDIGITALCOPIER_NO_ERROR + 0x0E)	//判断图像方向错误
#define IDDIGITALCOPIER_RECOGNISE_FAILED			(IDDIGITALCOPIER_NO_ERROR + 0x0F)	//识别失败
#define IDDIGITALCOPIER_CLOSE_FAILED				(IDDIGITALCOPIER_NO_ERROR + 0x10)	//关闭端口失败
#define	IDDIGITALCOPIER_MAX_CODE					(IDDIGITALCOPIER_NO_ERROR + 0x11)	//最大错误码
#define IDDIGITALCOPIER_OPEN_ExcelFILE_ERROR        (IDDIGITALCOPIER_NO_ERROR + 0x12)	//无Excel文件
#define	IDDIGITALCOPIER_EXCEL_SERVER_NOT_INIT	    (IDDIGITALCOPIER_NO_ERROR + 0x13)	//Excel服务未初始化   
#define	IDDIGITALCOPIER_EXCEL_GETPROCESSOR_ERROR    (IDDIGITALCOPIER_NO_ERROR + 0x14)	//获取Excel线程失败 
#define	IDDIGITALCOPIER_EXCEL_FILEOPENED            (IDDIGITALCOPIER_NO_ERROR + 0x15)	//Excel文件已经打开 
#define	IDDIGITALCOPIER_NOIDDATA					(IDDIGITALCOPIER_NO_ERROR + 0x16)	//没有身份证电子信息数据
#define	IDDIGITALCOPIER_IDDATA_PROCESS_ERROR		(IDDIGITALCOPIER_NO_ERROR + 0x17)	//身份证电子信息处理错误
#define IDDIGITALCOPIER_LOADVEHICLEDLL_ERROR        (IDDIGITALCOPIER_NO_ERROR + 0x18)	//加载行驶证动态库错误
#define IDDIGITALCOPIER_NOVEHICLDATA	            (IDDIGITALCOPIER_NO_ERROR + 0x19)	//没有车辆行驶证数据

/**********************************************************************************************************************
* 设备状态宏定义
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_STATUS_IDLE			0x00 //设备空闲状态
#define	IDDIGITALCOPIER_STATUS_SCAN         0x20 //设备扫描
#define	IDDIGITALCOPIER_STATUS_WAIT			0X40 //设备等待(扫描后卡停在走纸通道中)
#define	IDDIGITALCOPIER_STATUS_RETIRECARD	0X41 //设备出卡(对应于等待后指令启动出卡)
#define	IDDIGITALCOPIER_STATUS_ERROR		0xf0 //错误状态

#define IDDIGITALCOPIER_ERRORSTATUS_NORMAL				0x00 //正常
#define IDDIGITALCOPIER_ERRORSTATUS_COVEROPENED			0x01 //扫描上盖抬起
#define IDDIGITALCOPIER_ERRORSTATUS_PASSAGEJAM			0x01 //塞卡

/**********************************************************************************************************************
* 扫描模式宏定义
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_SCANNER_WORK_BYMANUAL			0x00							  //手动扫描
#define	IDDIGITALCOPIER_SCANNER_WORK_AUTOSCAN			(IDDIGITALCOPIER_NO_ERROR + 0x01) //自动扫描（脱机时使用）

/**********************************************************************************************************************
* 光源类型宏定义
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_LIGHT_RED			0x00							  //红色光源
#define	IDDIGITALCOPIER_LIGHT_GREEN			(IDDIGITALCOPIER_NO_ERROR + 0x01) //绿色光源
#define	IDDIGITALCOPIER_LIGHT_BLUE         	(IDDIGITALCOPIER_NO_ERROR + 0x02) //蓝色光源
#define	IDDIGITALCOPIER_LIGHT_WHITE			(IDDIGITALCOPIER_NO_ERROR + 0x03) //白色光源
#define	IDDIGITALCOPIER_LIGHT_COLOR			(IDDIGITALCOPIER_NO_ERROR + 0x04) //彩色光源

/**********************************************************************************************************************
* 设备状态结构体宏定义
**********************************************************************************************************************/
typedef struct
{ 
	int Status;				//IDDIGITALCOPIER_STATUS_IDLE:设备空闲状态		IDDIGITALCOPIER_STATUS_SCAN:设备扫描状态
							//IDDIGITALCOPIER_STATUS_WAIT:设备等待状态		IDDIGITALCOPIER_STATUS_RETIRECARD:设备出卡状态
							//IDDIGITALCOPIER_STATUS_ERROR:错误状态
	
	int ScanCoverOpen;		//IDDIGITALCOPIER_ERRORSTATUS_NORMAL:扫描上盖正常        IDDIGITALCOPIER_ERRORSTATUS_COVEROPENED:扫描上盖抬起  
	int BlockCard;			//IDDIGITALCOPIER_ERRORSTATUS_NORMAL:卡正常              IDDIGITALCOPIER_ERRORSTATUS_PASSAGEJAM:塞卡
} DEVICESTATUS; 

/**********************************************************************************************************************
* 设备名称、ID结构体
**********************************************************************************************************************/
typedef struct ScannerInfoRec
{
	unsigned	DeviceID;
//	char		DeviceName[256];
}ScannerInfoRec;
#define Null_ScannerInfoRec {0}//{0x00}, 

/**********************************************************************************************************************
* 动态库输出函数
**********************************************************************************************************************/
#ifdef __cplusplus
extern "C" {
#endif
//*********************************************************************************************************************
//序号		1.0
//函数名：	EnumScannerDevice
//描述：	枚举扫描设备
//入口参数：无
//出口参数：ScannerInfo: 设备信息结构体指针，根据实际连接情况开辟缓冲区
//			DeviceNumber: 枚举到的设备数量，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR			//枚举设备成功
//IDDIGITALCOPIER_NO_DEVICE			//无设备
//IDDIGITALCOPIER_INVALID_ARGUMENT	//无效参数
//**********************************************************************************************************************
typedef int (__stdcall *mEnumScannerDevice)(ScannerInfoRec *ScannerInfo, unsigned *DeviceNumber);

//*********************************************************************************************************************
//序号		1.1
//函数名：	OpenConnection
//描述：	打开设备
//入口参数：无
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR		//打开设备成功
//IDDIGITALCOPIER_NO_DEVICE		//无设备
//IDDIGITALCOPIER_TABPAR_NONE	//参数文件错误
//**********************************************************************************************************************
typedef int (__stdcall *mOpenConnection)(unsigned DeviceID);//,char *DllPath

//*********************************************************************************************************************
//序号		1.11
//函数名：	OpenConnInPath
//描述：	打开设备
//入口参数：DeviceID: 设备内部ID
//          DllPath:动态库路径
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR		//打开设备成功
//IDDIGITALCOPIER_NO_DEVICE		//无设备
//IDDIGITALCOPIER_TABPAR_NONE	//参数文件错误
//**********************************************************************************************************************
typedef int  (__stdcall *mOpenConnInPath)(unsigned DeviceID,char* DllPath);

//*********************************************************************************************************************
//序号		1.2
//函数名：	CloseConnection
//描述：	关闭设备
//入口参数：DeviceID: 设备内部ID
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR		//关闭端口成功
//IDDIGITALCOPIER_CLOSE_FAILED	//关闭端口失败
//*********************************************************************************************************************
typedef int (__stdcall *mCloseConnection)(unsigned DeviceID);

//*********************************************************************************************************************
//序号		1.3
//函数名：	CheckIdCard
//描述：	检测是否放入卡
//入口参数：DeviceID: 设备内部ID
//          CheckTime：检测时间，单位为秒，CheckTime>=0(为0时无超时)
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//检测卡成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//IDDIGITALCOPIER_TIMEOUT_ERROR			//超时错误
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//上盖打开
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//塞卡
//**********************************************************************************************************************
typedef int (__stdcall *mCheckIdCard)(unsigned DeviceID, int CheckTime);

//*********************************************************************************************************************
//序号		1.4
//函数名：	TakeIDCard
//描述：	检测是否被取走
//入口参数：DeviceID: 设备内部ID
//          CheckTime:	检测时间，单位为秒，CheckTime>=0(为0时无超时)
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//检测卡被取走
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//IDDIGITALCOPIER_TIMEOUT_ERROR			//超时错误
//*********************************************************************************************************************
typedef int (__stdcall *mTakeIDCard)(unsigned DeviceID, int CheckTime);

//*********************************************************************************************************************
//序号		1.5
//函数名：	ScanIdCard
//描述：	启动扫描
//入口参数：DeviceID: 设备内部ID
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//启动扫描成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//上盖打开
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//塞卡
//IDDIGITALCOPIER_START_SCAN_FAILED		//启动扫描失败
//*********************************************************************************************************************
typedef int (__stdcall *mScanIdCard)(unsigned DeviceID);

//*********************************************************************************************************************
//序号		1.6
//函数名：	SavePicToStream
//描述：	读取当前图像数据块
//入口参数：DeviceID: 设备内部ID
//出口参数：TopSource: 正面图像数据信息结构体，不能为空
//          ReverseSource: 正面图像数据信息结构体，不能为空
//			IDCardMode: 证卡类型，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR						//读取图像成功
//IDDIGITALCOPIER_HAVE_NOT_INIT					//未初始化
//IDDIGITALCOPIER_INVALID_ARGUMENT				//无效参数
//IDDIGITALCOPIER_PORT_ERROR					//端口错误
//IDDIGITALCOPIER_STATUS_COVER_OPENED			//上盖打开
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM			//塞卡
//IDDIGITALCOPIER_OUT_OF_MEMORY					//内存溢出
//IDDIGITALCOPIER_INVALID_STATUS				//无效状态
//IDDIGITALCOPIER_NO_IMAGE_DATA					//没有图像数据
//IDDIGITALCOPIER_IMAGE_PROCESS_ERROR			//图像处理失败
//IDDIGITALCOPIER_IMAGE_JUDGE_DIRECTION_ERROR	//判断图像方向错误
//*********************************************************************************************************************
typedef int (__stdcall *mSavePicToStream)(unsigned DeviceID,BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int *IDCardMode, BOOL Browse, BOOL bSaveOrigPic);

typedef int (__stdcall *mSaveXSZPicToStream)(unsigned DeviceID,BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int *IDCardMode, BOOL Browse, BOOL bSaveOrigPic);
//*********************************************************************************************************************
//序号		1.7
//函数名：	SavePicToFile
//描述：	读取当前图像数据块
//入口参数：TopSource: 正面图像数据信息结构体，不能为空
//          ReverseSource: 正面图像数据信息结构体，不能为空
//			FileName: 保存文件名称，不能为空
//			Format: 保存格式，BMP或JPG
//			Weave: 正反面图像组合
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//保存图像成功
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//IDDIGITALCOPIER_OUT_OF_MEMORY			//内存溢出
//IDDIGITALCOPIER_IMAGE_PROCESS_ERROR	//图像处理失败
//*********************************************************************************************************************
typedef int (__stdcall *mSavePicToFile)(BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int IDCardMode,char *FileName, int Format, BOOL Weave);


//*********************************************************************************************************************
//序号		1.71
//函数名：	SavePicToFileII
//描述：	读取当前图像数据块
//入口参数：DeviceID: 设备内部ID
//          TopSource: 正面图像数据信息结构体，不能为空
//          ReverseSource: 正面图像数据信息结构体，不能为空
//			FileName: 保存文件名称，不能为空
//			Format: 保存格式，BMP或JPG
//			Weave: 正反面图像组合
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//保存图像成功
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//IDDIGITALCOPIER_OUT_OF_MEMORY			//内存溢出
//IDDIGITALCOPIER_IMAGE_PROCESS_ERROR	//图像处理失败
//*********************************************************************************************************************
typedef int (__stdcall *mSavePicToFileII)(unsigned DeviceID, BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int IDCardMode,char *FileName, int Format, BOOL Weave);

//*********************************************************************************************************************
//序号		1.8
//函数名：	DistillIDInfo
//描述：	提取身份证信息
//入口参数：TopSource: 正面图像数据信息结构体，不能为空
//          ReverseSource: 正面图像数据信息结构体，不能为空。
//			IDCardMode: 证件类型，一代证或二代证
//出口参数：IDCard: 身份证信息结构体指针，不能为空。
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//提取信息成功
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//IDDIGITALCOPIER_OUT_OF_MEMORY			//内存溢出
//IDDIGITALCOPIER_RECOGNISE_FAILED		//识别失败
//*********************************************************************************************************************
typedef int (__stdcall *mDistillIDInfo)(BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int IDCardMode, HWIDCard *IDCard);

//*********************************************************************************************************************
//序号		1.81
//函数名：	SNBCOrHWDistillIDInfo
//描述：	提取身份证信息
//入口参数：DeviceID: 设备内部ID
//          TopSource: 正面图像数据信息结构体，不能为空
//          ReverseSource: 正面图像数据信息结构体，不能为空。
//			IDCardMode: 证件类型，一代证或二代证
//出口参数：IDCard: 身份证信息结构体指针，不能为空。
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//提取信息成功
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//IDDIGITALCOPIER_OUT_OF_MEMORY			//内存溢出
//IDDIGITALCOPIER_RECOGNISE_FAILED		//识别失败
//*********************************************************************************************************************
typedef int (__stdcall *mSNBCOrHWDistillIDInfo)(unsigned DeviceID, BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int IDCardMode, HWIDCard *IDCard);

//*********************************************************************************************************************
//序号		1.9
//函数名：	FreeMemory
//描述：	释放缓冲区
//入口参数：TopSource: 正面图像数据信息结构体，不能为空
//          ReverseSource: 正面图像数据信息结构体，不能为空
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//释放缓冲区成功
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//*********************************************************************************************************************
typedef int (__stdcall *mFreeMemory)(BY_BITMAP *TopSource, BY_BITMAP *ReverseSource);

//*********************************************************************************************************************
//序号		1.10
//函数名：	FeedIdCard
//描述：	出卡
//入口参数：DeviceID: 设备内部ID
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//出卡成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//上盖打开
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//塞卡
//IDDIGITALCOPIER_INVALID_STATUS		//无效状态
//*********************************************************************************************************************
typedef int (__stdcall *mFeedIdCard)(unsigned DeviceID);

//*********************************************************************************************************************
//序号		1.11
//函数名：	EjectIdCard
//描述：	退卡
//入口参数：DeviceID: 设备内部ID
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//退卡成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//上盖打开
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//塞卡
//IDDIGITALCOPIER_INVALID_STATUS		//无效状态
//*********************************************************************************************************************
typedef int (__stdcall *mEjectIdCard)(unsigned DeviceID);

//*********************************************************************************************************************
//序号		1.12
//函数名：	GetDeviceStatus
//描述：	获取设备状态
//入口参数：无
//出口参数：DeviceStatus：状态结构体指针，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//获取设备状态成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//*********************************************************************************************************************
typedef int (__stdcall *mGetDeviceStatus)(unsigned DeviceID, DEVICESTATUS *DeviceStatus);

//*********************************************************************************************************************
//序号		1.13
//函数名：	SetConfig
//描述：	设置配置
//入口参数：DeviceID: 设备内部ID
//出口参数：DeviceStatus：状态结构体指针，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//设置配置成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//*********************************************************************************************************************
typedef int (__stdcall *mSetConfig)(unsigned DeviceID, int Light, int DPI, int ThresholdValue);

//**********************************************************************************************************************
//序号		1.14
//函数名：	GetLastErrorCode
//描述：	获取最近一次的错误码
//入口参数:	无
//出口参数:	无
//返回值:	错误码
//**********************************************************************************************************************/
typedef int (__stdcall *mGetLastErrorCode)();

//**********************************************************************************************************************
//序号		1.15
//函数名：	GetLastErrorStr
//描述：	获取最近一次的错误描述
//入口参数:	无
//出口参数:	无
//返回值:	
//IDDIGITALCOPIER_NO_ERROR				//获取成功
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//**********************************************************************************************************************/
typedef int (__stdcall *mGetLastErrorStr)(char* errStr);

//*********************************************************************************************************************
//序号		1.16
//函数名：	mSetScanMode
//描述：	设置扫描模式
//入口参数：DeviceID: 设备内部ID
//出口参数：DeviceStatus：状态结构体指针，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//设置配置成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//*********************************************************************************************************************
typedef int (__stdcall *mSetScanMode)(unsigned DeviceID, int ScanMode, int Type);

//*********************************************************************************************************************
//序号		1.17
//函数名：	SetConfig
//描述：	查询扫描模式
//入口参数：DeviceID: 设备内部ID
//出口参数：DeviceStatus：状态结构体指针，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//设置配置成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//*********************************************************************************************************************
typedef int (__stdcall *mGetScanMode)(unsigned DeviceID, int ScanMode);

//*********************************************************************************************************************
//序号		1.18
//函数名：	WriteToExcel
//描述：	查询扫描模式
//入口参数：无
//出口参数：DeviceStatus：状态结构体指针，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//写入成功成功
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//*********************************************************************************************************************
typedef int (__stdcall *mWriteToExcel)(char *cPath,char* cSheetName, char *cValue,long *row, long *column);

//*********************************************************************************************************************
//序号		1.19
//函数名：	EjectIdCardEx
//描述：	查询扫描模式
//入口参数：DeviceID: 设备内部ID
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//写入成功
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//*********************************************************************************************************************
typedef int (__stdcall *mEjectIdCardEx)(unsigned DeviceID);

//*********************************************************************************************************************
//序号		1.20
//函数名：	InitServer
//描述：	启动Excel服务
//入口参数：无
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//启动Excel服务成功
//IDDIGITALCOPIER_HAVE_NOT_INIT         //服务未启动
//*********************************************************************************************************************
typedef int (__stdcall *mInitServer)();


//*********************************************************************************************************************
//序号		1.21
//函数名：	ExitServer
//描述：	注销Excel服务
//入口参数：无
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//注销Excel服务成功
//*********************************************************************************************************************
typedef int (__stdcall *mExitServer)();

//*********************************************************************************************************************
//序号		1.22
//函数名：	ChangeID
//描述：	更改设备ID
//入口参数：DeviceID: 设备内部ID
//			NewID: 新ID号
//出口参数：DeviceStatus：状态结构体指针，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//更改设备ID成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_INVALID_ARGUMENT		//无效参数
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//*********************************************************************************************************************
typedef int (__stdcall *mChangeID)(unsigned DeviceID, unsigned NewID);

//*********************************************************************************************************************
//序号		1.23
//函数名：	DirectFeedIdCard
//描述：	出卡
//入口参数：DeviceID: 设备内部ID
//出口参数：无
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//出卡成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//上盖打开
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//塞卡
//IDDIGITALCOPIER_INVALID_STATUS		//无效状态
//*********************************************************************************************************************
typedef int (__stdcall *mDirectFeedIdCard)(unsigned DeviceID);

//*********************************************************************************************************************
//序号		1.24
//函数名：	GetID2Info
//描述：	获取二代证信息
//入口参数：DeviceID: 设备内部ID
//			Format：头像图片保存方式，ID_IMAGE_NAME-ID_IMAGE_FORMAT
//			Folder: Format为ID_IMAGE_FORMAT时指定文件夹路径，不能为空
//出口参数：mIDInfo：二代证信息结构体指针，不能为空
//返回值：	
//IDDIGITALCOPIER_NO_ERROR				//获取信息成功
//IDDIGITALCOPIER_HAVE_NOT_INIT			//未初始化
//IDDIGITALCOPIER_PORT_ERROR			//端口错误
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//上盖打开
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//塞卡
//IDDIGITALCOPIER_INVALID_STATUS		//无效状态
//IDDIGITALCOPIER_NOIDDATA				//没有身份证电子信息数据
//IDDIGITALCOPIER_OUT_OF_MEMORY			//内存溢出
//*********************************************************************************************************************
typedef int (__stdcall *mGetID2Info)(unsigned DeviceID, IDInfo *IDCard, int Format, char *Folder);

//*********************************************************************************************************************
//序号		1.25
//函数名：	DistillVehicleInfo
//描述：	通过SNBC识别库获取车辆行驶证信息
//入口参数：PicturePath		行驶证图像路径
//出口参数：aVhicCard		获取的行驶证信息
//返回值：	成功返回:	OPERATION_SUCCESS; 
//			失败返回:	OPERATION_FAIL				//操作失败
//						OPERATION_LOADLIBRARYFAIL	//加载动态库失败
//						OPERATION_NOVehicleDATA		//获取信息失败
//*********************************************************************************************************************
typedef	int (__stdcall *mDistillVehicleInfo)(unsigned DeviceID, char *PicturePath, VehicCard *aVhicCard);

#ifdef __cplusplus
}
#endif

/**********************************************************************************************************************
//函数名：	LoadMyLibrary
//描述：	加载动态库
//入口参数:	无
//出口参数:	ErrorInfo：错误码，不能为空
//返回值:	成功返回TRUE，失败返回FALSE
**********************************************************************************************************************/
	BOOL LoadMyLibrary(char*ErrorInfo);

/**********************************************************************************************************************
//函数名：	UnloadMyLibrary
//描述：	卸载动态库
//入口参数:	无
//出口参数:	无
//返回值:	成功返回TRUE，失败返回FALSE
**********************************************************************************************************************/
	BOOL UnloadMyLibrary();
#endif
