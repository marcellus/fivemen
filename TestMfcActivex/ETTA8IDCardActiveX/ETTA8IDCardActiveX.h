#pragma once

// ETTA8IDCardActiveX.h : ETTA8IDCardActiveX.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CETTA8IDCardActiveXApp : �й�ʵ�ֵ���Ϣ������� ETTA8IDCardActiveX.cpp��

class CETTA8IDCardActiveXApp : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

