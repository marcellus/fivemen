// VoiceActiveXCtrl.cpp : CVoiceActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "VoiceActiveX.h"
#include "VoiceActiveXCtrl.h"
#include "VoiceActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CVoiceActiveXCtrl, COleControl)


BEGIN_INTERFACE_MAP(   CVoiceActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CVoiceActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CVoiceActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CVoiceActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CVoiceActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CVoiceActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CVoiceActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CVoiceActiveXCtrl,   ObjSafe) 
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
CVoiceActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CVoiceActiveXCtrl,   ObjSafe) 

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
CVoiceActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CVoiceActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CVoiceActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CVoiceActiveXCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CVoiceActiveXCtrl, "FileName", dispidFileName, m_FileName, OnFileNameChanged, VT_BSTR)
	DISP_FUNCTION_ID(CVoiceActiveXCtrl, "PlayVoice", dispidPlayVoice, PlayVoice, VT_EMPTY, VTS_BSTR)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CVoiceActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CVoiceActiveXCtrl, 1)
	PROPPAGEID(CVoiceActiveXPropPage::guid)
END_PROPPAGEIDS(CVoiceActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CVoiceActiveXCtrl, "VOICEACTIVEX.VoiceActiveXCtrl.1",
	0x3be2b9a6, 0xa746, 0x40ae, 0xa5, 0x4e, 0x70, 0x5e, 0xfb, 0x3c, 0x98, 0xe2)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CVoiceActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DVoiceActiveX =
		{ 0xD1742149, 0x26BE, 0x4081, { 0xAA, 0x2A, 0x5, 0x35, 0xAC, 0x92, 0xF9, 0x71 } };
const IID BASED_CODE IID_DVoiceActiveXEvents =
		{ 0x4D3FD060, 0x59E1, 0x4CF3, { 0x9B, 0x46, 0x9F, 0xFC, 0xFE, 0x48, 0x94, 0x60 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwVoiceActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CVoiceActiveXCtrl, IDS_VOICEACTIVEX, _dwVoiceActiveXOleMisc)



// CVoiceActiveXCtrl::CVoiceActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CVoiceActiveXCtrl ��ϵͳע�����

BOOL CVoiceActiveXCtrl::CVoiceActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_VOICEACTIVEX,
			IDB_VOICEACTIVEX,
			afxRegApartmentThreading,
			_dwVoiceActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CVoiceActiveXCtrl::CVoiceActiveXCtrl - ���캯��

CVoiceActiveXCtrl::CVoiceActiveXCtrl()
{
	InitializeIIDs(&IID_DVoiceActiveX, &IID_DVoiceActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CVoiceActiveXCtrl::~CVoiceActiveXCtrl - ��������

CVoiceActiveXCtrl::~CVoiceActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CVoiceActiveXCtrl::OnDraw - ��ͼ����

void CVoiceActiveXCtrl::OnDraw(
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



// CVoiceActiveXCtrl::DoPropExchange - �־���֧��

void CVoiceActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CVoiceActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CVoiceActiveXCtrl::GetControlFlags()
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



// CVoiceActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CVoiceActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CVoiceActiveXCtrl ��Ϣ�������

void CVoiceActiveXCtrl::OnFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CVoiceActiveXCtrl::PlayVoice(LPCTSTR IDR_Voice)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	//AfxMessageBox(IDR_Voice,0,0);
	//PlaySound("SystemStart",NULL,SND_ALIAS|SND_ASYNC);
	PlaySound((LPCTSTR)"C:\\123.wav",NULL,SND_ALIAS|SND_ASYNC);
	CString strErrorID;
	strErrorID.Format(_T("ErrID = %u"),GetLastError());
	AfxMessageBox(strErrorID);


	//PlaySound(MAKEINTRESOURCE(IDR_Voice),AfxGetResourceHandle(),SND_ASYNC|SND_RESOURCE|SND_NODEFAULT|SND_LOOP);
	// TODO: �ڴ���ӵ��ȴ���������
}
