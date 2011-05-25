// ETTSelfUSBVideoActiveXCtrl.cpp : CETTSelfUSBVideoActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTSelfUSBVideoActiveX.h"
#include "ETTSelfUSBVideoActiveXCtrl.h"
#include "ETTSelfUSBVideoActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfUSBVideoActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTSelfUSBVideoActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTSelfUSBVideoActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTSelfUSBVideoActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTSelfUSBVideoActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTSelfUSBVideoActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 
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
CETTSelfUSBVideoActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 

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
CETTSelfUSBVideoActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfUSBVideoActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTSelfUSBVideoActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
	ON_WM_SIZE()
	ON_WM_CREATE()
	//ON_BN_CLICKED(IDC_Video, OnBnClickedButton1)
	//ON_BN_CLICKED(IDC_Bmp, OnBnClickedButton2)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTSelfUSBVideoActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CETTSelfUSBVideoActiveXCtrl, "BeginCapture", dispidBeginCapture, BeginCapture, VT_BSTR, VTS_I2)
	DISP_FUNCTION_ID(CETTSelfUSBVideoActiveXCtrl, "CaptureBmp", dispidCaptureBmp, CaptureBmp, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfUSBVideoActiveXCtrl, "FileName", dispidFileName, m_FileName, OnFileNameChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTSelfUSBVideoActiveXCtrl, "CaptureBmpDpi", dispidCaptureBmpDpi, CaptureBmpDpi, VT_I2, VTS_I2 VTS_I2)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTSelfUSBVideoActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTSelfUSBVideoActiveXCtrl, 1)
	PROPPAGEID(CETTSelfUSBVideoActiveXPropPage::guid)
END_PROPPAGEIDS(CETTSelfUSBVideoActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTSelfUSBVideoActiveXCtrl, "ETTSELFUSBVIDEOA.ETTSelfUSBVideoACtrl.1",
	0x7970878, 0x4c36, 0x470c, 0xac, 0xdc, 0x9a, 0xb3, 0x6f, 0xa2, 0x8, 0x4b)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTSelfUSBVideoActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DETTSelfUSBVideoActiveX =
		{ 0x922573C6, 0x1BED, 0x4891, { 0xB7, 0xB1, 0x1, 0x39, 0x5, 0x37, 0x57, 0x63 } };
const IID BASED_CODE IID_DETTSelfUSBVideoActiveXEvents =
		{ 0x5055CF7F, 0x7352, 0x4ECF, { 0xBA, 0xF3, 0x91, 0x83, 0xFF, 0x65, 0x28, 0x1E } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTSelfUSBVideoActiveXOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTSelfUSBVideoActiveXCtrl, IDS_ETTSELFUSBVIDEOACTIVEX, _dwETTSelfUSBVideoActiveXOleMisc)



// CETTSelfUSBVideoActiveXCtrl::CETTSelfUSBVideoActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTSelfUSBVideoActiveXCtrl ��ϵͳע�����

BOOL CETTSelfUSBVideoActiveXCtrl::CETTSelfUSBVideoActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTSELFUSBVIDEOACTIVEX,
			IDB_ETTSELFUSBVIDEOACTIVEX,
			afxRegApartmentThreading,
			_dwETTSelfUSBVideoActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTSelfUSBVideoActiveXCtrl::CETTSelfUSBVideoActiveXCtrl - ���캯��

CETTSelfUSBVideoActiveXCtrl::CETTSelfUSBVideoActiveXCtrl()
{
	InitializeIIDs(&IID_DETTSelfUSBVideoActiveX, &IID_DETTSelfUSBVideoActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTSelfUSBVideoActiveXCtrl::~CETTSelfUSBVideoActiveXCtrl - ��������

CETTSelfUSBVideoActiveXCtrl::~CETTSelfUSBVideoActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTSelfUSBVideoActiveXCtrl::OnDraw - ��ͼ����

void CETTSelfUSBVideoActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	//pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	//pdc->Ellipse(rcBounds);
	pdc->Rectangle(rcBounds);

	if (!IsOptimizedDraw())
	{
		// ������֧���Ż���ͼ��

		// TODO: ������κ� GDI ����ѡ�뵽�豸������ *pdc �У�
		//		���ڴ˴��ָ���ǰѡ���Ķ���
	}
}



// CETTSelfUSBVideoActiveXCtrl::DoPropExchange - �־���֧��

void CETTSelfUSBVideoActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTSelfUSBVideoActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTSelfUSBVideoActiveXCtrl::GetControlFlags()
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



// CETTSelfUSBVideoActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTSelfUSBVideoActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTSelfUSBVideoActiveXCtrl ��Ϣ�������

void CETTSelfUSBVideoActiveXCtrl::OnSize(UINT nType, int cx, int cy)
{
	COleControl::OnSize(nType, cx, cy);

	// TODO: �ڴ˴������Ϣ����������
}

int CETTSelfUSBVideoActiveXCtrl::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (COleControl::OnCreate(lpCreateStruct) == -1)
		return -1;

	// TODO:  �ڴ������ר�õĴ�������
	//m_button1.Create(_T("��ʾ��Ƶ"),WS_CHILD|WS_VISIBLE,CRect(10,210,90,240),this,IDC_Video);

	//m_button2.Create(_T("��    ͼ"),WS_CHILD|WS_VISIBLE,CRect(20,210,200,240),this,IDC_Bmp);

	return 0;
}


BSTR CETTSelfUSBVideoActiveXCtrl::BeginCapture(int iDevId)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	CString strResult;

	// TODO: Add your control notification handler code here
	//���������ƵԴ������
	//AfxMessageBox("��ʼ��ȡactivex�ؼ������");
	HWND VideoWnd=this->m_hWnd;
	CRect rect;
	this->GetClientRect(&rect);
	//AfxMessageBox("��ȡ����λ��");
	//GetDlgItem(IDC_VIDEOPLAY)->GetClientRect(&rect);
	m_Vmr.Init(iDevId,VideoWnd,rect.Width()-30,rect.Height()-40);
	//AfxMessageBox("��ʼ�������豸��");
	//GetDlgItem(IDC_Video)->EnableWindow(false);
	//GetDlgItem(IDC_Bmp)->EnableWindow(true);

	return strResult.AllocSysString();
}

SHORT CETTSelfUSBVideoActiveXCtrl::CaptureBmp(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	//AfxMessageBox("׼������bmpʧ��!");
	if(!m_Vmr.ImageCapture(this->m_FileName))
	{
		AfxMessageBox("����bmpʧ��!");
		return 0;
	}
	
	// TODO: �ڴ���ӵ��ȴ���������

	return 1;
}

void CETTSelfUSBVideoActiveXCtrl::OnFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTSelfUSBVideoActiveXCtrl::CaptureBmpDpi(SHORT xdpi, SHORT ydpi)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(!m_Vmr.ImageCaptureEx(xdpi,ydpi,this->m_FileName))
	{
		AfxMessageBox("����bmpʧ��!");
		return 0;
	}

	// TODO: �ڴ���ӵ��ȴ���������

	return 1;
}
