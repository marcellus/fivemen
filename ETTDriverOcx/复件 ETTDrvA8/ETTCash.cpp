// ETTCash.cpp : CETTCashApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTCash.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTCashApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x62C88F93, 0x9EF, 0x4584, { 0xA3, 0x8C, 0x6E, 0xDA, 0x8F, 0x31, 0x1D, 0xF9 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTCashApp::InitInstance - DLL ��ʼ��

BOOL CETTCashApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTCashApp::ExitInstance - DLL ��ֹ

int CETTCashApp::ExitInstance()
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
