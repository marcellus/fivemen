// ETTDrvA8.cpp : CETTDrvA8App �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTDrvA8.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTDrvA8App theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x5AEAF8AC, 0x7C0F, 0x4B73, { 0x96, 0xC7, 0x66, 0x2B, 0x59, 0x4, 0xC9, 0xF8 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTDrvA8App::InitInstance - DLL ��ʼ��

BOOL CETTDrvA8App::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTDrvA8App::ExitInstance - DLL ��ֹ

int CETTDrvA8App::ExitInstance()
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
