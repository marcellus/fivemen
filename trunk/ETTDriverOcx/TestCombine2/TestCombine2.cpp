// TestCombine2.cpp : CTestCombine2App 和 DLL 注册的实现。

#include "stdafx.h"
#include "TestCombine2.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CTestCombine2App theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xECEEA569, 0xFF80, 0x4618, { 0xA2, 0x6B, 0xF5, 0x41, 0xAF, 0xB, 0x96, 0x33 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CTestCombine2App::InitInstance - DLL 初始化

BOOL CTestCombine2App::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CTestCombine2App::ExitInstance - DLL 终止

int CTestCombine2App::ExitInstance()
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
