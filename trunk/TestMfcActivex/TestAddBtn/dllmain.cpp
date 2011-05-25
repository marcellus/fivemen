// dllmain.cpp : DllMain 的实现。

#include "stdafx.h"
#include "resource.h"
#include "TestAddBtn_i.h"
#include "dllmain.h"
#include "dlldatax.h"

CTestAddBtnModule _AtlModule;

class CTestAddBtnApp : public CWinApp
{
public:

// 重写
	virtual BOOL InitInstance();
	virtual int ExitInstance();

	DECLARE_MESSAGE_MAP()
};

BEGIN_MESSAGE_MAP(CTestAddBtnApp, CWinApp)
END_MESSAGE_MAP()

CTestAddBtnApp theApp;

BOOL CTestAddBtnApp::InitInstance()
{
#ifdef _MERGE_PROXYSTUB
	if (!PrxDllMain(m_hInstance, DLL_PROCESS_ATTACH, NULL))
		return FALSE;
#endif
	return CWinApp::InitInstance();
}

int CTestAddBtnApp::ExitInstance()
{
	return CWinApp::ExitInstance();
}
