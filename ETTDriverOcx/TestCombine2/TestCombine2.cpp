// TestCombine2.cpp : CTestCombine2App �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "TestCombine2.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CTestCombine2App theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xECEEA569, 0xFF80, 0x4618, { 0xA2, 0x6B, 0xF5, 0x41, 0xAF, 0xB, 0x96, 0x33 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CTestCombine2App::InitInstance - DLL ��ʼ��

BOOL CTestCombine2App::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CTestCombine2App::ExitInstance - DLL ��ֹ

int CTestCombine2App::ExitInstance()
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
