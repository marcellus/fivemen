// CashCode.cpp : CCashCode 的实现

#include "stdafx.h"
#include "CashCode.h"

#include <comutil.h>
#include "windows.h"
#pragma comment(lib,"comsuppw.lib")


// CCashCode


STDMETHODIMP CCashCode::get_HasAcceptMoney(SHORT* pVal)
{
	// TODO: 在此添加实现代码

	return S_OK;
}

STDMETHODIMP CCashCode::put_HasAcceptMoney(SHORT newVal)
{
	// TODO: 在此添加实现代码

	return S_OK;
}

STDMETHODIMP CCashCode::get_Message(BSTR* pVal)
{
	// TODO: 在此添加实现代码

	return S_OK;
}

STDMETHODIMP CCashCode::put_Message(BSTR newVal)
{
	// TODO: 在此添加实现代码

	return S_OK;
}

STDMETHODIMP CCashCode::LoadDll(void)
{
	// TODO: 在此添加调度处理程序代码
	if(DLLInstPrint==NULL)
	{

		// AfxMessageBox("加载动态库BillValidator.dll！");
		DLLInstPrint=LoadLibrary(_T("BillValidator.dll"));
	}
	else
	{
		// AfxMessageBox("已经存在动态库BillValidator.dll！");
	}

	//AfxMessageBox("LoadLibrary -sdtapi.dll 成功！");
	//AfxMessageBox("LoadLibrary -WltRS.dll 成功！");
	if(DLLInstPrint!=NULL)
	{
		//AfxMessageBox("从动态库中获取函数！");
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		StartIdentify=(int(__stdcall *)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message))GetProcAddress(DLLInstPrint,"StartIdentify");

		StartIdentifyV2=(int(__stdcall *)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message))GetProcAddress(DLLInstPrint,"StartIdentifyV2");

		StopIdentify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"StopIdentify");
		Identify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Identify");

		IdentifyV2=(int(__stdcall *)(int,char* Message))GetProcAddress(DLLInstPrint,"IdentifyV2");

		Reset=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Reset");
		this->put_Message(_T("成功"));


	}
	else
	{
	    this->put_Message(_T("失败"));
		//AfxMessageBox("加载动态库BillValidator.dll失败！");

		exit(0);
		return S_FALSE;
	}

	return S_OK;
}

STDMETHODIMP CCashCode::DestroyDll(void)
{
	if(DLLInstPrint!=NULL)
	{
		//AfxMessageBox("释放DLL！");
		FreeLibrary(DLLInstPrint);
		DLLInstPrint=NULL;
		this->put_Message(_T("成功"));
	}
	else
	{
		this->put_Message(_T("失败"));
		return S_FALSE;
	}

	

	return S_OK;
}

STDMETHODIMP CCashCode::InitCashCode(SHORT port)
{
	// TODO: 在此添加实现代码

	return S_OK;
}

STDMETHODIMP CCashCode::InitCashCodeV2(SHORT port)
{
	int ret=-1;
	try
	{


		this->LoadDll();
		//AfxMessageBox("开始执行InitCashCodeV2");
		//Sleep(1000);
		//CString tmp;

		char msg[255];
		//AfxMessageBox("准备打开纸币端口2");

		ret=OpenDevice(port,msg);
		//ret=OpenDevice(2,msg);
		//Sleep(100);
		//tmp.Format(_T("打开设备端口%d结果%d"),2,ret);
		//AfxMessageBox(tmp);
		ret=Reset(msg);
		Sleep(100);
		//tmp.Format(_T("复位识别器%d"),ret);
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
	//tmp.Format(_T("停止识币%d"),ret);
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
	// TODO: 在此添加实现代码
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
