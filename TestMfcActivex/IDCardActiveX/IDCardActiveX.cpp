// IDCardActiveX.cpp : CIDCardActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "IDCardActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CIDCardActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x5D8BBCC4, 0x5AF8, 0x4A1E, { 0x88, 0xE5, 0x21, 0x3C, 0xD0, 0x68, 0x5E, 0xCC } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CIDCardActiveXApp::InitInstance - DLL ��ʼ��

BOOL CIDCardActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CIDCardActiveXApp::ExitInstance - DLL ��ֹ

int CIDCardActiveXApp::ExitInstance()
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
