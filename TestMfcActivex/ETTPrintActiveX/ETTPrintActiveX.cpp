// ETTPrintActiveX.cpp : CETTPrintActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTPrintActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTPrintActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x29D07778, 0xECD, 0x40A6, { 0xA7, 0x99, 0x5B, 0x9A, 0xCE, 0xBD, 0x10, 0x39 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTPrintActiveXApp::InitInstance - DLL ��ʼ��

BOOL CETTPrintActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTPrintActiveXApp::ExitInstance - DLL ��ֹ

int CETTPrintActiveXApp::ExitInstance()
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
