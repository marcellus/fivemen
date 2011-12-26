// ETTDrvA8.cpp : CETTDrvA8App 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTDrvA8.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTDrvA8App theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x5AEAF8AC, 0x7C0F, 0x4B73, { 0x96, 0xC7, 0x66, 0x2B, 0x59, 0x4, 0xC9, 0xF8 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTDrvA8App::InitInstance - DLL 初始化

BOOL CETTDrvA8App::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTDrvA8App::ExitInstance - DLL 终止

int CETTDrvA8App::ExitInstance()
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
