HANDLE __stdcall M100_CommOpen(char *Port);
HANDLE __stdcall M100_CommOpenWithBaud(char *Port, unsigned int _data);
int __stdcall M100_CommClose(HANDLE ComHandle);
int __stdcall M100_GetSysVerion(HANDLE ComHandle, char *strVerion);
//+++++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_SetCommBaud(HANDLE ComHandle, unsigned int _Baud);
int __stdcall M100_Reset(HANDLE ComHandle, BYTE _PM,BYTE _VerCode[14]);
int __stdcall M100_CheckCardPosition(HANDLE ComHandle, BYTE *_Position);
int __stdcall M100_CheckSensorStates(HANDLE ComHandle, BYTE _States[7]);
int __stdcall M100_EnterCard(HANDLE ComHandle,BYTE EnterType,DWORD WaitTime);
int __stdcall M100_EnterCardUntime(HANDLE ComHandle, BYTE EnterType);//;;;½ø¿¨Á¢¼´·µ»Ø
int __stdcall M100_MoveCard(HANDLE ComHandle, BYTE _PM);
int __stdcall M100_AutoTestICCard(HANDLE ComHandle, BYTE *_IcCardType);
int __stdcall M100_Led1Control(HANDLE ComHandle, BYTE _PM);
int __stdcall M100_Led2Control(HANDLE ComHandle, BYTE _PM);
int __stdcall M100_Eot(HANDLE ComHandle);
//++++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_ReadMagcardDecode(HANDLE ComHandle, BYTE _track, DWORD *_DataLen,BYTE _BlockData[]);
int __stdcall M100_ReadMagcardUNDecode(HANDLE ComHandle,BYTE _track, DWORD *_DataLen,BYTE _BlockData[]);
int __stdcall M100_ClearMagCardData(HANDLE ComHandle);
//++++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_S50DetectCard(HANDLE ComHandle);
int __stdcall M100_S50GetCardID(HANDLE ComHandle, BYTE _CardID[4]);
int __stdcall M100_S50LoadSecKey(HANDLE ComHandle, BYTE _BlockAddr, BYTE _KEYType, BYTE _KEY[6]);
int __stdcall M100_S50ReadBlock(HANDLE ComHandle, BYTE _Block, BYTE _BlockData[16]);
int __stdcall M100_S50WriteBlock(HANDLE ComHandle, BYTE _Block, BYTE _BlockData[16]);
int __stdcall M100_S50InitValue(HANDLE ComHandle, BYTE _Block, BYTE _Data[16]);
int __stdcall M100_S50Increment(HANDLE ComHandle, BYTE _Block, BYTE _Data[4]);
int __stdcall M100_S50Decrement(HANDLE ComHandle, BYTE _Block, BYTE _Data[4]);
int __stdcall M100_S50Halt(HANDLE ComHandle);
int __stdcall M100_S70DetectCard(HANDLE ComHandle);
int __stdcall M100_S70GetCardID(HANDLE ComHandle, BYTE _CardID[4]);
int __stdcall M100_S70LoadSecKey(HANDLE ComHandle, BYTE _BlockAddr, BYTE _KEYType, BYTE _KEY[6]);
int __stdcall M100_S70ReadBlock(HANDLE ComHandle, BYTE _Block, BYTE _BlockData[16]);
int __stdcall M100_S70WriteBlock(HANDLE ComHandle, BYTE _Block, BYTE _BlockData[16]);
int __stdcall M100_S70InitValue(HANDLE ComHandle, BYTE _Block, BYTE _Data[16]);
int __stdcall M100_S70Increment(HANDLE ComHandle, BYTE _Block, BYTE _Data[4]);
int __stdcall M100_S70Decrement(HANDLE ComHandle, BYTE _Block, BYTE _Data[4]);
int __stdcall M100_S70Halt(HANDLE ComHandle);
int __stdcall M100_ULDetectCard(HANDLE ComHandle);
int __stdcall M100_ULGetCardID(HANDLE ComHandle, BYTE _CardID[7]);
int __stdcall M100_ULReadBlock(HANDLE ComHandle, BYTE _Block, BYTE _BlockData[16]);
int __stdcall M100_ULWriteBlock(HANDLE ComHandle, BYTE _Block, BYTE _BlockData[16]);
int __stdcall M100_ULHalt(HANDLE ComHandle);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_IcCardPowerOn(HANDLE ComHandle);
int __stdcall M100_IcCardPowerOff(HANDLE ComHandle);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_CpuCardColdReset(HANDLE ComHandle, BYTE *_CPUType,BYTE _RstData[], BYTE *_RstdataLen);
int __stdcall M100_CpuCardPowerOff(HANDLE ComHandle);
int __stdcall M100_CpuCardWarmReset(HANDLE ComHandle, BYTE _VOLTAGE,BYTE *_CPUType, BYTE _RstData[], BYTE *_RstdataLen);
int __stdcall M100_CPUT0APDU(HANDLE ComHandle, int _dataLen, BYTE _APDUData[], BYTE _exData[], int *_exdataLen);
int __stdcall M100_CPUT1APDU(HANDLE ComHandle, int _dataLen, BYTE _APDUData[], BYTE _exData[], int *_exdataLen);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_SimColdReset(HANDLE ComHandle, BYTE *_SIMTYPE,BYTE _exData[], int *_exdataLen);
int __stdcall M100_SimCardPowerOff(HANDLE ComHandle);
int __stdcall M100_SimT0APDU(HANDLE ComHandle,  int _dataLen, BYTE _APDUData[], BYTE _exData[], int *_exdataLen);
int __stdcall M100_SimT1APDU(HANDLE ComHandle,  int _dataLen, BYTE _APDUData[], BYTE _exData[], int *_exdataLen);
int __stdcall M100_SimSelect(HANDLE ComHandle, BYTE SIMNo);
int __stdcall M100_SimWarmReset(HANDLE ComHandle,BYTE _VOLTAGE, BYTE *_SIMTYPE,BYTE _exData[], int *_exdataLen);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_AT24CXXRead(HANDLE ComHandle, BYTE _CardType, int _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_AT24CXXWrite(HANDLE ComHandle, BYTE _CardType, int _Address, BYTE _dataLen, BYTE _BlockData[]);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_AT45DB041Reset(HANDLE ComHandle);
int __stdcall M100_AT45DB041Read(HANDLE ComHandle, int  _Address, BYTE _BlockData[]);
int __stdcall M100_AT45DB041Write(HANDLE ComHandle, int  _Address, BYTE _BlockData[264]);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_AT88SC102Reset(HANDLE ComHandle);
int __stdcall M100_AT88SC102VerifyPWD(HANDLE ComHandle, BYTE _PWData[2]);
int __stdcall M100_AT88SC102Read(HANDLE ComHandle, BYTE _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_AT88SC102Security1Erasure(HANDLE ComHandle, BYTE _Address, BYTE _dataLen);
int __stdcall M100_AT88SC102Security2ErasureApp1(HANDLE ComHandle,BYTE _Security2App1PW[6]);
int __stdcall M100_AT88SC102Security2ErasureApp2(HANDLE ComHandle,BYTE _EC2, BYTE _Security2App2PW[4]);
int __stdcall M100_AT88SC102Write(HANDLE ComHandle, BYTE _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_AT88SC102WritePWD(HANDLE ComHandle, BYTE _PWType,BYTE _PWData[]);
int __stdcall M100_AT88SC102SetMode(HANDLE ComHandle, BYTE _CtrlMode);
int __stdcall M100_AT88SC102DisableEC2(HANDLE ComHandle);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_AT88SC1604Reset(HANDLE ComHandle);
int __stdcall M100_AT88SC1604VerifyPWD(HANDLE ComHandle, BYTE _PWType, BYTE _PWData[]);
int __stdcall M100_AT88SC1604Read(HANDLE ComHandle,  int _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_AT88SC1604Erasure(HANDLE ComHandle, int _Address, BYTE _dataLen);
int __stdcall M100_AT88SC1604Write(HANDLE ComHandle, int _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_AT88SC1604WritePWD(HANDLE ComHandle, BYTE _PWType,BYTE _PWData[]);
int __stdcall M100_AT88SC1604Personalization(HANDLE ComHandle,BYTE _PM);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_AT88SC1608Reset(HANDLE ComHandle);
int __stdcall M100_AT88SC1608VerifyPWD(HANDLE ComHandle, BYTE _PWType, BYTE _PWData[]);
int __stdcall M100_AT88SC1608Read(HANDLE ComHandle, BYTE _Index, BYTE _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_AT88SC1608Write(HANDLE ComHandle, BYTE _Index, BYTE _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_AT88SC1608ReadFUSE(HANDLE ComHandle, BYTE * _FAB, BYTE * _CMA, BYTE * _PER);
int __stdcall M100_AT88SC1608WriteFUSE(HANDLE ComHandle);
int __stdcall M100_AT88SC1608InitAuth(HANDLE ComHandle, BYTE _DATA[8]);
int __stdcall M100_AT88SC1608VerifyAuth(HANDLE ComHandle, BYTE _DATA[8]);
int __stdcall M100_AT88SC1608WritePWD(HANDLE ComHandle, BYTE _PWType,BYTE _PWData[]);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_SLE4442Reset(HANDLE ComHandle);
int __stdcall M100_SLE4442VerifyPWD(HANDLE ComHandle, BYTE _PWData[3]);
int __stdcall M100_SLE4442Read(HANDLE ComHandle, BYTE _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_SLE4442ReadProtectBit(HANDLE ComHandle, BYTE _BlockData[32]);
int __stdcall M100_SLE4442ReadSafety(HANDLE ComHandle, BYTE _BlockData[4]);
int __stdcall M100_SLE4442Write(HANDLE ComHandle, BYTE _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_SLE4442WriteProtectBit(HANDLE ComHandle, BYTE _Address,BYTE _DataLen,BYTE _BlockData[32]);
int __stdcall M100_SLE4442ChangePWD(HANDLE ComHandle, BYTE _PWData[3]);
//+++++++++++++++++++++++++++++++++++++++++++++++++++//
int __stdcall M100_Sle4428Reset(HANDLE ComHandle);
int __stdcall M100_Sle4428VerifyPWD(HANDLE ComHandle, BYTE _PWData[2]);
int __stdcall M100_Sle4428Read(HANDLE ComHandle, int _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_Sle4428ReadProtectBit(HANDLE ComHandle, int _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_Sle4428Write(HANDLE ComHandle, int _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_Sle4428WriteP(HANDLE ComHandle, int _Address, BYTE _dataLen, BYTE _BlockData[]);
int __stdcall M100_Sle4428ChangePWD(HANDLE ComHandle, BYTE _PWData[2]);
//++++++++++++++++++++++++++++++++++++++++++++++++++//