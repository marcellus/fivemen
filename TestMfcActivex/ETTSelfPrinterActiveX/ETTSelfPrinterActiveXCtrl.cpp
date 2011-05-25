// ETTSelfPrinterActiveXCtrl.cpp : CETTSelfPrinterActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTSelfPrinterActiveX.h"
#include "ETTSelfPrinterActiveXCtrl.h"
#include "ETTSelfPrinterActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfPrinterActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTSelfPrinterActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTSelfPrinterActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTSelfPrinterActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTSelfPrinterActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTSelfPrinterActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 
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
CETTSelfPrinterActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 

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
CETTSelfPrinterActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfPrinterActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTSelfPrinterActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTSelfPrinterActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "CarPrint", dispidCarPrint, CarPrint, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "GLBM", dispidGLBM, m_GLBM, OnGLBMChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "LSH", dispidLSH, m_LSH, OnLSHChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "YWLX", dispidYWLX, m_YWLX, OnYWLXChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Owner", dispidOwner, m_Owner, OnOwnerChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Hmhp", dispidHmhp, m_Hmhp, OnHmhpChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Slrq", dispidSlrq, m_Slrq, OnSlrqChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Fee", dispidFee, m_Fee, OnFeeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Hint", dispidHint, m_Hint, OnHintChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Jszh", dispidJszh, m_Jszh, OnJszhChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Ksrq", dispidKsrq, m_Ksrq, OnKsrqChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "Yyrq", dispidYyrq, m_Yyrq, OnYyrqChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "PrinterName", dispidPrinterName, m_PrinterName, OnPrinterNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfPrinterActiveXCtrl, "MyTestMessage", dispidMyTestMessage, m_MyTestMessage, OnMyTestMessageChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "LoadReceiptDll", dispidLoadReceiptDll, LoadReceiptDll, VT_BSTR, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "LoadInvoiceDll", dispidLoadInvoiceDll, LoadInvoiceDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "SetRowDistanceEx", dispidSetRowDistanceEx, SetRowDistanceEx, VT_I2, VTS_I2)
	
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "CutPaperEx", dispidCutPaperEx, CutPaperEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "PrintLineEx2", dispidPrintLineEx2, PrintLineEx2, VT_I2, VTS_PBSTR)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "ClearAll", dispidClearAll, ClearAll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "AddString", dispidAddString, AddString, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "Test", dispidTest, Test, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfPrinterActiveXCtrl, "ShowArray", dispidShowArray, ShowArray, VT_EMPTY, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTSelfPrinterActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTSelfPrinterActiveXCtrl, 1)
	PROPPAGEID(CETTSelfPrinterActiveXPropPage::guid)
END_PROPPAGEIDS(CETTSelfPrinterActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTSelfPrinterActiveXCtrl, "ETTSELFPRINTERAC.ETTSelfPrinterAcCtrl.1",
	0x4f193682, 0x5451, 0x4cd5, 0x83, 0x40, 0x63, 0xdd, 0x4, 0xd2, 0xfa, 0xd9)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTSelfPrinterActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DETTSelfPrinterActiveX =
		{ 0xD30B98E7, 0xF1BB, 0x402D, { 0x8E, 0x60, 0x6D, 0x7F, 0xAD, 0x93, 0xF6, 0x28 } };
const IID BASED_CODE IID_DETTSelfPrinterActiveXEvents =
		{ 0x889818F0, 0x7383, 0x4B13, { 0xA1, 0x50, 0x6E, 0x77, 0x72, 0x78, 0xAB, 0xBC } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTSelfPrinterActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTSelfPrinterActiveXCtrl, IDS_ETTSELFPRINTERACTIVEX, _dwETTSelfPrinterActiveXOleMisc)



// CETTSelfPrinterActiveXCtrl::CETTSelfPrinterActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTSelfPrinterActiveXCtrl ��ϵͳע�����

BOOL CETTSelfPrinterActiveXCtrl::CETTSelfPrinterActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTSELFPRINTERACTIVEX,
			IDB_ETTSELFPRINTERACTIVEX,
			afxRegApartmentThreading,
			_dwETTSelfPrinterActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTSelfPrinterActiveXCtrl::CETTSelfPrinterActiveXCtrl - ���캯��

CETTSelfPrinterActiveXCtrl::CETTSelfPrinterActiveXCtrl()
{
	InitializeIIDs(&IID_DETTSelfPrinterActiveX, &IID_DETTSelfPrinterActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTSelfPrinterActiveXCtrl::~CETTSelfPrinterActiveXCtrl - ��������

CETTSelfPrinterActiveXCtrl::~CETTSelfPrinterActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTSelfPrinterActiveXCtrl::OnDraw - ��ͼ����

void CETTSelfPrinterActiveXCtrl::OnDraw(
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



// CETTSelfPrinterActiveXCtrl::DoPropExchange - �־���֧��

void CETTSelfPrinterActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTSelfPrinterActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTSelfPrinterActiveXCtrl::GetControlFlags()
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



// CETTSelfPrinterActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTSelfPrinterActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTSelfPrinterActiveXCtrl ��Ϣ�������

SHORT CETTSelfPrinterActiveXCtrl::CarPrint(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//AfxMessageBox((LPCTSTR)"��ʾ��Ϣ",0,0);
	this->m_CQPrint=new CQPrint();
	//AfxMessageBox((LPCTSTR)"ִ��Dialog",0,0);
	int dialogint=0;
	if(m_PrinterName.GetLength()!=0)
	{
	    dialogint=m_CQPrint->Dialog(m_PrinterName.GetBuffer(m_PrinterName.GetLength()),1);
	}
	else

	{
		dialogint=m_CQPrint->Dialog(NULL,1);
	}
	if(dialogint==-1)
	{
		return -1;
	}
	//m_CQPrint->Dialog("Microsoft Office Document Image Writer",1);
	//m_CQPrint->Dialog("\\\\192.168.1.150\\Share-Printer",1);
	//AfxMessageBox((LPCTSTR)"ִ��StartPrint",0,0);
	//CString str = new CString();
	//str.Format("%d",this->dispidPrinterName);
	//str.
	//m_CQPrint->Dialog("1",1);
	m_CQPrint->StartPrint();
	m_CQPrint->AddFontToEnvironment("����",7,16);
	m_CQPrint->SetMargins(20,20,20,20);
	m_CQPrint->SetDistance(5);
	//m_CQPrint->ActivateHF());
	int size_temp[]={5};
	m_CQPrint->SetTableColumnsSize(1,size_temp);
	//AfxMessageBox((LPCTSTR)"ִ��StartPage",0,0);
	m_CQPrint->StartPage();
	//AfxMessageBox((LPCTSTR)"ִ��SetMargins",0,0);
	
	//m_CQPrint->SetTableColumns(1);
	
	//AfxMessageBox((LPCTSTR)"ִ��AddTableRecord",0,0);
	//m_CQPrint->AddTableRecord(0,"��Ҫ���ж��룡",FORMAT_CENTER);
	//m_CQPrint->
	//m_CQPrint->Print(0,"�����м���1��",FORMAT_CENTER,0);
	m_CQPrint->Print(0,this->m_GLBM,FORMAT_CENTER,0);
    m_CQPrint->Print(0,(LPCTSTR)"����������ƾ֤",FORMAT_CENTER,0);
	CString strFormat;
	strFormat.Format("�� ˮ �ţ�%s",this->m_LSH);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
    strFormat.Format("ҵ�����ͣ�%s",this->m_YWLX);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
    strFormat.Format("�� �� �ˣ�%s",this->m_Owner);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
	strFormat.Format("������ƣ�%s",this->m_Hmhp);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
	strFormat.Format("�������ڣ�%s",this->m_Slrq);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
	strFormat.Format("�շѽ�%s",this->m_Fee);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
    strFormat.Format("������ϣ�%s",this->m_Hint);
	m_CQPrint->Print(0,strFormat,FORMAT_NORMAL,0);
	//m_CQPrint->Line(PS_DOT);

	//m_CQPrint->Print(0,"�����м���2��",FORMAT_CENTER,0);
	//m_CQPrint->Line(PS_SOLID);
	//AfxMessageBox((LPCTSTR)"ִ��EndPage",0,0);
	m_CQPrint->EndPage();
	//m_CQPrint->Print(0,"�����м���3��",FORMAT_CENTER,0);
	//AfxMessageBox((LPCTSTR)"ִ��EndPrint",0,0);
	m_CQPrint->EndPrint();

	return 0;
}

void CETTSelfPrinterActiveXCtrl::OnGLBMChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnLSHChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnYWLXChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnOwnerChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnHmhpChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnSlrqChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnFeeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnHintChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnJszhChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnKsrqChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnYyrqChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnPrinterNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfPrinterActiveXCtrl::OnMyTestMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTSelfPrinterActiveXCtrl::LoadReceiptDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	DLLInstPrint=LoadLibrary("ReceiptPrinter.dll");
	//AfxMessageBox("LoadLibrary -sdtapi.dll �ɹ���");
	//AfxMessageBox("LoadLibrary -WltRS.dll �ɹ���");
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

SHORT CETTSelfPrinterActiveXCtrl::LoadInvoiceDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	DLLInstPrint=LoadLibrary("InvoicePrinter.dll");
	//AfxMessageBox("LoadLibrary -sdtapi.dll �ɹ���");
	//AfxMessageBox("LoadLibrary -WltRS.dll �ɹ���");
	if(DLLInstPrint!=NULL)
	{
		OpenDevice=(int(__stdcall *)(int,char* message))GetProcAddress(DLLInstPrint,"OpenDevice");
		CloseDevice=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CloseDevice");
		GetDeviceStatus=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"GetDeviceStatus");
		SetRowDistance=(int(__stdcall *)(int,char* Message))GetProcAddress(DLLInstPrint,"SetRowDistance");
		PrintLine=(int(__stdcall *)(const char* print_data, char* Message))GetProcAddress(DLLInstPrint,"PrintLine");
		CutPaper=(int(__stdcall *)(char* Message))GetProcAddress(DLLInstPrint,"CutPaper");
		SetTextStyle=(int(__stdcall *)(const char *pszStyle, char* Message))GetProcAddress(DLLInstPrint,"SetTextStyle");

		SetBlackOffset=(int(__stdcall *)(int P, int L, int Q, char *Message))GetProcAddress(DLLInstPrint,"SetBlackOffset");
		BlackMarkIdentify=(int(__stdcall *)(char *Message))GetProcAddress(DLLInstPrint,"BlackMarkIdentify");
		MovePaper=(int(__stdcall *)(int Distance, char* Messagee))GetProcAddress(DLLInstPrint,"MovePaper");
	}
	else
	{
		AfxMessageBox("���ض�̬��InvoicePrinter.dllʧ�ܣ�");
		exit(0);
	}

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(DLLInstPrint!=NULL)
		FreeLibrary(DLLInstPrint);

	return 0;
}


SHORT CETTSelfPrinterActiveXCtrl::OpenDeviceEx(int port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strError;
	
	char* msg;
	int ret=OpenDevice(port,msg);
	strError.Format(_T("�򿪶˿ڽ����=%u;i_ret = %u"),port,ret);
	AfxMessageBox(strError);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	CString strError;

	char* msg;
	int ret=CloseDevice(msg);
	strError.Format(_T("�رն˿ڽ����=%u;"),ret);
	AfxMessageBox(strError);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::SetRowDistanceEx(int distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	// TODO: �ڴ���ӵ��ȴ���������
	CString strError;

	char* msg;
	int ret=SetRowDistance(distance,msg);
	strError.Format(_T("�رն˿ڽ����=%u;"),ret);
	AfxMessageBox(strError);

	return 0;
}


SHORT CETTSelfPrinterActiveXCtrl::CutPaperEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	CString strError;

	char* msg;
	int ret=CutPaper(msg);
	strError.Format(_T("��ֽ�����=%u;"),ret);
	AfxMessageBox(strError);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::PrintLineEx2(BSTR* data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
CString strError;
	char* msg;
	//char* data2 = data;
	int ret=PrintLine(msg,msg);
	strError.Format(_T("��ֽ�����=%u;"),ret);
	AfxMessageBox(strError);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::ClearAll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	this->arrStr.RemoveAll();

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::AddString(BSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	AfxMessageBox("��ʼִ��AddString");
	//CString str;
	//str.Format(_T("��������Ϊ��=%u;"),data);
	//AfxMessageBox(str);
	//this->arrStr.Add(data);

	return 0;
}

SHORT CETTSelfPrinterActiveXCtrl::Test(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	AfxMessageBox("��ʼִ��Test");

	// TODO: �ڴ���ӵ��ȴ���������
	/*CString str;
	str.Format(_T("������󳤶ȣ�=%d;"),arrStr.GetCount());
	AfxMessageBox(str);
	for (int i=0;i<arrStr.GetCount();i++)
	{
		str.Format(_T("��������Ϊ��=%u;"),arrStr.GetAt(i));
		AfxMessageBox(str);
	}
	*/

	return 0;
}

void CETTSelfPrinterActiveXCtrl::ShowArray(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	
AfxMessageBox("��ʼִ��ShowArray");
	/*CString str;
	str.Format(_T("������󳤶ȣ�=%d;"),arrStr.GetCount());
	AfxMessageBox(str);
	for (int i=0;i<arrStr.GetCount();i++)
	{
		str.Format(_T("��������Ϊ��=%u;"),arrStr.GetAt(i));
		AfxMessageBox(str);
	}
	*/

}
