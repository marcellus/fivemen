// ETTCashCodeActiveX.cpp : CETTCashCodeActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTCashCodeActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTCashCodeActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x5971B212, 0x780E, 0x4853, { 0x8F, 0xF4, 0x3D, 0x7B, 0xA6, 0x76, 0xAC, 0xC8 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTCashCodeActiveXApp::InitInstance - DLL ��ʼ��

BOOL CETTCashCodeActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTCashCodeActiveXApp::ExitInstance - DLL ��ֹ

int CETTCashCodeActiveXApp::ExitInstance()
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
