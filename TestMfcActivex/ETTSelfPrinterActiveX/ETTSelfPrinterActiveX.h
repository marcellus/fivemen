#pragma once

// ETTSelfPrinterActiveX.h : ETTSelfPrinterActiveX.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������


// CETTSelfPrinterActiveXApp : �й�ʵ�ֵ���Ϣ������� ETTSelfPrinterActiveX.cpp��

class CETTSelfPrinterActiveXApp : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

