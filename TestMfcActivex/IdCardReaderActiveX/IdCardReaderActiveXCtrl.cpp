// IdCardReaderActiveXCtrl.cpp : CIdCardReaderActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "IdCardReaderActiveX.h"
#include "IdCardReaderActiveXCtrl.h"
#include "IdCardReaderActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CIdCardReaderActiveXCtrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CIdCardReaderActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CIdCardReaderActiveXCtrl, COleControl)
	DISP_FUNCTION_ID(CIdCardReaderActiveXCtrl, "AboutBox", DISPID_ABOUTBOX, AboutBox, VT_EMPTY, VTS_NONE)
	
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Password", Password, VT_BSTR)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"ComPort", ComPort, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"baud", baud, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"parity", parity, VT_BSTR)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"databits", databits, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"stopbits", stopbits, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Change", Change, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Timeout", Timeout, VT_I4)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"TrackNo", TrackNo, VT_I2)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Tk_Data2", Tk_Data2, VT_BSTR)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"Tk_Data3", Tk_Data3, VT_BSTR)
	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"port", port, VT_BSTR)

	DISP_FUNCTION(CIdCardReaderActiveXCtrl, "ReadString", ReadString, VT_I2, VTS_NONE)

	DISP_PROPERTY(CIdCardReaderActiveXCtrl,"ResultStr", ResultStr, VT_BSTR)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CIdCardReaderActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CIdCardReaderActiveXCtrl, 1)
	PROPPAGEID(CIdCardReaderActiveXPropPage::guid)
END_PROPPAGEIDS(CIdCardReaderActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CIdCardReaderActiveXCtrl, "IDCARDREADERACTI.IdCardReaderActiCtrl.1",
	0xd25db37e, 0x478, 0x408c, 0x95, 0xca, 0x1e, 0x63, 0xa, 0x88, 0xca, 0xbf)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CIdCardReaderActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DIdCardReaderActiveX =
		{ 0x51F544AC, 0x51EB, 0x4BDC, { 0xBC, 0xF9, 0xBC, 0x57, 0x15, 0x3A, 0x95, 0xBB } };
const IID BASED_CODE IID_DIdCardReaderActiveXEvents =
		{ 0xEDCD5E37, 0x21B4, 0x4900, { 0x83, 0xB9, 0x6A, 0xED, 0xD9, 0x21, 0x87, 0xD4 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwIdCardReaderActiveXOleMisc =
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CIdCardReaderActiveXCtrl, IDS_IDCARDREADERACTIVEX, _dwIdCardReaderActiveXOleMisc)



// CIdCardReaderActiveXCtrl::CIdCardReaderActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CIdCardReaderActiveXCtrl ��ϵͳע�����

BOOL CIdCardReaderActiveXCtrl::CIdCardReaderActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_IDCARDREADERACTIVEX,
			IDB_IDCARDREADERACTIVEX,
			afxRegApartmentThreading,
			_dwIdCardReaderActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CIdCardReaderActiveXCtrl::CIdCardReaderActiveXCtrl - ���캯��

CIdCardReaderActiveXCtrl::CIdCardReaderActiveXCtrl()
{
	InitializeIIDs(&IID_DIdCardReaderActiveX, &IID_DIdCardReaderActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CIdCardReaderActiveXCtrl::~CIdCardReaderActiveXCtrl - ��������

CIdCardReaderActiveXCtrl::~CIdCardReaderActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CIdCardReaderActiveXCtrl::OnDraw - ��ͼ����

void CIdCardReaderActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	pdc->Ellipse(rcBounds);
}



// CIdCardReaderActiveXCtrl::DoPropExchange - �־���֧��

void CIdCardReaderActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CIdCardReaderActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CIdCardReaderActiveXCtrl::GetControlFlags()
{
	DWORD dwFlags = COleControl::GetControlFlags();


	// ���ô������ڼ��ɼ���ؼ���
	// TODO: ��д�ؼ�����Ϣ�������ʱ����ʹ��
	//		m_hWnd ��Ա����֮ǰӦ���ȼ������ֵ�Ƿ�
	//		�� null��
	dwFlags |= windowlessActivate;
	return dwFlags;
}



// CIdCardReaderActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CIdCardReaderActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CIdCardReaderActiveXCtrl::AboutBox - ���û���ʾ�����ڡ���

void CIdCardReaderActiveXCtrl::AboutBox()
{
	CDialog dlgAbout(IDD_ABOUTBOX_IDCARDREADERACTIVEX);
	dlgAbout.DoModal();
}



// CIdCardReaderActiveXCtrl ��Ϣ�������

short CIdCardReaderActiveXCtrl::ReadString() 
{
	return 0;
}
