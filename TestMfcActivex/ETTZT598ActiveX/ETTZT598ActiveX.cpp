// ETTZT598ActiveX.cpp : CETTZT598ActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTZT598ActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTZT598ActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x7D7D0822, 0xE349, 0x4A21, { 0x8E, 0xE6, 0xF3, 0x96, 0xF2, 0x83, 0xEA, 0x5F } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTZT598ActiveXApp::InitInstance - DLL ��ʼ��

BOOL CETTZT598ActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTZT598ActiveXApp::ExitInstance - DLL ��ֹ

int CETTZT598ActiveXApp::ExitInstance()
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
