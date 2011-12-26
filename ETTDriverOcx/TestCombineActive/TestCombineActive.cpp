// TestCombineActive.cpp : CTestCombineActiveApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "TestCombineActive.h"
#include "CDETTKMYActiveX.h"
#include "CDETTSelfIDCardActiveX.h"
#include "CDETTSelfIDCardActiveXEvents.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CTestCombineActiveApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xA351C60, 0xBA5F, 0x4CD4, { 0x9C, 0x80, 0x60, 0x10, 0x81, 0xEE, 0x58, 0x7C } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CTestCombineActiveApp::InitInstance - DLL ��ʼ��

BOOL CTestCombineActiveApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CTestCombineActiveApp::ExitInstance - DLL ��ֹ

int CTestCombineActiveApp::ExitInstance()
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
