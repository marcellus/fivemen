// ETTA8IDCardActiveX.cpp : CETTA8IDCardActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTA8IDCardActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTA8IDCardActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x62CCCF45, 0x8C94, 0x4650, { 0xA0, 0xB2, 0xB4, 0x81, 0x5F, 0x49, 0x1E, 0x7 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTA8IDCardActiveXApp::InitInstance - DLL ��ʼ��

BOOL CETTA8IDCardActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTA8IDCardActiveXApp::ExitInstance - DLL ��ֹ

int CETTA8IDCardActiveXApp::ExitInstance()
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
