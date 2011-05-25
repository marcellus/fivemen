// ETTA8IDCardActiveX.cpp : CETTA8IDCardActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTA8IDCardActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTA8IDCardActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x62CCCF45, 0x8C94, 0x4650, { 0xA0, 0xB2, 0xB4, 0x81, 0x5F, 0x49, 0x1E, 0x7 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTA8IDCardActiveXApp::InitInstance - DLL 初始化

BOOL CETTA8IDCardActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTA8IDCardActiveXApp::ExitInstance - DLL 终止

int CETTA8IDCardActiveXApp::ExitInstance()
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
