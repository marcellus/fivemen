// USBVideoActiveXCtrl.cpp : CUSBVideoActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "USBVideoActiveX.h"
#include "USBVideoActiveXCtrl.h"
#include "USBVideoActiveXPropPage.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CUSBVideoActiveXCtrl, COleControl)



// ��Ϣӳ��

BEGIN_MESSAGE_MAP(CUSBVideoActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
	ON_WM_CREATE()
	ON_BN_CLICKED(1, OnBnClickedButton1)
	ON_BN_CLICKED(2, OnBnClickedButton2)
	//ON_WM_SIZE()
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CUSBVideoActiveXCtrl, COleControl)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CUSBVideoActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CUSBVideoActiveXCtrl, 1)
	PROPPAGEID(CUSBVideoActiveXPropPage::guid)
END_PROPPAGEIDS(CUSBVideoActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CUSBVideoActiveXCtrl, "USBVIDEOACTIVEX.USBVideoActiveXCtrl.1",
	0x1009cfdd, 0xfda, 0x4e6f, 0x8a, 0xac, 0xaa, 0x3f, 0x38, 0x15, 0x52, 0x21)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CUSBVideoActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DUSBVideoActiveX =
		{ 0x99D458C9, 0x4608, 0x4ED5, { 0xAE, 0xE7, 0x43, 0xCB, 0x5B, 0x82, 0x10, 0xFE } };
const IID BASED_CODE IID_DUSBVideoActiveXEvents =
		{ 0xA0A6C942, 0x950D, 0x40CD, { 0xBE, 0x76, 0x1E, 0x69, 0x36, 0x2D, 0x29, 0x41 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwUSBVideoActiveXOleMisc =
	OLEMISC_SIMPLEFRAME |
	OLEMISC_ACTIVATEWHENVISIBLE |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CUSBVideoActiveXCtrl, IDS_USBVIDEOACTIVEX, _dwUSBVideoActiveXOleMisc)



// CUSBVideoActiveXCtrl::CUSBVideoActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CUSBVideoActiveXCtrl ��ϵͳע�����

BOOL CUSBVideoActiveXCtrl::CUSBVideoActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_USBVIDEOACTIVEX,
			IDB_USBVIDEOACTIVEX,
			afxRegApartmentThreading,
			_dwUSBVideoActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CUSBVideoActiveXCtrl::CUSBVideoActiveXCtrl - ���캯��

CUSBVideoActiveXCtrl::CUSBVideoActiveXCtrl()
{
	InitializeIIDs(&IID_DUSBVideoActiveX, &IID_DUSBVideoActiveXEvents);

	EnableSimpleFrame();
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CUSBVideoActiveXCtrl::~CUSBVideoActiveXCtrl - ��������

CUSBVideoActiveXCtrl::~CUSBVideoActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CUSBVideoActiveXCtrl::OnDraw - ��ͼ����

void CUSBVideoActiveXCtrl::OnDraw(
			CDC* pdc, const CRect& rcBounds, const CRect& rcInvalid)
{
	if (!pdc)
		return;

	// TODO: �����Լ��Ļ�ͼ�����滻����Ĵ��롣
	//pdc->FillRect(rcBounds, CBrush::FromHandle((HBRUSH)GetStockObject(WHITE_BRUSH)));
	//pdc->Ellipse(rcBounds);
	//pdc->DrawText()
	pdc->Rectangle(rcBounds);

	if (!IsOptimizedDraw())
	{
		// ������֧���Ż���ͼ��

		// TODO: ������κ� GDI ����ѡ�뵽�豸������ *pdc �У�
		//		���ڴ˴��ָ���ǰѡ���Ķ���
	}
}



// CUSBVideoActiveXCtrl::DoPropExchange - �־���֧��

void CUSBVideoActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CUSBVideoActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CUSBVideoActiveXCtrl::GetControlFlags()
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



// CUSBVideoActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CUSBVideoActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}


void CUSBVideoActiveXCtrl::OnBnClickedButton1()
{
	AfxMessageBox(_T("��ʾ��Ƶ!"));
	
}

void CUSBVideoActiveXCtrl::OnBnClickedButton2()
{
	AfxMessageBox(_T("��ʼ��ͼ!"));

	//GetDlgItem(1)->EnableWindow(false);
}


// CUSBVideoActiveXCtrl ��Ϣ�������

int CUSBVideoActiveXCtrl::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (COleControl::OnCreate(lpCreateStruct) == -1)
		return -1;
   
m_button1.Create(_T("��ʾ��Ƶ"),WS_CHILD|WS_VISIBLE,CRect(10,10,50,30),this,1);
	//m_button1.Create(_T("��ʾ��Ƶ"),WS_CHILD|WS_VISIBLE,CRect(10,210,110,30),this,1);

	m_button2.Create(_T("��    ͼ"),WS_CHILD|WS_VISIBLE,CRect(80,10,110,30),this,2);
	AfxMessageBox(L"�����ؼ���ɣ�");

	// TODO:  �ڴ������ר�õĴ�������

	return 0;
}

void CUSBVideoActiveXCtrl::OnSize(UINT nType, int cx, int cy)
{
	COleControl::OnSize(nType, cx, cy);

	// TODO: �ڴ˴������Ϣ����������
}
