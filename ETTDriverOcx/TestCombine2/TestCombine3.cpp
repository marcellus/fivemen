// TestCombine3.cpp : CTestCombine3App �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "TestCombine3.h"
#include <initguid.h>
#include "TestCombine2_i.c"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CTestCombine3App theApp;

const GUID CDECL BASED_CODE _tlid =
{ 0xA5FBC2C, 0x81D0, 0x40A8, { 0x82, 0x95, 0x9C, 0x3E, 0xF0, 0xB2, 0x42, 0x10 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CTestCombine3App::InitInstance - DLL ��ʼ��

BOOL CTestCombine3App::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CTestCombine3App::ExitInstance - DLL ��ֹ

int CTestCombine3App::ExitInstance()
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
