// ETTSelfUSBVideoActiveX.cpp : CETTSelfUSBVideoActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTSelfUSBVideoActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTSelfUSBVideoActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x71885BFD, 0xDA30, 0x4D7D, { 0xB0, 0xAA, 0x34, 0xA9, 0x97, 0xB7, 0xAB, 0xB5 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTSelfUSBVideoActiveXApp::InitInstance - DLL ��ʼ��

BOOL CETTSelfUSBVideoActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTSelfUSBVideoActiveXApp::ExitInstance - DLL ��ֹ

int CETTSelfUSBVideoActiveXApp::ExitInstance()
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
