// ETTSelfHotPrinterActiveXCtrl.cpp : CETTSelfHotPrinterActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTSelfHotPrinterActiveX.h"
#include "ETTSelfHotPrinterActiveXCtrl.h"
#include "ETTSelfHotPrinterActiveXPropPage.h"

#include <comutil.h>
#include "windows.h"
#pragma comment(lib,"comsuppw.lib")


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfHotPrinterActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTSelfHotPrinterActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTSelfHotPrinterActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTSelfHotPrinterActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTSelfHotPrinterActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTSelfHotPrinterActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 
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
CETTSelfHotPrinterActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 

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
CETTSelfHotPrinterActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfHotPrinterActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTSelfHotPrinterActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTSelfHotPrinterActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "LoadReceiptDll", dispidLoadReceiptDll, LoadReceiptDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "LoadInvoiceDll", dispidLoadInvoiceDll, LoadInvoiceDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "AddString", dispidAddString, AddString, VT_EMPTY, VTS_BSTR)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "TestArray", dispidTestArray, TestArray, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "RemoveAllString", dispidRemoveAllString, RemoveAllString, VT_EMPTY, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "PrintHot", dispidPrintHot, PrintHot, VT_EMPTY, VTS_I2 VTS_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfHotPrinterActiveXCtrl, "FontStyle", dispidFontStyle, m_FontStyle, OnFontStyleChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "GetDeviceStatusEx", dispidGetDeviceStatusEx, GetDeviceStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "SetRowDistanceEx", dispidSetRowDistanceEx, SetRowDistanceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "SetLeftDistanceEx", dispidSetLeftDistanceEx, SetLeftDistanceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "PrintLineEx", dispidPrintLineEx, PrintLineEx, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "CutPaperEx", dispidCutPaperEx, CutPaperEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "PrintBitmapNVEx", dispidPrintBitmapNVEx, PrintBitmapNVEx, VT_I2, VTS_I2 VTS_I2 VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "SetTextStyleEx", dispidSetTextStyleEx, SetTextStyleEx, VT_I2, VTS_BSTR)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "SetBlackOffsetEx", dispidSetBlackOffsetEx, SetBlackOffsetEx, VT_I2, VTS_I2 VTS_I2 VTS_I2)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "BlackMarkIdentifyEx", dispidBlackMarkIdentifyEx, BlackMarkIdentifyEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfHotPrinterActiveXCtrl, "MovePaperEx", dispidMovePaperEx, MovePaperEx, VT_I2, VTS_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfHotPrinterActiveXCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTSelfHotPrinterActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTSelfHotPrinterActiveXCtrl, 1)
	PROPPAGEID(CETTSelfHotPrinterActiveXPropPage::guid)
END_PROPPAGEIDS(CETTSelfHotPrinterActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTSelfHotPrinterActiveXCtrl, "ETTSELFHOTPRINTE.ETTSelfHotPrinteCtrl.1",
	0xcada7da3, 0x25c6, 0x43e6, 0xb5, 0xc5, 0x7a, 0x5e, 0x94, 0x9a, 0x52, 0x96)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTSelfHotPrinterActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DETTSelfHotPrinterActiveX =
		{ 0x4FE5156D, 0x91B, 0x4A4B, { 0x98, 0xA0, 0xE9, 0x85, 0x66, 0x22, 0xD7, 0xD5 } };
const IID BASED_CODE IID_DETTSelfHotPrinterActiveXEvents =
		{ 0xBBBBCF47, 0xF600, 0x4371, { 0x8D, 0xD3, 0x36, 0x41, 0xC9, 0xDA, 0x18, 0x2E } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTSelfHotPrinterActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTSelfHotPrinterActiveXCtrl, IDS_ETTSELFHOTPRINTERACTIVEX, _dwETTSelfHotPrinterActiveXOleMisc)



// CETTSelfHotPrinterActiveXCtrl::CETTSelfHotPrinterActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTSelfHotPrinterActiveXCtrl ��ϵͳע�����

BOOL CETTSelfHotPrinterActiveXCtrl::CETTSelfHotPrinterActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTSELFHOTPRINTERACTIVEX,
			IDB_ETTSELFHOTPRINTERACTIVEX,
			afxRegApartmentThreading,
			_dwETTSelfHotPrinterActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTSelfHotPrinterActiveXCtrl::CETTSelfHotPrinterActiveXCtrl - ���캯��

CETTSelfHotPrinterActiveXCtrl::CETTSelfHotPrinterActiveXCtrl()
{
	InitializeIIDs(&IID_DETTSelfHotPrinterActiveX, &IID_DETTSelfHotPrinterActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTSelfHotPrinterActiveXCtrl::~CETTSelfHotPrinterActiveXCtrl - ��������

CETTSelfHotPrinterActiveXCtrl::~CETTSelfHotPrinterActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTSelfHotPrinterActiveXCtrl::OnDraw - ��ͼ����

void CETTSelfHotPrinterActiveXCtrl::OnDraw(
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



// CETTSelfHotPrinterActiveXCtrl::DoPropExchange - �־���֧��

void CETTSelfHotPrinterActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTSelfHotPrinterActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTSelfHotPrinterActiveXCtrl::GetControlFlags()
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



// CETTSelfHotPrinterActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTSelfHotPrinterActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTSelfHotPrinterActiveXCtrl ��Ϣ�������

SHORT CETTSelfHotPrinterActiveXCtrl::LoadReceiptDll(void)
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
		this->m_Message="�ɹ�";
		return 0;
	}
	else
	{
		this->m_Message="ʧ��";
		return -1;
		AfxMessageBox("���ض�̬��ReceiptPrinter.dllʧ�ܣ�");
		exit(0);
	}


	// TODO: �ڴ���ӵ��ȴ���������
}

SHORT CETTSelfHotPrinterActiveXCtrl::LoadInvoiceDll(void)
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
		this->m_Message="�ɹ�";
		return 0;
	}
	else
	{
		this->m_Message="ʧ��";
		return -1;
		AfxMessageBox("���ض�̬��InvoicePrinter.dllʧ�ܣ�");
		exit(0);
	}

	// TODO: �ڴ���ӵ��ȴ���������
}

SHORT CETTSelfHotPrinterActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	if(DLLInstPrint!=NULL)
	{
		FreeLibrary(DLLInstPrint);
		DLLInstPrint=NULL;
		this->m_Message="�ɹ�";
		return 0;
	}
	else
	{

		this->m_Message="ʧ��";
		return -1;
	}

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTSelfHotPrinterActiveXCtrl::AddString(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//AfxMessageBox(L"��ʼִ��AddString");
	//CString str;
	//str.Format(_T("��������Ϊ��=%u;"),data);
	//AfxMessageBox(str);
	this->arrStr.Add(data);

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTSelfHotPrinterActiveXCtrl::TestArray(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	AfxMessageBox("��ʼִ��ShowArray");
	CString str;
	str.Format(_T("������󳤶ȣ�=%d;"),arrStr.GetCount());
	AfxMessageBox(str);
	for (int i=0;i<arrStr.GetCount();i++)
	{
	str.Format(_T("��������Ϊ��=%s;"),arrStr.GetAt(i));
	AfxMessageBox(str);
	}
	

	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTSelfHotPrinterActiveXCtrl::RemoveAllString(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	this->arrStr.RemoveAll();
}

void CETTSelfHotPrinterActiveXCtrl::PrintHot(SHORT port, SHORT distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	this->LoadReceiptDll();
	//char* msg="test";
	char msg[255];
	int ret=-1;
	ret=OpenDevice(port,msg);
	//CString tmp;
	//tmp.Format(_T("��������ӡ���˿�%d���%d"),port,ret);
	//AfxMessageBox(tmp);
	if(m_FontStyle.GetLength()>0)
	{
		ret=SetTextStyle(m_FontStyle,msg);
	}
	for (int i=0;i<arrStr.GetCount();i++)
	{
		ret=PrintLine(arrStr.GetAt(i),msg);
		//tmp.Format(_T("��ӡ�ַ���%u���%d"),arrStr.GetAt(i),ret);
		//AfxMessageBox(tmp);
	}
	ret=CutPaper(msg);
	//tmp.Format(_T("��ֽ���%d"),ret);
	//AfxMessageBox(tmp);
	ret=CloseDevice(msg);
	//tmp.Format(_T("�رմ�ӡ���˿ڣ����%d"),ret);
	//AfxMessageBox(tmp);
	this->DestroyDll();


	// TODO: �ڴ���ӵ��ȴ���������
}

void CETTSelfHotPrinterActiveXCtrl::OnFontStyleChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������
	

	SetModifiedFlag();
}

SHORT CETTSelfHotPrinterActiveXCtrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
   char msg[255];
   int ret=-1;
   ret=OpenDevice(port,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CloseDevice(msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::GetDeviceStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=GetDeviceStatus(msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::SetRowDistanceEx(SHORT distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=SetRowDistance(distance,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::SetLeftDistanceEx(SHORT distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=SetLeftDistance(distance,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::PrintLineEx(LPCTSTR data)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=PrintLine(data,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::CutPaperEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=CutPaper(msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::PrintBitmapNVEx(SHORT index, SHORT size, SHORT nspace)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=PrintBitmapNV(index,size,nspace,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::SetTextStyleEx(LPCTSTR style)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=SetTextStyle(style,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::SetBlackOffsetEx(SHORT P, SHORT L, SHORT Q)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=SetBlackOffset(P,L,Q,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::BlackMarkIdentifyEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=BlackMarkIdentify(msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);
	return ret;
}

SHORT CETTSelfHotPrinterActiveXCtrl::MovePaperEx(SHORT distance)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	char msg[255];
	int ret=-1;
	ret=MovePaper(distance,msg);
this->m_Message=_com_util::ConvertStringToBSTR(msg);

	return ret;
}

void CETTSelfHotPrinterActiveXCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}
