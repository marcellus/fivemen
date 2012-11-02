#include "types.h"
#include <comutil.h>
#include "windows.h"
#include "NationItemArray.h"
#include "WideString.h"
#include <vector>
#include "LoadMyLibrary.h"

#pragma comment(lib,"comsuppw.lib")

#pragma once



#pragma region 新北洋

unsigned        DevNumber;                              //统计当前设备数量 
ScannerInfoRec  ScannerInfo[8]  = {0};                  //设备信息
DEVICESTATUS    DeviceStatus = {0,0,0};                 //设备状态
unsigned        SecDeviceNum = 0;                       //当前选中机器的内部ID号
int     Uni_ScanMode        = IDDIGITALCOPIER_SCANNER_WORK_BYMANUAL;  //扫描模式
int		Uni_ScanLight		= IDDIGITALCOPIER_LIGHT_COLOR;	//扫描光源
int		Uni_ActionAfterScan = 0;							//扫描后动作
int		Uni_ReclaimTimeout	= 20;							//吞卡超时
int		Uni_ImageDPI		= 300;							//图像分辨率
int		Uni_ImageWeave		= 0;							//图像拼接
int		Uni_ImageNameNumber	= 1;							//扫描数量
char	Uni_SaveNewImagePath[MAX_PATH] = {0x00};			//新扫描图像保存路径
char	Uni_SaveOldImagePath[MAX_PATH] = {0x00};			//原扫描图像保存路径
int     Uni_loadOCRDll = 0;                                 //是否需要加载OCR动态库
int     Uni_ReadIDInfo = 0;                                 //是否需要二代证识读
int     Uni_ReadVehicle = 0;                                //是否需要行驶证识读
int     Uni_Double_Pic_Info[10] = {0};                      //任意证件输出双面图像
int     Uni_Card_Enter[10] = {0};                            //入卡方式，前入卡或者后入卡
CString             Uni_SaveExcelPath;                      //Excel文件保存路径
extern	HWIDCard    IDCard;									//身份证信息
extern  IDInfo      mIDInfo;                                //二代证身份证信息
extern  bool        bToExcelFlag;                           //是否写入Excel
extern  bool        bOCRIdentifyFlag;                       //是否OCR识别
extern  bool        bRead2IDInfoFlag;                       //是否进行二代证识读
extern  bool        bVehicleFlag;                           //是否进行行驶证识别


/**********************************************************************************************************************
* 清空身份证信息结构体
**********************************************************************************************************************/
#define NullIdCardInfo()									\
{															\
	memset(IDCard.personname, 0, sizeof(IDCard.personname));			\
	memset(IDCard.sex, 0, sizeof(IDCard.sex));				\
	memset(IDCard.birthday, 0, sizeof(IDCard.birthday));	\
	memset(IDCard.nation, 0, sizeof(IDCard.nation));		\
	memset(IDCard.address, 0, sizeof(IDCard.address));		\
	memset(IDCard.signDate, 0, sizeof(IDCard.signDate));	\
	memset(IDCard.timeLimit, 0, sizeof(IDCard.timeLimit));	\
	memset(IDCard.number, 0, sizeof(IDCard.number));		\
	memset(IDCard.chDepartment, 0, sizeof(IDCard.chDepartment));	\
	memset(IDCard.chSignStart, 0, sizeof(IDCard.chSignStart));		\
	memset(IDCard.chSignEnd, 0, sizeof(IDCard.chSignEnd));			\
}

/**********************************************************************************************************************
* 函数声明
**********************************************************************************************************************/
extern mEnumScannerDevice	EnumScannerDevice;
extern mOpenConnection		OpenConnection;
extern mOpenConnInPath      OpenConnInPath;
extern mCloseConnection		CloseConnection;
extern mCheckIdCard			CheckIdCard;
extern mTakeIDCard			TakeIDCard;
extern mScanIdCard			ScanIdCard;
extern mSavePicToStream		SavePicToStream;
extern mSaveXSZPicToStream	SaveXSZPicToStream;
extern mSavePicToFile		SavePicToFile;
extern mSavePicToFileII		SavePicToFileII;
extern mDistillIDInfo		DistillIDInfo;
extern mSNBCOrHWDistillIDInfo SNBCOrHWDistillIDInfo;
extern mGetID2Info          GetID2Info;
extern mFreeMemory			FreeMemory;
extern mDirectFeedIdCard	DirectFeedIdCard;
extern mFeedIdCard			FeedIdCard;
extern mEjectIdCard			EjectIdCard;
extern mGetDeviceStatus		GetDeviceStatus;
extern mSetConfig			SetConfig;
extern mGetLastErrorCode	GetLastErrorCode;
extern mGetLastErrorStr		GetLastErrorStr;
extern mSetScanMode			SetScanMode;
extern mGetScanMode			GetScanMode;
extern mWriteToExcel		WriteToExcel;
extern mEjectIdCardEx	    EjectIdCardEx;
extern mInitServer		    InitServer;
extern mExitServer          ExitServer;
extern mChangeID            ChangeID;
extern mDistillVehicleInfo  DistillVehicleInfo;
	#pragma endregion


// ETTA8IDCardActiveXCtrl.h : CETTA8IDCardActiveXCtrl ActiveX 控件类的声明。


// CETTA8IDCardActiveXCtrl : 有关实现的信息，请参阅 ETTA8IDCardActiveXCtrl.cpp。
#define SCANNER_NAME		"IVS-600DS"		//chengxiang 2008-06-10,a8_dbl-->IVS-600DS
#define SCANNER_DLL_NAME	"a8_dblNew.DLL"

#define MSG_STATUS_CARD_NONE		"卡不存在"
#define MSG_STATUS_CARD_F_READY			"卡就绪"
#define MSG_STATUS_CARD_F_SCANNING  	"卡扫描中"
#define MSG_STATUS_CARD_R_READY			"卡就绪"
#define MSG_STATUS_CARD_R_SCANNING		"卡扫描中"
#define MSG_STATUS_CARD_DONE			"卡读取完毕"
#define MSG_STATUS_CARD_EJECTING		"卡已弹出"
#define MSG_STATUS_CARD_CONFISCATING	"卡拒绝"
#define MSG_STATUS_CARD_ABORT			"卡终止"
#define MSG_STATUS_CARD_UNKOWN			"未知错误"

#define MSG_SCS_PARAM  "设备参数错误"
#define MSG_SCS_ERR "设备通信出错"
#define MSG_SCS_OK  "设备状态正常"
#define MSG_SCS_FAIL  "设备状态异常"
#define MSG_SCS_NODATA  "设备没有可读数据"
#define MSG_SCS_BUSY "设备忙"
#define MSG_SCS_CALIB  "设备校准"
#define MSG_SCS_CLEAN  "清空CIS"
#define MSG_SCS_SCAN  "设备扫描中"
#define MSG_SCS_CARD  "获取卡状态"

/** 

SCS_PARAM	-2	 	Parameters error
SCS_ERR		-1		Communication err
SCS_OK		0		OK
SCS_FAIL		1		Fail
SCS_NODATA	2		No data to read
SCS_BUSY	   	3		Busy status
SCS_CALIB	4		Calibrate
SCS_CLEAN	5		Clean CIS
SCS_SCAN		6		Scanning
SCS_CARD		7		Card Status

#define STATUS_CARD_NONE			0
#define STATUS_CARD_F_READY			1
#define STATUS_CARD_F_SCANNING  	2
#define STATUS_CARD_R_READY			3
#define STATUS_CARD_R_SCANNING		4
#define STATUS_CARD_DONE			5
#define STATUS_CARD_EJECTING		6
#define STATUS_CARD_CONFISCATING	7
#define STATUS_CARD_ABORT			8
**/

static HINSTANCE SYSCAN_hDrvModule = NULL;
BOOL scan_running = false;

//------------------------------------------------------
//两个dll都有的函数定义现金识别器动态库函数功能定义
//------------------------------------------------------
BOOL             (__stdcall *SYSCAN_HasScanner)(char* szScannerName);
BOOL             (__stdcall *SYSCAN_CloseDevice)(void);
SC_STATUS		(__stdcall *SYSCAN_GetButtonStatus)(unsigned long * btn_bits);


SC_STATUS		(__stdcall *SYSCAN_ResetDevice) (void);
SC_STATUS		(__stdcall *SYSCAN_GetDeviceStatus)(SC_STATUS* status);


SC_STATUS		(__stdcall *SYSCAN_CancelScan)(void);
SC_STATUS		(__stdcall *SYSCAN_GetScanData)(unsigned char* buffer, unsigned long length);
//ADD NEW
SC_STATUS		(__stdcall *SYSCAN_StartCalib)(void);
SC_STATUS		(__stdcall *SYSCAN_CancelCalib)(void);
SC_STATUS		(__stdcall *SYSCAN_CalibrateScanner)(void);

//ADD NWE END

//SC_STATUS		(*SYSCAN_BeginScan)(SC_MODEA8* mode);
SC_STATUS		(__stdcall *SYSCAN_BeginScan)(void);	//20080304,delete parameters
//SC_STATUS		(*SYSCAN_EndScan)(SC_MODEA8* mode);
SC_STATUS		(__stdcall *SYSCAN_EndScan)(void);	//20080304,delete parameters
SC_STATUS		(__stdcall *SYSCAN_StartMotor)(unsigned long speed);
SC_STATUS		(__stdcall *SYSCAN_StopMotor)(void);
////////////////////////////////////////////////////////////////
SC_STATUS (__stdcall *SYSCAN_ConfiscateCard)(void);
SC_STATUS (__stdcall *SYSCAN_EjectCard)(void);
SC_STATUS (__stdcall *SYSCAN_GetSensorStatus)(SC_STATUS* status);
SC_STATUS (__stdcall *SYSCAN_GetCardStatus)(SC_STATUS* status);
SC_STATUS (__stdcall *SYSCAN_StartSuckCard)(void);
SC_STATUS (__stdcall *SYSCAN_CancelSuckCard)(void);

SC_STATUS (__stdcall *SYSCAN_SetScanModeA8)(const SC_MODEA8* mode);
SC_STATUS (__stdcall *SYSCAN_GetScanModeA8)(SC_MODEA8* mode);
SC_STATUS (__stdcall *SYSCAN_GetScanDataLength)(unsigned long * status);


short (__stdcall *SYSCAN_GetImageBlockA8)(VOID * pAreaBuf1, VOID * pAreaBuf2,short line,unsigned long index,unsigned short *usOverFlag);

SC_STATUS (__stdcall *SYSCAN_GetMagcardDataLength) (unsigned long track, unsigned long * length);
SC_STATUS (__stdcall *SYSCAN_GetMagcardData) (unsigned long track, unsigned char* buffer, unsigned long* length);

SC_STATUS (__stdcall *SYSCAN_GetMagcardRawDataLength) (unsigned long track, unsigned long * length);
SC_STATUS (__stdcall *SYSCAN_GetMagcardRawData) (unsigned long track, unsigned char* buffer, unsigned long* length);

SC_STATUS (__stdcall *SYSCAN_GetCalibData)(SC_CALIBDATA * pCalibData);

/////////////Add by chengxiang,20080304
SC_STATUS (__stdcall *SYSCAN_GetChipID)(UINT * pChipID);
SC_STATUS (__stdcall *SYSCAN_Beep)(int time);
SC_STATUS (__stdcall *SYSCAN_GetVersion)(char * version);
/////////////End add

SC_STATUS (__stdcall *SYSCAN_GetDeviceError)(void);
SC_STATUS (__stdcall *SYSCAN_GetImgFromUnit)(unsigned long lDpi,
											 const char *pImgPath1,unsigned long *lImgW1,unsigned long *lImgH1,
											 const char *pImgPath2,unsigned long *lImgW2,unsigned long *lImgH2);
SC_STATUS (__stdcall *SYSCAN_GetColorImgFromUnit)(unsigned long lDpi,
												  const char *pImgPath1,unsigned long *lImgW1,unsigned long *lImgH1,
												  const char *pImgPath2,unsigned long *lImgW2,unsigned long *lImgH2);

SC_STATUS (__stdcall *SYSCAN_GetHeadFromImage)(const char *pImgPath1,const char *pImgPath2,const char *pImgHeadPath);
//unsigned char Meg10[1024 * 1024 * 15];

//add for rfid
long		(__stdcall *SYSCAN_StartRFID)(void);
long		(__stdcall *SYSCAN_StopRFID)(void);
long		(__stdcall *SYSCAN_HaltCard)(const SC_RFID* param);
long		(__stdcall *SYSCAN_RequestCard)(unsigned long* type);
long		(__stdcall *SYSCAN_ReadCard)(const SC_RFID* param, unsigned char* buffer, unsigned long* length);
long		(__stdcall *SYSCAN_ReadRFIDInfo)(id_Card *pIdCard);
//add for rfid end

void (__stdcall *SYSCAN_CalibBmpFile)(char *pFilePath);
int (__stdcall *SYSCAN_BmpToJpeg)(char *srcFileName,char *dstFileName);
BOOL (__stdcall *SYSCAN_Dpi600To300)(BYTE *srcbuf,BYTE *dstbuf,int width,int height,BYTE imgMode);

int (__stdcall *SYSCAN_SetCalibdata)();



#include <objsafe.h>//导入安全接口

class CETTDrvA8Ctrl : public COleControl
{
	DECLARE_DYNCREATE(CETTDrvA8Ctrl)
	//ISafeObject
	DECLARE_INTERFACE_MAP()

	BEGIN_INTERFACE_PART(ObjSafe, IObjectSafety)
		STDMETHOD_(HRESULT, GetInterfaceSafetyOptions) ( 
		/* [in] */ REFIID riid,
		/* [out] */ DWORD __RPC_FAR *pdwSupportedOptions,
		/* [out] */ DWORD __RPC_FAR *pdwEnabledOptions
		);

		STDMETHOD_(HRESULT, SetInterfaceSafetyOptions) ( 
			/* [in] */ REFIID riid,
			/* [in] */ DWORD dwOptionSetMask,
			/* [in] */ DWORD dwEnabledOptions
			);
	END_INTERFACE_PART(ObjSafe);


// 构造函数
public:
	CETTDrvA8Ctrl();

// 重写
public:
	virtual void OnDraw(CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid);
	virtual void DoPropExchange(CPropExchange* pPX);
	virtual void OnResetState();
	virtual DWORD GetControlFlags();
	char filePath[MAX_PATH];
	SC_TIME rtctime;
	SC_MODEA8 modeA8;
	SC_CALIBDATA CalibData;
	BOOL bViewBmp;	//确定是否显示bmp
	BOOL bWaitCard;
	int nScanTimes;	//总共扫描的次数
	BOOL WriteBMPFileHeader(FILE *pFile, int nImgW, int nImgH, int nDPI, int nColorMode, int nBytesPerLine);
	void GetExePath(LPSTR tmppath);
	int FileWltToBmp(void);
	unsigned long CreateWltFile(BYTE *pBuf);

// 实现
protected:
	~CETTDrvA8Ctrl();

	DECLARE_OLECREATE_EX(CETTDrvA8Ctrl)    // 类工厂和 guid
	DECLARE_OLETYPELIB(CETTDrvA8Ctrl)      // GetTypeInfo
	DECLARE_PROPPAGEIDS(CETTDrvA8Ctrl)     // 属性页 ID
	DECLARE_OLECTLTYPE(CETTDrvA8Ctrl)		// 类型名称和杂项状态

// 消息映射
	DECLARE_MESSAGE_MAP()

// 调度映射
	DECLARE_DISPATCH_MAP()

// 事件映射
	DECLARE_EVENT_MAP()

// 调度和事件 ID
public:
	enum {
		dispidBmpToJpeg = 33L,
		dispidCompressJpg = 32,
		dispidReadRFID = 31L,
		dispidReadAndScanDpiEx = 30L,

		dispidGetCardStatusEx = 29L,
		dispidInitNationArray = 28L,
		dispidCalibrationEx = 27L,
		dispidGetDeviceStatusEx = 26L,
		dispidReadAndScanEx = 25L,
		dispidDestroyDll = 24L,
		dispidEjectCardEx = 23L,
		dispidEnterCardEx = 22L,
		dispidCloseDeviceEx = 21L,
		dispidOpenDeviceEx = 20L,
		dispidLoadDll = 19L,
		dispidIdCard = 18,
		dispidYxqxName = 17,
		dispidYxqxCode = 16,
		dispidEndDate = 15,
		dispidStartDate = 14,
		dispidFzjg = 13,
		dispidAddress = 12,
		dispidBirth = 11,
		dispidNationName = 10,
		dispidNationCode = 9,
		dispidSexName = 8,
		dispidSexCode = 7,
		dispidUserName = 6,
		dispidIsReaded = 5,
		dispidIdCardEndImgFileName = 4,
		dispidIdCardFrontImgFileName = 3,
		dispidIdCardImgFileName = 2,
		dispidMessage = 1
	};
protected:
	CNationItemArray m_nationArray;
	void OnMessageChanged(void);
	CString m_Message;
	void OnIdCardImgFileNameChanged(void);
	CString m_IdCardImgFileName;
	void OnIdCardFrontImgFileNameChanged(void);
	CString m_IdCardFrontImgFileName;
	void OnIdCardEndImgFileNameChanged(void);
	CString m_IdCardEndImgFileName;
	void OnIsReadedChanged(void);
	SHORT m_IsReaded;
	void OnUserNameChanged(void);
	CString m_UserName;
	void OnSexCodeChanged(void);
	SHORT m_SexCode;
	void OnSexNameChanged(void);
	CString m_SexName;
	void OnNationCodeChanged(void);
	CString m_NationCode;
	void OnNationNameChanged(void);
	CString m_NationName;
	void OnBirthChanged(void);
	CString m_Birth;
	void OnAddressChanged(void);
	CString m_Address;
	void OnFzjgChanged(void);
	CString m_Fzjg;
	void OnStartDateChanged(void);
	CString m_StartDate;
	void OnEndDateChanged(void);
	CString m_EndDate;
	void OnYxqxCodeChanged(void);
	CString m_YxqxCode;
	void OnYxqxNameChanged(void);
	CString m_YxqxName;
	void OnIdCardChanged(void);
	CString m_IdCard;
	SHORT LoadDll(void);
	SHORT OpenDeviceEx(SHORT port);
	SHORT CloseDeviceEx(void);
	SHORT EnterCardEx(void);
	SHORT EjectCardEx(void);
	SHORT DestroyDll(void);
	SHORT ReadAndScanEx(void);
	SHORT GetDeviceStatusEx(void);
	SHORT CalibrationEx(void);
	SHORT InitNationArray(void);
	SHORT GetCardStatusEx(void);
	
	SHORT ReadAndScanDpiEx(LONG dpi);
	SHORT ReadRFID(void);
	void OnCompressJpgChanged(void);
	SHORT m_CompressJpg;
	SHORT BmpToJpeg(LPCTSTR src, LPCTSTR dest);
};

