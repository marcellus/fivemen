// ETTSelfPrinterActiveX.cpp : CETTSelfPrinterActiveXApp �� DLL ע���ʵ�֡�

#include "stdafx.h"
#include "ETTSelfPrinterActiveX.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


CETTSelfPrinterActiveXApp theApp;

const GUID CDECL BASED_CODE _tlid =
		{ 0xAD83D01E, 0x7CCF, 0x496D, { 0xBD, 0x99, 0x12, 0x1A, 0xA5, 0xBC, 0xDE, 0x85 } };
const WORD _wVerMajor = 1;
const WORD _wVerMinor = 0;



// CETTSelfPrinterActiveXApp::InitInstance - DLL ��ʼ��

BOOL CETTSelfPrinterActiveXApp::InitInstance()
{
	BOOL bInit = COleControlModule::InitInstance();

	if (bInit)
	{
		// TODO: �ڴ�������Լ���ģ���ʼ�����롣
	}

	return bInit;
}



// CETTSelfPrinterActiveXApp::ExitInstance - DLL ��ֹ

int CETTSelfPrinterActiveXApp::ExitInstance()
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
