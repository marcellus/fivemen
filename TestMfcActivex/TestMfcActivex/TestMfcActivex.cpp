// TestMfcActivex.cpp : CTestMfcActivexApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "TestMfcActivex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CTestMfcActivexApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x9D788FCF, 0xE42C, 0x4FED, { 0xAB, 0x59, 0x88, 0x53, 0x23, 0xDA, 0xEE, 0x73 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CTestMfcActivexApp::InitInstance - DLL ��ʼ��

BOOL CTestMfcActivexApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CTestMfcActivexApp::ExitInstance - DLL ��ֹ

int CTestMfcActivexApp::ExitInstance()
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
