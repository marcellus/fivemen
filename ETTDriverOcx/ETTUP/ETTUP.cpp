// ETTUP.cpp : CETTUPApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTUP.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTUPApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x1692E992, 0xB5A7, 0x405A, { 0xAC, 0x6D, 0xA7, 0x82, 0xAA, 0xCE, 0x4, 0x2A } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTUPApp::InitInstance - DLL 初始化

BOOL CETTUPApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTUPApp::ExitInstance - DLL 终止

int CETTUPApp::ExitInstance()
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
