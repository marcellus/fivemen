#pragma once

// ETTDrvA8.h : ETTDrvA8.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CETTDrvA8App : �й�ʵ�ֵ���Ϣ������� ETTDrvA8.cpp��

class CETTDrvA8App : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

