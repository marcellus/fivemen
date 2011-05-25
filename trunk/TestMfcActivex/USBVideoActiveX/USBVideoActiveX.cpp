// USBVideoActiveX.cpp : CUSBVideoActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "USBVideoActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CUSBVideoActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x1EAAE7E, 0xFEAB, 0x460B, { 0x97, 0x5F, 0xB8, 0xE7, 0x61, 0xCB, 0x2A, 0xED } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CUSBVideoActiveXApp::InitInstance - DLL 初始化

BOOL CUSBVideoActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CUSBVideoActiveXApp::ExitInstance - DLL 终止

int CUSBVideoActiveXApp::ExitInstance()
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
