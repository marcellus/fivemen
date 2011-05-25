// ETTPrintActiveX.cpp : CETTPrintActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTPrintActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTPrintActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x29D07778, 0xECD, 0x40A6, { 0xA7, 0x99, 0x5B, 0x9A, 0xCE, 0xBD, 0x10, 0x39 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTPrintActiveXApp::InitInstance - DLL 初始化

BOOL CETTPrintActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTPrintActiveXApp::ExitInstance - DLL 终止

int CETTPrintActiveXApp::ExitInstance()
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
