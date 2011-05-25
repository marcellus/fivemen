// ETTSelfPrinterActiveX.cpp : CETTSelfPrinterActiveXApp 和 DLL 注册的实现。

#include "stdafx.h"
#include "ETTSelfPrinterActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTSelfPrinterActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xAD83D01E, 0x7CCF, 0x496D, { 0xBD, 0x99, 0x12, 0x1A, 0xA5, 0xBC, 0xDE, 0x85 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTSelfPrinterActiveXApp::InitInstance - DLL 初始化

BOOL CETTSelfPrinterActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: 在此添加您自己的模块初始化代码。
	}

	return bInit;
}



// CETTSelfPrinterActiveXApp::ExitInstance - DLL 终止

int CETTSelfPrinterActiveXApp::ExitInstance()
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
