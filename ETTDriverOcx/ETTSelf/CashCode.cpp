// CashCode.cpp : CCashCode ��ʵ��

#include "stdafx.h"
#include "CashCode.h"

#include <comutil.h>
#include "windows.h"
#pragma comment(lib,"comsuppw.lib")


// CCashCode


STDMETHODIMP CCashCode::get_HasAcceptMoney(SHORT* pVal)
{
	// TODO: �ڴ����ʵ�ִ���

	return S_OK;
}

STDMETHODIMP CCashCode::put_HasAcceptMoney(SHORT newVal)
{
	// TODO: �ڴ����ʵ�ִ���

	return S_OK;
}

STDMETHODIMP CCashCode::get_Message(BSTR* pVal)
{
	// TODO: �ڴ����ʵ�ִ���

	return S_OK;
}

STDMETHODIMP CCashCode::put_Message(BSTR newVal)
{
	// TODO: �ڴ����ʵ�ִ���

	return S_OK;
}

STDMETHODIMP CCashCode::LoadDll(void)
{
	// TODO: �ڴ���ӵ��ȴ���������
	if(DLLInstPrint==NULL)
	{

		// AfxMessageBox("���ض�̬��BillValidator.dll��");
		DLLInstPrint=LoadLibrary(_T("BillValidator.dll"));
	}
	else
	{
		// AfxMessageBox("�Ѿ����ڶ�̬��BillValidator.dll��");
	}

	//AfxMessageBox("LoadLibrary -sdtapi.dll �ɹ���");
	//AfxMessageBox("LoadLibrary -WltRS.dll �ɹ���");
	if(DLLInstPrint!=NULL)
	{
		//AfxMessageBox("�Ӷ�̬���л�ȡ������");
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		StartIdentify=(int(__stdcall *)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message))GetProcAddress(DLLInstPrint,"StartIdentify");

		StartIdentifyV2=(int(__stdcall *)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message))GetProcAddress(DLLInstPrint,"StartIdentifyV2");

		StopIdentify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"StopIdentify");
		Identify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Identify");

		IdentifyV2=(int(__stdcall *)(int,char* Message))GetProcAddress(DLLInstPrint,"IdentifyV2");

		Reset=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Reset");
		this->put_Message(_T("�ɹ�"));


	}
	else
	{
	    this->put_Message(_T("ʧ��"));
		//AfxMessageBox("���ض�̬��BillValidator.dllʧ�ܣ�");

		exit(0);
		return S_FALSE;
	}

	return S_OK;
}

STDMETHODIMP CCashCode::DestroyDll(void)
{
	if(DLLInstPrint!=NULL)
	{
		//AfxMessageBox("�ͷ�DLL��");
		FreeLibrary(DLLInstPrint);
		DLLInstPrint=NULL;
		this->put_Message(_T("�ɹ�"));
	}
	else
	{
		this->put_Message(_T("ʧ��"));
		return S_FALSE;
	}

	

	return S_OK;
}

STDMETHODIMP CCashCode::InitCashCode(SHORT port)
{
	// TODO: �ڴ����ʵ�ִ���

	return S_OK;
}

STDMETHODIMP CCashCode::InitCashCodeV2(SHORT port)
{
	int ret=-1;
	try
	{


		this->LoadDll();
		//AfxMessageBox("��ʼִ��InitCashCodeV2");
		//Sleep(1000);
		//CString tmp;

		char msg[255];
		//AfxMessageBox("׼����ֽ�Ҷ˿�2");

		ret=OpenDevice(port,msg);
		//ret=OpenDevice(2,msg);
		//Sleep(100);
		//tmp.Format(_T("���豸�˿�%d���%d"),2,ret);
		//AfxMessageBox(tmp);
		ret=Reset(msg);
		Sleep(100);
		//tmp.Format(_T("��λʶ����%d"),ret);
		//AfxMessageBox(tmp);
		ret=StartIdentifyV2("lsh","userno","1111111",msg);
		this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));
	}

	catch (...)
	{
		DWORD dw = GetLastError();
		CString str;
		str.Format("GetLastError = %u",dw);
		AfxMessageBox(str);

	}

	return ret;
}

STDMETHODIMP CCashCode::IdentifyExV2(SHORT maxmoney)
{
	//CString tmp;

	char msg[255];
	int ret=-1;
	ret=IdentifyV2(maxmoney,msg);
	this->put_Message(_T(_com_util::ConvertStringToBSTR(msg);


	return ret;
}

STDMETHODIMP CCashCode::CloseCashCode(void)
{
	//CString tmp;

	char msg[255];
	int ret=-1;

	ret=StopIdentify(msg);
	//tmp.Format(_T("ֹͣʶ��%d"),ret);
	//AfxMessageBox(tmp);
	if(ret==0)
	{
		ret=CloseDevice(msg);
		this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));
	}
	else
	{
		this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));
	}
	return ret;
	if(ret==0)
	{
		return S_OK;
	}
	else
	{


		return S_FALSE;
	}
}

STDMETHODIMP CCashCode::OpenDeviceEx(SHORT port)
{
	char msg[255];
	int ret=-1;
	ret=OpenDevice(port,msg);
	this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));
	if(ret==0)
	{
		return S_OK;
	}
	else
	{


		return S_FALSE;
	}
}

STDMETHODIMP CCashCode::CloseDeviceEx(void)
{
	// TODO: �ڴ����ʵ�ִ���
	char msg[255];
	int ret=-1;
	ret=CloseDevice(msg);
	this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));
	if(ret==0)
	{
		return S_OK;
	}
	else
	{


		return S_FALSE;
	}
}

STDMETHODIMP CCashCode::GetDeviceStatusEx(void)
{
	char msg[255];
	int ret=-1;
	ret=GetDeviceStatus(msg);
	this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));
	if(ret==0)
	{
		return S_OK;
	}
	else
	{


		return S_FALSE;
	}
}

STDMETHODIMP CCashCode::StopIdentifyEx(void)
{
	char msg[255];
	int ret=-1;
	ret=StopIdentify(msg);
	this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));

	if(ret==0)
	{
		return S_OK;
	}
	else
	{


		return S_FALSE;
	}
}

STDMETHODIMP CCashCode::ResetEx(void)
{
	char msg[255];
	int ret=-1;
	ret=Reset(msg);
	this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));

	if(ret==0)
	{
		return S_OK;
	}
	else
	{


		return S_FALSE;
	}
}

STDMETHODIMP CCashCode::StartIdentifyV2Ex(void)
{
	char msg[255];
	int ret=-1;
	ret=StartIdentifyV2("","",denominations,msg);
	this->put_Message(_T(_com_util::ConvertStringToBSTR(msg)));

	//return ret;
    if(ret==0)
	{
		return S_OK;
	}
	else
	{


		return S_FALSE;
	}
	
}
