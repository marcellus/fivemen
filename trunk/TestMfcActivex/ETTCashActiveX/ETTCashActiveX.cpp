// ETTCashActiveX.cpp : CETTCashActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTCashActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTCashActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x9E410F6F, 0xED28, 0x4279, { 0xA3, 0x7A, 0x5E, 0x70, 0xE6, 0x87, 0x71, 0xA1 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTCashActiveXApp::InitInstance - DLL 初始化

BOOL CETTCashActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTCashActiveXApp::ExitInstance - DLL 终止

int CETTCashActiveXApp::ExitInstance()
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
