#pragma once

// ETTSelfUSBVideoActiveX.h : ETTSelfUSBVideoActiveX.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CETTSelfUSBVideoActiveXApp : �й�ʵ�ֵ���Ϣ������� ETTSelfUSBVideoActiveX.cpp��

class CETTSelfUSBVideoActiveXApp : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

