// IdCardReaderActiveX.cpp : CIdCardReaderActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "IdCardReaderActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CIdCardReaderActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x9A8805FE, 0x745A, 0x4C1C, { 0x93, 0xCD, 0x84, 0xA2, 0xFE, 0x11, 0x31, 0x5B } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CIdCardReaderActiveXApp::InitInstance - DLL ��ʼ��

BOOL CIdCardReaderActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CIdCardReaderActiveXApp::ExitInstance - DLL ��ֹ

int CIdCardReaderActiveXApp::ExitInstance()
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
