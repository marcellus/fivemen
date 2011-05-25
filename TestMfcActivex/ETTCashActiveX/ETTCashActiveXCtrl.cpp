// ETTCashActiveXCtrl.cpp : CETTCashActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTCashActiveX.h"
#include "ETTCashActiveXCtrl.h"
#include "ETTCashActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTCashActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTCashActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTCashActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTCashActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTCashActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTCashActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 
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
CETTCashActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 

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
CETTCashActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTCashActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTCashActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTCashActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTCashActiveXCtrl, "LoadCashDll", dispidLoadCashDll, LoadCashDll, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashActiveXCtrl, "DestoryDll", dispidDestoryDll, DestoryDll, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTCashActiveXCtrl, "AcceptMoney", dispidAcceptMoney, AcceptMoney, VT_EMPTY, VTS_I2)
	DISP_FUNCTION_ID(CETTCashActiveXCtrl, "TestMethod", dispidTestMethod, TestMethod, VT_EMPTY, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTCashActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTCashActiveXCtrl, 1)
	PROPPAGEID(CETTCashActiveXPropPage::guid)
END_PROPPAGEIDS(CETTCashActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTCashActiveXCtrl, "ETTCASHACTIVEX.ETTCashActiveXCtrl.1",
	0x52857b7e, 0x9aeb, 0x4273, 0xb6, 0x57, 0x46, 0x41, 0xf5, 0x4d, 0xb1, 0x79)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTCashActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DETTCashActiveX =
		{ 0x9DF7813F, 0x13B1, 0x4CFC, { 0xB0, 0xD1, 0x51, 0x89, 0x40, 0x95, 0xE6, 0x2D } };
const IID BASED_CODE IID_DETTCashActiveXEvents =
		{ 0xD026003A, 0x10F7, 0x44DF, { 0xA3, 0x1D, 0xA9, 0x3A, 0x64, 0xA7, 0xA7, 0x3F } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTCashActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTCashActiveXCtrl, IDS_ETTCASHACTIVEX, _dwETTCashActiveXOleMisc)



// CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTCashActiveXCtrl ��ϵͳע�����

BOOL CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTCASHACTIVEX,
			IDB_ETTCASHACTIVEX,
			afxRegApartmentThreading,
			_dwETTCashActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// ��Ȩ�ַ���

static const TCHAR BASED_CODE _szLicFileName[] = _T("ETTCashActiveX.lic");

static const WCHAR BASED_CODE _szLicString[] =
	L"Copyright (c) 2011 ";



// CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::VerifyUserLicense -
// ����Ƿ�����û����֤

BOOL CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::VerifyUserLicense()
{
	return AfxVerifyLicFile(AfxGetInstanceHandle(), _szLicFileName,
		_szLicString);
}



// CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::GetLicenseKey -
// ��������ʱ��Ȩ��Կ

BOOL CETTCashActiveXCtrl::CETTCashActiveXCtrlFactory::GetLicenseKey(DWORD dwReserved,
	BSTR FAR* pbstrKey)
{
	if (pbstrKey == NULL)
		return FALSE;

	*pbstrKey = SysAllocString(_szLicString);
	return (*pbstrKey != NULL);
}



// CETTCashActiveXCtrl::CETTCashActiveXCtrl - ���캯��

CETTCashActiveXCtrl::CETTCashActiveXCtrl()
{
	InitializeIIDs(&IID_DETTCashActiveX, &IID_DETTCashActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTCashActiveXCtrl::~CETTCashActiveXCtrl - ��������

CETTCashActiveXCtrl::~CETTCashActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTCashActiveXCtrl::OnDraw - ��ͼ����

void CETTCashActiveXCtrl::OnDraw(
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



// CETTCashActiveXCtrl::DoPropExchange - �־���֧��

void CETTCashActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTCashActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTCashActiveXCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// �ڻ�Ͳ��״̬֮�����ת��ʱ��
	// �������»��ƿؼ���
	dwFlags |= noFlickerActivate;

	// �ؼ�ͨ������ԭ�豸�������е�
	// ԭʼ GDI ���󣬿����Ż����� OnDraw ������
	dwFlags |= canOptimizeDraw;
	return dwFlags;
}



// CETTCashActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTCashActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTCashActiveXCtrl ��Ϣ�������

void CETTCashActiveXCtrl::LoadCashDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	DLLInstPrint=LoadLibrary("BillValidator.dll");
	//AfxMessageBox("LoadLibrary -sdtapi.dll �ɹ���");
	//AfxMessageBox("LoadLibrary -WltRS.dll �ɹ���");
	if(DLLInstPrint!=NULL)
	{
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		StartIdentify=(int(__stdcall *)(const char* TraceNo, const char* UserNo, const char *EnabledDenominations, char* Message))GetProcAddress(DLLInstPrint,"StartIdentify");
		StopIdentify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"StopIdentify");
		Identify=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Identify");
		Reset=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"Reset");
	
	}
	else
	{
		AfxMessageBox("���ض�̬��BillValidator.dllʧ�ܣ�");
		exit(0);
	}

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTCashActiveXCtrl::DestoryDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	if(DLLInstPrint!=NULL)
		FreeLibrary(DLLInstPrint);

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTCashActiveXCtrl::AcceptMoney(SHORT money)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	AfxMessageBox("��ʼ����DLL");
	this->LoadCashDll();
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
	AfxMessageBox("��ʼִ��AcceptMoney");
	CString tmp;

	char msg[255];
	int ret=-1;
	ret=OpenDevice(2,msg);
	tmp.Format(_T("���豸�˿�%d���%d"),2,ret);
	AfxMessageBox(tmp);
	ret=Reset(msg);
	tmp.Format(_T("��λʶ����%d"),ret);
	AfxMessageBox(tmp);
	ret=StartIdentify("lsh","userno","1111111",msg);
	tmp.Format(_T("��ʼͶ��%d"),ret);
	AfxMessageBox(tmp);
	int all=0;
	while(true)
	{
       ret=Identify(msg);
	   //tmp.Format(_T("�Ѿ����˶���Ǯ%d"),ret);
	  // AfxMessageBox(tmp);
	   all=all+ret;
	   if(all==money)
	   {
		   AfxMessageBox("�Ѿ�������Ǯ��");
		   break;
	   }
	}

	ret=StopIdentify(msg);
	tmp.Format(_T("ֹͣʶ��%d"),ret);
	AfxMessageBox(tmp);
   
	ret=CloseDevice(msg);
	tmp.Format(_T("�ر��豸%d"),ret);
	AfxMessageBox(tmp);

     
	this->DestoryDll();

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTCashActiveXCtrl::TestMethod(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	AfxMessageBox("ִ�в��Է�����");
}
