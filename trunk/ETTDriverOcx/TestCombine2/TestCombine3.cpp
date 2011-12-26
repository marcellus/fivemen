// TestCombine3.cpp : CTestCombine3App 和 DLL 注册的实现。

#include "stdafx.h"
#include "TestCombine3.h"
#include <initguid.h>
#include "TestCombine2_i.c"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CTestCombine3App theApp;

const GUID CDECL BASED_CODE _tlid =
{ 0xA5FBC2C, 0x81D0, 0x40A8, { 0x82, 0x95, 0x9C, 0x3E, 0xF0, 0xB2, 0x42, 0x10 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CTestCombine3App::InitInstance - DLL 初始化

BOOL CTestCombine3App::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CTestCombine3App::ExitInstance - DLL 终止

int CTestCombine3App::ExitInstance()
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
