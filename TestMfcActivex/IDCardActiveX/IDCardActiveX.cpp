// IDCardActiveX.cpp : CIDCardActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "IDCardActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CIDCardActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x5D8BBCC4, 0x5AF8, 0x4A1E, { 0x88, 0xE5, 0x21, 0x3C, 0xD0, 0x68, 0x5E, 0xCC } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CIDCardActiveXApp::InitInstance - DLL 初始化

BOOL CIDCardActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CIDCardActiveXApp::ExitInstance - DLL 终止

int CIDCardActiveXApp::ExitInstance()
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
