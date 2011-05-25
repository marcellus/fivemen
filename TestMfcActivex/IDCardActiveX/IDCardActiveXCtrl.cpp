// IDCardActiveXCtrl.cpp : CIDCardActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "IDCardActiveX.h"
#include "IDCardActiveXCtrl.h"
#include "IDCardActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CIDCardActiveXCtrl, COleControl)

////////////////////////////////////////////////////////////////////////////
//                        ����activex��ȫ�ӿ�
////////////////////////////////////////////////////////////////////////////
BEGIN_INTERFACE_MAP(   CIDCardActiveXCtrl,   COleControl   ) 
INTERFACE_PART(CIDCardActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CIDCardActiveXCtrl::XObjSafe::AddRef() 
{ 
        METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 
        return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CIDCardActiveXCtrl::XObjSafe::Release() 
{ 
        METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 
        return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CIDCardActiveXCtrl::XObjSafe::QueryInterface( 
        REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
        METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 
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
CIDCardActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
/*   [in]   */   REFIID   riid, 
                /*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
                /*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 

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
CIDCardActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
                /*   [in]   */   REFIID   riid, 
                /*   [in]   */   DWORD   dwOptionSetMask, 
                /*   [in]   */   DWORD   dwEnabledOptions) 
{ 
        METHOD_PROLOGUE(CIDCardActiveXCtrl,   ObjSafe) 

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

////////////////////////////////////////////////////////////////////////////
//                        ����activex��ȫ�ӿ�
////////////////////////////////////////////////////////////////////////////

// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CIDCardActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CIDCardActiveXCtrl, COleControl)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CIDCardActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CIDCardActiveXCtrl, 1)
	PROPPAGEID(CIDCardActiveXPropPage::guid)
END_PROPPAGEIDS(CIDCardActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CIDCardActiveXCtrl, "IDCARDACTIVEX.IDCardActiveXCtrl.1",
	0xfd63286f, 0x7a4f, 0x4c01, 0x96, 0x5, 0x21, 0x63, 0xc1, 0xed, 0x11, 0x90)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CIDCardActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DIDCardActiveX =
		{ 0xCE963D6C, 0xDA9E, 0x4E6F, { 0xAE, 0xAC, 0x7F, 0x27, 0xF1, 0x24, 0x8D, 0xE1 } };
const IID BASED_CODE IID_DIDCardActiveXEvents =
		{ 0xF356B5E6, 0x5D6A, 0x4691, { 0xA5, 0x2C, 0x87, 0xB5, 0x23, 0xF6, 0x1, 0x73 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwIDCardActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CIDCardActiveXCtrl, IDS_IDCARDACTIVEX, _dwIDCardActiveXOleMisc)



// CIDCardActiveXCtrl::CIDCardActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CIDCardActiveXCtrl ��ϵͳע�����

BOOL CIDCardActiveXCtrl::CIDCardActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_IDCARDACTIVEX,
			IDB_IDCARDACTIVEX,
			afxRegApartmentThreading,
			_dwIDCardActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CIDCardActiveXCtrl::CIDCardActiveXCtrl - ���캯��

CIDCardActiveXCtrl::CIDCardActiveXCtrl()
{
	InitializeIIDs(&IID_DIDCardActiveX, &IID_DIDCardActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CIDCardActiveXCtrl::~CIDCardActiveXCtrl - ��������

CIDCardActiveXCtrl::~CIDCardActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CIDCardActiveXCtrl::OnDraw - ��ͼ����

void CIDCardActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CIDCardActiveXCtrl::DoPropExchange - �־���֧��

void CIDCardActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CIDCardActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CIDCardActiveXCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// ���ô������ڼ��ɼ���ؼ���
	// TODO: ��д�ؼ�����Ϣ�������ʱ����ʹ��
	//		m_hWnd ��Ա����֮ǰӦ���ȼ������ֵ�Ƿ�
	//		�� null��
	dwFlags |= windowlessActivate;
	return dwFlags;
}



// CIDCardActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CIDCardActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CIDCardActiveXCtrl ��Ϣ�������
