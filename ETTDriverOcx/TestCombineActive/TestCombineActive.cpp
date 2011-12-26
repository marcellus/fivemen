// TestCombineActive.cpp : CTestCombineActiveApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "TestCombineActive.h"
#include "CDETTKMYActiveX.h"
#include "CDETTSelfIDCardActiveX.h"
#include "CDETTSelfIDCardActiveXEvents.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CTestCombineActiveApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xA351C60, 0xBA5F, 0x4CD4, { 0x9C, 0x80, 0x60, 0x10, 0x81, 0xEE, 0x58, 0x7C } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CTestCombineActiveApp::InitInstance - DLL 初始化

BOOL CTestCombineActiveApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CTestCombineActiveApp::ExitInstance - DLL 终止

int CTestCombineActiveApp::ExitInstance()
{
	// TODO: 在此添加您自己的模块终止代码。

	return COleControlModule::ExitInstance();
}



// DllRegisterServer - 将项添加到系统注册表

STDAPI DllRegisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleRegisterTypeLib(AfxGetInstanceHandle(), _tlid))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(TRUE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}



// DllUnregisterServer - 将项从系统注册表中移除

STDAPI DllUnregisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleUnregisterTypeLib(_tlid, _wVerMajor, _wVerMinor))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(FALSE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}
