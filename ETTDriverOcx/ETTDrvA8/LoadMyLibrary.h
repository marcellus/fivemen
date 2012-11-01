//**********************************************************************************************************************
//  Copyright (C), 2011, ɽ���±�����Ϣ�����ɷ����޹�˾ 
//  �ļ���: LoadMyLibrary.h
//  �汾 : V1.0
//  ����:  2011-01-29
//  ����:  ���ض�̬��ͷ�ļ�
//  �����б�:  
//**********************************************************************************************************************
#ifndef __LOADMYLIBRARY_H__
#define	__LOADMYLIBRARY_H__

/**********************************************************************************************************************
* �������Ͷ���
**********************************************************************************************************************/
typedef char				sint8;
typedef unsigned char		uint8;
typedef short				sint16;
typedef unsigned short		uint16;
typedef int					sint32;
typedef unsigned int		uint32;

/**********************************************************************************************************************
* ���֤��Ϣ�ṹ��궨��
**********************************************************************************************************************/
typedef struct HWIDCard
{ 
	uint8 personname[20];		// ����
	uint8 sex[3];		// �Ա�
	uint8 nation[20];	// ����
	uint8 birthday[9];	// �������ڣ����ո�ʽ����19780909��
	uint8 address[100];	// סַ��Ϣ�����ֺ��ַ�Ҳռ2���ֽڣ�
	uint8 signDate[9];	// ǩ������ .��ʽ��19960303��
	uint8 timeLimit[3];	// ��Ч����,2�����֣�һ���ֽ�һ������
	uint8 number[20];	// ���֤���룬һ���ֽ�һ������

	uint8 chDepartment[30];		//��֤����
	uint8 chSignStart[16];		//ǩ��������ʼ
	uint8 chSignEnd[16];		//ǩ�����ڽ���
//	char HeadPortrait[256];     //ͷ����Ϣ
}HWIDCard;

#define RESULTNUMBER		10	//��ѡ���������
typedef struct VehicCard
{ 
	int plate_num;			//���ƺ����ѡ�������
	int vin_num;			//ʶ������ѡ�������
	int ine_num;			//�����������ѡ�������
	int vet_num;			//�������ͺ�ѡ�������
	int regdate_num;		//ע��ʱ���ѡ�������
	int issuedate_num;		//��֤ʱ���ѡ�������
	
	char plate_result[RESULTNUMBER][30];	//���ƺ���ʶ����
	char vin_result[RESULTNUMBER][30];		//ʶ�����ʶ����
	char engine_result[RESULTNUMBER][30];	//����������ʶ����
	char vet_result[RESULTNUMBER][30];		//��������ʶ����
	char regdate_result[RESULTNUMBER][30];	//ע��ʱ��ʶ����
	char issuedate_result[RESULTNUMBER][30];//��֤ʱ��ʶ����
}VehicCard;
static VehicCard null_vehcard = {0};

/**********************************************************************************************************************
* ����֤������Ϣ�ṹ��궨��
**********************************************************************************************************************/
typedef struct IDInfo
{
	char name[32];				//����		
	char sex[4];				//�Ա�
	char nation[12];			//����
	char birthday[20];			//��������
	char address[72];			//סַ��Ϣ
	char number[40];			//���֤����
	char department[32];		//ǩ������
	char timeLimit[36];			//��Ч����
	char Image[256];			//ͷ����Ϣ
}IDInfo;
#define Null_IDinfo	{{0},{0},{0},{0},{0},{0},{0},{0},{0}}

/**********************************************************************************************************************
* λͼͼ��ṹ��궨��
**********************************************************************************************************************/
typedef struct  BY_BITMAP
{
	sint32	biWidth;		//ͼ����
	sint32	biHeight;		//ͼ��߶�
	sint32	biBitCount;		//��ɫ���
	sint32	bfSize;			//λͼ����������
	sint32	BytesPerLine;	//һ��λͼ������ռ���ֽ���
	uint8	**ScanLine;		//������
	uint8	*buffer;		//ͼ�񻺳���
}BY_BITMAP;
static	const BY_BITMAP null_bitmap = {0,0,0,0,0,0,0};

/**********************************************************************************************************************
* ֤�����ͺ궨��
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_IDCard1				0x1					//һ��֤
#define	IDDIGITALCOPIER_IDCard2				0x2		            //����֤
#define	IDDIGITALCOPIER_XSZ      			0x3		            //��ʻ֤
#define IDDIGITALCOPIER_Other			    0xa                 //����

/**********************************************************************************************************************
* ����ͼ�����ͺ궨��
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_SAVE_BMP			0x0									//BMPλͼ
#define	IDDIGITALCOPIER_SAVE_JPG			(IDDIGITALCOPIER_SAVE_BMP + 0x1)	//JPGͼ��

/**********************************************************************************************************************
* ����ֵ�궨��
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_NO_ERROR					0x00								//����
#define	IDDIGITALCOPIER_NO_DEVICE					(IDDIGITALCOPIER_NO_ERROR + 0x01)	//���豸
#define	IDDIGITALCOPIER_PORT_ERROR					(IDDIGITALCOPIER_NO_ERROR + 0x02)	//�˿ڴ���
#define	IDDIGITALCOPIER_TABPAR_NONE					(IDDIGITALCOPIER_NO_ERROR + 0x03)	//�����ļ�����
#define	IDDIGITALCOPIER_HAVE_NOT_INIT				(IDDIGITALCOPIER_NO_ERROR + 0x04)	//δ��ʼ��
#define	IDDIGITALCOPIER_INVALID_ARGUMENT			(IDDIGITALCOPIER_NO_ERROR + 0x05)	//��Ч����
#define	IDDIGITALCOPIER_TIMEOUT_ERROR				(IDDIGITALCOPIER_NO_ERROR + 0x06)	//��ʱ����
#define	IDDIGITALCOPIER_STATUS_COVER_OPENED			(IDDIGITALCOPIER_NO_ERROR + 0x07)	//�ϸǴ�
#define	IDDIGITALCOPIER_STATUS_PASSAGE_JAM			(IDDIGITALCOPIER_NO_ERROR + 0x08)	//����
#define	IDDIGITALCOPIER_START_SCAN_FAILED			(IDDIGITALCOPIER_NO_ERROR + 0x09)	//����ɨ��ʧ��
#define	IDDIGITALCOPIER_OUT_OF_MEMORY				(IDDIGITALCOPIER_NO_ERROR + 0x0A)	//�ڴ����
#define	IDDIGITALCOPIER_INVALID_STATUS				(IDDIGITALCOPIER_NO_ERROR + 0x0B)	//��Ч״̬
#define	IDDIGITALCOPIER_NO_IMAGE_DATA				(IDDIGITALCOPIER_NO_ERROR + 0x0C)	//û��ͼ������
#define	IDDIGITALCOPIER_IMAGE_PROCESS_ERROR			(IDDIGITALCOPIER_NO_ERROR + 0x0D)	//ͼ�������
#define	IDDIGITALCOPIER_IMAGE_JUDGE_DIRECTION_ERROR	(IDDIGITALCOPIER_NO_ERROR + 0x0E)	//�ж�ͼ�������
#define IDDIGITALCOPIER_RECOGNISE_FAILED			(IDDIGITALCOPIER_NO_ERROR + 0x0F)	//ʶ��ʧ��
#define IDDIGITALCOPIER_CLOSE_FAILED				(IDDIGITALCOPIER_NO_ERROR + 0x10)	//�رն˿�ʧ��
#define	IDDIGITALCOPIER_MAX_CODE					(IDDIGITALCOPIER_NO_ERROR + 0x11)	//��������
#define IDDIGITALCOPIER_OPEN_ExcelFILE_ERROR        (IDDIGITALCOPIER_NO_ERROR + 0x12)	//��Excel�ļ�
#define	IDDIGITALCOPIER_EXCEL_SERVER_NOT_INIT	    (IDDIGITALCOPIER_NO_ERROR + 0x13)	//Excel����δ��ʼ��   
#define	IDDIGITALCOPIER_EXCEL_GETPROCESSOR_ERROR    (IDDIGITALCOPIER_NO_ERROR + 0x14)	//��ȡExcel�߳�ʧ�� 
#define	IDDIGITALCOPIER_EXCEL_FILEOPENED            (IDDIGITALCOPIER_NO_ERROR + 0x15)	//Excel�ļ��Ѿ��� 
#define	IDDIGITALCOPIER_NOIDDATA					(IDDIGITALCOPIER_NO_ERROR + 0x16)	//û�����֤������Ϣ����
#define	IDDIGITALCOPIER_IDDATA_PROCESS_ERROR		(IDDIGITALCOPIER_NO_ERROR + 0x17)	//���֤������Ϣ�������
#define IDDIGITALCOPIER_LOADVEHICLEDLL_ERROR        (IDDIGITALCOPIER_NO_ERROR + 0x18)	//������ʻ֤��̬�����
#define IDDIGITALCOPIER_NOVEHICLDATA	            (IDDIGITALCOPIER_NO_ERROR + 0x19)	//û�г�����ʻ֤����

/**********************************************************************************************************************
* �豸״̬�궨��
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_STATUS_IDLE			0x00 //�豸����״̬
#define	IDDIGITALCOPIER_STATUS_SCAN         0x20 //�豸ɨ��
#define	IDDIGITALCOPIER_STATUS_WAIT			0X40 //�豸�ȴ�(ɨ���ͣ����ֽͨ����)
#define	IDDIGITALCOPIER_STATUS_RETIRECARD	0X41 //�豸����(��Ӧ�ڵȴ���ָ����������)
#define	IDDIGITALCOPIER_STATUS_ERROR		0xf0 //����״̬

#define IDDIGITALCOPIER_ERRORSTATUS_NORMAL				0x00 //����
#define IDDIGITALCOPIER_ERRORSTATUS_COVEROPENED			0x01 //ɨ���ϸ�̧��
#define IDDIGITALCOPIER_ERRORSTATUS_PASSAGEJAM			0x01 //����

/**********************************************************************************************************************
* ɨ��ģʽ�궨��
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_SCANNER_WORK_BYMANUAL			0x00							  //�ֶ�ɨ��
#define	IDDIGITALCOPIER_SCANNER_WORK_AUTOSCAN			(IDDIGITALCOPIER_NO_ERROR + 0x01) //�Զ�ɨ�裨�ѻ�ʱʹ�ã�

/**********************************************************************************************************************
* ��Դ���ͺ궨��
**********************************************************************************************************************/
#define	IDDIGITALCOPIER_LIGHT_RED			0x00							  //��ɫ��Դ
#define	IDDIGITALCOPIER_LIGHT_GREEN			(IDDIGITALCOPIER_NO_ERROR + 0x01) //��ɫ��Դ
#define	IDDIGITALCOPIER_LIGHT_BLUE         	(IDDIGITALCOPIER_NO_ERROR + 0x02) //��ɫ��Դ
#define	IDDIGITALCOPIER_LIGHT_WHITE			(IDDIGITALCOPIER_NO_ERROR + 0x03) //��ɫ��Դ
#define	IDDIGITALCOPIER_LIGHT_COLOR			(IDDIGITALCOPIER_NO_ERROR + 0x04) //��ɫ��Դ

/**********************************************************************************************************************
* �豸״̬�ṹ��궨��
**********************************************************************************************************************/
typedef struct
{ 
	int Status;				//IDDIGITALCOPIER_STATUS_IDLE:�豸����״̬		IDDIGITALCOPIER_STATUS_SCAN:�豸ɨ��״̬
							//IDDIGITALCOPIER_STATUS_WAIT:�豸�ȴ�״̬		IDDIGITALCOPIER_STATUS_RETIRECARD:�豸����״̬
							//IDDIGITALCOPIER_STATUS_ERROR:����״̬
	
	int ScanCoverOpen;		//IDDIGITALCOPIER_ERRORSTATUS_NORMAL:ɨ���ϸ�����        IDDIGITALCOPIER_ERRORSTATUS_COVEROPENED:ɨ���ϸ�̧��  
	int BlockCard;			//IDDIGITALCOPIER_ERRORSTATUS_NORMAL:������              IDDIGITALCOPIER_ERRORSTATUS_PASSAGEJAM:����
} DEVICESTATUS; 

/**********************************************************************************************************************
* �豸���ơ�ID�ṹ��
**********************************************************************************************************************/
typedef struct ScannerInfoRec
{
	unsigned	DeviceID;
//	char		DeviceName[256];
}ScannerInfoRec;
#define Null_ScannerInfoRec {0}//{0x00}, 

/**********************************************************************************************************************
* ��̬���������
**********************************************************************************************************************/
#ifdef __cplusplus
extern "C" {
#endif
//*********************************************************************************************************************
//���		1.0
//��������	EnumScannerDevice
//������	ö��ɨ���豸
//��ڲ�������
//���ڲ�����ScannerInfo: �豸��Ϣ�ṹ��ָ�룬����ʵ������������ٻ�����
//			DeviceNumber: ö�ٵ����豸����������Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR			//ö���豸�ɹ�
//IDDIGITALCOPIER_NO_DEVICE			//���豸
//IDDIGITALCOPIER_INVALID_ARGUMENT	//��Ч����
//**********************************************************************************************************************
typedef int (__stdcall *mEnumScannerDevice)(ScannerInfoRec *ScannerInfo, unsigned *DeviceNumber);

//*********************************************************************************************************************
//���		1.1
//��������	OpenConnection
//������	���豸
//��ڲ�������
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR		//���豸�ɹ�
//IDDIGITALCOPIER_NO_DEVICE		//���豸
//IDDIGITALCOPIER_TABPAR_NONE	//�����ļ�����
//**********************************************************************************************************************
typedef int (__stdcall *mOpenConnection)(unsigned DeviceID);//,char *DllPath

//*********************************************************************************************************************
//���		1.11
//��������	OpenConnInPath
//������	���豸
//��ڲ�����DeviceID: �豸�ڲ�ID
//          DllPath:��̬��·��
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR		//���豸�ɹ�
//IDDIGITALCOPIER_NO_DEVICE		//���豸
//IDDIGITALCOPIER_TABPAR_NONE	//�����ļ�����
//**********************************************************************************************************************
typedef int  (__stdcall *mOpenConnInPath)(unsigned DeviceID,char* DllPath);

//*********************************************************************************************************************
//���		1.2
//��������	CloseConnection
//������	�ر��豸
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR		//�رն˿ڳɹ�
//IDDIGITALCOPIER_CLOSE_FAILED	//�رն˿�ʧ��
//*********************************************************************************************************************
typedef int (__stdcall *mCloseConnection)(unsigned DeviceID);

//*********************************************************************************************************************
//���		1.3
//��������	CheckIdCard
//������	����Ƿ���뿨
//��ڲ�����DeviceID: �豸�ڲ�ID
//          CheckTime�����ʱ�䣬��λΪ�룬CheckTime>=0(Ϊ0ʱ�޳�ʱ)
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//��⿨�ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//IDDIGITALCOPIER_TIMEOUT_ERROR			//��ʱ����
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//�ϸǴ�
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//����
//**********************************************************************************************************************
typedef int (__stdcall *mCheckIdCard)(unsigned DeviceID, int CheckTime);

//*********************************************************************************************************************
//���		1.4
//��������	TakeIDCard
//������	����Ƿ�ȡ��
//��ڲ�����DeviceID: �豸�ڲ�ID
//          CheckTime:	���ʱ�䣬��λΪ�룬CheckTime>=0(Ϊ0ʱ�޳�ʱ)
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//��⿨��ȡ��
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//IDDIGITALCOPIER_TIMEOUT_ERROR			//��ʱ����
//*********************************************************************************************************************
typedef int (__stdcall *mTakeIDCard)(unsigned DeviceID, int CheckTime);

//*********************************************************************************************************************
//���		1.5
//��������	ScanIdCard
//������	����ɨ��
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//����ɨ��ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//�ϸǴ�
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//����
//IDDIGITALCOPIER_START_SCAN_FAILED		//����ɨ��ʧ��
//*********************************************************************************************************************
typedef int (__stdcall *mScanIdCard)(unsigned DeviceID);

//*********************************************************************************************************************
//���		1.6
//��������	SavePicToStream
//������	��ȡ��ǰͼ�����ݿ�
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�����TopSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//          ReverseSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//			IDCardMode: ֤�����ͣ�����Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR						//��ȡͼ��ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT					//δ��ʼ��
//IDDIGITALCOPIER_INVALID_ARGUMENT				//��Ч����
//IDDIGITALCOPIER_PORT_ERROR					//�˿ڴ���
//IDDIGITALCOPIER_STATUS_COVER_OPENED			//�ϸǴ�
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM			//����
//IDDIGITALCOPIER_OUT_OF_MEMORY					//�ڴ����
//IDDIGITALCOPIER_INVALID_STATUS				//��Ч״̬
//IDDIGITALCOPIER_NO_IMAGE_DATA					//û��ͼ������
//IDDIGITALCOPIER_IMAGE_PROCESS_ERROR			//ͼ����ʧ��
//IDDIGITALCOPIER_IMAGE_JUDGE_DIRECTION_ERROR	//�ж�ͼ�������
//*********************************************************************************************************************
typedef int (__stdcall *mSavePicToStream)(unsigned DeviceID,BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int *IDCardMode, BOOL Browse, BOOL bSaveOrigPic);

typedef int (__stdcall *mSaveXSZPicToStream)(unsigned DeviceID,BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int *IDCardMode, BOOL Browse, BOOL bSaveOrigPic);
//*********************************************************************************************************************
//���		1.7
//��������	SavePicToFile
//������	��ȡ��ǰͼ�����ݿ�
//��ڲ�����TopSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//          ReverseSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//			FileName: �����ļ����ƣ�����Ϊ��
//			Format: �����ʽ��BMP��JPG
//			Weave: ������ͼ�����
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//����ͼ��ɹ�
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//IDDIGITALCOPIER_OUT_OF_MEMORY			//�ڴ����
//IDDIGITALCOPIER_IMAGE_PROCESS_ERROR	//ͼ����ʧ��
//*********************************************************************************************************************
typedef int (__stdcall *mSavePicToFile)(BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int IDCardMode,char *FileName, int Format, BOOL Weave);


//*********************************************************************************************************************
//���		1.71
//��������	SavePicToFileII
//������	��ȡ��ǰͼ�����ݿ�
//��ڲ�����DeviceID: �豸�ڲ�ID
//          TopSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//          ReverseSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//			FileName: �����ļ����ƣ�����Ϊ��
//			Format: �����ʽ��BMP��JPG
//			Weave: ������ͼ�����
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//����ͼ��ɹ�
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//IDDIGITALCOPIER_OUT_OF_MEMORY			//�ڴ����
//IDDIGITALCOPIER_IMAGE_PROCESS_ERROR	//ͼ����ʧ��
//*********************************************************************************************************************
typedef int (__stdcall *mSavePicToFileII)(unsigned DeviceID, BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int IDCardMode,char *FileName, int Format, BOOL Weave);

//*********************************************************************************************************************
//���		1.8
//��������	DistillIDInfo
//������	��ȡ���֤��Ϣ
//��ڲ�����TopSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//          ReverseSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ�ա�
//			IDCardMode: ֤�����ͣ�һ��֤�����֤
//���ڲ�����IDCard: ���֤��Ϣ�ṹ��ָ�룬����Ϊ�ա�
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//��ȡ��Ϣ�ɹ�
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//IDDIGITALCOPIER_OUT_OF_MEMORY			//�ڴ����
//IDDIGITALCOPIER_RECOGNISE_FAILED		//ʶ��ʧ��
//*********************************************************************************************************************
typedef int (__stdcall *mDistillIDInfo)(BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int IDCardMode, HWIDCard *IDCard);

//*********************************************************************************************************************
//���		1.81
//��������	SNBCOrHWDistillIDInfo
//������	��ȡ���֤��Ϣ
//��ڲ�����DeviceID: �豸�ڲ�ID
//          TopSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//          ReverseSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ�ա�
//			IDCardMode: ֤�����ͣ�һ��֤�����֤
//���ڲ�����IDCard: ���֤��Ϣ�ṹ��ָ�룬����Ϊ�ա�
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//��ȡ��Ϣ�ɹ�
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//IDDIGITALCOPIER_OUT_OF_MEMORY			//�ڴ����
//IDDIGITALCOPIER_RECOGNISE_FAILED		//ʶ��ʧ��
//*********************************************************************************************************************
typedef int (__stdcall *mSNBCOrHWDistillIDInfo)(unsigned DeviceID, BY_BITMAP *TopSource, BY_BITMAP *ReverseSource, int IDCardMode, HWIDCard *IDCard);

//*********************************************************************************************************************
//���		1.9
//��������	FreeMemory
//������	�ͷŻ�����
//��ڲ�����TopSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//          ReverseSource: ����ͼ��������Ϣ�ṹ�壬����Ϊ��
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//�ͷŻ������ɹ�
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//*********************************************************************************************************************
typedef int (__stdcall *mFreeMemory)(BY_BITMAP *TopSource, BY_BITMAP *ReverseSource);

//*********************************************************************************************************************
//���		1.10
//��������	FeedIdCard
//������	����
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//�����ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//�ϸǴ�
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//����
//IDDIGITALCOPIER_INVALID_STATUS		//��Ч״̬
//*********************************************************************************************************************
typedef int (__stdcall *mFeedIdCard)(unsigned DeviceID);

//*********************************************************************************************************************
//���		1.11
//��������	EjectIdCard
//������	�˿�
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//�˿��ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//�ϸǴ�
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//����
//IDDIGITALCOPIER_INVALID_STATUS		//��Ч״̬
//*********************************************************************************************************************
typedef int (__stdcall *mEjectIdCard)(unsigned DeviceID);

//*********************************************************************************************************************
//���		1.12
//��������	GetDeviceStatus
//������	��ȡ�豸״̬
//��ڲ�������
//���ڲ�����DeviceStatus��״̬�ṹ��ָ�룬����Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//��ȡ�豸״̬�ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//*********************************************************************************************************************
typedef int (__stdcall *mGetDeviceStatus)(unsigned DeviceID, DEVICESTATUS *DeviceStatus);

//*********************************************************************************************************************
//���		1.13
//��������	SetConfig
//������	��������
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�����DeviceStatus��״̬�ṹ��ָ�룬����Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//�������óɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//*********************************************************************************************************************
typedef int (__stdcall *mSetConfig)(unsigned DeviceID, int Light, int DPI, int ThresholdValue);

//**********************************************************************************************************************
//���		1.14
//��������	GetLastErrorCode
//������	��ȡ���һ�εĴ�����
//��ڲ���:	��
//���ڲ���:	��
//����ֵ:	������
//**********************************************************************************************************************/
typedef int (__stdcall *mGetLastErrorCode)();

//**********************************************************************************************************************
//���		1.15
//��������	GetLastErrorStr
//������	��ȡ���һ�εĴ�������
//��ڲ���:	��
//���ڲ���:	��
//����ֵ:	
//IDDIGITALCOPIER_NO_ERROR				//��ȡ�ɹ�
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//**********************************************************************************************************************/
typedef int (__stdcall *mGetLastErrorStr)(char* errStr);

//*********************************************************************************************************************
//���		1.16
//��������	mSetScanMode
//������	����ɨ��ģʽ
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�����DeviceStatus��״̬�ṹ��ָ�룬����Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//�������óɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//*********************************************************************************************************************
typedef int (__stdcall *mSetScanMode)(unsigned DeviceID, int ScanMode, int Type);

//*********************************************************************************************************************
//���		1.17
//��������	SetConfig
//������	��ѯɨ��ģʽ
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�����DeviceStatus��״̬�ṹ��ָ�룬����Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//�������óɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//*********************************************************************************************************************
typedef int (__stdcall *mGetScanMode)(unsigned DeviceID, int ScanMode);

//*********************************************************************************************************************
//���		1.18
//��������	WriteToExcel
//������	��ѯɨ��ģʽ
//��ڲ�������
//���ڲ�����DeviceStatus��״̬�ṹ��ָ�룬����Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//д��ɹ��ɹ�
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//*********************************************************************************************************************
typedef int (__stdcall *mWriteToExcel)(char *cPath,char* cSheetName, char *cValue,long *row, long *column);

//*********************************************************************************************************************
//���		1.19
//��������	EjectIdCardEx
//������	��ѯɨ��ģʽ
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//д��ɹ�
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//*********************************************************************************************************************
typedef int (__stdcall *mEjectIdCardEx)(unsigned DeviceID);

//*********************************************************************************************************************
//���		1.20
//��������	InitServer
//������	����Excel����
//��ڲ�������
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//����Excel����ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT         //����δ����
//*********************************************************************************************************************
typedef int (__stdcall *mInitServer)();


//*********************************************************************************************************************
//���		1.21
//��������	ExitServer
//������	ע��Excel����
//��ڲ�������
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//ע��Excel����ɹ�
//*********************************************************************************************************************
typedef int (__stdcall *mExitServer)();

//*********************************************************************************************************************
//���		1.22
//��������	ChangeID
//������	�����豸ID
//��ڲ�����DeviceID: �豸�ڲ�ID
//			NewID: ��ID��
//���ڲ�����DeviceStatus��״̬�ṹ��ָ�룬����Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//�����豸ID�ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_INVALID_ARGUMENT		//��Ч����
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//*********************************************************************************************************************
typedef int (__stdcall *mChangeID)(unsigned DeviceID, unsigned NewID);

//*********************************************************************************************************************
//���		1.23
//��������	DirectFeedIdCard
//������	����
//��ڲ�����DeviceID: �豸�ڲ�ID
//���ڲ�������
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//�����ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//�ϸǴ�
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//����
//IDDIGITALCOPIER_INVALID_STATUS		//��Ч״̬
//*********************************************************************************************************************
typedef int (__stdcall *mDirectFeedIdCard)(unsigned DeviceID);

//*********************************************************************************************************************
//���		1.24
//��������	GetID2Info
//������	��ȡ����֤��Ϣ
//��ڲ�����DeviceID: �豸�ڲ�ID
//			Format��ͷ��ͼƬ���淽ʽ��ID_IMAGE_NAME-ID_IMAGE_FORMAT
//			Folder: FormatΪID_IMAGE_FORMATʱָ���ļ���·��������Ϊ��
//���ڲ�����mIDInfo������֤��Ϣ�ṹ��ָ�룬����Ϊ��
//����ֵ��	
//IDDIGITALCOPIER_NO_ERROR				//��ȡ��Ϣ�ɹ�
//IDDIGITALCOPIER_HAVE_NOT_INIT			//δ��ʼ��
//IDDIGITALCOPIER_PORT_ERROR			//�˿ڴ���
//IDDIGITALCOPIER_STATUS_COVER_OPENED	//�ϸǴ�
//IDDIGITALCOPIER_STATUS_PASSAGE_JAM	//����
//IDDIGITALCOPIER_INVALID_STATUS		//��Ч״̬
//IDDIGITALCOPIER_NOIDDATA				//û�����֤������Ϣ����
//IDDIGITALCOPIER_OUT_OF_MEMORY			//�ڴ����
//*********************************************************************************************************************
typedef int (__stdcall *mGetID2Info)(unsigned DeviceID, IDInfo *IDCard, int Format, char *Folder);

//*********************************************************************************************************************
//���		1.25
//��������	DistillVehicleInfo
//������	ͨ��SNBCʶ����ȡ������ʻ֤��Ϣ
//��ڲ�����PicturePath		��ʻ֤ͼ��·��
//���ڲ�����aVhicCard		��ȡ����ʻ֤��Ϣ
//����ֵ��	�ɹ�����:	OPERATION_SUCCESS; 
//			ʧ�ܷ���:	OPERATION_FAIL				//����ʧ��
//						OPERATION_LOADLIBRARYFAIL	//���ض�̬��ʧ��
//						OPERATION_NOVehicleDATA		//��ȡ��Ϣʧ��
//*********************************************************************************************************************
typedef	int (__stdcall *mDistillVehicleInfo)(unsigned DeviceID, char *PicturePath, VehicCard *aVhicCard);

#ifdef __cplusplus
}
#endif

/**********************************************************************************************************************
//��������	LoadMyLibrary
//������	���ض�̬��
//��ڲ���:	��
//���ڲ���:	ErrorInfo�������룬����Ϊ��
//����ֵ:	�ɹ�����TRUE��ʧ�ܷ���FALSE
**********************************************************************************************************************/
	BOOL LoadMyLibrary(char*ErrorInfo);

/**********************************************************************************************************************
//��������	UnloadMyLibrary
//������	ж�ض�̬��
//��ڲ���:	��
//���ڲ���:	��
//����ֵ:	�ɹ�����TRUE��ʧ�ܷ���FALSE
**********************************************************************************************************************/
	BOOL UnloadMyLibrary();
#endif
