// ETTCashCodeActiveX.cpp : CETTCashCodeActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTCashCodeActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTCashCodeActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x5971B212, 0x780E, 0x4853, { 0x8F, 0xF4, 0x3D, 0x7B, 0xA6, 0x76, 0xAC, 0xC8 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTCashCodeActiveXApp::InitInstance - DLL 初始化

BOOL CETTCashCodeActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTCashCodeActiveXApp::ExitInstance - DLL 终止

int CETTCashCodeActiveXApp::ExitInstance()
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
