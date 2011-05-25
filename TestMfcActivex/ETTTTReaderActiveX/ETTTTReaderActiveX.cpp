// ETTTTReaderActiveX.cpp : CETTTTReaderActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTTTReaderActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTTTReaderActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x4FCC45AD, 0xFA58, 0x4530, { 0xBD, 0xAD, 0x92, 0x4A, 0xE9, 0xB9, 0x9A, 0xDE } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTTTReaderActiveXApp::InitInstance - DLL 初始化

BOOL CETTTTReaderActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTTTReaderActiveXApp::ExitInstance - DLL 终止

int CETTTTReaderActiveXApp::ExitInstance()
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
