// VoiceActiveX.cpp : CVoiceActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "VoiceActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CVoiceActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0x66299FE8, 0xDFC5, 0x47AB, { 0xB2, 0x25, 0xE8, 0xD, 0xA6, 0x41, 0x29, 0x35 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CVoiceActiveXApp::InitInstance - DLL ��ʼ��

BOOL CVoiceActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CVoiceActiveXApp::ExitInstance - DLL ��ֹ

int CVoiceActiveXApp::ExitInstance()
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
