// ETTSelfIDCardActiveX.cpp : CETTSelfIDCardActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTSelfIDCardActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTSelfIDCardActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xFD5A8311, 0x18FF, 0x4AF7, { 0x80, 0x56, 0xB1, 0xD6, 0x5A, 0x41, 0x1D, 0xEA } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTSelfIDCardActiveXApp::InitInstance - DLL 初始化

BOOL CETTSelfIDCardActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTSelfIDCardActiveXApp::ExitInstance - DLL 终止

int CETTSelfIDCardActiveXApp::ExitInstance()
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
