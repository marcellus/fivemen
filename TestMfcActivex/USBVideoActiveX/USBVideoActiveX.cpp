// USBVideoActiveX.cpp : CUSBVideoActiveXApp �� DLL ע���ʵ�֡�

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



// CUSBVideoActiveXApp::InitInstance - DLL ��ʼ��

BOOL CUSBVideoActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CUSBVideoActiveXApp::ExitInstance - DLL ��ֹ

int CUSBVideoActiveXApp::ExitInstance()
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
