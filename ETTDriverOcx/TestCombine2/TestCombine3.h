#pragma once

// TestCombine3.h : TestCombine3.DLL 的主头文件

#if !defined( __AFXCTL_H__ )
#error "在包括此文件之前包括“afxctl.h”"
#endif

#include "resource.h"       // 主符号
#include "TestCombine2_i.h"


// CTestCombine3App : 有关实现的信息，请参阅 TestCombine3.cpp。

class CTestCombine3App : public COleControlModule
{
public:
	BOOL InitInstance();
	int ExitInstance();
};

extern const GUID CDECL _tlid;
extern const WORD _wVerMajor;
extern const WORD _wVerMinor;

