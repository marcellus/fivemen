// ETTEpsonPrinterActiveX.cpp : CETTEpsonPrinterActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTEpsonPrinterActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTEpsonPrinterActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x67A95709, 0xA323, 0x46F2, { 0x9C, 0x64, 0x72, 0xAA, 0xBC, 0xD7, 0x59, 0x3F } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTEpsonPrinterActiveXApp::InitInstance - DLL ��ʼ��

BOOL CETTEpsonPrinterActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTEpsonPrinterActiveXApp::ExitInstance - DLL ��ֹ

int CETTEpsonPrinterActiveXApp::ExitInstance()
{
	// TODO: �ڴ�������Լ���ģ����ֹ���롣

	return COleControlModule::ExitInstance();
}



// DllRegisterServer - ������ӵ�ϵͳע���

STDAPI DllRegisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleRegisterTypeLib(AfxGetInstanceHandle(), _tlid))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(TRUE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}



// DllUnregisterServer - �����ϵͳע������Ƴ�

STDAPI DllUnregisterServer(void)
{
	AFX_MANAGE_STATE(_afxModuleAddrThis);

	if (!AfxOleUnregisterTypeLib(_tlid, _wVerMajor, _wVerMinor))
		return ResultFromScode(SELFREG_E_TYPELIB);

	if (!COleObjectFactoryEx::UpdateRegistryAll(FALSE))
		return ResultFromScode(SELFREG_E_CLASS);

	return NOERROR;
}
