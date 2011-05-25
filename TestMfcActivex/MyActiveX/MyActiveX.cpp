// MyActiveX.cpp : CMyActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "MyActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CMyActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xA5B3C774, 0xD499, 0x4DBF, { 0xBC, 0x4, 0x3D, 0x23, 0xB9, 0x71, 0x43, 0xF } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CMyActiveXApp::InitInstance - DLL ��ʼ��

BOOL CMyActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CMyActiveXApp::ExitInstance - DLL ��ֹ

int CMyActiveXApp::ExitInstance()
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
