#pragma once

// ETTTTReaderActiveX.h : ETTTTReaderActiveX.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CETTTTReaderActiveXApp : �й�ʵ�ֵ���Ϣ������� ETTTTReaderActiveX.cpp��

class CETTTTReaderActiveXApp : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

