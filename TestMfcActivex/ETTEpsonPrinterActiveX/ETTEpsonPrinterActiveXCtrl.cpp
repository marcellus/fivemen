// ETTEpsonPrinterActiveXCtrl.cpp : CETTEpsonPrinterActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTEpsonPrinterActiveX.h"
#include "ETTEpsonPrinterActiveXCtrl.h"
#include "ETTEpsonPrinterActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTEpsonPrinterActiveXCtrl, COleControl)


BEGIN_INTERFACE_MAP(   CETTEpsonPrinterActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTEpsonPrinterActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTEpsonPrinterActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTEpsonPrinterActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTEpsonPrinterActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 
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
CETTEpsonPrinterActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 

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
CETTEpsonPrinterActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTEpsonPrinterActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTEpsonPrinterActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTEpsonPrinterActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "AddString", dispidAddString, AddString, VT_EMPTY, VTS_BSTR)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "RemoveAllString", dispidRemoveAllString, RemoveAllString, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "TestMethod", dispidTestMethod, TestMethod, VT_EMPTY, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTEpsonPrinterActiveXCtrl, "PrinterName", dispidPrinterName, m_PrinterName, OnPrinterNameChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTEpsonPrinterActiveXCtrl, "PrinterPort", dispidPrinterPort, PrinterPort, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTEpsonPrinterActiveXCtrl, "Port", dispidPort, m_Port, OnPortChanged, VT_I2)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTEpsonPrinterActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTEpsonPrinterActiveXCtrl, 1)
	PROPPAGEID(CETTEpsonPrinterActiveXPropPage::guid)
END_PROPPAGEIDS(CETTEpsonPrinterActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTEpsonPrinterActiveXCtrl, "ETTEPSONPRINTERA.ETTEpsonPrinterACtrl.1",
	0x55f3ec13, 0x28ab, 0x469e, 0x98, 0xde, 0x82, 0xe8, 0x62, 0x70, 0x3f, 0xc0)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTEpsonPrinterActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DETTEpsonPrinterActiveX =
		{ 0xB6C5706, 0xC674, 0x4856, { 0xA3, 0x42, 0x84, 0x5A, 0x5E, 0x1F, 0xE5, 0x5A } };
const IID BASED_CODE IID_DETTEpsonPrinterActiveXEvents =
		{ 0x7BD881A4, 0x9BCF, 0x4F89, { 0x8B, 0xCF, 0x9, 0x5D, 0x16, 0xF, 0x28, 0x1 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTEpsonPrinterActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTEpsonPrinterActiveXCtrl, IDS_ETTEPSONPRINTERACTIVEX, _dwETTEpsonPrinterActiveXOleMisc)



// CETTEpsonPrinterActiveXCtrl::CETTEpsonPrinterActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTEpsonPrinterActiveXCtrl ��ϵͳע�����

BOOL CETTEpsonPrinterActiveXCtrl::CETTEpsonPrinterActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTEPSONPRINTERACTIVEX,
			IDB_ETTEPSONPRINTERACTIVEX,
			afxRegApartmentThreading,
			_dwETTEpsonPrinterActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTEpsonPrinterActiveXCtrl::CETTEpsonPrinterActiveXCtrl - ���캯��

CETTEpsonPrinterActiveXCtrl::CETTEpsonPrinterActiveXCtrl()
{
	InitializeIIDs(&IID_DETTEpsonPrinterActiveX, &IID_DETTEpsonPrinterActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTEpsonPrinterActiveXCtrl::~CETTEpsonPrinterActiveXCtrl - ��������

CETTEpsonPrinterActiveXCtrl::~CETTEpsonPrinterActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTEpsonPrinterActiveXCtrl::OnDraw - ��ͼ����

void CETTEpsonPrinterActiveXCtrl::OnDraw(
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



// CETTEpsonPrinterActiveXCtrl::DoPropExchange - �־���֧��

void CETTEpsonPrinterActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTEpsonPrinterActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTEpsonPrinterActiveXCtrl::GetControlFlags()
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



// CETTEpsonPrinterActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTEpsonPrinterActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTEpsonPrinterActiveXCtrl ��Ϣ�������

SHORT CETTEpsonPrinterActiveXCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	DLLInstPrint=LoadLibrary("ReceiptPrinter.dll");
	if(DLLInstPrint!=NULL)
	{
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		SetRowDistance=(int(__stdcall *)(int,char* Message))GetProcAddress(DLLInstPrint,"SetRowDistance");
		PrintLine=(int(__stdcall *)(const char* print_data, char* Message))GetProcAddress(DLLInstPrint,"PrintLine");
		CutPaper=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CutPaper");
		SetTextStyle=(int(__stdcall *)(const char *pszStyle, char* Message))GetProcAddress(DLLInstPrint,"SetTextStyle");

		SetLeftDistance=(int(__stdcall *)(int distance, char* Message))GetProcAddress(DLLInstPrint,"SetLeftDistance");
		PrintBitmapNV=(int(__stdcall *)(int index, int size, int nSpace, char* Message))GetProcAddress(DLLInstPrint,"PrintBitmapNV");
	}
	else
	{
		AfxMessageBox("���ض�̬��ReceiptPrinter.dllʧ�ܣ�");
		exit(0);
	}

	return 0;
}

SHORT CETTEpsonPrinterActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	if(DLLInstPrint!=NULL)
		FreeLibrary(DLLInstPrint);

	return 0;
}

void CETTEpsonPrinterActiveXCtrl::AddString(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	this->arrStr.Add(data);
}

void CETTEpsonPrinterActiveXCtrl::RemoveAllString(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	this->arrStr.RemoveAll();
}

void CETTEpsonPrinterActiveXCtrl::TestMethod(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	AfxMessageBox("��ʼִ��ShowArray");
	CString str;
	str.Format(_T("������󳤶ȣ�=%d;"),arrStr.GetCount());
	AfxMessageBox(str);
	for (int i=0;i<arrStr.GetCount();i++)
	{
		str.Format(_T("��������Ϊ��=%s;"),arrStr.GetAt(i));
		AfxMessageBox(str);
	}
}

void CETTEpsonPrinterActiveXCtrl::OnPrinterNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTEpsonPrinterActiveXCtrl::PrinterPort(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	this->m_CQPrint->Dialog(this->m_PrinterName.GetBuffer(),1);
	HPRIVATEFONT font=this->m_CQPrint->AddFontToEnvironment("����_GB2312",10,16);
	this->m_CQPrint->StartPrint();
	this->m_CQPrint->StartPage();
	
	for (int i=0;i<arrStr.GetCount();i++)
	{
		this->m_CQPrint->Print(font,arrStr.GetAt(i),FORMAT_NORMAL,0);
	}

	this->m_CQPrint->EndPage();
	this->m_CQPrint->EndPrint();

	return 0;
}

void CETTEpsonPrinterActiveXCtrl::OnPortChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}
