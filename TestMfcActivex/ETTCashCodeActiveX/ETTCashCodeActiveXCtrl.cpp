// ETTCashCodeActiveXCtrl.cpp : CETTCashCodeActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"

#include "ETTCashCodeActiveX.h"
#include "ETTCashCodeActiveXCtrl.h"
#include "ETTCashCodeActiveXPropPage.h"

#include <comutil.h>
#include "windows.h"
#pragma comment(lib,"comsuppw.lib")



#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTCashCodeActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTCashCodeActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTCashCodeActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTCashCodeActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTCashCodeActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTCashCodeActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTCashCodeActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTCashCodeActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTCashCodeActiveXCtrl,   ObjSafe) 
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
CETTCashCodeActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashCodeActiveXCtrl,   ObjSafe) 

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
CETTCashCodeActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashCodeActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTCashCodeActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTCashCodeActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "TestMethod", dispidTestMethod, TestMethod, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "AcceptMoney", dispidAcceptMoney, AcceptMoney, VT_I2, VTS_I2 VTS_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTCashCodeActiveXCtrl, "HasAcceptMoney", dispidHasAcceptMoney, m_HasAcceptMoney, OnHasAcceptMoneyChanged, VT_I2)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "InitCashCode", dispidInitCashCode, InitCashCode, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "CloseCashCode", dispidCloseCashCode, CloseCashCode, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "IdentifyEx", dispidIdentifyEx, IdentifyEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "InitCashCodeV2", dispidInitCashCodeV2, InitCashCodeV2, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "IdentifyExV2", dispidIdentifyExV2, IdentifyExV2, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "GetDeviceStatusEx", dispidGetDeviceStatusEx, GetDeviceStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "StartIdentifyEx", dispidStartIdentifyEx, StartIdentifyEx, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "StopIdentifyEx", dispidStopIdentifyEx, StopIdentifyEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "ResetEx", dispidResetEx, ResetEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashCodeActiveXCtrl, "StartIdentifyV2Ex", dispidStartIdentifyV2Ex, StartIdentifyV2Ex, VT_I2, VTS_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTCashCodeActiveXCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTCashCodeActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTCashCodeActiveXCtrl, 1)
	PROPPAGEID(CETTCashCodeActiveXPropPage::guid)
END_PROPPAGEIDS(CETTCashCodeActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTCashCodeActiveXCtrl, "ETTCASHCODEACTIV.ETTCashCodeActivCtrl.1",
	0x5a797850, 0xbe8e, 0x4939, 0x8f, 0x6d, 0xd9, 0x39, 0x7b, 0x96, 0x37, 0x65)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTCashCodeActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DETTCashCodeActiveX =
		{ 0xD7039AD9, 0x7364, 0x4E65, { 0xBB, 0xA3, 0x9C, 0xE8, 0xDF, 0x60, 0xE9, 0x87 } };
const IID BASED_CODE IID_DETTCashCodeActiveXEvents =
		{ 0x3727E203, 0xB8F8, 0x40A9, { 0xA0, 0xA5, 0xE2, 0x68, 0xA, 0xF6, 0xA1, 0xC2 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTCashCodeActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTCashCodeActiveXCtrl, IDS_ETTCASHCODEACTIVEX, _dwETTCashCodeActiveXOleMisc)



// CETTCashCodeActiveXCtrl::CETTCashCodeActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTCashCodeActiveXCtrl ��ϵͳע�����

BOOL CETTCashCodeActiveXCtrl::CETTCashCodeActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTCASHCODEACTIVEX,
			IDB_ETTCASHCODEACTIVEX,
			afxRegApartmentThreading,
			_dwETTCashCodeActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTCashCodeActiveXCtrl::CETTCashCodeActiveXCtrl - ���캯��

CETTCashCodeActiveXCtrl::CETTCashCodeActiveXCtrl()
{
	InitializeIIDs(&IID_DETTCashCodeActiveX, &IID_DETTCashCodeActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTCashCodeActiveXCtrl::~CETTCashCodeActiveXCtrl - ��������

CETTCashCodeActiveXCtrl::~CETTCashCodeActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTCashCodeActiveXCtrl::OnDraw - ��ͼ����

void CETTCashCodeActiveXCtrl::OnDraw(
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



// CETTCashCodeActiveXCtrl::DoPropExchange - �־���֧��

void CETTCashCodeActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTCashCodeActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTCashCodeActiveXCtrl::GetControlFlags()
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



// CETTCashCodeActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTCashCodeActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTCashCodeActiveXCtrl ��Ϣ�������

void CETTCashCodeActiveXCtrl::TestMethod(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	AfxMessageBox("���Է������óɹ���");
}

SHORT CETTCashCodeActiveXCtrl::LoadDll(void)
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

SHORT CETTCashCodeActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
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

SHORT CETTCashCodeActiveXCtrl::AcceptMoney(SHORT port, SHORT money)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	//AfxMessageBox("��ʼ����DLL");
	this->LoadDll();
	/*
	OpenDevice;
	Reset;
	StartIdentify;
	while ()
	{
	Identify;
	if (Ͷ�ҽ��� && �����˳�)
	break;
	}
	StopIdentify;
	CloseDevice;
	*/
	//AfxMessageBox("��ʼִ��AcceptMoney");
	CString tmp;

	char msg[255];
	int ret=-1;
	ret=OpenDevice(port,msg);
	Sleep(200);
	//tmp.Format(_T("���豸�˿�%d���%d"),2,ret);
	//AfxMessageBox(tmp);
	ret=Reset(msg);
	Sleep(200);
	//tmp.Format(_T("��λʶ����%d"),ret);
	//AfxMessageBox(tmp);
	ret=StartIdentify("lsh","userno","1111111",msg);
	Sleep(200);
	//tmp.Format(_T("��ʼͶ��%d"),ret);
	//AfxMessageBox(tmp);
	//int all=0;
	this->m_HasAcceptMoney=0;
	ret=0;
	while(true)
	{
		if(m_HasAcceptMoney!=money)
		{
			//if(ret==0)
				ret=Identify(msg);
			//tmp.Format(_T("�Ѿ����˶���Ǯ%d"),ret);
			// AfxMessageBox(tmp);
			if(ret>0)
			{
				m_HasAcceptMoney=m_HasAcceptMoney+ret;
				//tmp.Format(_T("�Ѿ����˶���Ǯ%d"),m_HasAcceptMoney);
				//AfxMessageBox(tmp);

			}
			Sleep(200);

		}
		
		
		if(m_HasAcceptMoney==money&&Identify(msg)==0)
		{
			//AfxMessageBox("�Ѿ�������Ǯ��");
			break;
		}
		

	}

	ret=StopIdentify(msg);
	//tmp.Format(_T("ֹͣʶ��%d"),ret);
	//AfxMessageBox(tmp);

	ret=CloseDevice(msg);
	//tmp.Format(_T("�ر��豸%d"),ret);
	//AfxMessageBox(tmp);


	this->DestroyDll();

	return 0;
}

void CETTCashCodeActiveXCtrl::OnHasAcceptMoneyChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTCashCodeActiveXCtrl::InitCashCode(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	int ret=-1;
	char msg[255];
	ret=this->LoadDll();
	if(ret==0)
	{
		

		ret=OpenDevice(port,msg);
		if(ret==0)
		{
			ret=Reset(msg);
			if(ret==0)
			{
				Sleep(300);
				//tmp.Format(_T("��λʶ����%d"),ret);
				//AfxMessageBox(tmp);
				ret=StartIdentify("lsh","userno","1111111",msg);
				if(ret==0)
				{
					
				}
				
			}
			
		}
		//Sleep(100);
		//tmp.Format(_T("���豸�˿�%d���%d"),2,ret);
		//AfxMessageBox(tmp);
		

	}
	this->m_Message=_com_util::ConvertStringToBSTR(msg);
	/*
	OpenDevice;
	Reset;
	StartIdentify;
	while ()
	{
	Identify;
	if (Ͷ�ҽ��� && �����˳�)
	break;
	}
	StopIdentify;
	CloseDevice;
	*/
	//AfxMessageBox("��ʼִ��AcceptMoney");
	
	//Sleep(200);
	//tmp.Format(_T("��ʼͶ��%d"),ret);
	//AfxMessageBox(tmp);
	//int all=0;
	

	return ret;
}

SHORT CETTCashCodeActiveXCtrl::CloseCashCode(void)
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

	
	//tmp.Format(_T("�ر��豸%d"),ret);
	//AfxMessageBox(tmp);


	//this->DestroyDll();

	return ret;
}

SHORT CETTCashCodeActiveXCtrl::IdentifyEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	CString tmp;

	char msg[255];
	int ret=-1;
	ret=Identify(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCodeActiveXCtrl::InitCashCodeV2(SHORT port)
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

SHORT CETTCashCodeActiveXCtrl::IdentifyExV2(SHORT maxmoney)
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

SHORT CETTCashCodeActiveXCtrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=OpenDevice(port,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCodeActiveXCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CloseDevice(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCodeActiveXCtrl::GetDeviceStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=GetDeviceStatus(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCodeActiveXCtrl::StartIdentifyEx(LPCTSTR denominations)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StartIdentify("","",denominations,msg);
	
	this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTCashCodeActiveXCtrl::StopIdentifyEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StopIdentify(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCodeActiveXCtrl::ResetEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	char msg[255];
	int ret=-1;
	ret=Reset(msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

SHORT CETTCashCodeActiveXCtrl::StartIdentifyV2Ex(LPCTSTR denominations)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=StartIdentifyV2("","",denominations,msg);
	this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

void CETTCashCodeActiveXCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}
