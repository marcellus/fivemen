#pragma once

// ETTZT598ActiveX.h : ETTZT598ActiveX.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CETTZT598ActiveXApp : �й�ʵ�ֵ���Ϣ������� ETTZT598ActiveX.cpp��

class CETTZT598ActiveXApp : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

