#pragma once

// ETTSelfIDCardActiveX.h : ETTSelfIDCardActiveX.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CETTSelfIDCardActiveXApp : �й�ʵ�ֵ���Ϣ������� ETTSelfIDCardActiveX.cpp��

class CETTSelfIDCardActiveXApp : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

