//**********************************************************************************************************************
//  Copyright (C), 2011, 山东新北洋信息技术股份有限公司 
//  文件名: LoadMyLibrary.cpp
//  版本 : V1.0
//  日期:  2011-01-29
//  描述:  加载动态库源码
//  函数列表:  
//**********************************************************************************************************************
#include "StdAfx.h"
#include "LoadMyLibrary.h"

/**********************************************************************************************************************
* 全局变量声明
**********************************************************************************************************************/
static	HINSTANCE       Uni_hIDDigitalCopierLib	= NULL;   //证卡扫描仪动态库句柄

/**********************************************************************************************************************
* 函数声明
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
//函数名：	LoadMyLibrary
//描述：	加载动态库
//入口参数:	无
//出口参数:	ErrorInfo：错误码，不能为空
//返回值:	成功返回TRUE，失败返回FALSE
**********************************************************************************************************************/
BOOL LoadMyLibrary(char*ErrorInfo)
{
	//******************************************************************************************************************
	//定义变量
	BOOL returnValue = FALSE;
	char CurrentDir[MAX_PATH] = {0x00};
	char TempFilePath[MAX_PATH] = {0x00};

	//******************************************************************************************************************
	//获取当前路径
	memset(CurrentDir, 0x00, MAX_PATH);
	GetCurrentDirectory(MAX_PATH, CurrentDir);
	//******************************************************************************************************************
	//判断参数
	if(ErrorInfo == NULL)
	{
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载动态库
	if(Uni_hIDDigitalCopierLib)
	{
		returnValue = TRUE;
		goto ExitLine;
	}

	sprintf(TempFilePath, "%s\\IDDigitalCopierDll.dll", CurrentDir);
	Uni_hIDDigitalCopierLib = LoadLibrary(TempFilePath);//path
	if(!Uni_hIDDigitalCopierLib)
	{
		sprintf(ErrorInfo, "加载'IDDigitalCopierDll.dll'失败!");
		goto ExitLine;
	}
	
	
	//******************************************************************************************************************
	//加载EnumScannerDevice
	EnumScannerDevice = (mEnumScannerDevice)GetProcAddress(Uni_hIDDigitalCopierLib, "EnumScannerDevice");
	if(!EnumScannerDevice)
	{
		sprintf(ErrorInfo, "加载'EnumScannerDevice'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载OpenConnection
	OpenConnection = (mOpenConnection)GetProcAddress(Uni_hIDDigitalCopierLib, "OpenConnection");
	if(!OpenConnection)
	{
		sprintf(ErrorInfo, "加载'OpenConnection'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//OpenConnInPath
	OpenConnInPath = (mOpenConnInPath)GetProcAddress(Uni_hIDDigitalCopierLib, "OpenConnInPath");
	if(!OpenConnInPath)
	{
		sprintf(ErrorInfo, "加载'OpenConnInPath'失败!");
		goto ExitLine;
	}
	//******************************************************************************************************************
	//加载CloseConnection
	CloseConnection = (mCloseConnection)GetProcAddress(Uni_hIDDigitalCopierLib, "CloseConnection");
	if(!CloseConnection)
	{
		sprintf(ErrorInfo, "加载'CloseConnection'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载CheckIdCard
	CheckIdCard = (mCheckIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "CheckIdCard");
	if(!CheckIdCard)
	{
		sprintf(ErrorInfo, "加载'CheckIdCard'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载TakeIDCard
	TakeIDCard = (mTakeIDCard)GetProcAddress(Uni_hIDDigitalCopierLib, "TakeIDCard");
	if(!TakeIDCard)
	{
		sprintf(ErrorInfo, "加载'TakeIDCard'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载ScanIdCard
	ScanIdCard = (mScanIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "ScanIdCard");
	if(!ScanIdCard)
	{
		sprintf(ErrorInfo, "加载'ScanIdCard'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载SavePicToStream
	SavePicToStream = (mSavePicToStream)GetProcAddress(Uni_hIDDigitalCopierLib, "SavePicToStream");
	if(!SavePicToStream)
	{
		sprintf(ErrorInfo, "加载'SavePicToStream'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载SaveXSZPicToStream
	SaveXSZPicToStream = (mSaveXSZPicToStream)GetProcAddress(Uni_hIDDigitalCopierLib, "SaveXSZPicToStream");
	if(!SaveXSZPicToStream)
	{
		sprintf(ErrorInfo, "加载'SaveXSZPicToStream'失败!");
		goto ExitLine;
	}
	//******************************************************************************************************************
	//加载SavePicToFile
	SavePicToFile = (mSavePicToFile)GetProcAddress(Uni_hIDDigitalCopierLib, "SavePicToFile");
	if(!SavePicToFile)
	{
		sprintf(ErrorInfo, "加载'SavePicToFile'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载SavePicToFileII
	SavePicToFileII = (mSavePicToFileII)GetProcAddress(Uni_hIDDigitalCopierLib, "SavePicToFileII");
	if(!SavePicToFileII)
	{
		sprintf(ErrorInfo, "加载'SavePicToFileII'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载DistillIDInfo
	DistillIDInfo = (mDistillIDInfo)GetProcAddress(Uni_hIDDigitalCopierLib, "DistillIDInfo");
	if(!DistillIDInfo)
	{
		sprintf(ErrorInfo, "加载'DistillIDInfo'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载SNBCOrHWDistillIDInfo
	SNBCOrHWDistillIDInfo = (mSNBCOrHWDistillIDInfo)GetProcAddress(Uni_hIDDigitalCopierLib, "SNBCOrHWDistillIDInfo");
	if(!SNBCOrHWDistillIDInfo)
	{
		sprintf(ErrorInfo, "加载函数'SNBCOrHWDistillIDInfo'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载GetIDInfo
	GetID2Info = (mGetID2Info)GetProcAddress(Uni_hIDDigitalCopierLib, "GetID2Info");
	if(!GetID2Info)
	{
		sprintf(ErrorInfo, "加载'GetIDInfo'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载FreeMemory
	FreeMemory = (mFreeMemory)GetProcAddress(Uni_hIDDigitalCopierLib, "FreeMemory");
	if(!FreeMemory)
	{
		sprintf(ErrorInfo, "加载'FreeMemory'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载DirectFeedIdCard
	DirectFeedIdCard = (mDirectFeedIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "DirectFeedIdCard");
	if(!DirectFeedIdCard)
	{
		sprintf(ErrorInfo, "加载'DirectFeedIdCard'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载FeedIdCard
	FeedIdCard = (mFeedIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "FeedIdCard");
	if(!FeedIdCard)
	{
		sprintf(ErrorInfo, "加载'FeedIdCard'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载EjectIdCard
	EjectIdCard = (mEjectIdCard)GetProcAddress(Uni_hIDDigitalCopierLib, "EjectIdCard");
	if(!EjectIdCard)
	{
		sprintf(ErrorInfo, "加载'EjectIdCard'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载GetDeviceStatus
	GetDeviceStatus = (mGetDeviceStatus)GetProcAddress(Uni_hIDDigitalCopierLib, "GetDeviceStatus");
	if(!GetDeviceStatus)
	{
		sprintf(ErrorInfo, "加载'GetDeviceStatus'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载SetConfig
	SetConfig = (mSetConfig)GetProcAddress(Uni_hIDDigitalCopierLib, "SetConfig");
	if(!SetConfig)
	{
		sprintf(ErrorInfo, "加载'SetConfig'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载GetLastErrorCode
	GetLastErrorCode = (mGetLastErrorCode)GetProcAddress(Uni_hIDDigitalCopierLib, "GetLastErrorCode");
	if(!GetLastErrorCode)
	{
		sprintf(ErrorInfo, "加载'GetLastErrorCode'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载GetLastErrorStr
	GetLastErrorStr = (mGetLastErrorStr)GetProcAddress(Uni_hIDDigitalCopierLib, "GetLastErrorStr");
	if(!GetLastErrorStr)
	{
		sprintf(ErrorInfo, "加载'GetLastErrorStr'失败!");
		goto ExitLine;
	}

		//******************************************************************************************************************
	//加载SetScanMode
	SetScanMode = (mSetScanMode)GetProcAddress(Uni_hIDDigitalCopierLib, "SetScanMode");
	if(!SetScanMode)
	{
		sprintf(ErrorInfo, "加载'SetScanMode'失败!");
		goto ExitLine;
	}

		//******************************************************************************************************************
	//加载GetScanMode
	GetScanMode = (mGetScanMode)GetProcAddress(Uni_hIDDigitalCopierLib, "GetScanMode");
	if(!GetScanMode)
	{
		sprintf(ErrorInfo, "加载'GetScanMode'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载WriteToExcel
	WriteToExcel = (mWriteToExcel)GetProcAddress(Uni_hIDDigitalCopierLib, "WriteToExcel");
	if(!WriteToExcel)
	{
		sprintf(ErrorInfo, "加载'WriteToExcel'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载EjectIdCardEx
	EjectIdCardEx = (mEjectIdCardEx)GetProcAddress(Uni_hIDDigitalCopierLib, "EjectIdCardEx");
	if(!EjectIdCardEx)
	{
		sprintf(ErrorInfo, "加载'EjectIdCardEx'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载InitServer
	InitServer = (mInitServer)GetProcAddress(Uni_hIDDigitalCopierLib, "InitServer");
	if(!InitServer)
	{
		sprintf(ErrorInfo, "加载'InitServer'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载ExitServer
	ExitServer = (mExitServer)GetProcAddress(Uni_hIDDigitalCopierLib, "ExitServer");
	if(!ExitServer)
	{
		sprintf(ErrorInfo, "加载'ExitServer'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载ChangeID
	ChangeID = (mChangeID)GetProcAddress(Uni_hIDDigitalCopierLib, "ChangeID");
	if(!ChangeID)
	{
		sprintf(ErrorInfo, "加载'ChangeID'失败!");
		goto ExitLine;
	}

	//******************************************************************************************************************
	//加载DistillVehicleInfo
	DistillVehicleInfo = (mDistillVehicleInfo)GetProcAddress(Uni_hIDDigitalCopierLib, "DistillVehicleInfo");
	if(!DistillVehicleInfo)
	{
		sprintf(ErrorInfo, "加载'DistillVehicleInfo'失败!");
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
//函数名：	UnloadMyLibrary
//描述：	卸载动态库
//入口参数:	无
//出口参数:	无
//返回值:	成功返回TRUE，失败返回FALSE
**********************************************************************************************************************/
BOOL UnloadMyLibrary()
{
	//******************************************************************************************************************
	//定义变量
	BOOL returnValue = FALSE;

	//******************************************************************************************************************
	//卸载动态库
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
