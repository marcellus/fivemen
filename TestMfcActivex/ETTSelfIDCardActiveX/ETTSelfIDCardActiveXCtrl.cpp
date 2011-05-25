// ETTSelfIDCardActiveXCtrl.cpp : CETTSelfIDCardActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTSelfIDCardActiveX.h"
#include "ETTSelfIDCardActiveXCtrl.h"
#include "ETTSelfIDCardActiveXPropPage.h"




#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTSelfIDCardActiveXCtrl, COleControl)
BEGIN_INTERFACE_MAP(   CETTSelfIDCardActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTSelfIDCardActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTSelfIDCardActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTSelfIDCardActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTSelfIDCardActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 
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
CETTSelfIDCardActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 

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
CETTSelfIDCardActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTSelfIDCardActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTSelfIDCardActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTSelfIDCardActiveXCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "IsReaded", dispidIsReaded, m_IsReaded, OnIsReadedChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "Name", dispidName, m_Name, OnNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "SexCode", dispidSexCode, m_SexCode, OnSexCodeChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "SexName", dispidSexName, m_SexName, OnSexNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "IDCard", dispidIDCard, m_IDCard, OnIDCardChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "NationCode", dispidNationCode, m_NationCode, OnNationCodeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "NationName", dispidNationName, m_NationName, OnNationNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "Birth", dispidBirth, m_Birth, OnBirthChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "Address", dispidAddress, m_Address, OnAddressChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "Fzjg", dispidFzjg, m_Fzjg, OnFzjgChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "StartDate", dispidStartDate, m_StartDate, OnStartDateChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "EndDate", dispidEndDate, m_EndDate, OnEndDateChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "YxqxCode", dispidYxqxCode, m_YxqxCode, OnYxqxCodeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "YxqxName", dispidYxqxName, m_YxqxName, OnYxqxNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "ImagePath", dispidImagePath, m_ImagePath, OnImagePathChanged, VT_UI1)
	DISP_FUNCTION_ID(CETTSelfIDCardActiveXCtrl, "ReadIDCard", dispidReadIDCard, ReadIDCard, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "IsUseCom", dispidIsUseCom, m_IsUseCom, OnIsUseComChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "HasLoadLib", dispidHasLoadLib, m_HasLoadLib, OnHasLoadLibChanged, VT_I2)
	DISP_FUNCTION_ID(CETTSelfIDCardActiveXCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTSelfIDCardActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTSelfIDCardActiveXCtrl, "ReadTick", dispidReadTick, m_ReadTick, OnReadTickChanged, VT_I2)
	DISP_FUNCTION_ID(CETTSelfIDCardActiveXCtrl, "ReadFromFile", dispidReadFromFile, ReadFromFile, VT_BSTR, VTS_BSTR)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTSelfIDCardActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTSelfIDCardActiveXCtrl, 1)
PROPPAGEID(CETTSelfIDCardActiveXPropPage::guid)
END_PROPPAGEIDS(CETTSelfIDCardActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTSelfIDCardActiveXCtrl, "ETTSELFIDCARDACT.ETTSelfIDCardActCtrl.1",
					   0x447c4906, 0x6678, 0x461b, 0x9e, 0x20, 0x10, 0xb, 0xde, 0x91, 0x38, 0x28)



					   // ����� ID �Ͱ汾

					   IMPLEMENT_OLETYPELIB(CETTSelfIDCardActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



					   // �ӿ� ID

					   const IID BASED_CODE IID_DETTSelfIDCardActiveX =
{ 0xBC755F0E, 0x4F1C, 0x46A2, { 0x8C, 0x10, 0x97, 0xE3, 0x64, 0x97, 0x48, 0x65 } };
const IID BASED_CODE IID_DETTSelfIDCardActiveXEvents =
{ 0x97A9E85, 0xC96F, 0x4B0F, { 0xB4, 0x94, 0x8D, 0x90, 0x6D, 0x13, 0xE2, 0xEB } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTSelfIDCardActiveXOleMisc =
OLEMISC_INVISIBLEATRUNTIME |
OLEMISC_SETCLIENTSITEFIRST |
OLEMISC_INSIDEOUT |
OLEMISC_CANTLINKINSIDE |
OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTSelfIDCardActiveXCtrl, IDS_ETTSELFIDCARDACTIVEX, _dwETTSelfIDCardActiveXOleMisc)



// CETTSelfIDCardActiveXCtrl::CETTSelfIDCardActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTSelfIDCardActiveXCtrl ��ϵͳע�����

BOOL CETTSelfIDCardActiveXCtrl::CETTSelfIDCardActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
		IDS_ETTSELFIDCARDACTIVEX,
		IDB_ETTSELFIDCARDACTIVEX,
		afxRegApartmentThreading,
		_dwETTSelfIDCardActiveXOleMisc,
		_tlid,
		_wVerMajor,
		_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTSelfIDCardActiveXCtrl::CETTSelfIDCardActiveXCtrl - ���캯��

CETTSelfIDCardActiveXCtrl::CETTSelfIDCardActiveXCtrl()
{
	this->InitNationArray();
	InitializeIIDs(&IID_DETTSelfIDCardActiveX, &IID_DETTSelfIDCardActiveXEvents);
	//this->InitNationArray();
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTSelfIDCardActiveXCtrl::~CETTSelfIDCardActiveXCtrl - ��������

CETTSelfIDCardActiveXCtrl::~CETTSelfIDCardActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
	this->m_nationArray.RemoveAll();
}



// CETTSelfIDCardActiveXCtrl::OnDraw - ��ͼ����

void CETTSelfIDCardActiveXCtrl::OnDraw(
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



// CETTSelfIDCardActiveXCtrl::DoPropExchange - �־���֧��

void CETTSelfIDCardActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTSelfIDCardActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTSelfIDCardActiveXCtrl::GetControlFlags()
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



// CETTSelfIDCardActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTSelfIDCardActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTSelfIDCardActiveXCtrl ��Ϣ�������

void CETTSelfIDCardActiveXCtrl::OnIsReadedChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnSexCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnSexNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnIDCardChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnNationCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnNationNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnBirthChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnAddressChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnFzjgChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnStartDateChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnEndDateChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnYxqxCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnYxqxNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnImagePathChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTSelfIDCardActiveXCtrl::ReadIDCard(void)
{


	SHORT result=0;
	AFX_MANAGE_STATE(AfxGetStaticModuleState());




	this->LoadDll();
	CString strErrorID;


	int i_ret=0;
	int i_Port=1001;

	for(;i_Port<=1016;i_Port++)
	{
		i_ret=SDT_OpenPort(i_Port);
		if(i_ret==144)
		{
			//strErrorID.Format(_T("��ȡSDT_OpenPort�Ķ˿ڳɹ���=%u;i_ret = %u"),i_Port,i_ret);
			//AfxMessageBox(strErrorID);
			break;
		}
	}
	//���ʹ�ô���
	if(this->m_IsUseCom==1)
	{
		//AfxMessageBox("��ʼ��ȡ���ڣ�");
		for(int i;i<=4;i++)
		{
			i_ret=SDT_OpenPort(i);
			if(i_ret==144)
			{
				//strErrorID.Format(_T("��ȡSDT_OpenPort�Ķ˿ڳɹ���=%u;i_ret = %u"),i,i_ret);
				//AfxMessageBox(strErrorID);
				i_Port=i;
				break;
			}
		}

	}
	if(i_ret!=144)
	{
		AfxMessageBox("����֤������û����ȷ���룬���飡");
		this->DestroyDll();
		return -1;
	}


	int intOpenPortRtn = 0;
	int rtnTemp = 0;
	//int  = 0;
	//int pucSN = 0;
	//int puiCHMsgLen = 0;
	//int puiPHMsgLen = 0;
	int EdziIfOpen = 1;   
	unsigned char pucIIN[256],puiCHMsgLen[256],puiPHMsgLen[256],pucSN[256];
	//AfxMessageBox("��ʼ�ҿ�SDT_StartFindIDCard");
	rtnTemp = SDT_StartFindIDCard(i_Port, pucIIN, EdziIfOpen);
	if (rtnTemp != 159)
	{
		rtnTemp = SDT_StartFindIDCard(i_Port, pucIIN, EdziIfOpen);  //���ҿ�
		if (rtnTemp != 159)
		{
			rtnTemp = SDT_ClosePort(i_Port);
			//AfxMessageBox("δ�ſ����߿�δ�źã������·ſ���");
			this->DestroyDll();
			// log.Debug();
			//MessageBox.Show("", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return 1;
		}
	}
	//AfxMessageBox("��ʼѡ��SDT_SelectIDCard");
	rtnTemp = SDT_SelectIDCard(i_Port,  pucSN, EdziIfOpen);
	if (rtnTemp != 144)
	{
		rtnTemp = SDT_SelectIDCard(i_Port, pucSN, EdziIfOpen);  //��ѡ��
		if (rtnTemp != 144)
		{
			rtnTemp = SDT_ClosePort(i_Port);
			//AfxMessageBox("����ʧ�ܣ�");
			this->DestroyDll();
			// MessageBox.Show("����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return 2;
		}
	}
	//AfxMessageBox("��ʼɾ���ļ���");
	try
	{
		CFile::Remove("c:\\wz.txt");
		CFile::Remove("c:\\zp.bmp");
		CFile::Remove("c:\\zp.wlt");
	}
	catch(CFileException *ex)
	{//�ļ������ڻ�����쳣

	}


	//AfxMessageBox("��ʼ��ȡ��Ϣ���ļ���");
	rtnTemp = SDT_ReadBaseMsgToFile(i_Port, "c:\\wz.txt", puiCHMsgLen, "c:\\zp.wlt",puiPHMsgLen, EdziIfOpen);
	if (rtnTemp != 144)
	{
		//AfxMessageBox("��ȡ���ļ���Ϣ���ļ�ʧ�ܣ�");
		rtnTemp = SDT_ClosePort(i_Port);
		this->DestroyDll();
		//log.Debug("��������ʧ�ܣ�");
		// MessageBox.Show("����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
		return 3;
	}

	if (this->m_IsUseCom)
		rtnTemp = GetBmp("c:\\zp.wlt", 2);
	else
		rtnTemp = GetBmp("c:\\zp.wlt", 1);

	/*
	CFile cf;
	int   iFileHandle=cf.Open("c:\\wz.txt", CFile::modeRead );
	if( !iFileHandle )
	return -1;

	// Get the size of the file and store
	// in a local variable. .
	DWORD dwSize;
	dwSize = cf.GetLength();
	strErrorID.Format(_T("��ȡ�������λ����=%u;"),dwSize);
	AfxMessageBox(strErrorID);
	wchar_t sRead=new wchar_t[dwSize];
	//��ָ����Ŀ
	cf.Read(sRead, dwSize);
	CString   str; 
	tmpstr.GetBuffer(1000);


	cf.Close();


	//char *unicodeStr=new char[dwSize];
	//::MultiByteToWideChar(CP_ACP, 0, sRead, -1, unicodeStr, dwSize);

	strErrorID.Format( _T("%s"), sRead ); //����_T����������UNICODE��
	AfxMessageBox(strErrorID);

	*/

	//strErrorID.Format( _T("%s"), test ); //����_T����������UNICODE��
	//AfxMessageBox(strErrorID);



	//strErrorID.Format(_T("ErrID = %u"),GetLastError());
	//AfxMessageBox(strErrorID);



	i_ret= SDT_ClosePort(i_Port);
	this->m_IsReaded=1;
	//strErrorID.Format(_T("SDT_ClosePort�Ķ˿�=%u;i_ret = %u"),i_Port,i_ret);
	//AfxMessageBox(strErrorID);
	//strErrorID.Format(_T("ErrID = %u"),GetLastError());
	//AfxMessageBox(strErrorID);
	this->DestroyDll();
	BSTR test=this->ReadFromFile("c:\\wz.txt");
	return 0;



	/*
	for(int i_Port=1001;i_Port<=1016;i_Port++)
	{
	i_ret=InitComm(i_Port);
	i_ret;
	strErrorID.Format(_T("InitComm�Ķ˿�=%u;i_ret = %u"),i_Port,i_ret);
	AfxMessageBox(strErrorID);
	strErrorID.Format(_T("ErrID = %u"),GetLastError());
	AfxMessageBox(strErrorID);
	if(i_ret==0)
	{
	strErrorID.Format(_T("InitComm�Ķ˿� = %u"),i_Port);
	AfxMessageBox(strErrorID);
	break;
	}
	}
	*/
	return result;
}

//��ʼ������ӳ�����
void CETTSelfIDCardActiveXCtrl::InitNationArray(void)
{
	/**/
	this->m_nationArray.Add("01", "����");
	this->m_nationArray.Add("02", "�ɹ���");
	this->m_nationArray.Add("03", "����");
	this->m_nationArray.Add("04", "����");
	this->m_nationArray.Add("05", "ά�����");
	this->m_nationArray.Add("06", "����");
	this->m_nationArray.Add("07", "����");
	this->m_nationArray.Add("08", "׳��");
	this->m_nationArray.Add("09", "������");
	this->m_nationArray.Add("10", "������");
	this->m_nationArray.Add("11", "����");
	this->m_nationArray.Add("12", "����");
	this->m_nationArray.Add("13", "����");
	this->m_nationArray.Add("14", "����");
	this->m_nationArray.Add("15", "������");
	this->m_nationArray.Add("16", "������");
	this->m_nationArray.Add("17", "��������");
	this->m_nationArray.Add("18", "����");
	this->m_nationArray.Add("19", "����");
	this->m_nationArray.Add("20", "������");
	this->m_nationArray.Add("21", "����");
	this->m_nationArray.Add("22", "���");
	this->m_nationArray.Add("23", "��ɽ��");
	this->m_nationArray.Add("24", "������");
	this->m_nationArray.Add("25", "ˮ��");
	this->m_nationArray.Add("26", "������");
	this->m_nationArray.Add("27", "������");
	this->m_nationArray.Add("28", "������");
	this->m_nationArray.Add("29", "�¶�������");
	this->m_nationArray.Add("30", "����");
	this->m_nationArray.Add("31", "�ﺲ����");
	this->m_nationArray.Add("32", "������");
	this->m_nationArray.Add("33", "Ǽ��");
	this->m_nationArray.Add("34", "������");
	this->m_nationArray.Add("35", "������");
	this->m_nationArray.Add("36", "ë����");
	this->m_nationArray.Add("37", "������");
	this->m_nationArray.Add("38", "������");
	this->m_nationArray.Add("39", "������");
	this->m_nationArray.Add("40", "������");
	this->m_nationArray.Add("41", "��������");
	this->m_nationArray.Add("42", "ŭ��");
	this->m_nationArray.Add("43", "���α����");
	this->m_nationArray.Add("44", "����˹��");
	this->m_nationArray.Add("45", "���¿���");
	this->m_nationArray.Add("46", "�°���");
	this->m_nationArray.Add("47", "������");
	this->m_nationArray.Add("48", "ԣ����");
	this->m_nationArray.Add("49", "����");
	this->m_nationArray.Add("50", "��������");
	this->m_nationArray.Add("51", "������");
	this->m_nationArray.Add("52", "���״���");
	this->m_nationArray.Add("53", "������");
	this->m_nationArray.Add("54", "�Ű���");
	this->m_nationArray.Add("55", "�����");
	this->m_nationArray.Add("56", "��ŵ��");
	this->m_nationArray.Add("57", "����");
	this->m_nationArray.Add("98", "������뼮");

	// TODO: �ڴ�������Դ���������

}


void CETTSelfIDCardActiveXCtrl::OnIsUseComChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTSelfIDCardActiveXCtrl::OnHasLoadLibChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}





SHORT CETTSelfIDCardActiveXCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	//AfxMessageBox("׼������dll��");
	DLLInst1=LoadLibrary("sdtapi.dll");
	//AfxMessageBox("LoadLibrary -sdtapi.dll �ɹ���");

	DLLInst2=LoadLibrary("WltRS.dll");
	//AfxMessageBox("LoadLibrary -WltRS.dll �ɹ���");
	if(DLLInst1!=NULL)
	{
		SDT_OpenPort=(int(__stdcall *)(int))GetProcAddress(DLLInst1,"SDT_OpenPort");
		SDT_ClosePort=(int(__stdcall *)(int))GetProcAddress(DLLInst1,"SDT_ClosePort");
		SDT_StartFindIDCard=(int(__stdcall *)(int,BYTE *pucIIN,int))GetProcAddress(DLLInst1,"SDT_StartFindIDCard");
		SDT_SelectIDCard=(int(__stdcall *)(int,BYTE *pucIIN,int))GetProcAddress(DLLInst1,"SDT_SelectIDCard");
		SDT_ReadBaseMsgToFile=(int(__stdcall *)(int,LPSTR filename,BYTE *puiCHMsgLen,LPSTR filename2,BYTE *puiPHMsgLen,int))GetProcAddress(DLLInst1,"SDT_ReadBaseMsgToFile");
	}
	else
	{
		AfxMessageBox("���ض�̬��sdtapi.dllʧ�ܣ�");
		exit(0);
	}
	if(DLLInst2!=NULL)
	{
		GetBmp=(int(__stdcall *)(LPSTR,int))GetProcAddress(DLLInst2,"GetBmp");
	}
	else
	{
		AfxMessageBox("���ض�̬��WltRS.dllʧ�ܣ�");
		exit(0);
	}



	return 0;
}

SHORT CETTSelfIDCardActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(DLLInst1!=NULL)
	{
		FreeLibrary(DLLInst1);
		DLLInst1=NULL;
	}
	if(DLLInst2!=NULL)
	{
		FreeLibrary(DLLInst2);
		DLLInst2=NULL;
	}


	return 0;
}

void CETTSelfIDCardActiveXCtrl::OnReadTickChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

BSTR CETTSelfIDCardActiveXCtrl::ReadFromFile(LPCTSTR filename)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
	CString strTemp;
	CString strTxt;
	CFile file;
	if(file.Open(filename,CFile::modeRead|CFile::typeBinary))
	{
		WCHAR buffer[255];
		memset(buffer,0,sizeof(buffer));
		file.Read(buffer,sizeof(buffer));
		file.Close();
		CString str(buffer);
		//AfxMessageBox(str);
		CString strTemp;
		int nLength = 0;
		int tokenLength[] = {30,2,4,16,70,36,30,16,16,70};
		WCHAR bufferTemp[255];		
		for(int i=0;i<sizeof(tokenLength)/sizeof(int);i++)
		{
			memset(bufferTemp,0,sizeof(bufferTemp));
			memcpy(bufferTemp,buffer+nLength,tokenLength[i]);
			CString str(bufferTemp);
			strTemp = str;
			nLength += tokenLength[i]/sizeof(WCHAR);
			//AfxMessageBox(strTemp);
			switch(i)
			{
			case 0:
				this->m_Name=str;
				break;
			case 1:
				if(str=="1")
				{
					this->m_SexCode=1;
					this->m_SexName="��";
				}
				else if(str=="0")
				{
					this->m_SexCode=0;
					this->m_SexName="Ů";
				}
				break;

			case 2:
				this->m_NationCode=str;
				this->m_NationName=this->m_nationArray.Get(str);
				break;

			case 3:
				this->m_Birth=str;
				break;
			case 4:
				this->m_Address=str;
				break;
			case 5:
				this->m_IDCard=str;
				break;
			case 6:
				this->m_Fzjg=str;
				break;
			case 7:
				this->m_StartDate=str;
				break;
			case 8:
				this->m_EndDate=str;
				break;
			default:
				break;
			}

			//AfxMessageBox(strTemp);
		}
	}

	/*
	//BSTR
	CString str;

	CString strErrorID;

	char   psFirst[2]; 
	CFile cf;
	//AfxMessageBox("׼�����ļ���");
	int   iFileHandle=cf.Open(filename, CFile::modeRead );
	int   iFileLength   = cf.GetLength();
	strErrorID.Format(_T("�ļ�����=%u;"),iFileLength);
	AfxMessageBox(strErrorID);
	//AfxMessageBox("��ȡ���ļ����ȣ�");
	char *wstr=new char[iFileLength];      
	// wchar_t   *wstr=new   wchar_t[iFileLength+1]; 
	cf.Read(wstr,   iFileLength); 
	//AfxMessageBox("��ȡ�ļ���ϣ�");
	cf.Close();

	strErrorID.Format(_T("�ļ�����=%u;"),wstr);
	AfxMessageBox(strErrorID);
	//AfxMessageBox("�ر��ļ���ϣ�");
	//WideString *a=new WideString(wstr);
	//a->toUTF8String(wstr);
	LPWSTR ttt;
	//a->ws;

	wchar_t* ws=new wchar_t;
	//WideCharToMultiByte(CP_UTF8,0,ws,-1,wstr,iFileLength,NULL,NULL);
	//int MultiByteToWideChar(UINT CodePage, DWORD dwFlags, LPCSTR lpMultiByteStr,
	//int cchMultiByte, LPWSTR lpWideCharStr, int cchWideChar); 
	// MultiByteToWideChar(CP_ACP,0,wstr,-1,ttt,iFileLength);

	int len = ::MultiByteToWideChar(CP_THREAD_ACP, 0, wstr, -1, NULL, 0);   
	strErrorID.Format(_T("����=%u;"),len);
	AfxMessageBox(strErrorID);
	// AfxMessageBox(len);
	if (len == 0) return L"";   

	std::vector<wchar_t> unicode(len);   
	::MultiByteToWideChar(CP_THREAD_ACP, 0, wstr, -1, &unicode[0], len);   

	// return &unicode[0];  

	strErrorID.Format(_T("����=%u;"),&unicode[0]);
	AfxMessageBox(strErrorID);

	*/


	return strTemp.AllocSysString();
}
