// ETTTTReaderActiveX.cpp : CETTTTReaderActiveXApp �� DLL ע���ʵ�֡�

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



// CETTTTReaderActiveXApp::InitInstance - DLL ��ʼ��

BOOL CETTTTReaderActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTTTReaderActiveXApp::ExitInstance - DLL ��ֹ

int CETTTTReaderActiveXApp::ExitInstance()
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
