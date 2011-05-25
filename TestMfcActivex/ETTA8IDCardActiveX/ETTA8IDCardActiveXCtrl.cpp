// ETTA8IDCardActiveXCtrl.cpp : CETTA8IDCardActiveXCtrl ActiveX �ؼ����ʵ�֡�

#include "stdafx.h"
#include "ETTA8IDCardActiveX.h"
#include "ETTA8IDCardActiveXCtrl.h"
#include "ETTA8IDCardActiveXPropPage.h"



#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CETTA8IDCardActiveXCtrl, COleControl)

BEGIN_INTERFACE_MAP(   CETTA8IDCardActiveXCtrl,   COleControl   ) 
	INTERFACE_PART(CETTA8IDCardActiveXCtrl,   IID_IObjectSafety,   ObjSafe) 
END_INTERFACE_MAP() 

///////////////////////////////////////////////////////////////////////////// 
//   IObjectSafety   member   functions 

//   Delegate   AddRef,   Release,   QueryInterface 

ULONG   FAR   EXPORT   CETTA8IDCardActiveXCtrl::XObjSafe::AddRef() 
{ 
	METHOD_PROLOGUE(CETTA8IDCardActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalAddRef(); 
} 

ULONG   FAR   EXPORT   CETTA8IDCardActiveXCtrl::XObjSafe::Release() 
{ 
	METHOD_PROLOGUE(CETTA8IDCardActiveXCtrl,   ObjSafe) 
		return   pThis-> ExternalRelease(); 
} 

HRESULT   FAR   EXPORT   CETTA8IDCardActiveXCtrl::XObjSafe::QueryInterface( 
	REFIID   iid,   void   FAR*   FAR*   ppvObj) 
{ 
	METHOD_PROLOGUE(CETTA8IDCardActiveXCtrl,   ObjSafe) 
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
CETTA8IDCardActiveXCtrl::XObjSafe::GetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwSupportedOptions, 
	/*   [out]   */   DWORD   __RPC_FAR   *pdwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTA8IDCardActiveXCtrl,   ObjSafe) 

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
CETTA8IDCardActiveXCtrl::XObjSafe::SetInterfaceSafetyOptions(   
	/*   [in]   */   REFIID   riid, 
	/*   [in]   */   DWORD   dwOptionSetMask, 
	/*   [in]   */   DWORD   dwEnabledOptions) 
{ 
	METHOD_PROLOGUE(CETTA8IDCardActiveXCtrl,   ObjSafe) 

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

BEGIN_MESSAGE_MAP(CETTA8IDCardActiveXCtrl, COleControl)
	ON_OLEVERB(AFX_IDS_VERB_PROPERTIES, OnProperties)
END_MESSAGE_MAP()



// ����ӳ��

BEGIN_DISPATCH_MAP(CETTA8IDCardActiveXCtrl, COleControl)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "Message", dispidMessage, m_Message, OnMessageChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "LoadDll", dispidLoadDll, LoadDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "OpenDeviceEx", dispidOpenDeviceEx, OpenDeviceEx, VT_I2, VTS_I2)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "CloseDeviceEx", dispidCloseDeviceEx, CloseDeviceEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "EnterCardEx", dispidEnterCardEx, EnterCardEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "EjectCardEx", dispidEjectCardEx, EjectCardEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "DestroyDll", dispidDestroyDll, DestroyDll, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "ReadAndScanEx", dispidReadAndScanEx, ReadAndScanEx, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "IdCardImgFileName", dispidIdCardImgFileName, m_IdCardImgFileName, OnIdCardImgFileNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "IdCardFrontImgFileName", dispidIdCardFrontImgFileName, m_IdCardFrontImgFileName, OnIdCardFrontImgFileNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "IdCardEndImgFileName", dispidIdCardEndImgFileName, m_IdCardEndImgFileName, OnIdCardEndImgFileNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "IsReaded", dispidIsReaded, m_IsReaded, OnIsReadedChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "Name", dispidName, m_Name, OnNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "SexCode", dispidSexCode, m_SexCode, OnSexCodeChanged, VT_I2)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "SexName", dispidSexName, m_SexName, OnSexNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "NationCode", dispidNationCode, m_NationCode, OnNationCodeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "NationName", dispidNationName, m_NationName, OnNationNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "Birth", dispidBirth, m_Birth, OnBirthChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "Address", dispidAddress, m_Address, OnAddressChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "Fzjg", dispidFzjg, m_Fzjg, OnFzjgChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "StartDate", dispidStartDate, m_StartDate, OnStartDateChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "EndDate", dispidEndDate, m_EndDate, OnEndDateChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "YxqxCode", dispidYxqxCode, m_YxqxCode, OnYxqxCodeChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "YxqxName", dispidYxqxName, m_YxqxName, OnYxqxNameChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "ReadTick", dispidReadTick, m_ReadTick, OnReadTickChanged, VT_I2)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "GetDeviceStatusEx", dispidGetDeviceStatusEx, GetDeviceStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "CalibrationEx", dispidCalibrationEx, CalibrationEx, VT_I2, VTS_NONE)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "ImgPathPreX", dispidImgPathPreX, m_ImgPathPreX, OnImgPathPreXChanged, VT_BSTR)
	DISP_PROPERTY_NOTIFY_ID(CETTA8IDCardActiveXCtrl, "IdCard", dispidIdCard, m_IdCard, OnIdCardChanged, VT_BSTR)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "InitNationArray", dispidInitNationArray, InitNationArray, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "GetCardStatusEx", dispidGetCardStatusEx, GetCardStatusEx, VT_I2, VTS_NONE)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "ReadAndScanDpiEx", dispidReadAndScanDpiEx, ReadAndScanDpiEx, VT_I2, VTS_I4)
	DISP_FUNCTION_ID(CETTA8IDCardActiveXCtrl, "ReadAndScan2Ex", dispidReadAndScan2Ex, ReadAndScan2Ex, VT_I2, VTS_NONE)
END_DISPATCH_MAP()



// �¼�ӳ��

BEGIN_EVENT_MAP(CETTA8IDCardActiveXCtrl, COleControl)
END_EVENT_MAP()



// ����ҳ

// TODO: ����Ҫ��Ӹ�������ҳ�����ס���Ӽ���!
BEGIN_PROPPAGEIDS(CETTA8IDCardActiveXCtrl, 1)
	PROPPAGEID(CETTA8IDCardActiveXPropPage::guid)
END_PROPPAGEIDS(CETTA8IDCardActiveXCtrl)



// ��ʼ���๤���� guid

IMPLEMENT_OLECREATE_EX(CETTA8IDCardActiveXCtrl, "ETTA8IDCARDACTIV.ETTA8IDCardActivCtrl.1",
	0xc504828d, 0xbb8d, 0x4d2f, 0xaa, 0x5c, 0x7e, 0xd3, 0x79, 0x7a, 0x8c, 0xa2)



// ����� ID �Ͱ汾

IMPLEMENT_OLETYPELIB(CETTA8IDCardActiveXCtrl, _tlid, _wVerMajor, _wVerMinor)



// �ӿ� ID

const IID BASED_CODE IID_DETTA8IDCardActiveX =
		{ 0xA3041BBA, 0x5CA8, 0x4D06, { 0x8F, 0x7F, 0x9F, 0x26, 0x9F, 0xD0, 0x79, 0x53 } };
const IID BASED_CODE IID_DETTA8IDCardActiveXEvents =
		{ 0x9458A5D9, 0xFD14, 0x4776, { 0x88, 0x71, 0x31, 0x6, 0x7, 0x96, 0xBB, 0x47 } };



// �ؼ�������Ϣ

static const DWORD BASED_CODE _dwETTA8IDCardActiveXOleMisc =
	OLEMISC_INVISIBLEATRUNTIME |
	OLEMISC_SETCLIENTSITEFIRST |
	OLEMISC_INSIDEOUT |
	OLEMISC_CANTLINKINSIDE |
	OLEMISC_RECOMPOSEONRESIZE;

IMPLEMENT_OLECTLTYPE(CETTA8IDCardActiveXCtrl, IDS_ETTA8IDCARDACTIVEX, _dwETTA8IDCardActiveXOleMisc)



// CETTA8IDCardActiveXCtrl::CETTA8IDCardActiveXCtrlFactory::UpdateRegistry -
// ��ӻ��Ƴ� CETTA8IDCardActiveXCtrl ��ϵͳע�����

BOOL CETTA8IDCardActiveXCtrl::CETTA8IDCardActiveXCtrlFactory::UpdateRegistry(BOOL bRegister)
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
			IDS_ETTA8IDCARDACTIVEX,
			IDB_ETTA8IDCARDACTIVEX,
			afxRegApartmentThreading,
			_dwETTA8IDCardActiveXOleMisc,
			_tlid,
			_wVerMajor,
			_wVerMinor);
	else
		return AfxOleUnregisterClass(m_clsid, m_lpszProgID);
}



// CETTA8IDCardActiveXCtrl::CETTA8IDCardActiveXCtrl - ���캯��

CETTA8IDCardActiveXCtrl::CETTA8IDCardActiveXCtrl()
{
	InitializeIIDs(&IID_DETTA8IDCardActiveX, &IID_DETTA8IDCardActiveXEvents);
	// TODO: �ڴ˳�ʼ���ؼ���ʵ�����ݡ�
}



// CETTA8IDCardActiveXCtrl::~CETTA8IDCardActiveXCtrl - ��������

CETTA8IDCardActiveXCtrl::~CETTA8IDCardActiveXCtrl()
{
	// TODO: �ڴ�����ؼ���ʵ�����ݡ�
}



// CETTA8IDCardActiveXCtrl::OnDraw - ��ͼ����

void CETTA8IDCardActiveXCtrl::OnDraw(
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



// CETTA8IDCardActiveXCtrl::DoPropExchange - �־���֧��

void CETTA8IDCardActiveXCtrl::DoPropExchange(CPropExchange* pPX)
{
	ExchangeVersion(pPX, MAKELONG(_wVerMinor, _wVerMajor));
	COleControl::DoPropExchange(pPX);

	// TODO: Ϊÿ���־õ��Զ������Ե��� PX_ ������
}



// CETTA8IDCardActiveXCtrl::GetControlFlags -
// �Զ��� MFC �� ActiveX �ؼ�ʵ�ֵı�־��
//
DWORD CETTA8IDCardActiveXCtrl::GetControlFlags()
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



// CETTA8IDCardActiveXCtrl::OnResetState - ���ؼ�����ΪĬ��״̬

void CETTA8IDCardActiveXCtrl::OnResetState()
{
	COleControl::OnResetState();  // ���� DoPropExchange ���ҵ���Ĭ��ֵ

	// TODO: �ڴ��������������ؼ�״̬��
}



// CETTA8IDCardActiveXCtrl ��Ϣ�������

void CETTA8IDCardActiveXCtrl::OnMessageChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTA8IDCardActiveXCtrl::LoadDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	// AfxMessageBox("׼������TTCardReaderV2��");
	SYSCAN_hDrvModule=LoadLibrary(SCANNER_DLL_NAME);
	//DLLInst=LoadLibrary("TTReadCard.dll");
	//AfxMessageBox("�������TTCardReaderV2��");
	if(SYSCAN_hDrvModule!=NULL)
	{
		//AfxMessageBox("��ʼ����TTCardReaderV2�еĺ�����");
		SYSCAN_HasScanner               = (BOOL(__stdcall *)(char*))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_HasScanner"));
		SYSCAN_CloseDevice				= (BOOL(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CloseDevice"));
		SYSCAN_GetButtonStatus          = (SC_STATUS(__stdcall *)(unsigned long *))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetButtonStatus"));
		SYSCAN_ResetDevice				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule, TEXT("IO_ResetDevice"));
		SYSCAN_GetDeviceStatus			= (SC_STATUS(__stdcall *)(SC_STATUS* status))GetProcAddress(SYSCAN_hDrvModule, TEXT("IO_GetDeviceStatus"));
		//	SYSCAN_SetScanMode				= (SC_STATUS(__cdecl *)(const SC_MODE* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_SetScanMode"));
		//	SYSCAN_GetScanMode				= (SC_STATUS(__cdecl *)(SC_MODE* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetScanMode"));
		//	SYSCAN_BeginScan				= (SC_STATUS(__cdecl *)(SC_MODE* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_BeginScan"));
		SYSCAN_CancelScan				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CancelScan"));
		SYSCAN_GetScanData				= (SC_STATUS(__stdcall *)(unsigned char* buffer, unsigned long length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetScanData"));
		SYSCAN_StartCalib				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StartCalib"));
		SYSCAN_CancelCalib				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CancelCalib"));
		//	SYSCAN_CalibrateScanner         = (SC_STATUS(__cdecl *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CalibrateScanner"));
		//	SYSCAN_GetLines					= (SC_STATUS(__cdecl *)(BYTE *pAreaBuf,unsigned long lines, SC_MODE * mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetLines"));

		//SYSCAN_BeginScan				= (SC_STATUS(__cdecl *)(SC_MODEA8* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_BeginScan"));
		SYSCAN_BeginScan				= (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_BeginScan"));

		//	SYSCAN_EndScan  			   = (SC_STATUS(__cdecl *)(SC_MODEA8* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_EndScan"));
		SYSCAN_EndScan  			   = (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_EndScan"));	//20080304,delete parameters

		SYSCAN_StartMotor				= (SC_STATUS(__stdcall *)(unsigned long speed))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StartMotor"));
		SYSCAN_StopMotor               = (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StopMotor"));

		/////////////////////////////////////////////////////////////////////////////////////

		SYSCAN_ConfiscateCard =(SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_ConfiscateCard"));
		SYSCAN_EjectCard =(SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_EjectCard"));
		SYSCAN_GetSensorStatus=(SC_STATUS(__stdcall *)(SC_STATUS* status))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetSensorStatus"));
		SYSCAN_GetCardStatus=(SC_STATUS(__stdcall *)(SC_STATUS* status))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetCardStatus"));
		SYSCAN_StartSuckCard = (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StartSuckCard"));
		SYSCAN_CancelSuckCard = (SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CancelSuckCard"));

		SYSCAN_SetScanModeA8 = (SC_STATUS(__stdcall *)(const SC_MODEA8* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_SetScanModeA8"));
		SYSCAN_GetScanModeA8 = (SC_STATUS(__stdcall *)(SC_MODEA8* mode))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetScanModeA8"));

		SYSCAN_GetScanDataLength=(SC_STATUS (__stdcall *)(unsigned long * status))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetScanDataLength"));
		SYSCAN_GetImageBlockA8 = (short(__stdcall *)(VOID * pAreaBuf1, VOID * pAreaBuf2,short line,unsigned long index,unsigned short *usOverFlag))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetImageBlockA8"));

		//Add by chengxiang,20080304
		SYSCAN_GetChipID=(SC_STATUS(__stdcall *)(UINT * pChipID))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetChipID"));
		SYSCAN_Beep=(SC_STATUS(__stdcall *)(int time))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_Beep"));
		SYSCAN_GetVersion=(SC_STATUS(__stdcall *)(char * version))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetVersion"));
		//End add

		SYSCAN_GetMagcardDataLength = (SC_STATUS(__stdcall *)(unsigned long track, unsigned long * length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetMagcardDataLength"));
		SYSCAN_GetMagcardData = (SC_STATUS(__stdcall *)(unsigned long track, unsigned char* buffer, unsigned long* length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetMagcardData"));

		SYSCAN_GetMagcardRawDataLength = (SC_STATUS(__stdcall *)(unsigned long track, unsigned long * length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetMagcardRawDataLength"));
		SYSCAN_GetMagcardRawData = (SC_STATUS(__stdcall *)(unsigned long track, unsigned char* buffer, unsigned long* length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetMagcardRawData"));

		SYSCAN_GetCalibData		=	(SC_STATUS(__stdcall *)(SC_CALIBDATA *))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetCalibData"));
		SYSCAN_GetDeviceError	=	(SC_STATUS(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetDeviceError"));	
		SYSCAN_GetImgFromUnit   =   (SC_STATUS(__stdcall *)(unsigned long lDpi,
		                                   const char *pImgPath1,unsigned long *lImgW1,unsigned long *lImgH1,
										   const char *pImgPath2,unsigned long *lImgW2,unsigned long *lImgH2))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetImgFromUnit"));

		SYSCAN_GetHeadFromImage =   (SC_STATUS(__stdcall *)(const char *pImgPath1,const char *pImgPath2,const char *pImgHeadPath))
									 GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_GetHeadFromImage"));

		//add for rfid
		SYSCAN_StopRFID                = (long(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StopRFID"));
		SYSCAN_StartRFID               = (long(__stdcall *)(void))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_StartRFID"));
		SYSCAN_HaltCard				   = (long(__stdcall *)(const SC_RFID* param))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_HaltCard"));
		SYSCAN_RequestCard			   = (long(__stdcall *)(unsigned long* type))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_RequestCard"));
		SYSCAN_ReadCard	               = (long(__stdcall *)(const SC_RFID* param, unsigned char* buffer, unsigned long* length))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_ReadCard"));
		SYSCAN_ReadRFIDInfo			   = (long(__stdcall *)(id_Card *pIdCard))GetProcAddress(SYSCAN_hDrvModule,"IO_ReadRFIDInfo");
		//add for rfid end

		SYSCAN_CalibBmpFile		=	(void(__stdcall *)(char *pFilePath))GetProcAddress(SYSCAN_hDrvModule,TEXT("IO_CalibBmpFile"));
		SYSCAN_BmpToJpeg		=	(int (__stdcall *)(char *srcFileName,char *dstFileName))GetProcAddress(SYSCAN_hDrvModule,"BmpToJpeg");
		SYSCAN_Dpi600To300		=   (BOOL (__stdcall *)(BYTE *srcbuf,BYTE *dstbuf,int width,int height,BYTE imgMode))GetProcAddress(SYSCAN_hDrvModule,"Dpi600To300");

		//AfxMessageBox("�������TTCardReaderV2�еĺ�����");

	}
	else
	{
		AfxMessageBox("���ض�̬��A8.dllʧ�ܣ�");
		exit(0);
	}


	return 0;
}

SHORT CETTA8IDCardActiveXCtrl::OpenDeviceEx(SHORT port)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if (SYSCAN_HasScanner(SCANNER_NAME))
	{
		CString dispinfo;
		dispinfo.Format("open device ok");
		//GetDlgItem(IDC_STATIC_STATUS)->SetWindowText(dispinfo);		
		scan_running = true;

		//GetDlgItem(IDC_OPEN_DEV) ->EnableWindow(false);
		modeA8.mode_d = 7;		//
		modeA8.mode_d_r	= 7;
		modeA8.mode_u = 7;
		modeA8.mode_u_r	= 7 ;
		modeA8.auto_reverse	= 0 ;
		SYSCAN_SetScanModeA8(&modeA8);
		this->m_Message="�ɹ�";
		return 0;

	}
	else
	{
		//CString dispinfo;
		//dispinfo.Format("open device fail");
		//GetDlgItem(IDC_STATIC_STATUS)->SetWindowText(dispinfo);
		this->m_Message="ʧ��";
		return -1;
		//OnBtnClose();
	}
	//bRFIDEnable = FALSE;
	CalibrationEx();

	return 0;
}

SHORT CETTA8IDCardActiveXCtrl::CloseDeviceEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������
	if (scan_running)
	{	
		SYSCAN_CloseDevice();
		scan_running = false;
	}   
	 SYSCAN_CloseDevice();

	return 0;
}

SHORT CETTA8IDCardActiveXCtrl::EnterCardEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	long lRet = SYSCAN_StartSuckCard();
	if(lRet==SCS_OK)
	{
		this->m_Message="�ɹ�";
		return 0;
	}
	this->m_Message="ʧ��";

	return -1;
}

SHORT CETTA8IDCardActiveXCtrl::EjectCardEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	unsigned long status =  SYSCAN_EjectCard();
	if(status==SCS_OK)
	{

		this->m_Message="�ɹ�";
		SYSCAN_CancelSuckCard();
		return 0;
	}
	this->m_Message="ʧ��";

	return -1;
}

SHORT CETTA8IDCardActiveXCtrl::DestroyDll(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	if(SYSCAN_hDrvModule!=NULL)
	{
		FreeLibrary(SYSCAN_hDrvModule);
		SYSCAN_hDrvModule=NULL;
	}
	/*
	if(DLLInst2!=NULL)
	{
		FreeLibrary(DLLInst2);
		DLLInst2=NULL;
	}
	if(DLLInst3!=NULL)
	{
		FreeLibrary(DLLInst3);
		DLLInst3=NULL;
	}
	*/

	return 0;
}

SHORT CETTA8IDCardActiveXCtrl::ReadAndScanEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());
 
	return this->ReadAndScanDpiEx(300);
	
}

void CETTA8IDCardActiveXCtrl::OnIdCardImgFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnIdCardFrontImgFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnIdCardEndImgFileNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnIsReadedChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnSexCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnSexNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnNationCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnNationNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnBirthChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnAddressChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnFzjgChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnStartDateChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnEndDateChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnYxqxCodeChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnYxqxNameChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::OnReadTickChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTA8IDCardActiveXCtrl::GetDeviceStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	SC_STATUS Cstatus;                                            
	SC_STATUS DeviceStatus =  SYSCAN_GetDeviceStatus(&Cstatus);
	this->m_Message = "error";
	if(DeviceStatus == SCS_PARAM)
	{
		m_Message = MSG_SCS_PARAM;

	}
	//else if(DeviceStatus == SCS_ERROR)
	//{
		//m_Message = "SCS_ERROR";

	//}
	else if(DeviceStatus == SCS_OK)
	{
		m_Message = MSG_SCS_OK;

	}
	////////
	else if(DeviceStatus == SCS_FAIL)
	{
		m_Message = MSG_SCS_FAIL;

	}
	else if(DeviceStatus == SCS_NODATA)
	{
		m_Message = MSG_SCS_NODATA;

	}

	else if(DeviceStatus == SCS_BUSY)
	{
		m_Message = MSG_SCS_BUSY;

	}
	else if(DeviceStatus == SCS_CALIB)
	{
		m_Message = MSG_SCS_CALIB;

	}	
	else if(DeviceStatus == SCS_CLEAN)
	{
		m_Message = MSG_SCS_CLEAN;

	}
	else if(DeviceStatus == SCS_SCAN)
	{
		m_Message = MSG_SCS_SCAN;

	}	
	//else if(DeviceStatus == SCS_CARD)
	//{
		//m_Message = "SCS_CARD";

	//}
	//else if(DeviceStatus == SCS_MOTOR)
	//{
		//m_Message = "SCS_MOTOR";
	//} 


	return 0;
}

SHORT CETTA8IDCardActiveXCtrl::CalibrationEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	unsigned long status=1;
	memset(&CalibData,0xff,sizeof(SC_CALIBDATA));

	long retValue;
	retValue=SYSCAN_GetCalibData(&CalibData);
	CString disdata;
	if (retValue!=SCS_OK)
	{
		disdata.Format("��ȡУ׼�Ĳ�������");
		return -2;
	}

	status=CalibData.bCalibStatus;
	if (status==0)	//δУ׼
	{
		disdata.Format("The device didn't calibrate till now, acquiring the data need accomplished the calibration process.");

		return -1;
	}
	else		//��У׼
	{
		//write calibration data to file
		char filename[]="calibdata.txt";
		//CFile file(strFileName,CFile::modeWrite);
		disdata.Format("Get calibration parameter OK!");
		return 0;
	}

	return 0;
}

BOOL CETTA8IDCardActiveXCtrl::WriteBMPFileHeader(FILE *pFile, int nImgW, int nImgH, int nDPI, int nColorMode, int nBytesPerLine)
{
	//AfxMessageBox("��ʼдͼƬ�ļ�ͷ");
	BITMAPFILEHEADER   bmpflh; //�ļ�ͷ file header
	BITMAPINFOHEADER   bmpifh; //��Ϣͷ information header

	bmpflh.bfType = 0x4d42;
	bmpflh.bfReserved1 = 0;
	bmpflh.bfReserved2 = 0;

	bmpifh.biSize = sizeof(BITMAPINFOHEADER);
	bmpifh.biWidth = nImgW;
	bmpifh.biHeight = nImgH;
	bmpifh.biPlanes = 1;
	if(0 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(1 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}

	else if (2 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(3 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(4 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(5 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(6 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(7 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(8 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(9 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(10 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(11 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(12 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(13 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(14 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}
	else if(15 == nColorMode)
	{
		bmpifh.biBitCount = 8;
	}

	else if(16 == nColorMode)
	{
		bmpifh.biBitCount = 24;
	}
	else
	{
		return FALSE;
	}
	bmpifh.biCompression = BI_RGB;
	bmpifh.biSizeImage = 0;
	bmpifh.biXPelsPerMeter = nDPI * 10000 / 254;
	bmpifh.biYPelsPerMeter = nDPI * 10000 / 254;
	bmpifh.biClrUsed = 0;
	bmpifh.biClrImportant = 0;

	switch (bmpifh.biBitCount){
	case 1:
		{
			RGBQUAD colortable[2];
			colortable[0].rgbRed = 0;
			colortable[0].rgbGreen = 0;
			colortable[0].rgbBlue = 0;
			colortable[0].rgbReserved = 0;
			colortable[1].rgbRed = 255;
			colortable[1].rgbGreen = 255;
			colortable[1].rgbBlue = 255;
			colortable[1].rgbReserved = 0;
			bmpflh.bfOffBits = sizeof(BITMAPFILEHEADER) + bmpifh.biSize + 2 * sizeof(RGBQUAD);
			bmpflh.bfSize = bmpflh.bfOffBits + nBytesPerLine * nImgH;
			bmpifh.biClrUsed = 2;
			bmpifh.biClrImportant = 2;
			if (sizeof(BITMAPFILEHEADER) != fwrite(&bmpflh,1,sizeof(BITMAPFILEHEADER),pFile))
				return FALSE;
			if (bmpifh.biSize != fwrite(&bmpifh,1,bmpifh.biSize,pFile))
				return FALSE;
			if (sizeof(RGBQUAD) * 2 != fwrite(colortable,1,sizeof(RGBQUAD) * 2,pFile))
				return FALSE;
			break;
		}
	case 8:
		{
			RGBQUAD colortable[256];
			for (int i = 0 ; i < 256 ; i ++){
				colortable[i].rgbBlue = i;
				colortable[i].rgbGreen = i;
				colortable[i].rgbRed = i;
				colortable[i].rgbReserved = 0;
			}
			bmpflh.bfOffBits = sizeof(BITMAPFILEHEADER) + bmpifh.biSize + 256 * sizeof(RGBQUAD);
			bmpflh.bfSize = bmpflh.bfOffBits + nBytesPerLine * nImgH;
			if (sizeof(BITMAPFILEHEADER) != fwrite(&bmpflh,1,sizeof(BITMAPFILEHEADER),pFile))
				return FALSE;
			if (bmpifh.biSize != fwrite(&bmpifh,1,bmpifh.biSize,pFile))
				return FALSE;
			if (sizeof(RGBQUAD) * 256 != fwrite(colortable,1,sizeof(RGBQUAD) * 256,pFile))
				return FALSE;
			break;
		}
	case 24:
		bmpflh.bfOffBits = sizeof(BITMAPFILEHEADER) + bmpifh.biSize;
		bmpflh.bfSize = bmpflh.bfOffBits + nBytesPerLine * nImgH;
		if (sizeof(BITMAPFILEHEADER) != fwrite(&bmpflh,1,sizeof(BITMAPFILEHEADER),pFile))
			return FALSE;
		if (bmpifh.biSize != fwrite(&bmpifh,1,bmpifh.biSize,pFile))
			return FALSE;
		
		
		break;
	}

	//AfxMessageBox("����дͼƬ�ļ�ͷ");
	//set file length
	if (0 != fseek(pFile,bmpflh.bfSize - 1,SEEK_SET))
		return FALSE;
	if (1 != fwrite(&bmpflh,1,1,pFile))//write any one byte
		return FALSE;
	if (0 != fseek(pFile,0,SEEK_END))
		return FALSE;
	return TRUE;
} 



void CETTA8IDCardActiveXCtrl::OnImgPathPreXChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

void CETTA8IDCardActiveXCtrl::GetExePath(LPSTR tmppath)
{
	CString str;
	 str = "c:\\";
		//AfxMessageBox(m_ImgPathPreX);
	 //LPCTSTR buf = (LPCTSTR)this->m_ImgPathPreX; 
		LPCTSTR buf = (LPCTSTR)str; 

	int i;                       // get application directory
	lstrcpy(tmppath, buf);             
	for( i = lstrlen(tmppath); i >= 0 && tmppath[i] != '\\'; i--);
	tmppath[i+1] = '\0';
}

void CETTA8IDCardActiveXCtrl::OnIdCardChanged(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ�������Դ���������

	SetModifiedFlag();
}

SHORT CETTA8IDCardActiveXCtrl::InitNationArray(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

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

	

	return 0;
}


unsigned long CETTA8IDCardActiveXCtrl::CreateWltFile(BYTE *pBuf)
{
	char szPath[MAX_PATH];

	strcpy(szPath, "c:\\Picture.wlt");

	HANDLE hFile = INVALID_HANDLE_VALUE;
	DWORD dwBytesReturned;



	hFile = CreateFile(szPath,
		GENERIC_WRITE,
		0,
		NULL,
		CREATE_ALWAYS,
		FILE_ATTRIBUTE_NORMAL,
		NULL);

	if(hFile == INVALID_HANDLE_VALUE)
	{
		return 0;
	}

	BOOL bRes;
	bRes = WriteFile(hFile, pBuf, 1024 * sizeof( BYTE ), &dwBytesReturned, NULL);
	if (bRes)
	{
		CloseHandle( hFile );
		return 1;
	}
	else
		return 0;
}
int CETTA8IDCardActiveXCtrl::FileWltToBmp(void)
{   
	AfxMessageBox("	��ʼ��wlt�ļ�ת��bmp");
	int ( WINAPI *SYS_GetBMP )(char * wlt_file,int intf);
	AfxMessageBox("׼������WltRS.dll�ļ�");
	HMODULE hLib = ::LoadLibrary("WltRS.dll");
	SYS_GetBMP	= (int(WINAPI*)(char *,int))GetProcAddress(hLib,TEXT("GetBmp"));
    AfxMessageBox("����WltRS.dll�ļ����");
	char szPath[MAX_PATH];
	//GetCurrentDirectory(MAX_PATH,szPath);
	//strcat(szPath,"\\Picture.wlt");
	strcpy(szPath, "c:\\Picture.wlt");

	int retbmp = SYS_GetBMP(szPath,1);
	CString	dispinfo;
	dispinfo.Format("GetBMP return code%d",retbmp);
	//m_staticinfo.SetWindowText(dispinfo);  
	AfxMessageBox(dispinfo);
	if( retbmp == -1 )
	{
		//AfxMessageBox("	decode picture err\r\n");
	}
	else if( retbmp == -2 )
	{
		//AfxMessageBox("wlt�ļ���׺����");        
	}
	else if( retbmp == -3 )
	{	
		//AfxMessageBox("wlt�ļ��򿪴���");
	}   
	else if( retbmp == -4 )
	{
		//AfxMessageBox("wlt�ļ��򿪴���");
	}
	else if( retbmp == -5 )
	{
		//AfxMessageBox("���δ��Ȩ");
	}
	else if( retbmp == -6 )
	{
		//AfxMessageBox("�豸���Ӵ���");
	}
	::FreeLibrary(hLib);
	return retbmp;
}

SHORT CETTA8IDCardActiveXCtrl::GetCardStatusEx(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������

	SC_STATUS Cstatus;                                            
	//SC_STATUS DeviceStatus =  SYSCAN_GetCardStatus(&Cstatus);
	SYSCAN_GetCardStatus(&Cstatus);
	this->m_Message = "error";
	if(Cstatus == STATUS_CARD_F_READY )
	{
		m_Message = MSG_STATUS_CARD_F_READY;

	}else if(Cstatus == STATUS_CARD_R_READY ){
		m_Message = MSG_STATUS_CARD_R_READY;
	}else if(Cstatus == STATUS_CARD_NONE ){
		m_Message = MSG_STATUS_CARD_NONE;
	}else if(Cstatus == STATUS_CARD_F_SCANNING ){
		m_Message = MSG_STATUS_CARD_F_SCANNING;
	}else if(Cstatus == STATUS_CARD_R_SCANNING ){
		m_Message = MSG_STATUS_CARD_R_SCANNING;
	}else if(Cstatus == STATUS_CARD_DONE ){
		m_Message = MSG_STATUS_CARD_DONE;
	}else if(Cstatus == STATUS_CARD_EJECTING ){
		m_Message = MSG_STATUS_CARD_EJECTING;
	}else if(Cstatus == STATUS_CARD_CONFISCATING ){
		m_Message = MSG_STATUS_CARD_CONFISCATING;
	}else if(Cstatus == STATUS_CARD_ABORT ){
		m_Message = MSG_STATUS_CARD_ABORT;
	}



	return Cstatus;
}

SHORT CETTA8IDCardActiveXCtrl::ReadAndScanDpiEx(LONG dpi)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������

	//AfxMessageBox("Begin Activex ReadAndScanEx Method!");
	BOOL bScanOk = FALSE;
	//define bitmap file
	SC_CALIBDATA * pTempCalibData;
	SC_CALIBDATA tempCalibData;
	pTempCalibData=&tempCalibData;
	*pTempCalibData=CalibData;
	//if (MessageBox("Calibrate scan data?","scan",MB_YESNO)==IDNO)
	//{
	//	(SC_CALIBDATA * )memset(pTempCalibData,0,sizeof(CalibData));
	//}

	FILE*          pFile1 = NULL;
	FILE*          pFile2 = NULL;
	FILE*          pFile3 = NULL;
	FILE*          pFile4 = NULL;
	//AfxMessageBox("Begin Activex ReadAndScanEx Method2!");

	DWORD dwStart;
	const long cntlImgLinePerBlock = 8;//8;//block one change to four //Changed by liqian on 2010-11-08 for test
	char ImgFilePath1[260],ImgFilePath2[260],ImgFilePath3[260],ImgFilePath4[260];
	char ImgFilePath1Jpg[260],ImgFilePath2Jpg[260],ImgFilePath3Jpg[260],ImgFilePath4Jpg[260];
	unsigned char *pBmp1=NULL,*pBmp2=NULL,*pBmp3=NULL,*pBmp4=NULL;

	CString disdata;
	CString	dispinfo;
	//AfxMessageBox("Begin Activex ReadAndScanEx Method3!");

	//m_staticinfo.SetWindowText(dispinfo);
	long			lImgW = const_imgW;
	long			lImgH = Const_MaxImageHeight;//const_imgH;
	long			lImgLineScaned = 0;
	long			lImgLineOfLastBlock = 0;
	unsigned char*	pImgBuf = NULL;
	int				nBytesPerLine = 0;/*image bytes per scann-line*/
	int				nStartScanPos  = 0;
	int				nLineBytesForward,nLineBytesReverse;
	int				nOffsetForward,nOffsetReverse;
	long			lImgLinePerBlock = cntlImgLinePerBlock;//block one change to four
	SC_STATUS		status;
	SC_STATUS Cstatus; 
	BOOL bReadDataForwardOk=FALSE,bReadDataReverseOk=FALSE;
	char AA[1024] = {0};
	unsigned short mIs_ScanOver = 0;

	dispinfo.Format("");
	//AfxMessageBox("Begin Activex ReadAndScanEx Method4!");

	//check device has been opened
	if(!scan_running)
	{
		//AfxMessageBox("Begin Activex ReadAndScanEx Method5!");
		//Notice();
	}
	//AfxMessageBox("Begin Activex ReadAndScanEx Method5!");
	status = SYSCAN_StartSuckCard();
	if (status != SCS_OK)
	{
		dispinfo.Format("Start suck card failed");
		//AfxMessageBox(dispinfo);
		return -1;
	}
	//check card status
	DWORD dwEnd;
	dwStart = GetTickCount();
	//while (1)
	//{
	dwEnd = GetTickCount();
	//AfxMessageBox("Begin Activex ReadAndScanEx Method6!");
	if (dwEnd - dwStart > 10000)
	{
		dispinfo.Format("Wait card timeout");
		//AfxMessageBox(dispinfo);
		status = SYSCAN_CancelSuckCard();
		if (status != SCS_OK)
		{
			dispinfo.Format("Cancel suck card error");
			//AfxMessageBox(dispinfo);
		}
		return -1;
	}
	//AfxMessageBox("Begin Activex ReadAndScanEx Method7!");
	status = SYSCAN_GetCardStatus(&Cstatus);
	dispinfo.Format("get card Status->%d",status);
	//AfxMessageBox(dispinfo);
	if(status != SCS_OK)
	{
		dispinfo.Format("SC_COMMUNICATION_ERR");
		//AfxMessageBox(dispinfo);
		return -1;
	}
	if(Cstatus == STATUS_CARD_NONE)
	{
		dispinfo.Format("please insert card");
		//AfxMessageBox(dispinfo);
		return -1;
	}
	else if((Cstatus != STATUS_CARD_F_READY) && (Cstatus != STATUS_CARD_R_READY) && (Cstatus != STATUS_CARD_DONE))
	{
		dispinfo.Format("scanner is busy");
		//AfxMessageBox(dispinfo);
		return -1;
	}
	//else
	//{
		//AfxMessageBox("Begin Activex ReadAndScanEx Method8!");
		//return -1;
	//}
	//}
	//check card status complete
 //AfxMessageBox("Begin Read RFID");
	//Read RFID
	id_Card acard;
	memset(&acard,0,sizeof(acard));
	 //AfxMessageBox("Begin SYSCAN_ReadRFIDInfo ");
	status = SYSCAN_ReadRFIDInfo(&acard);
	dispinfo.Format("SYSCAN_ReadRFIDInfo Status->%d",status);
    //AfxMessageBox(dispinfo);
	//AfxMessageBox("End Read RFID");
	if (status == SCS_OK)
	{
		char id_Name[30] = {0};			  //����	  30   bytes
		char id_Sex[4] = {0};				  //�Ա�	  2    bytes
		char id_National[4] = {0};		  //����	  4    bytes
		char id_Born[16] = {0};			  //����	  16   bytes
		char id_Home[70] = {0};			  //��ͥ	  70   bytes
		char id_Code[36] = {0};			  //���֤��  36   bytes
		char id_RegOrg[30] = {0};		  //����	  30   bytes
		char id_ValidPeriod[32] = {0};	  //��Ч����  32   bytes 	 
		char id_NewAddr[36] = {0};		  //���µ�ַ  36   bytes


		char	strTmp1[300];

		LPSTR	lpBmpData = NULL;

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_Name,15,strTmp1,300,NULL,NULL);

		strcpy(id_Name, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,&(acard.id_Sex),1,strTmp1,300,NULL,NULL);
		if (1==atoi(strTmp1)) 
		{
			strcpy(id_Sex, "��");
			this->m_SexCode=1;
		}
		else if (2==atoi(strTmp1))
		{	strcpy(id_Sex, "Ů");
           this->m_SexCode=2;
		}
		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_National,2,strTmp1,300,NULL,NULL);
		strcpy(id_National, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_Born,8,strTmp1,300,NULL,NULL);
		strcpy(id_Born, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_Home,35,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_Home, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_Code,18,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_Code, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_RegOrg,15,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_RegOrg, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_ValidPeriod,16,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_ValidPeriod, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_NewAddr,18,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_NewAddr, strTmp1);


		char str[1284];
		memset(str,0,1284);
		this->m_Address=_com_util::ConvertStringToBSTR(id_Home);
		this->m_Name=_com_util::ConvertStringToBSTR(id_Name);
		this->m_NationCode=_com_util::ConvertStringToBSTR(id_National);
		this->InitNationArray();
		this->m_NationName=this->m_nationArray.Get(this->m_NationCode);
		this->m_SexName=_com_util::ConvertStringToBSTR(id_Sex);
		this->m_Birth=_com_util::ConvertStringToBSTR(id_Born);
		this->m_IdCard=_com_util::ConvertStringToBSTR(id_Code);
		this->m_Fzjg=_com_util::ConvertStringToBSTR(id_RegOrg);
		this->m_YxqxName=_com_util::ConvertStringToBSTR(id_ValidPeriod);
		
		
		this->bViewBmp = TRUE;
		//AfxMessageBox("����WLT�ļ���ʼ");
		if(! this->CreateWltFile(acard.id_pImage))//CREATE WLT FILE
		{
		    //AfxMessageBox("create WLT file fail");
			//AfxMessageBox("����WLT�ļ�ʧ��");
			return SCS_RDTYPE2FILEERR;
		}

		//AfxMessageBox("����WLT�ļ�����");
		//AfxMessageBox("FileWltToBmp�ļ���ʼ");
		//if(!this->FileWltToBmp())				//CHANGE WLT FILE INTO BMP FILE
		//{
			//AfxMessageBox("FileWltToBmp file fail");
			//return SCS_RDTYPE2FILEERR;
		//}
		//AfxMessageBox("FileWltToBmp�ļ�����");

		/*
		if (!this->bViewBmp) return -1;
		CBitmap bmp;

		BITMAP Bitmap;
		HDC hSrcDC=NULL;
		HDC hDesDC=NULL;
		if(bmp.m_hObject!=NULL)
			DeleteObject(bmp.m_hObject);
		hDesDC = GetDC()->m_hDC;
		hSrcDC = CreateCompatibleDC(hDesDC);
		if(hSrcDC==NULL)
		{
			return -1;
		}
		bmp.m_hObject=(HBITMAP)LoadImage(NULL,
			"Picture.bmp",
			IMAGE_BITMAP,
			0,
			0,
			LR_CREATEDIBSECTION | LR_LOADFROMFILE|LR_CREATEDIBSECTION);
		if( bmp.m_hObject == NULL )
		{
			DeleteDC(hSrcDC);
			return -1;
		}

		GetObject(bmp.m_hObject, sizeof BITMAP, &Bitmap);
		SelectObject(hSrcDC, bmp.m_hObject);
		::SetStretchBltMode(hDesDC,COLORONCOLOR); 
		RECT rect,dlgRect;
		
		DeleteDC(hSrcDC);

		*/
		//this->ViewBmp();
		//this->UpdateWindow();
	}
	/*BOOL bRes;
	char pCardInfoBuf[1024];
	memset(pCardInfoBuf,0,1024);

	bRes = this->ReadRFID(pCardInfoBuf);
	if (!bRes)
	{
	dispinfo.Format("Read RFID failed!");
	m_staticinfo.SetWindowText(dispinfo);
	}
	else
	{
	//m_staticinfo.SetWindowText(pCardInfoBuf);
	//MessageBox(pCardInfoBuf,NULL,MB_OK);
	m_eInfo.SetWindowText(pCardInfoBuf);
	}*/
	//ReadRFID complete

	//set the bitmap filename
	//char *=_com_util::ConvertBSTRToString();

	LPTSTR   prefpath   =   this->m_ImgPathPreX.GetBuffer(); 
	//   ���������ʹ��p�Ĵ��� 
	if(prefpath   !=   NULL)   
		*prefpath   =   _T( '\0 '); 
		this->m_ImgPathPreX.ReleaseBuffer();   //   ʹ�����ʱ�ͷţ��Ա���ʹ��������CString��Ա���� 


		GetExePath(ImgFilePath1);
		strcat(ImgFilePath1,"Picture1.bmp");
		GetExePath(ImgFilePath1Jpg);
		strcat(ImgFilePath1Jpg,"Picture1.jpg");


		GetExePath(ImgFilePath2);
		strcat(ImgFilePath2,"Picture2.bmp");
		GetExePath(ImgFilePath2Jpg);
		strcat(ImgFilePath2Jpg,"Picture2.jpg");

		GetExePath(ImgFilePath3);
		strcat(ImgFilePath3,"Picture3.bmp");
		GetExePath(ImgFilePath3Jpg);
		strcat(ImgFilePath3Jpg,"Picture3.jpg");

		GetExePath(ImgFilePath4);
		strcat(ImgFilePath4,"Picture4.bmp");
		GetExePath(ImgFilePath4Jpg);
		strcat(ImgFilePath4Jpg,"Picture4.jpg");

	//set bitmap filename complete

	//check scan mode
	if(modeA8.mode_u == 16)	
	{
		nLineBytesForward = const_imgW * 3;
		nOffsetForward = 54;
	}
	else
	{
		nLineBytesForward = const_imgW;    
		nOffsetForward = 1078;
	}

	if(modeA8.mode_u == 16)
	{
		nLineBytesReverse = const_imgW * 3;
		nOffsetReverse = 54;
	}
	else
	{
		nLineBytesReverse = const_imgW; 
		nOffsetReverse = 1078;
	}

	/**  hhlin
	unsigned char *Bmp1 = new unsigned char[const_imgW * 3 * Const_MaxImageHeight];
	unsigned char *Bmp2 = new unsigned char[const_imgW * 3 * Const_MaxImageHeight];
	//unsigned char *Bmp3 = new unsigned char[const_imgW * 3 * Const_MaxImageHeight];
	//unsigned char *Bmp4 = new unsigned char[const_imgW * 3 * Const_MaxImageHeight];
	BYTE *pImgBuf1=new unsigned char [3 * const_imgW * cntlImgLinePerBlock];
	BYTE *pImgBuf2=new unsigned char [3 * const_imgW * cntlImgLinePerBlock];
	//BYTE *pImgBuf3=new unsigned char [3 * const_imgW * cntlImgLinePerBlock];
	//BYTE *pImgBuf4=new unsigned char [3 * const_imgW * cntlImgLinePerBlock];
	pBmp1 = Bmp1 + nLineBytesForward * Const_MaxImageHeight;
	pBmp2 = Bmp2 + nLineBytesForward * Const_MaxImageHeight;

	**/

	int iRet;
    unsigned long lImgW1=600,lImgH1=400;
	//AfxMessageBox("��ʼɨ��");
	iRet=SYSCAN_GetImgFromUnit(dpi,ImgFilePath1,&lImgW1,&lImgH1,ImgFilePath2,&lImgW1,&lImgH1);
	//AfxMessageBox("����ɨ��");
    if(iRet == 0)
	{
		//AfxMessageBox("scan success");
		//iRet = SYSCAN_GetHeadFromImage(ImgFilePath1,ImgFilePath2,"c:\\imgHead.bmp");
	}else {
		SYSCAN_EjectCard();
        SYSCAN_ResetDevice();
	    AfxMessageBox("ͼƬɨ���쳣���豸�Ѹ�λ��������");
	}
	//pBmp3 = Bmp3 + nLineBytesReverse * Const_MaxImageHeight;
	//pBmp4 = Bmp4 + nLineBytesReverse * Const_MaxImageHeight;

   //AfxMessageBox("send scan command");
	//status = SYSCAN_BeginScan(&modeA8);

/**   hhlin
	status = 0;
	status=SYSCAN_BeginScan();//20080304,chx
	if(status != SCS_OK)
	{
		//dispinfo.Format("SYSCAN_BeginScan ERR;%d",status);
		//m_staticinfo.SetWindowText(dispinfo);
		dispinfo.Format("ͼƬɨ��;%d",status);
		AfxMessageBox(dispinfo);
		goto FreeBuffer;
	}
	//send scan command ok

	//if card at the end of device
	if(Cstatus == STATUS_CARD_R_READY)        
	{
		dwStart = GetTickCount();
		goto scanRev;
	}

	//////////////////////////read data from buffer
	////////////////forward
	dwStart = GetTickCount();
	dispinfo.Format("read image1 and image2 ...");
	//m_staticinfo.SetWindowText(dispinfo);  
	//AfxMessageBox(dispinfo);
	//read scan data
	bReadDataForwardOk=TRUE;
	//
	//lImgH = 200;

	while(1)
	{
		//get one block
		lImgLinePerBlock = SYSCAN_GetImageBlockA8(pImgBuf1,pImgBuf2, (short)lImgLinePerBlock,0,&mIs_ScanOver);
		lImgLineScaned += lImgLinePerBlock;
		if (lImgLinePerBlock < 0)
		{
			//this->GetDeviceStatusEx();
			//dispinfo.Format("%s err:%04d",m_Message, lImgLineScaned);
			//m_staticinfo.SetWindowText(dispinfo);
			//AfxMessageBox(dispinfo);

			sprintf(AA,"lImgLinePerBlock=%d\r\n",lImgLinePerBlock);
			//m_eInfo.SetWindowText(AA);

			//UpdateData(FALSE);
			//UpdateData();
			//AfxMessageBox("SYSCAN_GetImageBlock_1() failed!\n");
			//AfxMessageBox("��ȡɨ��ͼƬʧ��!\n");
        
			bReadDataForwardOk=FALSE;		
			//goto WriteDataToFile;
			continue;
		}

		//Put image data into memory block
		pBmp1 -= nLineBytesForward * lImgLinePerBlock;
		memcpy(pBmp1,pImgBuf1,nLineBytesForward * lImgLinePerBlock);

		pBmp2 -= nLineBytesForward * lImgLinePerBlock;              
		memcpy(pBmp2,pImgBuf2,nLineBytesForward * lImgLinePerBlock);
		lImgLineOfLastBlock = lImgLinePerBlock;

		if(mIs_ScanOver == SCAN_COMPLETE_HAUL)
			goto scanRev;
		if(mIs_ScanOver == SCAN_COMPLETE_SUCCESS)
			goto WriteDataToFile;
	}//end while	
	//dispinfo.Format("scan OK forward");
	dispinfo.Format("ɨ��ɹ�");
	//AfxMessageBox(dispinfo);
	//m_staticinfo.SetWindowText(dispinfo);
	//this->UpdateWindow();
	//read forward data complete
	//if (!modeA8.auto_reverse)
	//{
	//	SYSCAN_EndScan();
	//	goto WriteDataToFile;
	//}//if needless reverse ,end scan and return

	///////////////reverse
scanRev:
	//read bmp data
	dispinfo.Format("read backtrack image ...");
	//AfxMessageBox(dispinfo);
	//m_staticinfo.SetWindowText(dispinfo);
	//this->UpdateWindow();
	lImgLineScaned = 0;
	lImgLineOfLastBlock = 0;
	bReadDataReverseOk=TRUE;
	mIs_ScanOver = 0;
	pBmp1 = Bmp1 + nLineBytesForward * Const_MaxImageHeight;
	pBmp2 = Bmp2 + nLineBytesForward * Const_MaxImageHeight;

	while (1)
	{
		//get one block
		lImgLinePerBlock = SYSCAN_GetImageBlockA8(pImgBuf1,pImgBuf2, (short)lImgLinePerBlock,1,&mIs_ScanOver);
		lImgLineScaned += lImgLinePerBlock;
		if (lImgLinePerBlock < 0)
		{
			dispinfo.Format("err:%04d",lImgLineScaned);
			//AfxMessageBox(dispinfo);
			//m_staticinfo.SetWindowText(dispinfo);

			sprintf(AA,"lImgLinePerBlock=%d\r\n",lImgLinePerBlock);
			//m_eInfo.SetWindowText(AA);


			//UpdateData(FALSE);
			//UpdateData();

			//AfxMessageBox("SYSCAN_GetImageBlock_2() failed!\n");
			bReadDataReverseOk=FALSE;
			goto WriteDataToFile;
		}
		else if (lImgLinePerBlock == 0)
		{
			dispinfo.Format("err:No image");
			//AfxMessageBox(dispinfo);
			//m_staticinfo.SetWindowText(dispinfo);
			goto WriteDataToFile;
		}
		pBmp1 -= nLineBytesReverse * lImgLinePerBlock;
		memcpy(pBmp1,pImgBuf1,nLineBytesReverse * lImgLinePerBlock);

		pBmp2 -= nLineBytesReverse * lImgLinePerBlock;
		memcpy(pBmp2,pImgBuf2,nLineBytesReverse * lImgLinePerBlock);

		lImgLineOfLastBlock = lImgLinePerBlock;

		if(mIs_ScanOver == SCAN_COMPLETE_HAUL)
			break;
		if(mIs_ScanOver == SCAN_COMPLETE_SUCCESS)
			break;
	}//end while
	//SYSCAN_EndScan();
	//read reverse data complete
	//////////////////////////read data from buffer complete
	bScanOk = TRUE;
	//////////////////////write buffer data to file
WriteDataToFile:
	SYSCAN_EndScan();

	this->nScanTimes++;
	dwStart = GetTickCount() - dwStart;
	dispinfo.Format("scan ok time = %08d ms; scan times:%d",dwStart,this->nScanTimes);
	//AfxMessageBox(dispinfo);
	//m_staticinfo.SetWindowText(dispinfo);

	//300DPI
	int nDpi,cusWidth,cusHeight;
	BOOL b300Dpi;
	int nBytesOfOneLine;
	int mode;

	//b300Dpi = this->m_b300dpi.GetCheck();
	b300Dpi=true;
	if (b300Dpi)	//300dpi
	{
		nDpi = 300;
		cusHeight = (lImgLineScaned+1) / 2;
		cusWidth = const_imgW / 2;

		if (modeA8.mode_u == 16)	//��ɫģʽ��ÿ��3BYTE
		{
			nBytesOfOneLine = cusWidth * 3;
			mode = 1;
		}
		else	//����ģʽ��ÿ��1BYTE
		{
			nBytesOfOneLine = cusWidth;
			mode = 0;
		}

		BYTE *p300buf = new BYTE[nBytesOfOneLine * cusHeight];
		SYSCAN_Dpi600To300(pBmp1,p300buf,const_imgW,lImgLineScaned,mode);	//��������ͼ������
		memcpy(pBmp1,p300buf,nBytesOfOneLine * cusHeight);
		SYSCAN_Dpi600To300(pBmp2,p300buf,const_imgW,lImgLineScaned,mode);
		memcpy(pBmp2,p300buf,nBytesOfOneLine * cusHeight);
	}
	else	//600dpi
	{

		nDpi = 600;
		cusWidth = const_imgW;
		cusHeight = lImgLineScaned;

		if (modeA8.mode_u == 16)	//��ɫģʽ��ÿ��3BYTE
		{
			nBytesOfOneLine = cusWidth * 3;
		}
		else	//����ģʽ��ÿ��1BYTE
		{
			nBytesOfOneLine = cusWidth;
		}
	}
	//END 300DPI
	//write data to bmp1,2
	//if (bReadDataForwardOk)
	//{
	//AfxMessageBox(ImgFilePath1);
	//dispinfo.Format("%s",ImgFilePath1);
	//AfxMessageBox(dispinfo);
	pFile1 = fopen(ImgFilePath1,"wb");	//bitmap file 1
	if (!pFile1 || !WriteBMPFileHeader(pFile1,cusWidth,cusHeight,nDpi,modeA8.mode_u,nBytesOfOneLine))	//add for 300dpi
	{
		//err handle
		dispinfo.Format("pFile || WriteBMPFileHeader Err");
		//AfxMessageBox(dispinfo);
		goto FreeBuffer;      
	}
	pFile2 = fopen(ImgFilePath2,"wb");	//bitmap file 2
	if (!pFile1 || !WriteBMPFileHeader(pFile2,cusWidth,cusHeight,nDpi,modeA8.mode_u,nBytesOfOneLine))	//add for 300dpi
	{
		//err handle
		dispinfo.Format("pFile || WriteBMPFileHeader Err");
		//AfxMessageBox(dispinfo);
		goto FreeBuffer;
	}
	//create bitmap file complete
	//write bmp 1
	if (0 != fseek(pFile1,nOffsetForward ,SEEK_SET))
	{
		dispinfo.Format("disk file I/O failed!\n");
		//AfxMessageBox(dispinfo);
		//m_staticinfo.SetWindowText(dispinfo);
	}
	if ((unsigned int)nBytesOfOneLine * cusHeight != fwrite(pBmp1,1,nBytesOfOneLine * cusHeight,pFile1))	//add for 300dpi
	{
		dispinfo.Format("disk file I/O failed!\n");
		//AfxMessageBox(dispinfo);
		//m_staticinfo.SetWindowText(dispinfo);
	}
	//write bmp 2
	if (0 != fseek(pFile2,nOffsetForward ,SEEK_SET))
	{
		dispinfo.Format("disk file I/O failed!\n");
		//AfxMessageBox(dispinfo);
		//m_staticinfo.SetWindowText(dispinfo);
	}
	if ((unsigned int)nBytesOfOneLine * cusHeight != fwrite(pBmp2,1,nBytesOfOneLine * cusHeight,pFile2))	//add for 300dpi
	{
		dispinfo.Format("disk file I/O failed!\n");
		//AfxMessageBox(dispinfo);
		//m_staticinfo.SetWindowText(dispinfo);
	}
	//close file 12
	if (pFile1)
	{
		fclose(pFile1);
		pFile1 = NULL;
	}
	if (pFile2)
	{
		fclose(pFile2);
		pFile2 = NULL;
	}
	//}//end if bReadDataForwardOk

	//write buffer data to bmp3,4
	/*	if (bReadDataReverseOk)
	{
	pFile3 = fopen(ImgFilePath3,"wb");	//bmp3
	if (!pFile3 || !WriteBMPFileHeader(pFile3,const_imgW,lImgLineScaned,600,modeA8.mode_u,nLineBytesReverse))
	{
	//err handle
	dispinfo.Format("pFile || WriteBMPFileHeader Err");
	goto FreeBuffer;
	}
	pFile4 = fopen(ImgFilePath4,"wb");	//bmp4
	if (!pFile4 || !WriteBMPFileHeader(pFile4,const_imgW,lImgLineScaned,600,modeA8.mode_u,nLineBytesReverse))		
	{
	//err handle
	dispinfo.Format("pFile || WriteBMPFileHeader Err");
	goto FreeBuffer;
	}
	//write bmp 3
	if (0 != fseek(pFile3,nOffsetReverse ,SEEK_SET))
	{
	dispinfo.Format("disk file I/O failed!\n");
	m_staticinfo.SetWindowText(dispinfo);
	}
	if ((unsigned int)nLineBytesReverse * lImgLineScaned != fwrite(pBmp3,1,nLineBytesReverse * lImgLineScaned,pFile3))
	{
	dispinfo.Format("disk file I/O failed!\n");
	m_staticinfo.SetWindowText(dispinfo);
	}
	//write bmp 4
	if (0 != fseek(pFile4,nOffsetReverse ,SEEK_SET))
	{
	dispinfo.Format("disk file I/O failed!\n");
	m_staticinfo.SetWindowText(dispinfo);
	}
	if ((unsigned int)nLineBytesReverse * lImgLineScaned != fwrite(pBmp4,1,nLineBytesReverse * lImgLineScaned,pFile4))
	{
	dispinfo.Format("disk file I/O failed!\n");
	m_staticinfo.SetWindowText(dispinfo);
	}
	//close file
	if (pFile3)
	{
	fclose(pFile3);
	pFile3 = NULL;
	}
	if (pFile4)
	{
	fclose(pFile4);
	pFile4 = NULL;
	}
	}//end if bReadDataReverseOk
	*/
	//JPEG

  /** hhlin

	BOOL bJpeg;
	//bJpeg = m_bJpeg.GetCheck();
	bJpeg=false;
	if (bJpeg)	//�ж��Ƿ�Ҫѹ����JPEG��ʽ
	{
		SYSCAN_BmpToJpeg(ImgFilePath1,ImgFilePath1Jpg);
		SYSCAN_BmpToJpeg(ImgFilePath2,ImgFilePath2Jpg);
		/*if (bReadDataReverseOk)
		{
		SYSCAN_BmpToJpeg(ImgFilePath3,ImgFilePath3Jpg);
		SYSCAN_BmpToJpeg(ImgFilePath4,ImgFilePath4Jpg);
		}*/
//	}
	//JPEG
/**
	//write buffer data to bmp OK
	/////////////////////Free buffer
FreeBuffer:
	free(Bmp1);
	free(Bmp2);
	//free(Bmp3);
	//free(Bmp4);
	free(pImgBuf1);
	free(pImgBuf2);
	//free(pImgBuf3);
	//free(pImgBuf4);

	//	this->OnBtnEje();
**/
	return 0;
}

SHORT CETTA8IDCardActiveXCtrl::ReadAndScan2Ex(void)
{
	AFX_MANAGE_STATE(AfxGetStaticModuleState());

	// TODO: �ڴ���ӵ��ȴ���������

		// TODO: �ڴ���ӵ��ȴ���������

	//AfxMessageBox("Begin Activex ReadAndScanEx Method!");
	BOOL bScanOk = FALSE;
	//define bitmap file
	SC_CALIBDATA * pTempCalibData;
	SC_CALIBDATA tempCalibData;
	pTempCalibData=&tempCalibData;
	*pTempCalibData=CalibData;
	//if (MessageBox("Calibrate scan data?","scan",MB_YESNO)==IDNO)
	//{
	//	(SC_CALIBDATA * )memset(pTempCalibData,0,sizeof(CalibData));
	//}

	FILE*          pFile1 = NULL;
	FILE*          pFile2 = NULL;
	FILE*          pFile3 = NULL;
	FILE*          pFile4 = NULL;
	//AfxMessageBox("Begin Activex ReadAndScanEx Method2!");

	DWORD dwStart;
	const long cntlImgLinePerBlock = 8;//8;//block one change to four //Changed by liqian on 2010-11-08 for test
	char ImgFilePath1[260],ImgFilePath2[260],ImgFilePath3[260],ImgFilePath4[260];
	char ImgFilePath1Jpg[260],ImgFilePath2Jpg[260],ImgFilePath3Jpg[260],ImgFilePath4Jpg[260];
	unsigned char *pBmp1=NULL,*pBmp2=NULL,*pBmp3=NULL,*pBmp4=NULL;

	CString disdata;
	CString	dispinfo;
	//AfxMessageBox("Begin Activex ReadAndScanEx Method3!");

	//m_staticinfo.SetWindowText(dispinfo);
	long			lImgW = const_imgW;
	long			lImgH = Const_MaxImageHeight;//const_imgH;
	long			lImgLineScaned = 0;
	long			lImgLineOfLastBlock = 0;
	unsigned char*	pImgBuf = NULL;
	int				nBytesPerLine = 0;/*image bytes per scann-line*/
	int				nStartScanPos  = 0;
	int				nLineBytesForward,nLineBytesReverse;
	int				nOffsetForward,nOffsetReverse;
	long			lImgLinePerBlock = cntlImgLinePerBlock;//block one change to four
	SC_STATUS		status;
	SC_STATUS Cstatus; 
	BOOL bReadDataForwardOk=FALSE,bReadDataReverseOk=FALSE;
	char AA[1024] = {0};
	unsigned short mIs_ScanOver = 0;

	dispinfo.Format("");
	//AfxMessageBox("Begin Activex ReadAndScanEx Method4!");

	//check device has been opened
	if(!scan_running)
	{
		//AfxMessageBox("Begin Activex ReadAndScanEx Method5!");
		//Notice();
	}
	//AfxMessageBox("Begin Activex ReadAndScanEx Method5!");
	status = SYSCAN_StartSuckCard();
	if (status != SCS_OK)
	{
		dispinfo.Format("Start suck card failed");
		//AfxMessageBox(dispinfo);
		return -1;
	}
	//check card status
	DWORD dwEnd;
	dwStart = GetTickCount();
	//while (1)
	//{
	dwEnd = GetTickCount();
	//AfxMessageBox("Begin Activex ReadAndScanEx Method6!");
	if (dwEnd - dwStart > 10000)
	{
		//dispinfo.Format("Wait card timeout");
		//AfxMessageBox(dispinfo);
		status = SYSCAN_CancelSuckCard();
		if (status != SCS_OK)
		{
			dispinfo.Format("Cancel suck card error");
			//AfxMessageBox(dispinfo);
		}
		return -1;
	}
	//AfxMessageBox("Begin Activex ReadAndScanEx Method7!");
	status = SYSCAN_GetCardStatus(&Cstatus);
	dispinfo.Format("get card Status->%d",status);
	//AfxMessageBox(dispinfo);
	if(status != SCS_OK)
	{
		dispinfo.Format("SC_COMMUNICATION_ERR");
		//AfxMessageBox(dispinfo);
		return -1;
	}
	if(Cstatus == STATUS_CARD_NONE)
	{
		dispinfo.Format("please insert card");
		//AfxMessageBox(dispinfo);
		return -1;
	}
	else if((Cstatus != STATUS_CARD_F_READY) && (Cstatus != STATUS_CARD_R_READY) && (Cstatus != STATUS_CARD_DONE))
	{
		dispinfo.Format("scanner is busy");
		//AfxMessageBox(dispinfo);
		return -1;
	}
	//else
	//{
		//AfxMessageBox("Begin Activex ReadAndScanEx Method8!");
		//return -1;
	//}
	//}
	//check card status complete
 //AfxMessageBox("Begin Read RFID");
	//Read RFID
	id_Card acard;
	memset(&acard,0,sizeof(acard));
	 //AfxMessageBox("Begin SYSCAN_ReadRFIDInfo ");
	status = SYSCAN_ReadRFIDInfo(&acard);
	dispinfo.Format("SYSCAN_ReadRFIDInfo Status->%d",status);
    //AfxMessageBox(dispinfo);
	//AfxMessageBox("End Read RFID");
	if (status == SCS_OK)
	{
		char id_Name[30] = {0};			  //����	  30   bytes
		char id_Sex[4] = {0};				  //�Ա�	  2    bytes
		char id_National[4] = {0};		  //����	  4    bytes
		char id_Born[16] = {0};			  //����	  16   bytes
		char id_Home[70] = {0};			  //��ͥ	  70   bytes
		char id_Code[36] = {0};			  //���֤��  36   bytes
		char id_RegOrg[30] = {0};		  //����	  30   bytes
		char id_ValidPeriod[32] = {0};	  //��Ч����  32   bytes 	 
		char id_NewAddr[36] = {0};		  //���µ�ַ  36   bytes


		char	strTmp1[300];

		LPSTR	lpBmpData = NULL;

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_Name,15,strTmp1,300,NULL,NULL);

		strcpy(id_Name, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,&(acard.id_Sex),1,strTmp1,300,NULL,NULL);
		if (1==atoi(strTmp1)) 
		{
			strcpy(id_Sex, "��");
			this->m_SexCode=1;
		}
		else if (2==atoi(strTmp1))
		{	strcpy(id_Sex, "Ů");
           this->m_SexCode=2;
		}
		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_National,2,strTmp1,300,NULL,NULL);
		strcpy(id_National, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_Born,8,strTmp1,300,NULL,NULL);
		strcpy(id_Born, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_Home,35,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_Home, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_Code,18,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_Code, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_RegOrg,15,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_RegOrg, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_ValidPeriod,16,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_ValidPeriod, strTmp1);

		memset(strTmp1,0x00,300);
		WideCharToMultiByte(0,0,acard.id_NewAddr,18,strTmp1,/*0*/300,NULL,NULL);
		strcpy(id_NewAddr, strTmp1);


		char str[1284];
		memset(str,0,1284);
		this->m_Address=_com_util::ConvertStringToBSTR(id_Home);
		this->m_Name=_com_util::ConvertStringToBSTR(id_Name);
		this->m_NationCode=_com_util::ConvertStringToBSTR(id_National);
		this->InitNationArray();
		this->m_NationName=this->m_nationArray.Get(this->m_NationCode);
		this->m_SexName=_com_util::ConvertStringToBSTR(id_Sex);
		this->m_Birth=_com_util::ConvertStringToBSTR(id_Born);
		this->m_IdCard=_com_util::ConvertStringToBSTR(id_Code);
		this->m_Fzjg=_com_util::ConvertStringToBSTR(id_RegOrg);
		this->m_YxqxName=_com_util::ConvertStringToBSTR(id_ValidPeriod);
		
		
		this->bViewBmp = TRUE;
		if(! this->CreateWltFile(acard.id_pImage))//CREATE WLT FILE
		{
		    //AfxMessageBox("create WLT file fail");
			AfxMessageBox("����WLT�ļ�ʧ��");
			return SCS_RDTYPE2FILEERR;
		}


		//if(!this->FileWltToBmp())				//CHANGE WLT FILE INTO BMP FILE
		//{
			//AfxMessageBox("FileWltToBmp file fail");
			//return SCS_RDTYPE2FILEERR;
		//}

		/*
		if (!this->bViewBmp) return -1;
		CBitmap bmp;

		BITMAP Bitmap;
		HDC hSrcDC=NULL;
		HDC hDesDC=NULL;
		if(bmp.m_hObject!=NULL)
			DeleteObject(bmp.m_hObject);
		hDesDC = GetDC()->m_hDC;
		hSrcDC = CreateCompatibleDC(hDesDC);
		if(hSrcDC==NULL)
		{
			return -1;
		}
		bmp.m_hObject=(HBITMAP)LoadImage(NULL,
			"Picture.bmp",
			IMAGE_BITMAP,
			0,
			0,
			LR_CREATEDIBSECTION | LR_LOADFROMFILE|LR_CREATEDIBSECTION);
		if( bmp.m_hObject == NULL )
		{
			DeleteDC(hSrcDC);
			return -1;
		}

		GetObject(bmp.m_hObject, sizeof BITMAP, &Bitmap);
		SelectObject(hSrcDC, bmp.m_hObject);
		::SetStretchBltMode(hDesDC,COLORONCOLOR); 
		RECT rect,dlgRect;
		
		DeleteDC(hSrcDC);

		*/
		//this->ViewBmp();
		//this->UpdateWindow();
	}
	/*BOOL bRes;
	char pCardInfoBuf[1024];
	memset(pCardInfoBuf,0,1024);

	bRes = this->ReadRFID(pCardInfoBuf);
	if (!bRes)
	{
	dispinfo.Format("Read RFID failed!");
	m_staticinfo.SetWindowText(dispinfo);
	}
	else
	{
	//m_staticinfo.SetWindowText(pCardInfoBuf);
	//MessageBox(pCardInfoBuf,NULL,MB_OK);
	m_eInfo.SetWindowText(pCardInfoBuf);
	}*/
	//ReadRFID complete

	//set the bitmap filename
	//char *=_com_util::ConvertBSTRToString();

	LPTSTR   prefpath   =   this->m_ImgPathPreX.GetBuffer(); 
	//   ���������ʹ��p�Ĵ��� 
	if(prefpath   !=   NULL)   
		*prefpath   =   _T( '\0 '); 
		this->m_ImgPathPreX.ReleaseBuffer();   //   ʹ�����ʱ�ͷţ��Ա���ʹ��������CString��Ա���� 


		GetExePath(ImgFilePath1);
		strcat(ImgFilePath1,"Picture1.bmp");
		GetExePath(ImgFilePath1Jpg);
		strcat(ImgFilePath1Jpg,"Picture1.jpg");


		GetExePath(ImgFilePath2);
		strcat(ImgFilePath2,"Picture2.bmp");
		GetExePath(ImgFilePath2Jpg);
		strcat(ImgFilePath2Jpg,"Picture2.jpg");

		GetExePath(ImgFilePath3);
		strcat(ImgFilePath3,"Picture3.bmp");
		GetExePath(ImgFilePath3Jpg);
		strcat(ImgFilePath3Jpg,"Picture3.jpg");

		GetExePath(ImgFilePath4);
		strcat(ImgFilePath4,"Picture4.bmp");
		GetExePath(ImgFilePath4Jpg);
		strcat(ImgFilePath4Jpg,"Picture4.jpg");

	//set bitmap filename complete

	//check scan mode
	if(modeA8.mode_u == 16)	
	{
		nLineBytesForward = const_imgW * 3;
		nOffsetForward = 54;
	}
	else
	{
		nLineBytesForward = const_imgW;    
		nOffsetForward = 1078;
	}

	if(modeA8.mode_u == 16)
	{
		nLineBytesReverse = const_imgW * 3;
		nOffsetReverse = 54;
	}
	else
	{
		nLineBytesReverse = const_imgW; 
		nOffsetReverse = 1078;
	}


	unsigned char *Bmp1 = new unsigned char[const_imgW * 3 * Const_MaxImageHeight];
	unsigned char *Bmp2 = new unsigned char[const_imgW * 3 * Const_MaxImageHeight];
	//unsigned char *Bmp3 = new unsigned char[const_imgW * 3 * Const_MaxImageHeight];
	//unsigned char *Bmp4 = new unsigned char[const_imgW * 3 * Const_MaxImageHeight];
	BYTE *pImgBuf1=new unsigned char [3 * const_imgW * cntlImgLinePerBlock];
	BYTE *pImgBuf2=new unsigned char [3 * const_imgW * cntlImgLinePerBlock];
	//BYTE *pImgBuf3=new unsigned char [3 * const_imgW * cntlImgLinePerBlock];
	//BYTE *pImgBuf4=new unsigned char [3 * const_imgW * cntlImgLinePerBlock];
	pBmp1 = Bmp1 + nLineBytesForward * Const_MaxImageHeight;
	pBmp2 = Bmp2 + nLineBytesForward * Const_MaxImageHeight;


	//pBmp3 = Bmp3 + nLineBytesReverse * Const_MaxImageHeight;
	//pBmp4 = Bmp4 + nLineBytesReverse * Const_MaxImageHeight;

   //AfxMessageBox("send scan command");
	//status = SYSCAN_BeginScan(&modeA8);


	status = 0;
	status=SYSCAN_BeginScan();//20080304,chx
	if(status != SCS_OK)
	{
		//dispinfo.Format("SYSCAN_BeginScan ERR;%d",status);
		//m_staticinfo.SetWindowText(dispinfo);
		dispinfo.Format("ͼƬɨ��;%d",status);
		AfxMessageBox(dispinfo);
		goto FreeBuffer;
	}
	//send scan command ok

	//if card at the end of device
	if(Cstatus == STATUS_CARD_R_READY)        
	{
		dwStart = GetTickCount();
		goto scanRev;
	}

	//////////////////////////read data from buffer
	////////////////forward
	dwStart = GetTickCount();
	dispinfo.Format("read image1 and image2 ...");
	//m_staticinfo.SetWindowText(dispinfo);  
	//AfxMessageBox(dispinfo);
	//read scan data
	bReadDataForwardOk=TRUE;
	//
	//lImgH = 200;

	while(1)
	{
		//get one block
		lImgLinePerBlock = SYSCAN_GetImageBlockA8(pImgBuf1,pImgBuf2, (short)lImgLinePerBlock,0,&mIs_ScanOver);
		lImgLineScaned += lImgLinePerBlock;
		if (lImgLinePerBlock < 0)
		{
			//this->GetDeviceStatusEx();
			//dispinfo.Format("%s err:%04d",m_Message, lImgLineScaned);
			//m_staticinfo.SetWindowText(dispinfo);
			//AfxMessageBox(dispinfo);

			sprintf(AA,"lImgLinePerBlock=%d\r\n",lImgLinePerBlock);
			//m_eInfo.SetWindowText(AA);

			//UpdateData(FALSE);
			//UpdateData();
			//AfxMessageBox("SYSCAN_GetImageBlock_1() failed!\n");
			//AfxMessageBox("��ȡɨ��ͼƬʧ��!\n");
        
			bReadDataForwardOk=FALSE;		
			//goto WriteDataToFile;
			continue;
		}

		//Put image data into memory block
		pBmp1 -= nLineBytesForward * lImgLinePerBlock;
		memcpy(pBmp1,pImgBuf1,nLineBytesForward * lImgLinePerBlock);

		pBmp2 -= nLineBytesForward * lImgLinePerBlock;              
		memcpy(pBmp2,pImgBuf2,nLineBytesForward * lImgLinePerBlock);
		lImgLineOfLastBlock = lImgLinePerBlock;

		if(mIs_ScanOver == SCAN_COMPLETE_HAUL)
			goto scanRev;
		if(mIs_ScanOver == SCAN_COMPLETE_SUCCESS)
			goto WriteDataToFile;
	}//end while	
	//dispinfo.Format("scan OK forward");
	dispinfo.Format("ɨ��ɹ�");
	//AfxMessageBox(dispinfo);
	//m_staticinfo.SetWindowText(dispinfo);
	//this->UpdateWindow();
	//read forward data complete
	//if (!modeA8.auto_reverse)
	//{
	//	SYSCAN_EndScan();
	//	goto WriteDataToFile;
	//}//if needless reverse ,end scan and return

	///////////////reverse
scanRev:
	//read bmp data
	dispinfo.Format("read backtrack image ...");
	//AfxMessageBox(dispinfo);
	//m_staticinfo.SetWindowText(dispinfo);
	//this->UpdateWindow();
	lImgLineScaned = 0;
	lImgLineOfLastBlock = 0;
	bReadDataReverseOk=TRUE;
	mIs_ScanOver = 0;
	pBmp1 = Bmp1 + nLineBytesForward * Const_MaxImageHeight;
	pBmp2 = Bmp2 + nLineBytesForward * Const_MaxImageHeight;

	while (1)
	{
		//get one block
		lImgLinePerBlock = SYSCAN_GetImageBlockA8(pImgBuf1,pImgBuf2, (short)lImgLinePerBlock,1,&mIs_ScanOver);
		lImgLineScaned += lImgLinePerBlock;
		if (lImgLinePerBlock < 0)
		{
			dispinfo.Format("err:%04d",lImgLineScaned);
			//AfxMessageBox(dispinfo);
			//m_staticinfo.SetWindowText(dispinfo);

			sprintf(AA,"lImgLinePerBlock=%d\r\n",lImgLinePerBlock);
			//m_eInfo.SetWindowText(AA);


			//UpdateData(FALSE);
			//UpdateData();

			//AfxMessageBox("SYSCAN_GetImageBlock_2() failed!\n");
			bReadDataReverseOk=FALSE;
			goto WriteDataToFile;
		}
		else if (lImgLinePerBlock == 0)
		{
			dispinfo.Format("err:No image");
			//AfxMessageBox(dispinfo);
			//m_staticinfo.SetWindowText(dispinfo);
			goto WriteDataToFile;
		}
		pBmp1 -= nLineBytesReverse * lImgLinePerBlock;
		memcpy(pBmp1,pImgBuf1,nLineBytesReverse * lImgLinePerBlock);

		pBmp2 -= nLineBytesReverse * lImgLinePerBlock;
		memcpy(pBmp2,pImgBuf2,nLineBytesReverse * lImgLinePerBlock);

		lImgLineOfLastBlock = lImgLinePerBlock;

		if(mIs_ScanOver == SCAN_COMPLETE_HAUL)
			break;
		if(mIs_ScanOver == SCAN_COMPLETE_SUCCESS)
			break;
	}//end while
	//SYSCAN_EndScan();
	//read reverse data complete
	//////////////////////////read data from buffer complete
	bScanOk = TRUE;
	//////////////////////write buffer data to file
WriteDataToFile:
	SYSCAN_EndScan();

	this->nScanTimes++;
	dwStart = GetTickCount() - dwStart;
	dispinfo.Format("scan ok time = %08d ms; scan times:%d",dwStart,this->nScanTimes);
	//AfxMessageBox(dispinfo);
	//m_staticinfo.SetWindowText(dispinfo);

	//300DPI
	int nDpi,cusWidth,cusHeight;
	BOOL b300Dpi;
	int nBytesOfOneLine;
	int mode;

	//b300Dpi = this->m_b300dpi.GetCheck();
	b300Dpi=true;
	if (b300Dpi)	//300dpi
	{
		nDpi = 300;
		cusHeight = (lImgLineScaned+1) / 2;
		cusWidth = const_imgW / 2;

		if (modeA8.mode_u == 16)	//��ɫģʽ��ÿ��3BYTE
		{
			nBytesOfOneLine = cusWidth * 3;
			mode = 1;
		}
		else	//����ģʽ��ÿ��1BYTE
		{
			nBytesOfOneLine = cusWidth;
			mode = 0;
		}

		BYTE *p300buf = new BYTE[nBytesOfOneLine * cusHeight];
		SYSCAN_Dpi600To300(pBmp1,p300buf,const_imgW,lImgLineScaned,mode);	//��������ͼ������
		memcpy(pBmp1,p300buf,nBytesOfOneLine * cusHeight);
		SYSCAN_Dpi600To300(pBmp2,p300buf,const_imgW,lImgLineScaned,mode);
		memcpy(pBmp2,p300buf,nBytesOfOneLine * cusHeight);
	}
	else	//600dpi
	{

		nDpi = 600;
		cusWidth = const_imgW;
		cusHeight = lImgLineScaned;

		if (modeA8.mode_u == 16)	//��ɫģʽ��ÿ��3BYTE
		{
			nBytesOfOneLine = cusWidth * 3;
		}
		else	//����ģʽ��ÿ��1BYTE
		{
			nBytesOfOneLine = cusWidth;
		}
	}
	//END 300DPI
	//write data to bmp1,2
	//if (bReadDataForwardOk)
	//{
	//AfxMessageBox(ImgFilePath1);
	//dispinfo.Format("%s",ImgFilePath1);
	//AfxMessageBox(dispinfo);
	pFile1 = fopen(ImgFilePath1,"wb");	//bitmap file 1
	if (!pFile1 || !WriteBMPFileHeader(pFile1,cusWidth,cusHeight,nDpi,modeA8.mode_u,nBytesOfOneLine))	//add for 300dpi
	{
		//err handle
		dispinfo.Format("pFile || WriteBMPFileHeader Err");
		//AfxMessageBox(dispinfo);
		goto FreeBuffer;      
	}
	pFile2 = fopen(ImgFilePath2,"wb");	//bitmap file 2
	if (!pFile1 || !WriteBMPFileHeader(pFile2,cusWidth,cusHeight,nDpi,modeA8.mode_u,nBytesOfOneLine))	//add for 300dpi
	{
		//err handle
		dispinfo.Format("pFile || WriteBMPFileHeader Err");
		//AfxMessageBox(dispinfo);
		goto FreeBuffer;
	}
	//create bitmap file complete
	//write bmp 1
	if (0 != fseek(pFile1,nOffsetForward ,SEEK_SET))
	{
		dispinfo.Format("disk file I/O failed!\n");
		//AfxMessageBox(dispinfo);
		//m_staticinfo.SetWindowText(dispinfo);
	}
	if ((unsigned int)nBytesOfOneLine * cusHeight != fwrite(pBmp1,1,nBytesOfOneLine * cusHeight,pFile1))	//add for 300dpi
	{
		dispinfo.Format("disk file I/O failed!\n");
		//AfxMessageBox(dispinfo);
		//m_staticinfo.SetWindowText(dispinfo);
	}
	//write bmp 2
	if (0 != fseek(pFile2,nOffsetForward ,SEEK_SET))
	{
		dispinfo.Format("disk file I/O failed!\n");
		//AfxMessageBox(dispinfo);
		//m_staticinfo.SetWindowText(dispinfo);
	}
	if ((unsigned int)nBytesOfOneLine * cusHeight != fwrite(pBmp2,1,nBytesOfOneLine * cusHeight,pFile2))	//add for 300dpi
	{
		dispinfo.Format("disk file I/O failed!\n");
		//AfxMessageBox(dispinfo);
		//m_staticinfo.SetWindowText(dispinfo);
	}
	//close file 12
	if (pFile1)
	{
		fclose(pFile1);
		pFile1 = NULL;
	}
	if (pFile2)
	{
		fclose(pFile2);
		pFile2 = NULL;
	}
	//}//end if bReadDataForwardOk

	//write buffer data to bmp3,4
	/*	if (bReadDataReverseOk)
	{
	pFile3 = fopen(ImgFilePath3,"wb");	//bmp3
	if (!pFile3 || !WriteBMPFileHeader(pFile3,const_imgW,lImgLineScaned,600,modeA8.mode_u,nLineBytesReverse))
	{
	//err handle
	dispinfo.Format("pFile || WriteBMPFileHeader Err");
	goto FreeBuffer;
	}
	pFile4 = fopen(ImgFilePath4,"wb");	//bmp4
	if (!pFile4 || !WriteBMPFileHeader(pFile4,const_imgW,lImgLineScaned,600,modeA8.mode_u,nLineBytesReverse))		
	{
	//err handle
	dispinfo.Format("pFile || WriteBMPFileHeader Err");
	goto FreeBuffer;
	}
	//write bmp 3
	if (0 != fseek(pFile3,nOffsetReverse ,SEEK_SET))
	{
	dispinfo.Format("disk file I/O failed!\n");
	m_staticinfo.SetWindowText(dispinfo);
	}
	if ((unsigned int)nLineBytesReverse * lImgLineScaned != fwrite(pBmp3,1,nLineBytesReverse * lImgLineScaned,pFile3))
	{
	dispinfo.Format("disk file I/O failed!\n");
	m_staticinfo.SetWindowText(dispinfo);
	}
	//write bmp 4
	if (0 != fseek(pFile4,nOffsetReverse ,SEEK_SET))
	{
	dispinfo.Format("disk file I/O failed!\n");
	m_staticinfo.SetWindowText(dispinfo);
	}
	if ((unsigned int)nLineBytesReverse * lImgLineScaned != fwrite(pBmp4,1,nLineBytesReverse * lImgLineScaned,pFile4))
	{
	dispinfo.Format("disk file I/O failed!\n");
	m_staticinfo.SetWindowText(dispinfo);
	}
	//close file
	if (pFile3)
	{
	fclose(pFile3);
	pFile3 = NULL;
	}
	if (pFile4)
	{
	fclose(pFile4);
	pFile4 = NULL;
	}
	}//end if bReadDataReverseOk
	*/
	//JPEG

  

	BOOL bJpeg;
	//bJpeg = m_bJpeg.GetCheck();
	bJpeg=false;
	if (bJpeg)	//�ж��Ƿ�Ҫѹ����JPEG��ʽ
	{
		SYSCAN_BmpToJpeg(ImgFilePath1,ImgFilePath1Jpg);
		SYSCAN_BmpToJpeg(ImgFilePath2,ImgFilePath2Jpg);
		/*if (bReadDataReverseOk)
		{
		SYSCAN_BmpToJpeg(ImgFilePath3,ImgFilePath3Jpg);
		SYSCAN_BmpToJpeg(ImgFilePath4,ImgFilePath4Jpg);
		}*/
	}
	//JPEG

	//write buffer data to bmp OK
	/////////////////////Free buffer
FreeBuffer:
	free(Bmp1);
	free(Bmp2);
	//free(Bmp3);
	//free(Bmp4);
	free(pImgBuf1);
	free(pImgBuf2);
	//free(pImgBuf3);
	//free(pImgBuf4);

	//	this->OnBtnEje();


	return 0;
}
