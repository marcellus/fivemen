#pragma once
#include "ISO8583.h"

class CRegister
{
public:
	CRegister(void);
	virtual ~CRegister(void);

public:
	int SendRegisterData();

private:
	void BuildPackage(CIso8583Package *package,char *sTermID,char *sMercID/*,char *sProcCode*/);
	int Read8583Package(CIso8583Parse *package,BYTE *pBuf);
};