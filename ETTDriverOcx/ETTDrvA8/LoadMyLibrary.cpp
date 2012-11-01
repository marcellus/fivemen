//**********************************************************************************************************************
//  Copyright (C), 2011, ɽ���±�����Ϣ�����ɷ����޹�˾ 
//  �ļ���: LoadMyLibrary.cpp
//  �汾 : V1.0
//  ����:  2011-01-29
//  ����:  ���ض�̬��Դ��
//  �����б�:  
//**********************************************************************************************************************
#include "StdAfx.h"
#include "LoadMyLibrary.h"

/**********************************************************************************************************************
* ȫ�ֱ�������
**********************************************************************************************************************/
static	HINSTANCE       Uni_hIDDigitalCopierLib	= NULL;   //֤��ɨ���Ƕ�̬����

/**********************************************************************************************************************
* ��������
**********************************************************************************************************************/
mEnumScannerDevice      EnumScannerDevice   = NULL;
mOpenConnection			OpenConnection		= NULL;
mOpenConnInPath         OpenConnInPath      = NULL;  
mCloseConnection		CloseConnection		= NULL;
mCheckIdCard			CheckIdCard			= NULL;
mTakeIDCard				TakeIDCard			= NULL;
mScanIdCard				ScanIdCard			= NULL;
mSavePicToStream		SavePicToStream		= NULL;
mSaveXSZPicToStream		SaveXSZPicToStream	= NULL;
mSavePicToFile			SavePicToFile		= NULL;
mSavePicToFileII	    SavePicToFileII     = NULL;
mDistillIDInfo			DistillIDInfo		= NULL;
mSNBCOrHWDistillIDInfo  SNBCOrHWDistillIDInfo = NULL;
mGetID2Info             GetID2Info          = NULL;
mFreeMemory				FreeMemory			= NULL;
mFeedIdCard				FeedIdCard			= NULL;
mDirectFeedIdCard       DirectFeedIdCard    = NULL;
mEjectIdCard			EjectIdCard			= NULL;
mGetDeviceStatus		GetDeviceStatus		= NULL;
mSetConfig				SetConfig			= NULL;
mGetLastErrorCode		GetLastErrorCode	= NULL;
mGetLastErrorStr		GetLastErrorStr		= NULL;
mSetScanMode			SetScanMode         = NULL;
mGetScanMode			GetScanMode         = NULL;
mWriteToExcel		    WriteToExcel        = NULL;
mEjectIdCardEx          EjectIdCardEx       = NULL;
mInitServer             InitServer          = NULL;
mExitServer             ExitServer          = NULL;
mChangeID               ChangeID            = NULL;
mDistillVehicleInfo 	DistillVehicleInfo  = NULL;
/**********************************************************************************************************************
//��������	LoadMyLibrary
//������	���ض�̬��
//��ڲ���:	��
//���ڲ���:	ErrorInfo�������룬����Ϊ��
//����ֵ:	�ɹ�����TRUE��ʧ�ܷ���FALSE
**********************************************************************************************************************/
BOOL LoadMyLibrary(char*ErrorInfo)
{
	//******************************************************************************************************************
	//�������
	BOOL returnValue = FALSE;
	char CurrentDir[MAX_PATH] = {0x00};
	char TempFilePath[MAX_PATH] = {0x00};

	//******************************************************************************************************************
	//��ȡ��ǰ·��
	memset(CurrentDir, 0x00, MAX_PATH);
	GetCurrentDirectory(MAX_PATH, CurrentDir);
	//******************************************************************************************************************
	//�жϲ���
	if(ErrorInfo == NULL)
	{
		goto ExitLine;
	}

	//******************************************************************************************************************
	//���ض�̬��
	if(Uni_hIDDigitalCopierLib)
	{
		returnValue = TRUE;
		goto ExitLine;
	}

	sprintf(TempFilePath, "%s\\IDDigitalCopierDll.dll", CurrentDir);
	Uni_hIDDigitalCopierLib = LoadLibrary(TempFilePath);//path
	if(!Uni_hIDDigitalCopierLib)
	{
		sprintf(ErrorInfo, "����'IDDigitalCopierDll.dll'ʧ��!");
		goto ExitLine;
	}
	
	
	//******************************************************************************************************************
	//����EnumScannerDevice
	EnumScannerDevice = (mEnumScannerDevice)GetProcAddress(Uni_hIDDigitalCopierLib, "EnumScannerDevice");
	if(!EnumScannerDevice)
	{
		sprintf(ErrorInfo, "����'EnumScannerDevice'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����OpenConnection
	OpenConnection = (mOpenConnection)GetProcAddress(Uni_hIDDigitalCopierLib, "OpenConnection");
	if(!OpenConnection)
	{
		sprintf(ErrorInfo, "����'OpenConnection'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//OpenConnInPath
	OpenConnInPath = (mOpenConnInPath)GetProcAddress(Uni_hIDDigitalCopierLib, "OpenConnInPath");
	if(!OpenConnInPath)
	{
		sprintf(ErrorInfo, "����'OpenConnInPath'ʧ��!");
		goto ExitLine;
	}
	//******************************************************************************************************************
	//����CloseConnection
	CloseConnection = (mCloseConnection)GetProcAddress(Uni_hIDDigitalCopierLib, "CloseConnection");
	if(!CloseConnection)
	{
		sprintf(ErrorInfo, "����'CloseConnection'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����CheckIdCard
	CheckIdCard = (mCheckIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "CheckIdCard");
	if(!CheckIdCard)
	{
		sprintf(ErrorInfo, "����'CheckIdCard'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����TakeIDCard
	TakeIDCard = (mTakeIDCard)GetProcAddress(Uni_hIDDigitalCopierLib, "TakeIDCard");
	if(!TakeIDCard)
	{
		sprintf(ErrorInfo, "����'TakeIDCard'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����ScanIdCard
	ScanIdCard = (mScanIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "ScanIdCard");
	if(!ScanIdCard)
	{
		sprintf(ErrorInfo, "����'ScanIdCard'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����SavePicToStream
	SavePicToStream = (mSavePicToStream)GetProcAddress(Uni_hIDDigitalCopierLib, "SavePicToStream");
	if(!SavePicToStream)
	{
		sprintf(ErrorInfo, "����'SavePicToStream'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����SaveXSZPicToStream
	SaveXSZPicToStream = (mSaveXSZPicToStream)GetProcAddress(Uni_hIDDigitalCopierLib, "SaveXSZPicToStream");
	if(!SaveXSZPicToStream)
	{
		sprintf(ErrorInfo, "����'SaveXSZPicToStream'ʧ��!");
		goto ExitLine;
	}
	//******************************************************************************************************************
	//����SavePicToFile
	SavePicToFile = (mSavePicToFile)GetProcAddress(Uni_hIDDigitalCopierLib, "SavePicToFile");
	if(!SavePicToFile)
	{
		sprintf(ErrorInfo, "����'SavePicToFile'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����SavePicToFileII
	SavePicToFileII = (mSavePicToFileII)GetProcAddress(Uni_hIDDigitalCopierLib, "SavePicToFileII");
	if(!SavePicToFileII)
	{
		sprintf(ErrorInfo, "����'SavePicToFileII'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����DistillIDInfo
	DistillIDInfo = (mDistillIDInfo)GetProcAddress(Uni_hIDDigitalCopierLib, "DistillIDInfo");
	if(!DistillIDInfo)
	{
		sprintf(ErrorInfo, "����'DistillIDInfo'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����SNBCOrHWDistillIDInfo
	SNBCOrHWDistillIDInfo = (mSNBCOrHWDistillIDInfo)GetProcAddress(Uni_hIDDigitalCopierLib, "SNBCOrHWDistillIDInfo");
	if(!SNBCOrHWDistillIDInfo)
	{
		sprintf(ErrorInfo, "���غ���'SNBCOrHWDistillIDInfo'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����GetIDInfo
	GetID2Info = (mGetID2Info)GetProcAddress(Uni_hIDDigitalCopierLib, "GetID2Info");
	if(!GetID2Info)
	{
		sprintf(ErrorInfo, "����'GetIDInfo'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����FreeMemory
	FreeMemory = (mFreeMemory)GetProcAddress(Uni_hIDDigitalCopierLib, "FreeMemory");
	if(!FreeMemory)
	{
		sprintf(ErrorInfo, "����'FreeMemory'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����DirectFeedIdCard
	DirectFeedIdCard = (mDirectFeedIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "DirectFeedIdCard");
	if(!DirectFeedIdCard)
	{
		sprintf(ErrorInfo, "����'DirectFeedIdCard'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����FeedIdCard
	FeedIdCard = (mFeedIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "FeedIdCard");
	if(!FeedIdCard)
	{
		sprintf(ErrorInfo, "����'FeedIdCard'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����EjectIdCard
	EjectIdCard = (mEjectIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "EjectIdCard");
	if(!EjectIdCard)
	{
		sprintf(ErrorInfo, "����'EjectIdCard'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����GetDeviceStatus
	GetDeviceStatus = (mGetDeviceStatus)GetProcAddress(Uni_hIDDigitalCopierLib, "GetDeviceStatus");
	if(!GetDeviceStatus)
	{
		sprintf(ErrorInfo, "����'GetDeviceStatus'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����SetConfig
	SetConfig = (mSetConfig)GetProcAddress(Uni_hIDDigitalCopierLib, "SetConfig");
	if(!SetConfig)
	{
		sprintf(ErrorInfo, "����'SetConfig'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����GetLastErrorCode
	GetLastErrorCode = (mGetLastErrorCode)GetProcAddress(Uni_hIDDigitalCopierLib, "GetLastErrorCode");
	if(!GetLastErrorCode)
	{
		sprintf(ErrorInfo, "����'GetLastErrorCode'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����GetLastErrorStr
	GetLastErrorStr = (mGetLastErrorStr)GetProcAddress(Uni_hIDDigitalCopierLib, "GetLastErrorStr");
	if(!GetLastErrorStr)
	{
		sprintf(ErrorInfo, "����'GetLastErrorStr'ʧ��!");
		goto ExitLine;
	}

		//******************************************************************************************************************
	//����SetScanMode
	SetScanMode = (mSetScanMode)GetProcAddress(Uni_hIDDigitalCopierLib, "SetScanMode");
	if(!SetScanMode)
	{
		sprintf(ErrorInfo, "����'SetScanMode'ʧ��!");
		goto ExitLine;
	}

		//******************************************************************************************************************
	//����GetScanMode
	GetScanMode = (mGetScanMode)GetProcAddress(Uni_hIDDigitalCopierLib, "GetScanMode");
	if(!GetScanMode)
	{
		sprintf(ErrorInfo, "����'GetScanMode'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����WriteToExcel
	WriteToExcel = (mWriteToExcel)GetProcAddress(Uni_hIDDigitalCopierLib, "WriteToExcel");
	if(!WriteToExcel)
	{
		sprintf(ErrorInfo, "����'WriteToExcel'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����EjectIdCardEx
	EjectIdCardEx = (mEjectIdCardEx)GetProcAddress(Uni_hIDDigitalCopierLib, "EjectIdCardEx");
	if(!EjectIdCardEx)
	{
		sprintf(ErrorInfo, "����'EjectIdCardEx'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����InitServer
	InitServer = (mInitServer)GetProcAddress(Uni_hIDDigitalCopierLib, "InitServer");
	if(!InitServer)
	{
		sprintf(ErrorInfo, "����'InitServer'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����ExitServer
	ExitServer = (mExitServer)GetProcAddress(Uni_hIDDigitalCopierLib, "ExitServer");
	if(!ExitServer)
	{
		sprintf(ErrorInfo, "����'ExitServer'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����ChangeID
	ChangeID = (mChangeID)GetProcAddress(Uni_hIDDigitalCopierLib, "ChangeID");
	if(!ChangeID)
	{
		sprintf(ErrorInfo, "����'ChangeID'ʧ��!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//����DistillVehicleInfo
	DistillVehicleInfo = (mDistillVehicleInfo)GetProcAddress(Uni_hIDDigitalCopierLib, "DistillVehicleInfo");
	if(!DistillVehicleInfo)
	{
		sprintf(ErrorInfo, "����'DistillVehicleInfo'ʧ��!");
		goto ExitLine;
	}

	returnValue = TRUE;
ExitLine:
	if(!returnValue && Uni_hIDDigitalCopierLib)
	{
		UnloadMyLibrary();
	}
	return returnValue;
}

/**********************************************************************************************************************
//��������	UnloadMyLibrary
//������	ж�ض�̬��
//��ڲ���:	��
//���ڲ���:	��
//����ֵ:	�ɹ�����TRUE��ʧ�ܷ���FALSE
**********************************************************************************************************************/
BOOL UnloadMyLibrary()
{
	//******************************************************************************************************************
	//�������
	BOOL returnValue = FALSE;

	//******************************************************************************************************************
	//ж�ض�̬��
	if(Uni_hIDDigitalCopierLib)
	{
		returnValue = FreeLibrary(Uni_hIDDigitalCopierLib);
		if(returnValue)	Uni_hIDDigitalCopierLib = NULL;
		else			goto ExitLine;
	}
	returnValue = TRUE;
ExitLine:
	return returnValue;
}
