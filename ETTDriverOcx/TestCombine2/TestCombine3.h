#pragma once

// TestCombine3.h : TestCombine3.DLL ����ͷ�ļ�

#if !defined( __AFXCTL_H__ )
#error "�ڰ������ļ�֮ǰ������afxctl.h��"
#endif

#include "resource.h"       // ������
#include "TestCombine2_i.h"


// CTestCombine3App : �й�ʵ�ֵ���Ϣ������� TestCombine3.cpp��

class CTestCombine3App : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

