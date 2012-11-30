// ETTCashCtrl.cpp : CETTCashCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTCash.h"
#include "ETTCashCtrl.h"
#include "ETTCashPropPage.h"

#include "BankUtil\\Payment.h"
#include "BankUtil\\Register.h"
#include "BankUtil\\ReversalTransaction.h"

#include <comutil.h>
#include "windows.h"
#pragma comment(lib,"comsuppw.lib")

#include <tchar.h>
#include <strsafe.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

CReversalTransaction transaction;
CPayment payment;
CRegister reg;


IMPLEMENT_DYNCREATE(CETTCashCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTCashCtrl,   COleControl   ) 
	INTERFACE_PART(CETTCashCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTCashCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTCashCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTCashCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 
		return   (HRESULT)pThis-> ExternalQueryInterface(&iid,   ppvObj); 
} 

const   DWORD   dwSupportedBits   =   
INTERFACESAFE_FOR_UNTRUSTED_CALLER   | 
INTERFACESAFE_FOR_UNTRUSTED_DATA; 
const   DWORD   dwNotSupportedBits   =   ~   dwSupportedBits; 

///////////////////////////////////////////////////////////////////////////// 
//   CStopLiteCtrl::XObjSafe::GetInterfaceSafetyOptions 
//   Allows   container   to   query   what   interfaces   are   safe   for   what.   We 're 
//   optimizing   significantly   by   ignoring   which   interface   the   caller   is 
//   asking   for. 
HRESULT   STDMETHODCALLTYPE   
CETTCashCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 

		HRESULT   retval   =   ResultFromScode(S_OK); 

	//   does   interface   exist? 
	IUnknown   FAR*   punkInterface; 
	retval   =   pThis-> ExternalQueryInterface(&riid,   
		(void   *   *)&punkInterface); 
	if   (retval   !=   E_NOINTERFACE)   { //   interface   exists 
		punkInterface-> Release();   //   release   it--just   checking! 
	} 

	//   we   support   both   kinds   of   safety   and   have   always   both   set, 
	//   regardless   of   interface 
	*pdwSupportedOptions   =   *pdwEnabledOptions   =   dwSupportedBits; 

	return   retval;   //   E_NOINTERFACE   if   QI   failed 
} 

///////////////////////////////////////////////////////////////////////////// 
//   CStopLiteCtrl::XObjSafe::SetInterfaceSafetyOptions 
//   Since   we 're   always   safe,   this   is   a   no-brainer--but   we   do   check   to   make 
//   sure   the   interface   requested   exists   and   that   the   options   we 're   asked   to 
//   set   exist   and   are   set   on   (we   don 't   support   unsafe   mode). 
HRESULT   STDMETHODCALLTYPE   
CETTCashCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashCtrl,   ObjSafe) 

		//   does   interface   exist? 
		IUnknown   FAR*   punkInterface; 
	pThis-> ExternalQueryInterface(&riid,   (void   *   *)&punkInterface); 
	if   (punkInterface)   { //   interface   exists 
		punkInterface-> Release();   //   release   it--just   checking! 
	} 
	else   {   //   interface   doesn 't   exist 
		return   ResultFromScode(E_NOINTERFACE); 
	} 

	//   can 't   set   bits   we   don 't   support 
	if   (dwOptionSetMask   &   dwNotSupportedBits)   {   
		return   ResultFromScode(E_FAIL); 
	} 

	//   can 't   set   bits   we   do   support   to   zero 
	dwEnabledOptions   &=   dwSupportedBits; 
	//   (we   already   know   there   are   no   extra   bits   in   mask   ) 
	if   ((dwOptionSetMask   &   dwEnabledOptions)   != 
		dwOptionSetMask)   { 
			return   ResultFromScode(E_FAIL); 
	} 

	//   don 't   need   to   change   anything   since   we 're   always   safe 
	return   ResultFromScode(S_OK); 
}



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CETTCashCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTCashCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTCashCtrl, "HasAcceptMoney", dispidHasAcceptMoney, m_HasAcceptMoney, OnHasAcceptMoneyChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTCashCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTCashCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "InitCashCode", dispidInitCashCode, InitCashCode, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCtrl, "InitCashCodeV2", dispidInitCashCodeV2, InitCashCodeV2, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCtrl, "IdentifyExV2", dispidIdentifyExV2, IdentifyExV2, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCtrl, "CloseCashCode", dispidCloseCashCode, CloseCashCode, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "GetDeviceStatusEx", dispidGetDeviceStatusEx, GetDeviceStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "StopIdentifyEx", dispidStopIdentifyEx, StopIdentifyEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "ResetEx", dispidResetEx, ResetEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "StartIdentifyV2Ex2", dispidStartIdentifyV2Ex2, StartIdentifyV2Ex2, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTCashCtrl, "StartIdentifyV2Ex", dispidStartIdentifyV2Ex, StartIdentifyV2Ex, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTCashCtrl, "InitCreditcard", dispidInitCreditcard, InitCreditcard, VT_I2, VTS_BSTR VTS_I4 VTS_BSTR)
	DISP_FUNCTION_ID(CETTCashCtrl, "GetCreditcard", dispidGetCreditcard, GetCreditcard, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "EndCreditcard", dispidEndCreditcard, EndCreditcard, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCtrl, "LoadZTDll", dispidLoadZTDll, LoadZTDll, VT_I2, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTCashCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTCashCtrl, 1)
PROPPAGEID(CETTCashPropPage::guid)
END_PROPPAGEIDS(CETTCashCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTCashCtrl, "ETTCASH.ETTCashCtrl.1",
					   0xec8bc46b, 0x405, 0x47ca, 0xb5, 0x23, 0x3c, 0x40, 0x9f, 0xce, 0x78, 0xe2)


// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTCashCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID
const IID BASED_CODE IID_DETTCash =
{ 0xE7830902, 0xFE6B, 0x4AC0, { 0x8E, 0x15, 0xE9, 0x71, 0x2F, 0x29, 0x97, 0xF4 } };
const IID BASED_CODE IID_DETTCashEvents =
{ 0x1A65DFCC, 0x6BD4, 0x4493, { 0x8F, 0x77, 0x6B, 0x6D, 0x6F, 0x44, 0x39, 0x28 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTCashOleMisc =
OLEMISC_SETCLIENTSITEFIRST |
OLEMISC_INSIDEOUT |
OLEMISC_CANTLINKINSIDE |
OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTCashCtrl, IDS_ETTCASH, _dwETTCashOleMisc)



// CETTCashCtrl::CETTCashCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTCashCtrl ��ϵͳע�����

BOOL CETTCashCtrl::CETTCashCtrlFactory::UpdateRegistry(BOOL bRegister)
{
	// TODO: ��֤���Ŀؼ��Ƿ���ϵ�Ԫģ���̴߳������
	// �йظ�����Ϣ����ο� MFC ����˵�� 64��
	// ������Ŀؼ������ϵ�Ԫģ�͹�����
	// �����޸����´��룬��������������
	// afxRegApartmentThreading ��Ϊ 0��

	if (bRegister)
		return AfxOleRegisterControlClass(
		AfxGetInstanceHandle(),
		m_clsid,
		m_lpszProgID,
		IDS_ETTCASH,
		IDB_ETTCASH,
		afxRegApartmentThreading,
		_dwETTCashOleMisc,
		_tlid,
		_wVerMajor,
		_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTCashCtrl::CETTCashCtrl - ���캯��

CETTCashCtrl::CETTCashCtrl()
{
	InitializeIIDs(&IID_DETTCash, &IID_DETTCashEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTCashCtrl::~CETTCashCtrl - ��������

CETTCashCtrl::~CETTCashCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTCashCtrl::OnDraw - ��ͼ����

void CETTCashCtrl::OnDraw(
						  CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);

	if (!IsOptimizedDraw())
	{
		// ������֧���Ż���ͼ��

		// TODO: ������κ� GDI ����ѡ�뵽�豸������ *pdc �У�
		//		���ڴ˴��ָ���ǰѡ���Ķ���
	}
}



// CETTCashCtrl::DoPropExchange - �־���֧��

void CETTCashCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTCashCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTCashCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// ���ô������ڼ��ɼ���ؼ���
	// TODO: ��д�ؼ�����Ϣ�������ʱ����ʹ��
	//		m_hWnd ��Ա����֮ǰӦ���ȼ������ֵ�Ƿ�
	//		�� null��
	dwFlags |= windowlessActivate;

	// �ؼ�ͨ������ԭ�豸�������е�
	// ԭʼ GDI ���󣬿����Ż����� OnDraw ������
	dwFlags |= canOptimizeDraw;
	return dwFlags;
}



// CETTCashCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTCashCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTCashCtrl ��Ϣ�������

void CETTCashCtrl::OnHasAcceptMoneyChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTCashCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTCashCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	if(DLLInstPrint==NULL)
	{

		// AfxMessageBox("���ض�̬��BillValidator.dll��");
		DLLInstPrint=LoadLibrary("BillValidator.dll");
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
		this->m_Message="�ɹ�";


	}
	else
	{
		this->m_Message="ʧ��";
		AfxMessageBox("���ض�̬��BillValidator.dllʧ�ܣ�");

		exit(0);
	}



	return 0;
}

SHORT CETTCashCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(g_598Dll != NULL)
	{
		FreeLibrary(g_598Dll);
		g_598Dll = NULL;
		m_Message = "�ɹ�";
	}

	if(DLLInstPrint!=NULL)
	{
		//AfxMessageBox("�ͷ�DLL��");
		FreeLibrary(DLLInstPrint);
		DLLInstPrint=NULL;
		this->m_Message="�ɹ�";
	}
	else
	{
		this->m_Message="ʧ��";
	}

	return 0;
}

SHORT CETTCashCtrl::InitCashCode(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������

	return 0;
}

SHORT CETTCashCtrl::InitCashCodeV2(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	int ret=-1;
	try
	{
		this->LoadDll();
		//AfxMessageBox("��ʼִ��InitCashCodeV2");
		//Sleep(1000);
		CString tmp;

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
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
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

SHORT CETTCashCtrl::IdentifyExV2(SHORT maxmoney)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	CString tmp;

	char msg[255];
	int ret=-1;
	ret=IdentifyV2(maxmoney,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);


	return ret;
}

SHORT CETTCashCtrl::CloseCashCode(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString tmp;

	char msg[255];
	int ret=-1;

	ret=StopIdentify(msg);
	//tmp.Format(_T("ֹͣʶ��%d"),ret);
	//AfxMessageBox(tmp);
	if(ret==0)
	{
		ret=CloseDevice(msg);
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}
	else
	{
		this->m_Message=_com_util::ConvertStringToBSTR(msg);
	}
	return ret;
}

SHORT CETTCashCtrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=OpenDevice(port,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CloseDevice(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::GetDeviceStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=GetDeviceStatus(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::StopIdentifyEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StopIdentify(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::ResetEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=Reset(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::StartIdentifyV2Ex2(LPCTSTR denominations)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StartIdentifyV2("","",denominations,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCtrl::StartIdentifyV2Ex(LPCTSTR denominations)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StartIdentifyV2("","",denominations,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}


DWORD WINAPI MyThreadFunction( LPVOID lpParam ) 
{ 
	PMYDATA pDataArray;

	// Cast the parameter to the correct data type.
	// The pointer is known to be valid because 
	// it was checked for NULL before the thread was created.
	pDataArray = (PMYDATA)lpParam;

	int result = payment.SendPaymentData(pDataArray->sfxmbm,pDataArray->money,pDataArray->bz);

	return 0; 
} 

void ErrorHandler(LPTSTR lpszFunction) 
{ 
	// Retrieve the system error message for the last-error code.
	LPVOID lpMsgBuf;
	LPVOID lpDisplayBuf;
	DWORD dw = GetLastError(); 

	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER | 
		FORMAT_MESSAGE_FROM_SYSTEM |
		FORMAT_MESSAGE_IGNORE_INSERTS,
		NULL,
		dw,
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		(LPTSTR) &lpMsgBuf,
		0, NULL );

	// Display the error message.

	lpDisplayBuf = (LPVOID)LocalAlloc(LMEM_ZEROINIT, 
		(lstrlen((LPCTSTR) lpMsgBuf) + lstrlen((LPCTSTR) lpszFunction) + 40) * sizeof(TCHAR)); 
	StringCchPrintf((LPTSTR)lpDisplayBuf, 
		LocalSize(lpDisplayBuf) / sizeof(TCHAR),
		TEXT("%s failed with error %d: %s"), 
		lpszFunction, dw, lpMsgBuf); 
	//MessageBox(NULL, (LPCTSTR) lpDisplayBuf, TEXT("Error"), MB_OK); 

	// Free error-handling buffer allocations.
	LocalFree(lpMsgBuf);
	LocalFree(lpDisplayBuf);
}


SHORT CETTCashCtrl::InitCreditcard(LPCTSTR sfxmbm, LONG money, LPCTSTR bz)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if( LoadZTDll()!= 0) return -1;//���ض�̬��ʧ��

	pData = (PMYDATA) HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY,sizeof(MYDATA));

	if( pData == NULL )
	{
		ExitProcess(2);
		return -1;
	}

	// Generate unique data for each thread to work with.
	pData->sfxmbm = sfxmbm;
	pData->money = money;
	pData->bz = bz;

	// Create the thread to begin execution on its own.
	hThread = CreateThread( 
		NULL,                   // default security attributes
		0,                      // use default stack size  
		MyThreadFunction,       // thread function name
		pData,          // argument to thread function 
		0,                      // use default creation flags 
		&dwThreadId);   // returns the thread identifier 

	if (hThread == NULL) 
	{
		ErrorHandler(TEXT("CreateThread"));
		ExitProcess(3);
		return -1;
	}

	int ret=1;
	this->m_Message="��ʼ��ˢ���ɹ�";
	return ret;
}

LPCTSTR CETTCashCtrl::GetCreditcard(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	this->m_Message="���ˢ������";

	return payment.GetInputState();
}

SHORT CETTCashCtrl::EndCreditcard(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	payment.ReleaseResource();//�ͷ���Դ������

	// Wait until all threads have terminated.
	WaitForMultipleObjects(1, (const HANDLE *)hThread, TRUE, 5000/*INFINITE*/);

	// Close all thread handles and free memory allocations.
	CloseHandle(hThread);
	if(pData != NULL)
	{
		HeapFree(GetProcessHeap(), 0, pData);
		pData = NULL;    // Ensure address is not reused.
	}

	int ret=1;
	this->m_Message="����ˢ���ɹ�";
	return ret;
}

SHORT CETTCashCtrl::LoadZTDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if( g_598Dll == NULL )
		g_598Dll = LoadLibrary("ZT_EPP_API.dll");

	if( g_598Dll==NULL)
	{
		return -1;//�������ӿ�ʧ��
	}
	else
	{
		TCHAR szCurPath[MAX_PATH];
		GetCurrentDirectory(sizeof(szCurPath),szCurPath);
		_tcscat(szCurPath,TEXT("\\Config.ini"));
		CString szDate = TEXT("");
		DWORD dwSize = 1024;

		GetPrivateProfileString(TEXT("Register"),TEXT("Date"),TEXT("20121122"),
			szDate.GetBuffer(dwSize),dwSize,szCurPath);
		szDate.ReleaseBuffer();
		char cDate[9] = {'\0'};
		SYSTEMTIME t;
		GetLocalTime(&t);
		_snprintf(cDate, 9, "%04d%02d%02d",t.wYear, t.wMonth, t.wDay);
		if( strcmp(szDate,cDate) != 0)
		{//ÿ��ǩ��
			CRegister reg;
			if( reg.SendRegisterData() == 0)
			{
				WritePrivateProfileString(TEXT("Register"),TEXT("Date"),cDate,szCurPath);
			}
		}

		ZT_EPP_OpenCom  = (short (__stdcall* )(short,long))GetProcAddress(g_598Dll,"ZT_EPP_OpenCom");
		ZT_EPP_CloseCom = (short (__stdcall* )())GetProcAddress(g_598Dll,"ZT_EPP_CloseCom");
		ZT_EPP_PinReadVersion = (short(__stdcall* )(char *,char *,char *))GetProcAddress(g_598Dll,"ZT_EPP_PinReadVersion");
		ZT_EPP_PinLoadMasterKey = (short (__stdcall* )(int , short ,unsigned char *, char *))GetProcAddress(g_598Dll,"ZT_EPP_PinLoadMasterKey");
		ZT_EPP_PinLoadWorkKey = (short (__stdcall* )( int , short, short, unsigned char *, char * ))GetProcAddress(g_598Dll,"ZT_EPP_PinLoadWorkKey");
		ZT_EPP_TerminalNum = (short (__stdcall*)(char *,char *))GetProcAddress(g_598Dll,"ZT_EPP_TerminalNum");
		ZT_EPP_SetDesPara = (short (__stdcall* )(short ,short))GetProcAddress(g_598Dll,"ZT_EPP_SetDesPara");
		ZT_EPP_Des = (short (__stdcall* )(char *,char *,char *))GetProcAddress(g_598Dll,"ZT_EPP_Des");
		ZT_EPP_ActivWorkPin = (short (__stdcall* )(short ,short))GetProcAddress(g_598Dll,"ZT_EPP_ActivWorkPin");
		ZT_EPP_PinStartAdd = (short (__stdcall* )(short,short,short,short,short))GetProcAddress(g_598Dll,"ZT_EPP_PinStartAdd");
		ZT_EPP_OpenKeyVoic = (short (__stdcall* )(short))GetProcAddress(g_598Dll,"ZT_EPP_OpenKeyVoic");
		ZT_EPP_PinLoadCardNo=(short (__stdcall* )(char *))GetProcAddress(g_598Dll,"ZT_EPP_PinLoadCardNo");
		ZT_EPP_PinReportPressed = (short (__stdcall* )( char *, int ))GetProcAddress(g_598Dll,"ZT_EPP_PinReportPressed");
		ZT_EPP_PinReadPin = (short (__stdcall* )(int,unsigned char *))GetProcAddress(g_598Dll,"ZT_EPP_PinReadPin");
		ZT_EPP_DllSplitBcd = (void (__stdcall* )(unsigned char *,unsigned char *,int))GetProcAddress(g_598Dll,"ZT_EPP_DllSplitBcd");
		ZT_EPP_Undes = (short (__stdcall* )(char *,char *,char *))GetProcAddress(g_598Dll,"ZT_EPP_Undes");
		ZT_EPP_PinCalMAC = (short(__stdcall* )( int, int, char *,char *))GetProcAddress(g_598Dll,"ZT_EPP_PinCalMAC");
		ZT_EPP_PinAdd = (short (__stdcall* )(int ,int, char *, char *))GetProcAddress(g_598Dll,"ZT_EPP_PinAdd");
		ZT_EPP_PinUnAdd = (short (__stdcall* )(int,int,char *,char *))GetProcAddress(g_598Dll,"ZT_EPP_PinUnAdd");
		ZT_EPP_PinInitialization = (short (__stdcall* )( int ))GetProcAddress(g_598Dll,"ZT_EPP_PinInitialization");
		ZT_EPP_ICOnPower = (short (__stdcall* )( char * ))GetProcAddress(g_598Dll,"ZT_EPP_ICOnPower");
		ZT_EPP_ICDownPower = (short (__stdcall* )())GetProcAddress(g_598Dll,"ZT_EPP_ICDownPower");
		ZT_EPP_ICControl = (short (__stdcall* )(char *,char *))GetProcAddress(g_598Dll,"ZT_EPP_ICControl");
		ZT_EPP_SetICType = (short (__stdcall* )( int, int ))GetProcAddress(g_598Dll,"ZT_EPP_SetICType");
		ZT_EPP_ReadICType = (short (__stdcall* )( int, char * ))GetProcAddress(g_598Dll,"ZT_EPP_ReadICType");
	}
	return 0;
}
