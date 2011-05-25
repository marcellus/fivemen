// ETTSelfHotPrinterActiveX.cpp : CETTSelfHotPrinterActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTSelfHotPrinterActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTSelfHotPrinterActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x831D9190, 0x4CF1, 0x401A, { 0x87, 0x43, 0x16, 0x8C, 0x81, 0xE6, 0xD2, 0x4D } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTSelfHotPrinterActiveXApp::InitInstance - DLL 初始化

BOOL CETTSelfHotPrinterActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTSelfHotPrinterActiveXApp::ExitInstance - DLL 终止

int CETTSelfHotPrinterActiveXApp::ExitInstance()
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
